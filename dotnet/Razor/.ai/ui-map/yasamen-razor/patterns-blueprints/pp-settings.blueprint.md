# PP-SETTINGS - Blueprint resumido

## Pattern

PP-SETTINGS — Settings Page — ver `pp-settings.ui-map.md`

## Gap coberto

A lib cobre bem os campos e ações. O gap é orientar: nav lateral de seções com realce ativo via `NavLink` CSS, `@switch` por seção no conteúdo, `Box + Stack` para grupos de configuração, e confirmação de reset via `Modal`.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: nav lateral CSS com `NavLink + active` para seções; `@switch(secao)` para conteúdo; `Box + TextField + InputCheckbox/InputSelect` por seção; `NotificationService` para feedback de save; `Modal` para confirmação de reset.

## Componentes usados

- `Box` — papel: composição (container de grupo de configuração) — ver `box.sample.md`
- `Stack` — papel: composição (campos dentro do grupo) — ver `bar.sample.md`
- `Bar` — papel: composição (header da página e ações) — ver `bar.sample.md`
- `TextField` — papel: composição (campos de texto) — ver `field-text.sample.md`
- `Button` — papel: composição (salvar/cancelar/restaurar) — ver `button.sample.md`
- `Modal` — papel: composição (confirmação de reset) — ver `modal.sample.md`

## Recursos visuais

- `bg-primary-50 text-primary-700 font-medium` — seção ativa na nav lateral
- `text-dark-500 hover:bg-light-50` — seção inativa na nav lateral
- `w-52 shrink-0 hidden lg:block` — nav lateral visível apenas em desktop

## Receita

Nav lateral CSS + `@switch` por seção + `Box + Stack + TextField` para grupos + `Modal` de confirmação.

```razor
@page "/configuracoes/{Secao?}"
@inject NavigationManager Nav
@inject NotificationService NotificationService

@code {
    [Parameter] public string? Secao { get; set; }
    private string SecaoAtiva => Secao ?? "perfil";
    private ConfiguracoesDto model = new();
    private bool salvando;

    private record SecaoMenu(string Id, string Label, string Href);
    private SecaoMenu[] secoes =
    [
        new("perfil", "Perfil", "/configuracoes/perfil"),
        new("conta", "Conta e segurança", "/configuracoes/conta"),
        new("notificacoes", "Notificações", "/configuracoes/notificacoes"),
        new("aparencia", "Aparência", "/configuracoes/aparencia"),
    ];

    private async Task Salvar()
    {
        salvando = true;
        try
        {
            await Service.SalvarAsync(model, SecaoAtiva);
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
    @* Nav lateral (desktop) *@
    <nav class="w-52 shrink-0 hidden lg:block">
        <Stack Gap="Gaps.None">
            @foreach (var s in secoes)
            {
                <a href="@s.Href"
                   class="flex items-center gap-2 px-3 py-2 text-sm rounded-md transition-colors
                          @(SecaoAtiva == s.Id
                            ? "bg-primary-50 text-primary-700 font-medium"
                            : "text-dark-500 hover:bg-light-50")">
                    @s.Label
                </a>
            }
        </Stack>
    </nav>

    @* Conteúdo da seção *@
    <div class="flex-1 min-w-0">
        <Bar AdditionalClasses="mb-6">
            <StartContent>
                <h1 class="text-lg font-semibold text-dark-700">
                    @secoes.FirstOrDefault(s => s.Id == SecaoAtiva)?.Label
                </h1>
            </StartContent>
            <EndContent>
                <Button Style="Themes.Default" Size="Sizes.Small" Label="Restaurar padrões"
                        OnClick="ConfirmarReset" />
            </EndContent>
        </Bar>

        <EditForm Model="model" OnValidSubmit="Salvar">
            <DataAnnotationsValidator />

            @switch (SecaoAtiva)
            {
                case "perfil":
                    <Box Border="BorderBuilder.Box" AdditionalClasses="p-5">
                        <p class="text-sm font-semibold text-dark-700 mb-4">Dados pessoais</p>
                        <div class="grid grid-cols-1 sm:grid-cols-2 gap-4">
                            <TextField @bind-Value="model.Nome" Label="Nome" required />
                            <TextField @bind-Value="model.Email" Label="E-mail" required />
                        </div>
                    </Box>
                    break;

                case "notificacoes":
                    <Box Border="BorderBuilder.Box" AdditionalClasses="p-5">
                        <p class="text-sm font-semibold text-dark-700 mb-4">
                            Preferências de notificação
                        </p>
                        <Stack Gap="Gaps.Small">
                            <div class="flex items-center gap-2">
                                <InputCheckbox @bind-Value="model.EmailNovidades"
                                               id="cb-nov" class="accent-primary-500" />
                                <label for="cb-nov"
                                       class="text-sm text-dark-600 cursor-pointer">
                                    Receber novidades por e-mail
                                </label>
                            </div>
                            <div class="flex items-center gap-2">
                                <InputCheckbox @bind-Value="model.PushAtivado"
                                               id="cb-push" class="accent-primary-500" />
                                <label for="cb-push"
                                       class="text-sm text-dark-600 cursor-pointer">
                                    Notificações push no navegador
                                </label>
                            </div>
                        </Stack>
                    </Box>
                    break;

                case "aparencia":
                    <Box Border="BorderBuilder.Box" AdditionalClasses="p-5">
                        <p class="text-sm font-semibold text-dark-700 mb-4">Tema e exibição</p>
                        <div class="flex flex-col gap-1">
                            <label class="text-sm font-medium text-dark-600">Tema</label>
                            <InputSelect @bind-Value="model.Tema"
                                         class="w-full border border-light-300 rounded-md px-3 py-2 text-sm bg-white">
                                <option value="light">Claro</option>
                                <option value="dark">Escuro</option>
                                <option value="system">Sistema</option>
                            </InputSelect>
                        </div>
                    </Box>
                    break;
            }

            <Bar AdditionalClasses="mt-6">
                <EndContent>
                    <Button Style="Themes.Default" Label="Cancelar"
                            OnClick='() => Nav.NavigateTo("/")' />
                    <Button Style="Themes.Primary" Label="Salvar"
                            Type="submit" Loading="@salvando" />
                </EndContent>
            </Bar>
        </EditForm>
    </div>
</div>
```

## Limites

- Sem nav vertical dedicada — a lista de `<a>` com CSS de estado ativo é a alternativa funcional;
- Para mobile: substituir nav lateral por `ButtonGroup` de tabs horizontal ou `<select>` de seção;
- `InputCheckbox` e `InputSelect` não têm estilo da lib — divergência visual em relação ao `TextField`.
