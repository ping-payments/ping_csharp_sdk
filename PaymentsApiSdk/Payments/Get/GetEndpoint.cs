using PingPayments.PaymentsApi.Shared;
using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.Payments.Get
{
    public class GetEndpoint : 
        TenantEndpointBase<(Guid orderId, Guid paymentId), PaymentResponse>
    {
        public GetEndpoint(HttpClient httpClient, Guid tenantId) : base(httpClient, tenantId) { }

        protected override JsonSerializerOptions JsonSerializerOptions => new()
        {
            Converters = { new JsonStringEnumConverter() }
        };

        public override async Task<PaymentResponse> Action((Guid orderId, Guid paymentId) request) =>
            await Execute
            (
                $"api/v1/payment_orders/{request.orderId}/payments/{request.paymentId}",
                RequestTypeEnum.GET
            );

        protected override async Task<PaymentResponse> HttpResponseToResponse(HttpResponseMessage hrm)
        {
            var responseBody = await hrm.Content.ReadAsStringAsync();
            return hrm.StatusCode switch
            {
                HttpStatusCode.OK =>
                    new PaymentResponse
                    (
                        (int)hrm.StatusCode,
                        true,
                        Deserialize<PaymentResponseBody>(responseBody)
                    ),
                _ =>
                    new PaymentResponse
                    (
                        (int)hrm.StatusCode,
                        false,
                        Deserialize<ErrorResponseBody>(responseBody)
                    )
            };
        }
    }
}
