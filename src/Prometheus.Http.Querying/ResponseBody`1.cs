using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Prometheus.Http.Querying;

public sealed class ResponseBody<T> where T : class
{
    [JsonPropertyName("status")]
    public string Status { get; init; } = string.Empty;

    [JsonPropertyName("data")]
    public T? Data { get; init; }

    [JsonPropertyName("errorType")]
    public string? ErrorType { get; init; }

    [JsonPropertyName("error")]
    public string? Error { get; init; }

    [JsonPropertyName("warnings")]
    public IReadOnlyList<string>? Warnings { get; init; }
}
