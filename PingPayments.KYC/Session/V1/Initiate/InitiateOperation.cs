using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.KYC.Session.V1.Initiate
{
    public class InitiateOperation : OperationBase<InitiateRequest, GuidResponse>
    {
        public InitiateOperation(HttpClient httpClient) : base(httpClient) { }
        public override async Task<GuidResponse> ExecuteRequest(InitiateRequest request) =>
            await BaseExecute
            (
                POST,
                "api/initiate_verification",
                request
            );

        protected override async Task<GuidResponse> ParseHttpResponse(HttpResponseMessage hrm, InitiateRequest _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                Created => GuidResponse.Succesful(hrm.StatusCode, await Deserialize<GuidResponseBody>(responseBody), responseBody),
                _ => GuidResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;
        }
    }
}
