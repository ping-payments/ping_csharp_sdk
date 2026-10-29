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
            Lazy<CreateMerchantFromBankgiroOperation> createMerchantFromBankgiroOperation,
            Lazy<GetMerchantOperation> getMerchantOperation,
            Lazy<ListMerchantsDataOperation> listMerchantDataOperation,
            Lazy<ListMerchantsPageOperation> listMerchantPageOperation,
            Lazy<ActivatePayPalPPCPOperation> activatePayPalPPCPOperation,
            Lazy<ActivateKlarnaHPPOperation> activateKlarnaHPPOperation,
            Lazy<ActivateQuickpayOperation> activateQuickpayOperation,
            Lazy<ActivateQuickpayVippsOperation> activateQuickpayVippsOperation,
            Lazy<GetMerchantPaymentProviderMethodActivationOperation> getMerchantPaymentProviderMethodActivationOperation
        )
        {
            _createMerchantOperation = createMerchantOperation;
            _createMerchantFromBankgiroOperation = createMerchantFromBankgiroOperation;
            _getMerchantOperation = getMerchantOperation;
            _listMerchantDataOperation = listMerchantDataOperation;
            _listMerchantPageOperation = listMerchantPageOperation;
            _activatePayPalPPCPOperation = activatePayPalPPCPOperation;
            _activateKlarnaHPPOperation = activateKlarnaHPPOperation;
            _activateQuickpayOperation = activateQuickpayOperation;
            _activateQuickpayVippsOperation = activateQuickpayVippsOperation;
            _getMerchantPaymentProviderMethodActivationOperation = getMerchantPaymentProviderMethodActivationOperation;
        }

        private readonly Lazy<CreateMerchantOperation> _createMerchantOperation;
        private readonly Lazy<CreateMerchantFromBankgiroOperation> _createMerchantFromBankgiroOperation;
        private readonly Lazy<GetMerchantOperation> _getMerchantOperation;
        private readonly Lazy<ListMerchantsDataOperation> _listMerchantDataOperation;
        private readonly Lazy<ListMerchantsPageOperation> _listMerchantPageOperation;
        private readonly Lazy<ActivatePayPalPPCPOperation> _activatePayPalPPCPOperation;
        private readonly Lazy<ActivateKlarnaHPPOperation> _activateKlarnaHPPOperation;
        private readonly Lazy<ActivateQuickpayOperation> _activateQuickpayOperation;
        private readonly Lazy<ActivateQuickpayVippsOperation> _activateQuickpayVippsOperation;
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

        public async Task<GuidResponse> Create(CreateMerchantFromBankgiroRequest createMerchantFromBankgiroRequest) =>
            await _createMerchantFromBankgiroOperation.Value.ExecuteRequest(createMerchantFromBankgiroRequest);

        public async Task<ActivatePayPalPPCPResponse> ActivatePayPalPPCP(Guid merchantId, ActivatePayPalPPCPRequest request) =>
            await _activatePayPalPPCPOperation.Value.ExecuteRequest((merchantId, request));

        public async Task<ActivateKlarnaHPPResponse> ActivateKlarnaHPP(Guid merchantId, ActivateKlarnaHPPRequest request) =>
            await _activateKlarnaHPPOperation.Value.ExecuteRequest((merchantId, request));

        public async Task<ActivateQuickpayResponse> ActivateQuickpay(Guid merchantId, ActivateQuickpayRequest request) =>
            await _activateQuickpayOperation.Value.ExecuteRequest((merchantId, request));

        public async Task<ActivateQuickpayResponse> ActivateQuickpayVipps(Guid merchantId, ActivateQuickpayVippsRequest request) =>
            await _activateQuickpayVippsOperation.Value.ExecuteRequest((merchantId, request));

        public async Task<MerchantPaymentProviderMethodActivationResponse> GetPaymentProviderMethodActivation(Guid merchantId, Guid activationId) =>
            await _getMerchantPaymentProviderMethodActivationOperation.Value.ExecuteRequest((merchantId, activationId));
    }
}
