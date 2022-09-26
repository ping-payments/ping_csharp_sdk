using PingPayments.PaymentsApi.Tenants.Get.V1;
using System.Threading.Tasks;


namespace PingPayments.PaymentsApi.Tenants
{
    public interface ITenantV1
    {
        Task<TenantResponse> Get();

    }
}
