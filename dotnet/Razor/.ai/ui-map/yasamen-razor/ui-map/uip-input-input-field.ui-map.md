# UIP-INPUT-INPUT_FIELD - Input Field

## Componentes

**Principais**:

1. TextField
- `cobertura`: campo de texto e senha; `Label`, `Placeholder`, `Information`, `Error`; `Type: InputType` (apenas `Text` e `Password`); `ReadOnly`, `Disabled`, `Size`; `@bind-Value` para two-way binding; integração com `EditForm` e validação via `DataAnnotationsValidator`; atributos HTML adicionais capturados via `AdditionalAttributes` (ex.: `required`, `maxlength`, `pattern`);
- `limitações`: `InputType` só tem `Text` e `Password` — sem `Email`, `Number`, `Tel`, `Url`, `Date` via enum; sem máscara de entrada nativa; sem textarea nativa na biblioteca;
- `nota`: 8;
- `justificativa`: campo atômico de texto e senha com anatomia completa — label, validação, estados disabled/readonly, adornments via Prepend/Append.

**Composição**:

1. FieldText (como adorno textual)
- `cobertura`: texto de prefixo ou sufixo dentro do campo via `Prepend` ou `Append` do `TextField` (ex.: "R$", "https://", ".com");
- `nota`: 8;
- `justificativa`: adorno textual integrado visualmente dentro do campo — cobertura nativa para prefixos e sufixos textuais.

2. FieldBadge (como adorno de badge)
- `cobertura`: badge estilizado com `Themes` dentro do campo via `Prepend` ou `Append`; texto + estilo visual;
- `nota`: 7;
- `justificativa`: adorno badge com semântica visual de tema — bom para indicadores de estado no campo.

3. FieldAction (como ação acoplada)
- `cobertura`: botão de ação dentro do campo via `FooterAction` ou `Append` (ex.: "Copiar", "Gerar", "Limpar"); herda API de `Button`;
- `nota`: 7;
- `justificativa`: ação acoplada ao campo com estilo coerente — cobre o pattern de campo com ação local.

4. Blazor `<InputTextArea>` (para texto longo)
- `cobertura`: textarea multilinha nativa do Blazor; integra com `EditForm`; sem estilização da biblioteca;
- `nota`: 4;
- `justificativa`: funcional dentro de EditForm mas sem estilo da lib — usa estilos HTML nativos do browser.

5. Blazor `<InputNumber<T>>` (para campos numéricos)
- `cobertura`: campo numérico do Blazor com binding tipado; sem estilização da biblioteca;
- `nota`: 4;
- `justificativa`: funcional dentro de EditForm mas sem estilo da lib.

**Descartados**:
- `FieldText como input`: FieldText é decorativo (wrapper div `ya-field-text`) — não é um input e não suporta `@bind-Value`.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `tipo email, tel, url, date (semântica HTML)`: `InputType` não suporta esses tipos — usar `<input type="email">` HTML nativo ou `<TextField>` com atributo `type="email"` via `AdditionalAttributes` ([inferido] — comportamento dependente de como o componente renderiza atributos duplicados);
  - `máscara de entrada (CPF, CNPJ, telefone)`: sem nativo — JS interop com Inputmask ou lógica C# de formatação em `@oninput`;
  - `textarea estilizada`: sem componente nativo — usar `<InputTextArea>` Blazor sem estilização da lib;
  - `campo numérico estilizado`: sem componente nativo — usar `<InputNumber<T>>` Blazor sem estilização da lib.

- `tipo de adaptação`: componente principal implementa
- `o que precisa ser feito`:
  - Texto simples e senha: `TextField` com `Type="InputType.Text"` ou `Type="InputType.Password"`;
  - Prefixo/sufixo textual: `FieldText` no slot `Prepend` ou `Append` do `TextField`;
  - Ação acoplada: `FieldAction` no slot `FooterAction` ou `Append`;
  - Validação via `DataAnnotationsValidator` + atributos de anotação no model C#.

## Como usar

### Campos básicos de texto e senha

```razor
<TextField @bind-Value="model.Nome" Label="Nome completo" Placeholder="Ex: João Silva" required />
<TextField @bind-Value="model.Email" Label="E-mail" Placeholder="usuario@dominio.com" Information="Usado para login" required />
<TextField @bind-Value="model.Senha" Type="InputType.Password" Label="Senha" required />
```

### Campo com prefixo textual (FieldText no Prepend)

```razor
<TextField @bind-Value="model.Site" Label="Site">
    <Prepend>
        <FieldText>https://</FieldText>
    </Prepend>
</TextField>
```

### Campo com sufixo monetário (FieldText no Append)

```razor
<TextField @bind-Value="model.Desconto" Label="Desconto">
    <Append>
        <FieldText>%</FieldText>
    </Append>
</TextField>
```

### Campo com ação acoplada (FieldAction no FooterAction)

```razor
<TextField @bind-Value="model.Token" Label="Token de acesso" ReadOnly=true>
    <FooterAction>
        <FieldAction Label="Copiar" Icon="WellKnownIcons.Copy"
                     Style="Themes.Secondary" OnClick="CopiarToken" />
    </FooterAction>
</TextField>
```

### Campo somente leitura com informação

```razor
<TextField Value="@usuario.Email" Label="E-mail" ReadOnly=true
           Information="O e-mail não pode ser alterado após o cadastro." />
```

### Textarea e número (Blazor nativo — sem estilo da lib)

```razor
@* Textarea — <InputTextArea> Blazor, sem estilo da biblioteca *@
<div class="flex flex-col gap-1">
    <label class="text-sm font-medium text-dark-600">Observações</label>
    <InputTextArea @bind-Value="model.Observacao" rows="4"
                   class="w-full border border-light-300 rounded-md px-3 py-2 text-sm" />
    <ValidationMessage For="() => model.Observacao" />
</div>

@* Número — <InputNumber<T>> Blazor, sem estilo da biblioteca *@
<div class="flex flex-col gap-1">
    <label class="text-sm font-medium text-dark-600">Idade</label>
    <InputNumber @bind-Value="model.Idade" min="0" max="150"
                 class="w-full border border-light-300 rounded-md px-3 py-2 text-sm" />
    <ValidationMessage For="() => model.Idade" />
</div>
```

## Decisão de uso

- `nota geral`: 7;
- `limitações`: `InputType` apenas `Text` e `Password` — sem Email, Number, Tel, Date via enum; sem textarea ou campo numérico estilizado nativos; máscara requer JS interop ou C# manual;
- `recomendação`: `usar direto`
- `justificativa geral`:
  - `TextField` cobre texto e senha com anatomia completa (label, validation, adornments, disabled/readonly);
  - Prefixos/sufixos textuais e ações acopladas cobertos via `FieldText`, `FieldBadge`, `FieldAction`;
  - Textarea e número usam Blazor nativo (`InputTextArea`, `InputNumber`) sem estilização da lib;
  - Nota 7 reflete cobertura sólida para text/password com lacunas em tipos semânticos e campos especializados.
