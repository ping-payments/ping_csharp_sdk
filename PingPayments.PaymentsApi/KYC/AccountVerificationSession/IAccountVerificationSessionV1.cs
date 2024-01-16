using PingPayments.PaymentsApi.KYC.AccountVerificationSession.Create.V1;
using PingPayments.PaymentsApi.KYC.AccountVerificationSession.Get.V1;
using PingPayments.PaymentsApi.PaymentOrders.Allocations.V1;
using PingPayments.PaymentsApi.PaymentOrders.Create.V1;
using PingPayments.PaymentsApi.PaymentOrders.Get.V1;
using PingPayments.PaymentsApi.PaymentOrders.List.V1;
using PingPayments.PaymentsApi.PaymentOrders.Update.V1;
using PingPayments.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.KYC.AccountVerificationSession
{
    public interface IAccountVerificationSessionV1
    {
        Task<CreateSessionResponse> Create(CreateSessionRequest createRequest);
        Task<GetSessionResponse> Get(string sessionId);
    }
}
