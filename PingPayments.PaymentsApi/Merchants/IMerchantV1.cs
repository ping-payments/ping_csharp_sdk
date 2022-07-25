using PingPayments.PaymentsApi.Merchants.Create.V1;
using PingPayments.PaymentsApi.Merchants.Shared.V1;
using PingPayments.PaymentsApi.Merchants.List.V1;
using PingPayments.Shared;
using System;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.Merchants
{
    public interface IMerchantV1
    {
        Task<GuidResponse> Create(CreateMerchantRequest createMerchantRequest);
        Task<MerchantResponse> Get(Guid merchantId);
        Task<MerchantsResponse> List();
    }
}