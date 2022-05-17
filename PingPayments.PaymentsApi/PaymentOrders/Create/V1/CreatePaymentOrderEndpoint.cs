using PingPayments.PaymentsApi.Helpers;
using PingPayments.PaymentsApi.Shared;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.PaymentsApi.Shared.RequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.PaymentOrders.Create.V1
{
    public class CreatePaymentOrderEndpoint : EndpointBase<CreatePaymentOrderRequest, GuidResponse>
    {
        public CreatePaymentOrderEndpoint(HttpClient httpClient) : base(httpClient) { }

        public override async Task<GuidResponse> ExecuteRequest(CreatePaymentOrderRequest createPaymentOrderRequest) => 
            await BaseExecute
            (
                POST,
                $"api/v1/payment_orders",
                createPaymentOrderRequest,
                await ToJson(createPaymentOrderRequest)
            );

        protected override async Task<GuidResponse> ParseHttpResponse(HttpResponseMessage hrm, CreatePaymentOrderRequest _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => GuidResponse.Succesful(hrm.StatusCode, await Deserialize<GuidResponseBody>(responseBody), responseBody),
                _ => GuidResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;
        }
    }
}