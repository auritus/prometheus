using Prom = Prometheus.Http;

using var client = new HttpClient();

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var baseUrl = new Uri("http://localhost:9090");
var query = new Prom.Querying.Expressions.RangeQuery()
{
    Step = TimeSpan.FromSeconds(30),
    EndInclusive = DateTimeOffset.UtcNow,
    StartInclusive = DateTimeOffset.UtcNow - TimeSpan.FromHours(24),
    ExpressionQueryString = "up"
};

var response = await Prom.Querying.RequestDispatcher.Get<Prom.Querying.Expressions.ExpressionQueryResult>(client, baseUrl, query);

Console.Write(0);
