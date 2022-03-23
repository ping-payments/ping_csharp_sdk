namespace PaymentsApiSdk.Shared
{
    public record EmptyResponse : ApiResponseBase<EmptySuccesfulResponseBody>
    {
        public EmptyResponse(int StatusCode, bool IsSuccessful, ResponseBody<EmptySuccesfulResponseBody>? Body) 
            : base(StatusCode, IsSuccessful, Body)
        {

        }

        public static EmptyResponse Empty(int StatusCode, bool IsSuccessful) =>
            new(StatusCode, IsSuccessful, EmptySuccesfulResponseBody.Empty);
    }
}
