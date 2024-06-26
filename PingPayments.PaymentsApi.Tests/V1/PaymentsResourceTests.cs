﻿using PingPayments.Mimic.Deposit.Create.V1;
using PingPayments.PaymentsApi.PaymentOrders.Create.V1;
using PingPayments.PaymentsApi.Payments.Get.V1;
using PingPayments.PaymentsApi.Payments.Initiate.V1.Request;
using PingPayments.PaymentsApi.Payments.Refund.V1;
using PingPayments.PaymentsApi.Payments.Shared.V1;
using PingPayments.PaymentsApi.Payments.Shared.V1.Deposit;
using PingPayments.PaymentsApi.Payments.Update.V1;
using PingPayments.PaymentsApi.Payments.V1.Initiate.Request;
using PingPayments.PaymentsApi.Payments.V1.Initiate.Response;
using PingPayments.Shared;
using PingPayments.Shared.Enums;
using PingPayments.Shared.Helpers;
using PingPayments.Tests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BankId = PingPayments.PaymentsApi.Payments.V1.Initiate.Request.BankId;


namespace PingPayments.PaymentsApi.Tests.V1
{
    public class PaymentsResourceTests : PaymentsApiTestClient
    {
        [Fact]
        public async Task Initiate_payment_200()
        {
            var requestObject = CreatePayment.Dummy.New
            (
                CurrencyEnum.SEK,
                new OrderItem[]
                {
                    new OrderItem(5.ToMinorCurrencyUnit(), "A", SwedishVat.Vat25, TestData.MerchantId, null, new Dictionary<string, object> { { "Key", "Data" } }),
                    new OrderItem(5.ToMinorCurrencyUnit(), "B", SwedishVat.Vat12, null, TestData.LiquidityAccountId, tags: new string[] {"typ1"})
                },
                payer: new Payer(
                    sourceOfFunds: new SourceOfFundsEnum[]
                    {
                        SourceOfFundsEnum.rental_income,
                        SourceOfFundsEnum.loan_or_credit,
                        SourceOfFundsEnum.business_profits,
                        SourceOfFundsEnum.salary_or_employment_income,
                        SourceOfFundsEnum.legal_settlements,
                        SourceOfFundsEnum.gifts_and_donations,
                        SourceOfFundsEnum.dividends_and_investment_income,
                        SourceOfFundsEnum.foreign_remittances,
                        SourceOfFundsEnum.inheritance,
                        SourceOfFundsEnum.insurance_payouts,
                        SourceOfFundsEnum.lottery_or_gambling_winnings,
                        SourceOfFundsEnum.retirement_funds,
                        SourceOfFundsEnum.royalties,
                        SourceOfFundsEnum.sale_of_assets
                    }
                )
            );
            var response = await _api.Payments.V1.Initiate(TestData.OrderId, requestObject);

            AssertHttpOK(response);
            Assert.NotNull(response?.Body?.SuccessfulResponseBody);
            DummyResponseBody? body = response;
            Assert.NotNull(body);
            Assert.NotEqual(Guid.Empty, body?.Id);
        }

        [Fact(Skip = "Reliant on fortus speciefic")]
        public async Task Initiate_fortus_payment_200()
        {
            var requestObject = CreatePayment.Fortus.Invoice
            (
                new OrderItem[]
                {
                    new OrderItem(5.ToMinorCurrencyUnit(), "A", SwedishVat.Vat25, TestData.MerchantId, null, new Dictionary<string, object> { { "Key", "Data" } }),
                    new OrderItem(5.ToMinorCurrencyUnit(), "B", SwedishVat.Vat12, null, TestData.LiquidityAccountId, tags: new string[] {"typ1"})
                },
                InvoiceTypeEnum.days14,
                "195309261732",
                "SE",
                "213.115.225.102",
                "test@gmail.com",
                "12312312",
                new Address { City = "Örebro", FirstName = "Knut", LastName = "Knutesson", StreetAddress = "Örebrogatan 20", Zip = "70225" },
                payer: new Payer(
                    sourceOfFunds: new SourceOfFundsEnum[]
                    {
                        SourceOfFundsEnum.rental_income,
                        SourceOfFundsEnum.loan_or_credit,
                        SourceOfFundsEnum.business_profits,
                        SourceOfFundsEnum.salary_or_employment_income,
                        SourceOfFundsEnum.legal_settlements,
                        SourceOfFundsEnum.gifts_and_donations,
                        SourceOfFundsEnum.dividends_and_investment_income,
                        SourceOfFundsEnum.foreign_remittances,
                        SourceOfFundsEnum.inheritance,
                        SourceOfFundsEnum.insurance_payouts,
                        SourceOfFundsEnum.lottery_or_gambling_winnings,
                        SourceOfFundsEnum.retirement_funds,
                        SourceOfFundsEnum.royalties,
                        SourceOfFundsEnum.sale_of_assets
                    }
                ),
                bankId: new BankId { Method = BankIdMethodEnum.other_device, QrCodeCallbackUrl = "https://www.pingpayments.com", QrCodeSize = null, RedirectUrl = null }

            );
            var response = await _api.Payments.V1.Initiate(TestData.OrderId, requestObject);

            AssertHttpOK(response);
            Assert.NotNull(response?.Body?.SuccessfulResponseBody);
            FortusResponseBody? body = response;
            Assert.NotNull(body);
            Assert.NotEqual(Guid.Empty, body?.Id);
        }

        [Fact]
        public async Task Initiate_payment_422_when_order_items_and_total_amount_does_not_match()
        {
            var requestObject = new InitiatePaymentRequest
            (
                CurrencyEnum.SEK,
                1000,
                new OrderItem[]
                {
                    new OrderItem(500, "A", SwedishVat.Vat25, TestData.MerchantId),
                },
                ProviderEnum.dummy,
                MethodEnum.dummy,
                new DummyProviderMethodParameters(),
                TestData.FakeCallback,
                new Dictionary<string, object> { { "test_data", 1337m } }
            );
            var response = await _api.Payments.V1.Initiate(TestData.OrderId, requestObject);
            AssertHttpUnprocessableEntity(response);
        }

        [Fact]
        public async Task Initiate_payment_404_when_order_id_does_not_exist()
        {
            var orderId = Guid.NewGuid();
            var requestObject = new InitiatePaymentRequest
            (
                CurrencyEnum.SEK,
               1000,
                new OrderItem[]
                {
                    new OrderItem(5.ToMinorCurrencyUnit(), "A", SwedishVat.Vat25, TestData.MerchantId),
                    new OrderItem(5.ToMinorCurrencyUnit(), "B", SwedishVat.Vat12, TestData.MerchantId),
                },
                ProviderEnum.dummy,
                MethodEnum.dummy,
                new DummyProviderMethodParameters(),
                TestData.FakeCallback,
                new Dictionary<string, object> { { "test_data", 1337m } }
            );
            var response = await _api.Payments.V1.Initiate(orderId, requestObject);
            AssertHttpNotFound(response);
        }

        [Fact]
        public async Task Get_works()
        {
            var response = await _api.Payments.V1.Get(TestData.OrderId, TestData.PaymentId);
            AssertHttpOK(response);
        }

        [Fact]
        public async Task Get_404_on_wrong_payment_id()
        {
            var response = await _api.Payments.V1.Get(TestData.OrderId, Guid.NewGuid());
            AssertHttpNotFound(response);
        }

        [Fact]
        public async Task Get_404_on_non_existing_order()
        {
            var response = await _api.Payments.V1.Get(Guid.NewGuid(), Guid.NewGuid());
            AssertHttpNotFound(response);
        }

        [Fact]
        public async Task Get_404_on_non_existing_order_with_existing_payment()
        {
            var response = await _api.Payments.V1.Get(Guid.NewGuid(), TestData.PaymentId);
            AssertHttpNotFound(response);
        }


        [Fact]
        public async Task Initiate_ecommerce_swish_payment_200()
        {
            var request = CreatePayment.Swish.Ecommerce(
                new OrderItem[]
                {
                    new OrderItem(5.ToMinorCurrencyUnit(), "A", SwedishVat.Vat25, TestData.MerchantId),
                    new OrderItem(5.ToMinorCurrencyUnit(), "B", SwedishVat.Vat12, TestData.MerchantId),
                },
                "0701234567",
                "message",
                TestData.FakeCallback,
                new Dictionary<string, object> { });


            var response = await _api.Payments.V1.Initiate(TestData.OrderId, request);
            AssertHttpOK(response);
        }

        [Fact]
        public async Task Initiate_mcommerce_swish_payment_with_qr_200()
        {
            var request = CreatePayment.Swish.Mcommerce(
                new OrderItem[]
                {
                    new OrderItem(5.ToMinorCurrencyUnit(), "A", SwedishVat.Vat25, TestData.MerchantId),
                    new OrderItem(5.ToMinorCurrencyUnit(), "B", SwedishVat.Vat12, TestData.MerchantId),
                },
                "message",
                TestData.FakeCallback,
                new SwishQrCode(),
                new Dictionary<string, object> { });


            var response = await _api.Payments.V1.Initiate(TestData.OrderId, request);

            AssertHttpOK(response);

            var mcommerceResponse = response?.Body?.SuccessfulResponseBody as SwishMCommerceResponseBody;
            Assert.False(string.IsNullOrEmpty(mcommerceResponse?.ProviderMethodResponse.QrCode));
        }

        [Fact]
        public async Task Initiate_mcommerce_swish_payment_without_qr_200()
        {
            var request = CreatePayment.Swish.Mcommerce(
                new OrderItem[]
                {
                    new OrderItem(5.ToMinorCurrencyUnit(), "A", SwedishVat.Vat25, TestData.MerchantId),
                    new OrderItem(5.ToMinorCurrencyUnit(), "B", SwedishVat.Vat12, TestData.MerchantId),
                },
                "message",
                TestData.FakeCallback,
                null,
                new Dictionary<string, object> { });


            var response = await _api.Payments.V1.Initiate(TestData.OrderId, request);
            AssertHttpOK(response);
        }

        [Fact]
        public async Task Update_payment_204()
        {
            var initiatePaymentRequest = CreatePayment.Swish.Ecommerce(
                new OrderItem[]
                {
                    new OrderItem(5.ToMinorCurrencyUnit(), "A", SwedishVat.Vat25, TestData.MerchantId),
                    new OrderItem(5.ToMinorCurrencyUnit(), "B", SwedishVat.Vat12, TestData.MerchantId),
                },
                "0701234567",
                "message",
                TestData.FakeCallback,
                new Dictionary<string, object> { });

            var payment = await _api.Payments.V1.Initiate(TestData.OrderId, initiatePaymentRequest);
            Guid paymentId = payment.Body.SuccessfulResponseBody.Id;

            var newOrderItems = new OrderItem[]
            {
                new OrderItem(8.ToMinorCurrencyUnit(), "C", SwedishVat.Vat25, TestData.MerchantId),
                new OrderItem(2.ToMinorCurrencyUnit(), "D", SwedishVat.Vat12, TestData.MerchantId),
            };
            var updatePaymentRequest = new UpdatePaymentRequest(newOrderItems);

            var response = await _api.Payments.V1.Update(TestData.OrderId, paymentId, updatePaymentRequest);
            AssertHttpNoContent(response);
        }

        [Fact]
        public async Task Update_payment_404()
        {
            var newOrderItems = new OrderItem[]
            {
                new OrderItem(8.ToMinorCurrencyUnit(), "C", SwedishVat.Vat25, TestData.MerchantId),
                new OrderItem(2.ToMinorCurrencyUnit(), "D", SwedishVat.Vat12, TestData.MerchantId),
            };
            var updatePaymentRequest = new UpdatePaymentRequest(newOrderItems);

            var response = await _api.Payments.V1.Update(TestData.OrderId, new Guid(), updatePaymentRequest);
            AssertHttpNotFound(response);
        }


        [Fact]
        public async Task Update_payment_422()
        {
            var updatePaymentRequest = new UpdatePaymentRequest(Array.Empty<OrderItem>());
            var response = await _api.Payments.V1.Update(TestData.OrderId, new Guid(), updatePaymentRequest);
            AssertHttpUnprocessableEntity(response);
        }

        [Fact]
        public async Task Stop_payment_204()
        {
            var initiatePaymentRequest = CreatePayment.Dummy.New
            (
                CurrencyEnum.SEK,
                new OrderItem[]
                {
                    new OrderItem(5.ToMinorCurrencyUnit(), "A", SwedishVat.Vat25, TestData.MerchantId),
                    new OrderItem(5.ToMinorCurrencyUnit(), "B", SwedishVat.Vat12, TestData.MerchantId),
                },
                TestData.FakeCallback,
                desiredPaymentStatus: PaymentStatusEnum.COMPLETED
             );

            var payment = await _api.Payments.V1.Initiate(TestData.OrderId, initiatePaymentRequest);
            Guid paymentId = payment.Body.SuccessfulResponseBody.Id;

            var response = await _api.Payments.V1.Stop(TestData.OrderId, paymentId);
            AssertHttpNoContent(response);
        }

        [Fact]
        public async Task Stop_payment_404()
        {
            var response = await _api.Payments.V1.Stop(TestData.OrderId, new Guid());
            AssertHttpNotFound(response);
        }
#pragma warning disable CS8600 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.

        [Fact]
        public async Task Reconcile_underfunded_payment_204()
        {
            // Prepare an order with a deposit payment
            var (orderId, depositResponse) = await PreparePaymentOrderWithDepositPayment(price: 5);

            Guid paymentId = depositResponse.Id;
            var reference = depositResponse.ProviderMethodResponse.Reference;

            // Mimic a deposit
            CreateDepositRequest depositRequest = new
                (
                    Amount: 4.ToMinorCurrencyUnit(),
                    Currency: CurrencyEnum.SEK,
                    ReferenceType: ReferenceTypeEnum.OCR,
                    Reference: reference,
                    Iban: "SE4850000000054401096835",
                    Type: ProcesseTypeEnum.instant
                );
            await _mimicApi.Deposit.V1.Create(depositRequest);

            // Await Payment
            await AwaitPaymentStatusCallback(orderId, paymentId, PaymentStatusEnum.UNDERFUNDED);

            // Reconcile Payment funds 
            var ReconcileOrderItems = new OrderItem[]
            {
                new OrderItem(4.ToMinorCurrencyUnit(), "A", SwedishVat.Vat25, TestData.MerchantId),

            };
            var response = await _api.Payments.V1.Reconcile(orderId, paymentId, ReconcileOrderItems);

            AssertHttpNoContent(response);
        }

        [Fact]
        public async Task Reconcile_overfunded_payment_204()
        {
            // Prepare an order with a deposit payment
            var (orderId, depositResponse) = await PreparePaymentOrderWithDepositPayment(price: 5);

            Guid paymentId = depositResponse.Id;
            var reference = depositResponse.ProviderMethodResponse.Reference;

            // Mimic a deposit
            CreateDepositRequest depositRequest = new
                (
                    Amount: 6.ToMinorCurrencyUnit(),
                    Currency: CurrencyEnum.SEK,
                    ReferenceType: ReferenceTypeEnum.OCR,
                    Reference: reference,
                    Iban: "SE4850000000054401096835",
                    Type: ProcesseTypeEnum.instant
                );
            await _mimicApi.Deposit.V1.Create(depositRequest);

            // Await Payment
            await AwaitPaymentStatusCallback(orderId, paymentId, PaymentStatusEnum.OVERFUNDED);

            // Reconcile Payment funds 
            var ReconcileOrderItems = new OrderItem[]
            {
                new OrderItem(6.ToMinorCurrencyUnit(), "A", SwedishVat.Vat25, TestData.MerchantId),

            };
            var response = await _api.Payments.V1.Reconcile(orderId, paymentId, ReconcileOrderItems);

            AssertHttpNoContent(response);
        }

        [Fact]
        public async Task Create_deposit_payment_same_completed_reference()
        {
            // Prepare an order with a deposit payment
            var (orderId, depositResponse) = await PreparePaymentOrderWithDepositPayment(price: 5);

            Guid paymentId = depositResponse.Id;
            var reference = depositResponse.ProviderMethodResponse.Reference;

            // Mimic a deposit
            CreateDepositRequest depositRequest = new
                (
                    Amount: 5.ToMinorCurrencyUnit(),
                    Currency: CurrencyEnum.SEK,
                    ReferenceType: ReferenceTypeEnum.OCR,
                    Reference: reference,
                    Iban: "SE4850000000054401096835",
                    Type: ProcesseTypeEnum.instant
                );
            await _mimicApi.Deposit.V1.Create(depositRequest);

            // Await Payment to get completed
            await AwaitPaymentStatusCallback(orderId, paymentId, PaymentStatusEnum.COMPLETED);

            //Create another deposit Payment, same OCR
            var paymentRequest = CreatePayment.PingDeposit.Ocr
            (
                CurrencyEnum.SEK,
                orderItems: new OrderItem[]
                {
                    new OrderItem(5.ToMinorCurrencyUnit(), "A", SwedishVat.Vat25, TestData.MerchantId),
                },

                reference: reference
            );
            var response = await _api.Payments.V1.Initiate(orderId, paymentRequest);

            AssertHttpOK(response);
        }


        [Fact]
        public async Task Create_deposit_payment_same_pending_reference()
        {
            // Prepare an order with a deposit payment
            var (orderId, depositResponse) = await PreparePaymentOrderWithDepositPayment(price: 5);

            Guid paymentId = depositResponse.Id;
            var reference = depositResponse.ProviderMethodResponse.Reference;

            //Create another deposit Payment, same OCR
            var paymentRequest = CreatePayment.PingDeposit.Ocr
            (
                CurrencyEnum.SEK,
                orderItems: new OrderItem[]
                {
                    new OrderItem(5.ToMinorCurrencyUnit(), "A", SwedishVat.Vat25, TestData.MerchantId),
                },
                reference: reference
            );
            var response = await _api.Payments.V1.Initiate(orderId, paymentRequest);

            AssertHttpApiError(response);
        }

        [Fact]
        public async Task Reconcile_payment_amount_missmatch_403()
        {
            // Prepare an order with a deposit payment
            var (orderId, depositResponse) = await PreparePaymentOrderWithDepositPayment(price: 5);

            Guid paymentId = depositResponse.Id;
            var reference = depositResponse.ProviderMethodResponse.Reference;

            // Mimic a deposit
            CreateDepositRequest depositRequest = new
                (
                    Amount: 4.ToMinorCurrencyUnit(),
                    Currency: CurrencyEnum.SEK,
                    ReferenceType: ReferenceTypeEnum.OCR,
                    Reference: reference,
                    Iban: "SE4850000000054401096835",
                    Type: ProcesseTypeEnum.instant
                );
            await _mimicApi.Deposit.V1.Create(depositRequest);

            // Await Payment
            await AwaitPaymentStatusCallback(orderId, paymentId, PaymentStatusEnum.UNDERFUNDED);

            // Reconcile Payment funds 
            var ReconcileOrderItems = new OrderItem[]
            {
                new OrderItem(3.ToMinorCurrencyUnit(), "A", SwedishVat.Vat25, TestData.MerchantId),

            };
            var response = await _api.Payments.V1.Reconcile(orderId, paymentId, ReconcileOrderItems);

            AssertHttpApiError(response);
        }

        [Fact]
        public async Task Reconcile_funded_payment_204()
        {
            // Prepare an order with a deposit payment
            var (orderId, depositResponse) = await PreparePaymentOrderWithDepositPayment(price: 10, completeWhenFunded: false);

            Guid paymentId = depositResponse.Id;
            var reference = depositResponse.ProviderMethodResponse.Reference;

            // Mimic a deposit
            CreateDepositRequest depositRequest = new
                (
                    Amount: 10.ToMinorCurrencyUnit(),
                    Currency: CurrencyEnum.SEK,
                    ReferenceType: ReferenceTypeEnum.OCR,
                    Reference: reference,
                    Iban: "SE4850000000054401096835",
                    Type: ProcesseTypeEnum.instant
                );
            await _mimicApi.Deposit.V1.Create(depositRequest);

            // Await Payment
            await AwaitPaymentStatusCallback(orderId, paymentId, PaymentStatusEnum.FUNDED);

            var response = await _api.Payments.V1.Reconcile(orderId, paymentId);

            var completedPayment = await _api.Payments.V1.Get(orderId, paymentId);

            Assert.Equal(PaymentStatusEnum.COMPLETED, completedPayment.Body.SuccessfulResponseBody.Status);

            AssertHttpNoContent(response);
        }


        public async Task AwaitPaymentStatusCallback(Guid orderId, Guid paymentId, PaymentStatusEnum desiredStatus)
        {
            bool isStatusCompleted = false;
            while (!isStatusCompleted)
            {
                PaymentResponse payment = await _api.Payments.V1.Get(orderId, paymentId);
                var paymentStatus = payment.Body.SuccessfulResponseBody.Status;

                if (paymentStatus == desiredStatus) isStatusCompleted = true;
            }
        }

        [Fact]
        public async Task Create_invoice_deposit_payment()
        {
            var invoice = new Payments.Shared.V1.Deposit.Invoice
            {
                Customer = new Customer { City = "Örebro", Name = "Ludvig", PostalCode = "70341", StreetAddress = "Rostagatan 14" },
                Locale = SupportedLocales.sv_SE,
                TextFields = new TextFields
                {
                    Headline = "Kenguru",
                    SubText = new Dictionary<string, string>() { { "Animal", "that can jump" } }
                },
                Supplier = new Supplier { },
                Rows = new Row[] {
                    new Row {
                        Amount = 5.ToMinorCurrencyUnit(),
                        ArticleNumber = "12345678",
                        Quantity = 2,
                        Description = "Karins Lassange",
                        VatRate = SwedishVat.Vat25
                    }
                }
            };

            var paymentRequest = CreatePayment.PingDeposit.Invoice.Ocr
            (
                CurrencyEnum.SEK,
                orderItems: new OrderItem[]
                {
                    new OrderItem(10.ToMinorCurrencyUnit(), "A", SwedishVat.Vat25, TestData.MerchantId),
                },
                invoice: invoice,
                desiredDateOfPayment: DateTime.Today.AddDays(1)
            );
            var response = await _api.Payments.V1.Initiate(TestData.OrderId, paymentRequest);

            AssertHttpOK(response);
        }

        [Fact]
        public async Task Refund_payment_200()
        {

            //1. Create Payment
            var requestObject = CreatePayment.Dummy.New
            (
                CurrencyEnum.SEK,
                new OrderItem[]
                {
                    new OrderItem(5.ToMinorCurrencyUnit(), "A", SwedishVat.Vat25, TestData.MerchantId, null),
                },
                desiredPaymentStatus: PaymentStatusEnum.COMPLETED
            );
            var initiateResponse = await _api.Payments.V1.Initiate(TestData.OrderId, requestObject);
            AssertHttpOK(initiateResponse);

            var paymentID = initiateResponse.Body.SuccessfulResponseBody.Id;

            //2. await status completed
            var getResponse = await _api.Payments.V1.Get(TestData.OrderId, paymentID);
            AssertHttpOK(getResponse);

            var paymentStatus = getResponse.Body.SuccessfulResponseBody.Status;

            var isCompletd = await AwaitDesiredPaymentStatus(paymentStatus, PaymentStatusEnum.COMPLETED);
            Assert.True(isCompletd);

            //3. Initiate refund
            var refundRequest = new RefundRequest(
                5.ToMinorCurrencyUnit(),
                CurrencyEnum.SEK,
                RefundReasonEnum.fraudulent,
                "old lady got bamboozled"
            );

            var refundResponse = await _api.Payments.V1.Refund(TestData.OrderId, paymentID, refundRequest);


            AssertHttpOK(refundResponse);
            Assert.NotNull(refundResponse?.Body?.SuccessfulResponseBody);
            RefundResponseBody? body = refundResponse.Body.SuccessfulResponseBody;
            Assert.NotNull(body);
            Assert.Equal(body.Amount, 5.ToMinorCurrencyUnit());
            Assert.NotNull(body.Status);
            Assert.NotEmpty(body.Status);
        }

        public async Task<bool> AwaitDesiredPaymentStatus(PaymentStatusEnum paymentStatus, PaymentStatusEnum desiredPaymentStatus)
        {
            var tries = 0;
            var maxRetries = 3;
            var timeout = 1000;

            while (paymentStatus != desiredPaymentStatus || tries <= maxRetries)
            {
                var getResponse = await _api.Payments.V1.Get(TestData.OrderId, TestData.PaymentId);
                paymentStatus = getResponse.Body.SuccessfulResponseBody.Status;

                tries++;
                await Task.Delay(timeout);
            }
            return paymentStatus == desiredPaymentStatus ? true : false;
        }

        public async Task<(Guid orderId, PingDepositResponseBody depositResponse)> PreparePaymentOrderWithDepositPayment(int price, bool completeWhenFunded = true)
        {
            //Create a Payment Order
            var paymentOrderRequest = new CreatePaymentOrderRequest(CurrencyEnum.SEK);
            var paymentorderResponse = await _api.PaymentOrder.V1.Create(paymentOrderRequest);
            Guid orderId = paymentorderResponse.Body.SuccessfulResponseBody.Id;

            //Create a deposit Payment 
            var paymentRequest = CreatePayment.PingDeposit.Ocr
            (
                CurrencyEnum.SEK,
                orderItems: new OrderItem[]
                {
                    new OrderItem(price.ToMinorCurrencyUnit(), "A", SwedishVat.Vat25, TestData.MerchantId),
                },
                completeWhenFunded: completeWhenFunded

            );
            PingDepositResponseBody depositResponse = await _api.Payments.V1.Initiate(orderId, paymentRequest);

            return (orderId, depositResponse);
        }
#pragma warning restore CS8600 // Dereference of a possibly null reference
    }
}
