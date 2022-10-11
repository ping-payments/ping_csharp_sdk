using PingPayments.PaymentsApi.PaymentOrders.Shared.V1;
using PingPayments.Shared;
using System.Net;

namespace PingPayments.PaymentsApi.PaymentOrders.Allocations.V1
{

    public record AllocationsResponse : ApiResponseBase<AllocationList>
    {
        public AllocationsResponse(
            HttpStatusCode StatusCode,
            bool IsSuccessful,
            ResponseBody<AllocationList>? Body,
            string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }

        public static AllocationsResponse Successful(HttpStatusCode statusCode, AllocationList? allocationList, string rawBody) => new(statusCode, true, allocationList, rawBody);
        public static AllocationsResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? errorResponse, string rawBody) => new(statusCode, false, errorResponse, rawBody);

        public static implicit operator AllocationList?(AllocationsResponse allocationResponse) =>
            allocationResponse?.Body?.SuccessfulResponseBody;

        public static implicit operator Allocation[](AllocationsResponse allocationResponse) =>
            (allocationResponse?.Body?.SuccessfulResponseBody)?.Allocations ?? new Allocation[] { };
    }
}
