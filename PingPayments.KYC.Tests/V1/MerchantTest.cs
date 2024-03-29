﻿using PingPayments.KYC.Merchant.V1.AIS;
using PingPayments.KYC.Merchant.V1.Get;
using PingPayments.KYC.Merchant.V1.Verification;
using PingPayments.KYC.Shared;
using PingPayments.Tests;
using System;
using System.Runtime.CompilerServices;
using Xunit;


namespace PingPayments.KYC.Tests.V1
{
    public class MerchantTest : KYCApiTestClient
    {
        [Fact]
        public async Task Get_specific_kyc_merchants_returns_200()
        {
            var request = new GetKycRequest
            {
                MerchantId = TestData.MerchantId
            };
            var response = await _api.Merchant.V1.Get(request);
            AssertHttpOK(response);
        }

        [Fact]
        public async Task Get_List_of_kyc_merchants_returns_200()
        {
            var request = new GetKycRequest
            {
                Page = 1,
                PageSize = 10,
            };

            var response = await _api.Merchant.V1.Get(request);
            AssertHttpOK(response);
        }


        [Fact(Skip = "New merchant needs to be created each time")]
        public async Task Verification_returns_204()
        {
            var bankAccounts = new BankAccount[] {
                new BankAccount()
                {
                    Bic = "NDEASESS",
                    Iban = "SE7280000810340009783241",
                    Bban = "41971150033",
                    Clearing = "1985",
                    Plusgiro = "12345678",
                    Bankgiro = "17654321"
                }
            };
            var personData = new PersonData(
                identity: "198002015841",
                gender: GenderEnum.male,
                birthdate: "1985-12-24",
                firstname: "Svante",
                lastname: "Larsson");

            var request = new KycVerificationRequest
                (
                    bankAccounts: bankAccounts,
                    merchantId: TestData.MerchantId,
                    country: "SE",
                    email: "name@provider.com",
                    name: "Svante",
                    phone: "0705555555",
                    type: LegalEntityTypeEnum.person,
                    personData: personData
                );

            var response = await _api.Merchant.V1.Verification(request);
            AssertHttpNoContent(response);
        }

        [Fact(Skip = "New merchant needs to be created each time")]
        public async Task Verification_minimal_request_body_returns_204()
        {
            var bankAccounts = new BankAccount[] { };
            var personData = new PersonData(GenderEnum.male, "");

            var request = new KycVerificationRequest
                (
                    bankAccounts: bankAccounts,
                    merchantId: TestData.MerchantId,
                    country: "SE",
                    name: "Svante",
                    type: LegalEntityTypeEnum.person,
                    personData: personData
                );

            var response = await _api.Merchant.V1.Verification(request);
            AssertHttpNoContent(response);
        }

        [Fact]
        public async Task Verification_bad_request_returns_400()
        {
            var bankAccount = new BankAccount
            {
            };
            var personData = new PersonData(
                identity: "",
                gender: GenderEnum.male,
                birthdate: "1985-12-24",
                firstname: "Svante",
                lastname: "Larsson");

            var request = new KycVerificationRequest
                (
                    country: "SE",
                    email: "name@provider.com",
                    merchantId: TestData.MerchantId,
                    name: "Svante",
                    phone: "0705555555",
                    type: LegalEntityTypeEnum.person,
                    personData: personData
                );

            var response = await _api.Merchant.V1.Verification(request);
            AssertBadRequest(response);
        }

        [Fact]
        public async Task Ais_merchant_with_full_body_exept_redirects_return_200()
        {
            Style stylesObj = new()
            {
                BackgroundColor = "#47e331",
                FormBackgroundColor = "#44aacc",
                Primary = "#ffe7ec"
            };

            Distribution distributionObj = new()
            {
                EmailOptions = new EmailOptions() { Distribute = true, Originator = "originator" },
                SmsOptions = new SmsOptions() { Distribute = true, Message = "a message", Originator = "originator" }
            };
            var request = new AisMerchantRequest
            (
                merchantId: TestData.MerchantId,
                country: "SE",
                distribution: distributionObj,
                email: "test.mail@gmail.com",
                phoneNumber: "0701231212",
                psuId: "199412345676",
                style: stylesObj
            );

            var response = await _api.Merchant.V1.AIS(request);
            AssertHttpOK(response);
        }

        [Fact]
        public async Task Ais_merchant_entity_already_registered_returns_200()
        {
            var request = new AisMerchantRequest
            (
                merchantId: TestData.MerchantId,
                country: "SE",
                email: "test.mail@gmail.com",
                phoneNumber: "0701231212",
                psuId: "191111111111"
            );

            var response = await _api.Merchant.V1.AIS(request);
            AssertHttpOK(response);
        }
    }
}
