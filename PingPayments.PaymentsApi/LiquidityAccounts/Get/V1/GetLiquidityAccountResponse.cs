using PingPayments.PaymentsApi.LiquidityAccounts.Create.V1;
using PingPayments.Shared;
using System.Net;

namespace PingPayments.PaymentsApi.LiquidityAccounts.Get.V1
{
    public record GetLiquidityAccountResponse : ApiResponseBase<GetLiquidityAccountResponseBody>
    {
        public GetLiquidityAccountResponse(HttpStatusCode statusCode, bool IsSuccessful, ResponseBody<GetLiquidityAccountResponseBody>? Body, string RawBody) : base(statusCode, IsSuccessful, Body, RawBody) { }
        public static GetLiquidityAccountResponse Successful(HttpStatusCode statusCode, GetLiquidityAccountResponseBody? b, string rb) => new(statusCode, true, b, rb);
        public static GetLiquidityAccountResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);

        public static implicit operator GetLiquidityAccountResponseBody?(GetLiquidityAccountResponse x) =>
            x?.Body?.SuccessfulResponseBody as GetLiquidityAccountResponseBody;
    }
}
