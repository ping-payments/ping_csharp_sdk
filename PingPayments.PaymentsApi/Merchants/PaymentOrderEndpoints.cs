using PingPayments.PaymentsApi.Merchants.Create;
using PingPayments.PaymentsApi.Merchants.Get;
using PingPayments.PaymentsApi.Merchants.List;
using PingPayments.PaymentsApi.Merchants.Shared;
using PingPayments.PaymentsApi.Shared;
using System;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.PaymentOrders
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
