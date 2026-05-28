# PP-AUTH - Authentication

## Componentes por zona funcional

### Zona: Cabeçalho (marca e título)

1. Box + HTML livre (logo e título do fluxo)
- `cobertura`: logo da aplicação, título "Entrar" / "Criar conta" / "Recuperar senha";
- `nota`: 7;
- `justificativa`: container do cabeçalho de autenticação.

### Zona: Conteúdo (credenciais)

1. TextField (UIP-INPUT-INPUT_FIELD)
- `cobertura`: campo de e-mail (`TextField` text com validação `[EmailAddress]`), senha (`Type="@InputType.Password"`), código de verificação;
- `nota`: 8;
- `justificativa`: captura de credenciais — cobertura sólida com TextField nativo.

2. HTML `<InputCheckbox>` + label (lembrar-me)
- `cobertura`: opção "Lembrar minha senha" via `<InputCheckbox @bind-Value>` Blazor + `<label>` HTML; sem estilização da biblioteca;
- `nota`: 5;
- `justificativa`: funcional mas requer HTML manual de label e estilo.

3. Feedback Style=Danger (UIP-FEEDBACK-ERROR_STATE)
- `cobertura`: "Credenciais inválidas", "Conta não encontrada", "Conta bloqueada";
- `nota`: 9;
- `justificativa`: erros de autenticação — excelente cobertura.

### Zona: Ações

1. Button Style=Primary (ação primária)
- `cobertura`: "Entrar" / "Criar conta" / "Redefinir senha"; loading durante processamento;
- `nota`: 9;
- `justificativa`: ação de autenticação.

2. HTML links (ações auxiliares)
- `cobertura`: "Esqueceu a senha?", "Criar conta", "Voltar ao login"; âncoras HTML com Tailwind;
- `nota`: 7;
- `justificativa`: navegação entre fluxos de autenticação.

### Zona: Integração Blazor

1. AuthorizeView + NavigationManager (redirect pós-login)
- `cobertura`: redirect para `/` ou URL originador após login bem-sucedido; proteção de rota;
- `nota`: 8;
- `justificativa`: ciclo completo de autenticação Blazor.

**Descartados**: nenhum.

## Composição completa da página

### Login

```razor
@page "/login"
@layout AuthLayout
@code {
    private LoginDto model = new();
    private string? erro;
    private bool processando;

    [SupplyParameterFromQuery(Name = "returnUrl")]
    private string? ReturnUrl { get; set; }

    private async Task Entrar()
    {
        erro = null;
        processando = true;
        try
        {
            var resultado = await AuthService.LoginAsync(model);
            if (resultado.Sucesso)
            {
                Nav.NavigateTo(ReturnUrl ?? "/", forceLoad: true);
                return;
            }
            erro = resultado.Mensagem ?? "Credenciais inválidas. Verifique e tente novamente.";
        }
        catch
        {
            erro = "Erro ao tentar autenticar. Tente novamente.";
        }
        finally { processando = false; }
    }
}

<div class="min-h-screen flex items-center justify-center bg-light-50 px-4">
    <div class="w-full max-w-sm">
        @* Logo *@
        <div class="text-center mb-8">
            <div class="w-12 h-12 rounded-xl bg-primary-500 mx-auto mb-4
                        flex items-center justify-center">
                <span class="text-white font-bold text-lg">A</span>
            </div>
            <h1 class="text-2xl font-bold text-dark-800">Entrar</h1>
            <p class="text-sm text-dark-400 mt-1">Acesse sua conta</p>
        </div>

        @* Formulário *@
        <Box Border="BorderBuilder.Box" AdditionalClasses="p-6">
            @if (erro is not null)
            {
                <Feedback Style="Themes.Danger" Text="@erro" AdditionalClasses="mb-4" />
            }

            <EditForm Model="model" OnValidSubmit="Entrar">
                <DataAnnotationsValidator />
                <Stack Gap="Gaps.Medium">
                    <TextField @bind-Value="model.Email" Label="E-mail"
                               Placeholder="voce@empresa.com" required />
                    <div>
                        <div class="flex justify-between items-center mb-1">
                            <label class="text-sm text-dark-600">Senha</label>
                            <a href="/esqueci-senha"
                               class="text-xs text-primary-600 hover:underline">
                                Esqueceu a senha?
                            </a>
                        </div>
                        <TextField @bind-Value="model.Senha" Type="@InputType.Password"
                                   Placeholder="Sua senha" required />
                    </div>
                    @* Checkbox "lembrar" — InputCheckbox Blazor + label manual *@
                    <div class="flex items-center gap-2">
                        <InputCheckbox @bind-Value="model.LembrarMe" id="cb-lembrar"
                                       class="accent-primary-500" />
                        <label for="cb-lembrar" class="text-sm text-dark-500 cursor-pointer">
                            Lembrar minha senha
                        </label>
                    </div>
                    <Button Style="Themes.Primary"
                            Label="@(processando ? "Entrando..." : "Entrar")"
                            Type="submit" Disabled="@processando"
                            AdditionalClasses="w-full justify-center" />
                </Stack>
            </EditForm>
        </Box>

        <p class="text-center text-sm text-dark-400 mt-4">
            Não tem conta?
            <a href="/registro" class="text-primary-600 hover:underline font-medium">
                Criar conta gratuita
            </a>
        </p>
    </div>
</div>
```

### Recuperação de senha

```razor
@page "/esqueci-senha"
@layout AuthLayout
@code {
    private string email = "";
    private bool enviado;
    private bool processando;

    private async Task Enviar()
    {
        processando = true;
        await AuthService.SolicitarRecuperacaoAsync(email);
        enviado = true;
        processando = false;
    }
}

<div class="min-h-screen flex items-center justify-center bg-light-50 px-4">
    <div class="w-full max-w-sm">
        <div class="text-center mb-8">
            <h1 class="text-2xl font-bold text-dark-800">Recuperar senha</h1>
            <p class="text-sm text-dark-400 mt-1">
                Informe seu e-mail para receber as instruções.
            </p>
        </div>

        <Box Border="BorderBuilder.Box" AdditionalClasses="p-6">
            @if (enviado)
            {
                <Feedback Style="Themes.Success"
                          Text="Instruções enviadas! Verifique seu e-mail." />
            }
            else
            {
                <EditForm Model="@this" OnValidSubmit="Enviar">
                    <Stack Gap="Gaps.Medium">
                        <TextField @bind-Value="email" Label="E-mail"
                                   Placeholder="seu@email.com" required />
                        <Button Style="Themes.Primary"
                                Label="@(processando ? "Enviando..." : "Enviar instruções")"
                                Type="submit" Disabled="@processando"
                                AdditionalClasses="w-full justify-center" />
                    </Stack>
                </EditForm>
            }
        </Box>

        <p class="text-center text-sm text-dark-400 mt-4">
            <a href="/login" class="text-primary-600 hover:underline">
                Voltar ao login
            </a>
        </p>
    </div>
</div>
```

## Decisão de uso

- `nota geral`: 8;
- `limitações`: sem botão OAuth (Google, Microsoft, GitHub) — requer HTML manual + JS; sem verificação visual de força de senha; sem input de código MFA com slots individuais; checkbox "lembrar" requer `<InputCheckbox>` Blazor + label HTML manual;
- `recomendação`: `usar por composição`
- `justificativa geral`:
  - `TextField` (`Type="@InputType.Password"`) + `Feedback Style=Danger` + `Button` + `Box` cobrem PP-AUTH com boa qualidade;
  - `AuthorizeView` + `NavigationManager` da plataforma Blazor completam o ciclo de autenticação;
  - Nota 8 reflete ótima cobertura — PP-AUTH é bem suportado pela lib para os casos padrão.
