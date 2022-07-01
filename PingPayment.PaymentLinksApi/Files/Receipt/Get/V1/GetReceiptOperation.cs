using PingPayments.PaymentLinksApi.Files.Shared;
using PingPayments.PaymentLinksApi.Helpers;
using PingPayments.PaymentLinksApi.Shared;


using static PingPayments.PaymentLinksApi.Shared.RequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentLinksApi.Files.Receipt.Get.V1
{
    public class GetReceiptOperation : OperationBase<Guid, ReceiptResponse>
    {
        public GetReceiptOperation(HttpClient httpClient) : base(httpClient) { }

        public override async Task<ReceiptResponse> ExecuteRequest(Guid paymentLinkId) =>
            await BaseExecute(GET, $"api/v1/payment_links/{paymentLinkId}/receipt", paymentLinkId);

        protected override async Task<ReceiptResponse> ParseHttpResponse(HttpResponseMessage hrm, Guid _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => ReceiptResponse.Succesful(hrm.StatusCode, await Deserialize<UrlResponseBody>(responseBody), responseBody),
                _ => await ToError(hrm)
            };
            return response;
        }

        protected async Task<ReceiptResponse> ToError(HttpResponseMessage hrm) =>
            ReceiptResponse.Failure
            (
                hrm.StatusCode,
                await Deserialize<ErrorResponseBody>(await hrm.Content.ReadAsStringAsyncMemoized()),
                await hrm.Content.ReadAsStringAsyncMemoized()
            );
    }
}