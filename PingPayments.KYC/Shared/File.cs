using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PingPayments.KYC.Shared
{
    public record File
    {
        /// <summary>
        /// File contents
        /// </summary>
        [JsonPropertyName("content")]
        public string Content { get; set; }


        /// <summary>
        /// File content type
        /// </summary>
        [JsonPropertyName("content_type")]
        public string ContentType { get; set; }


        /// <summary>
        /// Filename
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
