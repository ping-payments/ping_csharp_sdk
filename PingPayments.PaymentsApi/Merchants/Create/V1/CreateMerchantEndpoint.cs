using PingPayments.PaymentsApi.Shared;
using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.Merchants.Create.V1
{
    public class CreateMerchantEndpoint : TenantEndpointBase<CreateMerchantRequest, GuidResponse>
    {
        public CreateMerchantEndpoint(HttpClient httpClient, Guid tenantId) : base(httpClient, tenantId) { }

        protected override JsonSerializerOptions JsonSerializerOptions => new() 
        { 
            Converters = { new JsonStringEnumConverter() },
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        public override async Task<GuidResponse> Action(CreateMerchantRequest createMerchantRequest) => 
            await Execute
            (
                $"api/v1/merchants", 
                RequestTypeEnum.POST,
                ToJson(createMerchantRequest)
            );

        protected override async Task<GuidResponse> HttpResponseToResponse(HttpResponseMessage hrm)
        {
            var responseBody = await hrm.Content.ReadAsStringAsync();
            return hrm.StatusCode switch
            {
                HttpStatusCode.OK =>
                    new GuidResponse
                    (
                        (int)hrm.StatusCode,
                        true,
                        Deserialize<GuidResponseBody>(responseBody)
                    ),
                _ =>
                    new GuidResponse
                    (
                        (int)hrm.StatusCode,
                        false,
                        Deserialize<ErrorResponseBody>(responseBody)
                    )
            };
        }
    }
}