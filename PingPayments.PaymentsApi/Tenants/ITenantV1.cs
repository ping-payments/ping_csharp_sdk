using PingPayments.PaymentsApi.Tenants.Get.V1;
using PingPayments.PaymentsApi.Tenants.Update.V1;
using PingPayments.Shared;
using System.Threading.Tasks;


namespace PingPayments.PaymentsApi.Tenants
{
    public interface ITenantV1
    {
        Task<TenantResponse> Get();
        Task<EmptyResponse> Update(UpdateTenantRequest updateTenantRequest);

    }
}
