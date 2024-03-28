using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PingPayments.PaymentsApi.DepositBankAccount.ListBankTransfer.Request.V1
{
    public record ListBankTransfersRequest(
        string? reference,
        PaymentChannelEnum? paymentChannel,
        bool? isConnected,
        int? fromAccount,
        int? toAmount,
        DateTime? fromBookingDate,
        DateTime? toBookingDate
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

                filterUrl.Append($"{name}={filter}&");
            }
            if (filterUrl.Length > 1)
            {
                //Removes the last "&"
                filterUrl.Length--;
                return filterUrl.ToString();
            }
            return "";
        }

        private static readonly Dictionary<string, string> PropertyNameMappings = new Dictionary<string, string>
        {
            { "PaymentChannel", "payment_channel" },
            { "IsConnected", "is_connected" },
            { "FromAccount", "from_account" },
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
