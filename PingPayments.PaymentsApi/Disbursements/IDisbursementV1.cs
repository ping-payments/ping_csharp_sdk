﻿using PingPayments.PaymentsApi.Disbursements.Get.V1;
using PingPayments.PaymentsApi.Disbursements.List.V1;
using System;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.Disbursements
{
    public interface IDisbursementV1
    {
        [Obsolete("Use Allocations.List(Guid disbursementId) instead.", true)]
        Task<GetDisbursementResponse> Get(Guid disbursementId);
        Task<ListDisbursementResponse> List((DateTimeOffset from, DateTimeOffset to)? dateFilter = null);
    }
}