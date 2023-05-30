using PingPayments.KYC.Agreement.V1.Create;
using PingPayments.Shared;
using System;
using System.Threading.Tasks;

namespace PingPayments.KYC.Agreement
{
    public class AgreementV1
    {
        private readonly Lazy<CreateAgreementOperation> _createAgreementOperation;

        public AgreementV1(Lazy<CreateAgreementOperation> createAgreementOperation)
        {
            _createAgreementOperation = createAgreementOperation;
        }

        public async Task<GuidResponse> Create(CreateAgreementRequestBody request) =>
            await _createAgreementOperation.Value.ExecuteRequest(request);

    }
}
