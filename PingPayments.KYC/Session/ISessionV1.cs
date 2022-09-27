using PingPayments.KYC.Session.V1.Initiate;
using PingPayments.KYC.Session.V1.Initiate.Response;
using System.Threading.Tasks;

namespace PingPayments.KYC.Session
{
    public interface ISessionV1
    {
        Task<InitiateSessionResponse> Initiate(InitiateSessionRequest request);
    }
}