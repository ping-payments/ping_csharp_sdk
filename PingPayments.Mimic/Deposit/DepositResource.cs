namespace PingPayments.Mimic.Deposit
{
    public class DepositResource : IDepositResource
    {
        public DepositResource(IDepositV1 v1) => V1 = v1;

        public IDepositV1 V1 { get; }
    }
}
