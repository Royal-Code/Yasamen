namespace RoyalCode.Razor.Commons.Authentication;

/// <summary>
/// Endpoint routes for authentication.
/// </summary>
public static class AuthenticationEndpointRoutes
{
    /// <summary>
    /// <para>
    ///     The path for the login endpoint. Defaults to "/signin".
    /// </para>
    /// <para>
    ///     Only set this if you want to change the default path, and change this in the application startup.
    /// </para>
    /// </summary>
    public static string SignInPath { get; set; } = "/signin";

    /// <summary>
    /// <para>
    ///     The path for the logout endpoint. Defaults to "/signout".
    /// </para>
    /// <para>
    ///     Only set this if you want to change the default path, and change this in the application startup.
    /// </para>
    /// </summary>
    public static string SignOutPath { get; set; } = "/signout";
}
