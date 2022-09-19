using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.KYC.Merchant.V1.Verification
{
    public class MerchantVerificationOperation : OperationBase<MerchantVerificationRequest, GuidResponse>
    {
        public MerchantVerificationOperation(HttpClient httpClient) : base(httpClient) { }
        public override async Task<GuidResponse> ExecuteRequest(MerchantVerificationRequest request) =>
            await BaseExecute
            (
                POST,
                "api/merchant_verification",
                request
            );

        protected override async Task<GuidResponse> ParseHttpResponse(HttpResponseMessage hrm, MerchantVerificationRequest _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                Created => GuidResponse.Succesful(hrm.StatusCode, await Deserialize<GuidResponseBody>(responseBody), responseBody),
                _ => GuidResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;
        }
    }
}

