# Pagination - Sample

## Visão geral
- **Propósito**: paginação responsiva para listas, tabelas e grids.
- **Complexidade**: 6
- **Patterns cobertos**: UIP-NAV-PAGINATION, PP-CATALOG, PP-LIST-DETAIL
- **Variações demonstradas**: loading, single-page mode, estado externo.

## Exemplos

### UIP-NAV-PAGINATION

**Objetivo**: controlar página atual com estado externo.

```razor
<Pagination CurrentPage="@page"
            TotalPages="@totalPages"
            Size="Sizes.Medium"
            OnPageChanged="@SetPage" />

@code {
    private int page = 1;
    private int totalPages = 12;
    private Task SetPage(int value) { page = value; return Task.CompletedTask; }
}
```

**Props usadas**: `CurrentPage`, `TotalPages`, `Size`, `OnPageChanged`.  
**Eventos relevantes**: `OnPageChanged` recebe a nova página.  
**Por que atende o pattern**: entrega navegação discreta entre páginas.

### Estado de carregamento e página única

**Objetivo**: evitar clique duplicado e tratar coleção pequena.

```razor
<Pagination CurrentPage="1"
            TotalPages="1"
            Loading="@loading"
            SinglePageMode="PaginationSinglePageMode.Message"
            SinglePageMessage="Todos os resultados cabem em uma única página."
            OnPageChanged="@(_ => Task.CompletedTask)" />

@code {
    private bool loading;
}
```

**Props usadas**: `Loading`, `SinglePageMode`, `SinglePageMessage`.  
**Eventos relevantes**: `OnPageChanged`.  
**Por que atende o pattern**: cobre estados próprios da paginação.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `CurrentPage` | `int` | sempre | página ativa |
| `TotalPages` | `int` | sempre | limite |
| `Loading` | `bool` | troca pendente | desabilita navegação |
| `DesktopWindowSize` | `int` | janela numérica | controla quantidade de páginas |
| `SinglePageMode` | `PaginationSinglePageMode` | total 1 | renderiza/oculta/mensagem |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| `OnPageChanged` | usuário troca página | buscar dados |

## Limitações
- Não é infinite scroll.

## Combinações frágeis
- `TotalPages` inconsistente com dados causa navegação sem resultado.
