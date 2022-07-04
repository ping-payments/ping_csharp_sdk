using PingPayments.PaymentLinksApi.Files.Shared.V1;
using PingPayments.PaymentLinksApi.Helpers;
using PingPayments.PaymentLinksApi.Shared;


using static PingPayments.PaymentLinksApi.Shared.RequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentLinksApi.Files.Receipt.Get.V1
{
    public class GetReceiptOperation : OperationBase<Guid, UrlResponse>
    {
        public GetReceiptOperation(HttpClient httpClient) : base(httpClient) { }

        public override async Task<UrlResponse> ExecuteRequest(Guid paymentLinkId) =>
            await BaseExecute(GET, $"api/v1/payment_links/{paymentLinkId}/receipt", paymentLinkId);

        protected override async Task<UrlResponse> ParseHttpResponse(HttpResponseMessage hrm, Guid _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => UrlResponse.Succesful(hrm.StatusCode, await Deserialize<UrlResponseBody>(responseBody), responseBody),
                _ => await ToError(hrm)
            };
            return response;
        }

        protected async Task<UrlResponse> ToError(HttpResponseMessage hrm) =>
            UrlResponse.Failure
            (
                hrm.StatusCode,
                await Deserialize<ErrorResponseBody>(await hrm.Content.ReadAsStringAsyncMemoized()),
                await hrm.Content.ReadAsStringAsyncMemoized()
            );
    }
}