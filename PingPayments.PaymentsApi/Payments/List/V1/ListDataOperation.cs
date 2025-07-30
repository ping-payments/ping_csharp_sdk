using PingPayments.PaymentsApi.PaymentOrders.List.V1;
using PingPayments.PaymentsApi.PaymentOrders.Shared.V1;
using PingPayments.PaymentsApi.Payments.Get.V1;
using PingPayments.Shared;
using PingPayments.Shared.Enums;
using PingPayments.Shared.Helpers;
using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.Payments.List.V1
{
    public class ListDataOperation: OperationBase<(DateTimeOffset? from, DateTimeOffset? to, PaymentStatusEnum? status, MethodEnum? method, ProviderEnum? provider, Guid? paymentOrderId, bool? refundRequested)?, PaymentsDataResponse>
    {
        public ListDataOperation(HttpClient httpClient) : base(httpClient) { }

        protected override JsonSerializerOptions JsonSerializerOptions => new()
        {
            Converters =
            {
                new MethodEnumJsonConvert(),
                new JsonStringEnumConverter(),
            }
        };

        public override async Task<PaymentsDataResponse> ExecuteRequest((DateTimeOffset? from, DateTimeOffset? to, PaymentStatusEnum? status, MethodEnum? method, ProviderEnum? provider, Guid? paymentOrderId, bool? refundRequested)? request) =>
            await GetPaginatedListAsync<PaymentResponseBody, PaymentsDataResponse>(
                request.HasValue ?
                    ($"api/v1/payment_orders?"
                    + (request.Value.from.HasValue ? $"from_initiated_date_time={WebUtility.UrlEncode(request.Value.from.Value.ToString("o"))}&" : string.Empty)
                    + (request.Value.to.HasValue ? $"to_initiated_date_time={WebUtility.UrlEncode(request.Value.to.Value.ToString("o"))}&" : string.Empty)
                    + (request.Value.status.HasValue ? $"status={request.Value.status.Value}&" : string.Empty)
                    + (request.Value.method.HasValue ? $"method={request.Value.method.Value}&" : string.Empty)
                    + (request.Value.provider.HasValue ? $"provider={request.Value.provider.Value}&" : string.Empty)
                    + (request.Value.paymentOrderId.HasValue ? $"payment_order_id={request.Value.paymentOrderId.Value}&" : string.Empty)
                    + (request.Value.refundRequested.HasValue ? $"is_refund_requested={request.Value.refundRequested.Value}" : string.Empty))
                :
                    $"api/v1/payment_orders",
                (isSuccess, statusCode, data, rawBody, error) =>
                    isSuccess
                        ? PaymentsDataResponse.Successful(statusCode, data.ToArray(), rawBody)
                        : PaymentsDataResponse.Failure(statusCode, error, rawBody)
            );

        protected override async Task<PaymentsDataResponse> ParseHttpResponse(HttpResponseMessage hrm, (DateTimeOffset? from, DateTimeOffset? to, PaymentStatusEnum? status, MethodEnum? method, ProviderEnum? provider, Guid? paymentOrderId, bool? refundRequested)? _)
        {
            throw new NotImplementedException("This method should not be called directly. Use ExecuteRequest instead.");
        }

    }
}
