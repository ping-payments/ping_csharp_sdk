using PingPayments.PaymentsApi.Allocations.Shared;
using PingPayments.PaymentsApi.PaymentOrders.Shared.V1;
using PingPayments.Shared;
using System.Net;

namespace PingPayments.PaymentsApi.Allocations.List.V1
{
    public record ListAllocationPageResponse : ApiResponseBase<GenericTransfer<Allocation>>
    {
        public ListAllocationPageResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<GenericTransfer<Allocation>>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }
        public static ListAllocationPageResponse Successful(HttpStatusCode statusCode, GenericTransfer<Allocation>? body, string rawBody) => new(statusCode, true, body, rawBody);
        public static ListAllocationPageResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? error, string rawBody) => new(statusCode, false, error, rawBody);

        public static implicit operator GenericTransfer<Allocation>(ListAllocationPageResponse ar) =>
            ar?.Body?.SuccessfulResponseBody ?? new GenericTransfer<Allocation> { };

        public static implicit operator Allocation[](ListAllocationPageResponse ar) =>
            ar?.Body?.SuccessfulResponseBody?.Data ?? new Allocation[] { };

        public static implicit operator PaginationLinks(ListAllocationPageResponse ar) =>
            ar?.Body?.SuccessfulResponseBody?.PaginationLinks ?? new PaginationLinks { };
    }
}
