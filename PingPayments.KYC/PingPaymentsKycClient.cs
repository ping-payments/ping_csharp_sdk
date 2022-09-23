using PingPayments.KYC.Merchant;
using PingPayments.KYC.Merchant.V1.Get;
using PingPayments.KYC.Merchant.V1.Verification;
using PingPayments.KYC.Session;
using PingPayments.KYC.Session.V1.Initiate;
using System;
using System.Net.Http;

namespace PingPayments.KYC
{
    public class PingPaymentsKycClient : IPingPaymentsKycClient
    {
        public PingPaymentsKycClient(HttpClient httplient)
        {
            var sessionV1 = new SessionV1(new Lazy<InitiateSessionOperation>(() => new InitiateSessionOperation(httplient)));

            _session = new Lazy<ISessionResource>(() => new SessionResource(sessionV1));

            var merchantV1 = new MerchantV1
                (
                    new Lazy<KycVerificationOperation>(() => new KycVerificationOperation(httplient)),
                    new Lazy<GetKycOperation>(() => new GetKycOperation(httplient))
                );
            _merchant = new Lazy<IMerchantResource>(() => new MerchantResource(merchantV1));
        }

        private readonly Lazy<ISessionResource> _session;
        public ISessionResource Session => _session.Value;

        private readonly Lazy<IMerchantResource> _merchant;
        public IMerchantResource Merchant => _merchant.Value;
    }
}
