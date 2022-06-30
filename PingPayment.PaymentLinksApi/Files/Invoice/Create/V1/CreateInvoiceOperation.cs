using PingPayments.PaymentLinksApi.Helpers;
using PingPayments.PaymentLinksApi.Shared;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.PaymentLinksApi.Shared.RequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentLinksApi.Files.Invoice.Create.V1
{
    public class CreateInvoiceOperation : OperationBase<CreateInvoiceRequest, EmptyResponse>
    {
        public CreateInvoiceOperation(HttpClient httpClient) : base(httpClient) { }

        public override async Task<EmptyResponse> ExecuteRequest(CreateInvoiceRequest createInvoiceRequest) =>
            await BaseExecute
            (
                POST,
                $"api/v1/payment_orders",
                createInvoiceRequest,
                await ToJson(createInvoiceRequest)
            );

        protected override async Task<EmptyResponse> ParseHttpResponse(HttpResponseMessage hrm, CreateInvoiceRequest _) =>
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