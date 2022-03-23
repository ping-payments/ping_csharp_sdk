using System;

namespace PaymentsApiSdk.Tests
{
    public static class TestData
    {
        public static string SandboxUri => "https://sandbox.pingpayments.com/payments/";
        public static Guid TenantId => Guid.Parse("be74903f-72bd-4e21-97c4-128dcf85e2f0");
        public static Guid MerchantId => Guid.Parse("04476abd-4bd4-45bb-b6ea-dcda41aded4d");
        public static Guid OrderId => Guid.Parse("fb27904a-f274-4c9a-b14d-085583fbaad4");
        public static Guid SplitTreeId => Guid.Parse("5802e367-96dd-4cc8-b0de-b4603fb6a32d");
        public static Guid PaymentId => Guid.Parse("cfc45f5f-2ec5-478c-8ec4-71410da43be1");
    }
}
