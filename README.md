[![](https://img.shields.io/nuget/v/soenneker.context7.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.context7.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.context7.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.context7.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.context7.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.context7.httpclients/)

# Soenneker.Context7.HttpClients

A .NET thread-safe singleton HttpClient for.

## Install

```bash
dotnet add package Soenneker.Context7.HttpClients
```

## Quick start

```csharp
using Soenneker.Context7.HttpClients.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddContext7OpenApiHttpClientAsSingleton();
```

Adds `Context7OpenApiHttpClient` as a singleton service.

## What you get

- `IContext7OpenApiHttpClient` — A .NET thread-safe singleton HttpClient for.
- `Context7OpenApiHttpClientRegistrar` — Registers the OpenAPI HttpClient wrapper for dependency injection.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `Context7OpenApiHttpClientRegistrar.AddContext7OpenApiHttpClientAsSingleton(services)` | Adds `Context7OpenApiHttpClient` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `Context7OpenApiHttpClientRegistrar.AddContext7OpenApiHttpClientAsScoped(services)` | Adds `Context7OpenApiHttpClient` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Reuse the registered client instead of constructing one per operation.
- Calls that return a cached or singleton value reuse the same instance until the owning service is disposed.
- Dispose instances you own when their scope ends so held resources can be released.
