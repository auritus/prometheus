using System.Collections.Generic;

namespace Prometheus.Http.Querying.Expressions;

public interface IExpressionQueryResultVisitor<in TState, out TResult>
{
    TResult Visit(IReadOnlyList<Matrix> result, TState state);
    TResult Visit(IReadOnlyList<Vector> result, TState state);
    TResult Visit(ScalarValue result, TState state);
    TResult Visit(StringValue result, TState state);
}
