using PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1;
using PingPayments.PaymentLinksApi.Shared;
using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentLinksApi.PaymentLinks.Get.V1
{
    public class GetPaymentLinkOperation : OperationBase<Guid, PaymentLinkResponse>
    {
        public GetPaymentLinkOperation(HttpClient httpClient) : base(httpClient) { }

        public override async Task<PaymentLinkResponse> ExecuteRequest(Guid paymentLinkId) =>
            await BaseExecute
            (
                GET,
                $"api/v1/payment_links/{paymentLinkId}",
                paymentLinkId
            );

        protected override async Task<PaymentLinkResponse> ParseHttpResponse(HttpResponseMessage hrm, Guid _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => PaymentLinkResponse.Successful(hrm.StatusCode, await Deserialize<PaymentLink>(responseBody), responseBody),
                _ => await ToError(hrm)
            };
            return response;
        }

        protected async Task<PaymentLinkResponse> ToError(HttpResponseMessage hrm) =>
            PaymentLinkResponse.Failure
            (
                hrm.StatusCode,
                await Deserialize<PaymentLinksErrorResponseBody>(await hrm.Content.ReadAsStringAsyncMemoized()),
                await hrm.Content.ReadAsStringAsyncMemoized()
            );
    }
}