using PingPayments.PaymentsApi.PaymentOrders.Shared.V1;
using PingPayments.Shared;
using System.Net;

namespace PingPayments.PaymentsApi.PaymentOrders.List.V1
{
    public record PaymentOrdersResponse : ApiResponseBase<PaymentOrderList>
    {
        public PaymentOrdersResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<PaymentOrderList>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }
        public static PaymentOrdersResponse Successful(HttpStatusCode statusCode, PaymentOrderList? b, string rb) => new(statusCode, true, b, rb);
        public static PaymentOrdersResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);

        public static implicit operator PaymentOrderList?(PaymentOrdersResponse por) =>
            por?.Body?.SuccessfulResponseBody;

        public static implicit operator PaymentOrder[](PaymentOrdersResponse por) =>
            (por?.Body?.SuccessfulResponseBody)?.PaymentOrders ?? new PaymentOrder[] { };
    }
}