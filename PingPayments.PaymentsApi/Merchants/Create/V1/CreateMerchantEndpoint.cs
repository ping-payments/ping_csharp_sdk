using PingPayments.PaymentsApi.Shared;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static PingPayments.PaymentsApi.Shared.RequestTypeEnum;
using static System.Net.HttpStatusCode;

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

        public override async Task<GuidResponse> ExecuteRequest(CreateMerchantRequest createMerchantRequest) => 
            await BaseExecute
            (
                POST,
                $"api/v1/merchants",
                ToJson(createMerchantRequest)
            );

        protected override async Task<GuidResponse> ParseHttpResponse(HttpResponseMessage hrm)
        {
            var responseBody = await hrm.Content.ReadAsStringAsync();
            var response = hrm.StatusCode switch
            {
                OK => GuidResponse.Succesful(hrm.StatusCode, Deserialize<GuidResponseBody>(responseBody)),
                _ => GuidResponse.Failure(hrm.StatusCode, Deserialize<ErrorResponseBody>(responseBody))
            };
            return response;
        }
    }
}