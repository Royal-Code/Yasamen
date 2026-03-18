# Sistema de Animações

> Como funciona o projeto `RoyalCode.Razor.Animations`, o tipo `AnimationFragment`, e como aplicar animações a ícones em botões.

---

## Visão Geral

O projeto `RoyalCode.Razor.Animations` fornece animações CSS aplicadas via wrapper de componente. O design respeita a separação de responsabilidades:

- O **componente** define o ícone a renderizar
- A **animação** envolve qualquer conteúdo sem saber o que está dentro
- O **consumidor** decide qual animação aplicar ao ícone

---

## `AnimationFragment` — Delegate de Animação

```csharp
// Tipo:
public delegate RenderFragment AnimationFragment(RenderFragment content);
```

É uma função que recebe um `RenderFragment` (o ícone) e retorna um `RenderFragment` (o ícone envolto na animação).

### Uso em parâmetro de componente

```csharp
[Parameter]
public AnimationFragment? IconAnimation { get; set; }
```

### Uso na renderização

```csharp
private RenderFragment RenderIcon => IconAnimation is not null
    ? IconAnimation(IconRender.Fragment(Icon!))
    : IconRender.Fragment(Icon!);
```

---

## Componentes de Animação

### `RotationMotion` — Rotação Contínua (Spinner)

Envolve conteúdo em rotação contínua. Usa atributo HTML customizado `ya-rotation` ou `ya-rotation-clockwise` como hook CSS.

```razor
@* Spinner padrão (anti-horário): *@
<RotationMotion>
    <Icon Kind="WellKnownIcons.Settings" />
</RotationMotion>

@* Spinner horário: *@
<RotationMotion CounterClockwise="true">
    <Icon Kind="WellKnownIcons.Settings" />
</RotationMotion>
```

Implementação interna:
```razor
@Render

@code {
    [Parameter]
    public RenderFragment ChildContent { get; set; } = null!;

    [Parameter]
    public bool CounterClockwise { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> AdditionalAttributes { get; set; } = null!;

    private RenderFragment Render => builder => {
        builder.OpenElement(0, "div");
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, CounterClockwise ? "ya-rotation-clockwise" : "ya-rotation");
        builder.AddContent(3, ChildContent);
        builder.CloseElement();
    };
}
```

**Nota:** usa `BuildRenderTree` manual via delegate (não markup .razor puro) para adicionar atributo HTML booleano dinâmico como classe CSS hook.

---

### `RotateEffect` — Rotação Estática

Aplica uma rotação fixa (não animada) por grau declarado. Usa variável CSS.

```razor
<RotateEffect Degrees="90">
    <Icon Kind="WellKnownIcons.Back" />
</RotateEffect>
```

Renderiza: `<div style="--rotate-effect-deg: 90deg">`. O CSS aplica `transform: rotate(var(--rotate-effect-deg))`.

---

## Factories de `AnimationFragment`

O projeto expõe factories estáticas para criar `AnimationFragment`:

### `Motions.Rotation()`

```csharp
// Cria AnimationFragment de rotação contínua:
AnimationFragment spinner = Motions.Rotation(clockwise: false);

// Uso como parâmetro de Button:
<Button Label="Carregando"
        Icon="WellKnownIcons.Settings"
        IconAnimation="@Motions.Rotation()" />
```

### `Effects.Rotate(degrees)`

```csharp
// Cria AnimationFragment de rotação estática:
AnimationFragment rotated = Effects.Rotate(180);

// Uso para ícone de "expandir" apontando para baixo vs cima:
<Button Icon="WellKnownIcons.ChevronDown"
        IconAnimation="@Effects.Rotate(isExpanded ? 180 : 0)" />
```

---

## Padrão: Loading State em Botão

O padrão recomendado para indicar carregamento em um botão é passar `IconAnimation` com `Motions.Rotation()`:

```razor
<Button Label="@(isLoading ? "Aguarde..." : "Salvar")"
        Icon="@(isLoading ? WellKnownIcons.Settings : WellKnownIcons.Save)"
        IconAnimation="@(isLoading ? Motions.Rotation() : null)"
        Disabled="@isLoading"
        Style="Themes.Primary"
        OnClick="@HandleSave" />

@code {
    private bool isLoading;

    private async Task HandleSave()
    {
        isLoading = true;
        try { await SaveAsync(); }
        finally { isLoading = false; }
    }
}
```

---

## Criando um Novo Efeito de Animação

Para adicionar uma nova animação ao sistema:

1. Criar o componente `.razor` em `RoyalCode.Razor.Animations/Animations/`:

```razor
@* GlowEffect.razor *@
@Render

@code {
    [Parameter]
    public RenderFragment ChildContent { get; set; } = null!;

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> AdditionalAttributes { get; set; } = null!;

    private RenderFragment Render => builder => {
        builder.OpenElement(0, "div");
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "ya-glow");  // hook CSS
        builder.AddContent(3, ChildContent);
        builder.CloseElement();
    };
}
```

2. Adicionar a classe CSS em `RoyalCode.Razor.Styles`:
```css
[ya-glow] { animation: glow 1s ease-in-out infinite; }
```

3. Expor como `AnimationFragment` factory (opcional):
```csharp
public static class Effects
{
    public static AnimationFragment Glow() =>
        content => builder => {
            // render GlowEffect wrapping content
        };
}
```




