using Microsoft.AspNetCore.Components;

namespace RoyalCode.Razor.Commons.Authentication;

/// <summary>
/// Exceção lançada quando o token de acesso do usuário não está disponível.
/// </summary>
public sealed class UserAccessTokenNotFoundException : Exception
{
    private readonly NavigationManager navigation;
    private readonly string signInPath;

    /// <summary>
    /// Cria uma nova instância do <see cref="UserAccessTokenNotFoundException"/>.
    /// </summary>
    /// <param name="navigation"></param>
    /// <param name="signInPath"></param>
    public UserAccessTokenNotFoundException(NavigationManager navigation, string signInPath)
        : base("Usuário não autenticado ou token de acesso não disponível durante a requisição")
    {
        this.navigation = navigation;
        this.signInPath = signInPath;
    }

    /// <summary>
    /// Aplica o redirecionamento para a página de login.
    /// </summary>
    public void RedirectToLogin()
    {
        navigation.NavigateTo(signInPath);
    }
}
