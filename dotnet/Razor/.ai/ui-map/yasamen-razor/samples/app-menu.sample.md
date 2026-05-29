# AppMenu - Sample

## Contrato de uso

**Entrada pública**: `<AppMenu>` — namespace `RoyalCode.Razor.Layouts.Apps`
**Grupo**: UI-NAV
**Propósito**: Menu de navegação do app exibido via `OffCanvas`. Carrega itens via `MenuService`, suporta busca, breadcrumbs de submenu e favoritos.
**Patterns**:
- `implementa`: UIP-NAV-NAVIGATION_MENU
- `compõe`: SHP-WORKSPACE_ADMIN
**Setup necessário**: `builder.Services.AddYasamenOffCanvas().AddYasamenMenu()` + `<YasamenStyles />` no `<head>`

## Regras rápidas

- **Use para**: menu de navegação principal do app em modo OffCanvas (slide-in lateral), com hierarquia de itens configurada via `MenuService`
- **Evite quando**: o menu é estático e simples — construir com `NavLink` e `AppSideBar` diretamente é mais simples; para menus sem hierarquia e sem busca, não usar `AppMenu`
- **Cuidado**: requer `MenuService` (via `AddYasamenMenu()`) configurado com os itens de menu antes do uso

## Exemplos

### `UIP-NAV-NAVIGATION_MENU, SHP-WORKSPACE_ADMIN` — Menu com OffCanvasHandler

Na maioria dos casos, `AppMenu` é instanciado via `AppSideMenuButton`. Use diretamente apenas quando precisar de um trigger customizado.

```razor
@code {
    private OffCanvasHandler menuHandler = new();
}

@* Trigger customizado *@
<Button Style="Themes.Default" Label="Menu" Icon="WellKnownIcons.Menu"
        OnClick="async () => await menuHandler.Show()" />

@* AppMenu com handler externo *@
<AppMenu Handler="@menuHandler" />
```

**Nota**: `AppMenu` gerencia internamente `OffCanvas`, `DescribesBreadcrumbs`, `AppMenuList` e `CloseOffCanvasButton`. O `MenuService` deve ter os itens carregados antes da abertura — configurar no DI com a árvore de itens de menu.

## API relevante

- **Props/parâmetros**: `Handler: OffCanvasHandler` (EditorRequired) — controla abertura/fechamento
- **Requer DI**: `MenuService` (via `AddYasamenMenu()`)

## Limites e combinações frágeis

- Fecha automaticamente ao navegar para outra rota via `NavigationManager.LocationChanged`
- `MenuService` gerencia a hierarquia de menus — não é possível passar itens inline; a configuração é feita via DI
