using PingPayments.PaymentsApi.Merchants.Create.V1;
using PingPayments.PaymentsApi.Merchants.Get.V1;
using PingPayments.PaymentsApi.Merchants.List.V1;
using PingPayments.PaymentsApi.Merchants.Shared.V1;
using PingPayments.PaymentsApi.Shared;
using System;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.PaymentOrders
{
    public class MerchantV1 : IMerchantV1
    {
        public MerchantV1(Lazy<CreateMerchantEndpoint> createMerchantEndpoint,
                          Lazy<GetMerchantEndpoint> getMerchantEndpoint,
                          Lazy<ListMerchantsEndpoint> listMerchantEndpoint)
        {
            _createMerchantEndpoint = createMerchantEndpoint;
            _getMerchantEndpoint = getMerchantEndpoint;
            _listMerchantEndpoint = listMerchantEndpoint;
        }

        private readonly Lazy<CreateMerchantEndpoint> _createMerchantEndpoint;
        private readonly Lazy<GetMerchantEndpoint> _getMerchantEndpoint;
        private readonly Lazy<ListMerchantsEndpoint> _listMerchantEndpoint;

        public async Task<MerchantResponse> Get(Guid merchantId) =>
            await _getMerchantEndpoint.Value.ExecuteRequest(merchantId);

        public async Task<MerchantsResponse> List() =>
            await _listMerchantEndpoint.Value.ExecuteRequest(null);

        public async Task<GuidResponse> Create(CreateMerchantRequest createMerchantRequest) =>
            await _createMerchantEndpoint.Value.ExecuteRequest(createMerchantRequest);
    }
}
