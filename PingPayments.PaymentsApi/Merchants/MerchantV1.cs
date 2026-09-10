using PingPayments.PaymentsApi.Merchants.ActivatePaymentMethod.V1;
using PingPayments.PaymentsApi.Merchants.ActivatePaymentMethod.V1.Request;
using PingPayments.PaymentsApi.Merchants.ActivatePaymentMethod.V1.Response;
using PingPayments.PaymentsApi.Merchants.Create.V1;
using PingPayments.PaymentsApi.Merchants.Get.V1;
using PingPayments.PaymentsApi.Merchants.List.V1;
using PingPayments.PaymentsApi.Merchants.Shared.V1;
using PingPayments.Shared;
using System;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.Merchants
{
    public class MerchantV1 : IMerchantV1
    {
        public MerchantV1
        (
            Lazy<CreateMerchantOperation> createMerchantOperation,
            Lazy<GetMerchantOperation> getMerchantOperation,
            Lazy<ListMerchantsDataOperation> listMerchantDataOperation,
            Lazy<ListMerchantsPageOperation> listMerchantPageOperation,
            Lazy<ActivatePayPalPPCPOperation> activatePayPalPPCPOperation,
            Lazy<GetMerchantPaymentProviderMethodActivationOperation> getMerchantPaymentProviderMethodActivationOperation
        )
        {
            _createMerchantOperation = createMerchantOperation;
            _getMerchantOperation = getMerchantOperation;
            _listMerchantDataOperation = listMerchantDataOperation;
            _listMerchantPageOperation = listMerchantPageOperation;
            _activatePayPalPPCPOperation = activatePayPalPPCPOperation;
            _getMerchantPaymentProviderMethodActivationOperation = getMerchantPaymentProviderMethodActivationOperation;
        }

        private readonly Lazy<CreateMerchantOperation> _createMerchantOperation;
        private readonly Lazy<GetMerchantOperation> _getMerchantOperation;
        private readonly Lazy<ListMerchantsDataOperation> _listMerchantDataOperation;
        private readonly Lazy<ListMerchantsPageOperation> _listMerchantPageOperation;
        private readonly Lazy<ActivatePayPalPPCPOperation> _activatePayPalPPCPOperation;
        private readonly Lazy<GetMerchantPaymentProviderMethodActivationOperation> _getMerchantPaymentProviderMethodActivationOperation;

        public async Task<MerchantResponse> Get(Guid merchantId) =>
            await _getMerchantOperation.Value.ExecuteRequest(merchantId);

        public async Task<MerchantsDataResponse> ListData() =>
            await _listMerchantDataOperation.Value.ExecuteRequest(null);

        public async Task<MerchantsPageResponse> ListPage(int? limit) =>
            await _listMerchantPageOperation.Value.ExecuteRequest((null, limit));

        public async Task<MerchantsPageResponse> ListPage(PaginationLinkHref href) =>
            await _listMerchantPageOperation.Value.ExecuteRequest((href, null));

        public async Task<GuidResponse> Create(CreateMerchantRequest createMerchantRequest) =>
            await _createMerchantOperation.Value.ExecuteRequest(createMerchantRequest);

        public async Task<ActivatePayPalPPCPResponse> ActivatePayPalPPCP(Guid merchantId, ActivatePayPalPPCPRequest request) =>
            await _activatePayPalPPCPOperation.Value.ExecuteRequest((merchantId, request));

        public async Task<MerchantPaymentProviderMethodActivationResponse> GetPaymentProviderMethodActivation(Guid merchantId, Guid activationId) =>
            await _getMerchantPaymentProviderMethodActivationOperation.Value.ExecuteRequest((merchantId, activationId));
    }
}
