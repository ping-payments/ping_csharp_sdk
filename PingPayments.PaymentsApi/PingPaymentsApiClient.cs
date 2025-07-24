using PingPayments.PaymentsApi.BankTransfer.List.V1;
using PingPayments.PaymentsApi.DepositBankAccount;
using PingPayments.PaymentsApi.DepositBankAccount.BankTransfer.Connect.V1;
using PingPayments.PaymentsApi.DepositBankAccount.List.V1;
using PingPayments.PaymentsApi.Disbursements;
using PingPayments.PaymentsApi.Disbursements.Get.V1;
using PingPayments.PaymentsApi.Disbursements.List.V1;
using PingPayments.PaymentsApi.KYC.AccountVerificationSession;
using PingPayments.PaymentsApi.KYC.AccountVerificationSession.Create.V1;
using PingPayments.PaymentsApi.KYC.AccountVerificationSession.Get.V1;
using PingPayments.PaymentsApi.LiquidityAccounts;
using PingPayments.PaymentsApi.LiquidityAccounts.Create.V1;
using PingPayments.PaymentsApi.LiquidityAccounts.Get.V1;
using PingPayments.PaymentsApi.Merchants;
using PingPayments.PaymentsApi.Merchants.Create.V1;
using PingPayments.PaymentsApi.Merchants.Get.V1;
using PingPayments.PaymentsApi.Merchants.List.V1;
using PingPayments.PaymentsApi.PaymentOrders;
using PingPayments.PaymentsApi.PaymentOrders.Allocations.V1;
using PingPayments.PaymentsApi.PaymentOrders.Close.V1;
using PingPayments.PaymentsApi.PaymentOrders.Create.V1;
using PingPayments.PaymentsApi.PaymentOrders.Get.V1;
using PingPayments.PaymentsApi.PaymentOrders.List.V1;
using PingPayments.PaymentsApi.PaymentOrders.Settle.V1;
using PingPayments.PaymentsApi.PaymentOrders.Split.V1;
using PingPayments.PaymentsApi.PaymentOrders.Update.V1;
using PingPayments.PaymentsApi.Payments;
using PingPayments.PaymentsApi.Payments.Get.V1;
using PingPayments.PaymentsApi.Payments.Initiate.V1;
using PingPayments.PaymentsApi.Payments.Reconcile.V1;
using PingPayments.PaymentsApi.Payments.Refund.V1;
using PingPayments.PaymentsApi.Payments.Stop.V1;
using PingPayments.PaymentsApi.Payments.Update.V1;
using PingPayments.PaymentsApi.Payouts;
using PingPayments.PaymentsApi.Payouts.Get.V1;
using PingPayments.PaymentsApi.Payouts.List.V1;
using PingPayments.PaymentsApi.Ping;
using PingPayments.PaymentsApi.Ping.V1;
using PingPayments.PaymentsApi.Poke;
using PingPayments.PaymentsApi.Poke.Request.V1;
using PingPayments.PaymentsApi.SigningKeys;
using PingPayments.PaymentsApi.SigningKeys.Generate.V1;
using PingPayments.PaymentsApi.SigningKeys.Get.V1;
using PingPayments.PaymentsApi.Tenants;
using PingPayments.PaymentsApi.Tenants.Get.V1;
using PingPayments.PaymentsApi.Tenants.Update.V1;
using System;
using System.Net.Http;


namespace PingPayments.PaymentsApi
{
    /// <summary>
    /// Client for the Payments API
    /// </summary>
    public class PingPaymentsApiClient : IPingPaymentsApiClient
    {
        public PingPaymentsApiClient(HttpClient httpClient)
        {
            var disbursementV1 = new DisbursementV1
            (
                new Lazy<GetDisbursementOperation>(() => new GetDisbursementOperation(httpClient)),
                new Lazy<ListDisbursementsOperation>(() => new ListDisbursementsOperation(httpClient))
            );

            _disbursementV1 = new Lazy<IDisbursementResource>(() => new DisbursementResource(disbursementV1));

            var depositBankAccountV1 = new DepositBankAccountV1
            (
                new Lazy<ConnectOperation>(() => new ConnectOperation(httpClient)),
                new Lazy<ListBankTransfersOperation>(() => new ListBankTransfersOperation(httpClient)),
                new Lazy<ListBankAccountsOperation>(() => new ListBankAccountsOperation(httpClient))
            );

            _depositBankAccountV1 = new Lazy<IDepositBankAccountResource>(() => new DepositBankAccountResource(depositBankAccountV1));

            var accountVerificationSessionV1 = new AccountVerificationSessionV1
           (
               new Lazy<GetSessionOperation>(() => new GetSessionOperation(httpClient)),
               new Lazy<CreateSessionOperation>(() => new CreateSessionOperation(httpClient))
           );
            _accountVerificationSessionResource = new Lazy<IAccountVerificationSessionResource>(() => new AccountVerificationSessionResource(accountVerificationSessionV1));

            var paymentsV1 = new PaymentsV1
            (
                new Lazy<InitiateOperation>(() => new InitiateOperation(httpClient)),
                new Lazy<GetOperation>(() => new GetOperation(httpClient)),
                new Lazy<ListOperation>(() => new ListOperation(httpClient)),
                new Lazy<UpdateOperation>(() => new UpdateOperation(httpClient)),
                new Lazy<ReconcileOperation>(() => new ReconcileOperation(httpClient)),
                new Lazy<RefundOperation>(() => new RefundOperation(httpClient)),
                new Lazy<StopOperation>(() => new StopOperation(httpClient))
            );
            _payments = new Lazy<IPaymentResource>(() => new PaymentResource(paymentsV1));

            var paymentOrderV1 = new PaymentOrderV1
            (
                 new Lazy<GetPaymentOrderOperation>(() => new GetPaymentOrderOperation(httpClient)),
                 new Lazy<CreatePaymentOrderOperation>(() => new CreatePaymentOrderOperation(httpClient)),
                 new Lazy<UpdatePaymentOrderOperation>(() => new UpdatePaymentOrderOperation(httpClient)),
                 new Lazy<ListPaymentOrderOperation>(() => new ListPaymentOrderOperation(httpClient)),
                 new Lazy<SplitPaymentOrderOperation>(() => new SplitPaymentOrderOperation(httpClient)),
                 new Lazy<ClosePaymentOrderOperation>(() => new ClosePaymentOrderOperation(httpClient)),
                 new Lazy<SettlePaymentOrderOperation>(() => new SettlePaymentOrderOperation(httpClient)),
                 new Lazy<GetPaymentOrderAllocationsOperation>(() => new GetPaymentOrderAllocationsOperation(httpClient))   // Obsolete, to be removed in future versions
            );
            _paymentOrderResource = new Lazy<IPaymentOrderResource>(() => new PaymentOrderResource(paymentOrderV1));

            var merchantV1 = new MerchantV1
            (
                new Lazy<CreateMerchantOperation>(() => new CreateMerchantOperation(httpClient)),
                new Lazy<GetMerchantOperation>(() => new GetMerchantOperation(httpClient)),
                new Lazy<ListMerchantsOperation>(() => new ListMerchantsOperation(httpClient))
            );
            _merchants = new Lazy<IMerchantResource>(() => new MerchantResource(merchantV1));

            var liquidityAccountV1 = new LiquidityAccountV1
            (
                new Lazy<CreateLiquidityAccountOperation>(() => new CreateLiquidityAccountOperation(httpClient)),
                new Lazy<GetLiquidityAccountOperation>(() => new GetLiquidityAccountOperation(httpClient))
            );
            _liquidityAccounts = new Lazy<ILiquidityAccountResource>(() => new LiquidityAccountResource(liquidityAccountV1));

            _ping = new Lazy<IPingResource>(() => new PingResource(new PingV1(new Lazy<PingOperation>(() => new PingOperation(httpClient)))));

            var payoutV1 = new PayoutV1
            (
                new Lazy<ListPayoutOperation>(() => new ListPayoutOperation(httpClient)),
                new Lazy<GetPayoutOperation>(() => new GetPayoutOperation(httpClient))
            );
            _payoutResource = new Lazy<IPayoutResource>(() => new PayoutResource(payoutV1));

            var tenantV1 = new TenantV1
            (
                new Lazy<GetTenantOperation>(() => new GetTenantOperation(httpClient)),
                new Lazy<UpdateTenantOperation>(() => new UpdateTenantOperation(httpClient))
            );
            _tenantResource = new Lazy<ITenantResource>(() => new TenantResource(tenantV1));

            var pokeV1 = new PokeV1
            (
                new Lazy<RequestCallbackOperation>(() => new RequestCallbackOperation(httpClient))
            );
            _pokeResource = new Lazy<IPokeResource>(() => new PokeResource(pokeV1));

            var signingKeyV1 = new SigningKeyV1
            (
                new Lazy<GenerateKeyOperation>(() => new GenerateKeyOperation(httpClient)),
                new Lazy<GetKeyOperation>(() => new GetKeyOperation(httpClient))
            );
            _signingResource = new Lazy<ISigningKeyResource>(() => new SigningKeyResource(signingKeyV1));
        }

        private readonly Lazy<IDisbursementResource> _disbursementV1;
        public IDisbursementResource Disbursements => _disbursementV1.Value;

        private readonly Lazy<IDepositBankAccountResource> _depositBankAccountV1;
        public IDepositBankAccountResource DepositBankAccount => _depositBankAccountV1.Value;


        private readonly Lazy<IAccountVerificationSessionResource> _accountVerificationSessionResource;
        public IAccountVerificationSessionResource AccountVerification => _accountVerificationSessionResource.Value;


        private readonly Lazy<IPaymentResource> _payments;
        public IPaymentResource Payments => _payments.Value;


        private readonly Lazy<IPaymentOrderResource> _paymentOrderResource;
        public IPaymentOrderResource PaymentOrder => _paymentOrderResource.Value;


        private readonly Lazy<IMerchantResource> _merchants;
        public IMerchantResource Merchants => _merchants.Value;


        private readonly Lazy<ILiquidityAccountResource> _liquidityAccounts;
        public ILiquidityAccountResource LiquidityAccounts => _liquidityAccounts.Value;


        private readonly Lazy<IPingResource> _ping;
        public IPingResource Ping => _ping.Value;


        private readonly Lazy<IPayoutResource> _payoutResource;
        public IPayoutResource Payouts => _payoutResource.Value;


        private readonly Lazy<ISigningKeyResource> _signingResource;
        public ISigningKeyResource SigningKey => _signingResource.Value;


        private readonly Lazy<ITenantResource> _tenantResource;
        public ITenantResource Tenants => _tenantResource.Value;


        private readonly Lazy<IPokeResource> _pokeResource;
        public IPokeResource Poke => _pokeResource.Value;
    }
}
