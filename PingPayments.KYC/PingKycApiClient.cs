using PingPayments.KYC.Agreement;
using PingPayments.KYC.Agreement.V1.Create;
using PingPayments.KYC.Agreement.V1.CreateAccessLink;
using PingPayments.KYC.Agreement.V1.Get;
using PingPayments.KYC.Agreement.V1.GetAgreementTemplates;
using PingPayments.KYC.Agreement.V1.Publish;
using PingPayments.KYC.Agreement.V1.Update;
using PingPayments.KYC.Agreement.V1.Delete;
using PingPayments.KYC.Merchant;
using PingPayments.KYC.Merchant.V1.AIS;
using PingPayments.KYC.Merchant.V1.Get;
using PingPayments.KYC.Merchant.V1.Verification;
using System;
using System.Net.Http;

namespace PingPayments.KYC
{
    public class PingKycApiClient : IPingKycApiClient
    {
        public PingKycApiClient(HttpClient httpClient)
        {
            var merchantV1 = new MerchantV1
                (
                    new Lazy<KycVerificationOperation>(() => new KycVerificationOperation(httpClient)),
                    new Lazy<GetKycOperation>(() => new GetKycOperation(httpClient)),
                    new Lazy<AisKycMerchantOperation>(() => new AisKycMerchantOperation(httpClient))
                );
            _merchant = new Lazy<IMerchantResource>(() => new MerchantResource(merchantV1));

            var agreementV1 = new AgreementV1
                (
                    new Lazy<Agreement.V1.Create.CreateOperation>(() => new Agreement.V1.Create.CreateOperation(httpClient)),
                    new Lazy<GetOperation>(() => new GetOperation(httpClient)),
                    new Lazy<ListTemplatesOperation>(() => new ListTemplatesOperation(httpClient)),
                    new Lazy<Agreement.V1.CreateAccessLink.CreateAccessLinkOperation>(() => new Agreement.V1.CreateAccessLink.CreateAccessLinkOperation(httpClient)),
                    new Lazy<PublishOperation>(() => new PublishOperation(httpClient)),
                    new Lazy<UpdateOperation>(() => new UpdateOperation(httpClient)),
                    new Lazy<DeleteOperation>(() => new DeleteOperation(httpClient))
                );
            _agreement = new Lazy<IAgreementResource>(() => new AgreementResource(agreementV1));
        }
        private readonly Lazy<IMerchantResource> _merchant;
        public IMerchantResource Merchant => _merchant.Value;

        private readonly Lazy<IAgreementResource> _agreement;
        public IAgreementResource Agreement => _agreement.Value;
    }
}
