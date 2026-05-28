# PP-FEED - Feed

## Componentes por zona funcional

### Zona: Filtros

1. Bar + ButtonGroup (filtro de tipo/período)
- `cobertura`: toggle de filtro "Todos / Meus / Seguindo" como ButtonGroup; seletor de período;
- `nota`: 7;
- `justificativa`: filtros de feed inline.

2. Button (verificar atualizações / carregar novos)
- `cobertura`: botão "X novos itens — carregar" no topo do feed;
- `nota`: 7;
- `justificativa`: atualização incremental do feed.

### Zona: Itens do Feed

1. Stack + Box/Bar (UIP-DATA-LIST_ITEM / UIP-DATA-TIMELINE_ITEM)
- `cobertura`: itens do feed em cards com autor, timestamp, conteúdo, badge de tipo, ações;
- `nota`: 7;
- `justificativa`: item de feed — card com Bar e BoxButton para ações.

2. Badge (tipo de item / categoria)
- `cobertura`: "Publicação", "Alerta", "Atualização", "Sistema" por item;
- `nota`: 9;
- `justificativa`: classificação visual do tipo de item no feed.

3. DropIconButton (UIP-ACTION-CONTEXTUAL_MENU)
- `cobertura`: ações por item ("Marcar como lido", "Fixar", "Ocultar", "Excluir");
- `nota`: 9;
- `justificativa`: menu de ações por item do feed.

### Zona: Ações

1. Button fixed (UIP-ACTION-FLOATING_ACTION — GAP parcial)
- `cobertura`: botão "Nova publicação" com `position:fixed`;
- `nota`: 4;
- `justificativa`: FAB manual para nova publicação.

2. Modal (composição de nova publicação)
- `cobertura`: modal com FieldTextArea para nova publicação;
- `nota`: 8;
- `justificativa`: composição de item de feed.

### Zona: Estados

1. Feedback + animate-pulse (UIP-FEEDBACK-LOADING_STATE)
- `cobertura`: skeleton de itens durante carregamento inicial;
- `nota`: 7;
- `justificativa`: estado de loading do feed.

2. Feedback Style=Light (empty state)
- `cobertura`: "Nenhuma publicação no momento";
- `nota`: 9;
- `justificativa`: estado vazio do feed.

**Descartados**: nenhum.

## Composição completa da página

```razor
@page "/feed"
@code {
    private List<FeedItemDto> itens = [];
    private int novosItens;
    private bool carregando = true;
    private bool carregandoMais;
    private int pagina = 1;
    private bool temMais = true;
    private string filtro = "todos";

    protected override async Task OnInitializedAsync() => await CarregarFeed();

    private async Task CarregarFeed()
    {
        carregando = true;
        pagina = 1;
        itens = await Service.ObterFeedAsync(filtro, pagina);
        carregando = false;
    }

    private async Task CarregarMais()
    {
        carregandoMais = true;
        pagina++;
        var novos = await Service.ObterFeedAsync(filtro, pagina);
        itens.AddRange(novos);
        temMais = novos.Count > 0;
        carregandoMais = false;
    }

    private async Task CarregarNovos()
    {
        novosItens = 0;
        await CarregarFeed();
    }
}

@* Header com filtros *@
<Bar AdditionalClasses="mb-4 sticky top-0 bg-white z-10 py-3 border-b border-light-100">
    <StartContent>
        <h1 class="text-lg font-semibold text-dark-700">Feed</h1>
    </StartContent>
    <EndContent>
        @* Filtro de tipo *@
        <div class="flex gap-1">
            @foreach (var f in new[] { ("todos","Todos"), ("meus","Meus"), ("alertas","Alertas") })
            {
                <button class="px-3 py-1 text-xs rounded-full border transition-colors
                               @(filtro == f.Item1
                                 ? "bg-primary-500 text-white border-primary-500"
                                 : "border-light-300 text-dark-500 hover:bg-light-50")"
                        @onclick='async () => { filtro = f.Item1; await CarregarFeed(); }'>
                    @f.Item2
                </button>
            }
        </div>
    </EndContent>
</Bar>

@* Notificação de novos itens *@
@if (novosItens > 0)
{
    <div class="flex justify-center mb-4">
        <Button Style="Themes.Primary" Size="Sizes.Small"
                Label="@($"{novosItens} novo(s) item(ns) — carregar")"
                OnClick="CarregarNovos" />
    </div>
}

@* Lista de itens *@
@if (carregando)
{
    <Stack Gap="Gaps.Medium">
        @for (int i = 0; i < 5; i++)
        {
            <Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
                <div class="animate-pulse space-y-2">
                    <div class="flex gap-2 items-center">
                        <div class="w-8 h-8 rounded-full bg-light-200"></div>
                        <div class="h-3 bg-light-200 rounded w-24"></div>
                        <div class="h-3 bg-light-100 rounded w-16 ml-auto"></div>
                    </div>
                    <div class="h-4 bg-light-200 rounded w-3/4"></div>
                    <div class="h-3 bg-light-100 rounded w-full"></div>
                    <div class="h-3 bg-light-100 rounded w-2/3"></div>
                </div>
            </Box>
        }
    </Stack>
}
else if (!itens.Any())
{
    <Feedback Style="Themes.Light" Text="Nenhuma publicação no momento." />
}
else
{
    <Stack Gap="Gaps.Medium">
        @foreach (var item in itens)
        {
            <Box Border="BorderBuilder.Box"
                 AdditionalClasses="@(item.Lido ? "p-4" : "p-4 border-l-2 border-primary-400")">
                @* Cabeçalho do item *@
                <Bar AdditionalClasses="mb-2">
                    <StartContent>
                        <div class="flex items-center gap-2">
                            <div class="w-7 h-7 rounded-full bg-light-200 flex items-center
                                        justify-center text-xs font-bold text-dark-500 flex-shrink-0">
                                @item.AutorNome.Substring(0, 1)
                            </div>
                            <div>
                                <p class="text-xs font-semibold text-dark-600">@item.AutorNome</p>
                                <p class="text-xs text-dark-300">
                                    @item.PublicadoEm.ToString("dd/MM/yyyy HH:mm")
                                </p>
                            </div>
                        </div>
                    </StartContent>
                    <EndContent>
                        <Badge Style="@item.TipoTema" Text="@item.Tipo" />
                        <DropIconButton Icon="WellKnownIcons.MoreVertical"
                                       Style="Themes.Default" Size="Sizes.Small">
                            @if (!item.Lido)
                            {
                                <DropItem Label="Marcar como lido"
                                          OnClick="() => MarcarLido(item.Id)" />
                            }
                            <DropItem Label="Fixar" OnClick="() => Fixar(item.Id)" />
                            <hr class="my-1 border-light-200" />
                            <DropItem Label="Ocultar" Style="Themes.Danger"
                                      OnClick="() => Ocultar(item.Id)" />
                        </DropIconButton>
                    </EndContent>
                </Bar>

                @* Conteúdo do item *@
                <p class="text-sm text-dark-600">@item.Conteudo</p>
            </Box>
        }
    </Stack>

    @* Carregar mais *@
    @if (temMais)
    {
        <div class="flex justify-center mt-6">
            <Button Style="Themes.Default" Label="Carregar mais"
                    OnClick="CarregarMais"
                    Disabled="@carregandoMais" />
        </div>
    }
}

@* FAB de nova publicação *@
<div class="fixed bottom-6 right-6 z-10">
    <Button Style="Themes.Primary"
            AdditionalClasses="rounded-full shadow-lg px-6 py-3"
            Label="+ Publicar"
            OnClick='() => ModalService.Open<NovaPublicacaoModal>()' />
</div>
```

## Decisão de uso

- `nota geral`: 6;
- `limitações`: scroll infinito automático requer `IntersectionObserver` via JS; pull-to-refresh não disponível na web; FAB é CSS manual (sem componente); sem suporte a tempo real (SignalR requer integração separada);
- `recomendação`: `usar por composição`
- `justificativa geral`:
  - `Stack` + `Box` + `Bar` + `Badge` + `DropIconButton` cobrem PP-FEED funcional com boa qualidade;
  - Paginação via "Carregar mais" é alternativa funcional ao scroll infinito automático;
  - Nota 6 reflete boa cobertura com limitações em scroll automático e tempo real.
