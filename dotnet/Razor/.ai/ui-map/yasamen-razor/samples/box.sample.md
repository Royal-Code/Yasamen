# Box - Sample

## Contrato de uso

**Entrada pública**: `<Box>` — namespace `RoyalCode.Razor.Layouts`
**Grupo**: UI-STRUCT
**Propósito**: Container estilizado com borda, padding e margin configuráveis via builders declarativos. É o bloco de construção de cards, painéis e superfícies de conteúdo.
**Patterns**:
- `implementa`: UIP-STRUCT-LAYOUT_ZONE, UIP-CONTENT-DETAIL_BLOCK, UIP-CONTENT-METRIC_CARD, UIP-CONTENT-RICH_TEXT_BLOCK
- `compõe`: UIP-FEEDBACK-EMPTY_STATE, UIP-FEEDBACK-ERROR_STATE, UIP-DATA-CARD_GRID, UIP-DATA-DATA_TABLE, UIP-STRUCT-COLLAPSIBLE_SECTION, UIP-NAV-TABS, UIP-DATA-TREE_VIEW, UIP-DATA-TIMELINE_ITEM, UIP-DATA-KANBAN_COLUMN, UIP-CONTENT-COMPARISON_BLOCK, UIP-CONTENT-MEDIA_VIEWER, UIP-CONTENT-MEDIA_COLLECTION
**Setup necessário**: `<YasamenStyles />` no `<head>`

## Regras rápidas

- **Use para**: cards, painéis, seções de conteúdo com separação visual via borda ou espaçamento próprio
- **Evite quando**: não há necessidade de borda ou padding próprio — use `Stack` (vertical) ou `Container` (grid/flex)
- **Cuidado**: os builders (`BorderBuilder`, `PaddingBuilder`, `MarginBuilder`) têm API fluente — `BorderBuilder.Box` é a variante mais comum (borda completa com border-radius)

## Exemplos

### `UIP-STRUCT-LAYOUT_ZONE, UIP-CONTENT-DETAIL_BLOCK` — Card/painel de conteúdo

`BorderBuilder.Box` é a variante padrão para cards — borda completa com cantos arredondados.

```razor
@* Card de detalhe — Box sem padding interno (gerenciar com classes Tailwind) *@
<Box Border="BorderBuilder.Box" AdditionalClasses="overflow-hidden">
    @* Header do card *@
    <Bar AdditionalClasses="px-4 py-3 border-b border-light-200 bg-light-50">
        <StartContent>
            <h2 class="text-base font-semibold text-dark-700">Informações do cliente</h2>
        </StartContent>
        <EndContent>
            <Button Style="Themes.Default" Size="Sizes.Small" Label="Editar" OnClick="Editar" />
        </EndContent>
    </Bar>
    @* Corpo do card *@
    <div class="p-4 space-y-2">
        <p class="text-sm text-dark-600"><span class="font-medium">Nome:</span> @cliente.Nome</p>
        <p class="text-sm text-dark-600"><span class="font-medium">Email:</span> @cliente.Email</p>
        <p class="text-sm text-dark-600"><span class="font-medium">Plano:</span>
            <Badge Style="Themes.Primary" Text="@cliente.Plano" />
        </p>
    </div>
</Box>
```

**API usada**: `Border="BorderBuilder.Box"`, `AdditionalClasses`

### `UIP-CONTENT-METRIC_CARD, UIP-DATA-CARD_GRID` — Cards de métricas em grade

```razor
@* Grade de KPIs: Container+Slot com Box interno *@
<Container Type="LayoutTypes.Grid">
    @foreach (var kpi in kpis)
    {
        <Slot Span="6" TabletSpan="3">
            <Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
                <Stack>
                    <Bar AdditionalClasses="mb-2">
                        <StartContent>
                            <p class="text-xs text-dark-400 uppercase font-medium">@kpi.Label</p>
                        </StartContent>
                        <EndContent>
                            <Badge Style="@(kpi.Variacao >= 0 ? Themes.Success : Themes.Danger)"
                                   Text="@($"{kpi.Variacao:+0;-0}%")" />
                        </EndContent>
                    </Bar>
                    <p class="text-2xl font-semibold text-dark-700">@kpi.Valor</p>
                </Stack>
            </Box>
        </Slot>
    }
</Container>
```

**API usada**: `Border`, `AdditionalClasses`; sem Padding/Margin builders (usando classes Tailwind diretamente)
**Nota**: É mais comum usar `class="p-4"` via `AdditionalClasses` do que `Padding="PaddingBuilder...."` — ambos funcionam.

### `UIP-DATA-DATA_TABLE, UIP-CONTENT-RICH_TEXT_BLOCK` — Tabela e conteúdo em Box

```razor
@* Tabela de dados envolta em Box *@
<Box Border="BorderBuilder.Box" AdditionalClasses="overflow-hidden">
    <table class="w-full text-sm">
        <thead class="bg-light-50 border-b border-light-200">
            <tr>
                <th class="text-left p-3 text-dark-500 font-medium">Nome</th>
                <th class="text-left p-3 text-dark-500 font-medium">Status</th>
                <th class="p-3 w-10"></th>
            </tr>
        </thead>
        <tbody>
            @foreach (var item in itens)
            {
                <tr class="border-b border-light-100 last:border-0">
                    <td class="p-3 text-dark-700">@item.Nome</td>
                    <td class="p-3"><Badge Style="@item.Tema" Text="@item.Status" /></td>
                    <td class="p-3">
                        <DropIconButton Icon="WellKnownIcons.MoreVertical"
                                       Style="Themes.Default" Size="Sizes.Small"
                                       ContentType="DropContentType.List" Align="Positions.End">
                            <DropItem Label="Editar" OnClick="() => Editar(item.Id)" />
                            <DropItem Label="Excluir" OnClick="() => Excluir(item.Id)" />
                        </DropIconButton>
                    </td>
                </tr>
            }
        </tbody>
    </table>
</Box>

@* Rich text / conteúdo editorial *@
<Box Border="BorderBuilder.Box" AdditionalClasses="p-6 prose max-w-none">
    @((MarkupString)conteudo.Html)
</Box>
```

### `UIP-DATA-TIMELINE_ITEM, UIP-DATA-KANBAN_COLUMN, UIP-STRUCT-COLLAPSIBLE_SECTION, UIP-DATA-TREE_VIEW, UIP-CONTENT-COMPARISON_BLOCK, UIP-CONTENT-MEDIA_VIEWER, UIP-CONTENT-MEDIA_COLLECTION` — Box como container em estruturas variadas

```razor
@* Kanban card *@
<Box Border="BorderBuilder.Box" AdditionalClasses="p-3 mb-2 cursor-pointer hover:shadow-sm transition-shadow">
    <Badge Style="@tarefa.PrioridadeTema" Text="@tarefa.Prioridade" Size="Sizes.Small" />
    <p class="text-sm font-semibold text-dark-700 mt-1">@tarefa.Titulo</p>
    <p class="text-xs text-dark-400 mt-0.5">@tarefa.Responsavel</p>
</Box>

@* Collapsible section body (aparece quando aberto) *@
@if (secaoAberta)
{
    <Box Border="BorderBuilder.Box" AdditionalClasses="border-t-0 rounded-t-none p-4">
        <Stack AdditionalClasses="gap-2">
            @foreach (var item in secaoItens)
            {
                <p class="text-sm text-dark-600">@item</p>
            }
        </Stack>
    </Box>
}

@* Media viewer, comparison, tree view — Box como wrapper de conteúdo especializado *@
<Box Border="BorderBuilder.Box" AdditionalClasses="overflow-hidden aspect-video">
    <img src="@item.ImageUrl" class="w-full h-full object-cover" alt="@item.Alt" />
</Box>
```

### `UIP-FEEDBACK-EMPTY_STATE, UIP-FEEDBACK-ERROR_STATE, UIP-NAV-TABS` — Box como container de estados e abas

```razor
@* Empty state e error state dentro de Box *@
<Box Border="BorderBuilder.Box" AdditionalClasses="p-8">
    @if (!itens.Any())
    {
        <Feedback Title="Nenhum item encontrado"
                  Text="Adicione um item para começar."
                  Style="Themes.Default" />
    }
</Box>

@* Tab panel — conteúdo de aba ativa em Box *@
<Box Border="BorderBuilder.Box" AdditionalClasses="p-4 border-t-0 rounded-t-none">
    @if (abaAtiva == "detalhes")
    {
        <Stack AdditionalClasses="gap-3">
            <p class="text-sm text-dark-600">Conteúdo da aba detalhes</p>
        </Stack>
    }
</Box>
```

## API relevante

| Parâmetro | Tipo | Default | Uso |
|---|---|---|---|
| `Border` | `BorderBuilder` | `BorderBuilder.Box` | Define o estilo de borda — `BorderBuilder.Box` para card completo; `BorderBuilder.None` para sem borda |
| `Padding` | `PaddingBuilder` | `PaddingBuilder.None` | Padding interno via builder fluente |
| `Margin` | `MarginBuilder` | `MarginBuilder.None` | Margin externa via builder fluente |
| `ChildContent` | `RenderFragment` | — | Conteúdo interno livre |
| `AdditionalClasses` | `string?` | null | Classes Tailwind adicionais (comum para `p-4`, `overflow-hidden`, etc.) |

## Defaults importantes

- `Border` default `BorderBuilder.Box`: Box sempre tem borda por default — use `Border="BorderBuilder.None"` para container sem borda
- `Padding` default `PaddingBuilder.None`: sem padding interno; adicione via `AdditionalClasses="p-4"` (mais flexível) ou via `PaddingBuilder`
