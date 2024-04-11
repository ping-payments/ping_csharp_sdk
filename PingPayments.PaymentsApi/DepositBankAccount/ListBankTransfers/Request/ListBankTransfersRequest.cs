using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PingPayments.PaymentsApi.DepositBankAccount.ListBankTransfer.Request.V1
{
    public record ListBankTransfersRequest(
        int? Limit = null,
        PaymentChannelEnum? PaymentChannel = null,
        bool? IsConnected = null,
        string? Reference = null,
        int? FromAmount = null,
        int? ToAmount = null,
        DateTime? FromBookingDate = null,
        DateTime? ToBookingDate = null
        )
    {
        public string ToFilterUrl()
        {
            StringBuilder filterUrl = new StringBuilder("?");

            PropertyInfo[] properties = GetType().GetProperties();
            foreach (var property in properties)
            {
                var filter = property.GetValue(this);
                var name = MapName(property.Name);

                if (filter != null)
                    filterUrl.Append($"{name}={filter}&");
            }
            if (filterUrl.Length > 1)
            {
                //Removes the last "&"
                filterUrl.Length--;
                var filter = filterUrl.ToString().ToLower();
                return filter;
            }
            return "";
        }

        private static readonly Dictionary<string, string> PropertyNameMappings = new Dictionary<string, string>
        {
            { "Limit", "limit" },
            { "PaymentChannel", "payment_channel" },
            { "Reference", "reference" },
            { "IsConnected", "is_connected" },
            { "FromAmount", "from_amount" },
            { "ToAmount", "to_amount" },
            { "FromBookingDate", "from_booking_date" },
            { "ToBookingDate", "to_booking_date" }
        };

        private string MapName(string name)
        {
            if (PropertyNameMappings.ContainsKey(name))
            {
                return PropertyNameMappings[name];
            }
            return name;
        }
    }
}
