using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentLinksApi.PaymentLinks.Create.V1.Request
{
    public class ProviderMethodParametersJsonConvert : JsonConverter<ProviderMethodParameters>
    {
        public override ProviderMethodParameters? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
            throw new NotImplementedException("cannot be deserialized because base class is abstract!");

        public override void Write(Utf8JsonWriter writer, ProviderMethodParameters value, JsonSerializerOptions options) =>
                writer.WriteRawValue(JsonSerializer.Serialize(value.ToDictionary(), options));
    }
}
