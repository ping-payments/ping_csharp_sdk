using PingPayments.PaymentsApi.Helpers;
using PingPayments.PaymentsApi.Shared;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.PaymentsApi.Shared.RequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.PaymentOrders.Update.V1
{
    public class UpdatePaymentOrderEndpoint : TenantEndpointBase<(Guid OrderId, Guid SplitTreeId), EmptyResponse>
    {
        public UpdatePaymentOrderEndpoint(HttpClient httpClient, Guid tenantId) : base(httpClient, tenantId) { }

        public override async Task<EmptyResponse> ExecuteRequest((Guid OrderId, Guid SplitTreeId) updateRequest) => 
            await BaseExecute
            (
                PUT,
                $"api/v1/payment_orders/{updateRequest.OrderId}",
                updateRequest,
                await ToJson(new { split_tree_id = updateRequest.SplitTreeId })
            );

        protected override async Task<EmptyResponse> ParseHttpResponse(HttpResponseMessage hrm, (Guid OrderId, Guid SplitTreeId) _) => 
            hrm.StatusCode switch
            {
                NoContent => EmptyResponse.Succesful(hrm.StatusCode),
                _ => await ToEmptyError(hrm)
            };
    }
}