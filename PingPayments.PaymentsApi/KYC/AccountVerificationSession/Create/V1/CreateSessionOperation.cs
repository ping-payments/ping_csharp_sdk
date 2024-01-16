using PingPayments.PaymentsApi.KYC.AccountVerificationSession.Shared;
using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.KYC.AccountVerificationSession.Create.V1
{
    public class CreateSessionOperation : OperationBase<CreateSessionRequest, CreateSessionResponse>
    {
        public CreateSessionOperation(HttpClient httpClient) : base(httpClient) { }

        protected override JsonSerializerOptions JsonSerializerOptions => new()
        {
            Converters = { new JsonStringEnumConverter() },
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        public override async Task<CreateSessionResponse> ExecuteRequest(CreateSessionRequest request) =>
            await BaseExecute
            (
                POST,
                "api/v1/account_verification_sessions",
                request,
                await ToJson(request)
            );

        protected override async Task<CreateSessionResponse> ParseHttpResponse(HttpResponseMessage hrm, CreateSessionRequest _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => CreateSessionResponse.Successful(hrm.StatusCode, await Deserialize<CreateSessionResponseBody>(responseBody), responseBody),
                _ => CreateSessionResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;
        }
    }
}
