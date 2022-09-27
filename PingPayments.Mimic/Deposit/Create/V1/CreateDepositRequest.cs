using PingPayments.Shared.Enums;
using System.Text.Json.Serialization;

namespace PingPayments.Mimic.Deposit.Create.V1
{
    public record CreateDepositRequest
    (
        int Amount,
        CurrencyEnum Currency,
        string ReferenceType,
        string Reference,
        string? Iban = null,
        ProcesseTypeEnum? Type = null
    )
    {

        [JsonPropertyName("amount")]
        public int Amount { get; set; } = Amount;


        [JsonPropertyName("currency")]
        public CurrencyEnum Currency { get; set; } = Currency;


        [JsonPropertyName("iban")]
        public string? Iban { get; set; } = Iban;


        [JsonPropertyName("reference")]
        public string Reference { get; set; } = Reference;


        [JsonPropertyName("reference_type")]
        public string ReferenceType { get; set; } = ReferenceType;


        [JsonPropertyName("type")]
        public ProcesseTypeEnum? Type { get; set; } = Type;
    }
}
