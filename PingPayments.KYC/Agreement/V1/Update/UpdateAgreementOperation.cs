using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.KYC.Agreement.V1.Update
{
    public class UpdateAgreementOperation : OperationBase<UpdateAgreementRequest, EmptyResponse>
    {
        public UpdateAgreementOperation(HttpClient httpClient) : base(httpClient) { }

        public async override Task<EmptyResponse> ExecuteRequest(UpdateAgreementRequest updateAgreementRequest) =>
            await BaseExecute(
                PUT, 
                $"api/agreements/{updateAgreementRequest.AgreementId}", 
                updateAgreementRequest,
                await ToJson(updateAgreementRequest)
            );

        protected override async Task<EmptyResponse> ParseHttpResponse(HttpResponseMessage hrm, UpdateAgreementRequest _)
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
