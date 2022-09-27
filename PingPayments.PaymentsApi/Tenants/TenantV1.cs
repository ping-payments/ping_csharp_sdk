using PingPayments.PaymentsApi.Tenants.Get.V1;
using PingPayments.PaymentsApi.Tenants.Update.V1;
using PingPayments.Shared;
using System;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.Tenants
{
    public class TenantV1 : ITenantV1
    {
        public TenantV1(Lazy<GetTenantOperation> getOperation,
                        Lazy<UpdateTenantOperation> updateTenantOperation)
        {
            _getOperation = getOperation;
            _updateTenantOperation = updateTenantOperation;
        }
        private readonly Lazy<GetTenantOperation> _getOperation;
        private readonly Lazy<UpdateTenantOperation> _updateTenantOperation;

        public async Task<TenantResponse> Get() =>
            await _getOperation.Value.ExecuteRequest(null);
        public async Task<EmptyResponse> Update(UpdateTenantRequest updateTenantRequest) =>
            await _updateTenantOperation.Value.ExecuteRequest(updateTenantRequest);
    }
}
