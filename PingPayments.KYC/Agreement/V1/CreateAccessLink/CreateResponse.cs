using PingPayments.Shared;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace PingPayments.KYC.Agreement.V1.CreateAccessLink
{
    public record CreateResponse : ApiResponseBase<AccessLink>
    {
        public CreateResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<AccessLink>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }
        public static CreateResponse Successful(HttpStatusCode statusCode, AccessLink? b, string rb) => new(statusCode, true, b, rb);
        public static CreateResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);
    }
}
