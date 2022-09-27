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
        public MerchantV1(Lazy<KycVerificationOperation> merchantVerificationOperation, Lazy<GetKycOperation> getMerchantKycOperation)
        {
            _merchantVerificationOperation = merchantVerificationOperation;
            _getMerchantKycOperation = getMerchantKycOperation;
        }

        private readonly Lazy<KycVerificationOperation> _merchantVerificationOperation;
        private readonly Lazy<GetKycOperation> _getMerchantKycOperation;

        public async Task<EmptyResponse> Verification(KycVerificationRequest merchantVerificationRequest) =>
            await _merchantVerificationOperation.Value.ExecuteRequest(merchantVerificationRequest);

        public async Task<GetKycResponse> Get(GetKycRequest request) =>
            await _getMerchantKycOperation.Value.ExecuteRequest(request);
    }
}
