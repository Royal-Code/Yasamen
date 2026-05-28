# DropButton - Sample

## Contrato de uso

**Entrada pública**: `<DropButton>` — namespace `RoyalCode.Razor.Drops`
**Grupo**: UI-ACTION
**Propósito**: Botão que ao clicar abre um menu dropdown com itens de ação ou conteúdo customizado.
**Patterns**:
- `implementa`: UIP-ACTION-CONTEXTUAL_MENU, UIP-OVERLAY-POPOVER
- `compõe`: UIP-NAV-BREADCRUMB
**Setup necessário**: `builder.Services.AddYasamenCommons()` + `<YasamenStyles />` no `<head>`

## Regras rápidas

- **Use para**: menus de ações secundárias acionado por botão com label; menus de exportação; popovers de filtro com trigger textual
- **Evite quando**: o trigger deve ser apenas ícone — use `DropIconButton`
- **Cuidado**: `ChildContent` são os `DropItem`s do menu; para customizar o botão trigger, use o slot `ButtonContent` em vez de `Label`

## Exemplos

### `UIP-ACTION-CONTEXTUAL_MENU` — Menu de ações com label

Use em toolbars para agrupar ações secundárias sob um único botão; `ContentType="DropContentType.List"` renderiza os itens em `<ul>`.

```razor
<DropButton Label="Exportar"
            Style="Themes.Default"
            ContentType="DropContentType.List"
            Align="Positions.End">
    <DropItem Label="CSV" OnClick="() => ExportarCsv()" />
    <DropItem Label="Excel" OnClick="() => ExportarExcel()" />
    <DropItem Label="PDF" OnClick="() => ExportarPdf()" />
</DropButton>
```

**API usada**: `Label`, `Style`, `ContentType`, `Align`, `ChildContent` (DropItems)

### `UIP-OVERLAY-POPOVER` — Popover de filtros rápidos

Use `CloseBehavior="CloseManually"` quando o conteúdo tem interação interna (ex: campos de filtro) para evitar fechar ao clicar dentro.

```razor
@code {
    private string? statusFiltro;
    private DropHandler handler = new();
}

<DropButton Label="Filtros"
            Style="Themes.Default"
            Icon="WellKnownIcons.Filter"
            Handler="@handler"
            CloseBehavior="DropCloseBehavior.CloseManually"
            MinWidth="Sizes.Large">
    <div class="p-4 flex flex-col gap-3">
        <p class="text-xs font-semibold text-dark-500 uppercase">Status</p>
        @foreach (var (val, label) in new[] { ("ativo","Ativo"), ("inativo","Inativo"), ("pendente","Pendente") })
        {
            <label class="flex items-center gap-2 text-sm text-dark-600 cursor-pointer">
                <InputCheckbox @bind-Value:get="statusFiltro == val"
                               @bind-Value:set="v => statusFiltro = v ? val : null" />
                @label
            </label>
        }
        <Button Style="Themes.Primary" Size="Sizes.Small" Label="Aplicar"
                OnClick="async () => { await AplicarFiltros(); await handler.CloseAsync(); }" />
    </div>
</DropButton>
```

**API usada**: `Handler`, `CloseBehavior`, `MinWidth`, conteúdo customizado livre
**Nota**: `DropHandler` permite fechar programaticamente via `handler.CloseAsync()`.

### `UIP-NAV-BREADCRUMB` — DropButton em overflow de breadcrumb

`DropButton` aparece automaticamente dentro de `Breadcrumb` para itens ocultos (overflow); quando necessário criar overflow manual, o slot `ButtonContent` customiza o trigger.

```razor
@* Uso direto do Breadcrumb — DropButton é interno ao componente *@
<Breadcrumb>
    <Items>
        <BreadcrumbItem Href="/admin">Admin</BreadcrumbItem>
        <BreadcrumbItem Href="/admin/usuarios">Usuários</BreadcrumbItem>
        <BreadcrumbItem Href="/admin/usuarios/42" Active=true>João Silva</BreadcrumbItem>
    </Items>
    <MenuItems>
        @* Overflow: DropItems injetados quando há itens ocultos *@
        <DropItem Label="Dashboard" OnClick='() => Nav.NavigateTo("/")' />
    </MenuItems>
</Breadcrumb>
```

**Nota**: No padrão `UIP-NAV-BREADCRUMB`, o `DropButton` é instanciado internamente pelo `Breadcrumb`; os `MenuItems` são os `DropItem` do overflow.

## API relevante

| Parâmetro | Tipo | Default | Uso |
|---|---|---|---|
| `Label` | `string` | — (EditorRequired) | Texto do botão trigger |
| `Style` | `Themes` | — | Tema do botão |
| `Direction` | `Directions` | Down | Down, Up, Left, Right |
| `Align` | `Positions` | Start | Alinhamento do menu relativo ao trigger |
| `MinWidth` | `Sizes?` | null | Largura mínima do menu aberto |
| `ContentType` | `DropContentType` | Default | List (`<ul>`) ou Default (`<div>`) |
| `CloseBehavior` | `DropCloseBehavior` | CloseOnClickOutside | CloseOnClick, CloseOnClickOutside, CloseManually |
| `Handler` | `DropHandler?` | null | Controle programático de open/close |
| `ButtonContent` | `RenderFragment` | — | Conteúdo customizado do botão trigger (alternativa a Label) |
| `ChildContent` | `RenderFragment` | — | Conteúdo do menu (DropItems ou qualquer HTML) |

- **Eventos**: `OnOpened: EventCallback<DropEventArgs>`, `OnClosed: EventCallback<DropEventArgs>`

## Defaults importantes

- `CloseBehavior` default `CloseOnClickOutside`: clicar num `DropItem` fecha o menu automaticamente; para evitar fechamento ao clicar dentro (ex: filtro com InputCheckbox), use `CloseManually` e chame `handler.CloseAsync()`
