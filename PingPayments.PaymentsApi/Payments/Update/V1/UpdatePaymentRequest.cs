using PingPayments.PaymentsApi.Payments.Shared.V1;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Update.V1
{
    public record UpdatePaymentRequest(OrderItem[] OrderItems)
    {
        /// <summary>
        /// TODO
        /// </summary>
        [JsonPropertyName("order_items")]
        public OrderItem[] OrderItems { get; set; } = OrderItems;
    }
}
