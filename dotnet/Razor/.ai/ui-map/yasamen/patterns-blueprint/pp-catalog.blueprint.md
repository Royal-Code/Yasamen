# PP-CATALOG - Blueprint

## Identificação
- **Pattern**: PP-CATALOG.
- **Nível final**: completo.
- **Cobertura atual**: 4.
- **Meta de cobertura proposta**: 8.
- **Evidências usadas**: `ui-map.md`, `page.pattern.md`, samples de `TextField`, `OffCanvas`, `Button`, `ButtonGroup`, `Container`, `Slot`, `Box`, `Badge`, `DropIconButton`, `DropItem`, `Pagination`, `Feedback`, `visual.language.md` e `styles.map.md`.

## Resumo executivo
Yasamen permite compor catálogo com busca, filtros, cards e paginação, mas não possui card de catálogo, filtro aplicado ou estado consolidado. O blueprint propõe `CatalogPage`, `CatalogCard` e `CatalogFilterPanel` como `[API proposta]`.

## Requisitos ainda não atendidos
- Busca e filtros conectados.
- Chips/resumo de filtros aplicados.
- Card de item com metadados e ações.
- Paginação ou carregamento incremental.
- Empty state por filtro.

## Diagnóstico estruturado do gap
`TextField` cobre busca, `OffCanvas` cobre painel de filtro, `Pagination` cobre páginas e `Box` cobre card. Falta contrato para ligar essas partes e diferenciar catálogo de lista operacional.

## Justificativa detalhada da meta
Com componentes propostos, a cobertura chega a 8 sem depender de data grid. A meta não cobre comparação avançada, favoritos persistentes ou recomendação.

## Estratégia de composição
- Toolbar com `TextField` e `Button` para filtros.
- `OffCanvas` para filtros em mobile e painel lateral em desktop quando necessário.
- `Container`/`Slot` para card grid.
- `Box`, `Badge`, `DropIconButton` para `CatalogCard`.
- `Pagination` no final.
- `Feedback` para vazio/erro.

## Proposta de peças, contratos e responsabilidades
- `[API proposta] CatalogPage`: Search, Filters, Items, Page, TotalPages.
- `[API proposta] CatalogCard`: Title, Summary, Status, Actions, Media slot.
- `[API proposta] AppliedFiltersBar`: lista de filtros aplicados e ação limpar.

## Aplicação objetiva da linguagem visual
Busca e filtro devem ser funcionais, não decorativos. Cards usam fundo branco, borda clara e poucas badges. CTA de item usa `Themes.Primary` quando é ação de conversão; caso contrário, usar `Themes.Light` ou menu contextual.

## Aplicação de estilos e tokens
Usar `gap-6`, `p-4/p-6`, `rounded-md`, `border-light-300`. Grid deve reduzir para uma coluna em mobile e evitar cards com altura instável por texto longo.

## Estrutura sugerida por tecnologia

```razor
@* [API proposta] CatalogPage *@
<Stack AdditionalClasses="space-y-6">
    <Box AdditionalClasses="p-4 bg-white border border-light-300 rounded-md">
        <div class="flex flex-col md:flex-row gap-4">
            <TextField Placeholder="Buscar" @bind-Value="Search">
                <FooterAction>
                    <FieldAction Label="Buscar" Style="Themes.Primary" OnClick="ApplySearch" />
                </FooterAction>
            </TextField>
            <Button Label="Filtros" Style="Themes.Light" OnClick="OpenFilters" />
        </div>
    </Box>
    @Cards
    <Pagination CurrentPage="@Page" TotalPages="@TotalPages" Loading="@Loading" OnPageChanged="ChangePage" />
</Stack>
```

## Blocos principais de código

```razor
@* [API proposta] CatalogCard *@
<Box AdditionalClasses="p-4 bg-white border border-light-300 rounded-md space-y-4">
    <div class="aspect-video bg-light-200 rounded-sm">@Media</div>
    <div class="space-y-2">
        <div class="flex justify-between gap-3">
            <h3 class="font-medium text-dark-900">@Title</h3>
            <DropIconButton Icon="BsIconNames.ThreeDots" MinWidth="Sizes.Smaller">
                <DropItem OnClick="Open">Abrir</DropItem>
                <DropItem OnClick="Compare">Comparar</DropItem>
            </DropIconButton>
        </div>
        <p class="text-sm text-dark-500">@Summary</p>
        <Badge Text="@Status" Style="@StatusTheme" Size="Sizes.Small" />
    </div>
</Box>
```

## Estados e comportamento responsivo
- Desktop: filtros podem aparecer em coluna lateral se forem críticos.
- Mobile: filtros em `OffCanvas` com ação "Aplicar".
- Empty: `Feedback Info` com limpar filtros.
- Loading: `Pagination Loading=true` e feedback no grid.
- Erro: `Feedback Danger` acima da coleção.

## Exemplo principal de uso

```razor
@* [API proposta] *@
<CatalogPage Items="products"
             Search="@search"
             Filters="@filters"
             Page="@page"
             TotalPages="@totalPages"
             OnApplyFilters="LoadCatalog" />
```

## Comparação entre cobertura atual e proposta
| Critério | Atual | Proposta |
|---|---|---|
| Busca | parcial | toolbar conectada |
| Filtro | offcanvas bruto | painel proposto |
| Card | manual | card de catálogo |
| Paginação | forte | integrada |

## Limitações remanescentes
- Comparação complexa e recomendação ficam fora.
- Infinite scroll não é nativo.
- Ordenação depende da API de dados.

## Pontos de adaptação
- Definir tipos de filtro e serialização em URL.
- Definir card compacto ou visual conforme domínio.
- Garantir que filtros aplicados tenham resumo visível.
