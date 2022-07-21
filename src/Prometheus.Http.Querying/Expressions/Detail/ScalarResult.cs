namespace Prometheus.Http.Querying.Expressions.Detail;

sealed class ScalarResult : ExpressionQueryResult<ScalarValue>
{
    public ScalarResult(string resultType, ScalarValue result) : base(resultType, result) { }

    #region Overrides
    public override TResult Accept<TState, TResult>(IExpressionQueryResultVisitor<TState, TResult> visitor, TState state) => visitor.Visit(Result, state);
    #endregion
}
