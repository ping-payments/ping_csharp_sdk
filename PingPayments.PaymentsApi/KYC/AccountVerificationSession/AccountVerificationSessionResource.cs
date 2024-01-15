using PingPayments.PaymentsApi.PaymentOrders;
using System;
using System.Collections.Generic;
using System.Text;

namespace PingPayments.PaymentsApi.KYC.AccountVerificationSession
{
    public class AccountVerificationSessionResource : IAccountVerificationSessionResource
    {
        public AccountVerificationSessionResource(IAccountVerificationSessionV1 v1) => V1 = v1;
        public IAccountVerificationSessionV1 V1 { get; }
    }
}
