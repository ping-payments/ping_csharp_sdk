using PingPayments.Mimic.Autogiro;
using PingPayments.Mimic.Autogiro.Update.Mandate.V1;
using PingPayments.Mimic.Autogiro.Update.Payment.V1;
using PingPayments.Mimic.Deposit;
using PingPayments.Mimic.Deposit.Create.V1;
using PingPayments.Mimic.Disbursements;
using PingPayments.Mimic.Disbursements.Trigger.V1;
using PingPayments.Mimic.Merchants;
using PingPayments.Mimic.Merchants.Update.V1;
using PingPayments.Mimic.PaymentConsent;
using PingPayments.Mimic.PaymentConsent.Update.V1;
using System;
using System.Net.Http;

namespace PingPayments.Mimic
{
    public class PingMimicApiClient : IPingMimicApiClient
    {
        public PingMimicApiClient(HttpClient httpClient)
        {
            var depositV1 = new DepositV1(new Lazy<CreateOperation>(() => new CreateOperation(httpClient)));
            _deposit = new Lazy<IDepositResource>(() => new DepositResource(depositV1));

            var merchantV1 = new MerchantV1(new Lazy<UpdateOperation>(() => new UpdateOperation(httpClient)));
            _merchant = new Lazy<IMerchantResource>(() => new MerchantResource(merchantV1));

            var disbursementV1 = new DisbursementV1(new Lazy<TriggerDisbursementOperation>(() => new TriggerDisbursementOperation(httpClient)));
            _disbursement = new Lazy<IDisbursementResource>(() => new DisbursementResource(disbursementV1));

            var autogirotV1 = new AutogiroV1
            (
                new Lazy<UpdateMandateOperation>(() => new UpdateMandateOperation(httpClient)),
                new Lazy<UpdatePaymentOperation>(() => new UpdatePaymentOperation(httpClient))
            );
            _autogiro = new Lazy<IAutogiroResource>(() => new AutogiroResource(autogirotV1));

            var paymentConsentV1 = new PaymentConsentV1(new Lazy<UpdatePaymentConsentOperation>(() => new UpdatePaymentConsentOperation(httpClient)));
            _paymentConsent = new Lazy<IPaymentConsentResource>(() => new PaymentConsentResource(paymentConsentV1));
        }

        private readonly Lazy<IDepositResource> _deposit;
        public IDepositResource Deposit => _deposit.Value;


        private readonly Lazy<IAutogiroResource> _autogiro;
        public IAutogiroResource Autogiro => _autogiro.Value;


        private readonly Lazy<IMerchantResource> _merchant;
        public IMerchantResource Merchant => _merchant.Value;


        private readonly Lazy<IDisbursementResource> _disbursement;
        public IDisbursementResource Disbursement => _disbursement.Value;


        private readonly Lazy<IPaymentConsentResource> _paymentConsent;
        public IPaymentConsentResource PaymentConsent => _paymentConsent.Value;
    }
}
