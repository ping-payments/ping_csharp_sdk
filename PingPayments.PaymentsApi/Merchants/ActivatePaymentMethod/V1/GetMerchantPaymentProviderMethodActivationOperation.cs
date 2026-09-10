using PingPayments.PaymentsApi.Merchants.ActivatePaymentMethod.V1.Response;
using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.Merchants.ActivatePaymentMethod.V1
{
    public class GetMerchantPaymentProviderMethodActivationOperation : OperationBase<(Guid merchantId, Guid activationId), MerchantPaymentProviderMethodActivationResponse>
    {
        public GetMerchantPaymentProviderMethodActivationOperation(HttpClient httpClient) : base(httpClient) { }

        protected override JsonSerializerOptions JsonSerializerOptions => new()
        {
            Converters = { new JsonStringEnumConverter() },
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        public override async Task<MerchantPaymentProviderMethodActivationResponse> ExecuteRequest((Guid merchantId, Guid activationId) request) =>
            await BaseExecute(GET, $"api/v1/merchants/{request.merchantId}/payment_provider_methods/activations/{request.activationId}", request);

        protected override async Task<MerchantPaymentProviderMethodActivationResponse> ParseHttpResponse(HttpResponseMessage hrm, (Guid merchantId, Guid activationId) _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => MerchantPaymentProviderMethodActivationResponse.Successful(hrm.StatusCode, await Deserialize<MerchantPaymentProviderMethodActivation>(responseBody), responseBody),
                _ => MerchantPaymentProviderMethodActivationResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;
        }
    }
}
