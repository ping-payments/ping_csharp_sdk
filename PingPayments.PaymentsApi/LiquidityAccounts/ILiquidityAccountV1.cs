using PingPayments.PaymentsApi.LiquidityAccounts.Create.V1;
using PingPayments.PaymentsApi.LiquidityAccounts.Get.V1;
using System;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.LiquidityAccounts
{
    public interface ILiquidityAccountV1
    {
        Task<CreateLiquidityAccountResponse> Create(CreateLiquidityAccountRequest createLiquidityAccountRequest);
        Task<GetLiquidityAccountResponse> Get(Guid merchantId);
    }
}