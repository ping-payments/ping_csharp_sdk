using PingPayments.PaymentsApi.PaymentOrders.Shared.V1;
using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;


namespace PingPayments.PaymentsApi.PaymentOrders.List.V1
{
    public class ListPaymentOrderOperation : OperationBase<(DateTimeOffset? from, DateTimeOffset? to, PaymentOrderStatusEnum? status, int? limit)?, PaymentOrdersResponse>
    {
        public ListPaymentOrderOperation(HttpClient httpClient) : base(httpClient) { }

        protected override JsonSerializerOptions JsonSerializerOptions => new()
        {
            Converters =
            {
                new MethodEnumJsonConvert(),
                new JsonStringEnumConverter(),
            }
        };

        public override async Task<PaymentOrdersResponse> ExecuteRequest((DateTimeOffset? from, DateTimeOffset? to, PaymentOrderStatusEnum? status, int? limit)? filter) =>
            await BaseExecute
            (
                GET,
                filter.HasValue ?
                    ($"api/v1/payment_orders?"
                    + (filter.Value.from.HasValue ? $"created_at_from={WebUtility.UrlEncode(filter.Value.from.Value.ToString("o"))}&" : string.Empty)
                    + (filter.Value.to.HasValue ? $"created_at_to={WebUtility.UrlEncode(filter.Value.to.Value.ToString("o"))}&" : string.Empty)
                    + (filter.Value.status.HasValue ? $"status={filter.Value.status.Value}&" : string.Empty)
                    + (filter.Value.limit.HasValue ? $"limit={filter.Value.limit.Value}" : string.Empty))
                :
                    $"api/v1/payment_orders",
                filter
            );

        public async Task<PaymentOrdersResponse> ExecuteRequest(PaginationLinkHref href, (DateTimeOffset? from, DateTimeOffset? to, PaymentOrderStatusEnum? status, int? limit)? filter) =>
            await BaseExecute
            (
                GET,
                href.Href,
                filter
            );

        protected override async Task<PaymentOrdersResponse> ParseHttpResponse(HttpResponseMessage hrm, (DateTimeOffset? from, DateTimeOffset? to, PaymentOrderStatusEnum? status, int? limit)? filter)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => await GetSuccessful(),
                _ => PaymentOrdersResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;

            async Task<PaymentOrdersResponse> GetSuccessful()
            {
                var genericResponseObject = await Deserialize<GenericTransfer<PaymentOrder>>(responseBody);
                PaymentOrder[] objectArray = genericResponseObject?.Data ?? Array.Empty<PaymentOrder>();
                if (genericResponseObject?.PaginationLinks.Next?.Href != null)
                {
                    var recursiveResponse = await ExecuteRequest(genericResponseObject!.PaginationLinks.Next!, filter);
                    if (recursiveResponse.IsSuccessful)
                    {
                        int oldLen = objectArray.Length;
                        Array.Resize<PaymentOrder>(ref objectArray, oldLen + (recursiveResponse.Body?.SuccessfulResponseBody?.Length ?? 0));
                        Array.Copy(recursiveResponse.Body?.SuccessfulResponseBody ?? Array.Empty<PaymentOrder>(), 0, objectArray, oldLen, recursiveResponse.Body?.SuccessfulResponseBody?.Length ?? 0);
                    }
                    else
                    {
                        return PaymentOrdersResponse.Failure(recursiveResponse.StatusCode, recursiveResponse.Body?.ErrorResponseBody, responseBody);
                    }
                }
                return PaymentOrdersResponse.Successful(hrm.StatusCode, objectArray, responseBody);
            }
        }
    }

}