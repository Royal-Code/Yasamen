# AppLayout - Sample

## Contrato de uso

**Entrada pública**: `<AppLayout>` — namespace `RoyalCode.Razor.Layouts.Apps`
**Grupo**: SHELL
**Propósito**: Shell completo de aplicação com header fixo (`AppTopBar`), sidebars opcionais (`AppSideBar`), área de conteúdo principal, footer e outlets automáticos para Modal, OffCanvas e Notification.
**Patterns**:
- `implementa`: UIP-STRUCT-LAYOUT_ZONE, SHP-WORKSPACE_ADMIN, SHP-DASHBOARD_ANALYTICS
- `compõe`: -
**Setup necessário**: `builder.Services.AddYasamenCommons().AddYasamenModal().AddYasamenOffCanvas().AddYasamenNotification()` + `AddYasamenMenu()` (se usar AppMenu) + `<YasamenStyles />` no `<head>`

## Regras rápidas

- **Use para**: layout raiz de aplicação web completa com header, sidebar e área de conteúdo
- **Evite quando**: a página não precisa de shell completo (ex: tela de login, página de erro) — use HTML simples `flex items-center justify-center`
- **Cuidado**: `Main` e `Footer` são EditorRequired; sem os outlets de Modal/OffCanvas/Notification no DI, os overlays não funcionarão

## Exemplos

### `SHP-WORKSPACE_ADMIN` — Shell completo de workspace administrativo

Estrutura padrão: sidebar de ícones com AppSideMenuButton + header com AppTopBar + conteúdo principal.

```razor
@* MainLayout.razor — LayoutComponentBase *@
@inherits LayoutComponentBase

<AppLayout>
    @* Slots do header (AppTopBar interno) *@
    <TopStart>
        @* Logo ou título do app *@
        <span class="font-bold text-dark-700 text-base px-4">MyApp</span>
    </TopStart>
    <TopEnd>
        @* Ações do usuário no header *@
        <IconButton Icon="WellKnownIcons.Notifications"
                   Style="Themes.Default" />
        <span class="text-sm text-dark-600 mr-4">@usuario.Nome</span>
    </TopEnd>

    @* Sidebar esquerda *@
    <LeftMenu>
        <AppSideBar Size="SpacingSize.LargerX2" Position="Positions.Start">
            <AppSideMenuButton />
            <AppSideItem Active="@IsActive("/dashboard")">
                <IconButton Icon="WellKnownIcons.Dashboard"
                           Style="Themes.Default"
                           NavigateTo="/dashboard" />
            </AppSideItem>
            <AppSideItem Active="@IsActive("/usuarios")">
                <IconButton Icon="WellKnownIcons.Users"
                           Style="Themes.Default"
                           NavigateTo="/usuarios" />
            </AppSideItem>
            <AppSideItem Active="@IsActive("/config")">
                <IconButton Icon="WellKnownIcons.Settings"
                           Style="Themes.Default"
                           NavigateTo="/config" />
            </AppSideItem>
        </AppSideBar>
    </LeftMenu>

    @* Conteúdo principal *@
    <Main>
        <div class="p-6">
            @Body
        </div>
    </Main>

    @* Footer *@
    <Footer>
        <div class="px-6 py-2 text-xs text-dark-300">
            © 2025 MyApp
        </div>
    </Footer>
</AppLayout>
```

**API usada**: `TopStart`, `TopEnd`, `LeftMenu`, `Main`, `Footer`
**Nota**: `AppSideMenuButton` requer `AddYasamenMenu()` no DI; gerencia o `AppMenu` com OffCanvas automaticamente.

### `SHP-DASHBOARD_ANALYTICS, UIP-STRUCT-LAYOUT_ZONE` — Shell com sidebar fixa de navegação textual

Para analytics, a sidebar pode ter texto além de ícones; sem `AppSideMenuButton`.

```razor
@* AnalyticsLayout.razor *@
@inherits LayoutComponentBase

<AppLayout>
    <TopStart>
        <span class="font-bold text-dark-700 text-sm px-4">Analytics</span>
    </TopStart>
    <TopEnd>
        <IconButton Icon="WellKnownIcons.Refresh"
                   Style="Themes.Default"
                   OnClick="RefreshAll" />
    </TopEnd>

    <LeftMenu>
        <AppSideBar Size="SpacingSize.LargerX4" Position="Positions.Start">
            <nav class="flex-1 overflow-y-auto p-2">
                <Stack AdditionalClasses="gap-0">
                    <NavLink href="/analytics/overview"
                             class="flex items-center gap-2 px-3 py-2 text-sm rounded-md
                                    text-dark-500 hover:bg-light-50"
                             ActiveClass="bg-primary-50 text-primary-700 font-medium">
                        Visão geral
                    </NavLink>
                    <NavLink href="/analytics/receita"
                             class="flex items-center gap-2 px-3 py-2 text-sm rounded-md
                                    text-dark-500 hover:bg-light-50"
                             ActiveClass="bg-primary-50 text-primary-700 font-medium">
                        Receita
                    </NavLink>
                </Stack>
            </nav>
        </AppSideBar>
    </LeftMenu>

    <Main>
        <div class="p-6">
            @Body
        </div>
    </Main>

    <Footer>
        <div class="px-6 py-2 text-xs text-dark-300">Analytics v1.0</div>
    </Footer>
</AppLayout>
```

**API usada**: `LeftMenu` com `AppSideBar` de largura maior para nav textual

## API relevante

| Parâmetro | Tipo | Default | Uso |
|---|---|---|---|
| `TopStart` / `TopCenter` / `TopEnd` | `RenderFragment` | — | Slots do AppTopBar interno |
| `LeftMenu` / `RightMenu` | `RenderFragment` | — | Sidebars laterais (opcional) |
| `Main` | `RenderFragment` | EditorRequired | Área de conteúdo principal |
| `Footer` | `RenderFragment` | EditorRequired | Rodapé fixo |
| `TopSize` | `SpacingSize` | LargerX2 | Altura do topbar |
| `FooterSize` | `SpacingSize` | LargerX2 | Altura do footer |
| `LeftMenuSize` / `RightMenuSize` | `SpacingSize` | LargerX2 | Largura das sidebars |
| `PreContent` / `PostContent` | `RenderFragment` | — | Conteúdo antes/depois do layout principal |

## Limites e combinações frágeis

- `Main` e `Footer` são EditorRequired — omiti-los causa erro de compilação
- `AppLayout` inclui automaticamente `ModalOutlet`, `OffCanvasOutlet`, `NotificationOutlet` — não adicionar manualmente
- `AppLayoutContext` é propagado por cascading para componentes filhos; acessível em componentes que precisam referenciar elementos DOM do layout
