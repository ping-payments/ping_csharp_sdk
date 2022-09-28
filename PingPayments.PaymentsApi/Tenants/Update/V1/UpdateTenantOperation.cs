using PingPayments.Shared;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;


namespace PingPayments.PaymentsApi.Tenants.Update.V1
{
    public class UpdateTenantOperation : OperationBase<UpdateTenantRequest, EmptyResponse>
    {
        public UpdateTenantOperation(HttpClient httpClient) : base(httpClient) { }

        public override async Task<EmptyResponse> ExecuteRequest(UpdateTenantRequest updateTenantRequest) =>
            await BaseExecute
            (
                PUT,
                $"api/v1/tenant",
                updateTenantRequest,
                await ToJson(updateTenantRequest)
            );
        protected override async Task<EmptyResponse> ParseHttpResponse(HttpResponseMessage hrm, UpdateTenantRequest updateTenantRequest) =>
            hrm.StatusCode switch
            {
                NoContent => EmptyResponse.Succesful(hrm.StatusCode),
                _ => await ToEmptyError(hrm)
            };
    }
}