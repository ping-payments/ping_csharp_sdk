namespace PaymentsApiSdk.Shared
{
    public abstract record ApiResponseBase<T>(int StatusCode, bool IsSuccessful, ResponseBody<T>? Body) where T : EmptySuccesfulResponseBody
    {
        public bool IsFailure => !IsSuccessful;

        public static implicit operator ErrorResponseBody?(ApiResponseBase<T> apiResponseBase) =>
            apiResponseBase.IsFailure &&
            apiResponseBase.Body?.ErrorResponseBody != null ?
                apiResponseBase.Body.ErrorResponseBody :
                null;
    }
}
