using PingPayments.PaymentsApi.Merchants.Shared.V1;
using PingPayments.PaymentsApi.Shared;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.PaymentsApi.Shared.RequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.Merchants.List.V1
{
    public class ListMerchantsEndpoint : TenantEndpointBase<EmptyRequest?, MerchantsResponse>
    {
        public ListMerchantsEndpoint(HttpClient httpClient, Guid tenantId) : base(httpClient, tenantId) { }

        public override async Task<MerchantsResponse> ExecuteRequest(EmptyRequest? emptyRequest = null) => 
            await BaseExecute(GET, $"api/v1/merchants");

        protected override async Task<MerchantsResponse> ParseHttpResponse(HttpResponseMessage hrm)
        {
            var responseBody = await hrm.Content.ReadAsStringAsync();
            var response = hrm.StatusCode switch
            {
                OK => MerchantsResponse.Succesful(hrm.StatusCode, new MerchantList(Deserialize<Merchant[]>(responseBody))),
                _ => MerchantsResponse.Failure(hrm.StatusCode, Deserialize<ErrorResponseBody>(responseBody))
            };
            return response;
        }
    }
}