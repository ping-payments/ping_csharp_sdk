using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.KYC.Agreement.V1.Create
{
    public class CreateAgreementOperation : OperationBase<CreateAgreementRequestBody, GuidResponse>
    {
        public CreateAgreementOperation(HttpClient httpClient) : base(httpClient) { }

        public async override Task<GuidResponse> ExecuteRequest(CreateAgreementRequestBody createAgreement) =>
            await BaseExecute(POST, $"api/agreements", createAgreement, await ToJson(createAgreement));

        protected override async Task<GuidResponse> ParseHttpResponse(HttpResponseMessage hrm, CreateAgreementRequestBody _createAgreement)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => GuidResponse.Successful(hrm.StatusCode, await Deserialize<GuidResponseBody>(responseBody), responseBody),
                _ => GuidResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;
        }
    }
}
