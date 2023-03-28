using PingPayments.PaymentLinksApi.Shared;
using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System.Text.Json;
using System.Text.Json.Serialization;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentLinksApi.Files.Invoice.Create.V1
{
    public class CreateInvoiceOperation : OperationBase<(Guid paymentLinkID, CreateInvoiceRequest createInvoiceRequest), PaymentLinksEmptyResponse>
    {
        public CreateInvoiceOperation(HttpClient httpClient) : base(httpClient) { }


        protected override JsonSerializerOptions JsonSerializerOptions => new()
        {
            Converters = { new JsonStringEnumConverter() },
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        public override async Task<PaymentLinksEmptyResponse> ExecuteRequest((Guid paymentLinkID, CreateInvoiceRequest createInvoiceRequest) request) =>
            await BaseExecute
            (
                PUT,
                $"api/v1/payment_links/{request.paymentLinkID}/invoice",
                request,
                await ToJson(request.createInvoiceRequest)
            );

        protected override async Task<PaymentLinksEmptyResponse> ParseHttpResponse(HttpResponseMessage hrm, (Guid paymentLinkID, CreateInvoiceRequest createInvoiceRequest) _) =>
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