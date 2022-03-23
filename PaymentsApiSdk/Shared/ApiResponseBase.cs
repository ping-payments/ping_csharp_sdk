namespace PaymentsApiSdk.Shared
{
    public abstract record ApiResponseBase<T>(int StatusCode, bool IsSuccessful, ResponseBody<T>? Body) where T : EmptySuccesfulResponseBody
    {
        public bool IsFailure => !IsSuccessful;
    }
}
