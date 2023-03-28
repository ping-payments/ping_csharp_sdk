using PingPayments.PaymentLinksApi.PaymentLinks.Send.V1.Requests;
using PingPayments.PaymentLinksApi.Shared;
using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System.Text.Json;
using System.Text.Json.Serialization;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentLinksApi.PaymentLinks.Send.V1
{
    public class SendPaymentLinkOperation : OperationBase<(Guid paymentLinkID, SendPaymentLinkRequestBody sendPaymentLinkRequestBody), PaymentLinksEmptyResponse>
    {
        public SendPaymentLinkOperation(HttpClient httpClient) : base(httpClient) { }

        public override async Task<PaymentLinksEmptyResponse> ExecuteRequest((Guid paymentLinkID, SendPaymentLinkRequestBody sendPaymentLinkRequestBody) request) =>
            await BaseExecute
            (
                PUT,
                $"api/v1/payment_links/{request.paymentLinkID}/distribute",
                request,
                await ToJson(request.sendPaymentLinkRequestBody)
            );

        protected override JsonSerializerOptions JsonSerializerOptions => new()
        {
            Converters = { new JsonStringEnumConverter() },
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        protected override async Task<PaymentLinksEmptyResponse> ParseHttpResponse(HttpResponseMessage hrm, (Guid paymentLinkID, SendPaymentLinkRequestBody sendPaymentLinkRequestBody) _) =>
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