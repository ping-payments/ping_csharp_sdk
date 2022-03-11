using Newtonsoft.Json;
using PaymentsApiSDK.Interfaces;
using System;

namespace PaymentsApiSDK.Models
{
    public class InitiatePaymentResponse : IInitiatePaymentResponse
    {
        [JsonProperty("id", Required = Required.DisallowNull)]
        public Guid id { get; set; }

        [JsonProperty("swish", Required = Required.Default)]
        public InitiateSwishPaymentResponse swish { get; set; }

        [JsonProperty("verifone", Required = Required.Default)]
        public InitiateVerifonePaymentResponse verifone { get; set; }

        [JsonProperty("billmate", Required = Required.Default)]
        public InitiateBillmatePaymentResponse billmate { get; set; }
    }
}
