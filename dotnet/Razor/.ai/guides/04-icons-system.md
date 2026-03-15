# Guide 04 — Sistema de Ícones

> Como funciona o sistema de ícones do projeto `RoyalCode.Razor.Icons`, como registrar bibliotecas de ícones, como usar `WellKnownIcons` e como renderizar ícones em novos componentes.

---

## Visão Geral

O sistema de ícones é **desacoplado da biblioteca de ícones**. O componente `Icon` sabe **como renderizar** mas não sabe **quais SVGs existem**. As bibliotecas de ícones (ex: Bootstrap Icons) se registram via factory pattern.

Isso permite:
- Trocar a biblioteca de ícones sem mudar os componentes
- Usar enums fortemente tipados (ex: `BsIconNames.House`)
- Mapear ícones semânticos (`WellKnownIcons`) para qualquer biblioteca

---

## Componente `Icon`

```razor
@* Por enum direto da biblioteca: *@
<Icon Kind="BsIconNames.House" />

@* Por ícone semântico (WellKnownIcons): *@
<Icon Kind="WellKnownIcons.Home" />

@* Com classes CSS adicionais: *@
<Icon Kind="WellKnownIcons.Add" AdditionalClasses="w-5 h-5 text-blue-500" />

@* Por fragment (resultado de IconRender.Fragment): *@
<Icon Fragment="@myFragment" />
```

Parâmetros:
| Parâmetro | Tipo | Descrição |
|---|---|---|
| `Kind` | `Enum?` | Enum de qualquer biblioteca registrada |
| `Fragment` | `IconFragment?` | Fragment pré-resolvido |
| `AdditionalClasses` | `string?` | Classes CSS para o SVG |
| `AdditionalAttributes` | `Dictionary<string,object>?` | Atributos splatted no SVG |

**Regra:** nunca definir `Kind` e `Fragment` ao mesmo tempo — o componente lança exceção.

---

## `IconFragment` — Delegate de Ícone

```csharp
// Tipo do delegate:
public delegate RenderFragment IconFragment(string? additionalClasses, Dictionary<string, object>? additionalAttributes);
```

É um delegate que recebe classes e atributos opcionais e retorna um `RenderFragment` com o SVG.

### Obtendo um `IconFragment`

```csharp
// Via método estático:
IconFragment fragment = IconRender.Fragment(BsIconNames.House);

// Em .razor — renderizar diretamente:
@IconRender.Fragment(WellKnownIcons.Close)("text-sm", null)

// Com classes:
@WellKnownIcons.Close("text-sm")
```

---

## `WellKnownIcons` — Ícones Semânticos

`WellKnownIcons` é um mapa de **conceitos semânticos** para `IconFragment`. Os valores são preenchidos pela biblioteca de ícones no startup.

### Ícones disponíveis

```csharp
WellKnownIcons.Home
WellKnownIcons.Add
WellKnownIcons.Edit
WellKnownIcons.Delete
WellKnownIcons.Close
WellKnownIcons.Menu
WellKnownIcons.Dots        // três pontos (⋮)
WellKnownIcons.Back
WellKnownIcons.Next
WellKnownIcons.Search
WellKnownIcons.Settings
WellKnownIcons.User
WellKnownIcons.FavoriteOn  // coração preenchido
WellKnownIcons.FavoriteOff // coração vazio
WellKnownIcons.Filter
WellKnownIcons.Export
WellKnownIcons.Print
WellKnownIcons.Refresh
// ... ~40 no total
```

### Uso em componentes internos

Componentes da biblioteca que precisam de ícones usam sempre `WellKnownIcons`, **nunca** enum de uma biblioteca específica diretamente:

```razor
@* Correto — semântico, independente da lib: *@
<button @onclick="CloseAsync">
    @WellKnownIcons.Close("text-sm")
</button>

@* Errado — acoplado à Bootstrap Icons: *@
<Icon Kind="BsIconNames.XCircle" />
```

---

## `IconContentFactories` — Registro de Fábricas

```csharp
// Registry de factories por tipo de enum:
IconContentFactories.Register<BsIconNames>(new BootstrapIconContentFactory());

// Obter factory para um tipo:
IIconContentFactory factory = IconContentFactories.Get(typeof(BsIconNames));
IconFragment fragment = factory.GetFragment(BsIconNames.House);
```

---

## Bootstrap Icons — `RoyalCode.Razor.Icons.Bootstrap`

### Registro no startup

```csharp
// Em Program.cs:
BootstrapIcons.Include();

// Ou sem mapear WellKnownIcons (caso já haja outra lib):
BootstrapIcons.Include(includeCommonsIcons: false);
```

### Enum `BsIconNames`

```csharp
// 1.000+ ícones com atributo [Description] mapeando para o nome do arquivo SVG:
public enum BsIconNames
{
    [Description("house")] House,
    [Description("plus-circle")] PlusCircle,
    [Description("x-circle")] XCircle,
    // ...
}
```

---

## Usando Ícones em Novos Componentes

### 1. Parâmetro de ícone opcional

```csharp
// No .razor.cs:
[Parameter]
public Enum? Icon { get; set; }

[Parameter]
public Positions IconPosition { get; set; }
```

### 2. Renderizar no markup

```razor
@if (Icon is not null && IconPosition == Positions.Start)
{
    <Icon Kind="Icon" />
}

@Content

@if (Icon is not null && IconPosition == Positions.End)
{
    <Icon Kind="Icon" />
}
```

### 3. Fragment inline (sem parâmetro de posição)

```csharp
// Quando o ícone é fixo e interno ao componente:
private RenderFragment RenderIcon => IconRender.Fragment(Icon!);
```

### 4. Com animação (ver Guide 05)

```csharp
private RenderFragment RenderIcon => IconAnimation is not null
    ? IconAnimation(IconRender.Fragment(Icon!))
    : IconRender.Fragment(Icon!);
```

---

## Criando uma Nova Biblioteca de Ícones

Se precisar integrar uma biblioteca diferente de Bootstrap Icons:

1. Criar `public enum MyIconNames { ... }` com `[Description("icon-name")]`
2. Implementar `IIconContentFactory`:
```csharp
public class MyIconContentFactory : IIconContentFactory
{
    public IconFragment GetFragment(Enum kind) { /* retorna SVG */ }
}
```
3. Registrar no startup: `IconContentFactories.Register<MyIconNames>(new MyIconContentFactory())`
4. Mapear `WellKnownIcons` via `WellKnownIcons.Include(/* delegates */)`
