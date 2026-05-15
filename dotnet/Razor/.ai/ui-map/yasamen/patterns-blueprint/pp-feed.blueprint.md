# PP-FEED - Blueprint

## Identificação
- **Pattern**: PP-FEED.
- **Nível final**: completo.
- **Cobertura atual**: 2.
- **Meta de cobertura proposta**: 8.
- **Evidências usadas**: `ui-map.md`, `page.pattern.md`, samples de `Stack`, `Box`, `Badge`, `DropIconButton`, `DropItem`, `Button`, `Feedback`, `Pagination`, `visual.language.md` e `styles.map.md`.

## Resumo executivo
Yasamen monta stream com blocos, badges e menus, mas não possui feed item, atualização incremental ou ação flutuante. O blueprint propõe página de feed com item cronológico, filtros simples e estados.

## Requisitos ainda não atendidos
- Item de feed com autoria, tempo, conteúdo e ações.
- Ordem temporal e agrupamento.
- Atualização incremental ou paginação.
- Estado vazio e loading.
- Ação de publicar ou criar item.

## Diagnóstico estruturado do gap
`Stack` permite fluxo vertical, `Box` vira item, `DropIconButton` cobre overflow e `Feedback` cobre estados. Falta o contrato cronológico e carregamento incremental.

## Justificativa detalhada da meta
A meta 8 é possível com `FeedPage` e `FeedItem` propostos. Infinite scroll e realtime ficam externos.

## Estratégia de composição
- `Stack` para stream.
- `Box` para item.
- `DropIconButton` para ações.
- `Badge` para tipo/status.
- `Pagination` ou botão "Carregar mais".
- `IconButton`/`Button` para criar item.

## Proposta de peças, contratos e responsabilidades
- `[API proposta] FeedPage`: Items, Filters, HasMore, OnLoadMore, OnCreate.
- `[API proposta] FeedItem`: Author, Time, Body, Type, Actions.
- `[API proposta] FeedComposerTrigger`: ação de criação.

## Aplicação objetiva da linguagem visual
Feed deve ser vertical, contido e claro. Usar `Badge` para tipo de evento, não como decoração. Item importante pode usar borda `primary-500/50`, não fundo forte.

## Aplicação de estilos e tokens
Usar `max-w` de leitura quando o feed for central; `space-y-4`, `p-4`, `border-light-300`. Ação flutuante deve usar `IconButton` com `Themes.Primary` e label acessível quando possível.

## Estrutura sugerida por tecnologia

```razor
@* [API proposta] FeedPage *@
<div class="relative">
    <Stack AdditionalClasses="space-y-4">
        @if (!Items.Any())
        {
            <Feedback Style="Themes.Info" Title="Sem atualizações" Text="Nenhum item foi publicado ainda." Block="true" />
        }
        @foreach (var item in Items)
        {
            @ItemTemplate(item)
        }
        <Button Label="Carregar mais" Style="Themes.Light" Block="true" OnClick="LoadMore" />
    </Stack>
    <IconButton Icon="BsIconNames.Plus" Style="Themes.Primary" Size="Sizes.Large" AdditionalClasses="fixed right-8 bottom-8" OnClick="Create" />
</div>
```

## Blocos principais de código

```razor
@* [API proposta] FeedItem *@
<Box AdditionalClasses="p-4 bg-white border border-light-300 rounded-md space-y-3">
    <div class="flex items-start justify-between gap-4">
        <div>
            <div class="font-medium text-dark-900">@Author</div>
            <div class="text-sm text-dark-400">@PublishedAt</div>
        </div>
        <DropIconButton Icon="BsIconNames.ThreeDots">
            <DropItem OnClick="Hide">Ocultar</DropItem>
            <DropItem OnClick="CopyLink">Copiar link</DropItem>
        </DropIconButton>
    </div>
    <p class="text-dark-700">@Body</p>
    <Badge Text="@Kind" Style="Themes.Info" Size="Sizes.Small" />
</Box>
```

## Estados e comportamento responsivo
- Desktop: stream central com filtros laterais opcionais.
- Mobile: stream em coluna única e ação principal visível.
- Loading: botão "Carregar mais" disabled ou feedback local.
- Empty: `Feedback Info`.
- Error: `Feedback Danger` com retry.

## Exemplo principal de uso

```razor
@* [API proposta] *@
<FeedPage Items="events"
          HasMore="@hasMore"
          OnLoadMore="LoadMoreAsync"
          OnCreate="OpenComposer" />
```

## Comparação entre cobertura atual e proposta
| Critério | Atual | Proposta |
|---|---|---|
| Stream | manual | `FeedPage` |
| Item | manual | `FeedItem` |
| Ações | cobertas | aplicadas |
| Loading | parcial | contrato |

## Limitações remanescentes
- Realtime e infinite scroll dependem do app.
- Composer rico não está incluso.
- Moderação e permissões são externas.

## Pontos de adaptação
- Definir ordenação e paginação.
- Decidir se há grupos por data.
- Conectar ação de criação ao fluxo do domínio.
