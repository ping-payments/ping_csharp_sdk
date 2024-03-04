using System.Text.Json.Serialization;
using PingPayments.PaymentsApi.Payments.Shared.V1.Deposit;

namespace PingPayments.PaymentsApi.LiquidityAccounts.Shared
{
    /// <summary>
    /// Information required for depositing funds to the liquidity account
    /// </summary>
    public record DepositInformation
    {
        public DepositInformation(BankAccount bankAccount, string reference, InvoiceUrls invoiceUrls)
        {
            BankAccount = bankAccount;
            Reference = reference;
            InvoiceUrls = invoiceUrls;
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
        /// Bank account details for deposits
        /// </summary>
        [JsonPropertyName("invoice")]
        public InvoiceUrls InvoiceUrls { get; set; } = new();


        /// <summary>
        /// Reference for the deposit, to be used as message when topping up the account
        /// </summary>
        [JsonPropertyName("reference")]
        public string Reference { get; set; } = "";
    }
}
