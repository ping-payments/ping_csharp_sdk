using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Shared.V1
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PayPalItemCategoryEnum
    {
        PHYSICAL_GOODS,
        DIGITAL_GOODS,
        DONATION,
    }
}
