namespace Prometheus.Http.Querying.Expressions.Detail;

sealed class StringResult : ExpressionQueryResult<StringValue>
{
    public StringResult(string resultType, StringValue result) : base(resultType, result) { }

    #region Overrides
    public override TResult Accept<TState, TResult>(IExpressionQueryResultVisitor<TState, TResult> visitor, TState state) => visitor.Visit(Result, state);
    #endregion
}
