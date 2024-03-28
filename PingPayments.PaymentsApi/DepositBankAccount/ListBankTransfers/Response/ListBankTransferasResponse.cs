
using PingPayments.Shared;
using System.Net;

namespace PingPayments.PaymentsApi.DepositBankAccount.ListBankTransfer.Response.V1
{
    public record ListBankTransferasResponse : ApiResponseBase<BankTransfer>
    {
        public ListBankTransferasResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<BankTransfer>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }
        public static ListBankTransferasResponse Successful(HttpStatusCode statusCode, BankTransfer? b, string rb) => new(statusCode, true, b, rb);
        public static ListBankTransferasResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);

        public static implicit operator BankTransfer(ListBankTransferasResponse bar) =>
            (bar?.Body?.SuccessfulResponseBody) ?? new BankTransfer { };
    }
}