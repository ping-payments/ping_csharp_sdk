using PingPayments.PaymentsApi.DepositBankAccount.BankTransfer.Connect.Request.V1;
using PingPayments.PaymentsApi.DepositBankAccount.List.Request.V1;
using PingPayments.PaymentsApi.DepositBankAccount.List.Response.V1;
using PingPayments.Shared;
using System;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.DepositBankAccount
{
    public interface IDepositBankAccountV1
    {
        Task<EmptyResponse> ConnectBankTransfer(Guid depositBandAccountId, Guid transferId, ConnectBankTransferRequest connectRequest);
        Task<ListBankAccountsResponse> ListBankAccounts(Guid depositBandAccountId, ListBankAccountsRequest ListBankAccountsRequest);
    }
}