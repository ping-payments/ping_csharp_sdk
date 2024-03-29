﻿using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public record SwishECommerceParameters
    (
        string Message,
        string PhoneNumber
    ) : ProviderMethodParameters
    {
        public override Dictionary<string, dynamic> ToDictionary() => new()
        {
            { "message", Message ?? "" },
            { "phone_number", PhoneNumber }
        };
    }
}
