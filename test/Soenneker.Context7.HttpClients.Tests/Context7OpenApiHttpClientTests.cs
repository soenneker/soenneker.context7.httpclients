using Soenneker.Context7.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Context7.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class Context7OpenApiHttpClientTests : HostedUnitTest
{
    private readonly IContext7OpenApiHttpClient _httpclient;

    public Context7OpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<IContext7OpenApiHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
