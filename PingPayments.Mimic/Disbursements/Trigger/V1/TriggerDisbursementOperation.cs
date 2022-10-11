using PingPayments.Shared;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.Mimic.Disbursements.Trigger.V1
{
    public class TriggerDisbursementOperation : OperationBase<Guid[], TriggerDisbursementResponse>
    {
        public TriggerDisbursementOperation(HttpClient httpClient) : base(httpClient) { }

        public override async Task<TriggerDisbursementResponse> ExecuteRequest(Guid[] PaymentOrderIdList) =>
            await BaseExecute
            (
                POST,
                "api/disbursements",
                PaymentOrderIdList,
                await ToJson(new { payment_orders = PaymentOrderIdList })
            );

        protected override async Task<TriggerDisbursementResponse> ParseHttpResponse(HttpResponseMessage hrm, Guid[] _)
        {
            var rawBody = await hrm.Content.ReadAsStringAsync();
            var response = hrm.StatusCode switch
            {
                OK => TriggerDisbursementResponse.Successful(hrm.StatusCode, await Deserialize<TriggerDisbursementResponseBody>(rawBody), rawBody),
                _ => TriggerDisbursementResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(rawBody), rawBody)
            };

            return response;
        }
    }
}
