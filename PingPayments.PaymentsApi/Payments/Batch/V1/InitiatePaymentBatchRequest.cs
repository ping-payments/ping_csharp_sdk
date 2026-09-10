using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Batch.V1
{
    public record InitiatePaymentBatchRequest
    {
        public InitiatePaymentBatchRequest(IEnumerable<PaymentBatchEntry> batch)
        {
            Batch = batch;
        }

        [JsonPropertyName("batch")]
        public IEnumerable<PaymentBatchEntry> Batch { get; set; }
    }
}
