using PingPayments.KYC.Merchant.V1.AIS;
using PingPayments.KYC.Merchant.V1.AIS.Response;
using PingPayments.KYC.Merchant.V1.Get;
using PingPayments.KYC.Merchant.V1.Get.Response;
using PingPayments.KYC.Merchant.V1.Verification;
using PingPayments.Shared;
using System.Threading.Tasks;

namespace PingPayments.KYC.Merchant
{
    public interface IMerchantV1
    {
        Task<GetKycResponse> Get(GetKycRequest request);
        Task<AisMerchantResponse> AIS(AisMerchantRequest request);
        Task<EmptyResponse> Verification(KycVerificationRequest request);
    }
}