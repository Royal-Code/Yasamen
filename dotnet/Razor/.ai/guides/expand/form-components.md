# Infraestrutura de Componentes de Formulário

> Como funciona a cadeia `FieldBase → FieldBase<T> → InputFieldBase<T> → TextField`. Como criar novos inputs seguindo o mesmo padrão.

---

## Visão Geral da Hierarquia

```
ComponentBase
  └── FieldBase                      (não-genérico — parâmetros comuns: Label, Size, Disabled, Prepend/Append)
        └── FieldBase<TValue>        (genérico — Value binding, EditContext, validação, parsing)
              └── InputFieldBase<TValue>  (input HTML — Type, MaxLength, BindEvent)
                    └── TextField    (string — TryParseValue + FormatValue)
                    └── NumberField  (a criar — numeric + parsing)
                    └── TextAreaField (a criar — textarea)
```

Componentes mais complexos (Select, CheckBox, DatePicker) herdam diretamente de `FieldBase<TValue>` e implementam seu próprio markup.

---

## `FieldBase` — Parâmetros de Base

Todos os campos compartilham estes parâmetros:

```csharp
[Parameter] public string? AdditionalClasses { get; set; }
[Parameter(CaptureUnmatchedValues = true)]
public Dictionary<string, object>? AdditionalAttributes { get; set; }

[Parameter] public string? Id { get; set; }
[Parameter] public string? Name { get; set; }
[Parameter] public string? Label { get; set; }
[Parameter] public string? LabelId { get; set; }
[Parameter] public string? Placeholder { get; set; }
[Parameter] public string? Information { get; set; }  // texto de ajuda abaixo do campo
[Parameter] public string? Error { get; set; }         // erro externo (não de validação)
[Parameter] public bool Disabled { get; set; }
[Parameter] public bool ReadOnly { get; set; }
[Parameter] public Sizes Size { get; set; } = Sizes.Default;
[Parameter] public string? ParsingErrorPattern { get; set; } = string.Empty;

// Cascading do EditForm:
[CascadingParameter] protected EditContext? CascadedEditContext { get; set; }

// Slots de addon (input group):
[Parameter] public RenderFragment Prepend { get; set; } = EmptyFragment.Delegate;
[Parameter] public RenderFragment Append { get; set; } = EmptyFragment.Delegate;
[Parameter] public RenderFragment FooterAction { get; set; } = EmptyFragment.Delegate;
[Parameter] public RenderFragment? DescriptionComplement { get; set; }
```

### IDs gerados automaticamente

Quando `Id` e `LabelId` não são fornecidos, `FieldBase` os gera automaticamente:

```csharp
// São lazy - gerados apenas quando acessados:
protected string FieldLabelId => labelId ??= (LabelId ?? YasamenExtensions.GenerateId());
protected string FieldInputId => inputId ??= (Id ?? YasamenExtensions.GenerateId());
```

### Label inferido da expressão

Quando o campo está vinculado via `@bind-Value` e não tem `Label` explícito:

```csharp
// FieldBase infere o Label a partir do ValueExpression:
// ex: @bind-Value="model.FirstName" → Label = "First Name"
// via propertyInfo.GetDefaultDisplayName()
```

---

## `FieldBase<TValue>` — Binding e Validação

```csharp
[Parameter] public TValue? Value { get; set; }
[Parameter] public EventCallback<TValue> ValueChanged { get; set; }
[Parameter] public Expression<Func<TValue>>? ValueExpression { get; set; }
[Parameter] public EventCallback<TValue> OnChange { get; set; }
```

### Validação integrada com `EditContext`

Quando dentro de um `<EditForm>`:
- Subscreve `EditContext.OnValidationStateChanged`
- Detecta erros de validação para `FieldIdentifier`
- Expõe `IsInvalid` (bool) e `GetErrorMessage()` para o markup

### Método abstrato `TryParseValue`

```csharp
/// <summary>
/// Tenta converter a string (value de input) para TValue.
/// </summary>
protected abstract bool TryParseValue(string? value,
    out TValue result,
    out string? errorMessage);

/// <summary>
/// Formata TValue para string (para exibição no input).
/// </summary>
protected abstract string? FormatValue(TValue? value);
```

---

## `InputFieldBase<TValue>` — Input HTML Base

Adiciona parâmetros específicos de `<input>`:

```csharp
[Parameter] public InputType Type { get; set; }   // Text, Password
[Parameter] public int? MaxLength { get; set; }
[Parameter] public string BindEvent { get; set; } = "onchange";
```

### Markup renderizado

Usa `FieldGroup` para layout e `<input>` com `@bind-value`:

```razor
<FieldGroup Label="@FieldLabel" LabelId="@FieldLabelId" ... >
    <Control>
        <input id="@FieldInputId"
               type="@Type.ToString().ToLower()"
               class="@Classes"
               @bind-value="CurrentValueAsString"
               @bind-value:event="@BindEvent"
               @ref="Element" />
    </Control>
</FieldGroup>
```

---

## `FieldGroup` — Layout do Campo

`FieldGroup` é o componente de **layout** de um campo. Não tem lógica de valor — apenas renderiza estrutura:

```
FieldGroup
├── description div
│   ├── <label> (LabelId / LabelFor)
│   └── DescriptionComplement slot
├── ControlGroup (se Prepend ou Append)
│   ├── Prepend slot
│   ├── Control slot (o <input> real)
│   └── Append slot
├── informative div (se Information ou FooterAction)
│   ├── ya-field-information
│   └── ya-field-group-footer
└── FieldError (se ErrorMessage presente)
```

**Regra:** nunca criar markup de label/validação/addons diretamente num input. Sempre usar `FieldGroup`.

---

## Criando um Novo Campo de Formulário

### Caso 1 — Input simples derivado de `InputFieldBase`

```csharp
// NumberField.cs
namespace RoyalCode.Razor.Components;

public class NumberField : InputFieldBase<decimal>
{
    [Parameter]
    public decimal? Min { get; set; }

    [Parameter]
    public decimal? Max { get; set; }

    [Parameter]
    public string? Format { get; set; }

    protected override bool TryParseValue(string? value,
        out decimal result,
        out string? errorMessage)
    {
        if (decimal.TryParse(value, out result))
        {
            errorMessage = null;
            return true;
        }
        result = default;
        errorMessage = ParsingErrorPattern ?? "Valor numérico inválido.";
        return false;
    }

    protected override string? FormatValue(decimal? value)
        => value?.ToString(Format ?? string.Empty);
}
```

Esse campo usará automaticamente o markup de `InputFieldBase` (FieldGroup + input).

---

### Caso 2 — Campo com markup próprio (ex: Select, CheckBox)

Criar `.razor` + `.razor.cs`:

```csharp
// SelectField.razor.cs
public partial class SelectField<TValue> : FieldBase<TValue>
{
    [Parameter, EditorRequired]
    public IEnumerable<TValue> Items { get; set; } = Enumerable.Empty<TValue>();

    [Parameter]
    public Func<TValue, string>? TextField { get; set; }

    [Parameter]
    public string? Placeholder { get; set; }

    protected override bool TryParseValue(string? value,
        out TValue result,
        out string? errorMessage)
    {
        // lógica de parsing do select
    }

    protected override string? FormatValue(TValue? value)
        => TextField?.Invoke(value!) ?? value?.ToString();
}
```

```razor
@* SelectField.razor *@
@typeparam TValue

<FieldGroup Label="@FieldLabel"
            LabelId="@FieldLabelId"
            LabelFor="@FieldInputId"
            ErrorMessage="@GetErrorMessage()"
            Size="Size"
            Prepend="@Prepend"
            Append="@Append"
            AdditionalClasses="@AdditionalClasses">
    <Control>
        <select id="@FieldInputId"
                class="@SelectClasses"
                disabled="@Disabled"
                @bind="CurrentValueAsString"
                @attributes="AdditionalAttributes">
            @if (Placeholder.IsPresent())
            {
                <option value="">@Placeholder</option>
            }
            @foreach (var item in Items)
            {
                <option value="@FormatValue(item)">
                    @(TextField?.Invoke(item) ?? item?.ToString())
                </option>
            }
        </select>
    </Control>
</FieldGroup>

@code {
    private string SelectClasses => "ya-select-field"
        .AddClass(IsInvalid, "ya-select-field-invalid")
        .AddClass(Size.ToCssClassName("ya-field"));
}
```

---

## Componentes de Apoio a Formulários

| Componente | Propósito |
|---|---|
| `FieldAction` | Botão estilizado ao lado de campo (`ya-field-action`) |
| `FieldBadge` | Badge colorida para rotular campo ("Obrigatório", "Beta") |
| `FieldText` | Wrapper de texto no addon do input (`ya-field-text`) |

### Uso típico com addons

```razor
<TextField Label="URL">
    <Prepend>
        <FieldText>https://</FieldText>
    </Prepend>
    <Append>
        <FieldText>.com</FieldText>
        <FieldAction Label="Verificar" OnClick="@Verify" />
    </Append>
</TextField>
```

---

## Validação — Integração com `EditForm`

O campo funciona automaticamente dentro de `<EditForm>`:

```razor
<EditForm Model="@model" OnValidSubmit="@Submit">
    <DataAnnotationsValidator />

    <TextField @bind-Value="model.Name"
               Label="Nome"
               Placeholder="Digite seu nome" />

    <Button Type="ButtonTypes.Submit" Label="Enviar" Style="Themes.Primary" />
</EditForm>
```

- `CascadedEditContext` é preenchido automaticamente pelo `EditForm`
- Erros de `DataAnnotationsValidator` aparecem sob o campo via `FieldGroup → FieldError`
- O campo fica com classe `ya-input-field-invalid` quando há erro

---

## Checklist para Novo Campo de Formulário

- [ ] Herdar de `InputFieldBase<TValue>` (simples) ou `FieldBase<TValue>` (custom markup)
- [ ] Implementar `TryParseValue` e `FormatValue`
- [ ] Usar `FieldGroup` no markup (nunca criar label/error próprio)
- [ ] Classe CSS do `<input>` / `<select>`: `ya-{tipo}-field` + `ya-{tipo}-field-invalid` quando `IsInvalid`
- [ ] `Size.ToCssClassName("ya-field")` para propagar o tamanho
- [ ] Parâmetros herdados `Prepend`, `Append`, `FooterAction`, `DescriptionComplement` expostos via `FieldGroup`
- [ ] `@typeparam TValue` no topo do `.razor` para campos genéricos



