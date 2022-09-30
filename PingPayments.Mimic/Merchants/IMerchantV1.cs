using PingPayments.Shared;
using PingPayments.Shared.Enums;
using System;
using System.Threading.Tasks;

namespace PingPayments.Mimic.Merchants
{
    public interface IMerchantV1
    {
        Task<EmptyResponse> Update(Guid merchantId, MerchantStatus merchantStatus);
    }
}