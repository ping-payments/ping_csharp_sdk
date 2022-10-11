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
    public class ListPaymentOrderOperation : OperationBase<(DateTimeOffset from, DateTimeOffset to)?, PaymentOrdersResponse>
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

        public override async Task<PaymentOrdersResponse> ExecuteRequest((DateTimeOffset from, DateTimeOffset to)? df) =>
            await BaseExecute
            (
                GET,
                df.HasValue ?
                    ($"api/v1/payment_orders?" +
                        $"from={WebUtility.UrlEncode(df.Value.from.ToString("o"))}&" +
                        $"to={WebUtility.UrlEncode(df.Value.to.ToString("o"))}")
                :
                    $"api/v1/payment_orders",
                df
            );

        protected override async Task<PaymentOrdersResponse> ParseHttpResponse(HttpResponseMessage hrm, (DateTimeOffset from, DateTimeOffset to)? _)
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
                var paymentOrders = await Deserialize<PaymentOrder[]?>(responseBody);
                var paymentOrderList = paymentOrders != null ? new PaymentOrderList(paymentOrders) : null;
                var response = PaymentOrdersResponse.Successful(hrm.StatusCode, paymentOrderList, responseBody);
                return response;
            }
        }
    }
}