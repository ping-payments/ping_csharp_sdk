using PingPayments.PaymentLinksApi.Helpers;
using PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1;
using PingPayments.PaymentLinksApi.PaymentLinks.V1.Create.Request;
using PingPayments.PaymentLinksApi.Shared;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static PingPayments.PaymentLinksApi.Shared.RequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentLinksApi.PaymentLinks.Get.V1
{
    public class GetPaymentLinkOperation : OperationBase<Guid, PaymentLinkResponse>
    {
        public GetPaymentLinkOperation(HttpClient httpClient) : base(httpClient) { }

        protected override JsonSerializerOptions JsonSerializerOptions => new()
        {
            Converters =
            {
                new MethodEnumJsonConvert(),
                new JsonStringEnumConverter(),
            }
        };

        public override async Task<PaymentLinkResponse> ExecuteRequest(Guid paymentLinkId) =>
            await BaseExecute(GET, $"api/v1/payment_links/{paymentLinkId}", paymentLinkId);

        protected override async Task<PaymentLinkResponse> ParseHttpResponse(HttpResponseMessage hrm, Guid _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => PaymentLinkResponse.Succesful(hrm.StatusCode, await Deserialize<BasePaymentLinks>(responseBody), responseBody),
                _ => await ToError(hrm)
            };
            return response;
        }

        protected async Task<PaymentLinkResponse> ToError(HttpResponseMessage hrm) =>
            PaymentLinkResponse.Failure
            (
                hrm.StatusCode,
                await Deserialize<ErrorResponseBody>(await hrm.Content.ReadAsStringAsyncMemoized()),
                await hrm.Content.ReadAsStringAsyncMemoized()
            );
    }
}