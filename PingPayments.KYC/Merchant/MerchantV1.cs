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
        public MerchantV1(Lazy<MerchantKycVerificationOperation> merchantVerificationOperation, Lazy<GetMerchantKycOperation> getMerchantKycOperation)
        {
            _merchantVerificationOperation = merchantVerificationOperation;
            _getMerchantKycOperation = getMerchantKycOperation;
        }

        private readonly Lazy<MerchantKycVerificationOperation> _merchantVerificationOperation;
        private readonly Lazy<GetMerchantKycOperation> _getMerchantKycOperation;

        public async Task<EmptyResponse> Verification(MerchantKycVerificationRequest merchantVerificationRequest) =>
            await _merchantVerificationOperation.Value.ExecuteRequest(merchantVerificationRequest);

        public async Task<GetMerchantKycResponse> Get(GetMerchantKycRequest request) =>
            await _getMerchantKycOperation.Value.ExecuteRequest(request);
    }
}
