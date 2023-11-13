using PingPayments.PaymentsApi.LiquidityAccounts.Shared;
using System;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.LiquidityAccounts.Get.V1
{
    /// <summary>
    /// Response body for the Liquidity Account details
    /// </summary>
    public record GetLiquidityAccountResponseBody
    {
        public GetLiquidityAccountResponseBody(int balance, string currency, DepositInformation depositInformation, Guid id)
        {
            Balance = balance;
            Currency = currency;
            DepositInformation = depositInformation;
            Id = id;
        }

        public GetLiquidityAccountResponseBody()
        {
            
        }

        /// <summary>
        /// Current balance of the Liquidity Account in minor unit of currency
        /// </summary>
        [JsonPropertyName("balance")]
        public int Balance { get; set; }

        /// <summary>
        /// Currency of the Liquidity Account
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; } = "";

        /// <summary>
        /// Information required for depositing targeted funds to the account
        /// </summary>
        [JsonPropertyName("deposit_information")]
        public DepositInformation DepositInformation { get; set; } = new();

        /// <summary>
        /// Unique identifier of the Liquidity Account
        /// </summary>
        [JsonPropertyName("id")]
        public Guid Id { get; set; } = Guid.Empty;
    }
}
