# PP-SETTINGS - Settings

## Componentes por zona funcional

### Zona: Navegação

1. Breadcrumb (UIP-NAV-BREADCRUMB)
- `cobertura`: localização dentro da hierarquia de configurações;
- `nota`: 9;
- `justificativa`: orientação de navegação nas configurações.

2. Nav lateral manual (seções de settings)
- `cobertura`: lista de links de seção na sidebar; item ativo realçado; `Stack` + links HTML;
- `nota`: 5;
- `justificativa`: navegação entre seções — sem componente de nav vertical dedicado.

### Zona: Conteúdo

1. Stack + Box (seções de configuração)
- `cobertura`: cada seção com Box + título HTML + Stack de campos; divisão visual de grupos de configuração;
- `nota`: 8;
- `justificativa`: container de seção de configuração.

2. EditForm + TextField (UIP-INPUT-INPUT_FIELD)
- `cobertura`: campos de configuração de texto/senha; sem FormGroup — agrupamento via Box + heading manual;
- `nota`: 8;
- `justificativa`: campos de configuração — boa cobertura para texto.

3. HTML `<InputSelect>` + `<InputCheckbox>` (preferências)
- `cobertura`: seleção de opções (tema, idioma, formato) via `<InputSelect>` Blazor; toggles via `<InputCheckbox>` + label manual; sem estilização da biblioteca;
- `nota`: 4;
- `justificativa`: funcional mas sem estilo da lib — requer HTML manual de label e classes Tailwind.

4. Seções colapsáveis (configurações avançadas)
- `cobertura`: configurações avançadas ou opcionais colapsáveis via Box + Bar + `@if`;
- `nota`: 5;
- `justificativa`: progressive disclosure de configurações menos usadas.

### Zona: Ações

1. Bar + Button (UIP-ACTION-ACTION_BAR)
- `cobertura`: "Salvar alterações" + "Cancelar" / "Restaurar padrões"; sticky no topo ou fixo no final;
- `nota`: 9;
- `justificativa`: ações de configuração — direto.

2. NotificationService (UIP-FEEDBACK-TOAST_ALERT)
- `cobertura`: "Configurações salvas com sucesso" / "Erro ao salvar";
- `nota`: 9;
- `justificativa`: feedback de salvamento.

3. Modal (confirmação de reset)
- `cobertura`: "Restaurar configurações padrão — tem certeza?";
- `nota`: 9;
- `justificativa`: confirmação de ação destrutiva nas configurações.

**Descartados**: nenhum.

## Composição completa da página

```razor
@page "/configuracoes/{Secao?}"
@code {
    [Parameter] public string? Secao { get; set; }
    private string secaoAtiva => Secao ?? "perfil";

    private ConfiguracoesDto model = new();
    private bool salvando;
    private bool confirmandoReset;

    private record SecaoMenu(string Id, string Label, string Href);
    private SecaoMenu[] secoes =
    [
        new("perfil", "Perfil", "/configuracoes/perfil"),
        new("conta", "Conta e segurança", "/configuracoes/conta"),
        new("notificacoes", "Notificações", "/configuracoes/notificacoes"),
        new("aparencia", "Aparência", "/configuracoes/aparencia"),
        new("integrações", "Integrações", "/configuracoes/integracoes"),
    ];

    private async Task Salvar()
    {
        salvando = true;
        try
        {
            await Service.SalvarAsync(model, secaoAtiva);
            NotificationService.Show("Configurações salvas.", Themes.Success);
        }
        catch
        {
            NotificationService.Show("Erro ao salvar.", Themes.Danger);
        }
        finally { salvando = false; }
    }
}

<div class="flex gap-6">
    @* Navegação lateral *@
    <nav class="w-52 shrink-0 hidden lg:block">
        <Stack Gap="Gaps.None">
            @foreach (var secao in secoes)
            {
                <a href="@secao.Href"
                   class="flex items-center gap-2 px-3 py-2 text-sm rounded-md transition-colors
                          @(secaoAtiva == secao.Id
                            ? "bg-primary-50 text-primary-700 font-medium"
                            : "text-dark-500 hover:bg-light-50")">
                    @secao.Label
                </a>
            }
        </Stack>
    </nav>

    @* Conteúdo da seção *@
    <div class="flex-1 min-w-0">
        <Bar AdditionalClasses="mb-6">
            <StartContent>
                <div>
                    <Breadcrumb Items='new[] { ("Configurações", "/configuracoes"), (secaoAtiva, null) }' />
                    <h1 class="text-lg font-semibold text-dark-700 mt-1">
                        @secoes.FirstOrDefault(s => s.Id == secaoAtiva)?.Label
                    </h1>
                </div>
            </StartContent>
            <EndContent>
                <Button Style="Themes.Default" Size="Sizes.Small" Label="Restaurar padrões"
                        OnClick="() => confirmandoReset = true" />
            </EndContent>
        </Bar>

        <EditForm Model="model" OnValidSubmit="Salvar">
            <DataAnnotationsValidator />

            @switch (secaoAtiva)
            {
                case "perfil":
                    <Stack Gap="Gaps.Medium">
                        <Box Border="BorderBuilder.Box" AdditionalClasses="p-5">
                            <p class="text-sm font-semibold text-dark-700 mb-4">Dados pessoais</p>
                            <div class="grid grid-cols-1 sm:grid-cols-2 gap-4">
                                <TextField @bind-Value="model.Nome" Label="Nome" required />
                                <TextField @bind-Value="model.Email" Label="E-mail" required />
                                <TextField @bind-Value="model.Telefone" Label="Telefone" />
                            </div>
                        </Box>
                        <Box Border="BorderBuilder.Box" AdditionalClasses="p-5">
                            <p class="text-sm font-semibold text-dark-700 mb-2">Foto de perfil</p>
                            <p class="text-xs text-dark-400 mb-3">
                                Formatos aceitos: JPG, PNG. Máximo 2MB.
                            </p>
                            <Button Style="Themes.Default" Label="Alterar foto" />
                        </Box>
                    </Stack>
                    break;

                case "notificacoes":
                    <Box Border="BorderBuilder.Box" AdditionalClasses="p-5">
                        <p class="text-sm font-semibold text-dark-700 mb-4">
                            Preferências de notificação
                        </p>
                        @* InputCheckbox Blazor + label manual *@
                        <Stack Gap="Gaps.Small">
                            <div class="flex items-center gap-2">
                                <InputCheckbox @bind-Value="model.EmailNovidades"
                                               id="cb-novidades" class="accent-primary-500" />
                                <label for="cb-novidades" class="text-sm text-dark-600 cursor-pointer">
                                    Receber novidades por e-mail
                                </label>
                            </div>
                            <div class="flex items-center gap-2">
                                <InputCheckbox @bind-Value="model.EmailAlertas"
                                               id="cb-alertas" class="accent-primary-500" />
                                <label for="cb-alertas" class="text-sm text-dark-600 cursor-pointer">
                                    Alertas críticos por e-mail
                                </label>
                            </div>
                            <div class="flex items-center gap-2">
                                <InputCheckbox @bind-Value="model.PushAtivado"
                                               id="cb-push" class="accent-primary-500" />
                                <label for="cb-push" class="text-sm text-dark-600 cursor-pointer">
                                    Notificações push no navegador
                                </label>
                            </div>
                        </Stack>
                    </Box>
                    break;

                case "aparencia":
                    <Box Border="BorderBuilder.Box" AdditionalClasses="p-5">
                        <p class="text-sm font-semibold text-dark-700 mb-4">Tema e exibição</p>
                        @* InputSelect Blazor + label manual *@
                        <Stack Gap="Gaps.Medium">
                            <div class="flex flex-col gap-1">
                                <label class="text-sm font-medium text-dark-600">Tema</label>
                                <InputSelect @bind-Value="model.Tema"
                                             class="w-full border border-light-300 rounded-md px-3 py-2 text-sm bg-white">
                                    <option value="light">Claro</option>
                                    <option value="dark">Escuro</option>
                                    <option value="system">Sistema</option>
                                </InputSelect>
                            </div>
                            <div class="flex flex-col gap-1">
                                <label class="text-sm font-medium text-dark-600">Idioma</label>
                                <InputSelect @bind-Value="model.Idioma"
                                             class="w-full border border-light-300 rounded-md px-3 py-2 text-sm bg-white">
                                    @foreach (var idioma in idiomasOptions)
                                    {
                                        <option value="@idioma.Value">@idioma.Label</option>
                                    }
                                </InputSelect>
                            </div>
                            <div class="flex flex-col gap-1">
                                <label class="text-sm font-medium text-dark-600">Formato de data</label>
                                <InputSelect @bind-Value="model.FormatoData"
                                             class="w-full border border-light-300 rounded-md px-3 py-2 text-sm bg-white">
                                    <option value="dd/MM/yyyy">DD/MM/AAAA</option>
                                    <option value="MM/dd/yyyy">MM/DD/AAAA</option>
                                </InputSelect>
                            </div>
                        </Stack>
                    </Box>
                    break;
            }

            @* Ações *@
            <Bar AdditionalClasses="mt-6">
                <EndContent>
                    <Button Style="Themes.Default" Label="Cancelar"
                            OnClick="() => Nav.NavigateTo(\"/\")" />
                    <Button Style="Themes.Primary"
                            Label="@(salvando ? "Salvando..." : "Salvar")"
                            Type="submit" Disabled="@salvando" />
                </EndContent>
            </Bar>
        </EditForm>
    </div>
</div>

@* Confirmação de reset *@
<Modal Title="Restaurar padrões" @bind-IsOpen="confirmandoReset" Size="ModalSize.Small">
    <ChildContent>
        <p class="text-sm text-dark-600">
            Todas as configurações desta seção serão restauradas para os valores padrão.
        </p>
    </ChildContent>
    <FooterContent>
        <Button Style="Themes.Default" Label="Cancelar"
                OnClick="() => confirmandoReset = false" />
        <Button Style="Themes.Danger" Label="Restaurar"
                OnClick="ResetarSecao" />
    </FooterContent>
</Modal>
```

## Decisão de uso

- `nota geral`: 7;
- `limitações`: sem FormGroup — agrupamento via Box + heading HTML manual; sem nav vertical dedicado para seções — tabs horizontal (GAP) ou nav CSS manual; select e checkbox sem estilização nativa (usar Blazor `<InputSelect>` e `<InputCheckbox>` com classes Tailwind manuais);
- `recomendação`: `usar por composição`
- `justificativa geral`:
  - `TextField` + `Box` + `Stack` + `Bar` cobrem PP-SETTINGS com boa qualidade;
  - Navegação lateral é CSS manual simples — adequado para a maioria dos casos;
  - Nota 7 reflete ótima cobertura de conteúdo com adaptação no agrupamento e nas preferências de select/checkbox.
