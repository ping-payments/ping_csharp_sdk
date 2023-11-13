using PingPayments.PaymentsApi.LiquidityAccounts.Shared;
using PingPayments.Shared.Enums;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.LiquidityAccounts.Create.V1
{
    /// <summary>
    /// Request for creating a liquidity account
    /// </summary>
    public record CreateLiquidityAccountRequest
    {
        public CreateLiquidityAccountRequest(string? name, CurrencyEnum currency, bool enableDeposits, AccountHolder accountHolder)
        {
            Name = name;
            Currency = currency;
            EnableDeposits = enableDeposits;
            AccountHolder = accountHolder;
        }

        /// <summary>
        /// Name of the liquidity account
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = "";

        /// <summary>
        /// Currency of the liquidity account
        /// </summary>
        [JsonPropertyName("currency")]
        public CurrencyEnum Currency { get; set; } = CurrencyEnum.SEK;

        /// <summary>
        /// Indicates if deposits are enabled for the liquidity account
        /// </summary>
        [JsonPropertyName("enable_deposits")]
        public bool EnableDeposits { get; set; } = false;

        /// <summary>
        /// Account holder details
        /// </summary>
        [JsonPropertyName("account_holder")]
        public AccountHolder AccountHolder { get; set; } = new();     
    }
}
