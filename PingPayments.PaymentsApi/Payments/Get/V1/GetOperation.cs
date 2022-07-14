using PingPayments.Shared.Helpers;
using PingPayments.Shared;
using PingPayments.PaymentsApi.Shared;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using static System.Net.HttpStatusCode;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;


namespace PingPayments.PaymentsApi.Payments.Get.V1
{
    public class GetOperation : OperationBase<(Guid orderId, Guid paymentId), PaymentResponse>
    {
        public GetOperation(HttpClient httpClient) : base(httpClient) { }

        protected override JsonSerializerOptions JsonSerializerOptions => new()
        {
            Converters =
            {
                new MethodEnumJsonConvert(),
                new JsonStringEnumConverter(),
            }
        };

        public override async Task<PaymentResponse> ExecuteRequest((Guid orderId, Guid paymentId) request) =>
            await BaseExecute(GET, $"api/v1/payment_orders/{request.orderId}/payments/{request.paymentId}", request);

        protected override async Task<PaymentResponse> ParseHttpResponse(HttpResponseMessage hrm, (Guid orderId, Guid paymentId) _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => PaymentResponse.Succesful(hrm.StatusCode, await Deserialize<PaymentResponseBody>(responseBody), responseBody),
                _ => PaymentResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;
        }
    }
}
