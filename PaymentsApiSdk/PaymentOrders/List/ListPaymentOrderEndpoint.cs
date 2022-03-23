using PaymentsApiSdk.PaymentOrders.Get;
using PaymentsApiSdk.Shared;
using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PaymentsApiSdk.PaymentOrders.List
{
    public class ListPaymentOrderEndpoint : TenantEndpointBase<(DateTimeOffset from, DateTimeOffset to)?, PaymentOrdersResponse>
    {
        public ListPaymentOrderEndpoint(HttpClient httpClient, Guid tenantId) : base(httpClient, tenantId) { }

        protected override JsonSerializerOptions JsonSerializerOptions => new() { Converters = { new JsonStringEnumConverter() } };

        public override async Task<PaymentOrdersResponse> Action((DateTimeOffset from, DateTimeOffset to)? dateFilters) => 
            await Execute
            (
                dateFilters.HasValue ? 
                    $"api/v1/payment_orders?from={dateFilters.Value.from:O}&to={dateFilters.Value.to:O}" : 
                    $"api/v1/payment_orders", 
                RequestTypeEnum.GET
            );

        protected override async Task<PaymentOrdersResponse> HttpResponseToResponse(HttpResponseMessage hrm)
        {
            var responseBody = await hrm.Content.ReadAsStringAsync();
            return hrm.StatusCode switch
            {
                HttpStatusCode.OK =>
                    new PaymentOrdersResponse
                    (
                        (int)hrm.StatusCode,
                        true,
                        new PaymentOrdersResponseBody(Deserialize<PaymentOrderResponseBody[]>(responseBody))
                    ),
                _ =>
                    new PaymentOrdersResponse
                    (
                        (int)hrm.StatusCode,
                        false,
                        Deserialize<ErrorResponseBody>(responseBody)
                    )
            };
        }
    }
}