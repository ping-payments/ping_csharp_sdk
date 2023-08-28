using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.KYC.Agreement.V1.CreateAccessLink
{
    public class CreateOperation : OperationBase<CreateRequestBody, CreateResponse>
    {
        public CreateOperation(HttpClient httpClient) : base(httpClient) { }

        public async override Task<CreateResponse> ExecuteRequest(CreateRequestBody createRequest) =>
            await BaseExecute(POST, $"api/agreements/{createRequest.AgreementId}/access_link", createRequest, await ToJson(createRequest));

        protected override async Task<CreateResponse> ParseHttpResponse(HttpResponseMessage hrm, CreateRequestBody createRequest)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => CreateResponse.Successful(hrm.StatusCode, await Deserialize<AccessLink>(responseBody), responseBody),
                _ => CreateResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;
        }
    }
}
