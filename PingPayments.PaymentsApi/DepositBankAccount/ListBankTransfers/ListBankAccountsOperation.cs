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
    public class ListBankTransfersOperation : OperationBase<(Guid depositBankAccountId, ListBankTransfersRequest? listRequest), ListBankTransfersResponse>
    {
        public ListBankTransfersOperation(HttpClient httpClient) : base(httpClient) { }

        public override async Task<ListBankTransfersResponse> ExecuteRequest((Guid depositBankAccountId, ListBankTransfersRequest? listRequest) request) =>

            await BaseExecute(GET,
            request.listRequest != null ?
                $"api/v1/deposit_bank_accounts/{request.depositBankAccountId}/transfers{request.listRequest.ToFilterUrl()}"
            :
                $"api/v1/deposit_bank_accounts/{request.depositBankAccountId}/transfers",
            request);

        protected override async Task<ListBankTransfersResponse> ParseHttpResponse(HttpResponseMessage hrm, (Guid depositBankAccountId, ListBankTransfersRequest? listRequest) _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => await GetSuccessful(),
                _ => ListBankTransfersResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;

            async Task<ListBankTransfersResponse> GetSuccessful()
            {
                var bankTransfers = await Deserialize<DepositBankAccount.ListBankTransfer.Response.V1.BankTransfer?>(responseBody);
                var response = ListBankTransfersResponse.Successful(hrm.StatusCode, bankTransfers, responseBody);
                return response;
            }
        }
    }
}