namespace PingPayments.Shared
{
    public record EmptySuccessfulResponseBody()
    {
        public static EmptySuccessfulResponseBody Empty => new();
    }
}
