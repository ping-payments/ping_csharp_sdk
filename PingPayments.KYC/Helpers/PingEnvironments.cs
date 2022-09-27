namespace PingPayments.KYC.Helpers
{
    public static partial class PingEnvironments
    {
        public static class KYC
        {
            public static string SandboxUri => "https://kyc-sandbox.pingpayments.com/";
            public static string ProductionUri => "https://kyc.pingpayments.com/";
        }
    }
}
