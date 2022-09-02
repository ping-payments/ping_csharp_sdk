namespace PingPayments.PaymentLinksApi.Helpers
{
    public static partial class PingEnvironments
    {
        public static class PaymentLinksApi
        {
            public static string SandboxUri => "https://sandbox.pingpayments.com/payment_links/";
            public static string ProductionUri => "https://production.pingpayments.com/payment_links/";
        }
    }
}
