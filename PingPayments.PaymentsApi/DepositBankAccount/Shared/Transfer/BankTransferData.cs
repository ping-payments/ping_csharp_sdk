using PingPayments.Shared;
using System;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.DepositBankAccount.Shared.Transfer
{
    public record BankTransferData : GuidResponseBody
    {
        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("booking_date")]
        public string BookingDate { get; set; }

        [JsonPropertyName("connections")]
        public Connection[] Connections { get; set; } = Array.Empty<Connection>();

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("remittance_information")]
        public RemittanceInformation? RemittanceInformation { get; set; }

        [JsonPropertyName("value_data")]
        public string ValueData { get; set; }
    }

}
