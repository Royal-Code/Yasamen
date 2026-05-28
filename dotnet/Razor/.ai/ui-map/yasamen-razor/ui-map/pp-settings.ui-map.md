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
- `cobertura`: cada seção com Box+title+FormGroup; Stack vertical de seções;
- `nota`: 8;
- `justificativa`: container de seção de configuração.

2. FormGroup + FieldText/FieldSelect/FieldCheckbox (UIP-INPUT-FORM_FIELD_GROUP)
- `cobertura`: parâmetros de configuração em grupos com legend;
- `nota`: 9;
- `justificativa`: campos de configuração — cobertura excelente.

3. uip-struct-collapsible-section (seções avançadas/ocultas)
- `cobertura`: configurações avançadas ou opcionais colapsáveis;
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
    <nav class="w-52 flex-shrink-0 hidden lg:block">
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
                            <FormGroup Legend="Dados pessoais">
                                <div class="grid grid-cols-1 sm:grid-cols-2 gap-4">
                                    <FieldText @bind-Value="model.Nome" Label="Nome" Required />
                                    <FieldText @bind-Value="model.Email" Label="E-mail"
                                               Type="email" Required />
                                    <FieldText @bind-Value="model.Telefone" Label="Telefone" />
                                </div>
                            </FormGroup>
                        </Box>
                        <Box Border="BorderBuilder.Box" AdditionalClasses="p-5">
                            <FormGroup Legend="Foto de perfil">
                                <p class="text-xs text-dark-400 mb-2">
                                    Formatos aceitos: JPG, PNG. Máximo 2MB.
                                </p>
                                <Button Style="Themes.Default" Label="Alterar foto" />
                            </FormGroup>
                        </Box>
                    </Stack>
                    break;

                case "notificacoes":
                    <Box Border="BorderBuilder.Box" AdditionalClasses="p-5">
                        <FormGroup Legend="Preferências de notificação">
                            <FieldCheckbox @bind-Value="model.EmailNovidades"
                                           Label="Receber novidades por e-mail" />
                            <FieldCheckbox @bind-Value="model.EmailAlertas"
                                           Label="Alertas críticos por e-mail" />
                            <FieldCheckbox @bind-Value="model.PushAtivado"
                                           Label="Notificações push no navegador" />
                        </FormGroup>
                    </Box>
                    break;

                case "aparencia":
                    <Box Border="BorderBuilder.Box" AdditionalClasses="p-5">
                        <FormGroup Legend="Tema e exibição">
                            <FieldSelect @bind-Value="model.Tema" Label="Tema"
                                         Options='new[] { ("light","Claro"), ("dark","Escuro"), ("system","Sistema") }' />
                            <FieldSelect @bind-Value="model.Idioma" Label="Idioma"
                                         Options="idiomasOptions" />
                            <FieldSelect @bind-Value="model.FormatoData" Label="Formato de data"
                                         Options='new[] { ("dd/MM/yyyy","DD/MM/AAAA"), ("MM/dd/yyyy","MM/DD/AAAA") }' />
                        </FormGroup>
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
- `limitações`: sem componente de nav vertical dedicado para settings — tabs horizontal (GAP) ou nav CSS manual; `EditContext` separado por seção requer lógica de switch; busca de configuração é manual;
- `recomendação`: `usar por composição`
- `justificativa geral`:
  - `FormGroup` + `FieldText/Select/Checkbox` + `Box` + `Bar` cobrem PP-SETTINGS com excelente qualidade;
  - Navegação lateral é CSS manual simples — adequado para a maioria dos casos;
  - Nota 7 reflete ótima cobertura de conteúdo com adaptação na navegação lateral.
