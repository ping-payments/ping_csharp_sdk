
using PingPayments.Shared;
using System.Net;

namespace PingPayments.PaymentsApi.DepositBankAccount.List.Response.V1
{
    public record ListBankAccountsResponse : ApiResponseBase<ListBankAccountsResponseBody[]>
    {
        public ListBankAccountsResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<ListBankAccountsResponseBody[]>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }
        public static ListBankAccountsResponse Successful(HttpStatusCode statusCode, ListBankAccountsResponseBody[]? b, string rb) => new(statusCode, true, b, rb);
        public static ListBankAccountsResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);

        public static implicit operator ListBankAccountsResponseBody[](ListBankAccountsResponse bar) =>
            (bar?.Body?.SuccessfulResponseBody) ?? new ListBankAccountsResponseBody[] { };
    }
}