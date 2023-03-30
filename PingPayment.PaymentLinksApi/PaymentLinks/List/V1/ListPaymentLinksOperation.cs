using PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1;
using PingPayments.PaymentLinksApi.Shared;
using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentLinksApi.PaymentLinks.List.V1
{
    public class ListPaymentLinksOperation : OperationBase<EmptyRequest, PaymentLinksResponse>
    {
        public ListPaymentLinksOperation(HttpClient httpClient) : base(httpClient) { }

        public override async Task<PaymentLinksResponse> ExecuteRequest(EmptyRequest? emptyRequest) =>
        await BaseExecute
            (
                GET,
                $"api/v1/payment_links",
                emptyRequest
            );

        protected override async Task<PaymentLinksResponse> ParseHttpResponse(HttpResponseMessage hrm, EmptyRequest? _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => PaymentLinksResponse.Successful(hrm.StatusCode, new PaymentLinkList(await Deserialize<PaymentLink[]>(responseBody)), responseBody),
                _ => PaymentLinksResponse.Failure(hrm.StatusCode, await Deserialize<PaymentLinksErrorResponseBody>(responseBody), responseBody)
            };
            return response;
        }
    }
}
