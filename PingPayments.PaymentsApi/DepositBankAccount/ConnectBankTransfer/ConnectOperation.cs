using PingPayments.PaymentsApi.DepositBankAccount.BankTransfer.Connect.Request.V1;
using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.DepositBankAccount.BankTransfer.Connect.V1
{
    public class ConnectOperation : OperationBase<(Guid depositBandAccountId, Guid transferId, ConnectBankTransferRequest connectRequest), EmptyResponse>
    {
        public ConnectOperation(HttpClient httpClient) : base(httpClient) { }

        protected override JsonSerializerOptions JsonSerializerOptions => new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        public override async Task<EmptyResponse> ExecuteRequest((Guid depositBandAccountId, Guid transferId, ConnectBankTransferRequest connectRequest) request) =>
            await BaseExecute
            (
                POST,
                $"api/v1/deposit_bank_accounts/{request.depositBandAccountId}/transfers/{request.transferId}/connect",
                request,
                await ToJson(request.connectRequest)
            );

        protected override async Task<EmptyResponse> ParseHttpResponse(HttpResponseMessage hrm, (Guid depositBandAccountId, Guid transferId, ConnectBankTransferRequest connectRequest) _) =>

            hrm.StatusCode switch
            {
                NoContent => EmptyResponse.Successful(hrm.StatusCode),
                _ => EmptyResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(await hrm.Content.ReadAsStringAsyncMemoized()), await hrm.Content.ReadAsStringAsyncMemoized())
            };

    }
}
