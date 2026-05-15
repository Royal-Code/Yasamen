# PP-LIST-DETAIL - Blueprint

## Identificação
- **Pattern**: PP-LIST-DETAIL.
- **Nível final**: completo.
- **Cobertura atual**: 6.
- **Meta de cobertura proposta**: 8.
- **Evidências usadas**: `ui-map.md`, `page.pattern.md`, samples de `Container`, `Slot`, `Box`, `Stack`, `Button`, `IconButton`, `Badge`, `Pagination`, `Feedback`, `OffCanvas`, `visual.language.md` e `styles.map.md`.

## Resumo executivo
Yasamen tem grid, slots, cards, paginação e ações suficientes para montar master-detail, mas não fornece seleção, detalhe sincronizado ou transição mobile. O blueprint propõe uma composição `[API proposta] ListDetailPage` com lista, detalhe e painel alternável.

## Requisitos ainda não atendidos
- Seleção persistente de item.
- Detalhe ou preview sincronizado.
- Alternância lista/detalhe em mobile.
- Empty state quando não há item selecionado ou coleção vazia.
- Ações contextuais no detalhe.

## Diagnóstico estruturado do gap
`Container` e `Slot` resolvem a divisão desktop. `Box`, `Badge` e `DropIconButton` montam itens. `Pagination` cobre navegação. Falta o contrato que conecta seleção, detalhe, filtros e estado responsivo.

## Justificativa detalhada da meta
A meta 8 é adequada porque o blueprint define a coordenação que falta usando componentes existentes. A cobertura não chega a 9 porque não há componente oficial de list item, data table ou split panel.

## Estratégia de composição
- `Container Type="LayoutTypes.Grid"` com `Slot` para lista e detalhe.
- `Box` para item e painel.
- `Badge` para status.
- `DropIconButton` para ações locais.
- `OffCanvas` para detalhe em mobile quando a lista precisa preservar foco.
- `Feedback` para vazio e erro.

## Proposta de peças, contratos e responsabilidades
- `[API proposta] ListDetailPage<TItem>`: Items, SelectedItem, OnSelect, Detail, Filters, Actions.
- `[API proposta] ListDetailItem`: Active, Title, Subtitle, Status, Actions.
- `[API proposta] DetailPane`: SelectedItem, EmptyContent, Loading.

## Aplicação objetiva da linguagem visual
Item ativo usa `bg-primary-100` e borda lateral `primary-500/50`, inspirado na navegação lateral. Painéis são brancos com `border-light-300`. A ação principal fica no detalhe com `Button Themes.Primary`.

## Aplicação de estilos e tokens
Grid 4/8/12/16. Desktop usa lista `LaptopSpan=4` e detalhe `LaptopSpan=8`. Mobile deve empilhar ou alternar para offcanvas; não comprimir detalhe ao lado da lista em 4 colunas.

## Estrutura sugerida por tecnologia

```razor
@* [API proposta] ListDetailPage *@
<Container Type="LayoutTypes.Grid" Size="LayoutSizes.Default" AdditionalClasses="gap-6">
    <Slot Span="4" LaptopSpan="4">
        <Stack AdditionalClasses="space-y-3">
            @Filters
            @foreach (var item in Items)
            {
                @ItemTemplate(item)
            }
            <Pagination CurrentPage="@Page" TotalPages="@TotalPages" OnPageChanged="OnPageChanged" />
        </Stack>
    </Slot>
    <Slot Span="4" LaptopSpan="8">
        @DetailContent
    </Slot>
</Container>
```

## Blocos principais de código

```razor
@* [API proposta] item selecionável *@
<button class="w-full text-left">
    <Box AdditionalClasses="@ItemClasses">
        <div class="flex items-start justify-between gap-4">
            <div class="min-w-0">
                <div class="font-medium text-dark-900">@Title</div>
                <div class="text-sm text-dark-500 truncate">@Subtitle</div>
            </div>
            <Badge Text="@Status" Style="@StatusTheme" Size="Sizes.Small" />
        </div>
    </Box>
</button>

@code {
    private string ItemClasses => Active
        ? "p-4 bg-primary-100 border-l-2 border-primary-500/50 rounded-md"
        : "p-4 bg-white border border-light-300 rounded-md";
}
```

## Estados e comportamento responsivo
- Desktop: lista e detalhe simultâneos.
- Mobile: lista primeiro; ao selecionar, navegar para detalhe ou abrir `OffCanvas`.
- Sem seleção: `Feedback Info` no detalhe.
- Coleção vazia: `Feedback Info` com CTA para limpar filtro.
- Loading de página: `Pagination Loading=true` e feedback local.

## Exemplo principal de uso

```razor
@* [API proposta] *@
<ListDetailPage Items="customers"
                SelectedItem="selectedCustomer"
                OnSelect="SelectCustomer"
                Page="@page"
                TotalPages="@totalPages">
    <Detail>
        <CustomerDetail Customer="selectedCustomer" />
    </Detail>
</ListDetailPage>
```

## Comparação entre cobertura atual e proposta
| Critério | Atual | Proposta |
|---|---|---|
| Layout | bom | contrato master-detail |
| Seleção | manual | estado formalizado |
| Detalhe | manual | pane dedicado |
| Mobile | não definido | alternância/offcanvas |

## Limitações remanescentes
- Data table e virtualização não são fornecidos.
- Navegação por rota precisa integração do app.
- Filtros avançados dependem de blueprint próprio.

## Pontos de adaptação
- Definir modelo de seleção e URL.
- Escolher lista card, tabela manual ou item compacto.
- Ajustar ações de detalhe por domínio.
