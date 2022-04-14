using PingPayments.PaymentsApi.Helpers;
using PingPayments.PaymentsApi.Payments.Shared.V1;
using PingPayments.PaymentsApi.Payments.V1.Initiate.Request;
using PingPayments.PaymentsApi.Payments.V1.Initiate.Response;
using PingPayments.PaymentsApi.Shared;
using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static PingPayments.PaymentsApi.Shared.RequestTypeEnum;
using static System.Net.HttpStatusCode;
[assembly: InternalsVisibleTo("PingPayments.PaymentsApi.Tests")]

namespace PingPayments.PaymentsApi.Payments.Initiate.V1
{
    public class InitiateEndpoint : TenantEndpointBase<(Guid orderId, InitiatePaymentRequest initiatePaymentRequest), InitiatePaymentResponse>
    {
        public InitiateEndpoint(HttpClient httpClient, Guid tenantId) : base(httpClient, tenantId) { }

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
                (ProviderEnum.swish, MethodEnum.e_commerce) => await Deserialize<SwishECommerceResponse>(raw, jsonOpts),
                (ProviderEnum.swish, MethodEnum.m_commerce) => await Deserialize<SwishMCommerceResponse>(raw, jsonOpts),
                (ProviderEnum.billmate, MethodEnum.invoice) => await Deserialize<BillmateResponse>(raw, jsonOpts),
                (ProviderEnum.verifone, MethodEnum.card) => await Deserialize<VerifoneResponse>(raw, jsonOpts),
                (ProviderEnum.payment_iq, MethodEnum.vipps) => await Deserialize<PaymentIqResponse>(raw, jsonOpts),
                (ProviderEnum.payment_iq, MethodEnum.card) => await Deserialize<PaymentIqResponse>(raw, jsonOpts), 
                (ProviderEnum.dummy, MethodEnum.dummy) => await Deserialize<DummyResponse>(raw, jsonOpts),
                (ProviderEnum.ping, MethodEnum.deposit) => await Deserialize<PingDepositResponse>(raw, jsonOpts),
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
