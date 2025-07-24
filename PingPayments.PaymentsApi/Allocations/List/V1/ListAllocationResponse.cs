using PingPayments.PaymentsApi.Allocations.Shared;
using PingPayments.PaymentsApi.PaymentOrders.Shared.V1;
using PingPayments.Shared;
using System.Net;

namespace PingPayments.PaymentsApi.Allocations.List.V1
{
    public record ListAllocationResponse : ApiResponseBase<Allocation[]>
    {
        public ListAllocationResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<Allocation[]>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }
        public static ListAllocationResponse Successful(HttpStatusCode statusCode, Allocation[]? body, string rawBody) => new(statusCode, true, body, rawBody);
        public static ListAllocationResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? error, string rawBody) => new(statusCode, false, error, rawBody);

        public static implicit operator Allocation[](ListAllocationResponse allocationResponse) =>
            allocationResponse?.Body?.SuccessfulResponseBody ?? new Allocation[] { };
    }
}
