# Yasamen Component Composition Guide

## Objetivo
Orientar a IA a criar componentes Blazor compostos sobre Yasamen seguindo as convenções reais da biblioteca.

## Quando usar
Use este guide ao gerar:
- Componentes app-specific que embrulham componentes Yasamen.
- Layouts, cards operacionais, toolbars, filtros, formulários compostos ou painéis.
- Componentes com slots, classes adicionais, atributos HTML adicionais ou handlers.
- Código `.razor` e `.razor.cs` para compor UI reutilizável.

## Decisão corporativa
Componentes criados em cima de Yasamen devem preservar a API visual da biblioteca: parâmetros tipados, `RenderFragment` para slots, `AdditionalClasses` para extensão visual, `AdditionalAttributes` para atributos HTML, handlers estáveis para overlays e composição de classes via `AddClass`.

## Regras
- Preserve componentes Yasamen como base da UI; só crie wrappers quando eles reduzirem repetição real ou codificarem uma decisão da aplicação.
- Para slots opcionais, use `RenderFragment` com `EmptyFragment.Delegate` quando seguir o padrão dos componentes Yasamen.
- Para conteúdo obrigatório, use `[Parameter, EditorRequired]` como `AppLayout.Main`, `AppLayout.Footer`, `AppMenu.Handler`, `Button.Label` e itens de navegação.
- Exponha `AdditionalClasses` em wrappers para permitir ajuste visual sem substituir classes internas.
- Exponha `AdditionalAttributes` com `[Parameter(CaptureUnmatchedValues = true)]` e aplique no elemento raiz quando o wrapper renderizar HTML próprio.
- Preserve a classe base do componente e acrescente classes com `.AddClass(...)`; não concatene classes de forma frágil quando a extensão está disponível.
- Use enums da biblioteca (`Themes`, `Sizes`, `Positions`, `Placements`) em parâmetros públicos; não exponha strings soltas para temas e tamanhos.
- Ao embrulhar `Button`, `IconButton`, `TextField`, `Modal` ou `OffCanvas`, encaminhe parâmetros essenciais em vez de esconder comportamento importante.
- Ao compor overlays, declare handlers como campos `readonly` do componente; não os crie no render tree.
- Use `CascadingValue` para contexto apenas quando filhos precisam consumir estado; use `IsFixed="true"` quando o objeto de contexto não muda.
- Em componentes com estado assíncrono, não dispare UI imperativa no construtor; use eventos, lifecycle ou handlers após render.
- Quando a biblioteca usa outlets internos, não duplique outlets no wrapper.
- Ao criar wrappers para telas, mantenha o markup denso e operacional; não transforme componentes de sistema em landing page ou hero decorativo.

## Exemplos / Passo-a-passo

### Wrapper de toolbar operacional

```razor
@using RoyalCode.Razor.Icons.Bootstrap

<div @attributes="AdditionalAttributes" class="@Classes">
    <Button Label="@PrimaryLabel"
            Style="Themes.Primary"
            Icon="@PrimaryIcon"
            OnClick="OnPrimaryClick" />

    @ChildContent
</div>

@code {
    private string Classes => "flex items-center justify-between gap-4"
        .AddClass(AdditionalClasses);

    [Parameter, EditorRequired]
    public string PrimaryLabel { get; set; } = null!;

    [Parameter]
    public Enum PrimaryIcon { get; set; } = BsIconNames.PlusCircle;

    [Parameter]
    public EventCallback<MouseEventArgs> OnPrimaryClick { get; set; }

    [Parameter]
    public RenderFragment ChildContent { get; set; } = EmptyFragment.Delegate;

    [Parameter]
    public string? AdditionalClasses { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? AdditionalAttributes { get; set; }
}
```

### Wrapper de painel com ação e slot

```razor
<Box AdditionalClasses="@Classes">
    <div class="flex items-center justify-between gap-4 mb-6">
        <h2>@Title</h2>
        @Actions
    </div>

    @ChildContent
</Box>

@code {
    private string Classes => "p-6 bg-white border-none"
        .AddClass(AdditionalClasses);

    [Parameter, EditorRequired]
    public string Title { get; set; } = null!;

    [Parameter, EditorRequired]
    public RenderFragment ChildContent { get; set; } = EmptyFragment.Delegate;

    [Parameter]
    public RenderFragment Actions { get; set; } = EmptyFragment.Delegate;

    [Parameter]
    public string? AdditionalClasses { get; set; }
}
```

### Componente com offcanvas interno

```razor
<IconButton IconFragment="@WellKnownIcons.Filter"
            title="Filtros"
            OnClick="ToggleFilters" />

<OffCanvas Position="Positions.End"
           Handler="filtersHandler"
           Title="@Title">
    <div class="p-4">
        <CloseOffCanvasButton />
        @ChildContent
    </div>
</OffCanvas>

@code {
    private readonly OffCanvasHandler filtersHandler = new();

    [Parameter]
    public string Title { get; set; } = "Filtros";

    [Parameter, EditorRequired]
    public RenderFragment ChildContent { get; set; } = EmptyFragment.Delegate;

    private async Task ToggleFilters()
    {
        await filtersHandler.Toggle();
    }
}
```

### AppLayout customizado com slots explícitos

```razor
@inherits LayoutComponentBase

<AppLayout>
    <TopStart>
        <AppSideMenuButton />
    </TopStart>
    <TopEnd>
        <IconButton IconFragment="@WellKnownIcons.UserProfile" title="Perfil" />
    </TopEnd>
    <Main>
        @Body
    </Main>
    <Footer>
        <span class="text-sm text-secondary-600">Rodapé</span>
    </Footer>
</AppLayout>
```

## Anti-padrões
- Não criar wrapper que só troca o nome do componente Yasamen sem reduzir repetição.
- Não remover `AdditionalClasses` de componentes compostos quando o layout consumidor precisa ajustar densidade.
- Não capturar atributos e deixar de aplicá-los ao elemento raiz.
- Não substituir parâmetros tipados por strings genéricas para tema, tamanho, posição ou placement.
- Não criar handlers de modal/offcanvas dentro de propriedades calculadas ou loops.
- Não duplicar `ModalOutlet`, `OffCanvasOutlet` ou `NotificationOutlet` em wrappers baseados em `AppLayout`.
- Não ocultar `OnClick`, `Disabled`, `Style` ou `Size` quando o wrapper representa uma ação reutilizável.

## Fontes
- `RoyalCode.Razor.Layouts.Apps/Layouts/Apps/AppLayout.razor`
- `RoyalCode.Razor.Layouts.Apps/Layouts/Apps/AppMenu.razor`
- `RoyalCode.Razor.Layouts.Apps/Layouts/Apps/AppTopBar.razor.cs`
- `RoyalCode.Razor.Buttons/Components/Button.razor`
- `RoyalCode.Razor.Buttons/Components/Button.razor.cs`
- `RoyalCode.Razor.Buttons/Components/IconButton.razor`
- `RoyalCode.Razor.Buttons/Components/IconButton.razor.cs`
- `RoyalCode.Razor.Navigation/Components/Pagination.razor.cs`
- `RoyalCode.Razor.Forms/Internal/Forms/FieldBase.cs`
- `RoyalCode.Razor.Forms/Internal/Forms/FieldGroup.razor`
- `RoyalCode.Razor.OffCanvas/Components/OffCanvasHandler.cs`
- `RoyalCode.Razor.Styles/Styles/Css.Extensions.cs`
