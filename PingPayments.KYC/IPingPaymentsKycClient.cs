using PingPayments.KYC.Session;

namespace PingPayments.KYC
{
    public interface IPingPaymentsKycClient
    {
        ISessionResource Session { get; }
    }
}