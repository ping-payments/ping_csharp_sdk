namespace PingPayments.PaymentsApi.Helpers
{
    public static partial class PingEnvironments
    {
        public static class PaymentsApi
        {
            public static string SandboxUri => "https://sandbox.pingpayments.com/payments";
            public static string ProductionUri => "https://production.pingpayments.com/payments";
        }
    }
}
