using RoyalCode.Razor.Commons.Authentication;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Microsoft.AspNetCore.Components.Authorization;

/// <summary>
/// Extension methods for <see cref="AuthenticationState"/>.
/// </summary>
public static class AuthenticationStateExtensions
{
    /// <summary>
    /// Gets a value indicating whether the user is authenticated.
    /// </summary>
    /// <param name="authenticationState">The authentication state.</param>
    /// <returns>True if the user is authenticated; otherwise, false.</returns>
    public static bool IsAuthenticated([NotNullWhen(true)] this AuthenticationState? authenticationState)
    {
        return authenticationState?.User?.Identity is not null && authenticationState.User.Identity.IsAuthenticated;
    }

    /// <summary>
    /// Retrieves the subject name associated with the authenticated user, if available.
    /// </summary>
    /// <param name="authenticationState">
    ///     The authentication state to evaluate. If null or unauthenticated, the method returns null.
    /// </param>
    /// <returns>
    ///     The subject name of the authenticated user, 
    ///     or null if the user is not authenticated or the subject name is unavailable.
    /// </returns>
    public static string? GetSubject(this AuthenticationState? authenticationState)
    {
        return authenticationState.IsAuthenticated()
            ? authenticationState.User.Identity?.Name
            : null;
    }

    /// <summary>
    /// Retrieves the user's display name from the authentication state if the user is authenticated.
    /// </summary>
    /// <param name="authenticationState">
    ///     The authentication state to evaluate. If null or unauthenticated, the method returns null.
    /// </param>
    /// <returns>
    ///     The user's display name if the user is authenticated and the name claim is present; otherwise, null.
    /// </returns>
    public static string? GetDisplayName(this AuthenticationState? authenticationState)
    {
        return authenticationState.IsAuthenticated()
            ? authenticationState.User.FindFirst(WellKnownClaimNames.DisplayName)?.Value
                ?? authenticationState.User.FindFirst(WellKnownClaimNames.Name)?.Value
            : null;
    }

    /// <summary>
    /// Retrieves the id associated with the authenticated user, if available.
    /// </summary>
    /// <param name="authenticationState">
    ///     The authentication state to evaluate. If null or unauthenticated, the method returns null.
    /// </param>
    /// <returns>
    ///     The id as a string if the user is authenticated and an id claim is present;
    ///     otherwise, null.
    /// </returns>
    public static string? GetId(this AuthenticationState? authenticationState)
    {
        return authenticationState.IsAuthenticated()
            ? authenticationState.User.FindFirst(WellKnownClaimNames.Id)?.Value
            : null;
    }

    /// <summary>
    /// Retrieves the access token associated with the authenticated user, if available.
    /// </summary>
    /// <param name="authenticationState">
    ///     The authentication state to evaluate. If null or unauthenticated, the method returns null.
    /// </param>
    /// <returns>
    ///     The access token as a string if the user is authenticated and an access token claim is present;
    ///     otherwise, null.
    /// </returns>
    public static string? GetAccessToken(this AuthenticationState? authenticationState)
    {
        return authenticationState.IsAuthenticated()
            ? authenticationState.User.FindFirst(WellKnownClaimNames.AccessToken)?.Value
            : null;
    }

    /// <summary>
    /// Retrieves the id token associated with the authenticated user, if available.
    /// </summary>
    /// <param name="authenticationState">
    ///     The authentication state to evaluate. If null or unauthenticated, the method returns null.
    /// </param>
    /// <returns>
    ///     The id token as a string if the user is authenticated and an id token claim is present;
    ///     otherwise, null.
    /// </returns>
    public static string? GetIdToken(this AuthenticationState? authenticationState)
    {
        return authenticationState.IsAuthenticated()
            ? authenticationState.User.FindFirst(WellKnownClaimNames.IdToken)?.Value
            : null;
    }

    /// <summary>
    /// Retrieves the refresh token associated with the authenticated user, if available.
    /// </summary>
    /// <param name="authenticationState">
    ///     The authentication state to evaluate. If null or unauthenticated, the method returns null.
    /// </param>
    /// <returns>
    ///     The refresh token as a string if the user is authenticated and a refresh token claim is present;
    ///     otherwise, null.
    /// </returns>
    public static string? GetRefreshToken(this AuthenticationState? authenticationState)
    {
        return authenticationState.IsAuthenticated()
            ? authenticationState.User.FindFirst(WellKnownClaimNames.RefreshToken)?.Value
            : null;
    }

    /// <summary>
    /// Retrieves the expiration time associated with the authenticated user, if available.
    /// </summary>
    /// <param name="authenticationState">
    ///     The authentication state to evaluate. If null or unauthenticated, the method returns null.
    /// </param>
    /// <returns>
    ///     The expiration time as a DateTime if the user is authenticated and a expires at claim is present;
    ///     otherwise, null.
    /// </returns>
    public static DateTime? GetAccessTokenExpiration(this AuthenticationState? authenticationState)
    {
        if (authenticationState.IsAuthenticated())
        {
            var expiration = authenticationState.User.FindFirst(WellKnownClaimNames.ExpiresAt)?.Value;
            return DateTime.TryParse(expiration, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.AssumeLocal, out var result)
                ? result
                : null;
        }

        return null;
    }
}