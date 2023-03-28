using PingPayments.PaymentLinksApi.Shared;
using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;


namespace PingPayments.PaymentLinksApi.Ping.V1
{
    public class PingOperation : OperationBase<EmptyRequest, PaymentLinksTextResponse>
    {
        public PingOperation(HttpClient httpClient) : base(httpClient)
        {
        }

        public override async Task<PaymentLinksTextResponse> ExecuteRequest(EmptyRequest emptyRequest) =>
            await BaseExecute
            (
                GET,
                $"api/v1/ping",
                emptyRequest
            );

        protected override async Task<PaymentLinksTextResponse> ParseHttpResponse(HttpResponseMessage hrm, EmptyRequest _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => PaymentLinksTextResponse.Successful(hrm.StatusCode, responseBody, responseBody),
                _ => PaymentLinksTextResponse.Failure(hrm.StatusCode, await Deserialize<PaymentLinksErrorResponseBody>(responseBody), responseBody)
            };
            return response;
        }
    }
}
