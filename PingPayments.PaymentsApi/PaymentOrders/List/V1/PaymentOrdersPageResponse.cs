using PingPayments.PaymentsApi.PaymentOrders.Shared.V1;
using PingPayments.Shared;
using System.Net;

namespace PingPayments.PaymentsApi.PaymentOrders.List.V1
{
    public record PaymentOrdersPageResponse : ApiResponseBase<GenericTransfer<PaymentOrder>>
    {
        public PaymentOrdersPageResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<GenericTransfer<PaymentOrder>>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }
        public static PaymentOrdersPageResponse Successful(HttpStatusCode statusCode, GenericTransfer<PaymentOrder>? b, string rb) => new(statusCode, true, b, rb);
        public static PaymentOrdersPageResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);

        public static implicit operator GenericTransfer<PaymentOrder>(PaymentOrdersPageResponse por) =>
            (por?.Body?.SuccessfulResponseBody) ?? new GenericTransfer<PaymentOrder> { };

        public static implicit operator PaymentOrder[](PaymentOrdersPageResponse por) =>
            (por?.Body?.SuccessfulResponseBody?.Data) ?? new PaymentOrder[] { };

        public static implicit operator PaginationLinks(PaymentOrdersPageResponse por) =>
            (por?.Body?.SuccessfulResponseBody?.PaginationLinks) ?? new PaginationLinks { };
    }
}