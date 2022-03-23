using System;

namespace PaymentsApiSdk.Shared
{
    public record GuidResponse : ApiResponseBase<GuidResponseBody>
    {
        public GuidResponse(int StatusCode, bool IsSuccessful, ResponseBody<GuidResponseBody>? Body) : base(StatusCode, IsSuccessful, Body)
        {
        }

        public static implicit operator Guid(GuidResponse guidResponse) => 
            guidResponse.IsSuccessful && 
            guidResponse?.Body?.SuccesfulResponseBody != null ? 
                guidResponse.Body.SuccesfulResponseBody.Id : 
                Guid.Empty;
    }
}
