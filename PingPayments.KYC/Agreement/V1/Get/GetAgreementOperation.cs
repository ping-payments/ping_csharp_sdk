using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.KYC.Agreement.V1.Get
{
    public class GetAgreementOperation : OperationBase<Guid, AgreementResponse>
    {
        public GetAgreementOperation(HttpClient httpClient) : base(httpClient) { }

        public async override Task<AgreementResponse> ExecuteRequest(Guid agreementId) =>
            await BaseExecute(GET, $"api/agreements/{agreementId}", agreementId);

        protected override async Task<AgreementResponse> ParseHttpResponse(HttpResponseMessage hrm, Guid _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => AgreementResponse.Successful(hrm.StatusCode, await Deserialize<AgreementResponseBody>(responseBody), responseBody),
                _ => AgreementResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;
        }
    }
}
