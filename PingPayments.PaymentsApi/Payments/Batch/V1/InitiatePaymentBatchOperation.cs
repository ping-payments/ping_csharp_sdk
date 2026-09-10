using PingPayments.PaymentsApi.Payments.V1.Initiate.Request;
using PingPayments.Shared;
using PingPayments.Shared.Enums;
using PingPayments.Shared.Helpers;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.Payments.Batch.V1
{
    public class InitiatePaymentBatchOperation : OperationBase<InitiatePaymentBatchRequest, InitiatePaymentBatchResponse>
    {
        public InitiatePaymentBatchOperation(HttpClient httpClient) : base(httpClient) { }

        protected override JsonSerializerOptions JsonSerializerOptions => new()
        {
            Converters =
            {
                new MethodEnumJsonConvert(),
                new JsonStringEnumConverter(),
                new ProviderMethodParametersJsonConvert(),
            },
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        public override async Task<InitiatePaymentBatchResponse> ExecuteRequest(InitiatePaymentBatchRequest request) =>
            await BaseExecute
            (
                POST,
                "api/v1/payment_batches",
                request,
                await ToJson(request)
            );

        protected override async Task<InitiatePaymentBatchResponse> ParseHttpResponse(HttpResponseMessage hrm, InitiatePaymentBatchRequest request)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => InitiatePaymentBatchResponse.Successful(hrm.StatusCode, await Deserialize<InitiatePaymentBatchResponseBody>(responseBody), responseBody),
                _ => InitiatePaymentBatchResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;
        }
    }
}
