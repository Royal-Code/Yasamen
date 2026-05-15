# PP-BOARD - Blueprint

## Identificação
- **Pattern**: PP-BOARD.
- **Nível final**: completo.
- **Cobertura atual**: 1.
- **Meta de cobertura proposta**: 8.
- **Evidências usadas**: `ui-map.md`, `page.pattern.md`, samples de `Container`, `Slot`, `Box`, `Stack`, `Badge`, `DropIconButton`, `DropItem`, `Button`, `TextField`, `OffCanvas`, `Feedback`, `visual.language.md` e `styles.map.md`.

## Resumo executivo
Yasamen não possui kanban, board ou drag/drop, mas oferece blocos, menus, filtros e layout para criar um board visual. O blueprint propõe colunas e cartões como peças de aplicação, deixando drag/drop como integração externa.

## Requisitos ainda não atendidos
- Colunas/lane por estado.
- Cartões com ações e metadados.
- Movimento entre estados.
- Filtros e busca.
- Empty state por coluna.

## Diagnóstico estruturado do gap
`Container`, `Slot`, `Stack`, `Box` e `Badge` resolvem a estrutura visual. `DropIconButton` cobre ações por card. Falta contrato para coluna, cartão e movimentação.

## Justificativa detalhada da meta
A meta 8 cobre board visual e operação básica sem prometer drag/drop nativo. Movimento pode ser feito por menu contextual ou biblioteca externa.

## Estratégia de composição
- `Bar` para toolbar.
- `TextField` para busca.
- `OffCanvas` para filtros.
- `Container` ou flex horizontal para colunas.
- `Box` para coluna e card.
- `DropIconButton` para mover/editar.
- `Feedback` para coluna vazia.

## Proposta de peças, contratos e responsabilidades
- `[API proposta] BoardPage`: Columns, Cards, Filters, OnMove.
- `[API proposta] BoardColumn`: Title, Count, Items, EmptyContent.
- `[API proposta] BoardCard`: Title, Metadata, Status, Actions.
- `[API proposta] BoardMoveAction`: destino e callback.

## Aplicação objetiva da linguagem visual
Colunas são superfícies `light-100` ou brancas com borda clara. Cards são brancos, `rounded-md`, `border-light-300`. Status usa `Badge`, não cor de fundo do card inteiro.

## Aplicação de estilos e tokens
Desktop pode usar scroll horizontal controlado. Mobile deve mostrar uma coluna por vez ou colunas empilhadas; não forçar cinco colunas comprimidas.

## Estrutura sugerida por tecnologia

```razor
@* [API proposta] BoardPage *@
<Stack AdditionalClasses="space-y-6">
    <Bar>
        <Start><TextField Placeholder="Buscar cartões" @bind-Value="Search" /></Start>
        <End><Button Label="Novo cartão" Style="Themes.Primary" OnClick="Create" /></End>
    </Bar>

    <div class="flex gap-6 overflow-x-auto pb-4">
        @foreach (var column in Columns)
        {
            @ColumnTemplate(column)
        }
    </div>
</Stack>
```

## Blocos principais de código

```razor
@* [API proposta] BoardColumn e BoardCard *@
<Box AdditionalClasses="w-80 shrink-0 p-4 bg-light-100 border border-light-300 rounded-md">
    <Bar>
        <Start><h2 class="font-medium text-dark-900">@Title</h2></Start>
        <End><Badge Text="@Items.Count.ToString()" Style="Themes.Secondary" Size="Sizes.Small" /></End>
    </Bar>

    <Stack AdditionalClasses="space-y-3 mt-4">
        @if (!Items.Any())
        {
            <Feedback Style="Themes.Info" Text="Sem itens nesta coluna." Block="true" />
        }
        @foreach (var card in Items)
        {
            <Box AdditionalClasses="p-4 bg-white border border-light-300 rounded-md space-y-2">
                <div class="flex justify-between gap-3">
                    <strong class="text-dark-900">@card.Title</strong>
                    <DropIconButton Icon="BsIconNames.ThreeDots">
                        <DropItem OnClick="@(() => Move(card))">Mover</DropItem>
                        <DropItem OnClick="@(() => Edit(card))">Editar</DropItem>
                    </DropIconButton>
                </div>
                <Badge Text="@card.Status" Style="Themes.Info" Size="Sizes.Small" />
            </Box>
        }
    </Stack>
</Box>
```

## Estados e comportamento responsivo
- Desktop: colunas lado a lado com scroll horizontal se necessário.
- Mobile: uma coluna por vez, tabs/selector proposto ou scroll horizontal com largura fixa.
- Empty board: `Feedback Info`.
- Empty column: feedback dentro da coluna.
- Loading: feedback por coluna ou board inteiro.

## Exemplo principal de uso

```razor
@* [API proposta] *@
<BoardPage Columns="columns"
           Search="@search"
           OnMove="MoveCardAsync"
           OnCreate="CreateCard" />
```

## Comparação entre cobertura atual e proposta
| Critério | Atual | Proposta |
|---|---|---|
| Board | ausente | página proposta |
| Coluna | ausente | `BoardColumn` |
| Card | manual | `BoardCard` |
| Drag/drop | ausente | integração externa |

## Limitações remanescentes
- Drag/drop e persistência de ordem não são nativos.
- Virtualização de muitos cartões fica fora.
- Permissões de movimento dependem do app.

## Pontos de adaptação
- Definir estados/colunas do domínio.
- Escolher movimento por menu ou drag/drop externo.
- Padronizar limite visual de cartões por coluna.
