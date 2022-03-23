using PaymentsApiSdk.Shared;
using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PaymentsApiSdk.PaymentOrders.Update
{
    public class UpdatePaymentOrderEndpoint : TenantEndpointBase<(Guid OrderId, Guid SplitTreeId), EmptyResponse>
    {
        public UpdatePaymentOrderEndpoint(HttpClient httpClient, Guid tenantId) : base(httpClient, tenantId) { }

        protected override JsonSerializerOptions JsonSerializerOptions => new() { Converters = { new JsonStringEnumConverter() } };

        public override async Task<EmptyResponse> Action((Guid OrderId, Guid SplitTreeId) updateRequest) => 
            await Execute
            (
                $"api/v1/payment_orders/{updateRequest.OrderId}", 
                RequestTypeEnum.PUT,
                ToJson(new { split_tree_id = updateRequest.SplitTreeId })
            );

        protected override async Task<EmptyResponse> HttpResponseToResponse(HttpResponseMessage hrm) => hrm.StatusCode switch
        {
            HttpStatusCode.NoContent =>
                EmptyResponse.Empty
                (
                    (int)hrm.StatusCode,
                    true
                ),
            _ =>
                new EmptyResponse
                (
                    (int)hrm.StatusCode,
                    false,
                    Deserialize<ErrorResponseBody>(await hrm.Content.ReadAsStringAsync())
                )
        };
    }
}