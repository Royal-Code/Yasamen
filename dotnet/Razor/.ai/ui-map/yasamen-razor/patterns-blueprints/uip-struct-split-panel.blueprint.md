# UIP-STRUCT-SPLIT_PANEL - Blueprint resumido

## Pattern

UIP-STRUCT-SPLIT_PANEL — Split Panel — ver `uip-struct-split-panel.ui-map.md`

## Gap coberto

A lib não oferece componente de layout split com dois painéis; a divisão é feita via `flex` CSS. O gap é orientar as combinações de classes para split assimétrico, responsividade e ocultação de painel em mobile.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: gap é estrutural CSS — flex 2-painel com tamanhos fixo/flexível; nenhum componente da lib adiciona valor sobre o HTML direto para este layout.

## Componentes usados

- `Bar` — papel: composição — ver `bar.sample.md` (headers internos de cada painel)
- `Box` — papel: composição — ver `box.sample.md` (container visual de painel)

## Recursos visuais

- `flex`, `flex-1`, `flex-shrink-0` — distribuição dos painéis
- `w-{n}`, `w-64`, `w-72`, `w-80` — largura fixa do painel lateral
- `hidden lg:flex`, `hidden md:flex` — ocultação responsiva
- `border-r border-light-200` — divisor entre painéis
- `overflow-hidden`, `overflow-y-auto` — scroll independente por painel

## Receita

Container `flex` com painel lateral de largura fixa e painel principal com `flex-1`; `overflow-hidden` no wrapper impede vazamento.

```razor
@* Split panel: painel fixo à esquerda + painel principal *@
<div class="flex h-full overflow-hidden border border-light-200 rounded-md">

    @* Painel lateral — largura fixa, oculto em mobile *@
    <div class="hidden lg:flex flex-col w-72 flex-shrink-0 border-r border-light-200">
        <Bar AdditionalClasses="px-4 py-3 border-b border-light-200 flex-shrink-0">
            <StartContent>
                <span class="text-sm font-semibold text-dark-700">Painel lateral</span>
            </StartContent>
        </Bar>
        <div class="flex-1 overflow-y-auto">
            @* conteúdo do painel lateral *@
        </div>
    </div>

    @* Painel principal — expande para o espaço restante *@
    <div class="flex-1 flex flex-col overflow-hidden">
        <Bar AdditionalClasses="px-4 py-3 border-b border-light-200 flex-shrink-0">
            <StartContent>
                <span class="text-sm font-semibold text-dark-700">Conteúdo principal</span>
            </StartContent>
        </Bar>
        <div class="flex-1 overflow-y-auto p-4">
            @* conteúdo principal *@
        </div>
    </div>
</div>

@* Split responsivo: mostrar/ocultar painel com estado C# *@
@code {
    private bool mostrarDetalhe;
}

<div class="flex h-full overflow-hidden">
    <div class="@(mostrarDetalhe ? "hidden lg:flex" : "flex") flex-col w-full lg:w-80 flex-shrink-0 border-r border-light-200">
        @* lista *@
    </div>
    <div class="@(mostrarDetalhe ? "flex" : "hidden lg:flex") flex-col flex-1 overflow-hidden">
        @* detalhe *@
    </div>
</div>
```

## Limites

- Divisor arrastável (resize) requer JS interop — não disponível na lib;
- Para split 3 painéis (explorador + canvas + inspector), ver `shp-studio-workbench.blueprint.md`.
