using System;
using System.Net;

namespace PingPayments.PaymentsApi.Shared
{
    public record GuidResponse : ApiResponseBase<GuidResponseBody>
    {
        public GuidResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<GuidResponseBody>? Body) : base(StatusCode, IsSuccessful, Body)
        {
        }

        public static implicit operator Guid(GuidResponse guidResponse) => 
            guidResponse.IsSuccessful && 
            guidResponse?.Body?.SuccesfulResponseBody != null ? 
                guidResponse.Body.SuccesfulResponseBody.Id : 
                Guid.Empty;

        public static GuidResponse Succesful(HttpStatusCode statusCode, GuidResponseBody? b) => new(statusCode, true, b);
        public static GuidResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e) => new(statusCode, false, e);
    }
}
