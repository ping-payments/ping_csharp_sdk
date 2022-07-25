namespace PingPayments.Shared
{
    public record EmptySuccesfulResponseBody()
    {
        public static EmptySuccesfulResponseBody Empty => new();
    }
}
