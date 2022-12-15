using PingPayments.KYC.Merchant.V1.AIS.Response;
using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.KYC.Merchant.V1.AIS
{
    public class AisKycMerchantOperation : OperationBase<AisMerchantRequest, AisMerchantResponse>
    {
        public AisKycMerchantOperation(HttpClient httpClient) : base(httpClient) { }

        protected override JsonSerializerOptions JsonSerializerOptions => new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        public override async Task<AisMerchantResponse> ExecuteRequest(AisMerchantRequest request) =>
            await BaseExecute
            (
                POST,
                "api/merchant_ais",
                request,
                await ToJson(request)
            );

        protected override async Task<AisMerchantResponse> ParseHttpResponse(HttpResponseMessage hrm, AisMerchantRequest _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => AisMerchantResponse.Successful(hrm.StatusCode, await Deserialize<AisMerchantResponseBody>(responseBody), responseBody),
                Created => AisMerchantResponse.Successful(hrm.StatusCode, await Deserialize<AisMerchantResponseBody>(responseBody), responseBody), 
                _ => AisMerchantResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;
        }
    }
}

