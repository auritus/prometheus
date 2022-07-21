using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Prometheus.Http.Querying.Expressions;

public sealed class Vector
{
    [JsonPropertyName("metric")]
    public IReadOnlyDictionary<string, string> MetricLabels { get; init; }

    [JsonPropertyName("value")]
    public StringValue Value { get; init; }
}
