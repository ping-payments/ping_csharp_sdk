using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.KYC.Agreement.V1.CreateAccessLink
{
    public class CreateAccessLinkOperation : OperationBase<CreateAccessLinkRequestBody, CreateAccessLinkResponse>
    {
        public CreateAccessLinkOperation(HttpClient httpClient) : base(httpClient) { }

        public async override Task<CreateAccessLinkResponse> ExecuteRequest(CreateAccessLinkRequestBody createRequest) =>
            await BaseExecute(POST, $"api/agreements/{createRequest.AgreementId}/access_link", createRequest, await ToJson(createRequest));

        protected override async Task<CreateAccessLinkResponse> ParseHttpResponse(HttpResponseMessage hrm, CreateAccessLinkRequestBody createRequest)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => CreateAccessLinkResponse.Successful(hrm.StatusCode, await Deserialize<AccessLink>(responseBody), responseBody),
                _ => CreateAccessLinkResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;
        }
    }
}
