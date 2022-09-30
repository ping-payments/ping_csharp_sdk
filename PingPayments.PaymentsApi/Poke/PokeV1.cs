using PingPayments.PaymentsApi.Poke.Request.V1;
using PingPayments.Shared;
using System;
using System.Threading.Tasks;


namespace PingPayments.PaymentsApi.Poke
{
    public class PokeV1 : IPokeV1
    {
        private readonly Lazy<RequestCallbackOperation> _requestCallbackOperation;
        public PokeV1(Lazy<RequestCallbackOperation> requestCallbackOperation)
        {
            _requestCallbackOperation = requestCallbackOperation;
        }

        public async Task<EmptyResponse> Request(Uri callbackUrl) =>
            await _requestCallbackOperation.Value.ExecuteRequest(callbackUrl);
    }
}

