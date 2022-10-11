using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;


namespace PingPayments.PaymentsApi.Tenants.Get.V1
{
    public class GetTenantOperation : OperationBase<EmptyRequest, TenantResponse>
    {
        public GetTenantOperation(HttpClient httpClient) : base(httpClient) { }

        public override async Task<TenantResponse> ExecuteRequest(EmptyRequest? emptyRequest = null) =>
            await BaseExecute(GET, $"api/v1/tenant", emptyRequest);

        protected override async Task<TenantResponse> ParseHttpResponse(HttpResponseMessage hrm, EmptyRequest? _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => TenantResponse.Successful(hrm.StatusCode, await Deserialize<TenantResponseBody>(responseBody), responseBody),
                _ => TenantResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;
        }
    }
}

