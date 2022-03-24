using PingPayments.PaymentsApi.PaymentOrders.Shared.V1;
using PingPayments.PaymentsApi.Shared;
using System.Net;

namespace PingPayments.PaymentsApi.PaymentOrders.List.V1
{
    public record PaymentOrdersResponse : ApiResponseBase<PaymentOrderList>
    {
        public PaymentOrdersResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<PaymentOrderList>? Body) : base(StatusCode, IsSuccessful, Body) { }
        public static PaymentOrdersResponse Succesful(HttpStatusCode statusCode, PaymentOrderList? b) => new(statusCode, true, b);
        public static PaymentOrdersResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e) => new(statusCode, false, e);
    }
}