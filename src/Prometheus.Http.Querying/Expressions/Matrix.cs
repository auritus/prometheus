using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Prometheus.Http.Querying.Expressions;

public sealed class Matrix
{
    [JsonPropertyName("metric")]
    public IReadOnlyDictionary<string, string> MetricLabels { get; init; }

    [JsonPropertyName("values")]
    public IReadOnlyList<StringValue> Values { get; init; }
}
