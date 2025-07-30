using PingPayments.PaymentsApi.PaymentOrders.Shared.V1;
using PingPayments.Shared;
using System.Net;

namespace PingPayments.PaymentsApi.PaymentOrders.List.V1
{
    public record PaymentOrdersDataResponse : ApiResponseBase<PaymentOrder[]>
    {
        public PaymentOrdersDataResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<PaymentOrder[]>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }
        public static PaymentOrdersDataResponse Successful(HttpStatusCode statusCode, PaymentOrder[]? b, string rb) => new(statusCode, true, b, rb);
        public static PaymentOrdersDataResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);

        public static implicit operator PaymentOrder[](PaymentOrdersDataResponse por) =>
            (por?.Body?.SuccessfulResponseBody) ?? new PaymentOrder[] { };
    }
}