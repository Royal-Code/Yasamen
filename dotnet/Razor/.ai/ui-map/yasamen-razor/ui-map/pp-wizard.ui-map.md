# PP-WIZARD - Wizard

## Componentes por zona funcional

### Zona: Navegação (Stepper)

1. Bar + Badge manual (UIP-NAV-STEPPER_INDICATOR — GAP parcial)
- `cobertura`: indicador horizontal de etapas com números e labels; estado atual, concluído e pendente via CSS; sem componente nativo;
- `nota`: 3;
- `justificativa`: stepper manual funcional — composição de circles CSS + Bar.

### Zona: Conteúdo

1. EditForm + Stack + TextField (UIP-INPUT-FORM_FIELD_GROUP + UIP-INPUT-INPUT_FIELD)
- `cobertura`: conteúdo de cada etapa com campos de texto/senha e validação por `EditContext`; sem FormGroup — agrupamento via Stack + heading HTML; select e checkbox via Blazor nativo;
- `nota`: 7;
- `justificativa`: etapa de formulário funcional com TextField e composição manual.

2. Box (container de etapa)
- `cobertura`: card visual da etapa atual com borda e padding;
- `nota`: 8;
- `justificativa`: container da etapa com separação visual.

3. Feedback Style=Danger (UIP-FEEDBACK-ERROR_STATE)
- `cobertura`: erro de validação ao tentar avançar etapa inválida;
- `nota`: 8;
- `justificativa`: feedback de erro de etapa.

4. Feedback Style=Light + animate-pulse (UIP-FEEDBACK-LOADING_STATE)
- `cobertura`: loading entre etapas (submit assíncrono antes de avançar);
- `nota`: 6;
- `justificativa`: estado de processamento entre etapas.

### Zona: Ações

1. Bar + Button (UIP-ACTION-ACTION_BAR)
- `cobertura`: "Anterior" + "Próximo" / "Concluir"; desabilitado em processamento;
- `nota`: 9;
- `justificativa`: navegação de etapas — ações diretas de alta qualidade.

**Descartados**: nenhum.

## Composição completa da página

```razor
@page "/onboarding"
@code {
    private int etapaAtual = 1;
    private int totalEtapas = 4;
    private bool processando;
    private string? erroEtapa;
    private OnboardingDto model = new();

    private record EtapaInfo(int Numero, string Label);
    private EtapaInfo[] etapas =
    [
        new(1, "Dados básicos"),
        new(2, "Configurações"),
        new(3, "Revisão"),
        new(4, "Conclusão"),
    ];

    private bool PodeAvancar()
    {
        return etapaAtual switch
        {
            1 => !string.IsNullOrEmpty(model.Nome) && !string.IsNullOrEmpty(model.Email),
            2 => model.PlanoSelecionado is not null,
            3 => true,
            _ => false,
        };
    }

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
                await Service.ConcluirOnboardingAsync(model);
                etapaAtual++;
            }
            catch (Exception ex)
            {
                erroEtapa = $"Erro: {ex.Message}";
            }
            finally { processando = false; }
            return;
        }
        etapaAtual++;
    }

    private void Voltar() => etapaAtual = Math.Max(1, etapaAtual - 1);
}

@* Stepper de progresso *@
<div class="flex items-center mb-8">
    @foreach (var etapa in etapas)
    {
        var concluida = etapaAtual > etapa.Numero;
        var ativa = etapaAtual == etapa.Numero;
        @if (etapa.Numero > 1)
        {
            <div class="flex-1 h-px @(concluida ? "bg-primary-400" : "bg-light-200") mx-2"></div>
        }
        <div class="flex flex-col items-center gap-1">
            <div class="w-8 h-8 rounded-full flex items-center justify-center text-sm font-bold
                        @(concluida ? "bg-primary-500 text-white"
                          : ativa ? "bg-primary-100 text-primary-700 border-2 border-primary-500"
                          : "bg-light-100 text-dark-400 border border-light-300")">
                @if (concluida) { <span>✓</span> }
                else { <span>@etapa.Numero</span> }
            </div>
            <span class="text-xs @(ativa ? "text-primary-700 font-medium" : "text-dark-400")
                         hidden sm:block whitespace-nowrap">
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
                <TextField @bind-Value="model.Nome" Label="Nome" required />
                <TextField @bind-Value="model.Email" Label="E-mail" required />
            </Stack>
            break;

        case 2:
            <Stack Gap="Gaps.Medium">
                <p class="text-sm font-semibold text-dark-700">Configurações</p>
                @* [inferido] FieldSelect não existe — usar <InputSelect> Blazor *@
                <div class="flex flex-col gap-1">
                    <label class="text-sm font-medium text-dark-600">Plano</label>
                    <InputSelect @bind-Value="model.PlanoSelecionado"
                                 class="w-full border border-light-300 rounded-md px-3 py-2 text-sm bg-white">
                        @foreach (var opt in planosOptions)
                        {
                            <option value="@opt.Value">@opt.Label</option>
                        }
                    </InputSelect>
                </div>
                @* [inferido] FieldCheckbox não existe — usar <InputCheckbox> Blazor *@
                <div class="flex items-center gap-2">
                    <InputCheckbox @bind-Value="model.AceitouTermos" id="cb-termos"
                                   class="accent-primary-500" />
                    <label for="cb-termos" class="text-sm text-dark-600 cursor-pointer">
                        Aceito os termos de uso
                    </label>
                </div>
            </Stack>
            break;

        case 3:
            <div>
                <h3 class="text-base font-semibold text-dark-700 mb-3">Revisão</h3>
                <dl class="grid grid-cols-2 gap-x-4 gap-y-2 text-sm">
                    <dt class="text-dark-400">Nome</dt>
                    <dd class="text-dark-600 font-medium">@model.Nome</dd>
                    <dt class="text-dark-400">E-mail</dt>
                    <dd class="text-dark-600">@model.Email</dd>
                    <dt class="text-dark-400">Plano</dt>
                    <dd class="text-dark-600">@model.PlanoSelecionado</dd>
                </dl>
            </div>
            break;

        case 4:
            <div class="text-center py-4">
                <div class="w-16 h-16 rounded-full bg-success-100 flex items-center justify-center mx-auto mb-3">
                    <span class="text-success-600 text-2xl">✓</span>
                </div>
                <h3 class="text-lg font-semibold text-dark-700">Concluído!</h3>
                <p class="text-sm text-dark-400 mt-1">Seu cadastro foi realizado com sucesso.</p>
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
                    OnClick="Avancar"
                    Disabled="@processando" />
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

## Decisão de uso

- `nota geral`: 6;
- `limitações`: stepper nativo ausente — indicador de progresso é CSS manual; sem persistência de etapa entre navegações (browser back); sem URL por etapa nativamente (requer `NavigationManager` manual);
- `recomendação`: `usar por composição`
- `justificativa geral`:
  - `FormGroup` + `EditContext` por etapa + `Bar` de navegação cobrem wizard funcional;
  - Stepper CSS manual é a maior limitação, mas é suficiente para casos padrão;
  - Nota 6 reflete boa cobertura do conteúdo de cada etapa com adaptação no indicador de progresso.
