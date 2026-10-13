using System;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Merchants.ActivatePaymentMethod.V1.Request
{
    public record ActivateKlarnaHPPParameters
    {
        public ActivateKlarnaHPPParameters(Uri successUrl, Uri cancelUrl)
        {
            SuccessUrl = successUrl;
            CancelUrl = cancelUrl;
            UseExistingSignedKlarnaAgreement = false;
        }

        /// <summary>
        /// Activates Klarna HPP when the merchant already accepted Klarna terms through a KYC agreement.
        /// </summary>
        public static ActivateKlarnaHPPParameters FromExistingSignedAgreement() => new(useExistingSignedKlarnaAgreement: true);

        private ActivateKlarnaHPPParameters(bool useExistingSignedKlarnaAgreement) =>
            UseExistingSignedKlarnaAgreement = useExistingSignedKlarnaAgreement;

        [JsonPropertyName("cancel_url")]
        public Uri? CancelUrl { get; }

        [JsonPropertyName("success_url")]
        public Uri? SuccessUrl { get; }

        [JsonPropertyName("use_existing_signed_klarna_agreement")]
        public bool UseExistingSignedKlarnaAgreement { get; }
    }
}
