# BreadcrumbItem - Sample

## Visão geral
- **Propósito**: item individual de `Breadcrumb`, com href ou callback.
- **Complexidade**: 3
- **Patterns cobertos**: UIP-NAV-BREADCRUMB
- **Variações demonstradas**: link e item ativo.

## Exemplos

### UIP-NAV-BREADCRUMB

**Objetivo**: declarar item navegável e item atual.

```razor
<Breadcrumb>
    <Items>
        <BreadcrumbItem Href="/produtos">Produtos</BreadcrumbItem>
        <BreadcrumbItem Active="true">Produto 001</BreadcrumbItem>
    </Items>
</Breadcrumb>
```

**Props usadas**: `Href`, `Active`, `ChildContent`.  
**Eventos relevantes**: `OnClick` opcional.  
**Por que atende o pattern**: diferencia retorno navegável e nível atual.

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| `Href` | `string` | item navegável | gera `NavLink` |
| `Active` | `bool` | item atual | aplica estado ativo |
| `Match` | `NavLinkMatch` | controle de rota ativa | define correspondência |
| `OnClick` | `EventCallback<MouseEventArgs>` | callback custom | substitui navegação direta |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| `OnClick` | clique | navegação controlada |

## Limitações
- Não deve conter ações que não sejam navegação hierárquica.

## Combinações frágeis
- `Active=true` com navegação para outro nível confunde o usuário.
