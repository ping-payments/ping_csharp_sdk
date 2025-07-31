using PingPayments.PaymentsApi.Disbursements.Shared;
using PingPayments.PaymentsApi.Payments.Shared.V1;
using PingPayments.Shared;
using PingPayments.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Allocations.Shared
{
    public record Allocation : GuidResponseBody
    {
        [JsonPropertyName("allocated_at")]
        public DateTimeOffset AllocatedAt { get; set; }

        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("currency")]
        public CurrencyEnum Currency { get; set; }

        [JsonPropertyName("disbursed_at")]
        public DateTimeOffset? DisbursedAt { get; set; }

        [JsonPropertyName("disbursement_id")]
        public Guid? DisbursementId { get; set; }

        [JsonPropertyName("label")]
        public string? Label { get; set; }

        [JsonPropertyName("merchant_id")]
        public Guid? MerchantId { get; set; }

        /// <summary>Custom metadata</summary>
        [JsonPropertyName("metadata")]
        public IDictionary<string, dynamic> Metadata { get; set; }

        [JsonPropertyName("payment_id")]
        public Guid? PaymentId { get; set; }

        [JsonPropertyName("payment_order_id")]
        public Guid PaymentOrderId { get; set; }

        [JsonPropertyName("recipient_bank_account")]
        public BankAccount RecipientBankAccount { get; set; }

        [JsonPropertyName("recipient_name")]
        public string RecipientName { get; set; }

        [JsonPropertyName("recipient_type")]
        public RecipientTypeEnum RecipientType { get; set; }

        [JsonPropertyName("reference")]
        public string Reference { get; set; }

        [JsonPropertyName("settled_at")]
        public DateTimeOffset? SettledAt { get; set; }
    }

}
