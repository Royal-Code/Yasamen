# UIP-OVERLAY-TOOLTIP - Blueprint resumido

## Pattern

UIP-OVERLAY-TOOLTIP — Tooltip — ver `uip-overlay-tooltip.ui-map.md`

## Gap coberto

A lib não tem componente de tooltip. O gap é orientar as três alternativas por cenário: atributo `title` (fallback), CSS puro via Tailwind `group`, e substituição por help icon + popover para conteúdo longo.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: para ajuda em formulários preferir texto inline; para ícones sem rótulo usar `group relative` + `span group-hover:opacity-100`; para conteúdo rico substituir por popover (ver `uip-overlay-popover.blueprint.md`).

## Componentes usados

- `IconButton` — papel: composição (trigger de ajuda) — ver `button.sample.md`
- `Box` — papel: composição (container de popover alternativo) — ver `box.sample.md`

## Recursos visuais

- `group relative inline-block` — âncora do tooltip via CSS hover
- `opacity-0 group-hover:opacity-100 transition-opacity delay-300` — aparição com delay
- `bg-dark-700 text-white text-xs rounded` — estilo visual do tooltip
- `pointer-events-none z-50` — tooltip não bloqueia eventos e fica acima do conteúdo
- `border-4 border-transparent border-t-dark-700` — seta triangular CSS

## Receita

Três estratégias por cenário; texto inline é a preferida para formulários.

```razor
@* Estratégia 1: tooltip CSS puro via Tailwind group (ícones e controles) *@
<div class="group relative inline-block">
    <IconButton Icon="WellKnownIcons.Info" Style="Themes.Default" Size="Sizes.Small" />

    <div class="absolute bottom-full left-1/2 -translate-x-1/2 mb-1 px-2 py-1
                bg-dark-700 text-white text-xs rounded whitespace-nowrap
                opacity-0 group-hover:opacity-100 transition-opacity delay-300
                pointer-events-none z-50">
        Clique para mais informações
        <div class="absolute top-full left-1/2 -translate-x-1/2 border-4
                    border-transparent border-t-dark-700"></div>
    </div>
</div>

@* Estratégia 2: atributo title HTML (fallback sem estilo — para campos simples) *@
<span title="Formato: DD/MM/AAAA">
    <FieldText @bind-Value="data" Label="Data" Placeholder="DD/MM/AAAA" />
</span>

@* Estratégia 3 (preferida para formulários): texto de ajuda inline *@
<div class="flex flex-col gap-1">
    <FieldText @bind-Value="cpf" Label="CPF" Placeholder="000.000.000-00" />
    <p class="text-xs text-dark-400 mt-0.5">Somente números, sem pontos ou traços.</p>
</div>

@* Estratégia 4: help icon + popover para conteúdo longo *@
@code { private bool helpAberto; }

<div class="flex items-center gap-1">
    <label class="text-sm text-dark-600">Coeficiente</label>
    <div class="relative">
        <button class="text-dark-300 hover:text-dark-500 text-xs leading-none"
                @onclick="() => helpAberto = !helpAberto"
                @onclick:stopPropagation>?</button>
        @if (helpAberto)
        {
            <div class="fixed inset-0 z-20" @onclick="() => helpAberto = false"></div>
            <div class="absolute left-0 top-full mt-1 z-30 w-48" @onclick:stopPropagation>
                <Box Border="BorderBuilder.Box"
                     AdditionalClasses="p-2 shadow-lg bg-white text-xs text-dark-500">
                    Valor entre 0,8 e 1,2. Padrão: 1,0.
                </Box>
            </div>
        }
    </div>
</div>
```

## Limites

- Tooltip CSS com `group-hover` não funciona em mobile (sem hover) — substituir por help icon clicável;
- `pointer-events-none` impede links ou botões dentro do tooltip — para conteúdo interativo usar popover;
- Sem acessibilidade automática (`aria-describedby`, `role="tooltip"`) — adicionar manualmente se necessário;
- Para muitos tooltips na mesma tela, o custo de markup de cada `group relative` é alto — considerar texto inline.
