using PingPayments.PaymentsApi.Payments.Get.V1;
using PingPayments.PaymentsApi.Payments.V1.Initiate.Request;
using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.Payments.Refund.V1
{
    public class RefundOperation : OperationBase<(Guid paymentOrderId, Guid paymentId, RefundRequest refundRequest), RefundResponse>
    {
        public RefundOperation(HttpClient httpClient) : base(httpClient) { }

        protected override JsonSerializerOptions JsonSerializerOptions => new()
        {
            Converters =
            {
                new MethodEnumJsonConvert(),
                new JsonStringEnumConverter()
            }
        };

        public override async Task<RefundResponse> ExecuteRequest((Guid paymentOrderId, Guid paymentId, RefundRequest refundRequest) request) =>
            await BaseExecute
            (
                POST,
                $"api/v1/payment_orders/{request.paymentOrderId}/payments/{request.paymentId}/refund",
                request,
                await ToJson(request.refundRequest)
            );

        protected override async Task<RefundResponse> ParseHttpResponse(HttpResponseMessage hrm, (Guid paymentOrderId, Guid paymentId, RefundRequest refundRequest) _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => RefundResponse.Successful(hrm.StatusCode, await Deserialize<RefundResponseBody>(responseBody), responseBody),
                _ => RefundResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;
        }
    }
}