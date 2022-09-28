using PingPayments.PaymentsApi.SigningKeys.Generate.V1;
using PingPayments.PaymentsApi.SigningKeys.Get.V1;
using PingPayments.Shared;
using System;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.SigningKeys
{
    public class SigningKeyV1 : ISigningKeyV1
    {
        private readonly Lazy<GenerateKeyOperation> _generateOperation;
        private readonly Lazy<GetKeyOperation> _getOperation;

        public SigningKeyV1
        (
            Lazy<GenerateKeyOperation> generateOperation,
            Lazy<GetKeyOperation> getOperation
        )
        {
            _generateOperation = generateOperation;
            _getOperation = getOperation;
        }

        public async Task<GenerateResponse> Generate() => await _generateOperation.Value.ExecuteRequest(new EmptyRequest());

        public async Task<GetKeyRespons> Get() => await _getOperation.Value.ExecuteRequest(new EmptyRequest());
    }
}
