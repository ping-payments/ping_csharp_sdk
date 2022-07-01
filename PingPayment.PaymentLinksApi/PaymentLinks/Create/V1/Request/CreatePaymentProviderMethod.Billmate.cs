
using PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1;

namespace PingPayments.PaymentLinksApi.PaymentLinks.Create.V1.Request
{
    public static partial class CreatePaymentProviderMethod
    {
        public static class Billmate
        {
            public static PaymentProviderMethod Invoice
                (
                    string firstName,
                    string lastName,
                    string nattionalIdNumber,
                    string email,
                    string phoneNumber,
                    string country,
                    string ipAddress,
                    string customerReference,
                    string isCompanyCustomer,
                    string? careOf = null,
                    string? freeText = null

                ) => new
                    (
                        MethodEnum.invoice,
                        ProviderEnum.billmate,
                        new BillmateParameters
                        (
                            firstName,
                            lastName,
                            nattionalIdNumber,
                            email,
                            phoneNumber,
                            country,
                            ipAddress,
                            customerReference,
                            isCompanyCustomer,
                            careOf,
                            freeText
                        )
                    );
        }
    }
}
