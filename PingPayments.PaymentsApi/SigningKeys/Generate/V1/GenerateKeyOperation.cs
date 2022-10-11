using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.SigningKeys.Generate.V1
{
    public class GenerateKeyOperation : OperationBase<EmptyRequest, GenerateResponse>
    {
        public GenerateKeyOperation(HttpClient httpClient) : base(httpClient) { }

        public override async Task<GenerateResponse> ExecuteRequest(EmptyRequest request) =>
            await BaseExecute(POST, "api/v1/signing_key/generate", request);

        protected override async Task<GenerateResponse> ParseHttpResponse(HttpResponseMessage hrm, EmptyRequest request)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => GenerateResponse.Successful(hrm.StatusCode, await Deserialize<GenerateKeyResponseBody>(responseBody), responseBody),
                _ => GenerateResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;
        }
    }
}
