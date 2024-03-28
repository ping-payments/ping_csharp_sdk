using System;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.DepositBankAccount.BankTransfer.Connect.Request.V1
{
    public record ConnectBankTransferRequest
    {
        /// <summary>
        /// Who performed the operation
        /// </summary>
        [JsonPropertyName("connected_by")]
        public string ConnectedBy { get; set; }

        /// <summary>
        /// ID of the Payment you wish to connect to the Transfer
        /// </summary>
        [JsonPropertyName("payment_id")]
        public Guid PaymentId { get; set; }
    }
}
