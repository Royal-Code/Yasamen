# AppSideMenuButton - Sample

## Contrato de uso

**Entrada pública**: `<AppSideMenuButton>` — namespace `RoyalCode.Razor.Layouts.Apps`
**Grupo**: SHELL
**Propósito**: Botão pré-montado para abrir/fechar o `AppMenu` via OffCanvas. Combina `AppSideItem` + `IconButton` + `AppMenu` em um único componente autocontido.
**Patterns**:
- `implementa`: -
- `compõe`: UIP-NAV-NAVIGATION_MENU, SHP-WORKSPACE_ADMIN
**Setup necessário**: `builder.Services.AddYasamenOffCanvas().AddYasamenMenu()` + `<YasamenStyles />` no `<head>`

## Regras rápidas

- **Use para**: botão principal de navegação na sidebar do `AppLayout` que abre o `AppMenu` com drawer
- **Evite quando**: quer controle manual sobre o handler do menu ou usar menu diferente do `AppMenu`
- **Cuidado**: requer `AddYasamenMenu()` no DI — sem ele, o componente falha ao tentar usar `MenuService`

## Exemplos

### `UIP-NAV-NAVIGATION_MENU, SHP-WORKSPACE_ADMIN` — Botão de menu na sidebar

Nenhum parâmetro necessário — o componente é autocontido.

```razor
@* Dentro de AppSideBar — posição padrão: primeiro item da sidebar *@
<AppSideBar Size="SpacingSize.LargerX2" Position="Positions.Start">
    <AppSideMenuButton />

    <AppSideItem Active="@Nav.Uri.Contains("/dashboard")">
        <IconButton Icon="WellKnownIcons.Dashboard"
                   Style="Themes.Default"
                   NavigateTo="/dashboard" />
    </AppSideItem>
</AppSideBar>
```

**Nota**: O ícone do botão muda de Default → Primary quando o menu está aberto (feedback visual automático). Fecha automaticamente ao navegar para outra rota.

## API relevante

- **Props/parâmetros**: nenhum parâmetro público
- **Requer DI**: `MenuService` (via `AddYasamenMenu()`) e `OffCanvasHandler` interno
