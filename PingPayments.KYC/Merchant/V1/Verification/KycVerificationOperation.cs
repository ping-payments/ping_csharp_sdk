using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.KYC.Merchant.V1.Verification
{
    public class KycVerificationOperation : OperationBase<KycVerificationRequest, EmptyResponse>
    {
        public KycVerificationOperation(HttpClient httpClient) : base(httpClient) { }

        protected override JsonSerializerOptions JsonSerializerOptions => new()
        {
            Converters = { new JsonStringEnumConverter() },
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        public override async Task<EmptyResponse> ExecuteRequest(KycVerificationRequest request) =>
            await BaseExecute
            (
                POST,
                "api/merchant_verification",
                request,
                await ToJson(request)
            );

        protected override async Task<EmptyResponse> ParseHttpResponse(HttpResponseMessage hrm, KycVerificationRequest _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                NoContent => EmptyResponse.Successful(hrm.StatusCode),
                _ => EmptyResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;
        }
    }
}

