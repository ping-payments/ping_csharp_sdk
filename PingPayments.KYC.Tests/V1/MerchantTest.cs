using PingPayments.KYC.Merchant.V1.Get;
using PingPayments.KYC.Merchant.V1.Verification;
using PingPayments.KYC.Shared;


namespace PingPayments.KYC.Tests.V1
{
    public class MerchantTest : BaseResourceTests
    {
        [Fact]
        public async Task Get_merchants_returns_200()
        {
            var request = new GetMerchantKycRequest
            {
                TenantId = TestData.TenantId,
                MerchantId = TestData.MerchantId
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
                Iban = "SE7280000810340009783242"
            };
            var personData = new PersonData
            {
                Birthdate = "1985-12-24",
                Firstname = "Svante",
                Lastname = "Larsson",
                Identity = "198002015841",
                Gender = "male"
            };

            var request = new MerchantKycVerificationRequest
                (
                    bankAccount,
                    "SE",
                    "name@provider.com",
                    TestData.MerchantId,
                    "Svante",
                    "0705555555",
                    TestData.TenantId,
                    "person",
                    personData
                );

            var response = await _api.Merchant.V1.Verification(request);
            AssertHttpNoContent(response);
        }
    }
}
