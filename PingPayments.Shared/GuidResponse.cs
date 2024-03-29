﻿using System.Net;

namespace PingPayments.Shared
{
    public record GuidResponse : ApiResponseBase<GuidResponseBody>
    {
        public GuidResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<GuidResponseBody>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody)
        {
        }

        public static implicit operator Guid(GuidResponse guidResponse) =>
            guidResponse.IsSuccessful &&
            guidResponse?.Body?.SuccessfulResponseBody != null ?
                guidResponse.Body.SuccessfulResponseBody.Id :
                Guid.Empty;

        public static GuidResponse Successful(HttpStatusCode statusCode, GuidResponseBody? b, string rb) => new(statusCode, true, b, rb);
        public static GuidResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);
    }
}
