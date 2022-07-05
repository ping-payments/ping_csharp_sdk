using PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentLinksApi.PaymentLinks.Create.V1.Request
{
    public class MethodEnumJsonConvert : JsonConverter<MethodEnum>
    {
        public override MethodEnum Read(ref Utf8JsonReader reader, Type _type, JsonSerializerOptions _options) =>
            reader.GetString()?.ToMethodEnum() ?? throw new InvalidOperationException("MethodEnum not parseable");

        public override void Write(Utf8JsonWriter writer, MethodEnum value, JsonSerializerOptions options) =>
            writer.WriteStringValue(value.Stringify());
    }
}
