using PingPayments.Mimic.Deposit.Create.V1;
using PingPayments.Shared;
using System;
using System.Threading.Tasks;

namespace PingPayments.Mimic.Deposit
{
    public class DepositV1 : IDepositV1
    {
        public DepositV1(Lazy<CreateOperation> createOperation)
        {
            _createOperation = createOperation;
        }
        private readonly Lazy<CreateOperation> _createOperation;

        public async Task<EmptyResponse> Create(CreateDepositRequest createDepositRequest) =>
            await _createOperation.Value.ExecuteRequest(createDepositRequest);
    }
}
