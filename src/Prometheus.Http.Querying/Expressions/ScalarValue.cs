using System;
using System.Text.Json.Serialization;

namespace Prometheus.Http.Querying.Expressions;

[JsonConverter(typeof(Converters.ScalarValueConverter))]
public sealed class ScalarValue
{
    public DateTime Timestamp { get; init; }

    public double Value { get; init; }
}
