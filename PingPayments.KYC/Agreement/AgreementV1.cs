using PingPayments.KYC.Agreement.V1.Create;
using PingPayments.KYC.Agreement.V1.Get;
using PingPayments.KYC.Agreement.V1.GetAgreementTemplates;
using PingPayments.KYC.Agreement.V1.Publish;
using PingPayments.KYC.Agreement.V1.Update;
using PingPayments.Shared;
using System;
using System.Threading.Tasks;

namespace PingPayments.KYC.Agreement
{

    public class AgreementV1 : IAgreementV1
    {
        private readonly Lazy<CreateOperation> _createOperation;
        private readonly Lazy<GetOperation> _getOperation;
        private readonly Lazy<ListTemplatesOperation> _listTemplatesOperation;
        private readonly Lazy<PublishOperation> _publishOperation;
        private readonly Lazy<UpdateOperation> _updateOperation;

        public AgreementV1(
            Lazy<CreateOperation> createAgreementOperation,
            Lazy<GetOperation> getAgreementOperation,
            Lazy<ListTemplatesOperation> getAgreementTemplatesOperation,
            Lazy<PublishOperation> publishAgreementOperation,
            Lazy<UpdateOperation> updateAgreementOperation)
        {
            _createOperation = createAgreementOperation;
            _getOperation = getAgreementOperation;
            _listTemplatesOperation = getAgreementTemplatesOperation;
            _publishOperation = publishAgreementOperation;
            _updateOperation = updateAgreementOperation;
        }

        public async Task<GuidResponse> Create(CreateRequestBody request) =>
            await _createOperation.Value.ExecuteRequest(request);

        public async Task<AgreementResponse> Get(Guid agreementId) =>
            await _getOperation.Value.ExecuteRequest(agreementId);

        public async Task<AgreementTemplatesResponse> ListTemplates() =>
            await _listTemplatesOperation.Value.ExecuteRequest(null);

        public async Task<EmptyResponse> Publish(PublishRequest request) =>
            await _publishOperation.Value.ExecuteRequest(request);

        public async Task<EmptyResponse> Update(UpdateRequest request) =>
            await _updateOperation.Value.ExecuteRequest(request);
    }
}
