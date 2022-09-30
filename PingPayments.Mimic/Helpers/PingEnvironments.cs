namespace PingPayments.Mimic.Helpers
{
    public partial class PingEnvironments
    {
        public static class MimicApi
        {
            public static string SandboxUri => "https://mimic-sandbox.pingpayments.com/";
            public static string ProductionUri => "https://mimic.pingpayments.com/";
        }
    }
}
