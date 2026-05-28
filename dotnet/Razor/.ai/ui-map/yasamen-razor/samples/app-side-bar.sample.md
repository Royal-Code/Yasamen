# AppSideBar - Sample

## Contrato de uso

**Entrada pública**: `<AppSideBar>` — namespace `RoyalCode.Razor.Layouts.Apps`
**Grupo**: SHELL
**Propósito**: Barra lateral fixa com largura e posição configuráveis (Start/End). Contém itens de navegação via ícones ou conteúdo textual.
**Patterns**:
- `implementa`: UIP-NAV-NAVIGATION_MENU, UIP-NAV-TAB_BAR
- `compõe`: -
**Setup necessário**: `<YasamenStyles />` no `<head>`; dentro de `AppLayout` no slot `LeftMenu` ou `RightMenu`

## Regras rápidas

- **Use para**: sidebar fixa de ícones de navegação principal, painel lateral de seção dentro do `AppLayout`
- **Evite quando**: precisa de painel que abre/fecha ao clicar — use `OffCanvas`
- **Cuidado**: `Position.Center` é inválido — usar apenas `Start` (esquerda) ou `End` (direita)

## Exemplos

### `UIP-NAV-NAVIGATION_MENU, UIP-NAV-TAB_BAR` — Sidebar de ícones de navegação

Sidebar clássica com `AppSideMenuButton` + `AppSideItem` para itens de navegação com estado ativo.

```razor
@* Dentro de AppLayout.LeftMenu *@
<AppSideBar Size="SpacingSize.LargerX2" Position="Positions.Start">
    @* Botão de menu (abre AppMenu via OffCanvas) *@
    <AppSideMenuButton />

    @* Itens de navegação com Active gerenciado *@
    <AppSideItem Active="@Nav.Uri.Contains("/dashboard")">
        <IconButton Icon="WellKnownIcons.Dashboard"
                   Style="Themes.Default"
                   NavigateTo="/dashboard"
                   title="Dashboard" />
    </AppSideItem>

    <AppSideItem Active="@Nav.Uri.Contains("/pedidos")">
        <IconButton Icon="WellKnownIcons.Orders"
                   Style="Themes.Default"
                   NavigateTo="/pedidos"
                   title="Pedidos" />
    </AppSideItem>

    <AppSideItem Active="@Nav.Uri.Contains("/clientes")">
        <IconButton Icon="WellKnownIcons.Users"
                   Style="Themes.Default"
                   NavigateTo="/clientes"
                   title="Clientes" />
    </AppSideItem>

    @* Ação no bottom da sidebar — configurações *@
    <div class="mt-auto">
        <AppSideItem Active="@Nav.Uri.Contains("/config")">
            <IconButton Icon="WellKnownIcons.Settings"
                       Style="Themes.Default"
                       NavigateTo="/config"
                       title="Configurações" />
        </AppSideItem>
    </div>
</AppSideBar>
```

**API usada**: `Size`, `Position`; `AppSideItem.Active` para estado ativo individual
**Nota**: `title` em `IconButton` é passado via `AdditionalAttributes`; exibe tooltip nativo do browser.

## API relevante

- **Props/parâmetros**: `Size: SpacingSize` (EditorRequired) — largura da sidebar; `Position: Positions` (EditorRequired) — Start | End
- **Slots**: `ChildContent: RenderFragment`

## Limites e combinações frágeis

- `Position.Center` não é válido — gera comportamento indefinido; usar apenas `Start` ou `End`
- Quando `AppSideBar` está no `LeftMenu` de `AppLayout`, a largura declarada em `Size` precisa corresponder ao `LeftMenuSize` do `AppLayout` para o espaçamento ser correto
