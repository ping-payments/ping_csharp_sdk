using PingPayments.PaymentLinksApi.Shared;
using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;


namespace PingPayments.PaymentLinksApi.PaymentLinks.Cancel.V1
{
    public class CancelPaymentLinkOperation : OperationBase<Guid, PaymentLinksEmptyResponse>
    {
        public CancelPaymentLinkOperation(HttpClient httpClient) : base(httpClient) { }

        public override async Task<PaymentLinksEmptyResponse> ExecuteRequest(Guid paymentLinkId) =>
            await BaseExecute
            (
                PUT,
                $"api/v1/payment_links/{paymentLinkId}/cancel",
                paymentLinkId,
                await ToJson(new { })
            );

        protected override async Task<PaymentLinksEmptyResponse> ParseHttpResponse(HttpResponseMessage hrm, Guid _) =>
            hrm.StatusCode switch
            {
                NoContent => PaymentLinksEmptyResponse.Successful(hrm.StatusCode),
                _ =>
                    PaymentLinksEmptyResponse.Failure
                    (
                        hrm.StatusCode,
                        await Deserialize<PaymentLinksErrorResponseBody>(await hrm.Content.ReadAsStringAsyncMemoized()),
                        await hrm.Content.ReadAsStringAsyncMemoized()
                    )
            };
    }
}