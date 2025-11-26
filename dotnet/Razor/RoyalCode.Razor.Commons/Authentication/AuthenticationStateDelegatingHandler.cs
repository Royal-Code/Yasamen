using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Options;
using RoyalCode.Razor.Styles;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace RoyalCode.Razor.Commons.Authentication;

internal class AuthenticationStateDelegatingHandler : DelegatingHandler
{
    private static readonly AuthenticationState NoAuthenticated = new AuthenticationState(new ClaimsPrincipal());
    private static readonly Func<Task<AuthenticationState>> DefaultAuthenticationStateAccessor =
        () => Task.FromResult(NoAuthenticated);

    private readonly Func<Task<AuthenticationState>> authenticationStateAccessor;
    private readonly NavigationManager navigationManager;
    private readonly IOptions<AuthenticationOptions> options;

    /// <summary>
    /// Cria uma nova instância do AuthenticationStateHandlerHttpHandler.
    /// </summary>
    /// <param name="authenticationStateAccessor"></param>
    /// <param name="navigationManager"></param>
    /// <param name="options"></param>
    public AuthenticationStateDelegatingHandler(
        NavigationManager navigationManager,
        IOptions<AuthenticationOptions> options,
        Func<Task<AuthenticationState>>? authenticationStateAccessor = null)
    {
        this.authenticationStateAccessor = authenticationStateAccessor ?? DefaultAuthenticationStateAccessor;
        this.navigationManager = navigationManager;
        this.options = options;
    }

    /// <inheritdoc />
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var authState = await authenticationStateAccessor();
        if (authState is not null)
        {
            var accessToken = authState.GetAccessToken();
            if (accessToken.IsPresent())
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }
            else
            {
                throw new UserAccessTokenNotFoundException(navigationManager, options.Value.SignInPath);
            }
        }

        return await base.SendAsync(request, cancellationToken);
    }

    /// <inheritdoc />
    protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        AuthenticationState? authState;
        var task = authenticationStateAccessor();
        if (task.Status == TaskStatus.RanToCompletion)
        {
            authState = task.Result;
        }
        else
        {
            authState = Task.Run(async () => await task).GetAwaiter().GetResult();
        }
        if (authState is not null)
        {
            var accessToken = authState.GetAccessToken();
            if (accessToken.IsPresent())
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }
            else
            {
                throw new UserAccessTokenNotFoundException(navigationManager, options.Value.SignInPath);
            }
        }

        return base.Send(request, cancellationToken);
    }
}
