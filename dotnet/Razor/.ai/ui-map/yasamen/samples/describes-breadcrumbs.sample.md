# DescribesBreadcrumbs - Sample

## Visão geral
- **Propósito**: gerar breadcrumb a partir de uma lista de descrições.
- **Complexidade**: 5
- **Patterns cobertos**: UIP-NAV-BREADCRUMB, PP-DETAIL
- **Variações demonstradas**: truncamento e callback.

## Exemplos

### UIP-NAV-BREADCRUMB

**Objetivo**: renderizar trilha com truncamento automático.

```razor
<DescribesBreadcrumbs Items="items" MaxVisibleItems="3" />

@code {
    private readonly IReadOnlyList<BreadcrumbDescription> items =
    [
        new() { Description = "Admin", HRef = "/admin" },
        new() { Description = "Clientes", HRef = "/clientes" },
        new() { Description = "Cliente 42", HRef = "/clientes/42" },
        new() { Description = "Contratos" }
    ];
}
```

**Props usadas**: `Items`, `MaxVisibleItems`.  
**Eventos relevantes**: navegação usa `HRef` quando não há `OnClick`.  
**Por que atende o pattern**: preserva hierarquia e compacta intermediários.

### Callback custom

**Objetivo**: controlar clique sem navegação direta.

```razor
<DescribesBreadcrumbs Items="items" MaxVisibleItems="2" OnClick="@SelectLevel" />

@code {
    private Task SelectLevel(BreadcrumbDescription item) => Task.CompletedTask;
}
```

**Props usadas**: `OnClick`.  
**Eventos relevantes**: `OnClick` recebe `BreadcrumbDescription`.  
**Por que atende o pattern**: permite breadcrumb dentro de menu/estado local.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `Items` | `IReadOnlyList<BreadcrumbDescription>` | sempre | origem da trilha |
| `MaxVisibleItems` | `int` | truncamento | controla overflow |
| `OnClick` | `EventCallback<BreadcrumbDescription>` | navegação custom | intercepta clique |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| `OnClick` | clique em nível | atualizar contexto |

## Limitações
- Requer modelo `BreadcrumbDescription`.

## Combinações frágeis
- `MaxVisibleItems` muito baixo pode ocultar contexto importante.
