using PingPayments.Shared;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.PaymentOrders.Update.V1
{
    public class UpdatePaymentOrderOperation : OperationBase<(Guid OrderId, UpdatePaymentOrderRequest updatePaymentOrderRequest), EmptyResponse>
    {
        public UpdatePaymentOrderOperation(HttpClient httpClient) : base(httpClient) { }

        public override async Task<EmptyResponse> ExecuteRequest((Guid OrderId, UpdatePaymentOrderRequest updatePaymentOrderRequest) request) =>
            await BaseExecute
            (
                PUT,
                $"api/v1/payment_orders/{request.OrderId}",
                request,
                await ToJson(request.updatePaymentOrderRequest)
            );
        protected override JsonSerializerOptions JsonSerializerOptions => new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        protected override async Task<EmptyResponse> ParseHttpResponse(HttpResponseMessage hrm, (Guid OrderId, UpdatePaymentOrderRequest updatePaymentOrderRequest) _) =>
            hrm.StatusCode switch
            {
                NoContent => EmptyResponse.Successful(hrm.StatusCode),
                _ => await ToEmptyError(hrm)
            };
    }
}