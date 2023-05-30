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
        Task<GuidResponse> Create(CreateAgreementRequestBody request);
        Task<AgreementResponse> Get(Guid agreementId);
        Task<AgreementTemplatesResponse> GetAgreementTemplates();
        Task<EmptyResponse> PublishAgreement(PublishAgreementRequest publishAgreementRequest);
        Task<EmptyResponse> UpdateAgreement(UpdateAgreementRequest updateAgreementRequest);
    }
}