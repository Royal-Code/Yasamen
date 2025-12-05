using RoyalCode.Razor.Commons.Authentication;
using RoyalCode.Razor.Commons.Modules;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extension methods for adding Yasamen services to the service collection.
/// </summary>
public static class YasamenServiceCollectionExtensions
{
    /// <summary>
    /// Adds Yasamen common services to the service collection.
    /// </summary>
    /// <param name="services">The service collection to add the services to.</param>
    /// <returns>The same instance of <paramref name="services"/> for chaining.</returns>
    public static IServiceCollection AddYasamenCommons(this IServiceCollection services)
    {
        services.AddTransient<ClickJs>();
        services.AddTransient<ElementJs>();
        services.AddTransient<FormsJs>();
        services.AddTransient<RippleJs>();

        return services;
    }

    /// <summary>
    /// <para>
    ///     Configures the HTTP client to automatically include authentication state in outgoing requests by adding the
    ///     AuthenticationStateDelegatingHandler to the message handler pipeline.
    /// </para>
    /// </summary>
    /// <remarks>
    ///     Use this method to ensure that authentication information is attached to each HTTP request
    ///     sent by the client. 
    ///     This is typically required when interacting with APIs that depend on the current user's 
    ///     authentication state.
    ///     If the AuthenticationStateDelegatingHandler is not already registered,
    ///     it will be added automatically.
    /// </remarks>
    /// <param name="builder">
    ///     The IHttpClientBuilder used to configure the HTTP client and its message handlers.
    /// </param>
    /// <returns>
    ///     The same IHttpClientBuilder instance, enabling further configuration of the HTTP client.
    /// </returns>
    public static IHttpClientBuilder AuthorizeWithAuthenticationState(this IHttpClientBuilder builder)
    {
        if (!builder.Services.Any(d => d.ServiceType == typeof(AuthenticationStateDelegatingHandler)))
            builder.Services.AddTransient<AuthenticationStateDelegatingHandler>();

        builder.AddHttpMessageHandler<AuthenticationStateDelegatingHandler>();

        return builder;
    }
}
