using System;

namespace Prometheus.Http.Querying;

public interface IRequest
{
    Uri GetUrl(Uri baseUrl);
}
