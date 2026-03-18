# Commons: Infraestrutura Compartilhada

> O que e o projeto `RoyalCode.Razor.Commons`, o que ele concentra de infraestrutura e como os outros pacotes devem usa-lo.

---

## Proposito do Projeto Commons

`RoyalCode.Razor.Commons` e o pacote de infraestrutura transversal da biblioteca. Ele concentra utilitarios e primitives reutilizadas por varios projetos.

Na pratica, ele contem:

1. JS modules para interop JavaScript;
2. `EmptyFragment` para parametros `RenderFragment`;
3. extensoes utilitarias de string, atributos HTML e IDs;
4. `TransitionState` e `VisibleState`;
5. registros DI (`AddYasamenCommons`);
6. utilitarios de autenticacao;
7. componentes utilitarios de infraestrutura, como `Ripple`.

Commons nao e um pacote de catalogo visual amplo, mas pode conter componente utilitario transversal quando isso simplifica a infraestrutura compartilhada.

---

## `EmptyFragment`

Padrao para parametros opcionais de `RenderFragment`.

```csharp
[Parameter]
public RenderFragment Prepend { get; set; } = EmptyFragment.Delegate;
```

Para testar se houve preenchimento:

```csharp
if (Prepend.IsNotEmptyFragment())
{
    // renderizar
}
```

Regra: evitar `null` como valor padrao para fragments opcionais quando a biblioteca precisa distinguir fragmento ausente de fragmento vazio.

---

## `AdditionalAttributes`

Padrao para componentes que aceitam splatting:

```csharp
[Parameter(CaptureUnmatchedValues = true)]
public Dictionary<string, object>? AdditionalAttributes { get; set; }
```

No markup:

```razor
<div class="@Classes" @attributes="AdditionalAttributes">
```

Se precisar tratar algum atributo antes do splatting, use os helpers do Commons.

---

## IDs e utilitarios

Exemplos:

```csharp
string id = YasamenExtensions.GenerateId();
string htmlId = "Meu Componente".ToHtmlId();
string label = propertyInfo.GetDefaultDisplayName();
```

Esses helpers aparecem especialmente em componentes de formulario.

---

## JS Modules

Interop JavaScript deve ser encapsulado em classes derivadas de `JsModuleBase`.

```csharp
public sealed class MyJs : JsModuleBase
{
    public MyJs(IJSRuntime js) : base(js, "my-module.js") { }
}
```

Regra:

- arquivo JS em `wwwroot/`;
- wrapper C# no Commons ou no pacote dono da funcionalidade;
- registro DI normalmente como `Transient`.

Exemplos atuais:

- `RippleJs`
- `ClickJs`
- `ElementJs`
- `FormsJs`

---

## `TransitionState` e `VisibleState`

`TransitionState` serve para ciclos com fases de abertura e fechamento.

`VisibleState` serve para show/hide simples.

Exemplo:

```csharp
await transitionState.OpenAsync(StateHasChanged);
await transitionState.CloseAsync(StateHasChanged);

await visibleState.ShowAsync(StateHasChanged);
await visibleState.HideAsync(StateHasChanged);
```

---

## `Ripple`

`Ripple` existe no Commons e e um componente visual utilitario de infraestrutura. Ele nao muda o papel do pacote, mas mostra que Commons pode expor componente transversal quando isso apoia varios outros pacotes.

---

## `AddYasamenCommons`

Uso esperado:

```csharp
builder.Services.AddYasamenCommons();
```

Isso registra os JS modules compartilhados e a infraestrutura comum necessaria para os demais componentes.

---

## Regras Praticas

1. Coloque no Commons apenas o que for transversal.
2. Nao mova para o Commons componentes de dominio ou de catalogo apenas por reuso eventual.
3. Um componente utilitario de infraestrutura pode morar no Commons se ele apoiar varios pacotes e nao pertencer semanticamente a um componente final.
4. Helpers de markup, JS interop, estados de transicao e extensoes gerais sao candidatos naturais ao Commons.

