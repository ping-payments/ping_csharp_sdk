using PingPayments.PaymentsApi.Payments.V1.Initiate.Response;
using PingPayments.Shared;
using System.Net;

namespace PingPayments.PaymentsApi.LiquidityAccounts.Create.V1
{
    /// <summary>
    /// Response for creating a liquidity account
    /// </summary>
    public record CreateLiquidityAccountResponse : ApiResponseBase<CreateLiquidityAccountResponseBody>
    {
        public CreateLiquidityAccountResponse(HttpStatusCode statusCode, bool IsSuccessful, ResponseBody<CreateLiquidityAccountResponseBody>? Body, string RawBody) : base(statusCode, IsSuccessful, Body, RawBody) { }
        public static CreateLiquidityAccountResponse Successful(HttpStatusCode statusCode, CreateLiquidityAccountResponseBody? b, string rb) => new(statusCode, true, b, rb);
        public static CreateLiquidityAccountResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);

        public static implicit operator CreateLiquidityAccountResponseBody?(CreateLiquidityAccountResponse x) =>
            x?.Body?.SuccessfulResponseBody as CreateLiquidityAccountResponseBody;
    }
}