using PingPayments.KYC.Session.V1.Initiate.Response;
using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.KYC.Session.V1.Initiate
{
    public class InitiateSessionOperation : OperationBase<InitiateSessionRequest, InitiateSessionResponse>
    {
        public InitiateSessionOperation(HttpClient httpClient) : base(httpClient) { }

        protected override JsonSerializerOptions JsonSerializerOptions => new()
        {
            Converters = { new JsonStringEnumConverter() },
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        public override async Task<InitiateSessionResponse> ExecuteRequest(InitiateSessionRequest request) =>
            await BaseExecute
            (
                POST,
                "api/initiate_verification",
                request,
                await ToJson(request)
            );

        protected override async Task<InitiateSessionResponse> ParseHttpResponse(HttpResponseMessage hrm, InitiateSessionRequest _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                Created => InitiateSessionResponse.Successful(hrm.StatusCode, await Deserialize<InitiateSessionResponseBody>(responseBody), responseBody),
                _ => InitiateSessionResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;
        }
    }
}
