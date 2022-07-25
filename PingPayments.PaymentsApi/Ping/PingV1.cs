using PingPayments.Shared;
using PingPayments.PaymentsApi.Ping.V1;
using System;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.Ping
{
    public class PingV1 : IPingV1
    {
        private readonly Lazy<PingOperation> _pingOperation;

        public PingV1(Lazy<PingOperation> pingOperation)
        {
            _pingOperation = pingOperation;
        }

        public async Task<TextResponse> Ping() => await _pingOperation.Value.ExecuteRequest(new EmptyRequest());
    }
}
