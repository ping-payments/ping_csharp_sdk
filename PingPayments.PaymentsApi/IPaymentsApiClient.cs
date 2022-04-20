﻿using PingPayments.PaymentsApi.PaymentOrders;
using PingPayments.PaymentsApi.Payments;

namespace PingPayments.PaymentsApi
{
    public interface IPaymentsApiClient
    {
        IMerchantEndpoints Merchants { get; }
        IPaymentOrderEndpoints PaymentOrder { get; }
        IPaymentEndpoints Payments { get; }
    }
}