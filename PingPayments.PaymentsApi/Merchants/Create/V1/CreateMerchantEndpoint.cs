using PingPayments.PaymentsApi.Helpers;
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
    public class CreateMerchantEndpoint : EndpointBase<CreateMerchantRequest, GuidResponse>
    {
        public CreateMerchantEndpoint(HttpClient httpClient) : base(httpClient) { }

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
                createMerchantRequest,
                await ToJson(createMerchantRequest)
            );

        protected override async Task<GuidResponse> ParseHttpResponse(HttpResponseMessage hrm, CreateMerchantRequest _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => GuidResponse.Succesful(hrm.StatusCode, await Deserialize<GuidResponseBody>(responseBody), responseBody),
                _ => GuidResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;
        }
    }
}