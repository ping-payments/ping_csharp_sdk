namespace PingPayments.PaymentsApi.Disbursements
{
    public class DisbursementResource : IDisbursementResource
    {
        public DisbursementResource(DisbursementV1 v1) => V1 = v1;
        public IDisbursementV1 V1 { get; }
    }
}
