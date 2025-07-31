namespace PingPayments.PaymentsApi.Allocations
{
    public class AllocationResource : IAllocationResource
    {
        public AllocationResource(AllocationV1 v1) => V1 = v1;
        public IAllocationV1 V1 { get; }
    }
}
