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
    public class ListDataOperation : OperationBase<(DateTimeOffset? from, DateTimeOffset? to, PaymentStatusEnum? status, MethodEnum? method, ProviderEnum? provider, Guid? paymentOrderId, bool? refundRequested), PaymentsDataResponse>
    {
        public const int limit = 200;

        public ListDataOperation(HttpClient httpClient) : base(httpClient) { }

        protected override JsonSerializerOptions JsonSerializerOptions => new()
        {
            Converters =
            {
                new MethodEnumJsonConvert(),
                new JsonStringEnumConverter(),
            }
        };

        public override async Task<PaymentsDataResponse> ExecuteRequest((DateTimeOffset? from, DateTimeOffset? to, PaymentStatusEnum? status, MethodEnum? method, ProviderEnum? provider, Guid? paymentOrderId, bool? refundRequested) request) =>
            await GetPaginatedListAsync<Payment, PaymentsDataResponse>($"api/v1/payments?limit=" + limit +
                     (request.from.HasValue ? $"&from_initiated_date_time={WebUtility.UrlEncode(request.from.Value.ToString("o"))}" : string.Empty) +
                     (request.to.HasValue ? $"&to_initiated_date_time={WebUtility.UrlEncode(request.to.Value.ToString("o"))}" : string.Empty) +
                     (request.status.HasValue ? $"&status={request.status.Value}" : string.Empty) +
                     (request.method.HasValue ? $"&method={request.method.Value}" : string.Empty) +
                     (request.provider.HasValue ? $"&provider={request.provider.Value}" : string.Empty) +
                     (request.paymentOrderId.HasValue ? $"&payment_order_id={request.paymentOrderId.Value}" : string.Empty) +
                     (request.refundRequested.HasValue ? $"&is_refund_requested={request.refundRequested.Value}" : string.Empty),
                (isSuccess, statusCode, data, rawBody, error) =>
                    isSuccess
                        ? PaymentsDataResponse.Successful(statusCode, data.ToArray(), rawBody)
                        : PaymentsDataResponse.Failure(statusCode, error, rawBody)
            );

        protected override async Task<PaymentsDataResponse> ParseHttpResponse(HttpResponseMessage hrm, (DateTimeOffset? from, DateTimeOffset? to, PaymentStatusEnum? status, MethodEnum? method, ProviderEnum? provider, Guid? paymentOrderId, bool? refundRequested) _)
        {
            throw new NotImplementedException("This method should not be called directly. Use ExecuteRequest instead.");
        }

    }
}
