using PaymentsApiSdk.Merchants.Create;
using PaymentsApiSdk.Merchants.Get;
using PaymentsApiSdk.Merchants.List;
using PaymentsApiSdk.Merchants.Shared;
using PaymentsApiSdk.Shared;
using System;
using System.Threading.Tasks;

namespace PaymentsApiSdk.PaymentOrders
{
    public class MerchantEndpoints
    {        
        public MerchantEndpoints(CreateMerchantEndpoint createMerchantEndpoint,
                                 GetMerchantEndpoint getMerchantEndpoint,
                                 ListMerchantsEndpoint listMerchantEndpoint)
        {
            _createMerchantEndpoint = createMerchantEndpoint;
            _getMerchantEndpoint = getMerchantEndpoint;
            _listMerchantEndpoint = listMerchantEndpoint;
        }

        private readonly CreateMerchantEndpoint _createMerchantEndpoint;
        private readonly GetMerchantEndpoint _getMerchantEndpoint;
        private readonly ListMerchantsEndpoint _listMerchantEndpoint;

        public async Task<MerchantResponse> Get(Guid merchantId) =>
            await _getMerchantEndpoint.Action(merchantId);

        public async Task<MerchantsResponse> List() => 
            await _listMerchantEndpoint.Action(null);

        public async Task<GuidResponse> Create(CreateMerchantRequest createMerchantRequest) => 
            await _createMerchantEndpoint.Action(createMerchantRequest);
    }
}
