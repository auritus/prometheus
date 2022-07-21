using System.Collections.Generic;

namespace Prometheus.Http.Querying.Expressions.Detail;

sealed class VectorResult : ExpressionQueryResult<IReadOnlyList<Vector>>
{
    public VectorResult(string resultType, IReadOnlyList<Vector> result) : base(resultType, result) { }

    #region Overrides
    public override TResult Accept<TState, TResult>(IExpressionQueryResultVisitor<TState, TResult> visitor, TState state) => visitor.Visit(Result, state);
    #endregion
}
