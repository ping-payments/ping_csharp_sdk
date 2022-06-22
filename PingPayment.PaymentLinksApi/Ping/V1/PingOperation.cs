using PingPayments.PaymentLinksApi.Shared;
using static PingPayments.PaymentLinksApi.Shared.RequestTypeEnum;
using static System.Net.HttpStatusCode;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PingPayments.PaymentLinksApi.Helpers;

namespace PingPayments.PaymentLinksApi.Ping.V1
{
    public class PingOperation : OperationBase<EmptyRequest, TextResponse>
    {
        public PingOperation(HttpClient httpClient) : base(httpClient)
        {
        }

        public override async Task<TextResponse> ExecuteRequest(EmptyRequest _)
        {
            var response = await BaseExecute(GET, $"api/v1/ping", _);
            return response;
        }

        protected override async Task<TextResponse> ParseHttpResponse(HttpResponseMessage hrm, EmptyRequest request)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => TextResponse.Succesful(hrm.StatusCode, responseBody, responseBody),
                _ => TextResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;
        }
    }
}
