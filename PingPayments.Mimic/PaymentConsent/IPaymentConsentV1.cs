using PingPayments.Mimic.PaymentConsent.Update.V1;
using PingPayments.Shared;
using System;
using System.Threading.Tasks;

namespace PingPayments.Mimic.PaymentConsent
{
    public interface IPaymentConsentV1
    {
        Task<EmptyResponse> Update(Guid consentId, PaymentConsentStatusEnum status);
    }
}
