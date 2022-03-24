using PingPayments.PaymentsApi.Merchants.Shared.V1;
using PingPayments.PaymentsApi.Shared;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.PaymentsApi.Shared.RequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.Merchants.Get.V1
{
    public class GetMerchantEndpoint : TenantEndpointBase<Guid, MerchantResponse>
    {
        public GetMerchantEndpoint(HttpClient httpClient, Guid tenantId) : base(httpClient, tenantId) { }

        public override async Task<MerchantResponse> ExecuteRequest(Guid merchantId) => 
            await BaseExecute(GET, $"api/v1/merchants/{merchantId}");

        protected override async Task<MerchantResponse> ParseHttpResponse(HttpResponseMessage hrm)
        {
            var responseBody = await hrm.Content.ReadAsStringAsync();
            var response = hrm.StatusCode switch
            {
                OK => MerchantResponse.Succesful(hrm.StatusCode, Deserialize<Merchant>(responseBody)),
                _ => MerchantResponse.Failure(hrm.StatusCode, Deserialize<ErrorResponseBody>(responseBody))
            };
            return response;
        }
    }
}