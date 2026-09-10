using PingPayments.PaymentsApi.PaymentConsents.Create.V1;
using PingPayments.PaymentsApi.PaymentConsents.Get.V1;
using System;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.PaymentConsents
{
    public class PaymentConsentV1 : IPaymentConsentV1
    {
        private readonly Lazy<CreatePaymentConsentOperation> _createPaymentConsentOperation;
        private readonly Lazy<GetPaymentConsentOperation> _getPaymentConsentOperation;

        public PaymentConsentV1(Lazy<CreatePaymentConsentOperation> createPaymentConsentOperation, Lazy<GetPaymentConsentOperation> getPaymentConsentOperation)
        {
            _createPaymentConsentOperation = createPaymentConsentOperation;
            _getPaymentConsentOperation = getPaymentConsentOperation;
        }

        public async Task<CreatePaymentConsentResponse> Create(CreatePaymentConsentRequest request) =>
            await _createPaymentConsentOperation.Value.ExecuteRequest(request);

        public async Task<PaymentConsentResponse> Get(Guid paymentConsentId) =>
            await _getPaymentConsentOperation.Value.ExecuteRequest(paymentConsentId);
    }
}
