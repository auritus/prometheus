using System;
using System.Text.Json.Serialization;

namespace Prometheus.Http.Querying.Expressions;

[JsonConverter(typeof(Converters.StringValueConverter))]
public sealed class StringValue
{
    public DateTime Timestamp { get; init; }

    public string Value { get; init; }
}
