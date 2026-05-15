# UIP-DATA-KANBAN_COLUMN - Blueprint

## Identificação
- **Pattern**: UIP-DATA-KANBAN_COLUMN - Kanban Column.
- **Nível final**: completo.
- **Cobertura atual**: 1.
- **Meta de cobertura proposta**: 8.
- **Evidências usadas**: `ui-map.md`, `ui_data.pattern.md`, samples de `Box`, `Stack`, `Badge`, `DropIconButton`, `DropItem`, `Feedback`, `visual.language.md` e `styles.map.md`.

## Resumo executivo
Yasamen não possui coluna kanban ou drag/drop. O blueprint propõe `KanbanColumn` e `KanbanCard` como peças de aplicação, com movimento por menu contextual ou integração externa.

## Requisitos ainda não atendidos
- Cabeçalho de coluna com contagem.
- Cartões operacionais.
- Estado vazio/limite.
- Movimento entre colunas.
- Responsividade de board.

## Diagnóstico estruturado do gap
`Box`, `Stack`, `Badge` e `DropIconButton` compõem coluna e card. Drag/drop e regras de movimento não existem e precisam ficar marcados como externos.

## Justificativa detalhada da meta
Com coluna e card propostos, a cobertura de exibição e ação chega a 8. Arrastar permanece fora da biblioteca.

## Estratégia de composição
- `Box` para coluna com largura fixa.
- `Bar` para título e contagem.
- `Stack` para cards.
- `Feedback` para vazio.
- `DropIconButton` para mover/editar.

## Proposta de peças, contratos e responsabilidades
- `[API proposta] KanbanColumn`: Title, Items, Limit, OnCreate.
- `[API proposta] KanbanCard`: Title, Subtitle, Status, Actions.
- `[API proposta] MoveCardAction`: destino e callback.

## Aplicação objetiva da linguagem visual
Coluna deve ser `bg-light-100` com borda clara. Card deve ser branco. Limite atingido usa `Warning`, erro usa `Danger`.

## Aplicação de estilos e tokens
Usar `w-80`, `shrink-0`, `space-y-3`, `p-4`; mobile mostra uma coluna por vez.

## Estrutura sugerida por tecnologia

```razor
@* [API proposta] KanbanColumn *@
<Box AdditionalClasses="w-80 shrink-0 p-4 bg-light-100 border border-light-300 rounded-md">
    <Bar>
        <Start><h2 class="font-medium text-dark-900">@Title</h2></Start>
        <End><Badge Text="@Items.Count.ToString()" Style="Themes.Secondary" Size="Sizes.Small" /></End>
    </Bar>
    <Stack AdditionalClasses="space-y-3 mt-4">
        @if (!Items.Any())
        {
            <Feedback Style="Themes.Info" Text="Nenhum cartão." Block="true" />
        }
        @foreach (var item in Items)
        {
            @CardTemplate(item)
        }
    </Stack>
</Box>
```

## Blocos principais de código

```razor
@* [API proposta] KanbanCard *@
<Box AdditionalClasses="p-4 bg-white border border-light-300 rounded-md space-y-2">
    <div class="flex justify-between gap-3">
        <div>
            <div class="font-medium text-dark-900">@Title</div>
            <div class="text-sm text-dark-500">@Subtitle</div>
        </div>
        <DropIconButton Icon="BsIconNames.ThreeDots">
            <DropItem OnClick="Move">Mover</DropItem>
            <DropItem OnClick="Open">Abrir</DropItem>
        </DropIconButton>
    </div>
    <Badge Text="@Status" Style="Themes.Info" Size="Sizes.Small" />
</Box>
```

## Estados e comportamento responsivo
- Desktop: colunas simultâneas.
- Mobile: uma coluna visível ou scroll horizontal.
- Empty: feedback por coluna.
- Limit reached: badge/feedback warning.
- Dragging: integração externa deve aplicar classe de destaque.

## Exemplo principal de uso

```razor
@* [API proposta] *@
<KanbanColumn Title="Em andamento"
              Items="doing"
              OnMove="MoveCardAsync" />
```

## Comparação entre cobertura atual e proposta
| Critério | Atual | Proposta |
|---|---|---|
| Coluna | ausente | proposta |
| Card | manual | proposto |
| Movimento | ausente | menu ou externo |
| Vazio | manual | previsto |

## Limitações remanescentes
- Drag/drop não é nativo.
- Ordenação e persistência dependem do domínio.

## Pontos de adaptação
- Definir destinos válidos por status.
- Usar menu contextual em mobile.
