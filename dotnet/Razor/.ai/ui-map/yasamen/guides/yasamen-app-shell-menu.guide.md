# Yasamen App Shell And Menu Guide

## Objetivo
Orientar a IA a gerar shell, layout, rotas e menus usando os componentes de aplicação do Yasamen sem inventar uma estrutura paralela.

## Quando usar
Use este guide ao gerar:
- Página Blazor com layout padrão.
- Shell administrativo, portal, dashboard ou tela operacional.
- Menu lateral, favoritos, breadcrumbs, rotas ou navegação por módulos.
- Configuração de `MenuOptions`, `MenuService` ou `MenuItem`.

## Decisão corporativa
O shell padrão de telas Yasamen deve usar `AppMainLayout`. Quando a tela exigir composição manual do shell, a IA deve usar `AppLayout` como primitivo e preencher os slots exigidos. A navegação estrutural deve ser configurada com `MenuOptions` e `MenuItem`, carregada por `MenuService`, e renderizada pelo `AppMenu`/componentes de menu existentes.

## Regras
- Para páginas comuns, aplique `@layout AppMainLayout` em vez de construir header, sidebar e footer manualmente.
- Use `AppLayout` quando precisar controlar slots como `TopStart`, `TopCenter`, `TopEnd`, `LeftMenu`, `RightMenu`, `Main` e `Footer`.
- Ao usar `AppLayout`, forneça sempre os slots `Main` e `Footer`, pois eles são marcados como `[EditorRequired]`.
- Não adicione manualmente `ModalOutlet`, `OffCanvasOutlet` e `NotificationOutlet` em páginas que já usam `AppLayout`; o próprio `AppLayout` os renderiza.
- Configure menus no container usando `MenuOptions`, `ConfigureMenuItems(...)` ou extensão local equivalente como `AddMenuItems()`.
- Modele grupos de navegação como `MenuItemType.Module` e links finais como `MenuItemType.Link`.
- Defina `Id` único e estável para cada `MenuItem`; `MenuService` usa `Find(id)` para mesclar itens e montar hierarquia.
- Defina `Url` apenas para itens navegáveis; módulos sem tela própria devem agrupar `Children`.
- Ao carregar menu remoto, use `MenuOptions.MenuUrl`; se o formato não for o JSON esperado, configure `ConfigureYasamenMenuDeserializer(...)`.
- Não trate o texto `search component` dentro de `AppMenu` como busca pronta para produção; ele é placeholder no componente atual.
- Não prometa persistência de favoritos; `AppMenu` alterna `IsFavorite` no item em memória.
- Use breadcrumbs derivados da hierarquia de `MenuItem.Parent`; não crie trilhas manuais duplicadas quando estiver navegando pelo menu.
- Ao abrir menu por offcanvas, mantenha um `OffCanvasHandler` em campo do componente e passe a mesma instância ao menu.

## Exemplos / Passo-a-passo

### Página comum com shell padrão

```razor
@page "/cadastros/clientes"
@layout AppMainLayout

<Box AdditionalClasses="p-8 bg-white border-none">
    <h1>Clientes</h1>
    <p class="text-secondary-700">Lista operacional de clientes.</p>
</Box>
```

### Configuração de menu local

```csharp
using RoyalCode.Razor.Layouts.Models;

public static class ConfigureMenu
{
    public static void AddMenuItems(this IServiceCollection services)
    {
        services.Configure<MenuOptions>(options =>
        {
            options.MenuItems.Add(new MenuItem
            {
                Id = "cadastros",
                Text = "Cadastros",
                Type = MenuItemType.Module,
                Children =
                [
                    new MenuItem
                    {
                        Id = "clientes",
                        Text = "Clientes",
                        Url = "cadastros/clientes",
                        Type = MenuItemType.Link
                    }
                ]
            });
        });
    }
}
```

### Uso direto de `AppLayout`

```razor
@inherits LayoutComponentBase

<AppLayout>
    <TopStart>
        <AppSideMenuButton />
    </TopStart>
    <TopCenter>
        <strong>Operações</strong>
    </TopCenter>
    <Main>
        @Body
    </Main>
    <Footer>
        <span class="text-sm text-secondary-600">Yasamen</span>
    </Footer>
</AppLayout>
```

### Menu por offcanvas

```razor
<IconButton IconFragment="@WellKnownIcons.Menu" OnClick="OpenMenu" title="Abrir menu" />
<AppMenu Handler="menuHandler" />

@code {
    private readonly OffCanvasHandler menuHandler = new();

    private async Task OpenMenu()
    {
        await menuHandler.Show();
    }
}
```

## Anti-padrões
- Não criar um menu com listas HTML soltas quando `MenuItem`, `MenuService` e `AppMenu` atendem ao caso.
- Não usar `MenuItemType.Link` para item sem `Url`.
- Não usar `MenuItemType.Module` para navegação final sem filhos.
- Não recriar outlets globais dentro de cada página.
- Não instanciar `OffCanvasHandler` dentro de markup, loops ou propriedades calculadas.
- Não depender do placeholder de busca de `AppMenu` para funcionalidades de filtro avançado.

## Fontes
- `RoyalCode.Razor.Layouts.Apps/Layouts/Apps/AppLayout.razor`
- `RoyalCode.Razor.Layouts.Apps/Layouts/Apps/AppMainLayout.razor`
- `RoyalCode.Razor.Layouts.Apps/Layouts/Apps/AppMenu.razor`
- `RoyalCode.Razor.Layouts.Apps/Layouts/Models/MenuOptions.cs`
- `RoyalCode.Razor.Layouts.Apps/Layouts/Models/MenuService.cs`
- `RoyalCode.Razor.Layouts.Apps/Layouts/Models/MenuItem.cs`
- `RoyalCode.Razor.Layouts.Apps/Layouts/Models/HttpMenuLoader.cs`
- `RoyalCode.Razor.Layouts.Apps/Extensions/LayoutAppsServiceCollectionExtensions.cs`
- `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/ConfigureMenu.cs`
- `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client/Components/Routes.razor`
