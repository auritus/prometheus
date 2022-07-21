using System.Text.Json;
using Prometheus.Http.Querying.Expressions;

namespace TestProject1;

public class ExpressionQueryResultConverterTests
{
    [Fact]
    public void ReadVectorExpressionQueryResult()
    {
        const string json = "  {\r\n      \"resultType\" : \"vector\",\r\n      \"result\" : [\r\n         {\r\n            \"metric\" : {\r\n               \"__name__\" : \"up\",\r\n               \"job\" : \"prometheus\",\r\n               \"instance\" : \"localhost:9090\"\r\n            },\r\n            \"value\": [ 1435781451.781, \"1\" ]\r\n         },\r\n         {\r\n            \"metric\" : {\r\n               \"__name__\" : \"up\",\r\n               \"job\" : \"node\",\r\n               \"instance\" : \"localhost:9100\"\r\n            },\r\n            \"value\" : [ 1435781451.781, \"0\" ]\r\n         }\r\n      ]\r\n   }";
        //var converter = new ExpressionQueryResultConverter();

        var result = JsonSerializer.Deserialize<ExpressionQueryResult>(json);
    }
}
