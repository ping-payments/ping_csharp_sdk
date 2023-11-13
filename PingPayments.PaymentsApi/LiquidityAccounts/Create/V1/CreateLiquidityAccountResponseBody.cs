using PingPayments.PaymentsApi.LiquidityAccounts.Shared;
using System;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.LiquidityAccounts.Create.V1
{
    public record CreateLiquidityAccountResponseBody
    {
        /// <summary>
        /// Information required for depositing funds to the account
        /// </summary>
        [JsonPropertyName("deposit_information")]
        public DepositInformation DepositInformation { get; set; } = new();

        /// <summary>
        /// Unique identifier of the created liquidity account
        /// </summary>
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
    }
}
