namespace PingPayments.PaymentsApi.DepositBankAccount
{
    public class DepositBankAccountResource : IDepositBankAccountResource
    {
        public DepositBankAccountResource(IDepositBankAccountV1 v1) => V1 = v1;
        public IDepositBankAccountV1 V1 { get; }
    }
}
