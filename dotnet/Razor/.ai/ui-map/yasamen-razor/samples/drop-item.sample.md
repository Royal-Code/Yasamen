# DropItem - Sample

## Contrato de uso

**Entrada pública**: `<DropItem>` — namespace `RoyalCode.Razor.Drops`
**Grupo**: UI-OVERLAY
**Propósito**: Item de menu dentro de um dropdown. Renderiza como `<li>` quando ContentType=List ou `<div>` caso contrário.
**Patterns**:
- `implementa`: -
- `compõe`: UIP-ACTION-CONTEXTUAL_MENU, UIP-OVERLAY-POPOVER, UIP-NAV-BREADCRUMB
**Setup necessário**: `<YasamenStyles />` no `<head>`; deve estar dentro de `DropButton` ou `DropIconButton`

## Regras rápidas

- **Use para**: cada opção de ação dentro do conteúdo de `DropButton` ou `DropIconButton`
- **Evite quando**: fora de um contexto de dropdown

## Exemplos

### `UIP-ACTION-CONTEXTUAL_MENU, UIP-OVERLAY-POPOVER` — Itens de ação em dropdown

Cada `DropItem` representa uma opção; combine conteúdo customizado via `ChildContent` quando label simples não basta.

```razor
@* Uso básico com Label *@
<DropButton Label="Ações" Style="Themes.Default" ContentType="DropContentType.List">
    <DropItem Label="Ver detalhes" OnClick="() => Ver(item.Id)" />
    <DropItem Label="Editar" OnClick="() => Editar(item.Id)" />
    <DropItem Label="Excluir" OnClick="() => Excluir(item.Id)" />
</DropButton>

@* Item com conteúdo customizado (ícone + label manual) *@
<DropIconButton Icon="WellKnownIcons.MoreVertical" Style="Themes.Default"
               ContentType="DropContentType.List" Align="Positions.End">
    <DropItem OnClick="() => Editar(item.Id)">
        <div class="flex items-center gap-2">
            <Icon Kind="WellKnownIcons.Edit" />
            <span>Editar</span>
        </div>
    </DropItem>
    <DropItem OnClick="() => Excluir(item.Id)" AdditionalClasses="text-danger-600">
        <div class="flex items-center gap-2">
            <Icon Kind="WellKnownIcons.Delete" />
            <span>Excluir</span>
        </div>
    </DropItem>
</DropIconButton>
```

**Nota**: `Label` é processado como `ChildContent` via parâmetro de conveniência; quando `ChildContent` é explicitamente declarado, `Label` é ignorado. `[inferido]` — verificar se há parâmetro `Label` explícito ou se usa apenas `ChildContent`.

### `UIP-NAV-BREADCRUMB` — Item de overflow em Breadcrumb

```razor
<Breadcrumb>
    <Items>
        <BreadcrumbItem Href="/loja">Loja</BreadcrumbItem>
        <BreadcrumbItem Href="/loja/notebook-dell" Active=true>Notebook Dell</BreadcrumbItem>
    </Items>
    <MenuItems>
        @* DropItems no overflow de breadcrumb *@
        <DropItem Label="Eletrônicos" OnClick='() => Nav.NavigateTo("/loja/eletronicos")' />
        <DropItem Label="Notebooks" OnClick='() => Nav.NavigateTo("/loja/eletronicos/notebooks")' />
        <DropItem Label="Dell" OnClick='() => Nav.NavigateTo("/loja/eletronicos/notebooks/dell")' />
    </MenuItems>
</Breadcrumb>
```

## API relevante

- **Props/parâmetros**: `ChildContent: RenderFragment` — conteúdo do item; `Label: string?` (conveniência), `OnClick: EventCallback<MouseEventArgs>`
- **Cascading**: `ContentType: DropContentType` do `DropBase` pai — determina renderização como `<li>` ou `<div>`
- **Role dinâmico**: `button` quando tem `OnClick`; `menuitem` caso contrário
