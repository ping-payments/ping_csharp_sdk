using PingPayments.PaymentsApi.PaymentConsents.Create.V1.Request;
using PingPayments.PaymentsApi.PaymentConsents.Create.V1.Response;
using PingPayments.Shared;
using PingPayments.Shared.Enums;
using PingPayments.Shared.Helpers;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.PaymentConsents.Create.V1
{
    public class CreatePaymentConsentOperation : OperationBase<CreatePaymentConsentRequest, CreatePaymentConsentResponse>
    {
        public CreatePaymentConsentOperation(HttpClient httpClient) : base(httpClient) { }

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

        public override async Task<CreatePaymentConsentResponse> ExecuteRequest(CreatePaymentConsentRequest request) =>
            await BaseExecute
            (
                POST,
                "api/v1/payment_consents",
                request,
                await ToJson(request)
            );

        protected internal static async Task<ProviderMethodResponseBody?> GetResponseBody(ProviderEnum provider, MethodEnum method, string raw, JsonSerializerOptions jsonOpts) =>
            (provider, method) switch
            {
                (ProviderEnum.swish, MethodEnum.recurring) => await Deserialize<SwishRecurringConsentResponseBody>(raw, jsonOpts),
                (ProviderEnum.bankgirot, MethodEnum.autogiro) => await Deserialize<BankgirotAutogiroConsentResponseBody>(raw, jsonOpts),
                _ => null
            };

        protected override async Task<CreatePaymentConsentResponse> ParseHttpResponse(HttpResponseMessage hrm, CreatePaymentConsentRequest request)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var parsedResponse = hrm.StatusCode switch
            {
                OK or Created => await GetSuccessful(),
                _ => await GetFailure()
            };
            return parsedResponse;

            async Task<CreatePaymentConsentResponse> GetSuccessful()
            {
                var body = await GetResponseBody(request.Provider, request.Method, responseBody, JsonSerializerOptions);
                return CreatePaymentConsentResponse.Successful(hrm.StatusCode, body, responseBody);
            }

            async Task<CreatePaymentConsentResponse> GetFailure()
            {
                var errorBody = await Deserialize<ErrorResponseBody>(responseBody);
                return CreatePaymentConsentResponse.Failure(hrm.StatusCode, errorBody, responseBody);
            }
        }
    }
}
