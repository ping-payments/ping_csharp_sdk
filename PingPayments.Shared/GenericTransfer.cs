using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PingPayments.Shared
{
    public record GenericTransfer<T> where T : class
    {
        [JsonPropertyName("data")]
        public T[] Data { get; set; } = Array.Empty<T>();

        [JsonPropertyName("_links")]
        public PaginationLinks PaginationLinks { get; set; } = new();
    }
}
