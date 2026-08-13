using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Context7.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.Context7.HttpClients.Registrars;

/// <summary>
/// Registers the OpenAPI HttpClient wrapper for dependency injection.
/// </summary>
public static class Context7OpenApiHttpClientRegistrar
{
    /// <summary>
    /// Adds <see cref="Context7OpenApiHttpClient"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddContext7OpenApiHttpClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<IContext7OpenApiHttpClient, Context7OpenApiHttpClient>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="Context7OpenApiHttpClient"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddContext7OpenApiHttpClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddScoped<IContext7OpenApiHttpClient, Context7OpenApiHttpClient>();

        return services;
    }
}
