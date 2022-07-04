using PingPayments.PaymentLinksApi.PaymentLinks.Create.V1.Request;
using PingPayments.PaymentLinksApi.Shared;
using static PingPayments.PaymentLinksApi.Shared.RequestTypeEnum; 
using System.Text.Json;
using PingPayments.PaymentLinksApi.Helpers;
using static System.Net.HttpStatusCode;
using PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentLinksApi.PaymentLinks.Create.V1
{
    public class CreatePaymentLinkOperation : OperationBase<CreatePaymentLinkRequest, CreatePaymentLinkResponse>
    {
        public CreatePaymentLinkOperation(HttpClient httpClient) : base(httpClient)
        {
        }

        protected override JsonSerializerOptions JsonSerializerOptions => new()
        {
            Converters =
            {
                new MethodEnumJsonConvert(),
                new JsonStringEnumConverter(),
                new ProviderMethodParametersJsonConvert(),
            },
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        public override async  Task<CreatePaymentLinkResponse> ExecuteRequest(CreatePaymentLinkRequest request) => 
        await BaseExecute
            (
                POST,
                $"api/v1/payment_links",
                request,
                await ToJson(request)
            );

        protected override async Task<CreatePaymentLinkResponse> ParseHttpResponse(HttpResponseMessage hrm, CreatePaymentLinkRequest request)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => CreatePaymentLinkResponse.Succesful(hrm.StatusCode, await Deserialize<CreatePaymentLinkResponseBody>(responseBody), responseBody),
                _ => CreatePaymentLinkResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;
        }
    }
}
