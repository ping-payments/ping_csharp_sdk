using PingPayments.PaymentsApi.LiquidityAccounts.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.KYC.AccountVerificationSession.Shared.Styling
{
    public record Button : BaseStyle
    {

        [JsonPropertyName("hover_color")]
        public string? HoverColor { get; set; }

        [JsonPropertyName("text_color")]
        public string? TextColor { get; set; }
    }
}
