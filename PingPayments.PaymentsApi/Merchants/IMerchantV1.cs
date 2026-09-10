using PingPayments.PaymentsApi.Merchants.ActivatePaymentMethod.V1.Request;
using PingPayments.PaymentsApi.Merchants.ActivatePaymentMethod.V1.Response;
using PingPayments.PaymentsApi.Merchants.Create.V1;
using PingPayments.PaymentsApi.Merchants.List.V1;
using PingPayments.PaymentsApi.Merchants.Shared.V1;
using PingPayments.Shared;
using System;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.Merchants
{
    public interface IMerchantV1
    {
        Task<GuidResponse> Create(CreateMerchantRequest createMerchantRequest);
        Task<MerchantResponse> Get(Guid merchantId);
        Task<MerchantsDataResponse> ListData();
        Task<MerchantsPageResponse> ListPage(int? limit = null);
        Task<MerchantsPageResponse> ListPage(PaginationLinkHref href);
        Task<ActivatePayPalPPCPResponse> ActivatePayPalPPCP(Guid merchantId, ActivatePayPalPPCPRequest request);
        Task<MerchantPaymentProviderMethodActivationResponse> GetPaymentProviderMethodActivation(Guid merchantId, Guid activationId);
    }
}