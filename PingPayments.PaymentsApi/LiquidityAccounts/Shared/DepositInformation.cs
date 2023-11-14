using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.LiquidityAccounts.Shared
{
    /// <summary>
    /// Information required for depositing funds to the liquidity account
    /// </summary>
    public record DepositInformation
    {
        public DepositInformation(BankAccount bankAccount, string reference)
        {
            BankAccount = bankAccount;
            Reference = reference;
        }

        public DepositInformation()
        {

        }

        /// <summary>
        /// Bank account details for deposits
        /// </summary>
        [JsonPropertyName("bank_account")]
        public BankAccount BankAccount { get; set; } = new();

        /// <summary>
        /// Reference for the deposit, to be used as message when topping up the account
        /// </summary>
        [JsonPropertyName("reference")]
        public string Reference { get; set; } = "";
    }
}
