using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http.Headers;
using PaymentsApiSDK.Interfaces;
using Microsoft.Extensions.Logging;

namespace PaymentsApiSdk
{
    public class PaymentsApiClient : IPaymentsApiClient
    {
        private readonly string _paymentsApiUrl;
        private readonly string _checkoutBaseUrl;
        private readonly ILogger<PaymentsApiClient> _logger;

        public PaymentsApiClient(string paymentsApiUrl, string checkoutBaseUrl, ILogger<PaymentsApiClient> logger)
        {
            _paymentsApiUrl = paymentsApiUrl;
            _checkoutBaseUrl = checkoutBaseUrl;
            _logger = logger;
        }

        public async Task<Option<IInitiatePaymentResponse>> InitiatePayment
        (
            IPaymentRequest payment,
            Guid tenantId,
            Guid merchantId,
            Guid paymentLinkId
        )
        {
            try
            {
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Add("tenant_id", tenantId.ToString());
                client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var values = new Dictionary<string, object>
                {
                    { "currency", payment.Currency },
                    { "merchant_amounts", new Dictionary<string, int>
                        {
                            { merchantId.ToString(), (int)(payment.Amount * 100) }
                        }
                    },
                    { "method", payment.Method switch
                    {
                        PaymentsApiMethodEnum.mobile => "mobile",
                        PaymentsApiMethodEnum.autogiro => "autogiro",
                        PaymentsApiMethodEnum.open_banking => "open_banking",
                        PaymentsApiMethodEnum.card => "card",
                        PaymentsApiMethodEnum.invoice => "invoice", _ => throw new NotImplementedException()
                    }},
                    { "order_items", payment.Items.Select(item=> new Dictionary<string, object>
                        {
                            { "amount", (int)(item.Amount * 100) },
                            { "name", item.Name },
                            { "vat_rate", item.Vat } })
                    },
                    { "payment_order_id", payment.OrderId },
                    { "provider", payment.Provider switch
                    {
                        PaymentsApiProviderEnum.verifone => "verifone",
                        PaymentsApiProviderEnum.bankgirot => "bankgirot",
                        PaymentsApiProviderEnum.open_banking => "open_banking",
                        PaymentsApiProviderEnum.swish => "swish",
                        PaymentsApiProviderEnum.billmate => "billmate",
                        _ => throw new NotImplementedException()
                    }},
                    { "provider_method_parameters", payment.ProviderMetaData.ToDictionary() },
                    { "status_callback_url", $"{_checkoutBaseUrl}/api/payment_links/payment_status" },
                    { "metadata", new Dictionary<string, object> { { "payment_link_id", paymentLinkId } }}
                };

                var postBody = JsonConvert.SerializeObject(values);

                _logger.LogInformation($"IniatePaymentBody: {postBody.Replace("\u0022", "")}");

                var response = await client.SendAsync(new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri($"{_paymentsApiUrl}/api/v1/payment_orders/{payment.OrderId}/payments"),
                    Content = new StringContent(postBody, Encoding.UTF8, "application/json")
                });

                var responseBody = await response.Content.ReadAsStringAsync();
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    _logger.LogError($"{response.StatusCode}: {responseBody}");
                    return Option<IInitiatePaymentResponse>.None;
                }

                return JsonConvert.DeserializeObject<InitiatePaymentResponse>(responseBody);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return Option<IInitiatePaymentResponse>.None;
            }
        }
    }
}
