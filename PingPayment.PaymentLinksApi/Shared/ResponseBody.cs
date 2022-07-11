namespace PingPayments.PaymentLinksApi.Shared
{
    public record ResponseBody<T>(ErrorResponseBody? ErrorResponseBody, T? SuccesfulResponseBody) where T : EmptySuccesfulResponseBody
    {
        public static ResponseBody<T> NewError(ErrorResponseBody ErrorResponseBody) => 
            new(ErrorResponseBody, null);

        public static ResponseBody<T> NewSuccess(T SuccesfulResponseBody) =>
            new(null, SuccesfulResponseBody);

        public static implicit operator ResponseBody<T>(ErrorResponseBody ErrorResponseBody) => 
            NewError(ErrorResponseBody);

        public static implicit operator ResponseBody<T>(T SuccesfulResponseBody) =>
            NewSuccess(SuccesfulResponseBody);
    }
}
