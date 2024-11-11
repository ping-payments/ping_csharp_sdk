using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.KYC.Agreement.V1.Delete
{
    public class DeleteOperation : OperationBase<DeleteRequest, EmptyResponse>
    {
        public DeleteOperation(HttpClient httpClient) : base(httpClient) { }

        public async override Task<EmptyResponse> ExecuteRequest(DeleteRequest deleteAgreementRequest) =>
            await BaseExecute(DELETE, $"api/agreements/{deleteAgreementRequest.AgreementId}", deleteAgreementRequest, await ToJson(deleteAgreementRequest));

        protected override async Task<EmptyResponse> ParseHttpResponse(HttpResponseMessage hrm, DeleteRequest _)
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
