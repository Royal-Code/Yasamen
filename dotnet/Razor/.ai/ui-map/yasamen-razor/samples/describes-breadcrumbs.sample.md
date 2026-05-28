# DescribesBreadcrumbs - Sample

## Contrato de uso

**Entrada pública**: `<DescribesBreadcrumbs>` — namespace `RoyalCode.Razor.Breadcrumbs`
**Grupo**: UI-NAV
**Propósito**: Breadcrumb inteligente que recebe lista de `BreadcrumbDescription` e aplica automaticamente limite de visíveis, com overflow em dropdown.
**Patterns**:
- `implementa`: UIP-NAV-BREADCRUMB
- `compõe`: -
**Setup necessário**: `<YasamenStyles />` no `<head>`

## Regras rápidas

- **Use para**: breadcrumbs com número dinâmico de itens ou onde o limite de visíveis precisa ser controlado; substitui `Breadcrumb`+`BreadcrumbItem` quando os itens vêm de dados
- **Evite quando**: a trilha é estática com número fixo de itens — use `Breadcrumb` diretamente

## Exemplos

### `UIP-NAV-BREADCRUMB` — Breadcrumb dinâmico a partir de dados

`BreadcrumbDescription` deve ter pelo menos `Label` e opcionalmente `HRef` para navegação automática.

```razor
@code {
    private IReadOnlyList<BreadcrumbDescription> trilha = [];

    protected override void OnInitialized()
    {
        trilha =
        [
            new BreadcrumbDescription { Label = "Admin", HRef = "/admin" },
            new BreadcrumbDescription { Label = "Departamentos", HRef = "/admin/depto" },
            new BreadcrumbDescription { Label = "TI", HRef = "/admin/depto/ti" },
            new BreadcrumbDescription { Label = "Equipes", HRef = "/admin/depto/ti/equipes" },
            new BreadcrumbDescription { Label = "Frontend" }  @* último item = ativo *@
        ];
    }

    private void OnItemClicado(BreadcrumbDescription item)
    {
        @* Navegação é feita automaticamente via HRef se definido *@
        Console.WriteLine($"Clicou: {item.Label}");
    }
}

<DescribesBreadcrumbs Items="@trilha"
                      MaxVisibleItems="3"
                      OnClick="OnItemClicado"
                      AdditionalClasses="mb-4" />
```

**API usada**: `Items`, `MaxVisibleItems`, `OnClick`
**Nota**: Com `MaxVisibleItems=3` e 5 itens, os 2 intermediários vão para o dropdown de overflow. Navega automaticamente via `NavigationManager.NavigateTo` se `HRef` estiver definido no `BreadcrumbDescription`.

## API relevante

- **Props/parâmetros**: `Items: IReadOnlyList<BreadcrumbDescription>` (EditorRequired), `MaxVisibleItems: int` (EditorRequired), `OnClick: EventCallback<BreadcrumbDescription>`
- `BreadcrumbDescription` tem pelo menos `Label: string` e `HRef: string?`
