using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Shared.V1.Deposit
{
    public record Supplier
    {

        /// <summary>
        /// Name of the supplier. If omitted, the tenant name will be used
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// URL to the supplier's logo
        /// </summary>
        [JsonPropertyName("image_url")]
        public string? ImageUrl { get; set; }
    }
}
