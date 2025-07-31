using PingPayments.PaymentsApi.Merchants.List.V1;
using PingPayments.PaymentsApi.Merchants.Shared.V1;
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
    public class ListPaymentOrderPageOperation : OperationBase<(PaginationLinkHref? href, DateTimeOffset? from, DateTimeOffset? to, PaymentOrderStatusEnum? status, int? limit)?, PaymentOrdersPageResponse>
    {
        public ListPaymentOrderPageOperation(HttpClient httpClient) : base(httpClient) { }

        protected override JsonSerializerOptions JsonSerializerOptions => new()
        {
            Converters =
            {
                new MethodEnumJsonConvert(),
                new JsonStringEnumConverter(),
            }
        };

        public override async Task<PaymentOrdersPageResponse> ExecuteRequest((PaginationLinkHref? href, DateTimeOffset? from, DateTimeOffset? to, PaymentOrderStatusEnum? status, int? limit)? request) =>
            await BaseExecute(
                GET,
                request.HasValue 
                ? ($"api/v1/payment_orders?"
                    + (request.Value.from.HasValue ? $"created_at_from={WebUtility.UrlEncode(request.Value.from.Value.ToString("o"))}&" : string.Empty)
                    + (request.Value.to.HasValue ? $"created_at_to={WebUtility.UrlEncode(request.Value.to.Value.ToString("o"))}&" : string.Empty)
                    + (request.Value.status.HasValue ? $"status={request.Value.status.Value}&" : string.Empty)
                    + (request.Value.limit.HasValue ? $"limit={request.Value.limit.Value}" : string.Empty))
                : $"api/v1/payment_orders",
                request
            );

        protected override async Task<PaymentOrdersPageResponse> ParseHttpResponse(HttpResponseMessage hrm, (PaginationLinkHref? href, DateTimeOffset? from, DateTimeOffset? to, PaymentOrderStatusEnum? status, int? limit)? request)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => PaymentOrdersPageResponse.Successful(hrm.StatusCode, await Deserialize<GenericTransfer<PaymentOrder>>(responseBody), responseBody),
                _ => PaymentOrdersPageResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;
        }
    }

}