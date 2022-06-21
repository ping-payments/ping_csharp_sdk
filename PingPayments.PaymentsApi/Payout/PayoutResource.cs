namespace PingPayments.PaymentsApi.Payout
{
    public class PayoutResource : IPayoutResource
    {
        public IPayoutV1 V1 { get; set; }

        public PayoutResource(IPayoutV1 v1)
        {
            V1 = v1;
        }
    }
}
