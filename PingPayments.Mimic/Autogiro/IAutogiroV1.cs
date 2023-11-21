using PingPayments.Mimic.Autogiro.Update.Mandate.V1;
using PingPayments.Mimic.Autogiro.Update.Payment.V1;
using PingPayments.Shared;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PingPayments.Mimic.Autogiro
{
    public interface IAutogiroV1
    {
        Task<EmptyResponse> UpdateMandate(UpdateMandateRequest updateMandateRequest);
        Task<EmptyResponse> UpdatePayment(UpdatePaymentRequest updatePaymentRequest);
    }
}
