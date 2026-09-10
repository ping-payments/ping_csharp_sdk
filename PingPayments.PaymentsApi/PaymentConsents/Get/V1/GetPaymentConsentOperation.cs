using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.PaymentConsents.Get.V1
{
    public class GetPaymentConsentOperation : OperationBase<Guid, PaymentConsentResponse>
    {
        public GetPaymentConsentOperation(HttpClient httpClient) : base(httpClient) { }

        protected override JsonSerializerOptions JsonSerializerOptions => new()
        {
            Converters =
            {
                new MethodEnumJsonConvert(),
                new JsonStringEnumConverter(),
            }
        };

        public override async Task<PaymentConsentResponse> ExecuteRequest(Guid paymentConsentId) =>
            await BaseExecute(GET, $"api/v1/payment_consents/{paymentConsentId}", paymentConsentId);

        protected override async Task<PaymentConsentResponse> ParseHttpResponse(HttpResponseMessage hrm, Guid _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => PaymentConsentResponse.Successful(hrm.StatusCode, await Deserialize<PaymentConsent>(responseBody), responseBody),
                _ => PaymentConsentResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;
        }
    }
}
