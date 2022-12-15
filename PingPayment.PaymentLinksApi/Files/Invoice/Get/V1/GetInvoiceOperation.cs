using PingPayments.PaymentLinksApi.Files.Shared.V1;
using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentLinksApi.Files.Invoice.Get.V1
{
    public class GetInvoiceOperation : OperationBase<Guid, GetInvoiceResponse>
    {
        public GetInvoiceOperation(HttpClient httpClient) : base(httpClient) { }

        public override async Task<GetInvoiceResponse> ExecuteRequest(Guid paymentLinkId) =>
            await BaseExecute
            (
                GET,
                $"api/v1/payment_links/{paymentLinkId}/invoice",
                paymentLinkId
            );

        protected override async Task<GetInvoiceResponse> ParseHttpResponse(HttpResponseMessage hrm, Guid _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => GetInvoiceResponse.Successful(hrm.StatusCode, await Deserialize<GetInvoiceResponseBody>(responseBody), responseBody),
                _ => await ToError(hrm)
            };
            return response;
        }

        protected async Task<GetInvoiceResponse> ToError(HttpResponseMessage hrm) =>
            GetInvoiceResponse.Failure
            (
                hrm.StatusCode,
                await Deserialize<ErrorResponseBody>(await hrm.Content.ReadAsStringAsyncMemoized()),
                await hrm.Content.ReadAsStringAsyncMemoized()
            );
    }
}