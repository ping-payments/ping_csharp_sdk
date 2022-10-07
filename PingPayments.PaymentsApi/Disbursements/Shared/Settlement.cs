using System;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Disbursements.Shared
{
    public record Settlement
    {
        /// <summary>
        /// Allocation ID (UUID4)
        /// </summary>
        /// 
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// The reference attached to the payout
        /// </summary>
        /// 
        [JsonPropertyName("reference")]
        public string Reference { get; set; }

        /// <summary>
        /// Timestamp at which the Allocation was allocated
        /// </summary>
        /// 
        [JsonPropertyName("allocated_at")]
        public DateTimeOffset AllocatedAt { get; set; }


        /// <summary>
        /// The settled amount in minor currency
        /// </summary>
        /// 
        [JsonPropertyName("amount")]
        public int Amount { get; set; }


        /// <summary>
        /// A lable describing the settlement
        /// </summary>
        [JsonPropertyName("label")]
        public string? Label { get; set; }


        /// <summary>
        /// The Merchant which will receive the settled amount. This value will be null if the type isn't Merchant,
        /// which means the settled amount wasn't paid out to a Merchant but the Tenant or payment facilitator
        /// </summary>
        [JsonPropertyName("merchant_id")]
        public Guid MerchantId { get; set; }


        /// <summary>
        /// The reference attached to the payout
        /// </summary>
        [JsonPropertyName("reference")]
        public string? Reference { get; set; }


        /// <summary>
        /// Which Payment the settled amount can be derived from.
        /// This value will be null if the amount can not be derived from a specific payment
        /// </summary>
        [JsonPropertyName("payment_id")]
        public Guid? PaymentId { get; set; }


        /// <summary>
        /// Which PaymentOrder the settled amount can be derived from.
        /// </summary>
        [JsonPropertyName("payment_order_id")]
        public Guid PaymentOrderId { get; set; }


        /// <summary>
        /// The name of the party which the settled amount was paid out to
        /// </summary>
        [JsonPropertyName("recipient_name")]
        public string RecipientName { get; set; }


        /// <summary>
        /// An enum describing which entity the settled amount was paid out to.
        /// </summary>
        [JsonPropertyName("recipient_type")]
        public RecipientTypeEnum RecipientType { get; set; }
    }
}
