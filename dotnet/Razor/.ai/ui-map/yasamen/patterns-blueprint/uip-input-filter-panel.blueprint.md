# UIP-INPUT-FILTER_PANEL - Blueprint

## Identificação
- **Pattern**: UIP-INPUT-FILTER_PANEL - Filter Panel.
- **Nível final**: completo.
- **Cobertura atual**: 4.
- **Meta de cobertura proposta**: 8.
- **Evidências usadas**: `ui-map.md`, `ui_input.pattern.md`, samples de `OffCanvas`, `TextField`, `ButtonGroup`, `Button`, `Badge`, `Feedback`, `FieldAction`, `visual.language.md` e `styles.map.md`.

## Resumo executivo
Yasamen possui `OffCanvas`, campos e botões, mas não há painel de filtros com aplicar, limpar, filtros ativos e responsividade. O blueprint propõe `FilterPanel` e `AppliedFiltersBar`.

## Requisitos ainda não atendidos
- Filtros estruturados por atributo.
- Aplicar e limpar.
- Indicador de filtros ativos.
- Variante desktop e mobile.
- Estado loading enquanto aplica.

## Diagnóstico estruturado do gap
`OffCanvas` resolve drawer mobile; `TextField` resolve entradas textuais; `ButtonGroup` resolve ações; `Badge` representa filtros ativos. Falta contrato e estado.

## Justificativa detalhada da meta
Com painel proposto, a cobertura chega a 8 para filtros comuns. Controles especializados ainda dependem de componentes futuros.

## Estratégia de composição
- Desktop: painel lateral ou bloco superior.
- Mobile: `OffCanvas Position=End`.
- `Badge` para filtros ativos.
- `ButtonGroup` para aplicar/limpar.
- `Feedback` para erro de filtro.

## Proposta de peças, contratos e responsabilidades
- `[API proposta] FilterPanel`: Model, OnApply, OnClear, ActiveCount, Loading.
- `[API proposta] AppliedFilterChip`: Label, OnRemove.
- `[API proposta] FilterDrawer`: handler e conteúdo do painel.

## Aplicação objetiva da linguagem visual
Filtros ativos usam badges leves; aplicar usa `Themes.Primary`; limpar usa `Themes.Light`. Erro de filtro usa `Danger`.

## Aplicação de estilos e tokens
Painel branco, `p-6`, `border-light-300`, `space-y-4`. Em mobile, offcanvas com backdrop leve já segue a biblioteca.

## Estrutura sugerida por tecnologia

```razor
@* [API proposta] FilterPanel *@
<Box AdditionalClasses="p-6 bg-white border border-light-300 rounded-md space-y-4">
    <Bar>
        <Start><h2 class="font-medium text-dark-900">Filtros</h2></Start>
        <End><Badge Text="@ActiveCount.ToString()" Style="Themes.Primary" Size="Sizes.Small" /></End>
    </Bar>
    @ChildContent
    <ButtonGroup AriaLabel="Ações de filtro" Size="Sizes.Small">
        <Button Label="Aplicar" Style="Themes.Primary" OnClick="Apply" Disabled="@Loading" />
        <Button Label="Limpar" Style="Themes.Light" OnClick="Clear" />
    </ButtonGroup>
</Box>
```

## Blocos principais de código

```razor
@* [API proposta] drawer mobile *@
<OffCanvas Handler="filterHandler" Position="Positions.End" Title="Filtros" UseBox="true">
    <FilterPanel Model="Filters" ActiveCount="@ActiveCount" OnApply="ApplyFilters" OnClear="ClearFilters">
        <TextField Label="Nome" @bind-Value="Filters.Name" />
        <TextField Label="Status" @bind-Value="Filters.Status" />
    </FilterPanel>
</OffCanvas>
```

## Estados e comportamento responsivo
- Desktop: visível ao lado ou acima da coleção.
- Mobile: `OffCanvas`.
- Sem filtros: active count zero e limpar disabled proposto.
- Aplicando: botões disabled.
- Erro: `Feedback Danger` dentro do painel.

## Exemplo principal de uso

```razor
@* [API proposta] *@
<FilterPanel Model="filters"
             ActiveCount="@activeFilters"
             Loading="@loading"
             OnApply="LoadResults"
             OnClear="ResetFilters" />
```

## Comparação entre cobertura atual e proposta
| Critério | Atual | Proposta |
|---|---|---|
| Drawer | `OffCanvas` | aplicado |
| Campos | textuais | agrupados |
| Filtros ativos | manual | badges |
| Aplicar/limpar | manual | contrato |

## Limitações remanescentes
- Facetas complexas precisam controles adicionais.
- Serialização em URL depende do app.

## Pontos de adaptação
- Definir filtros reativos ou por botão aplicar.
- Manter resumo de filtros visível fora do drawer.
