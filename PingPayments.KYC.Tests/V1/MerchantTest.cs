using PingPayments.KYC.Merchant.V1.Get;
using PingPayments.KYC.Merchant.V1.Verification;
using PingPayments.KYC.Shared;


namespace PingPayments.KYC.Tests.V1
{
    public class MerchantTest : BaseResourceTests
    {
        [Fact]
        public async Task Get_specific_kyc_merchants_returns_200()
        {
            var request = new GetKycRequest
            {
                TenantId = TestData.TenantId,
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
                TenantId = TestData.TenantId,
                Page = 1,
                PageSize = 10,
                Type = LegalEntityTypeEnum.person
            };

            var response = await _api.Merchant.V1.Get(request);
            AssertHttpOK(response);
        }


        [Fact]
        public async Task Verification_returns_204()
        {
            var bankAccount = new BankAccount
            {
                Bic = "NDEASESS",
                Iban = "SE7280000810340009783242",
                Bban = "41971150033",
                Clearing = "6985"
            };
            var personData = new PersonData
            {
                Birthdate = "1985-12-24",
                Firstname = "Svante",
                Lastname = "Larsson",
                Identity = "198002015841",
                Gender = GenderEnum.male
            };

            var request = new KycVerificationRequest
                (
                    bankAccount,
                    "SE",
                    "name@provider.com",
                    TestData.MerchantId,
                    "Svante",
                    "0705555555",
                    TestData.TenantId,
                    LegalEntityTypeEnum.person,
                    personData
                );

            var response = await _api.Merchant.V1.Verification(request);
            AssertHttpNoContent(response);
        }

        [Fact]
        public async Task Verification_bad_request_returns_400()
        {
            var bankAccount = new BankAccount
            {
                Bic = "NDEASESS",
                Iban = "SE7280000810340009783242"
            };
            var personData = new PersonData
            {
                Birthdate = "1985-12-24",
                Firstname = "Svante",
                Lastname = "Larsson",
                Identity = "198002015841",
                Gender = GenderEnum.male
            };

            var request = new KycVerificationRequest
                (
                    bankAccount,
                    "SE",
                    "name@provider.com",
                    TestData.MerchantId,
                    "Svante",
                    "0705555555",
                    new Guid(),
                    LegalEntityTypeEnum.person,
                    personData
                );

            var response = await _api.Merchant.V1.Verification(request);
            AssertBadRequest(response);
        }
    }
}
