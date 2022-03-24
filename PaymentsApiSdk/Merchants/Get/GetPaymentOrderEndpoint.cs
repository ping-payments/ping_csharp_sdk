using PingPayments.PaymentsApi.Merchants.Shared;
using PingPayments.PaymentsApi.Shared;
using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.Merchants.Get
{
    public class GetMerchantEndpoint : TenantEndpointBase<Guid, MerchantResponse>
    {
        public GetMerchantEndpoint(HttpClient httpClient, Guid tenantId) : base(httpClient, tenantId) { }

        protected override JsonSerializerOptions JsonSerializerOptions => new() { Converters = { new JsonStringEnumConverter() } };

        public override async Task<MerchantResponse> Action(Guid merchantId) => 
            await Execute($"api/v1/merchants/{merchantId}", RequestTypeEnum.GET);

        protected override async Task<MerchantResponse> HttpResponseToResponse(HttpResponseMessage hrm)
        {
            var responseBody = await hrm.Content.ReadAsStringAsync();
            return hrm.StatusCode switch
            {
                HttpStatusCode.OK =>
                    new MerchantResponse
                    (
                        (int)hrm.StatusCode,
                        true,
                        Deserialize<Merchant>(responseBody)
                    ),
                _ =>
                    new MerchantResponse
                    (
                        (int)hrm.StatusCode,
                        false,
                        Deserialize<ErrorResponseBody>(responseBody)
                    )
            };
        }
    }
}