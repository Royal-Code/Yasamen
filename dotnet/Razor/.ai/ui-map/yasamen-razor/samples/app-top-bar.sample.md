# AppTopBar - Sample

## Contrato de uso

**Entrada pública**: `<AppTopBar>` — namespace `RoyalCode.Razor.Layouts.Apps`
**Grupo**: SHELL
**Propósito**: Barra superior do app com três zonas de conteúdo (StartContent, CenterContent, EndContent) e altura configurável.
**Patterns**:
- `implementa`: -
- `compõe`: SHP-WORKSPACE_ADMIN, SHP-DASHBOARD_ANALYTICS
**Setup necessário**: `<YasamenStyles />` no `<head>`

## Regras rápidas

- **Use para**: standalone apenas em shells customizados sem `AppLayout`; em `AppLayout`, usar os slots `TopStart`/`TopCenter`/`TopEnd` diretamente
- **Evite quando**: precisa de toolbar interna de página — use `Bar`; use `AppTopBar` somente para o header fixo do app (z-index 1010)
- **Cuidado**: z-index nativo `ya-top-bar` = 1010 — não sobrescrever

## Exemplos

### `SHP-WORKSPACE_ADMIN, SHP-DASHBOARD_ANALYTICS` — AppTopBar standalone

Use diretamente apenas quando construindo um shell customizado sem `AppLayout`.

```razor
@* Shell customizado sem AppLayout — AppTopBar standalone *@
<div class="flex flex-col h-full">
    <AppTopBar Size="SpacingSize.LargerX2">
        <StartContent>
            <span class="font-bold text-dark-700 text-base px-4">AppName</span>
        </StartContent>
        <EndContent>
            <IconButton Icon="WellKnownIcons.Notifications" Style="Themes.Default" />
            <span class="text-sm text-dark-600 px-4">Admin</span>
        </EndContent>
    </AppTopBar>
    <main class="flex-1 overflow-auto p-6">
        @Body
    </main>
</div>
```

**Nota**: Dentro de `AppLayout`, os slots `TopStart`/`TopCenter`/`TopEnd` do layout mapeiam diretamente para `StartContent`/`CenterContent`/`EndContent` do `AppTopBar` interno — não instanciar `AppTopBar` explicitamente ao usar `AppLayout`.

## API relevante

- **Props/parâmetros**: `Size: SpacingSize` — altura do topbar
- **Slots**: `StartContent`, `CenterContent`, `EndContent: RenderFragment`
