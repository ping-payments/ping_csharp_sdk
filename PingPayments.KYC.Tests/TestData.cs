using System.Text.Json;

namespace PingPayments.KYC.Tests
{
    public static class TestData
    {
        private static Dictionary<string, Guid>? Settings { get; set; } = null;
        private static Dictionary<string, Guid> GetSettings()
        {
            if (Settings != null)
            {
                return Settings;
            }
            var testSetupJson = JsonDocument.Parse(File.ReadAllText("TestSetup.json"));
            Guid GetGuidValue(string key) => Guid.Parse
            (
                Environment.GetEnvironmentVariable(key) ??
                testSetupJson.RootElement.GetProperty(key).GetString() ??
                throw new Exception($"Missing setting {key}")
            );
            Settings = new Dictionary<string, Guid>()
            {
                {"TenantId",  GetGuidValue("TENANTID")},
                {"MerchantId",  GetGuidValue("MERCHANTID")},

            };
            return Settings;
        }
        public static Guid TenantId => GetSettings()["TenantId"];
        public static Guid MerchantId => GetSettings()["MerchantId"];
    }
}
