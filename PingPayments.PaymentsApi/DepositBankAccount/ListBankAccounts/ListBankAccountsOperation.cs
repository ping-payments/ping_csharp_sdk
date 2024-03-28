using PingPayments.PaymentsApi.DepositBankAccount.List.Response.V1;
using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.DepositBankAccount.List.V1
{
    public class ListBankAccountsOperation : OperationBase<EmptyRequest?, ListBankAccountsResponse>
    {
        public ListBankAccountsOperation(HttpClient httpClient) : base(httpClient) { }

        public override async Task<ListBankAccountsResponse> ExecuteRequest(EmptyRequest? emptyRequest = null) =>
            await BaseExecute(GET, $"api/v1/deposit_bank_accounts", emptyRequest);

        protected override async Task<ListBankAccountsResponse> ParseHttpResponse(HttpResponseMessage hrm, EmptyRequest? _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => await GetSuccessful(),
                _ => ListBankAccountsResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;

            async Task<ListBankAccountsResponse> GetSuccessful()
            {
                var depoitBankAccounts = await Deserialize<ListBankAccountsResponseBody[]?>(responseBody);
                var response = ListBankAccountsResponse.Successful(hrm.StatusCode, depoitBankAccounts, responseBody);
                return response;
            }
        }
    }
}
