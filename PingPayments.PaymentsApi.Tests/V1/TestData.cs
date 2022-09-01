using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace PingPayments.PaymentsApi.Tests.V1
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
                {"OrderId",  GetGuidValue("ORDERID")},
                {"SplitTreeId",  GetGuidValue("SPLITTREEID")},
                {"PaymentId",  GetGuidValue("PAYMENTID")}
            };
            return Settings;
        }
        public static Guid TenantId => GetSettings()["TenantId"];
        public static Guid MerchantId => GetSettings()["MerchantId"];
        public static Guid OrderId => GetSettings()["OrderId"];
        public static Guid SplitTreeId => GetSettings()["SplitTreeId"];
        public static Guid PaymentId => GetSettings()["PaymentId"];
        public static Uri FakeCallback => new("https://not.real.callback.pingpayments.com");
    }
}
