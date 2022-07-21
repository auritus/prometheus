using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Prometheus.Http.Querying.Expressions.Detail;

namespace Prometheus.Http.Querying.Expressions.Converters;

public sealed class ScalarValueConverter : JsonConverter<ScalarValue>
{
    internal static JsonConverter<ScalarValue> Self { get; } = new ScalarValueConverter();

    #region Overrides

    public override ScalarValue? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
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

        var value = reader.GetDouble();

        reader.Read();
        return new ScalarValue()
        {
            Value = value,
            Timestamp = timestamp,
        };
    }

    public override void Write(Utf8JsonWriter writer, ScalarValue value, JsonSerializerOptions options) => throw new NotImplementedException();

    #endregion
}
