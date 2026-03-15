# Guide 06 — Anatomia de um Componente

> Padrão completo de como criar um componente Blazor nesta biblioteca: estrutura de arquivos, parâmetros obrigatórios, CSS, DI e boas práticas.

---

## Estrutura de Arquivos

Um componente pode ser implementado de duas formas:

### Forma A — `.razor` com `@code` inline (componentes simples)

```
Components/
└── Badge.razor     ← markup + @code no mesmo arquivo
```

### Forma B — `.razor` + `.razor.cs` code-behind (componentes com lógica)

```
Components/
├── Button.razor        ← apenas markup
└── Button.razor.cs     ← parâmetros e lógica
```

A `partial class` no `.razor.cs` deve ter o **mesmo nome** que o componente `.razor`:

```csharp
// Button.razor.cs
namespace RoyalCode.Razor.Components;

public partial class Button   // partial — o .razor gera a outra metade
{
    [Parameter]
    public string Label { get; set; } = null!;
    // ...
}
```

### Forma C — Componente 100% C# (sem markup)

Para componentes que constroem o render tree manualmente:

```csharp
// Icon.cs
public class Icon : ComponentBase
{
    protected override void BuildRenderTree(RenderTreeBuilder builder) { ... }
}
```

---

## Namespace

Todos os componentes públicos ficam em `RoyalCode.Razor.Components`:

```csharp
namespace RoyalCode.Razor.Components;
```

Componentes internos ficam em `RoyalCode.Razor.Internal.{NomeProjeto}`:

```csharp
namespace RoyalCode.Razor.Internal.Notifications;
```

---

## Parâmetros Obrigatórios em Todo Componente

Todo componente visual **deve** ter estes dois parâmetros:

```csharp
/// <summary>
/// Style classes passed to the outermost element of the component.
/// </summary>
[Parameter]
public string? AdditionalClasses { get; set; }

/// <summary>
/// Additional HTML attributes.
/// </summary>
[Parameter(CaptureUnmatchedValues = true)]
public Dictionary<string, object>? AdditionalAttributes { get; set; }
```

`AdditionalClasses` é **separado** de `AdditionalAttributes` — o consumidor pode passar classes extras sem sobrescrever as do componente.

### No markup:

```razor
<div class="@Classes" @attributes="AdditionalAttributes">
```

A propriedade `Classes` inclui `AdditionalClasses` no final:

```csharp
private string Classes => "ya-meu-componente"
    .AddClass(/* variantes */)
    .AddClass(AdditionalClasses);  // sempre o último
```

---

## Parâmetros Comuns por Categoria

### Componentes visuais (não-form)

| Parâmetro | Tipo | Obrigatório | Default |
|---|---|---|---|
| `ChildContent` | `RenderFragment?` | não | `EmptyFragment.Delegate` |
| `Style` | `Themes` | não | `Themes.Default` |
| `Size` | `Sizes` | não | `Sizes.Default` |
| `AdditionalClasses` | `string?` | sim | — |
| `AdditionalAttributes` | `Dictionary<string,object>?` | sim | — |

### Componentes de ação (botões)

| Parâmetro | Tipo | Obrigatório |
|---|---|---|
| `Label` | `string` | sim (`[EditorRequired]`) |
| `Type` | `ButtonTypes` | não |
| `Style` | `Themes` | não |
| `Size` | `Sizes` | não |
| `Icon` | `Enum?` | não |
| `IconAnimation` | `AnimationFragment?` | não |
| `IconPosition` | `Positions` | não |
| `Outline` | `bool` | não |
| `Active` | `bool` | não |
| `Disabled` | `bool` | não |
| `NavigateTo` | `string?` | não |
| `OnClick` | `EventCallback<MouseEventArgs>` | não |

### Parâmetros com `[EditorRequired]`

Use `[EditorRequired]` apenas quando o componente **não pode funcionar** sem o parâmetro:

```csharp
[Parameter, EditorRequired]
public string Label { get; set; } = null!;
```

---

## Padrão de Propriedade `Classes`

```csharp
// Para componentes simples (no @code do .razor):
private string Classes => "ya-badge"
    .AddClass(GetStyle())
    .AddClass(Size.ToCssClassName("ya-badge"))
    .AddClass(AdditionalClasses);

// Para componentes com lógica condicional:
private string Classes => "ya-feedback"
    .AddClass(GetStyle())
    .AddClass(Size.ToCssClassName("ya-feedback"))
    .AddClass(Block, "ya-feedback-block")
    .AddClass(AdditionalClasses);
```

A `string` base é **sempre** a classe raiz `ya-{nome}`. Os modificadores seguem em `.AddClass()`.

---

## Injeção de Dependência no Componente

Para injetar serviços privados (ex: `NavigationManager`, `RippleJs`):

```csharp
// Injeção privada — não expõe o serviço ao consumidor
[Inject]
private NavigationManager Navigator { get; set; } = null!;

[Inject]
private RippleJs RippleJs { get; set; } = null!;
```

---

## Lifecycle do Componente — Boas Práticas

| Método | Quando usar |
|---|---|
| `OnInitialized` / `OnInitializedAsync` | Inicializar estado, subscrever eventos |
| `OnParametersSet` / `OnParametersSetAsync` | Reagir a mudanças de parâmetros |
| `OnAfterRender` / `OnAfterRenderAsync` | Interop JS (após elemento estar no DOM) |
| `IAsyncDisposable.DisposeAsync` | Cancelar timers, remover listeners JS |

```csharp
// Padrão para JS interop após render:
protected override async Task OnAfterRenderAsync(bool firstRender)
{
    if (firstRender)
    {
        await RippleJs.RippleAsync(Reference);
    }
}
```

---

## Slots (RenderFragment)

Para componentes com múltiplos slots nomeados:

```csharp
// Slot obrigatório:
[Parameter, EditorRequired]
public RenderFragment ChildContent { get; set; } = null!;

// Slot opcional:
[Parameter]
public RenderFragment Prepend { get; set; } = EmptyFragment.Delegate;

[Parameter]
public RenderFragment Append { get; set; } = EmptyFragment.Delegate;
```

No markup:
```razor
<div class="ya-control-group">
    @if (Prepend.IsNotEmptyFragment())
    {
        @Prepend
    }
    @ChildContent
    @if (Append.IsNotEmptyFragment())
    {
        @Append
    }
</div>
```

---

## Eventos

```csharp
// Callback sem dados:
[Parameter]
public EventCallback OnClose { get; set; }

// Callback com dados:
[Parameter]
public EventCallback<MouseEventArgs> OnClick { get; set; }

// Handler interno que dispara o callback:
private async Task CloseAsync()
{
    closed = true;
    await OnClose.InvokeAsync();
}
```

---

## Exemplo Completo — Componente Simples

```razor
@* Alert.razor *@
@if (!closed)
{
    <div class="@Classes" @attributes="AdditionalAttributes" role="alert">
        @if (Icon is not null)
        {
            <Icon Kind="Icon" />
        }
        @if (Title.IsPresent())
        {
            <strong>@Title</strong>
        }
        @ChildContent
        @if (Closeable)
        {
            <button type="button" class="ya-btn-close" @onclick="CloseAsync">
                @WellKnownIcons.Close("text-sm")
            </button>
        }
    </div>
}

@code {
    private bool closed;

    private string Classes => "ya-alert"
        .AddClass(Style.ToAlertTheme())
        .AddClass(Size.ToCssClassName("ya-alert"))
        .AddClass(AdditionalClasses);

    [Parameter] public RenderFragment ChildContent { get; set; } = EmptyFragment.Delegate;
    [Parameter] public string? Title { get; set; }
    [Parameter] public Themes Style { get; set; }
    [Parameter] public Sizes Size { get; set; }
    [Parameter] public Enum? Icon { get; set; }
    [Parameter] public bool Closeable { get; set; }
    [Parameter] public EventCallback OnClose { get; set; }
    [Parameter] public string? AdditionalClasses { get; set; }
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? AdditionalAttributes { get; set; }

    private async Task CloseAsync()
    {
        closed = true;
        StateHasChanged();
        await OnClose.InvokeAsync();
    }
}
```

---

## Checklist para Novo Componente

- [ ] Namespace: `RoyalCode.Razor.Components` (público) ou `RoyalCode.Razor.Internal.XYZ` (interno)
- [ ] Parâmetros `AdditionalClasses` (string?) e `AdditionalAttributes` (Dictionary, CaptureUnmatchedValues)
- [ ] Propriedade `Classes` com classe base `ya-{nome}` e `AddClass(AdditionalClasses)` ao final
- [ ] `@attributes="AdditionalAttributes"` no elemento raiz do markup
- [ ] Slots `RenderFragment` opcionais com `EmptyFragment.Delegate` como default
- [ ] Verificação de slots com `.IsNotEmptyFragment()`, textos com `.IsPresent()`
- [ ] Documentação XML (`///`) em todos os parâmetros públicos
- [ ] Serviços injetados com `[Inject] private`
