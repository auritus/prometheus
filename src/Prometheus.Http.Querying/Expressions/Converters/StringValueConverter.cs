using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Prometheus.Http.Querying.Expressions.Detail;

namespace Prometheus.Http.Querying.Expressions.Converters;

public sealed class StringValueConverter : JsonConverter<StringValue>
{
    internal static JsonConverter<StringValue> Self { get; } = new StringValueConverter();

    #region Overrides

    public override StringValue? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartArray || reader.Read() == false)
        {
            return null;
        }

        var timestamp = DateTimeFactory.FromUnixTimeSeconds(reader.GetDouble());

        if (reader.Read() == false)
        {
            return default;
        }

        var value = reader.GetString() ?? string.Empty;

        reader.Read();
        return new StringValue()
        {
            Value = value,
            Timestamp = timestamp,
        };
    }

    public override void Write(Utf8JsonWriter writer, StringValue value, JsonSerializerOptions options) => throw new NotImplementedException();

    #endregion
}
