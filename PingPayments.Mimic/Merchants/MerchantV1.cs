using PingPayments.Mimic.Merchants.Update.V1;
using PingPayments.Shared;
using PingPayments.Shared.Enums;
using System;
using System.Threading.Tasks;

namespace PingPayments.Mimic.Merchants
{
    public class MerchantV1 : IMerchantV1
    {
        public MerchantV1(Lazy<UpdateOperation> updateOperation)
        {
            _updateOperation = updateOperation;
        }
        private readonly Lazy<UpdateOperation> _updateOperation;

        public async Task<EmptyResponse> Update(Guid merchantId, MerchantStatus merchantStatus) =>
            await _updateOperation.Value.ExecuteRequest((merchantId, merchantStatus));
    }
}
