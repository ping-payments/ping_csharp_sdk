using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.KYC.Agreement.V1.Publish
{ 
    public class PublishAgreementOperation : OperationBase<PublishAgreementRequest, EmptyResponse>
    {
        public PublishAgreementOperation(HttpClient httpClient) : base(httpClient) { }

        public async override Task<EmptyResponse> ExecuteRequest(PublishAgreementRequest publishAgreementRequest) =>
            await BaseExecute(
                GET, 
                $"api/agreements/{publishAgreementRequest.AgreementId}/publish", 
                publishAgreementRequest,
                await ToJson(publishAgreementRequest)
            );

        protected override async Task<EmptyResponse> ParseHttpResponse(HttpResponseMessage hrm, PublishAgreementRequest _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => EmptyResponse.Successful(hrm.StatusCode),
                _ => EmptyResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;
        }
    }
}
