# UIP-STRUCT-COLLAPSIBLE_SECTION - Blueprint resumido

## Pattern

UIP-STRUCT-COLLAPSIBLE_SECTION — Collapsible Section — ver `uip-struct-collapsible-section.ui-map.md`

## Gap coberto

A lib não tem componente Accordion/Collapse dedicado. A seção colapsável é construída com `Bar` (header clicável) + `Box` (conteúdo) + `bool` de estado C#. O gap é orientar o padrão de composição e as variantes (grupo de seções, ícone de seta).

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: gap localizado — Bar + @if/hidden + bool state cobre o padrão; a única ausência é a animação de transição (CSS transition).

## Componentes usados

- `Bar` — papel: principal (header clicável) — ver `bar.sample.md`
- `Box` — papel: composição (container de conteúdo) — ver `box.sample.md`
- `Badge` — papel: composição (contagem, status) — ver `badge.sample.md`
- `Icon` — papel: composição (seta de colapso) — ver `icon.sample.md`

## Recursos visuais

- `cursor-pointer select-none` — feedback de clicabilidade no header
- `transition-all duration-200` — animação de abertura (opcional, sem JS)
- `WellKnownIcons.ChevronDown`, `WellKnownIcons.ChevronUp` — ícone de estado

## Receita

`Bar` com `@onclick` alterna `bool` de estado; conteúdo renderizado com `@if(aberto)`.

```razor
@code {
    private bool secaoAberta = true;
    private bool secaoAvancadaAberta;
}

@* Seção colapsável simples *@
<div class="border border-light-200 rounded-md overflow-hidden">
    <Bar AdditionalClasses="px-4 py-3 bg-light-50 cursor-pointer select-none
                           border-b @(secaoAberta ? "border-light-200" : "border-transparent")"
         @onclick="() => secaoAberta = !secaoAberta">
        <StartContent>
            <span class="text-sm font-semibold text-dark-700">Configurações gerais</span>
            <Badge Style="Themes.Secondary" Text="3 itens" Size="Sizes.Small" />
        </StartContent>
        <EndContent>
            <Icon Kind="@(secaoAberta ? WellKnownIcons.ChevronUp : WellKnownIcons.ChevronDown)" />
        </EndContent>
    </Bar>
    @if (secaoAberta)
    {
        <div class="p-4">
            @* conteúdo da seção *@
        </div>
    }
</div>

@* Grupo de seções colapsáveis (accordion-like) *@
@{
    var secoes = new[]
    {
        ("geral", "Geral", true),
        ("avancado", "Avançado", false),
        ("integracao", "Integração", false),
    };
}
<Stack Gap="Gaps.Small">
    @foreach (var (id, label, aberto) in secoes)
    {
        var estadoLocal = aberto; // cada seção controla seu próprio bool no código real
        <Box Border="BorderBuilder.Box" AdditionalClasses="overflow-hidden">
            <Bar AdditionalClasses="px-4 py-3 cursor-pointer select-none"
                 @onclick="() => { /* toggle estado da seção */ }">
                <StartContent>
                    <span class="text-sm font-semibold text-dark-600">@label</span>
                </StartContent>
                <EndContent>
                    <Icon Kind="@(estadoLocal ? WellKnownIcons.ChevronUp : WellKnownIcons.ChevronDown)" />
                </EndContent>
            </Bar>
            @if (estadoLocal)
            {
                <div class="px-4 pb-4 border-t border-light-100">
                    @* conteúdo *@
                </div>
            }
        </Box>
    }
</Stack>
```

## Limites

- Sem animação de deslizamento — `@if` faz render/unrender abrupto; para transição suave usar `hidden/block` com CSS `transition` mas requer `max-height` fixo ou JS;
- Para múltiplas seções com accordion exclusivo (fechar ao abrir outra), gerenciar `string? secaoAtiva` no componente pai.
