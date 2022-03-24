namespace PingPayments.PaymentsApi.Payments.Shared.V1
{
    public enum PaymentStatusEnum
    {
        INITIATED, 
        PENDING, 
        DECLINED, 
        CANCELLED, 
        CRASHED, 
        COMPLETED, 
        EXPIRED, 
        ABORTED
    }
}
