namespace PingPayments.PaymentLinksApi.Shared
{
    public record PaymentLinksResponseBody<T>(PaymentLinksErrorResponseBody? ErrorResponseBody, T? SuccessfulResponseBody) where T : class
    {
        public static PaymentLinksResponseBody<T> NewError(PaymentLinksErrorResponseBody ErrorResponseBody) =>
            new(ErrorResponseBody, null);

        public static PaymentLinksResponseBody<T> NewSuccess(T SuccessfulResponseBody) =>
            new(null, SuccessfulResponseBody);

        public static implicit operator PaymentLinksResponseBody<T>(PaymentLinksErrorResponseBody ErrorResponseBody) =>
            NewError(ErrorResponseBody);

        public static implicit operator PaymentLinksResponseBody<T>(T SuccessfulResponseBody) =>
            NewSuccess(SuccessfulResponseBody);
    }
}
