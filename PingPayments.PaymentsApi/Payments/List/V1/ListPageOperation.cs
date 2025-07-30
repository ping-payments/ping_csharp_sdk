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
    public class ListPageOperation : OperationBase<(PaginationLinkHref? href, DateTimeOffset? from, DateTimeOffset? to, PaymentStatusEnum? status, MethodEnum? method, ProviderEnum? provider, Guid? paymentOrderId, bool? refundRequested, int? limit)?, PaymentsPageResponse>
    {
        public ListPageOperation(HttpClient httpClient) : base(httpClient) { }

        protected override JsonSerializerOptions JsonSerializerOptions => new()
        {
            Converters =
            {
                new MethodEnumJsonConvert(),
                new JsonStringEnumConverter(),
            }
        };

        public override async Task<PaymentsPageResponse> ExecuteRequest((PaginationLinkHref? href, DateTimeOffset? from, DateTimeOffset? to, PaymentStatusEnum? status, MethodEnum? method, ProviderEnum? provider, Guid? paymentOrderId, bool? refundRequested, int? limit)? request) =>
            await BaseExecute(
                GET,
                request.HasValue ?
                    ($"api/v1/payment_orders?"
                    + (request.Value.from.HasValue ? $"from_initiated_date_time={WebUtility.UrlEncode(request.Value.from.Value.ToString("o"))}&" : string.Empty)
                    + (request.Value.to.HasValue ? $"to_initiated_date_time={WebUtility.UrlEncode(request.Value.to.Value.ToString("o"))}&" : string.Empty)
                    + (request.Value.status.HasValue ? $"status={request.Value.status.Value}&" : string.Empty)
                    + (request.Value.method.HasValue ? $"method={request.Value.method.Value}&" : string.Empty)
                    + (request.Value.provider.HasValue ? $"provider={request.Value.provider.Value}&" : string.Empty)
                    + (request.Value.paymentOrderId.HasValue ? $"payment_order_id={request.Value.paymentOrderId.Value}&" : string.Empty)
                    + (request.Value.refundRequested.HasValue ? $"is_refund_requested={request.Value.refundRequested.Value}&" : string.Empty)
                    + (request.Value.limit.HasValue ? $"limit={request.Value.limit.Value}" : string.Empty))
                :
                    $"api/v1/payment_orders",
                request
            );

        protected override async Task<PaymentsPageResponse> ParseHttpResponse(HttpResponseMessage hrm, (PaginationLinkHref? href, DateTimeOffset? from, DateTimeOffset? to, PaymentStatusEnum? status, MethodEnum? method, ProviderEnum? provider, Guid? paymentOrderId, bool? refundRequested, int? limit)? filter)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => PaymentsPageResponse.Successful(hrm.StatusCode, await Deserialize<GenericTransfer<PaymentResponseBody>>(responseBody), responseBody),
                _ => PaymentsPageResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;
        }

    }
}
