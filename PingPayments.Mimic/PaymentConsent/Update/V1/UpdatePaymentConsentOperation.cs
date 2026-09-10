using PingPayments.Shared;
using System;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.Mimic.PaymentConsent.Update.V1
{
    public class UpdatePaymentConsentOperation : OperationBase<(Guid consentId, PaymentConsentStatusEnum status), EmptyResponse>
    {
        public UpdatePaymentConsentOperation(HttpClient httpClient) : base(httpClient) { }

        protected override System.Text.Json.JsonSerializerOptions JsonSerializerOptions => new()
        {
            Converters = { new JsonStringEnumConverter() }
        };

        public override async Task<EmptyResponse> ExecuteRequest((Guid consentId, PaymentConsentStatusEnum status) request) =>
            await BaseExecute
            (
                PUT,
                $"api/payment_consents/{request.consentId}",
                request,
                await ToJson(new { status = request.status })
            );

        protected override async Task<EmptyResponse> ParseHttpResponse(HttpResponseMessage hrm, (Guid consentId, PaymentConsentStatusEnum status) _) =>
            hrm.StatusCode switch
            {
                NoContent => EmptyResponse.Successful(hrm.StatusCode),
                _ => await ToEmptyError(hrm)
            };
    }
}
