# UIP-DATA-TREE_VIEW - Tree View

**GAP parcial — sem componente dedicado**

A biblioteca não tem componente de tree view. Requer composição com `Stack` + `Bar`/`Box` recursivos + estado de nós expandidos + ícone de expansão via `Button`.

## Componentes

**Principais**: nenhum dedicado.

**Composição**:

1. Stack
- `cobertura`: container de nós do mesmo nível com espaçamento; indentação via `ml-4` para filhos;
- `nota`: 6;
- `justificativa`: sequência de nós com espaçamento — base da árvore.

2. Bar
- `cobertura`: linha de nó com ícone de expandir + label + ações contextuais por nó;
- `nota`: 6;
- `justificativa`: linha de nó individual com controle de expansão.

3. IconButton
- `cobertura`: toggle de expansão/recolhimento de nó (ícone ▶/▼); `Disabled` para nós sem filhos;
- `nota`: 7;
- `justificativa`: controle de expansão visual do nó.

4. DropIconButton
- `cobertura`: ações contextuais por nó (renomear, excluir, mover);
- `nota`: 7;
- `justificativa`: menu de ações por nó da árvore.

**Descartados**: nenhum.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `recursão de nós`: componente Razor recursivo (`@ref="this"` ou componente filho separado);
  - `lazy loading de filhos`: API call ao expandir nó + estado `carregandoNos[id]`;
  - `seleção com propagação para filhos`: lógica de checkbox tristate no app;
  - `drag/drop entre nós`: sem nativo — `UIP-INTERACTION-DRAG_DROP` é GAP.

- `tipo de adaptação`: composição + componente Razor recursivo
- `o que precisa ser feito`:
  - Criar componente `TreeNode.razor` que renderiza o nó atual e filhos recursivamente;
  - Estado `HashSet<int> nodosExpandidos` no componente raiz ou passado por CascadingValue;
  - `DropIconButton` por nó para ações contextuais.

## Como usar

### Componente recursivo de nó de árvore

```razor
@* TreeNode.razor *@
@code {
    [Parameter] public TreeItemDto Item { get; set; } = default!;
    [Parameter] public HashSet<int> Expandidos { get; set; } = default!;
    [Parameter] public EventCallback<int> OnSelecionar { get; set; }

    private bool IsExpandido => Expandidos.Contains(Item.Id);
    private void ToggleExpandir()
    {
        if (IsExpandido) Expandidos.Remove(Item.Id);
        else Expandidos.Add(Item.Id);
    }
}

<div>
    <Bar AdditionalClasses="py-1 hover:bg-light-50 rounded cursor-pointer"
         @onclick="() => OnSelecionar.InvokeAsync(Item.Id)">
        <StartContent>
            <div class="flex items-center gap-1">
                @if (Item.TemFilhos)
                {
                    <IconButton Icon="@(IsExpandido ? WellKnownIcons.ChevronDown : WellKnownIcons.ChevronRight)"
                               Style="Themes.Default" Size="Sizes.Small"
                               OnClick:stopPropagation
                               OnClick="ToggleExpandir" />
                }
                else
                {
                    <div class="w-6"></div>
                }
                @WellKnownIcons.Folder("text-dark-400 text-sm")
                <span class="text-sm text-dark-600">@Item.Nome</span>
            </div>
        </StartContent>
        <EndContent>
            <DropIconButton Icon="WellKnownIcons.MoreVertical"
                           Style="Themes.Default" Size="Sizes.Small">
                <DropItem Label="Renomear" OnClick="() => Renomear(Item.Id)" />
                <DropItem Label="Excluir" Style="Themes.Danger"
                          OnClick="() => Excluir(Item.Id)" />
            </DropIconButton>
        </EndContent>
    </Bar>
    @if (IsExpandido && Item.Filhos?.Any() == true)
    {
        <div class="ml-4 border-l border-light-200 pl-2">
            @foreach (var filho in Item.Filhos)
            {
                <TreeNode Item="filho" Expandidos="Expandidos" OnSelecionar="OnSelecionar" />
            }
        </div>
    }
</div>
```

### Uso do componente de árvore

```razor
@code {
    private HashSet<int> expandidos = [];
    private List<TreeItemDto> raiz = [];
}

<div class="border border-light-200 rounded-md p-2">
    @foreach (var no in raiz)
    {
        <TreeNode Item="no" Expandidos="expandidos"
                  OnSelecionar="(id) => SelecionarNo(id)" />
    }
</div>
```

## Decisão de uso

- `nota geral`: 2;
- `limitações`: sem componente de tree view nativo; requer componente Razor recursivo manual; expansão, seleção e lazy loading são responsabilidade do app; sem drag/drop entre nós; sem busca nativa na árvore;
- `recomendação`: `usar com adaptação`
- `justificativa geral`:
  - `Bar` + `IconButton` + `DropIconButton` + recursão Razor cobrem tree view funcional;
  - A lib contribui apenas com os primitivos de linha e ações — toda estrutura hierárquica é do app;
  - Nota 2 reflete que tree view requer implementação substancial de componente recursivo próprio.
