using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.KYC.Agreement.V1.Publish
{
    public class PublishOperation : OperationBase<PublishRequest, EmptyResponse>
    {
        public PublishOperation(HttpClient httpClient) : base(httpClient) { }

        public async override Task<EmptyResponse> ExecuteRequest(PublishRequest publishAgreementRequest) =>
            await BaseExecute(
                POST,
                $"api/agreements/{publishAgreementRequest.AgreementId}/publish",
                publishAgreementRequest,
                await ToJson(publishAgreementRequest)
            );

        protected override async Task<EmptyResponse> ParseHttpResponse(HttpResponseMessage hrm, PublishRequest _)
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
