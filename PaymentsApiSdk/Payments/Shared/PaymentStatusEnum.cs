namespace PingPayments.PaymentsApi.Payments.Shared
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
