﻿using PingPayments.PaymentLinksApi.Ping.V1;
using PingPayments.PaymentLinksApi.Shared;
using PingPayments.Shared;

namespace PingPayments.PaymentLinksApi.Ping
{
    public class PingV1 : IPingV1
    {
        private readonly Lazy<PingOperation> _pingOperation;

        public PingV1(Lazy<PingOperation> pingOperation)
        {
            _pingOperation = pingOperation;
        }

        public async Task<PaymentLinksTextResponse> Ping()
        {
            var response = await _pingOperation.Value.ExecuteRequest(new EmptyRequest());
            return response;
        }
    }
}
