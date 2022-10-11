using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;


namespace PingPayments.PaymentLinksApi.Ping.V1
{
    public class PingOperation : OperationBase<EmptyRequest, TextResponse>
    {
        public PingOperation(HttpClient httpClient) : base(httpClient)
        {
        }

        public override async Task<TextResponse> ExecuteRequest(EmptyRequest emptyRequest) =>
            await BaseExecute
            (
                GET,
                $"api/v1/ping",
                emptyRequest
            );

        protected override async Task<TextResponse> ParseHttpResponse(HttpResponseMessage hrm, EmptyRequest _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => TextResponse.Successful(hrm.StatusCode, responseBody, responseBody),
                _ => TextResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;
        }
    }
}
