namespace PingPayments.PaymentsApi.LiquidityAccounts
{
    public class LiquidityAccountResource : ILiquidityAccountResource
    {
        public LiquidityAccountResource(ILiquidityAccountV1 v1) => V1 = v1;
        public ILiquidityAccountV1 V1 { get; }
    }
}
