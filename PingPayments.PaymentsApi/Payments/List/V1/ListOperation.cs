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
    public class ListOperation: OperationBase<(DateTimeOffset? from, DateTimeOffset? to, PaymentStatusEnum? status, MethodEnum? method, ProviderEnum? provider, Guid? paymentOrderId, bool? refundRequested, int? limit)?, PaymentsResponse>
    {
        public ListOperation(HttpClient httpClient) : base(httpClient) { }

        protected override JsonSerializerOptions JsonSerializerOptions => new()
        {
            Converters =
            {
                new MethodEnumJsonConvert(),
                new JsonStringEnumConverter(),
            }
        };

        public override async Task<PaymentsResponse> ExecuteRequest((DateTimeOffset? from, DateTimeOffset? to, PaymentStatusEnum? status, MethodEnum? method, ProviderEnum? provider, Guid? paymentOrderId, bool? refundRequested, int? limit)? filter) =>
            await BaseExecute
            (
                GET,
                filter.HasValue ?
                    ($"api/v1/payment_orders?"
                    + (filter.Value.from.HasValue ? $"from_initiated_date_time={WebUtility.UrlEncode(filter.Value.from.Value.ToString("o"))}&" : string.Empty)
                    + (filter.Value.to.HasValue ? $"to_initiated_date_time={WebUtility.UrlEncode(filter.Value.to.Value.ToString("o"))}&" : string.Empty)
                    + (filter.Value.status.HasValue ? $"status={filter.Value.status.Value}&" : string.Empty)
                    + (filter.Value.method.HasValue ? $"method={filter.Value.method.Value}&" : string.Empty)
                    + (filter.Value.provider.HasValue ? $"provider={filter.Value.provider.Value}&" : string.Empty)
                    + (filter.Value.paymentOrderId.HasValue ? $"payment_order_id={filter.Value.paymentOrderId.Value}&" : string.Empty)
                    + (filter.Value.refundRequested.HasValue ? $"is_refund_requested={filter.Value.refundRequested.Value}&" : string.Empty)
                    + (filter.Value.limit.HasValue ? $"limit={filter.Value.limit.Value}" : string.Empty))
                :
                    $"api/v1/payment_orders",
                filter
            );

        public async Task<PaymentsResponse> ExecuteRequest(PaginationLinkHref href, (DateTimeOffset? from, DateTimeOffset? to, PaymentStatusEnum? status, MethodEnum? method, ProviderEnum? provider, Guid? paymentOrderId, bool? refundRequested, int? limit)? filter) =>
            await BaseExecute
            (
                GET,
                href.Href,
                filter
            );

        protected override async Task<PaymentsResponse> ParseHttpResponse(HttpResponseMessage hrm, (DateTimeOffset? from, DateTimeOffset? to, PaymentStatusEnum? status, MethodEnum? method, ProviderEnum? provider, Guid? paymentOrderId, bool? refundRequested, int? limit)? filter)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => await GetSuccessful(),
                _ => PaymentsResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;

            async Task<PaymentsResponse> GetSuccessful()
            {
                var genericResponseObject = await Deserialize<GenericTransfer<PaymentResponseBody>>(responseBody);
                PaymentResponseBody[] objectArray = genericResponseObject?.Data ?? Array.Empty<PaymentResponseBody>();
                if (genericResponseObject?.PaginationLinks.Next?.Href != null)
                {
                    var recursiveResponse = await ExecuteRequest(genericResponseObject!.PaginationLinks.Next!, filter);
                    if (recursiveResponse.IsSuccessful)
                    {
                        int oldLen = objectArray.Length;
                        Array.Resize<PaymentResponseBody>(ref objectArray, oldLen + (recursiveResponse.Body?.SuccessfulResponseBody?.Length ?? 0));
                        Array.Copy(recursiveResponse.Body?.SuccessfulResponseBody ?? Array.Empty<PaymentResponseBody>(), 0, objectArray, oldLen, recursiveResponse.Body?.SuccessfulResponseBody?.Length ?? 0);
                    }
                    else
                    {
                        return PaymentsResponse.Failure(recursiveResponse.StatusCode, recursiveResponse.Body?.ErrorResponseBody, responseBody);
                    }
                }
                return PaymentsResponse.Successful(hrm.StatusCode, objectArray, responseBody);
            }
        }

    }
}
