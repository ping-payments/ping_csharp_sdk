using PingPayments.PaymentsApi.Helpers;
using PingPayments.PaymentsApi.PaymentOrders.Shared.V1;
using PingPayments.PaymentsApi.Payments.V1.Initiate.Request;
using PingPayments.PaymentsApi.Shared;
using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static PingPayments.PaymentsApi.Shared.RequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.PaymentOrders.List.V1
{
    public class ListPaymentOrderEndpoint : EndpointBase<(DateTimeOffset from, DateTimeOffset to)?, PaymentOrdersResponse>
    {
        public ListPaymentOrderEndpoint(HttpClient httpClient) : base(httpClient) { }

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
                OK => await GetSuccesful(),
                _ => PaymentOrdersResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;

            async Task<PaymentOrdersResponse> GetSuccesful()
            {
                var paymentOrders = await Deserialize<PaymentOrder[]?>(responseBody);
                var paymentOrderList = paymentOrders != null ? new PaymentOrderList(paymentOrders) : null;
                var response = PaymentOrdersResponse.Succesful(hrm.StatusCode, paymentOrderList, responseBody);
                return response;
            }
        }
    }
}