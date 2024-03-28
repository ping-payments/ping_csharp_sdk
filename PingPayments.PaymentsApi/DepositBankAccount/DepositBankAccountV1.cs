using PingPayments.PaymentsApi.BankTransfer.List.V1;
using PingPayments.PaymentsApi.DepositBankAccount.BankTransfer.Connect.Request.V1;
using PingPayments.PaymentsApi.DepositBankAccount.BankTransfer.Connect.V1;
using PingPayments.PaymentsApi.DepositBankAccount.List.Response.V1;
using PingPayments.PaymentsApi.DepositBankAccount.List.V1;
using PingPayments.PaymentsApi.DepositBankAccount.ListBankTransfer.Request.V1;
using PingPayments.PaymentsApi.DepositBankAccount.ListBankTransfer.Response.V1;
using PingPayments.Shared;
using System;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.DepositBankAccount
{
    public class DepositBankAccountV1 : IDepositBankAccountV1
    {
        public DepositBankAccountV1
        (
            Lazy<ConnectOperation> connectBankTransferOperation,
            Lazy<ListBankTransfersOperation> listBankTransfersOperation,
            Lazy<ListBankAccountsOperation> listBankAccountsOperation
        )
        {
            _connectBankTransferOperation = connectBankTransferOperation;
            _listBankTransfersOperation = listBankTransfersOperation;
            _listBankAccountsOperation = listBankAccountsOperation;
        }

        private readonly Lazy<ConnectOperation> _connectBankTransferOperation;
        private readonly Lazy<ListBankTransfersOperation> _listBankTransfersOperation;
        private readonly Lazy<ListBankAccountsOperation> _listBankAccountsOperation;

        public async Task<EmptyResponse> ConnectBankTransfer(Guid depositBandAccountId, Guid transferId, ConnectBankTransferRequest connectBankTransferRequest) =>
            await _connectBankTransferOperation.Value.ExecuteRequest((depositBandAccountId, transferId, connectBankTransferRequest));

        public async Task<ListBankTransfersResponse> ListBankTransfers(Guid depositBandAccountId, ListBankTransfersRequest? listBankAccountsRequest) =>
            await _listBankTransfersOperation.Value.ExecuteRequest((depositBandAccountId, listBankAccountsRequest));

        public async Task<ListBankAccountsResponse> List() =>
            await _listBankAccountsOperation.Value.ExecuteRequest();
    }
}
