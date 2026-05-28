# PP-LIST-DETAIL - List Detail

## Componentes por zona funcional

### Zona: Coleção

**Principais**:

1. Stack + Bar/Box (UIP-DATA-LIST_ITEM)
- `cobertura`: lista de itens com hover, seleção ativa (`bg-primary-50`), badge de status;
- `nota`: 8;
- `justificativa`: coleção de itens com seleção — padrão direto.

2. HTML `<table>` + Tailwind (UIP-DATA-DATA_TABLE)
- `cobertura`: alternativa em grade com colunas, cabeçalho de sort, seleção de linha;
- `nota`: 6;
- `justificativa`: tabela como coleção para dados densos.

### Zona: Filtros

1. Bar + FieldText (busca) + DropButton (filtros rápidos)
- `cobertura`: barra de busca + filtros de contexto acima da coleção;
- `nota`: 8;
- `justificativa`: toolbar de filtros inline.

2. OffCanvas (UIP-INPUT-FILTER_PANEL)
- `cobertura`: filtros avançados em drawer lateral;
- `nota`: 9;
- `justificativa`: painel de filtros avançados.

### Zona: Detalhe

1. Box + Bar + dl/dd (UIP-CONTENT-DETAIL_BLOCK)
- `cobertura`: detalhe de entidade selecionada com campos, badges, ações;
- `nota`: 7;
- `justificativa`: detalhe legível do item selecionado.

2. Feedback Style=Light (empty state)
- `cobertura`: "Selecione um item para ver os detalhes";
- `nota`: 9;
- `justificativa`: estado vazio do painel de detalhe.

### Zona: Ações

1. Bar + Button/IconButton (UIP-ACTION-ACTION_BAR)
- `cobertura`: ações do item selecionado (editar, excluir, mover); ações de coleção (novo item);
- `nota`: 9;
- `justificativa`: toolbar de ações da página.

2. DropIconButton + DropItem (UIP-ACTION-CONTEXTUAL_MENU)
- `cobertura`: menu de ações por item na lista (editar, excluir, duplicar);
- `nota`: 9;
- `justificativa`: ações contextuais por item.

### Zona: Layout

1. Split panel CSS (UIP-STRUCT-SPLIT_PANEL)
- `cobertura`: `flex h-full` com painel esquerdo (lista) + painel direito (detalhe); responsivo com hidden/flex;
- `nota`: 6;
- `justificativa`: layout split manual — funcional, sem abstração.

**Descartados**: Container+Slot (grade de colunas iguais, não split assimétrico com seleção).

## Composição completa da página

```razor
@page "/itens"
@code {
    private List<ItemDto> itens = [];
    private ItemDto? selecionado;
    private bool mostrarDetalheMobile;
    private string busca = "";
    private bool carregando = true;

    protected override async Task OnInitializedAsync()
    {
        itens = await Service.ListarAsync();
        carregando = false;
    }

    private void Selecionar(ItemDto item)
    {
        selecionado = item;
        mostrarDetalheMobile = true;
    }

    private IEnumerable<ItemDto> ItensFiltrados =>
        string.IsNullOrEmpty(busca) ? itens
        : itens.Where(i => i.Nome.Contains(busca, StringComparison.OrdinalIgnoreCase));
}

@* Barra de ações da página *@
<Bar AdditionalClasses="mb-4">
    <StartContent>
        <TextField @bind-Value="busca" Placeholder="Buscar itens..." @oninput="FiltrarLocal" />
    </StartContent>
    <EndContent>
        <Button Style="Themes.Primary" Label="Novo item"
                OnClick="() => ModalService.Open<NovoItemModal>()" />
    </EndContent>
</Bar>

@* Layout split *@
<div class="flex border border-light-200 rounded-md overflow-hidden" style="height: calc(100vh - 160px);">
    @* Painel de lista *@
    <div class="@(mostrarDetalheMobile ? "hidden lg:flex" : "flex") flex-col
                w-full lg:w-80 flex-shrink-0 border-r border-light-200">
        @if (carregando)
        {
            <div class="p-3 space-y-2">
                @for (int i = 0; i < 8; i++)
                {
                    <div class="animate-pulse h-14 bg-light-100 rounded"></div>
                }
            </div>
        }
        else if (!ItensFiltrados.Any())
        {
            <div class="flex-1 flex items-center justify-center p-4">
                <Feedback Style="Themes.Light" Text="Nenhum item encontrado." />
            </div>
        }
        else
        {
            <div class="overflow-y-auto flex-1">
                @foreach (var item in ItensFiltrados)
                {
                    <div class="border-b border-light-100 last:border-0">
                        <Bar AdditionalClasses="px-3 py-3 cursor-pointer transition-colors
                                               @(selecionado?.Id == item.Id
                                                 ? "bg-primary-50"
                                                 : "hover:bg-light-50")"
                             @onclick="() => Selecionar(item)">
                            <StartContent>
                                <div>
                                    <p class="text-sm font-medium @(selecionado?.Id == item.Id ? "text-primary-700" : "text-dark-600")">
                                        @item.Nome
                                    </p>
                                    <p class="text-xs text-dark-400 mt-0.5">@item.Subtitulo</p>
                                </div>
                            </StartContent>
                            <EndContent>
                                <div class="flex items-center gap-1">
                                    <Badge Style="@item.StatusTema" Text="@item.Status" />
                                    <DropIconButton Icon="WellKnownIcons.MoreVertical"
                                                   Style="Themes.Default" Size="Sizes.Small">
                                        <DropItem Label="Editar"
                                                  OnClick="() => Editar(item)" />
                                        <DropItem Label="Excluir" Style="Themes.Danger"
                                                  OnClick="() => ConfirmarExclusao(item)" />
                                    </DropIconButton>
                                </div>
                            </EndContent>
                        </Bar>
                    </div>
                }
            </div>
        }
    </div>

    @* Painel de detalhe *@
    <div class="@(mostrarDetalheMobile ? "flex" : "hidden lg:flex") flex-col flex-1 overflow-hidden">
        @if (selecionado is null)
        {
            <div class="flex-1 flex items-center justify-center">
                <Feedback Style="Themes.Light"
                          Text="Selecione um item para ver os detalhes." />
            </div>
        }
        else
        {
            @* Header do detalhe *@
            <Bar AdditionalClasses="px-4 py-3 border-b border-light-200 bg-light-50">
                <StartContent>
                    @* Botão voltar mobile *@
                    <div class="flex items-center gap-2 lg:hidden">
                        <IconButton Icon="WellKnownIcons.ChevronLeft" Style="Themes.Default"
                                   OnClick="() => mostrarDetalheMobile = false" />
                    </div>
                    <div>
                        <h2 class="text-base font-semibold text-dark-700">@selecionado.Nome</h2>
                        <p class="text-xs text-dark-400">@selecionado.Descricao</p>
                    </div>
                </StartContent>
                <EndContent>
                    <Badge Style="@selecionado.StatusTema" Text="@selecionado.Status" />
                    <Button Style="Themes.Default" Size="Sizes.Small" Label="Editar"
                            OnClick="() => Editar(selecionado)" />
                    <IconButton Icon="WellKnownIcons.MoreVertical" Style="Themes.Default">
                        @* ações adicionais *@
                    </IconButton>
                </EndContent>
            </Bar>

            @* Conteúdo do detalhe *@
            <div class="flex-1 overflow-y-auto p-4">
                <dl class="grid grid-cols-1 sm:grid-cols-2 gap-x-6 gap-y-3 text-sm">
                    <div>
                        <dt class="text-dark-400 text-xs mb-0.5">Campo 1</dt>
                        <dd class="text-dark-600 font-medium">@selecionado.Campo1</dd>
                    </div>
                    <div>
                        <dt class="text-dark-400 text-xs mb-0.5">Campo 2</dt>
                        <dd class="text-dark-600 font-medium">@selecionado.Campo2</dd>
                    </div>
                </dl>
            </div>
        }
    </div>
</div>
```

## Decisão de uso

- `nota geral`: 6;
- `limitações`: split panel é CSS manual sem abstração dedicada; responsividade mobile/desktop é CSS `hidden/flex` manual; divisor ajustável não disponível; toda coordenação lista↔detalhe é lógica C# do app;
- `recomendação`: `usar por composição`
- `justificativa geral`:
  - `Stack`/`Bar`/`Box` + split CSS + `OffCanvas` + `Modal` + `Feedback` cobrem PP-LIST-DETAIL funcional e responsivo;
  - Os componentes de ação (`DropIconButton`, `Button`, `Bar`) são o ponto forte — operar sobre itens é direto;
  - Nota 6 reflete boa cobertura operacional com adaptação na estrutura split e filtros avançados.
