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
        }

        private readonly Lazy<ISessionResource> _session;
        public ISessionResource Session => _session.Value;
    }
}
