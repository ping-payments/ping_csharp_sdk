using PingPayments.PaymentsApi.PaymentOrders;
using System;
using System.Collections.Generic;
using System.Text;

namespace PingPayments.PaymentsApi.KYC.AccountVerificationSession
{
    public interface IAccountVerificationSessionResource
    {
        IAccountVerificationSessionV1 V1 { get; }
    }
}
