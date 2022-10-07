using PingPayments.PaymentsApi.PaymentOrders.Shared.V1;
using PingPayments.Shared;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace PingPayments.PaymentsApi.PaymentOrders.Allocations.V1
{

    public record AllocationsResponse : ApiResponseBase<AllocationList>
    {
        public AllocationsResponse(
            HttpStatusCode StatusCode, 
            bool IsSuccessful,
            ResponseBody<AllocationList?> Body,
            string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }

        public static AllocationsResponse Succesful(HttpStatusCode statusCode, AllocationList? allocationList, string rawBody) => new(statusCode, true, allocationList, rawBody);
        public static AllocationsResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? errorResponse, string rawBody) => new(statusCode, false, errorResponse, rawBody);
    }
}
