using PingPayments.PaymentLinksApi.Helpers;
using PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1;
using PingPayments.PaymentLinksApi.Shared;
using System.Text.Json;
using System.Text.Json.Serialization;

using static PingPayments.PaymentLinksApi.Shared.RequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentLinksApi.Files.Receipt.Get.V1
{
    public class GetReceiptOperation : OperationBase<Guid, InvoiceResponse>
    {
        public GetReceiptOperation(HttpClient httpClient) : base(httpClient) { }

        public override async Task<InvoiceResponse> ExecuteRequest(Guid paymentLinkId) =>
            await BaseExecute(GET, $"api/v1/payment_links/{paymentLinkId}", paymentLinkId);

        protected override async Task<InvoiceResponse> ParseHttpResponse(HttpResponseMessage hrm, Guid _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => InvoiceResponse.Succesful(hrm.StatusCode, await Deserialize<PaymentLink>(responseBody), responseBody),
                _ => await ToError(hrm)
            };
            return response;
        }

        protected async Task<InvoiceResponse> ToError(HttpResponseMessage hrm) =>
            InvoiceResponse.Failure
            (
                hrm.StatusCode,
                await Deserialize<ErrorResponseBody>(await hrm.Content.ReadAsStringAsyncMemoized()),
                await hrm.Content.ReadAsStringAsyncMemoized()
            );
    }
}