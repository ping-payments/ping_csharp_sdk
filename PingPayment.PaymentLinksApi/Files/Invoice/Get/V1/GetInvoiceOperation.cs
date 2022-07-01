using PingPayments.PaymentLinksApi.Files.Shared;
using PingPayments.PaymentLinksApi.Helpers;
using PingPayments.PaymentLinksApi.Shared;
using System.Text.Json;
using System.Text.Json.Serialization;

using static PingPayments.PaymentLinksApi.Shared.RequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentLinksApi.Files.Invoice.Get.V1
{
    public class GetInvoiceOperation : OperationBase<Guid, InvoiceResponse>
    {
        public GetInvoiceOperation(HttpClient httpClient) : base(httpClient) { }

        public override async Task<InvoiceResponse> ExecuteRequest(Guid paymentLinkId) =>
            await BaseExecute(GET, $"api/v1/payment_links/{paymentLinkId}/invoice", paymentLinkId);

        protected override async Task<InvoiceResponse> ParseHttpResponse(HttpResponseMessage hrm, Guid _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => InvoiceResponse.Succesful(hrm.StatusCode, await Deserialize<UrlResponseBody>(responseBody), responseBody),
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