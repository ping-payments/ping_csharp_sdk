using PingPayments.PaymentsApi.PaymentOrders.Shared.V1;
using PingPayments.PaymentsApi.Shared;
using System.Net;

namespace PingPayments.PaymentsApi.PaymentOrders.Get.V1
{
    public record PaymentOrderResponse : ApiResponseBase<PaymentOrder>
    {
        public PaymentOrderResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<PaymentOrder>? Body) : base(StatusCode, IsSuccessful, Body) { }
        public static PaymentOrderResponse Succesful(HttpStatusCode statusCode, PaymentOrder? b) => new(statusCode, true, b);
        public static PaymentOrderResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e) => new(statusCode, false, e);
    }
}
