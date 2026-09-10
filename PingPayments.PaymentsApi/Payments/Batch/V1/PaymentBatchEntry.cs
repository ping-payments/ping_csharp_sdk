using PingPayments.PaymentsApi.PaymentOrders.Create.V1;
using PingPayments.PaymentsApi.Payments.V1.Initiate.Request;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Batch.V1
{
    /// <summary>
    /// Represents a single entry in a payment batch containing a payment order and payment
    /// </summary>
    public record PaymentBatchEntry
    {
        public PaymentBatchEntry(
            CreatePaymentOrderRequest paymentOrder,
            InitiatePaymentRequest payment)
        {
            PaymentOrder = paymentOrder;
            Payment = payment;
        }

        /// <summary>
        /// The payment order to create for this batch entry
        /// </summary>
        [JsonPropertyName("payment_order")]
        public CreatePaymentOrderRequest PaymentOrder { get; set; }

        /// <summary>
        /// The payment to initiate for this batch entry
        /// </summary>
        [JsonPropertyName("payment")]
        public InitiatePaymentRequest Payment { get; set; }
    }
}
