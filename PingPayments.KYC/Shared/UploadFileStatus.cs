using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PingPayments.KYC.Shared
{
    public record FileStatus
    {
        [JsonPropertyName("changed_at")]
        public string ChangedAt { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("status")]
        public FileStatusEnum Status { get; set; }
    }
}
