using PingPayments.PaymentLinksApi.Helpers;
using PingPayments.PaymentLinksApi.Shared;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.PaymentLinksApi.Shared.RequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentLinksApi.PaymentLinks.Send.V1
{
    public class SendPaymentLinkOperation : OperationBase<Guid, EmptyResponse>
    {
        public SendPaymentLinkOperation(HttpClient httpClient) : base(httpClient) { }

        public override async Task<EmptyResponse> ExecuteRequest(Guid paymentLinkId) =>
            await BaseExecute
            (
                PUT,
                $"api/v1/payment_links/{paymentLinkId}/distribute", paymentLinkId,
                await ToJson(new { })
            );

        protected override async Task<EmptyResponse> ParseHttpResponse(HttpResponseMessage hrm, Guid _) =>
            hrm.StatusCode switch
            {
                NoContent => EmptyResponse.Succesful(hrm.StatusCode),
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