using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Merchants.ActivatePaymentMethod.V1.Response
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MerchantPaymentProviderMethodActivationStatusEnum
    {
        PENDING,
        COMPLETED,
        FAILED,
    }
}
