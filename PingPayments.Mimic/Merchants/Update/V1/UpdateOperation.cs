using PingPayments.Shared;
using PingPayments.Shared.Enums;
using PingPayments.Shared.Helpers;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.Mimic.Merchants.Update.V1
{
    public class UpdateOperation : OperationBase<(Guid merchantId, MerchantStatus merchantStatus), EmptyResponse>
    {
        public UpdateOperation(HttpClient httpClient) : base(httpClient) { }

        public override async Task<EmptyResponse> ExecuteRequest((Guid merchantId, MerchantStatus merchantStatus) request) =>
            await BaseExecute
                (
                    PUT,
                    $"/api/merchants/{request.merchantId}",
                    request,
                    await ToJson((new { status = request.merchantStatus }))
                );

        protected override async Task<EmptyResponse> ParseHttpResponse(HttpResponseMessage hrm, (Guid merchantId, MerchantStatus merchantStatus) _) =>
            hrm.StatusCode switch
            {
                NoContent => EmptyResponse.Succesful(hrm.StatusCode),
                _ => EmptyResponse.Failure
                    (
                        hrm.StatusCode,
                        await Deserialize<ErrorResponseBody>(await hrm.Content.ReadAsStringAsyncMemoized()),
                        await hrm.Content.ReadAsStringAsyncMemoized()
                    )
            };
    }
}
