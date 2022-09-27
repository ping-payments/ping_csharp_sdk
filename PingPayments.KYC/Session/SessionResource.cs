namespace PingPayments.KYC.Session
{
    public class SessionResource : ISessionResource
    {
        public SessionResource(ISessionV1 v1) => V1 = v1;

        public ISessionV1 V1 { get; }
    }
}
