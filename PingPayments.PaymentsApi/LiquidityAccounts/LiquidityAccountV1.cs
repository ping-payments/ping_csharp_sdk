using PingPayments.PaymentsApi.LiquidityAccounts.Create.V1;
using PingPayments.PaymentsApi.LiquidityAccounts.Get.V1;
using System;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.LiquidityAccounts
{
    public class LiquidityAccountV1 : ILiquidityAccountV1
    {
        public LiquidityAccountV1
        (
            Lazy<CreateLiquidityAccountOperation> createLiquidityAccountOperation,
            Lazy<GetLiquidityAccountOperation> getLiquidityAccountOperation
        )
        {
            _createLiquidityAccountOperation = createLiquidityAccountOperation;
            _getLiquidityAccountOperation = getLiquidityAccountOperation;
        }

        private readonly Lazy<CreateLiquidityAccountOperation> _createLiquidityAccountOperation;
        private readonly Lazy<GetLiquidityAccountOperation> _getLiquidityAccountOperation;

        public async Task<GetLiquidityAccountResponse> Get(Guid merchantId) =>
            await _getLiquidityAccountOperation.Value.ExecuteRequest(merchantId);

        public async Task<CreateLiquidityAccountResponse> Create(CreateLiquidityAccountRequest createLiquidityAccountRequest) =>
            await _createLiquidityAccountOperation.Value.ExecuteRequest(createLiquidityAccountRequest);
    }
}
