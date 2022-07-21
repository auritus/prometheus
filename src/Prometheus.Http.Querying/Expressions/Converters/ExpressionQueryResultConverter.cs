using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Prometheus.Http.Querying.Expressions.Detail;

namespace Prometheus.Http.Querying.Expressions.Converters;

public sealed class ExpressionQueryResultConverter : JsonConverter<ExpressionQueryResult>
{
    #region Overrides
    public override ExpressionQueryResult? Read(ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options)
    {
        var resultType = string.Empty;

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.PropertyName)
            {
                var name = reader.GetString();

                if (!reader.Read())
                {
                    return null;
                }

                switch (name)
                {
                    case "resultType":
                        resultType = ReadResultType(ref reader, options);
                        continue;

                    case "result":
                        return ReaderExpressionQueryResult(ref reader, options, resultType);
                }
            }
        }

        return null;
    }

    public override void Write(Utf8JsonWriter writer, ExpressionQueryResult value, JsonSerializerOptions options) => throw new NotImplementedException();
    #endregion

    #region Implementation

    static ExpressionQueryResult? ReaderExpressionQueryResult(ref Utf8JsonReader reader, JsonSerializerOptions options, string resultType)
    {
        reader.Read();

        switch (resultType)
        {
            case ResultTypeStrings.Scalar:
            {
                if (ScalarValueConverter.Self.Read(ref reader, typeof(ScalarValue), options) is { } value)
                {
                    return new ScalarResult(resultType, value);
                }

                break;
            }
            case ResultTypeStrings.String:
            {
                if (StringValueConverter.Self.Read(ref reader, typeof(StringValue), options) is { } value)
                {
                    return new StringResult(resultType, value);
                }

                break;
            }
            case ResultTypeStrings.Vector:
            {
                return ReadVectorExpressionQueryResult(ref reader, options, resultType);
            }
            case ResultTypeStrings.Matrix:
            {
                return ReadMatrixExpressionQueryResult(ref reader, options, resultType);
            }
        }

        return null;
    }

    static IReadOnlyList<T> ReadArrayAs<T>(ref Utf8JsonReader reader, JsonSerializerOptions options)
    {
        var result = new List<T>();

        while (reader.TokenType != JsonTokenType.EndArray)
        {
            if (JsonSerializer.Deserialize<T>(ref reader, options) is { } value)
            {
                result.Add(value);
            }

            if (reader.TokenType == JsonTokenType.EndObject && reader.Read())
            {
                continue;
            }

            break;
        }

        reader.Read();
        return result;
    }

    static ExpressionQueryResult? ReadMatrixExpressionQueryResult(
        ref Utf8JsonReader reader, JsonSerializerOptions options, string resultType)
        => new MatrixResult(resultType, ReadArrayAs<Matrix>(ref reader, options));

    static ExpressionQueryResult? ReadVectorExpressionQueryResult(
        ref Utf8JsonReader reader, JsonSerializerOptions options, string resultType)
        => new VectorResult(resultType, ReadArrayAs<Vector>(ref reader, options));

    static string ReadResultType(ref Utf8JsonReader reader, JsonSerializerOptions options)
        => reader.GetString() ?? string.Empty;
    #endregion
}
