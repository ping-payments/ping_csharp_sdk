
using PingPayments.Shared;
using PingPayments.PaymentsApi.DepositBankAccount.List.Response;
using System.Net;

namespace PingPayments.PaymentsApi.DepositBankAccount.List.Response.V1
{
    public record ListBankAccountsResponse : ApiResponseBase<DepositBankAccount>
    {
        public ListBankAccountsResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<DepositBankAccount>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }
        public static ListBankAccountsResponse Successful(HttpStatusCode statusCode, DepositBankAccount? b, string rb) => new(statusCode, true, b, rb);
        public static ListBankAccountsResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);

        public static implicit operator DepositBankAccount(ListBankAccountsResponse bar) =>
            (bar?.Body?.SuccessfulResponseBody) ?? new DepositBankAccount { };
    }
}