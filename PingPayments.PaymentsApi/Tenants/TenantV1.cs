using PingPayments.PaymentsApi.Tenants.Get.V1;
using System;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.Tenants
{
    public class TenantV1 : ITenantV1
    {
        public TenantV1(Lazy<GetTenantOperation> getOperation)
        {
            _getOperation = getOperation;
        }
        private readonly Lazy<GetTenantOperation> _getOperation;

        public async Task<TenantResponse> Get() =>
            await _getOperation.Value.ExecuteRequest(null);
    }
}
