using Newtonsoft.Json.Linq;
using Prometheus.Http.Querying.Expressions;

namespace TestProject1;

public class StringValueConverterTests
{
    [Fact]
    public void ReadVectorResult()
    {
        var json = "{ \"value\": [ 1435781451.781, \"A\" ], \"metric\": {} }";
        var result = System.Text.Json.JsonSerializer.Deserialize<Vector>(json);
    }
}