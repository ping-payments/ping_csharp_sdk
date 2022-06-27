using PingPayments.PaymentLinksApi.Payments.Shared.V1;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public class MethodEnumJsonConvert : JsonConverter<MethodEnum>
    {
        public override MethodEnum Read(ref Utf8JsonReader reader, Type _type, JsonSerializerOptions _options) =>
            reader.GetString()?.ToMethodEnum() ?? throw new InvalidOperationException("MethodEnum not parseable");

        public override void Write(Utf8JsonWriter writer, MethodEnum value, JsonSerializerOptions options) =>
            writer.WriteStringValue(value.Stringify());
    }
}
