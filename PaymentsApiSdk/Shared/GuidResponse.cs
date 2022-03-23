namespace PaymentsApiSdk.Shared
{
    public record GuidResponse : ApiResponseBase<GuidResponseBody>
    {
        public GuidResponse(int StatusCode, bool IsSuccessful, ResponseBody<GuidResponseBody>? Body) : base(StatusCode, IsSuccessful, Body)
        {
        }
    }
}
