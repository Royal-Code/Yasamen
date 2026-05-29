# UIP-NAV-STEPPER_INDICATOR - Blueprint resumido

## Pattern

UIP-NAV-STEPPER_INDICATOR — Stepper Indicator — ver `uip-nav-stepper-indicator.ui-map.md`

## Gap coberto

A lib não tem componente de stepper de progresso. A indicação visual de etapas é construída com `Bar + Badge + CSS` para números de etapa + linha de conexão. O gap é orientar o padrão com os três estados (pendente, ativo, concluído) e a linha horizontal de progresso.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `Bar` com círculos CSS manuais + `Badge` para estado cobre o stepper; linha de conexão via `div` com `bg-light-200`/`bg-primary-400`.

## Componentes usados

- `Bar` — papel: principal (container do stepper) — ver `bar.sample.md`
- `Badge` — papel: composição (número/ícone de etapa) — ver `badge.sample.md`

## Recursos visuais

- `rounded-full w-8 h-8` — círculo de etapa
- `flex-1 h-px mx-2` — linha de conexão entre etapas
- `Themes.Primary` — etapa ativa; `Themes.Success` — etapa concluída; `Themes.Light` — pendente

## Receita

Círculos manuais com estado de cor + linha flex entre etapas; responsividade via `hidden sm:block` nos labels.

```razor
@code {
    private int etapaAtual = 2;

    private record Etapa(int Numero, string Label);
    private Etapa[] etapas =
    [
        new(1, "Dados"),
        new(2, "Revisão"),
        new(3, "Confirmação"),
    ];
}

<div class="flex items-center mb-8">
    @for (int i = 0; i < etapas.Length; i++)
    {
        var etapa = etapas[i];
        var concluida = etapaAtual > etapa.Numero;
        var ativa = etapaAtual == etapa.Numero;

        @* Linha de conexão antes da etapa (exceto a primeira) *@
        @if (i > 0)
        {
            <div class="flex-1 h-px @(concluida ? "bg-primary-400" : "bg-light-200") mx-2"></div>
        }

        <div class="flex flex-col items-center gap-1">
            @* Círculo de etapa *@
            <div class="w-8 h-8 rounded-full flex items-center justify-center text-sm font-bold
                        flex-shrink-0
                        @(concluida ? "bg-primary-500 text-white"
                          : ativa ? "bg-primary-100 text-primary-700 ring-2 ring-primary-500"
                          : "bg-light-100 text-dark-400 border border-light-300")">
                @if (concluida)
                {
                    <Icon Kind="WellKnownIcons.Check" />
                }
                else
                {
                    @etapa.Numero
                }
            </div>
            @* Label da etapa (oculto em telas pequenas) *@
            <span class="text-xs whitespace-nowrap hidden sm:block
                         @(ativa ? "text-primary-700 font-semibold"
                           : concluida ? "text-dark-500"
                           : "text-dark-400")">
                @etapa.Label
            </span>
        </div>
    }
</div>
```

## Limites

- Sem componente de stepper nativo — toda a renderização é HTML/CSS manual;
- Para uso em wizard, combinar com `Bar` de navegação Anterior/Próximo — ver `pp-wizard.blueprint.md`;
- Stepper vertical (para mobile ou sidebar) requer refatoração do layout de `flex items-center` para `flex-col`.
