# UIP-SYSTEM-AUTH_SESSION - Blueprint resumido

## Pattern

UIP-SYSTEM-AUTH_SESSION — Auth Session — ver `uip-system-auth-session.ui-map.md`

## Gap coberto

A lib não tem componente de gerenciamento de sessão. O gap é orientar: `AuthorizeView` + `Feedback(Warning) + Button` para sessão expirada com redirect, e `Modal` com `TextField(Password)` para reautenticação inline sem perder contexto.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `AuthorizeView(NotAuthorized)` com `Feedback(Warning)` + `Button("Fazer login")` para fluxo padrão Blazor; `Modal` + `TextField(Password)` para reauth inline em fluxos que preservam contexto.

## Componentes usados

- `Feedback` — papel: principal (estado de sessão expirada/permissão insuficiente) — ver `feedback.sample.md`
- `Modal` — papel: composição (reauth inline) — ver `modal.sample.md`
- `TextField` — papel: composição (campo de senha no reauth) — ver `field-text.sample.md`
- `Button` — papel: composição (CTAs de login/confirmar) — ver `button.sample.md`

## Recursos visuais

- `AuthorizeView(Policy="...")` — controle de acesso granular por policy
- `Feedback(Themes.Warning)` — sessão expirada
- `Feedback(Themes.Danger)` — acesso negado/permissão insuficiente

## Receita

`AuthorizeView` para fluxo padrão; `Modal + TextField + Button` para reauth inline.

```razor
@inject NavigationManager Navigation

@* Fluxo padrão: AuthorizeView com feedback de sessão expirada *@
<AuthorizeView>
    <Authorized>
        @ChildContent
    </Authorized>
    <NotAuthorized>
        <Feedback Style="Themes.Warning" AdditionalClasses="m-4">
            <ChildContent>
                <p class="text-sm font-medium">Sessão expirada</p>
                <p class="text-xs mt-0.5">Faça login novamente para continuar.</p>
            </ChildContent>
        </Feedback>
        <div class="text-center mt-4">
            <Button Style="Themes.Primary" Label="Fazer login"
                    OnClick='() => Navigation.NavigateTo(
                        "/login?returnUrl=" + Uri.EscapeDataString(Navigation.Uri))' />
        </div>
    </NotAuthorized>
</AuthorizeView>

@* Acesso negado por permissão insuficiente *@
<AuthorizeView Policy="AdminOnly">
    <Authorized>
        @AdminContent
    </Authorized>
    <NotAuthorized>
        <Feedback Style="Themes.Danger"
                  Text="Você não tem permissão para acessar esta seção." />
    </NotAuthorized>
</AuthorizeView>

@* Reautenticação inline (sem redirect — preserva contexto) *@
@inject ModalService ModalService

@code {
    private string senha = "";
    private bool reautenticando;
    private string? erroReauth;

    private async Task Reautenticar()
    {
        reautenticando = true;
        erroReauth = null;
        var sucesso = await AuthService.ReautenticarAsync(senha);
        reautenticando = false;
        if (sucesso)
            await ModalService.CloseAsync("reauth-modal");
        else
            erroReauth = "Senha incorreta. Tente novamente.";
    }
}

<Modal Id="reauth-modal" Title="Confirme sua identidade">
    <ChildContent>
        <Stack Gap="Gaps.Medium">
            <p class="text-sm text-dark-500">
                Por segurança, confirme sua senha para continuar.
            </p>
            @if (erroReauth is not null)
            {
                <Feedback Style="Themes.Danger" Text="@erroReauth" />
            }
            <TextField @bind-Value="senha"
                       Type="InputType.Password"
                       Label="Senha" Placeholder="Digite sua senha" />
            <Bar>
                <EndContent>
                    <Button Style="Themes.Secondary" Outline=true Label="Cancelar"
                            OnClick="() => ModalService.CloseAsync("reauth-modal")" />
                    <Button Style="Themes.Primary" Label="Confirmar"
                            Loading="@reautenticando"
                            OnClick="Reautenticar" />
                </EndContent>
            </Bar>
        </Stack>
    </ChildContent>
</Modal>
```

## Limites

- `AuthorizeView` requer `CascadingAuthenticationState` no `App.razor` — pré-requisito do Blazor;
- Silent refresh de tokens JWT é responsabilidade do servidor/middleware (ex.: cookie deslizante) — não da lib;
- Para proteção de rotas completas preferir `[Authorize]` no componente de página ao invés de `AuthorizeView` por seção.
