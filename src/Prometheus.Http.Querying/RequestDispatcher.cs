using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Prometheus.Http.Querying;

public static class RequestDispatcher
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="client"></param>
    /// <param name="baseUrl"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="HttpRequestException">Thrown if the request could not be executed.</exception>
    public static async Task<ResponseBody<T>> Get<T>(HttpClient client, Uri baseUrl, IRequest request) where T : class
    {
        var url = request.GetUrl(baseUrl);
        var result = await client.GetAsync(url);

        result.EnsureSuccessStatusCode();
        return await result.Content.ReadFromJsonAsync<ResponseBody<T>>() ?? throw new IOException($"Failed to decode JSON into expected type {typeof(ResponseBody<T>)}");
    }
}
