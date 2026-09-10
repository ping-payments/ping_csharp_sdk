using PingPayments.PaymentsApi.Merchants.ActivatePaymentMethod.V1.Request;
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
    public class ActivatePayPalPPCPOperation : OperationBase<(Guid merchantId, ActivatePayPalPPCPRequest request), ActivatePayPalPPCPResponse>
    {
        public ActivatePayPalPPCPOperation(HttpClient httpClient) : base(httpClient) { }

        protected override JsonSerializerOptions JsonSerializerOptions => new()
        {
            Converters = { new JsonStringEnumConverter() },
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        public override async Task<ActivatePayPalPPCPResponse> ExecuteRequest((Guid merchantId, ActivatePayPalPPCPRequest request) request) =>
            await BaseExecute
            (
                POST,
                $"api/v1/merchants/{request.merchantId}/payment_provider_methods/activations",
                request,
                await ToJson(request.request)
            );

        protected override async Task<ActivatePayPalPPCPResponse> ParseHttpResponse(HttpResponseMessage hrm, (Guid merchantId, ActivatePayPalPPCPRequest request) _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => ActivatePayPalPPCPResponse.Successful(hrm.StatusCode, await Deserialize<ActivatePayPalPPCPResponseBody>(responseBody), responseBody),
                _ => ActivatePayPalPPCPResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;
        }
    }
}
