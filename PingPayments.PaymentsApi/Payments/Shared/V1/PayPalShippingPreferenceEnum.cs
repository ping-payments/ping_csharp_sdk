using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Shared.V1
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PayPalShippingPreferenceEnum
    {
        SET_PROVIDED_ADDRESS,
        NO_SHIPPING,
    }
}
