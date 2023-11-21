using PingPayments.Mimic.Autogiro.Update.Payment.V1;
using PingPayments.Shared;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.Mimic.Autogiro.Update.Mandate.V1
{
    public class UpdatePaymentOperation : OperationBase<UpdatePaymentRequest, EmptyResponse>
    {
        public UpdatePaymentOperation(HttpClient httpClient) : base(httpClient) { }
        public override async Task<EmptyResponse> ExecuteRequest(UpdatePaymentRequest updatePaymentRequest) =>
            await BaseExecute
            (
                PUT,
                $"api/autogiro/payment",
                updatePaymentRequest,
                await ToJson(updatePaymentRequest)
            );

        protected override async Task<EmptyResponse> ParseHttpResponse(HttpResponseMessage hrm, UpdatePaymentRequest _) =>
        hrm.StatusCode switch
        {
            NoContent => EmptyResponse.Successful(hrm.StatusCode),
            _ => await ToEmptyError(hrm)
        };
    }
}
