using PingPayments.PaymentsApi.Allocations.Shared;
using PingPayments.Shared;
using System.Net;

namespace PingPayments.PaymentsApi.PaymentOrders.Allocations.V1
{

    public record AllocationsResponse : ApiResponseBase<Allocation[]>
    {
        public AllocationsResponse(
            HttpStatusCode StatusCode,
            bool IsSuccessful,
            ResponseBody<Allocation[]>? Body,
            string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }

        public static AllocationsResponse Successful(HttpStatusCode statusCode, Allocation[]? allocations, string rawBody) => new(statusCode, true, allocations, rawBody);
        public static AllocationsResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? errorResponse, string rawBody) => new(statusCode, false, errorResponse, rawBody);

        public static implicit operator Allocation[](AllocationsResponse allocationResponse) =>
            (allocationResponse?.Body?.SuccessfulResponseBody) ?? new Allocation[] { };
    }
}
