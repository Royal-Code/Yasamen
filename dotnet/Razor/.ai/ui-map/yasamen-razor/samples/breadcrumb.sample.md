# Breadcrumb - Sample

## Contrato de uso

**Entrada pública**: `<Breadcrumb>` — namespace `RoyalCode.Razor.Breadcrumbs`
**Grupo**: UI-NAV
**Propósito**: Trilha de navegação com suporte a menu dropdown de overflow para itens ocultos. Para lista dinâmica com limite de visíveis, usar `DescribesBreadcrumbs`.
**Patterns**:
- `implementa`: UIP-NAV-BREADCRUMB
- `compõe`: UIP-CONTENT-CONTENT_HEADER
**Setup necessário**: `<YasamenStyles />` no `<head>`

## Regras rápidas

- **Use para**: navegação hierárquica estática com número fixo de níveis
- **Evite quando**: o número de itens é dinâmico e pode exceder o espaço — use `DescribesBreadcrumbs`; para a trilha de submenu dentro do `AppMenu`, o componente já usa `DescribesBreadcrumbs` internamente

## Exemplos

### `UIP-NAV-BREADCRUMB, UIP-CONTENT-CONTENT_HEADER` — Breadcrumb estático com overflow

Use `Items` para itens visíveis e `MenuItems` para overflow (exibido em dropdown quando há itens ocultos).

```razor
@* Breadcrumb simples sem overflow *@
<Breadcrumb AdditionalClasses="mb-4">
    <Items>
        <BreadcrumbItem Href="/admin">Admin</BreadcrumbItem>
        <BreadcrumbItem Href="/admin/usuarios">Usuários</BreadcrumbItem>
        <BreadcrumbItem Href="/admin/usuarios/perfil" Active=true>
            Perfil de João Silva
        </BreadcrumbItem>
    </Items>
</Breadcrumb>

@* Breadcrumb com overflow: itens intermediários vão para MenuItems *@
<Breadcrumb>
    <Items>
        <BreadcrumbItem Href="/loja">Loja</BreadcrumbItem>
        @* ... ítens do overflow seriam exibidos como "..." *@
        <BreadcrumbItem Href="/loja/eletronicos/smartphones/apple" Active=true>
            iPhone 15 Pro
        </BreadcrumbItem>
    </Items>
    <MenuItems>
        <DropItem Label="Eletrônicos" OnClick='() => Nav.NavigateTo("/loja/eletronicos")' />
        <DropItem Label="Smartphones" OnClick='() => Nav.NavigateTo("/loja/eletronicos/smartphones")' />
        <DropItem Label="Apple" OnClick='() => Nav.NavigateTo("/loja/eletronicos/smartphones/apple")' />
    </MenuItems>
</Breadcrumb>
```

**API usada**: `Items` (BreadcrumbItem), `MenuItems` (DropItem para overflow)

## API relevante

- **Props/parâmetros**: `AdditionalClasses: string?`
- **Slots**: `Items: RenderFragment` — BreadcrumbItems visíveis; `MenuItems: RenderFragment` — DropItems no dropdown de overflow (exibido como "..." quando há itens)
