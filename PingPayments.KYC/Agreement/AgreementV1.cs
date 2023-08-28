﻿using PingPayments.KYC.Agreement.V1.Create;
using PingPayments.KYC.Agreement.V1.CreateAccessLink;
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
        private readonly Lazy<V1.Create.CreateOperation> _createAgreementOperation;
        private readonly Lazy<GetOperation> _getAgreementOperation;
        private readonly Lazy<ListTemplatesOperation> _listTemplatesOperation;
        private readonly Lazy<V1.CreateAccessLink.CreateOperation> _createAccessLinkOperation;
        private readonly Lazy<PublishOperation> _publishAgreementOperation;
        private readonly Lazy<UpdateOperation> _updateAgreementOperation;

        public AgreementV1(
            Lazy<V1.Create.CreateOperation> createAgreementOperation,
            Lazy<GetOperation> getAgreementOperation,
            Lazy<ListTemplatesOperation> getAgreementTemplatesOperation,
            Lazy<V1.CreateAccessLink.CreateOperation> createAccessLinkOperation,
            Lazy<PublishOperation> publishAgreementOperation,
            Lazy<UpdateOperation> updateAgreementOperation)
        {
            _createAgreementOperation = createAgreementOperation;
            _getAgreementOperation = getAgreementOperation;
            _listTemplatesOperation = getAgreementTemplatesOperation;
            _createAccessLinkOperation = createAccessLinkOperation;
            _publishAgreementOperation = publishAgreementOperation;
            _updateAgreementOperation = updateAgreementOperation;
        }

        public async Task<GuidResponse> Create(V1.Create.CreateRequestBody request) =>
            await _createAgreementOperation.Value.ExecuteRequest(request);

        public async Task<AgreementResponse> Get(Guid agreementId) =>
            await _getAgreementOperation.Value.ExecuteRequest(agreementId);

        public async Task<AgreementTemplatesResponse> ListTemplates() =>
            await _listTemplatesOperation.Value.ExecuteRequest(null);

        public async Task<CreateResponse> CreateAccessLink(V1.CreateAccessLink.CreateRequestBody request) =>
           await _createAccessLinkOperation.Value.ExecuteRequest(request);

        public async Task<EmptyResponse> Publish(PublishRequest request) =>
            await _publishAgreementOperation.Value.ExecuteRequest(request);

        public async Task<EmptyResponse> Update(UpdateRequest request) =>
            await _updateAgreementOperation.Value.ExecuteRequest(request);

    }
}
