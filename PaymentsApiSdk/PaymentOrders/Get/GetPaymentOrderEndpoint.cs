using PaymentsApiSdk.Shared;
using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PaymentsApiSdk.PaymentOrders.Get
{
    public class GetPaymentOrderEndpoint : TenantEndpointBase<Guid, PaymentOrderResponse>
    {
        public GetPaymentOrderEndpoint(HttpClient httpClient, Guid tenantId) : base(httpClient, tenantId) { }

        protected override JsonSerializerOptions JsonSerializerOptions => new() { Converters = { new JsonStringEnumConverter() } };

        public override async Task<PaymentOrderResponse> Action(Guid orderId) => 
            await Execute($"api/v1/payment_orders/{orderId}", RequestTypeEnum.GET);

        protected override async Task<PaymentOrderResponse> HttpResponseToResponse(HttpResponseMessage hrm)
        {
            var responseBody = await hrm.Content.ReadAsStringAsync();
            return hrm.StatusCode switch
            {
                HttpStatusCode.OK =>
                    new PaymentOrderResponse
                    (
                        (int)hrm.StatusCode,
                        true,
                        Deserialize<PaymentOrderResponseBody>(responseBody)
                    ),
                _ =>
                    new PaymentOrderResponse
                    (
                        (int)hrm.StatusCode,
                        false,
                        Deserialize<ErrorResponseBody>(responseBody)
                    )
            };
        }
    }
}