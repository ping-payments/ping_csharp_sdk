using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;


namespace PingPayments.PaymentLinksApi.PaymentLinks.Cancel.V1
{
    public class CancelPaymentLinkOperation : OperationBase<Guid, EmptyResponse>
    {
        public CancelPaymentLinkOperation(HttpClient httpClient) : base(httpClient) { }

        public override async Task<EmptyResponse> ExecuteRequest(Guid paymentLinkId) =>
            await BaseExecute
            (
                PUT,
                $"api/v1/payment_links/{paymentLinkId}/cancel",
                paymentLinkId,
                await ToJson(new { })
            );

        protected override async Task<EmptyResponse> ParseHttpResponse(HttpResponseMessage hrm, Guid _) =>
            hrm.StatusCode switch
            {
                NoContent => EmptyResponse.Successful(hrm.StatusCode),
                _ =>
                    EmptyResponse.Failure
                    (
                        hrm.StatusCode,
                        await Deserialize<ErrorResponseBody>(await hrm.Content.ReadAsStringAsyncMemoized()),
                        await hrm.Content.ReadAsStringAsyncMemoized()
                    )
            };
    }
}