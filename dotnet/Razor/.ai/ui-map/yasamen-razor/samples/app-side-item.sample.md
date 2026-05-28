# AppSideItem - Sample

## Contrato de uso

**Entrada pública**: `<AppSideItem>` — namespace `RoyalCode.Razor.Layouts.Apps`
**Grupo**: SHELL
**Propósito**: Slot de item dentro da `AppSideBar` com estado ativo visual. Aplica classe `active` quando `Active=true`.
**Patterns**:
- `implementa`: -
- `compõe`: UIP-NAV-NAVIGATION_MENU, UIP-NAV-TAB_BAR
**Setup necessário**: `<YasamenStyles />` no `<head>`; deve estar dentro de `AppSideBar`

## Regras rápidas

- **Use para**: envolver cada `IconButton` ou botão de navegação na sidebar com gerenciamento de estado ativo
- **Evite quando**: fora de sidebar — o componente é semântico para itens laterais

## Exemplos

### `UIP-NAV-NAVIGATION_MENU, UIP-NAV-TAB_BAR` — Item de sidebar com estado ativo

```razor
<AppSideBar Size="SpacingSize.LargerX2" Position="Positions.Start">
    @* Active gerenciado externamente com NavigationManager *@
    <AppSideItem Active="@Nav.Uri.Contains("/dashboard")">
        <IconButton Icon="WellKnownIcons.Dashboard"
                   Style="Themes.Default" title="Dashboard"
                   NavigateTo="/dashboard" />
    </AppSideItem>

    @* Active por estado C# local *@
    <AppSideItem Active="@secaoAtiva == "relatorios"">
        <IconButton Icon="WellKnownIcons.Report"
                   Style="Themes.Default" title="Relatórios"
                   OnClick='() => secaoAtiva = "relatorios"' />
    </AppSideItem>
</AppSideBar>
```

**API usada**: `Active: bool`, `ChildContent: RenderFragment`

## API relevante

- **Props/parâmetros**: `Active: bool` — estado ativo visual (adiciona classe `active`)
- **Slots**: `ChildContent: RenderFragment?`
