using PingPayments.KYC.Agreement;
using PingPayments.KYC.Agreement.V1.Create;
using PingPayments.KYC.Agreement.V1.Get;
using PingPayments.KYC.Agreement.V1.GetAgreementTemplates;
using PingPayments.KYC.Agreement.V1.Publish;
using PingPayments.KYC.Agreement.V1.Update;
using PingPayments.KYC.Merchant;
using PingPayments.KYC.Merchant.V1.AIS;
using PingPayments.KYC.Merchant.V1.Get;
using PingPayments.KYC.Merchant.V1.Verification;
using PingPayments.KYC.Session;
using PingPayments.KYC.Session.V1.Initiate;
using System;
using System.Net.Http;

namespace PingPayments.KYC
{
    public class PingKycApiClient : IPingKycApiClient
    {
        public PingKycApiClient(HttpClient httpClient)
        {
            var sessionV1 = new SessionV1(new Lazy<InitiateSessionOperation>(() => new InitiateSessionOperation(httpClient)));

            _session = new Lazy<ISessionResource>(() => new SessionResource(sessionV1));

            var merchantV1 = new MerchantV1
                (
                    new Lazy<KycVerificationOperation>(() => new KycVerificationOperation(httpClient)),
                    new Lazy<GetKycOperation>(() => new GetKycOperation(httpClient)),
                    new Lazy<AisKycMerchantOperation>(() => new AisKycMerchantOperation(httpClient))
                );
            _merchant = new Lazy<IMerchantResource>(() => new MerchantResource(merchantV1));

            var agreementV1 = new AgreementV1
                (
                    new Lazy<CreateOperation>(() => new CreateOperation(httpClient)),
                    new Lazy<GetOperation>(() => new GetOperation(httpClient)),
                    new Lazy<ListTemplatesOperation>(() => new ListTemplatesOperation(httpClient)),
                    new Lazy<PublishOperation>(() => new PublishOperation(httpClient)),
                    new Lazy<UpdateOperation>(() => new UpdateOperation(httpClient))
                );
            _agreement = new Lazy<IAgreementResource>(() => new AgreementResource(agreementV1));
        }

        private readonly Lazy<ISessionResource> _session;
        public ISessionResource Session => _session.Value;

        private readonly Lazy<IMerchantResource> _merchant;
        public IMerchantResource Merchant => _merchant.Value;

        private readonly Lazy<IAgreementResource> _agreement;
        public IAgreementResource Agreement => _agreement.Value;
    }
}
