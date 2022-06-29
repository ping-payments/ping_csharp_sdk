using PingPayments.PaymentLinksApi.PaymentLinks.Create.V1.Request;
using PingPayments.PaymentLinksApi.Shared;
using static PingPayments.PaymentLinksApi.Shared.RequestTypeEnum; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using PingPayments.PaymentLinksApi.Helpers;
using static System.Net.HttpStatusCode;
using PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1;

namespace PingPayments.PaymentLinksApi.PaymentLinks.Create.V1
{
    public class CreatePaymentLinkOperation : OperationBase<CreatePaymentLinkRequest, CreatePaymentLinkResponse>
    {
        public CreatePaymentLinkOperation(HttpClient httpClient) : base(httpClient)
        {
        }

        public override async  Task<CreatePaymentLinkResponse> ExecuteRequest(CreatePaymentLinkRequest request) => 
        await BaseExecute
            (
                POST,
                $"api/v1/payment_links",
                request,
                await ToJson(request)
            );

        protected override async Task<CreatePaymentLinkResponse> ParseHttpResponse(HttpResponseMessage hrm, CreatePaymentLinkRequest request)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => CreatePaymentLinkResponse.Succesful(hrm.StatusCode, await Deserialize<CreatePaymentLinkResponseBody>(responseBody), responseBody),
                _ => CreatePaymentLinkResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;
        }
    }
}
