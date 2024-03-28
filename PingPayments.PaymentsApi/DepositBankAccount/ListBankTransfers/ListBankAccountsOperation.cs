using PingPayments.PaymentsApi.DepositBankAccount.Shared;
using PingPayments.PaymentsApi.DepositBankAccount.ListBankTransfer.Response.V1;
using PingPayments.PaymentsApi.DepositBankAccount.ListBankTransfer.Request.V1;
using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;
using System;

namespace PingPayments.PaymentsApi.BankTransfer.List.V1
{
    public class ListBankTransfersOperation : OperationBase<(Guid depositBankAccountId, ListBankTransfersRequest? listRequest), ListBankTransferasResponse>
    {
        public ListBankTransfersOperation(HttpClient httpClient) : base(httpClient) { }

        public override async Task<ListBankTransferasResponse> ExecuteRequest((Guid depositBankAccountId, ListBankTransfersRequest? listRequest) request) =>
            await BaseExecute(GET, $"api/v1/deposit_bank_accounts/{request.depositBankAccountId}/transfers{request.listRequest.ToFilterUrl()}", request);

        protected override async Task<ListBankTransferasResponse> ParseHttpResponse(HttpResponseMessage hrm, (Guid depositBankAccountId, ListBankTransfersRequest? listRequest) _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => await GetSuccessful(),
                _ => ListBankTransferasResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;

            async Task<ListBankTransferasResponse> GetSuccessful()
            {
                var bankTransfers = await Deserialize<DepositBankAccount.ListBankTransfer.Response.V1.BankTransfer?>(responseBody);
                var response = ListBankTransferasResponse.Successful(hrm.StatusCode, bankTransfers, responseBody);
                return response;
            }
        }
    }
}