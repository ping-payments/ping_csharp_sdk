using LanguageExt;
using System;
using System.Threading.Tasks;

namespace PaymentsApiSDK.Interfaces
{
    public interface IPaymentsApiClient
    {
        Task<Option<IInitiatePaymentResponse>> InitiatePayment(IPaymentRequest payment, Guid tenantId, Guid merchantId, Guid paymentLinkId);
    }
}