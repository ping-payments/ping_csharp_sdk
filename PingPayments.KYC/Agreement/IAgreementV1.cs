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
    public interface IAgreementV1
    {
        Task<GuidResponse> Create(CreateRequestBody request);
        Task<AgreementResponse> Get(Guid agreementId);
        Task<AgreementTemplatesResponse> ListTemplates();
        Task<EmptyResponse> Publish(PublishRequest request);
        Task<EmptyResponse> Update(UpdateRequest request);
    }
}