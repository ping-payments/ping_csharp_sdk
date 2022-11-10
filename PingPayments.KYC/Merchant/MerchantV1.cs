using PingPayments.KYC.Merchant.V1.AIS;
using PingPayments.KYC.Merchant.V1.AIS.Response;
using PingPayments.KYC.Merchant.V1.Get;
using PingPayments.KYC.Merchant.V1.Get.Response;
using PingPayments.KYC.Merchant.V1.Verification;
using PingPayments.Shared;
using System;
using System.Threading.Tasks;

namespace PingPayments.KYC.Merchant
{
    public class MerchantV1 : IMerchantV1
    {
        public MerchantV1(
            Lazy<KycVerificationOperation> merchantVerificationOperation,
            Lazy<GetKycOperation> getMerchantKycOperation,
            Lazy<AisKycMerchantOperation> aisKycMerchantOperation)
        {
            _merchantVerificationOperation = merchantVerificationOperation;
            _getMerchantKycOperation = getMerchantKycOperation;
            _aisKycMerchantOperation = aisKycMerchantOperation;
        }

        private readonly Lazy<KycVerificationOperation> _merchantVerificationOperation;
        private readonly Lazy<GetKycOperation> _getMerchantKycOperation;
        private readonly Lazy<AisKycMerchantOperation> _aisKycMerchantOperation;

        public async Task<EmptyResponse> Verification(KycVerificationRequest merchantVerificationRequest) =>
            await _merchantVerificationOperation.Value.ExecuteRequest(merchantVerificationRequest);

        public async Task<GetKycResponse> Get(GetKycRequest request) =>
            await _getMerchantKycOperation.Value.ExecuteRequest(request);

        public async Task<AisMerchantResponse> AIS(AisMerchantRequest request) =>
            await _aisKycMerchantOperation.Value.ExecuteRequest(request);
    }
}
