using System.Text.Json.Serialization;
using Prometheus.Http.Querying.Expressions.Converters;

namespace Prometheus.Http.Querying.Expressions;

[JsonConverter(typeof(ExpressionQueryResultConverter))]
public abstract class ExpressionQueryResult
{
    public string ResultType { get; init; }

    public abstract TResult Accept<TState, TResult>(IExpressionQueryResultVisitor<TState, TResult> visitor, TState state);
}
