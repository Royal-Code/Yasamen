# BreadcrumbItem - Sample

## Contrato de uso

**Entrada pública**: `<BreadcrumbItem>` — namespace `RoyalCode.Razor.Breadcrumbs`
**Grupo**: UI-NAV
**Propósito**: Item individual de breadcrumb. Renderiza como `NavLink` (href) ou `<a>` com callback.
**Patterns**:
- `implementa`: -
- `compõe`: UIP-NAV-BREADCRUMB
**Setup necessário**: `<YasamenStyles />` no `<head>`; deve estar dentro de `Breadcrumb.Items`

## Regras rápidas

- **Use para**: cada item da trilha de navegação dentro do slot `Items` de `Breadcrumb`
- **Evite quando**: fora de `Breadcrumb` — use `NavLink` diretamente

## Exemplos

### `UIP-NAV-BREADCRUMB` — Itens de trilha de navegação

```razor
@* Via Href — NavLink com match de rota *@
<Breadcrumb>
    <Items>
        <BreadcrumbItem Href="/">Início</BreadcrumbItem>
        <BreadcrumbItem Href="/produtos">Produtos</BreadcrumbItem>
        <BreadcrumbItem Href="/produtos/eletronicos"
                        Match="NavLinkMatch.All">Eletrônicos</BreadcrumbItem>
        <BreadcrumbItem Active=true>Notebooks</BreadcrumbItem>
    </Items>
</Breadcrumb>

@* Via OnClick — para breadcrumb de estado interno *@
<Breadcrumb>
    <Items>
        <BreadcrumbItem OnClick="() => voltarRaiz()">Início</BreadcrumbItem>
        <BreadcrumbItem OnClick="() => voltarCategoria()">Documentos</BreadcrumbItem>
        <BreadcrumbItem Active=true>Relatório Q4</BreadcrumbItem>
    </Items>
</Breadcrumb>
```

**API usada**: `Href`, `Active`, `Match`, `OnClick`
**Nota**: O último item (item atual) normalmente usa `Active=true` e sem `Href` — renderiza como texto não clicável.

## API relevante

- **Props/parâmetros**: `Href: string`, `Active: bool`, `Match: NavLinkMatch` (default Prefix), `OnClick: EventCallback<MouseEventArgs>`, `ChildContent: RenderFragment?`
