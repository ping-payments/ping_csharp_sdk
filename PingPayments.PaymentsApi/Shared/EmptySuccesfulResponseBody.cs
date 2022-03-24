namespace PingPayments.PaymentsApi.Shared
{
    public record EmptySuccesfulResponseBody()
    {
        public static EmptySuccesfulResponseBody Empty => new();
    }
}
