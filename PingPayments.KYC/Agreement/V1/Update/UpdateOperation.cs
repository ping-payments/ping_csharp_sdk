using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.KYC.Agreement.V1.Update
{
    public class UpdateOperation : OperationBase<UpdateRequest, EmptyResponse>
    {
        public UpdateOperation(HttpClient httpClient) : base(httpClient) { }

        public async override Task<EmptyResponse> ExecuteRequest(UpdateRequest updateAgreementRequest) =>
            await BaseExecute(
                PUT,
                $"api/agreements/{updateAgreementRequest.AgreementId}",
                updateAgreementRequest,
                await ToJson(updateAgreementRequest)
            );

        protected override async Task<EmptyResponse> ParseHttpResponse(HttpResponseMessage hrm, UpdateRequest _)
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
