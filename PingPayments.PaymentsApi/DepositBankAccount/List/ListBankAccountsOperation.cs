using PingPayments.PaymentsApi.DepositBankAccount.Shared;
using PingPayments.PaymentsApi.DepositBankAccount.List.Response.V1;
using PingPayments.PaymentsApi.DepositBankAccount.List.Request.V1;
using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;
using System;

namespace PingPayments.PaymentsApi.DepositBankAccount.List.V1
{
    public class ListBankTransfersOperation : OperationBase<(Guid depositBankAccountId, ListBankAccountsRequest? listRequest), ListBankAccountsResponse>
    {
        public ListBankTransfersOperation(HttpClient httpClient) : base(httpClient) { }

        public override async Task<ListBankAccountsResponse> ExecuteRequest((Guid depositBankAccountId, ListBankAccountsRequest? listRequest) request) =>
            await BaseExecute(GET, $"api/v1/deposit_bank_accounts/{request.depositBankAccountId}/transfers{request.listRequest.ToFilterUrl()}", request);

        protected override async Task<ListBankAccountsResponse> ParseHttpResponse(HttpResponseMessage hrm, (Guid depositBankAccountId, ListBankAccountsRequest? listRequest) _)
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
                var depoitBankAccount = await Deserialize<Response.V1.DepositBankAccount?>(responseBody);
                var response = ListBankAccountsResponse.Successful(hrm.StatusCode, depoitBankAccount, responseBody);
                return response;
            }
        }
    }
}