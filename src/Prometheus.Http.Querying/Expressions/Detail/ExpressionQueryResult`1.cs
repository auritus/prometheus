namespace Prometheus.Http.Querying.Expressions.Detail;

abstract class ExpressionQueryResult<T> : ExpressionQueryResult
{
    protected ExpressionQueryResult(string resultType, T result)
    {
        ResultType = resultType;
        Result = result;
    }

    public T Result { get; init; }
}
