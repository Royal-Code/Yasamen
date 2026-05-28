# UIP-SYSTEM-AUTH_SESSION - Auth Session

**GAP parcial — sem componente dedicado**

A biblioteca não tem componente de gerenciamento de sessão. O tratamento de sessão expirada é responsabilidade do app (ASP.NET Core Authentication, Blazor AuthenticationStateProvider). A lib contribui com os overlays de reauth e feedback de erro de autorização.

## Componentes

**Principais**: nenhum dedicado.

**Composição**:

1. Modal
- `cobertura`: overlay de reautenticação inline sem perder contexto da tela atual; formulário de reauth com `FieldText` (senha) + `Button` ("Confirmar");
- `nota`: 7;
- `justificativa`: container de reauth modal — preserva contexto da tela sem redirect completo.

2. Feedback (Themes.Warning / Themes.Danger)
- `cobertura`: mensagem de sessão expirada, permissão insuficiente ou erro de autorização contextual;
- `nota`: 6;
- `justificativa`: feedback visual de estado de autorização.

3. Button
- `cobertura`: CTA "Fazer login novamente", "Ir para login", "Reautenticar";
- `nota`: 8;
- `justificativa`: ação de resolução do estado de sessão expirada.

**Descartados**: nenhum.

## Esforço de adaptação

- `tipo de adaptação`: composição — lógica de sessão é do framework
- `o que precisa ser feito`:
  - Blazor `AuthenticationStateProvider` + `[Authorize]` cuida do redirect para login;
  - Para reauth modal (sem redirect): `Modal` com campo de senha + chamada API de reauth;
  - Para sessão expirada com mensagem: `Feedback Warning` + `Button "Fazer login"`;
  - Silent refresh de tokens é responsabilidade do servidor/middleware — não da lib.

## Como usar

### Feedback de sessão expirada com redirect

```razor
@* Blazor AuthorizeView e CascadingAuthenticationState cobrem o caso padrão *@
<AuthorizeView>
    <Authorized>
        @ChildContent
    </Authorized>
    <NotAuthorized>
        <Feedback Style="Themes.Warning" 
                  Text="Sua sessão expirou. Faça login novamente para continuar."
                  AdditionalClasses="m-4" />
        <div class="text-center mt-4">
            <Button Style="Themes.Primary" Label="Fazer login"
                    OnClick="() => Navigation.NavigateTo("/login?returnUrl=" + Uri.EscapeDataString(Navigation.Uri))" />
        </div>
    </NotAuthorized>
</AuthorizeView>
```

### Modal de reautenticação inline

```razor
@code {
    private string senha = "";
    private bool reautenticando = false;
    private string? erroReauth;
}

<Modal Id="reauth-modal" Title="Confirme sua identidade">
    <ChildContent>
        <Stack Gap="Gaps.Medium">
            @if (erroReauth is not null)
            {
                <Feedback Style="Themes.Danger" Text="@erroReauth" />
            }
            <FieldText @bind-Value="senha" Type="password"
                       Label="Senha" Placeholder="Digite sua senha" />
            <Bar>
                <EndContent>
                    <Button Style="Themes.Secondary" Outline=true Label="Cancelar"
                            OnClick="() => ModalService.CloseAsync("reauth-modal")" />
                    <Button Style="Themes.Primary" Label="Confirmar"
                            Loading="@reautenticando" OnClick="Reautenticar" />
                </EndContent>
            </Bar>
        </Stack>
    </ChildContent>
</Modal>
```

## Decisão de uso

- `nota geral`: 3;
- `limitações`: sem componente de session management nativo; toda lógica de sessão é do ASP.NET Core + Blazor AuthenticationStateProvider; a lib contribui apenas com Modal e Feedback para os overlays de reauth;
- `recomendação`: `usar com adaptação`
- `justificativa geral`:
  - O framework Blazor (AuthorizeView, AuthenticationStateProvider) cobre o gerenciamento de sessão;
  - `Modal` + `Feedback` + `Button` cobrem os overlays visuais de reauth e feedback de expiração;
  - Nota 3 reflete que a lib contribui apenas com primitivos visuais — a lógica é do framework.
