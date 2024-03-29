﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Shared.V1
{
    public record OrderItem
    {
        public OrderItem(int amount, string name, decimal vat, Guid? merchantId = null, Guid? liquidityAccountId = null, IDictionary<string, dynamic>? metadata = null, string[]? tags = null)
        {
            Amount = amount;
            Name = name;
            Vat = vat;
            MerchantId = merchantId;
            LiquidityAccountId = liquidityAccountId;
            Metadata = metadata ?? new Dictionary<string, dynamic>();
            Tags = tags ?? new string[] { };
        }

        /// <summary>
        /// Amount in minor currency unit, i ex Swedish Ören
        /// </summary>
        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// Name of the item sold
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Vat in decimal percentages, should be between 00.00 and 99.99
        /// </summary>
        [JsonPropertyName("vat_rate")]
        public decimal Vat { get; set; }

        /// <summary>
        /// Merchant that is selling/providing the item. LiquidityAccountId must be unset or null
        /// </summary>
        [JsonPropertyName("merchant_id")]
        public Guid? MerchantId { get; set; }

        /// <summary>
        /// Liquidity account to receive funds. MerchantId must be unset or null
        /// </summary>
        [JsonPropertyName("liquidity_account_id")]
        public Guid? LiquidityAccountId { get; set; }

        /// <summary>
        /// Custom metadata
        /// </summary>
        [JsonPropertyName("metadata")]
        public IDictionary<string, dynamic> Metadata { get; set; }

        /// <summary>
        /// Set tags on an item to route funds
        /// </summary>
        [JsonPropertyName("tags")]
        public string[]? Tags { get; set; }

        /// <summary>
        /// Simplifies creation of order items array
        /// </summary>
        public static implicit operator OrderItem[](OrderItem orderItem) => new[] { orderItem };
    }
}
