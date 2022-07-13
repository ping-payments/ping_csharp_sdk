using PingPayments.Shared.Helpers;
using PingPayments.PaymentsApi.Shared;
using PingPayments.PaymentsApi.Payments.Shared.V1;
using PingPayments.PaymentsApi.Payments.V1.Initiate.Request;
using PingPayments.PaymentsApi.Payments.V1.Initiate.Response;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Runtime.CompilerServices;
using static System.Net.HttpStatusCode;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
[assembly: InternalsVisibleTo("PingPayments.PaymentsApi.Tests")]

namespace PingPayments.PaymentsApi.Payments.Initiate.V1
{
    public class InitiateOperation : OperationBase<(Guid orderId, InitiatePaymentRequest initiatePaymentRequest), InitiatePaymentResponse>
    {
        public InitiateOperation(HttpClient httpClient) : base(httpClient) { }

        protected override JsonSerializerOptions JsonSerializerOptions => new()
        {
            Converters = 
            {
                new MethodEnumJsonConvert(),
                new JsonStringEnumConverter(),
                new ProviderMethodParametersJsonConvert(),
            }
        };

        public override async Task<InitiatePaymentResponse> ExecuteRequest((Guid orderId, InitiatePaymentRequest initiatePaymentRequest) request) =>
            await BaseExecute
            (
                POST,
                $"api/v1/payment_orders/{request.orderId}/payments",
                request,
                await ToJson(request.initiatePaymentRequest)
            );

        protected internal static async Task<ProviderMethodResponseBody?> GetResponseBody(ProviderEnum provider, MethodEnum method, string raw, JsonSerializerOptions jsonOpts) =>
            (provider, method) switch
            {
                (ProviderEnum.swish, MethodEnum.e_commerce) => await Deserialize<SwishECommerceResponseBody>(raw, jsonOpts),
                (ProviderEnum.swish, MethodEnum.m_commerce) => await Deserialize<SwishMCommerceResponseBody>(raw, jsonOpts),
                (ProviderEnum.billmate, MethodEnum.invoice) => await Deserialize<BillmateResponseBody>(raw, jsonOpts),
                (ProviderEnum.verifone, MethodEnum.card) => await Deserialize<VerifoneResponseBody>(raw, jsonOpts),
                (ProviderEnum.payment_iq, MethodEnum.vipps) => await Deserialize<PaymentIqResponseBody>(raw, jsonOpts),
                (ProviderEnum.payment_iq, MethodEnum.card) => await Deserialize<PaymentIqResponseBody>(raw, jsonOpts), 
                (ProviderEnum.dummy, MethodEnum.dummy) => await Deserialize<DummyResponseBody>(raw, jsonOpts),
                (ProviderEnum.ping, MethodEnum.deposit) => await Deserialize<PingDepositResponseBody>(raw, jsonOpts),
                _ => throw new NotImplementedException(),
            };

        protected override async Task<InitiatePaymentResponse> ParseHttpResponse(HttpResponseMessage hrm, (Guid orderId, InitiatePaymentRequest initiatePaymentRequest) request)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var parsedResponse = hrm.StatusCode switch
            {
                OK => await GetSuccesful(),
                _ => await GetFailure()
            };
            return parsedResponse;

            async Task<InitiatePaymentResponse> GetSuccesful()
            {
                var body = await GetResponseBody(request.initiatePaymentRequest.Provider, request.initiatePaymentRequest.Method, responseBody, JsonSerializerOptions);
                var response = InitiatePaymentResponse.Succesful(hrm.StatusCode, body, responseBody);
                return response;
            }

            async Task<InitiatePaymentResponse> GetFailure()
            {
                var errorBody = await Deserialize<ErrorResponseBody>(responseBody);
                var response = InitiatePaymentResponse.Failure(hrm.StatusCode, errorBody, responseBody);
                return response;
            }
        }
    }
}
