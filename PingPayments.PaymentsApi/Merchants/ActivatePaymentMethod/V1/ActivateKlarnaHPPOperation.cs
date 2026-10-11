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
    public class ActivateKlarnaHPPOperation : OperationBase<(Guid merchantId, ActivateKlarnaHPPRequest request), ActivateKlarnaHPPResponse>
    {
        public ActivateKlarnaHPPOperation(HttpClient httpClient) : base(httpClient) { }

        protected override JsonSerializerOptions JsonSerializerOptions => new()
        {
            Converters = { new JsonStringEnumConverter() },
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        public override async Task<ActivateKlarnaHPPResponse> ExecuteRequest((Guid merchantId, ActivateKlarnaHPPRequest request) request) =>
            await BaseExecute
            (
                POST,
                $"api/v1/merchants/{request.merchantId}/payment_provider_methods/activations",
                request,
                await ToJson(request.request)
            );

        protected override async Task<ActivateKlarnaHPPResponse> ParseHttpResponse(HttpResponseMessage hrm, (Guid merchantId, ActivateKlarnaHPPRequest request) _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => ActivateKlarnaHPPResponse.Successful(hrm.StatusCode, await Deserialize<ActivateKlarnaHPPResponseBody>(responseBody), responseBody),
                _ => ActivateKlarnaHPPResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;
        }
    }
}
