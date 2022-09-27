using PingPayments.KYC.Session.V1.Initiate;
using PingPayments.KYC.Session.V1.Initiate.Response;
using System;
using System.Threading.Tasks;

namespace PingPayments.KYC.Session
{
    public class SessionV1 : ISessionV1
    {
        public SessionV1(Lazy<InitiateSessionOperation> initiateOperation)
        {
            _initiateOperation = initiateOperation;
        }

        private readonly Lazy<InitiateSessionOperation> _initiateOperation;

        public async Task<InitiateSessionResponse> Initiate(InitiateSessionRequest request) =>
            await _initiateOperation.Value.ExecuteRequest(request);
    }
}
