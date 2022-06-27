using PingPayments.PaymentLinksApi.Shared;
using static PingPayments.PaymentLinksApi.Shared.RequestTypeEnum;
using static System.Net.HttpStatusCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1;
using PingPayments.PaymentLinksApi.Helpers;

namespace PingPayments.PaymentLinksApi.PaymentLinks.List.V1
{
    public class ListPaymentLinksOperation : OperationBase<EmptyRequest, PaymentLinksResponse>
    {
        public ListPaymentLinksOperation(HttpClient httpClient) : base(httpClient)
        {
        }

        public override async Task<PaymentLinksResponse> ExecuteRequest(EmptyRequest? emptyRequest = null)
        {
            var request = await BaseExecute(GET, $"api/v1/payment_links", emptyRequest);
            return request; 
        }

        protected override async Task<PaymentLinksResponse> ParseHttpResponse(HttpResponseMessage hrm, EmptyRequest? _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => PaymentLinksResponse.Succesful(hrm.StatusCode, new PaymentLinkList(await Deserialize<BasePaymentLinks[]>(responseBody)), responseBody),
                _ => PaymentLinksResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;
        }
    }
}
