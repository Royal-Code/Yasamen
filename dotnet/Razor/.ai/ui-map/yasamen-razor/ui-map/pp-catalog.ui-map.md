# PP-CATALOG - Catalog

## Componentes por zona funcional

### Zona: Filtros

1. Bar + FieldText (UIP-INPUT-SEARCH_BAR)
- `cobertura`: barra de busca com debounce; total de resultados;
- `nota`: 8;
- `justificativa`: busca inline direta.

2. DropButton / ButtonGroup (filtros rápidos inline)
- `cobertura`: toggle de categoria/status no header; chips de filtro ativo via `Badge`;
- `nota`: 8;
- `justificativa`: filtros de refinamento rápido visíveis.

3. OffCanvas + FieldSelect/Checkbox (UIP-INPUT-FILTER_PANEL)
- `cobertura`: filtros avançados em drawer End; botão "Limpar" + "Aplicar";
- `nota`: 9;
- `justificativa`: filtros avançados em painel lateral.

### Zona: Coleção

1. Container+Slot + Box/Bar (UIP-DATA-CARD_GRID)
- `cobertura`: grade responsiva 2-4 colunas; card com imagem, título, badge, ações;
- `nota`: 9;
- `justificativa`: coleção em grade — ponto forte da lib.

2. Stack + Bar/Box (UIP-DATA-LIST_ITEM)
- `cobertura`: alternativa em lista densa para catálogos de dados;
- `nota`: 8;
- `justificativa`: coleção em lista.

3. Feedback Style=Light (empty state)
- `cobertura`: "Nenhum resultado para os filtros aplicados" + botão "Limpar filtros";
- `nota`: 9;
- `justificativa`: estado vazio da coleção.

### Zona: Ações

1. Pagination (UIP-NAV-PAGINATION)
- `cobertura`: paginação abaixo da grade;
- `nota`: 9;
- `justificativa`: navegação entre páginas da coleção.

2. DropIconButton + DropItem (UIP-ACTION-CONTEXTUAL_MENU)
- `cobertura`: ações por item no card (ver, editar, excluir);
- `nota`: 9;
- `justificativa`: ações contextuais por item.

**Descartados**: nenhum.

## Composição completa da página

```razor
@page "/catalogo"
@code {
    private string busca = "";
    private string? categoriaFiltro;
    private int pagina = 1;
    private int totalPaginas;
    private List<ItemDto> itens = [];
    private bool carregando;
    private bool modoLista;
    private CancellationTokenSource? _debounce;

    protected override async Task OnInitializedAsync() => await Buscar();

    private async Task OnBusca(ChangeEventArgs e)
    {
        busca = e.Value?.ToString() ?? "";
        _debounce?.Cancel();
        _debounce = new CancellationTokenSource();
        try
        {
            await Task.Delay(350, _debounce.Token);
            pagina = 1;
            await Buscar();
        }
        catch (TaskCanceledException) { }
    }

    private async Task Buscar()
    {
        carregando = true;
        var resultado = await Service.PesquisarAsync(busca, categoriaFiltro, pagina);
        itens = resultado.Itens;
        totalPaginas = resultado.TotalPaginas;
        carregando = false;
    }
}

@* Cabeçalho com busca e filtros *@
<Bar AdditionalClasses="mb-4 flex-wrap gap-2">
    <StartContent>
        <TextField @bind-Value="busca"
                   @oninput="OnBusca"
                   Placeholder="Buscar no catálogo..." AdditionalClasses="w-64" />
        @if (!string.IsNullOrEmpty(busca) || categoriaFiltro is not null)
        {
            <div class="flex gap-1 flex-wrap">
                @if (!string.IsNullOrEmpty(busca))
                {
                    <span class="flex items-center gap-1 px-2 py-0.5 bg-primary-100
                                 text-primary-700 text-xs rounded-full">
                        "@busca"
                        <button @onclick='() => { busca = ""; Buscar(); }' class="text-primary-500 hover:text-primary-700">×</button>
                    </span>
                }
                @if (categoriaFiltro is not null)
                {
                    <span class="flex items-center gap-1 px-2 py-0.5 bg-light-200
                                 text-dark-600 text-xs rounded-full">
                        @categoriaFiltro
                        <button @onclick='() => { categoriaFiltro = null; Buscar(); }' class="text-dark-400 hover:text-dark-600">×</button>
                    </span>
                }
            </div>
        }
    </StartContent>
    <EndContent>
        @* Toggle grid/lista *@
        <IconButton Icon="@(modoLista ? WellKnownIcons.Grid : WellKnownIcons.List)"
                   Style="Themes.Default" Size="Sizes.Small"
                   OnClick="() => modoLista = !modoLista" />
        @* Filtros avançados *@
        <Button Style="Themes.Default" Label="Filtros"
                OnClick='() => OffCanvasService.Open<FiltrosDrawer>(p =>
                    p.Add(x => x.OnAplicar, EventCallback.Factory.Create<FiltrosDto>(this, AplicarFiltros)))' />
        <span class="text-xs text-dark-400">@itens.Count resultado(s)</span>
    </EndContent>
</Bar>

@* Coleção *@
@if (carregando)
{
    <Container Columns="3">
        @for (int i = 0; i < 6; i++)
        {
            <Slot>
                <Box Border="BorderBuilder.Box" AdditionalClasses="overflow-hidden">
                    <div class="animate-pulse bg-light-200 h-36 w-full"></div>
                    <div class="p-3 space-y-2">
                        <div class="animate-pulse h-4 bg-light-200 rounded w-3/4"></div>
                        <div class="animate-pulse h-3 bg-light-100 rounded w-1/2"></div>
                    </div>
                </Box>
            </Slot>
        }
    </Container>
}
else if (!itens.Any())
{
    <Feedback Style="Themes.Light" Text="Nenhum item encontrado para os filtros aplicados.">
        <ChildContent>
            <Button Style="Themes.Default" Size="Sizes.Small" Label="Limpar filtros"
                    OnClick='() => { busca = ""; categoriaFiltro = null; Buscar(); }' />
        </ChildContent>
    </Feedback>
}
else if (modoLista)
{
    <Stack Gap="Gaps.Small">
        @foreach (var item in itens)
        {
            <Box Border="BorderBuilder.Box"
                 AdditionalClasses="p-3 cursor-pointer hover:shadow-sm transition-shadow"
                 @onclick="() => AbrirItem(item.Id)">
                <Bar>
                    <StartContent>
                        <div>
                            <p class="font-semibold text-sm text-dark-600">@item.Nome</p>
                            <p class="text-xs text-dark-400">@item.Descricao</p>
                        </div>
                    </StartContent>
                    <EndContent>
                        <Badge Style="@item.CategoriaTema" Text="@item.Categoria" />
                        <DropIconButton Icon="WellKnownIcons.MoreVertical"
                                       Style="Themes.Default" Size="Sizes.Small">
                            <DropItem Label="Ver" OnClick="() => AbrirItem(item.Id)" />
                            <DropItem Label="Editar" OnClick="() => Editar(item.Id)" />
                            <DropItem Label="Excluir" Style="Themes.Danger"
                                      OnClick="() => Excluir(item.Id)" />
                        </DropIconButton>
                    </EndContent>
                </Bar>
            </Box>
        }
    </Stack>
}
else
{
    <Container Columns="3">
        @foreach (var item in itens)
        {
            <Slot>
                <Box Border="BorderBuilder.Box"
                     AdditionalClasses="overflow-hidden cursor-pointer hover:shadow-md transition-shadow"
                     @onclick="() => AbrirItem(item.Id)">
                    @if (item.ImagemUrl is not null)
                    {
                        <img src="@item.ImagemUrl" alt="@item.Nome"
                             class="w-full h-36 object-cover" />
                    }
                    <div class="p-3">
                        <Bar AdditionalClasses="mb-1">
                            <StartContent>
                                <p class="font-semibold text-sm text-dark-600">@item.Nome</p>
                            </StartContent>
                            <EndContent>
                                <Badge Style="@item.CategoriaTema" Text="@item.Categoria" />
                            </EndContent>
                        </Bar>
                        <p class="text-xs text-dark-400 mb-2">@item.Descricao</p>
                        <Bar>
                            <EndContent>
                                <DropIconButton Icon="WellKnownIcons.MoreVertical"
                                               Style="Themes.Default" Size="Sizes.Small">
                                    <DropItem Label="Ver" OnClick="() => AbrirItem(item.Id)" />
                                    <DropItem Label="Editar" OnClick="() => Editar(item.Id)" />
                                    <DropItem Label="Excluir" Style="Themes.Danger"
                                              OnClick="() => Excluir(item.Id)" />
                                </DropIconButton>
                            </EndContent>
                        </Bar>
                    </div>
                </Box>
            </Slot>
        }
    </Container>
}

<Pagination CurrentPage="@pagina" TotalPages="@totalPaginas"
            OnPageChanged="async p => { pagina = p; await Buscar(); }"
            AdditionalClasses="mt-6" />
```

## Decisão de uso

- `nota geral`: 8;
- `limitações`: toggle grid/lista é lógica C# manual; chips de filtro ativo são HTML manual; sem facetas dinâmicas nativas;
- `recomendação`: `usar por composição`
- `justificativa geral`:
  - `Container+Slot` + `Pagination` + `OffCanvas` (filtros) + `FieldText` (busca) cobrem o catalog com alta qualidade;
  - Nota 8 reflete excelente cobertura — PP-CATALOG é um dos page patterns mais bem suportados pela lib.
