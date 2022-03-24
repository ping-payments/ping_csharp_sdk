using PingPayments.PaymentsApi.Merchants.Shared;
using PingPayments.PaymentsApi.Shared;
using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.Merchants.List
{
    public class ListMerchantsEndpoint : TenantEndpointBase<EmptyRequest?, MerchantsResponse>
    {
        public ListMerchantsEndpoint(HttpClient httpClient, Guid tenantId) : base(httpClient, tenantId) { }

        protected override JsonSerializerOptions JsonSerializerOptions => new() { Converters = { new JsonStringEnumConverter() } };

        public override async Task<MerchantsResponse> Action(EmptyRequest? emptyRequest = null) => 
            await Execute($"api/v1/merchants", RequestTypeEnum.GET);

        protected override async Task<MerchantsResponse> HttpResponseToResponse(HttpResponseMessage hrm)
        {
            var responseBody = await hrm.Content.ReadAsStringAsync();
            return hrm.StatusCode switch
            {
                HttpStatusCode.OK =>
                    new MerchantsResponse
                    (
                        (int)hrm.StatusCode,
                        true,
                        new MerchantList(Deserialize<Merchant[]>(responseBody))
                    ),
                _ =>
                    new MerchantsResponse
                    (
                        (int)hrm.StatusCode,
                        false,
                        Deserialize<ErrorResponseBody>(responseBody)
                    )
            };
        }
    }
}