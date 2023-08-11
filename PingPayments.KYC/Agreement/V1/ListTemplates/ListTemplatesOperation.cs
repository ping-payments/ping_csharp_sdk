using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.KYC.Agreement.V1.GetAgreementTemplates
{
    public class ListTemplatesOperation : OperationBase<EmptyRequest?, AgreementTemplatesResponse>
    {
        public ListTemplatesOperation(HttpClient httpClient) : base(httpClient) { }

        public async override Task<AgreementTemplatesResponse> ExecuteRequest(EmptyRequest? emptyRequest = null) =>
            await BaseExecute(GET, $"api/agreements/templates", emptyRequest);

        protected override async Task<AgreementTemplatesResponse> ParseHttpResponse(HttpResponseMessage hrm, EmptyRequest _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => AgreementTemplatesResponse.Successful(hrm.StatusCode, await Deserialize<AgreementTemplate[]>(responseBody), responseBody),
                _ => AgreementTemplatesResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;
        }
    }
}
