# PP-WIZARD - Blueprint completo

## Pattern

PP-WIZARD — Wizard — ver `pp-wizard.ui-map.md`

## Gap coberto

A lib não tem componente de stepper. O gap é coordenar: indicador de progresso por etapa em CSS manual (círculo + linha conectora + estado concluído/ativo/pendente), estado `etapaAtual` central, validação por etapa antes de avançar via `EditContext` ou verificação manual, submit assíncrono na penúltima etapa, e tela de conclusão.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: stepper CSS `div.flex.items-center` com círculos `div.w-8.h-8.rounded-full` e linha `div.flex-1.h-px` conectora; estado por etapa via comparação com `etapaAtual`; conteúdo de etapa via `@switch(etapaAtual)`; `Box(p-6)` como container de etapa; `Bar(Anterior/Próximo)` como controles de navegação; validação por `PodeAvancar()`.
- `eixos cobertos sem componente novo`:
  - indicador de progresso → HTML div + CSS (nenhum componente da lib);
  - conteúdo da etapa → `Box + Stack + TextField + InputSelect + InputCheckbox` Blazor;
  - ações de navegação → `Bar + Button(Anterior/Próximo/Concluir)`;
  - erro de validação → `Feedback(Danger)` acima do conteúdo da etapa;
  - loading entre etapas → `Button(Loading=true)` desabilitado.

## Componentes usados

- `Box` — papel: principal (container de etapa) — ver `box.sample.md`
- `Bar` — papel: composição (ações de navegação) — ver `bar.sample.md`
- `Stack` — papel: composição (campos dentro da etapa) — ver `bar.sample.md`
- `Button` — papel: composição (Anterior, Próximo, Concluir) — ver `button.sample.md`
- `TextField` — papel: composição (campos de texto nas etapas) — ver `field-text.sample.md`
- `Feedback` — papel: composição (erro de validação da etapa) — ver `feedback.sample.md`

## Recursos visuais

- `w-8 h-8 rounded-full flex items-center justify-center text-sm font-bold` — círculo da etapa
- `bg-primary-500 text-white` — etapa concluída
- `bg-primary-100 text-primary-700 border-2 border-primary-500` — etapa ativa
- `bg-light-100 text-dark-400 border border-light-300` — etapa pendente
- `flex-1 h-px mx-2` + cor condicional — linha conectora entre etapas
- `hidden sm:block whitespace-nowrap` — label da etapa oculto em mobile

## Receita

### Estrutura base

Wizard de 4 etapas com validação por etapa, submit assíncrono na última e tela de conclusão.

```razor
@page "/onboarding"
@inject NavigationManager Nav

@code {
    private int etapaAtual = 1;
    private readonly int totalEtapas = 4;
    private bool processando;
    private string? erroEtapa;
    private OnboardingDto model = new();

    private record EtapaInfo(int Numero, string Label);
    private readonly EtapaInfo[] etapas =
    [
        new(1, "Dados básicos"),
        new(2, "Configurações"),
        new(3, "Revisão"),
        new(4, "Conclusão"),
    ];

    private bool PodeAvancar() => etapaAtual switch
    {
        1 => !string.IsNullOrEmpty(model.Nome) && !string.IsNullOrEmpty(model.Email),
        2 => model.PlanoSelecionado is not null,
        3 => true,
        _ => false,
    };

    private async Task Avancar()
    {
        erroEtapa = null;
        if (!PodeAvancar())
        {
            erroEtapa = "Preencha todos os campos obrigatórios antes de continuar.";
            return;
        }
        if (etapaAtual == totalEtapas - 1)
        {
            processando = true;
            try
            {
                await Service.ConcluirAsync(model);
                etapaAtual++;
            }
            catch (Exception ex)
            {
                erroEtapa = $"Erro ao concluir: {ex.Message}";
            }
            finally { processando = false; }
            return;
        }
        etapaAtual++;
        erroEtapa = null;
    }

    private void Voltar()
    {
        if (etapaAtual > 1) etapaAtual--;
        erroEtapa = null;
    }
}

@* Stepper de progresso *@
<div class="flex items-center mb-8">
    @foreach (var etapa in etapas)
    {
        var concluida = etapaAtual > etapa.Numero;
        var ativa = etapaAtual == etapa.Numero;
        @if (etapa.Numero > 1)
        {
            <div class="flex-1 h-px mx-2 @(concluida ? "bg-primary-400" : "bg-light-200")"></div>
        }
        <div class="flex flex-col items-center gap-1">
            <div class="w-8 h-8 rounded-full flex items-center justify-center text-sm font-bold
                        @(concluida ? "bg-primary-500 text-white"
                          : ativa ? "bg-primary-100 text-primary-700 border-2 border-primary-500"
                          : "bg-light-100 text-dark-400 border border-light-300")">
                @if (concluida) { <span>✓</span> }
                else { <span>@etapa.Numero</span> }
            </div>
            <span class="text-xs hidden sm:block whitespace-nowrap
                         @(ativa ? "text-primary-700 font-medium" : "text-dark-400")">
                @etapa.Label
            </span>
        </div>
    }
</div>

@* Conteúdo da etapa *@
<Box Border="BorderBuilder.Box" AdditionalClasses="p-6 mb-6">
    @if (erroEtapa is not null)
    {
        <Feedback Style="Themes.Danger" Text="@erroEtapa" AdditionalClasses="mb-4" />
    }

    @switch (etapaAtual)
    {
        case 1:
            <Stack Gap="Gaps.Medium">
                <p class="text-sm font-semibold text-dark-700">Dados básicos</p>
                <TextField @bind-Value="model.Nome" Label="Nome completo" required />
                <TextField @bind-Value="model.Email" Label="E-mail" required />
            </Stack>
            break;

        case 2:
            <Stack Gap="Gaps.Medium">
                <p class="text-sm font-semibold text-dark-700">Configurações</p>
                <div class="flex flex-col gap-1">
                    <label class="text-sm font-medium text-dark-600">Plano</label>
                    <InputSelect @bind-Value="model.PlanoSelecionado"
                                 class="w-full border border-light-300 rounded-md px-3 py-2 text-sm bg-white">
                        <option value="">Selecione um plano...</option>
                        <option value="free">Gratuito</option>
                        <option value="pro">Pro</option>
                        <option value="enterprise">Enterprise</option>
                    </InputSelect>
                </div>
                <div class="flex items-center gap-2">
                    <InputCheckbox @bind-Value="model.AceitouTermos"
                                   id="cb-termos" class="accent-primary-500" />
                    <label for="cb-termos" class="text-sm text-dark-600 cursor-pointer">
                        Li e aceito os
                        <a href="/termos" class="text-primary-600 underline">termos de uso</a>
                    </label>
                </div>
            </Stack>
            break;

        case 3:
            <div>
                <p class="text-sm font-semibold text-dark-700 mb-4">Revisão dos dados</p>
                <dl class="grid grid-cols-1 sm:grid-cols-2 gap-x-6 gap-y-3 text-sm">
                    <div>
                        <dt class="text-xs text-dark-400 mb-0.5">Nome</dt>
                        <dd class="text-dark-600 font-medium">@model.Nome</dd>
                    </div>
                    <div>
                        <dt class="text-xs text-dark-400 mb-0.5">E-mail</dt>
                        <dd class="text-dark-600">@model.Email</dd>
                    </div>
                    <div>
                        <dt class="text-xs text-dark-400 mb-0.5">Plano</dt>
                        <dd class="text-dark-600">@model.PlanoSelecionado</dd>
                    </div>
                </dl>
            </div>
            break;

        case 4:
            <div class="text-center py-4">
                <div class="w-16 h-16 rounded-full bg-success-100 flex items-center
                            justify-center mx-auto mb-4">
                    <span class="text-success-600 text-3xl">✓</span>
                </div>
                <h3 class="text-lg font-semibold text-dark-700">Cadastro concluído!</h3>
                <p class="text-sm text-dark-400 mt-2">
                    Bem-vindo, @model.Nome. Sua conta foi criada com sucesso.
                </p>
            </div>
            break;
    }
</Box>

@* Ações de navegação *@
@if (etapaAtual < totalEtapas)
{
    <Bar>
        <StartContent>
            @if (etapaAtual > 1)
            {
                <Button Style="Themes.Default" Label="Anterior"
                        OnClick="Voltar" Disabled="@processando" />
            }
        </StartContent>
        <EndContent>
            <Button Style="Themes.Primary"
                    Label="@(etapaAtual == totalEtapas - 1 ? "Concluir" : "Próximo")"
                    Loading="@processando"
                    OnClick="Avancar" />
        </EndContent>
    </Bar>
}
else
{
    <Bar>
        <EndContent>
            <Button Style="Themes.Primary" Label="Ir para o início"
                    OnClick='() => Nav.NavigateTo("/")' />
        </EndContent>
    </Bar>
}
```

### Cenários de composição

#### Wizard com validação via EditContext por etapa

```razor
@code {
    private EditContext? contextoEtapa;

    protected override void OnInitialized()
        => AtualizarContexto();

    private void AtualizarContexto()
    {
        contextoEtapa = etapaAtual switch
        {
            1 => new EditContext(model.DadosBasicos),
            2 => new EditContext(model.Configuracoes),
            _ => null,
        };
    }

    private async Task AvancarComValidacao()
    {
        if (contextoEtapa is not null && !contextoEtapa.Validate())
        {
            erroEtapa = "Corrija os erros antes de continuar.";
            return;
        }
        etapaAtual++;
        AtualizarContexto();
    }
}
```

#### Wizard com URL por etapa

```razor
@page "/onboarding/{Etapa:int}"
@code {
    [Parameter] public int Etapa { get; set; }

    protected override void OnParametersSet()
        => etapaAtual = Math.Clamp(Etapa, 1, totalEtapas);

    private void AvancarComNavegacao()
    {
        if (!PodeAvancar()) return;
        Nav.NavigateTo($"/onboarding/{etapaAtual + 1}");
    }
}
```

### Estados de página

- `loading` entre etapas: `Button(Loading=true Disabled=true)` no botão "Próximo/Concluir";
- `erro de etapa`: `Feedback(Danger)` acima do `Box` da etapa, antes do conteúdo;
- `conclusão`: etapa final com ícone de sucesso `div.rounded-full.bg-success-100` + `h3` + link para início.

## Limites

- Stepper CSS não é nativo — reconstruir com HTML + classes Tailwind a cada wizard;
- Sem persistência entre navegações — pressionar "voltar" no browser perde o estado; usar URL por etapa para evitar;
- `InputSelect` e `InputCheckbox` não recebem estilo da lib — estilo Tailwind manual;
- Validação por etapa via `PodeAvancar()` é funcional mas frágil — preferir `EditContext.Validate()` para integração com DataAnnotations;
- Wizard com muitas etapas em mobile: ocultar labels do stepper com `hidden sm:block`.

### Responsividade

Mobile: labels do stepper ocultos (`hidden sm:block`), apenas números visíveis. Stepper horizontal funciona até ~4 etapas; para 5+ etapas considerar barra de progresso linear `div.h-1.bg-primary-500` com `width: @(etapaAtual / totalEtapas * 100)%`.
