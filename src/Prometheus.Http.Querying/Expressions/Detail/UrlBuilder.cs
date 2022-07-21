using System;
using System.Linq;

namespace Prometheus.Http.Querying.Expressions.Detail;

static class UrlBuilder
{
    public static Uri Create(
        Uri baseUrl,
        string path,
        params (string name, string value)[] values) =>
        values.Length switch
        {
            0 => new Uri(baseUrl, path),
            _ => new Uri(baseUrl, path + "?" + string.Join("&", values.Select(t => $"{t.name}={Uri.EscapeDataString(t.value)}"))),
        };
}
