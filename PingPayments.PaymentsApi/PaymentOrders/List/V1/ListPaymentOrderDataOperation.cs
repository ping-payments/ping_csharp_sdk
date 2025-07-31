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
    public class ListPaymentOrderDataOperation : OperationBase<(DateTimeOffset? from, DateTimeOffset? to, PaymentOrderStatusEnum? status)?, PaymentOrdersDataResponse>
    {
        public ListPaymentOrderDataOperation(HttpClient httpClient) : base(httpClient) { }

        protected override JsonSerializerOptions JsonSerializerOptions => new()
        {
            Converters =
            {
                new MethodEnumJsonConvert(),
                new JsonStringEnumConverter(),
            }
        };

        public override async Task<PaymentOrdersDataResponse> ExecuteRequest((DateTimeOffset? from, DateTimeOffset? to, PaymentOrderStatusEnum? status)? request) =>
            await GetPaginatedListAsync<PaymentOrder, PaymentOrdersDataResponse>(
                request.HasValue
                ? ($"api/v1/payment_orders?"
                    + (request.Value.from.HasValue ? $"created_at_from={WebUtility.UrlEncode(request.Value.from.Value.ToString("o"))}&" : string.Empty)
                    + (request.Value.to.HasValue ? $"created_at_to={WebUtility.UrlEncode(request.Value.to.Value.ToString("o"))}&" : string.Empty)
                    + (request.Value.status.HasValue ? $"status={request.Value.status.Value}" : string.Empty))
                : $"api/v1/payment_orders",
                (isSuccess, statusCode, data, rawBody, error) =>
                    isSuccess
                        ? PaymentOrdersDataResponse.Successful(statusCode, data.ToArray(), rawBody)
                        : PaymentOrdersDataResponse.Failure(statusCode, error, rawBody)
            );

        protected override Task<PaymentOrdersDataResponse> ParseHttpResponse(HttpResponseMessage hrm, (DateTimeOffset? from, DateTimeOffset? to, PaymentOrderStatusEnum? status)? _)
        {
            throw new NotImplementedException("This method should not be called directly. Use ExecuteRequest instead.");
        }

    }

}