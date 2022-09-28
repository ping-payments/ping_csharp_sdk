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
            Lazy<ListMerchantsOperation> listMerchantOperation
        )
        {
            _createMerchantOperation = createMerchantOperation;
            _getMerchantOperation = getMerchantOperation;
            _listMerchantOperation = listMerchantOperation;
        }

        private readonly Lazy<CreateMerchantOperation> _createMerchantOperation;
        private readonly Lazy<GetMerchantOperation> _getMerchantOperation;
        private readonly Lazy<ListMerchantsOperation> _listMerchantOperation;

        public async Task<MerchantResponse> Get(Guid merchantId) =>
            await _getMerchantOperation.Value.ExecuteRequest(merchantId);

        public async Task<MerchantsResponse> List() =>
            await _listMerchantOperation.Value.ExecuteRequest(null);

        public async Task<GuidResponse> Create(CreateMerchantRequest createMerchantRequest) =>
            await _createMerchantOperation.Value.ExecuteRequest(createMerchantRequest);
    }
}
