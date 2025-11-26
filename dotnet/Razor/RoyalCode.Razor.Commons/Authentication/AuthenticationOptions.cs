namespace RoyalCode.Razor.Commons.Authentication;

/// <summary>
/// Options for configuring authentication endpoints.
/// </summary>
public class AuthenticationOptions
{
    /// <summary>
    /// Gets or sets the path for the sign-in endpoint.
    /// </summary>
    public string SignInPath { get; set; } = AuthenticationEndpointRoutes.SignInPath;

    /// <summary>
    /// Gets or sets the path for the sign-out endpoint.
    /// </summary>
    public string SignOutPath { get; set; } = AuthenticationEndpointRoutes.SignOutPath;
}
