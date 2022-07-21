using System;

namespace Prometheus.Http.Querying.Expressions.Detail;

static class DateTimeFactory
{
    public static DateTime FromUnixTimeSeconds(double value) => DateTime.UnixEpoch.AddSeconds(value);

    public static string ToUtcString(in DateTime value) => value.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");

    public static string ToUtcString(in DateTimeOffset value) => value.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");
}
