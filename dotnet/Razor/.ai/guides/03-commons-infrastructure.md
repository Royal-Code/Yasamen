# Guide 03 — Projeto Commons: Infraestrutura Compartilhada

> O que é o projeto `RoyalCode.Razor.Commons`, para que serve cada parte, e como usar seus utilitários nos outros projetos.

---

## Propósito do Projeto Commons

`RoyalCode.Razor.Commons` é o projeto de **infraestrutura transversal** — não contém componentes visuais. Fornece:

1. **JS Modules** — wrappers type-safe para interop JavaScript
2. **`EmptyFragment`** — utilitário para `RenderFragment` vazios
3. **Extensions** — helpers de string, atributos HTML e ID generation
4. **`TransitionState` / `VisibleState`** — gerenciamento de estados de animação/visibilidade
5. **Registros DI** (`AddYasamenCommons`)
6. **Módulo de autenticação** (utilitários de auth state + HTTP handler)

Todos os outros projetos de componentes dependem de Commons.

---

## `EmptyFragment` — Fragmentos Vazios

Padrão obrigatório para parâmetros `RenderFragment` opcionais.

```csharp
// Em vez de null:
[Parameter]
public RenderFragment Prepend { get; set; } = EmptyFragment.Delegate;

// Para verificar se foi preenchido:
if (Prepend.IsNotEmptyFragment())
{
    // renderizar
}

// Fragment tipado:
[Parameter]
public RenderFragment<MyModel> ItemTemplate { get; set; } = EmptyFragment.GetDelegate<MyModel>();
```

**Regra:** todo parâmetro `RenderFragment` opcional **deve** ter valor padrão `EmptyFragment.Delegate`. Nunca usar `null` como padrão.

**Por quê:** `.IsNotEmptyFragment()` detecta corretamente se o slot foi fornecido, evitando comparação com `null` que falha em alguns cenários de re-render do Blazor.

---

## `CssClasses` — Método `IsPresent` / `IsMissing`

Além dos extension methods em `CssClasses`, o namespace expõe extensões de string:

```csharp
// Verifica se string não é null/whitespace
string? text = GetText();
if (text.IsPresent()) { /* usar text */ }
if (text.IsMissing()) { /* não usar */ }

// Em .razor (exemplo do Feedback):
@if (Title.IsPresent())
{
    <h4>@Title</h4>
}
```

---

## `AdditionalAttributesExtensions` — Splatting de Atributos

Padrão para componentes que usam `[Parameter(CaptureUnmatchedValues = true)]`:

```csharp
// Parâmetro obrigatório em componentes que aceitam splatting:
[Parameter(CaptureUnmatchedValues = true)]
public Dictionary<string, object>? AdditionalAttributes { get; set; }
```

No markup:
```razor
<div class="@Classes" @attributes="AdditionalAttributes">
```

Para **extrair** atributos específicos antes de splat (ex: extrair `class` manual):
```csharp
// Extrai e remove "class" do dict para não duplicar
var extraClass = AdditionalAttributes.ExtractClass();
```

---

## `YasamenExtensions` — Utilitários de ID e Texto

### Geração de IDs únicos
```csharp
// 10 letras minúsculas aleatórias
string id = YasamenExtensions.GenerateId(); // "kzjqpwxmnt"

// Converter string em ID HTML-safe
string htmlId = "Meu Componente!".ToHtmlId(); // "Meu-Componente"
```

Usado em `FieldBase` para gerar `labelId` e `inputId` únicos quando não fornecidos pelo consumidor.

### `GetDefaultDisplayName` para Labels
```csharp
// Lê DisplayName, Description ou DisplayAttribute do MemberInfo
// Usado em FieldBase para inferir o Label a partir da propriedade bindada
string label = propertyInfo.GetDefaultDisplayName();
```

---

## JS Modules — Padrão `JsModuleBase`

Todo interop JavaScript é encapsulado em uma classe que herda de `JsModuleBase`.

### Como funciona

```csharp
public abstract class JsModuleBase
{
    // Caminho relativo ao wwwroot do assembly
    protected JsModuleBase(IJSRuntime js, string pathFromWwwRoot, bool isLibrary = true)

    // Carrega o módulo lazy (apenas na primeira chamada)
    protected async ValueTask<IJSObjectReference> GetModuleAsync()
    // → Resolve para: "./_content/{AssemblyName}/{pathFromWwwRoot}"
}
```

### Criando um novo JS Module

```csharp
public sealed class MyJs : JsModuleBase
{
    public MyJs(IJSRuntime js) : base(js, "my-module.js") { }

    public async ValueTask DoSomethingAsync(ElementReference element)
    {
        var js = await GetModuleAsync();
        await js.InvokeVoidAsync("doSomething", element);
    }
}
```

Registrar no DI como `Transient`:
```csharp
services.AddTransient<MyJs>();
```

O arquivo JS deve estar em `wwwroot/my-module.js` do projeto que define o módulo.

### Módulos existentes

| Classe | Arquivo JS | Propósito |
|---|---|---|
| `RippleJs` | `ripple.js` | Efeito material ripple em botões |
| `ClickJs` | `click.js` | Listener de clique no `document.body` (usado por dropdowns) |
| `ElementJs` | `element.js` | Get/Set propriedades DOM, invoke métodos, getBoundingClientRect |
| `FormsJs` | `forms.js` | Blur-on-Enter, focus-next, get/set value de input |

### `FieldJs` — JS específico de campos de formulário

`FieldJs` é um helper **não injetável diretamente** — é instanciado por `FieldBase` internamente. Encapsula operações JS específicas do ciclo de vida de um campo.

---

## `TransitionState` — Gerenciamento de Transições CSS

Gerencia o ciclo de vida de transições CSS com as fases:

```
OpeningStart → Opening → Open → ClosingStart → Closing → Closed
```

```csharp
// Exemplo de uso (Modal, NotificationAnimation):
private TransitionState transitionState = new();

// Para abrir:
await transitionState.OpenAsync(StateHasChanged);

// Para fechar:
await transitionState.CloseAsync(StateHasChanged);

// Fase atual:
TransitionPhases phase = transitionState.Phase;

// Gerar classe CSS:
string cssClass = $"ya-modal-{transitionState.Phase.ToCssClass()}";
```

Cada fase dura um ciclo de render, permitindo que o CSS aplique a transição.

---

## `VisibleState` — Toggle Simples de Visibilidade

Para componentes com show/hide sem transição animada complexa:

```csharp
private VisibleState visibleState = new();

// Mostrar:
await visibleState.ShowAsync(StateHasChanged);

// Esconder:
await visibleState.HideAsync(StateHasChanged);

// Estado:
bool isVisible = visibleState.IsVisible;
```

Usado pelo `OffCanvas` e outros componentes de sobreposição.

---

## `AddYasamenCommons` — Registro DI

```csharp
// Em Program.cs da app consumidora:
builder.Services.AddYasamenCommons();
```

Registra `Transient`:
- `ClickJs`
- `ElementJs`
- `FormsJs`
- `RippleJs`

---

## Módulo de Autenticação (uso avançado)

O projeto inclui utilitários para propagação de auth state via HTTP:

```csharp
// Adiciona handler que injeta auth state em requests HTTP:
builder.Services
    .AddHttpClient("MyApi")
    .AuthorizeWithAuthenticationState();
```

Claims padrão disponíveis em `WellKnownClaimNames` (Name, Email, Role, Sub, etc.).
