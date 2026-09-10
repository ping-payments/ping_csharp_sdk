using PingPayments.PaymentsApi.PaymentConsents.Create.V1;
using PingPayments.PaymentsApi.PaymentConsents.Get.V1;
using System;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.PaymentConsents
{
    public interface IPaymentConsentV1
    {
        Task<CreatePaymentConsentResponse> Create(CreatePaymentConsentRequest request);
        Task<PaymentConsentResponse> Get(Guid paymentConsentId);
    }
}
