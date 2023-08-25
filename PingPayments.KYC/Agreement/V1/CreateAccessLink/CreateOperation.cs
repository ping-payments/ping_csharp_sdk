using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.KYC.Agreement.V1.CreateAccessLink
{
    public class CreateOperation : OperationBase<(Guid agreementId, CreateRequestBody createRequest), CreateResponse>
    {
        public CreateOperation(HttpClient httpClient) : base(httpClient) { }

        public async override Task<CreateResponse> ExecuteRequest((Guid agreementId, CreateRequestBody createRequest) request) =>
            await BaseExecute(POST, $"api/agreements/{request.agreementId}", request, await ToJson(request.createRequest));

        protected override async Task<CreateResponse> ParseHttpResponse(HttpResponseMessage hrm, (Guid agreementId, CreateRequestBody createRequest) request)
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
