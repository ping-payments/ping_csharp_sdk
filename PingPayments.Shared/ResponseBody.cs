namespace PingPayments.Shared
{
    public record ResponseBody<T>(ErrorResponseBody? ErrorResponseBody, T? SuccessfulResponseBody) where T : class
    {
        public static ResponseBody<T> NewError(ErrorResponseBody ErrorResponseBody) =>
            new(ErrorResponseBody, null);

        public static ResponseBody<T> NewSuccess(T SuccessfulResponseBody) =>
            new(null, SuccessfulResponseBody);

        public static implicit operator ResponseBody<T>(ErrorResponseBody ErrorResponseBody) =>
            NewError(ErrorResponseBody);

        public static implicit operator ResponseBody<T>(T SuccessfulResponseBody) =>
            NewSuccess(SuccessfulResponseBody);
    }
}
