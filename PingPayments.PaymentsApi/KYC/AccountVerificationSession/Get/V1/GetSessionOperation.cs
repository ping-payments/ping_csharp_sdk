using PingPayments.PaymentsApi.Payments.Get.V1;
using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.KYC.AccountVerificationSession.Get.V1
{
    public class GetSessionOperation : OperationBase<string, GetSessionResponse>
    {
        public GetSessionOperation(HttpClient httpClient) : base(httpClient) { }

        protected override JsonSerializerOptions JsonSerializerOptions => new()
        {
            Converters =
            {
                new MethodEnumJsonConvert(),
                new JsonStringEnumConverter(),
            }
        };

        public override async Task<GetSessionResponse> ExecuteRequest(string sessionId) =>
            await BaseExecute(GET, $"api/v1/account_verification_sessions/{sessionId}", sessionId);

        protected override async Task<GetSessionResponse> ParseHttpResponse(HttpResponseMessage hrm, string _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => GetSessionResponse.Successful(hrm.StatusCode, await Deserialize<GetSessionResponseBody>(responseBody), responseBody),
                _ => GetSessionResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;
        }
    }
}
