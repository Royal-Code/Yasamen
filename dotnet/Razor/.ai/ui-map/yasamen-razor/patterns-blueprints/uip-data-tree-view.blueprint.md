# UIP-DATA-TREE_VIEW - Blueprint completo

## Pattern

UIP-DATA-TREE_VIEW — Tree View — ver `uip-data-tree-view.ui-map.md`

## Gap coberto

A lib não tem componente de árvore hierárquica. O gap é orientar: componente Razor recursivo `TreeNode.razor`, estado de nós expandidos via `HashSet<int>`, passagem do estado com `CascadingValue`, indentação por nível via `ml-4`, toggle de expansão com `IconButton`, e ações contextuais por nó com `DropIconButton`.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: componente Razor recursivo próprio `TreeNode.razor` usando `Bar + IconButton + DropIconButton`; estado `HashSet<int> nodosExpandidos` no pai; indentação via `ml-4 border-l border-light-200 pl-2` por nível; seleção de nó via callback `EventCallback<int>`.
- `eixos cobertos sem componente novo`:
  - toggle de expansão → `IconButton(ChevronRight/ChevronDown)`;
  - ações contextuais → `DropIconButton + DropItem`;
  - linha de nó → `Bar` com hover e onClick;
  - indentação e linha guia → `ml-4 border-l border-light-200 pl-2` por nível.

## Componentes usados

- `Bar` — papel: composição (linha de nó) — ver `bar.sample.md`
- `IconButton` — papel: composição (toggle expandir/recolher) — ver `button.sample.md`
- `DropIconButton` — papel: composição (ações por nó) — ver `button.sample.md`
- `DropItem` — papel: composição (itens de ação) — ver `button.sample.md`

## Recursos visuais

- `ml-4 border-l border-light-200 pl-2` — indentação com linha guia por nível
- `hover:bg-light-50 rounded cursor-pointer` — linha de nó interativo
- `bg-primary-50 text-primary-700` — nó selecionado
- `w-6` — espaço reservado para o ícone de expansão em nós folha (alinhamento)

## Receita

### Estrutura base

Componente `TreeNode.razor` recursivo + uso no componente pai.

```razor
@* TreeNode.razor *@
@code {
    [Parameter] public TreeItemDto Item { get; set; } = default!;
    [Parameter] public HashSet<int> Expandidos { get; set; } = default!;
    [Parameter] public int? IdSelecionado { get; set; }
    [Parameter] public EventCallback<int> OnSelecionar { get; set; }
    [Parameter] public EventCallback<(int id, string acao)> OnAcao { get; set; }

    private bool IsExpandido => Expandidos.Contains(Item.Id);

    private void ToggleExpandir()
    {
        if (IsExpandido) Expandidos.Remove(Item.Id);
        else Expandidos.Add(Item.Id);
    }
}

<div>
    <Bar AdditionalClasses="@($"py-1 rounded cursor-pointer {(IdSelecionado == Item.Id ? "bg-primary-50" : "hover:bg-light-50")}")"
         @onclick="() => OnSelecionar.InvokeAsync(Item.Id)">
        <StartContent>
            <div class="flex items-center gap-1">
                @if (Item.TemFilhos)
                {
                    <IconButton
                        Icon="@(IsExpandido ? WellKnownIcons.ChevronDown : WellKnownIcons.ChevronRight)"
                        Style="Themes.Default" Size="Sizes.Small"
                        OnClick:stopPropagation OnClick="ToggleExpandir" />
                }
                else
                {
                    <div class="w-6"></div>
                }
                <span class="text-sm @(IdSelecionado == Item.Id ? "text-primary-700 font-medium" : "text-dark-600")">
                    @Item.Nome
                </span>
            </div>
        </StartContent>
        <EndContent>
            <DropIconButton Icon="WellKnownIcons.MoreVertical"
                            Style="Themes.Default" Size="Sizes.Small"
                            OnClick:stopPropagation>
                <DropItem Label="Renomear"
                          OnClick="() => OnAcao.InvokeAsync((Item.Id, "renomear"))" />
                <DropItem Label="Nova pasta"
                          OnClick="() => OnAcao.InvokeAsync((Item.Id, "nova-pasta"))" />
                <hr class="my-1 border-light-200" />
                <DropItem Label="Excluir" Style="Themes.Danger"
                          OnClick="() => OnAcao.InvokeAsync((Item.Id, "excluir"))" />
            </DropIconButton>
        </EndContent>
    </Bar>

    @* Filhos — recursão *@
    @if (IsExpandido && Item.Filhos?.Any() == true)
    {
        <div class="ml-4 border-l border-light-200 pl-2">
            @foreach (var filho in Item.Filhos)
            {
                <TreeNode Item="filho"
                          Expandidos="Expandidos"
                          IdSelecionado="IdSelecionado"
                          OnSelecionar="OnSelecionar"
                          OnAcao="OnAcao" />
            }
        </div>
    }
</div>
```

```razor
@* Uso do TreeNode no componente pai *@
@code {
    private List<TreeItemDto> raiz = [];
    private HashSet<int> expandidos = [];
    private int? idSelecionado;

    protected override async Task OnInitializedAsync()
        => raiz = await ArvoreSvc.ObterRaizAsync();

    private async Task OnSelecionarNo(int id)
    {
        idSelecionado = id;
        await CarregarDetalheNo(id);
    }

    private async Task OnAcaoNo((int id, string acao) args)
    {
        switch (args.acao)
        {
            case "renomear":
                await RenomearNo(args.id);
                break;
            case "excluir":
                await ExcluirNo(args.id);
                raiz = await ArvoreSvc.ObterRaizAsync();
                break;
            case "nova-pasta":
                await NovaSubpasta(args.id);
                raiz = await ArvoreSvc.ObterRaizAsync();
                expandidos.Add(args.id);
                break;
        }
    }
}

<div class="border border-light-200 rounded-md p-2 overflow-y-auto max-h-96">
    @if (!raiz.Any())
    {
        <p class="text-xs text-dark-400 text-center py-4">Estrutura vazia.</p>
    }
    else
    {
        @foreach (var no in raiz)
        {
            <TreeNode Item="no"
                      Expandidos="expandidos"
                      IdSelecionado="idSelecionado"
                      OnSelecionar="OnSelecionarNo"
                      OnAcao="OnAcaoNo" />
        }
    }
</div>
```

### Cenários de composição

#### Árvore com lazy loading de filhos

```razor
@* TreeNode.razor — variante com lazy loading *@
@code {
    [Parameter] public TreeItemDto Item { get; set; } = default!;
    [Parameter] public Func<int, Task<List<TreeItemDto>>> CarregarFilhos { get; set; } = default!;
    [Parameter] public HashSet<int> Expandidos { get; set; } = default!;

    private bool carregandoFilhos;

    private async Task ToggleExpandirAsync()
    {
        if (Expandidos.Contains(Item.Id))
        {
            Expandidos.Remove(Item.Id);
            return;
        }
        if (Item.TemFilhos && Item.Filhos is null)
        {
            carregandoFilhos = true;
            Item = Item with { Filhos = await CarregarFilhos(Item.Id) };
            carregandoFilhos = false;
        }
        Expandidos.Add(Item.Id);
    }
}
```

#### Árvore de busca com destaque

```razor
@code {
    private string filtroArvore = "";

    private bool NoCorresponde(TreeItemDto no) =>
        string.IsNullOrEmpty(filtroArvore) ||
        no.Nome.Contains(filtroArvore, StringComparison.OrdinalIgnoreCase);
}

<div class="flex flex-col gap-2">
    <input type="search"
           @bind="filtroArvore" @bind:event="oninput"
           placeholder="Filtrar..."
           class="w-full border border-light-300 rounded px-2 py-1 text-sm" />
    <div class="overflow-y-auto max-h-80">
        @foreach (var no in raiz.Where(n => NoCorresponde(n)))
        {
            <TreeNode Item="no" Expandidos="expandidos"
                      OnSelecionar="OnSelecionarNo" OnAcao="OnAcaoNo" />
        }
    </div>
</div>
```

### Estados de página

- `loading`: substitui a div da árvore por 5 linhas `animate-pulse bg-light-200 h-4 rounded` com diferentes larguras e `ml-4` escalonado;
- `empty`: `<p class="text-xs text-dark-400 text-center py-4">Estrutura vazia.</p>`;
- `error`: `<Feedback Style="Themes.Danger" Text="Erro ao carregar.">`  com `Button "Tentar novamente"`.

## Limites

- Sem componente de tree view nativo — `TreeNode.razor` precisa ser criado no projeto consumidor;
- Profundidade muito grande (> 5 níveis) pode causar problemas de performance sem lazy loading;
- Seleção múltipla e checkbox tristate (parcialmente selecionado) requerem lógica adicional no app;
- Drag & drop entre nós é GAP — `UIP-INTERACTION-DRAG_DROP` não tem suporte nativo; alternativa: `DropItem "Mover para"`;
- `HashSet<int> expandidos` é passado por referência — cuidado com mutação em renderizações paralelas;
- Busca/filtro na árvore não expande automaticamente os pais dos nós encontrados — requer lógica de expansão recursiva.

### Coordenação

Estado `expandidos` deve ser centralizado no componente pai e passado por parâmetro para que `StateHasChanged()` funcione corretamente após modificação. Não usar `CascadingValue` para estado mutável — pode causar re-renders excessivos.
