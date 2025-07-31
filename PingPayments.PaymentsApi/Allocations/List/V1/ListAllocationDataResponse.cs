using PingPayments.PaymentsApi.Allocations.Shared;
using PingPayments.PaymentsApi.PaymentOrders.Shared.V1;
using PingPayments.Shared;
using System.Net;

namespace PingPayments.PaymentsApi.Allocations.List.V1
{
    public record ListAllocationDataResponse : ApiResponseBase<Allocation[]>
    {
        public ListAllocationDataResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<Allocation[]>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }
        public static ListAllocationDataResponse Successful(HttpStatusCode statusCode, Allocation[]? body, string rawBody) => new(statusCode, true, body, rawBody);
        public static ListAllocationDataResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? error, string rawBody) => new(statusCode, false, error, rawBody);

        public static implicit operator Allocation[](ListAllocationDataResponse allocationResponse) =>
            allocationResponse?.Body?.SuccessfulResponseBody ?? new Allocation[] { };
    }
}
