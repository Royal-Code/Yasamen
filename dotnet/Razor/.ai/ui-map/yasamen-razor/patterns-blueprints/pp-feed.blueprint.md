# PP-FEED - Blueprint resumido

## Pattern

PP-FEED — Feed Page — ver `pp-feed.ui-map.md`

## Gap coberto

A lib cobre bem os itens do feed. O gap é orientar: scroll infinito com botão "Carregar mais" (alternativa a IntersectionObserver), badge de tipo por item, skeleton de loading, e FAB de nova publicação.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `Stack + Box + Bar + Badge + DropIconButton` para itens; `ButtonGroup` de filtro no header sticky; `Button("Carregar mais")` para paginação incremental; FAB manual `fixed bottom-6 right-6`.

## Componentes usados

- `Stack` — papel: principal (lista do feed) — ver `stack.sample.md`
- `Box` — papel: composição (card de item) — ver `box.sample.md`
- `Bar` — papel: composição (header do item e da página) — ver `bar.sample.md`
- `Badge` — papel: composição (tipo de item) — ver `badge.sample.md`
- `DropIconButton` — papel: composição (ações por item) — ver `button.sample.md`
- `Button` — papel: composição (filtros, carregar mais, FAB) — ver `button.sample.md`
- `Feedback` — papel: composição (loading, empty state) — ver `feedback.sample.md`

## Recursos visuais

- `border-l-2 border-primary-400` — item não lido com marcação lateral
- `sticky top-0 bg-white z-10` — header com filtros
- `fixed bottom-6 right-6 z-10` — FAB de nova publicação

## Receita

Header sticky com filtros; `Stack + Box + Bar + Badge` por item; "Carregar mais"; FAB.

```razor
@page "/feed"
@code {
    private List<FeedItemDto> itens = [];
    private bool carregando = true;
    private bool carregandoMais;
    private bool temMais = true;
    private int pagina = 1;
    private string filtro = "todos";

    protected override async Task OnInitializedAsync() => await CarregarFeed();

    private async Task CarregarFeed()
    {
        carregando = true;
        pagina = 1;
        itens = await FeedService.ObterAsync(filtro, pagina);
        carregando = false;
    }

    private async Task CarregarMais()
    {
        carregandoMais = true;
        pagina++;
        var novos = await FeedService.ObterAsync(filtro, pagina);
        itens.AddRange(novos);
        temMais = novos.Count > 0;
        carregandoMais = false;
    }
}

@* Header com filtros *@
<Bar AdditionalClasses="mb-4 sticky top-0 bg-white z-10 py-3 border-b border-light-100">
    <StartContent>
        <h1 class="text-lg font-semibold text-dark-700">Feed</h1>
    </StartContent>
    <EndContent>
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
    </EndContent>
</Bar>

@* Conteúdo *@
@if (carregando)
{
    <Stack Gap="Gaps.Medium">
        @for (int i = 0; i < 4; i++)
        {
            <Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
                <div class="animate-pulse space-y-2">
                    <div class="flex gap-2 items-center">
                        <div class="w-8 h-8 rounded-full bg-light-200"></div>
                        <div class="h-3 bg-light-200 rounded w-24"></div>
                    </div>
                    <div class="h-4 bg-light-200 rounded w-3/4"></div>
                    <div class="h-3 bg-light-100 rounded w-full"></div>
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
                 AdditionalClasses="@($"p-4 {(!item.Lido ? "border-l-2 border-primary-400" : "")}")">
                <Bar AdditionalClasses="mb-2">
                    <StartContent>
                        <div class="flex items-center gap-2">
                            <div class="w-7 h-7 rounded-full bg-light-200 flex items-center
                                        justify-center text-xs font-bold text-dark-500 flex-shrink-0">
                                @item.AutorNome[0]
                            </div>
                            <div>
                                <p class="text-xs font-semibold text-dark-600">@item.AutorNome</p>
                                <p class="text-xs text-dark-300">
                                    @item.PublicadoEm.ToString("dd/MM HH:mm")
                                </p>
                            </div>
                        </div>
                    </StartContent>
                    <EndContent>
                        <Badge Style="@item.TipoTema" Text="@item.Tipo" />
                        <DropIconButton Icon="WellKnownIcons.MoreVertical"
                                       Style="Themes.Default" Size="Sizes.Small">
                            <DropItem Label="Marcar como lido"
                                      OnClick="() => MarcarLido(item.Id)" />
                            <DropItem Label="Fixar" OnClick="() => Fixar(item.Id)" />
                            <DropItem Label="Ocultar" Style="Themes.Danger"
                                      OnClick="() => Ocultar(item.Id)" />
                        </DropIconButton>
                    </EndContent>
                </Bar>
                <p class="text-sm text-dark-600">@item.Conteudo</p>
            </Box>
        }
    </Stack>

    @if (temMais)
    {
        <div class="flex justify-center mt-6 pb-24">
            <Button Style="Themes.Default" Label="Carregar mais"
                    Loading="@carregandoMais"
                    OnClick="CarregarMais" />
        </div>
    }
}

@* FAB de nova publicação *@
<Button Style="Themes.Primary"
        AdditionalClasses="fixed bottom-6 right-6 z-10 shadow-lg"
        Label="+ Publicar"
        OnClick="AbrirNovaPublicacao" />
```

## Limites

- Scroll infinito automático requer `IntersectionObserver` via JS interop — "Carregar mais" é alternativa funcional;
- Tempo real (SignalR) para `novosItens` requer integração separada — polling periódico como alternativa;
- `pb-24` na lista compensa o FAB para que o último item não fique coberto.
