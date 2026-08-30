[![](https://img.shields.io/nuget/v/soenneker.context7.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.context7.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.context7.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.context7.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.context7.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.context7.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.context7.httpclients/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.context7.httpclients/actions/workflows/codeql.yml)

# Soenneker.Context7.HttpClients

Provides a cached `HttpClient` configured for Context7's HTTP API.

## Install

```bash
dotnet add package Soenneker.Context7.HttpClients
```

## Configuration

```json
{
  "Context7": {
    "ApiKey": "ctx7sk-..."
  }
}
```

The default base address is `https://context7.com/api/`. Requests use `Authorization: Bearer <ApiKey>`, matching Context7's API-key authentication.

Optional settings:

| Key | Default | Purpose |
| --- | --- | --- |
| `Context7:ClientBaseUrl` | `https://context7.com/api/` | Replaces the service base address; a trailing slash is normalized automatically |
| `Context7:AuthHeaderName` | `Authorization` | Replaces the authentication header name |
| `Context7:AuthHeaderValueTemplate` | `Bearer {token}` | Formats the API key; `{token}` is replaced with `Context7:ApiKey` |

## Registration

```csharp
using Soenneker.Context7.HttpClients.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddContext7OpenApiHttpClientAsSingleton();
```

Use `AddContext7OpenApiHttpClientAsScoped()` when each dependency-injection scope should own a separate cached client entry.

## Usage

```csharp
using Soenneker.Context7.HttpClients.Abstract;

public sealed class Context7HealthCheck(IContext7OpenApiHttpClient clientProvider)
{
    public async ValueTask<HttpResponseMessage> Check(CancellationToken cancellationToken)
    {
        HttpClient client = await clientProvider.Get(cancellationToken);
        return await client.GetAsync("v2/libs/search?libraryName=react&query=hooks", cancellationToken);
    }
}
```

The wrapper lazily creates the client on the first `Get` call and returns that instance for the wrapper's lifetime. Configuration is read during creation; changing configuration later does not rebuild an already cached client.

## Practical notes

- Do not dispose the returned `HttpClient`; the wrapper owns it. Dependency injection disposes the wrapper at the end of its lifetime.
- The API key is attached as a default request header. Redact authorization headers in HTTP logs, traces, and exception diagnostics.
- This package configures transport only. It does not add retries, rate-limit handling, response caching, or generated API methods.
