using System;

namespace Prometheus.Http.Querying.Expressions;

public sealed class RangeQuery : IRequest
{
    public string ExpressionQueryString { get; init; } = null!;

    public DateTimeOffset StartInclusive { get; init; }

    public DateTimeOffset EndInclusive { get; init; }

    public TimeSpan Step { get; init; } = TimeSpan.FromSeconds(30);

    #region Implementation
    Uri GetUrl(Uri baseUrl) => Detail.UrlBuilder.Create(baseUrl, "/api/v1/query_range",
        ("query", ExpressionQueryString),
        ("start", Detail.DateTimeFactory.ToUtcString(StartInclusive)),
        ("end", Detail.DateTimeFactory.ToUtcString(EndInclusive)),
        ("step", Step.TotalSeconds.ToString("0")));
    #endregion

    #region IRequest
    Uri IRequest.GetUrl(Uri baseUrl) => GetUrl(baseUrl);
    #endregion
}
