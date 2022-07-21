using System.Collections.Generic;

namespace Prometheus.Http.Querying.Expressions.Detail;

sealed class MatrixResult : ExpressionQueryResult<IReadOnlyList<Matrix>>
{
    public MatrixResult(string resultType, IReadOnlyList<Matrix> result) : base(resultType, result) { }

    #region Overrides
    public override TResult Accept<TState, TResult>(IExpressionQueryResultVisitor<TState, TResult> visitor, TState state) => visitor.Visit(Result, state);
    #endregion
}
