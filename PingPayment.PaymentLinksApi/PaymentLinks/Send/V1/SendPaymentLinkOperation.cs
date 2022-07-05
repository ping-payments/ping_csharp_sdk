using PingPayments.PaymentLinksApi.Helpers;
using PingPayments.PaymentLinksApi.PaymentLinks.Send.V1.Requests;
using PingPayments.PaymentLinksApi.Shared;
using System.Text.Json;
using System.Text.Json.Serialization;
using static PingPayments.PaymentLinksApi.Shared.RequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentLinksApi.PaymentLinks.Send.V1
{
    public class SendPaymentLinkOperation : OperationBase<(Guid paymentLinkID, SendPaymentLinkRequestBody sendPaymentLinkRequestBody), EmptyResponse>
    {
        public SendPaymentLinkOperation(HttpClient httpClient) : base(httpClient) { }

        public override async Task<EmptyResponse> ExecuteRequest((Guid paymentLinkID, SendPaymentLinkRequestBody sendPaymentLinkRequestBody) request) =>
            await BaseExecute
            (
                PUT,
                $"api/v1/payment_links/{request.paymentLinkID}/distribute", 
                request,
                await ToJson(request.sendPaymentLinkRequestBody)
            );

        protected override JsonSerializerOptions JsonSerializerOptions => new()
        {
            Converters = {  new JsonStringEnumConverter()   },
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        protected override async Task<EmptyResponse> ParseHttpResponse(HttpResponseMessage hrm, (Guid paymentLinkID, SendPaymentLinkRequestBody sendPaymentLinkRequestBody) _) =>
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