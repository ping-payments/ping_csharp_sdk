using PingPayments.KYC.Agreement.V1.Create;
using PingPayments.KYC.Agreement.V1.Get;
using PingPayments.KYC.Agreement.V1.GetAgreementTemplates;
using PingPayments.Shared;
using System;
using System.Threading.Tasks;

namespace PingPayments.KYC.Agreement
{
    public class AgreementV1
    {
        private readonly Lazy<CreateAgreementOperation> _createAgreementOperation;
        private readonly Lazy<GetAgreementOperation> _getAgreementOperation;
        private readonly Lazy<GetAgreementTemplatesOperation> _getAgreementTemplatesOperation;


        public AgreementV1(
            Lazy<CreateAgreementOperation> createAgreementOperation, 
            Lazy<GetAgreementOperation> getAgreementOperation, 
            Lazy<GetAgreementTemplatesOperation> getAgreementTemplatesOperation)
        {
            _createAgreementOperation = createAgreementOperation;
            _getAgreementOperation = getAgreementOperation;
            _getAgreementTemplatesOperation = getAgreementTemplatesOperation;
        }

        public async Task<GuidResponse> Create(CreateAgreementRequestBody request) =>
            await _createAgreementOperation.Value.ExecuteRequest(request);

        public async Task<AgreementResponse> Get(Guid agreementId) =>
            await _getAgreementOperation.Value.ExecuteRequest(agreementId);

        public async Task<AgreementTemplatesResponse> GetAgreementTemplates() =>
            await _getAgreementTemplatesOperation.Value.ExecuteRequest(null);

    }
}
