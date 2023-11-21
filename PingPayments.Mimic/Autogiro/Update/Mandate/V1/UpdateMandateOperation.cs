using PingPayments.Shared;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.Mimic.Autogiro.Update.Mandate.V1
{
    public class UpdateMandateOperation : OperationBase<UpdateMandateRequest, EmptyResponse>
    {
        public UpdateMandateOperation(HttpClient httpClient) : base(httpClient) { }
        public override async Task<EmptyResponse> ExecuteRequest(UpdateMandateRequest updateMandateRequest) =>
            await BaseExecute
            (
                PUT,
                $"api/autogiro/mandate",
                updateMandateRequest,
                await ToJson(updateMandateRequest)
            );
        protected override JsonSerializerOptions JsonSerializerOptions => new()
        {
            Converters = { new JsonStringEnumConverter() },
        };

        protected override async Task<EmptyResponse> ParseHttpResponse(HttpResponseMessage hrm, UpdateMandateRequest _) =>
        hrm.StatusCode switch
        {
            NoContent => EmptyResponse.Successful(hrm.StatusCode),
            _ => await ToEmptyError(hrm)
        };
    }
}
