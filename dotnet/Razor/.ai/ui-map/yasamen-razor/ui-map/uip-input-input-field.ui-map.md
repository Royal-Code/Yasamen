# UIP-INPUT-INPUT_FIELD - Input Field

## Componentes

**Principais**:

1. FieldText
- `cobertura`: campo de texto, email, senha, URL, número; `Label`, `Placeholder`, `HelpText`, `Required`; validação inline via `ValidationMessage` do Blazor + `AdditionalClasses` de erro; `Type` para semântica HTML (`text`, `email`, `password`, `number`, `tel`, `url`); readonly via `ReadOnly=true`; disabled via `Disabled=true`; `@bind-Value` para two-way binding;
- `limitações`: sem máscara de entrada nativa; sem prefixo/sufixo de texto embutido nativamente; sem ação local acoplada (ex: botão "copiar" dentro do campo);
- `nota`: 8;
- `justificativa`: campo atômico de texto com anatomia completa de label, validação e estados — cobertura sólida para a maioria dos tipos escalares.

2. FieldTextArea
- `cobertura`: textarea para texto longo; `Rows` configurável; mesma anatomia do FieldText;
- `nota`: 8;
- `justificativa`: variante de texto multilinha com mesma API.

3. FieldNumber
- `cobertura`: campo numérico com `Min`, `Max`, `Step`; validação de range;
- `nota`: 7;
- `justificativa`: campo numérico com semântica e validação específica.

**Composição**:

1. Badge / span + FieldText
- `cobertura`: prefixo ou sufixo visual (ex: "R$", "%", "kg") como elemento HTML ao lado do campo;
- `nota`: 5;
- `justificativa`: adorno textual externo ao campo — não integrado visualmente como prefixo dentro do input.

2. IconButton + FieldText (em Bar)
- `cobertura`: campo com ação local (ex: "Copiar", "Limpar", "Gerar") posicionado ao lado via `Bar`;
- `nota`: 5;
- `justificativa`: ação acoplada via composição — não integrada dentro do input.

**Descartados**: nenhum.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `máscara de entrada (CPF, CNPJ, telefone)`: sem nativo — JS interop com Inputmask ou lógica C# de formatação em `@oninput`;
  - `prefixo/sufixo integrado visualmente`: usar `<div class="flex items-center">` + `<span class="...">R$</span>` + `FieldText AdditionalClasses="rounded-l-none"`;
  - `ação dentro do campo (reveal password, copiar)`: compor `FieldText` + `IconButton` em `Bar` ou div flex.

- `tipo de adaptação`: componente principal implementa
- `o que precisa ser feito`:
  - Usar `FieldText` com `Type` correto para semântica; `Required`, `HelpText`, `Disabled` conforme regra;
  - Para senha: `Type="password"` + `IconButton` de reveal ao lado via composição;
  - Validação via `DataAnnotationsValidator` + `ValidationMessage` nativo do Blazor.

## Como usar

### Campos básicos

```razor
<FieldText @bind-Value="model.Nome" Label="Nome" Required=true Placeholder="Ex: João Silva" />
<FieldText @bind-Value="model.Email" Type="email" Label="E-mail" Required=true />
<FieldText @bind-Value="model.Senha" Type="password" Label="Senha" Required=true />
<FieldNumber @bind-Value="model.Idade" Label="Idade" Min="0" Max="150" />
<FieldTextArea @bind-Value="model.Observacao" Label="Observações" Rows="4" />
```

### Campo com prefixo monetário (composição)

```razor
<div class="flex flex-col gap-1">
    <label class="text-sm font-medium text-dark-600">Valor</label>
    <div class="flex items-center border border-light-300 rounded-md overflow-hidden">
        <span class="px-3 py-2 bg-light-100 text-dark-400 text-sm border-r border-light-300">R$</span>
        <input type="number" class="flex-1 px-3 py-2 text-sm outline-none"
               @bind="model.Valor" min="0" step="0.01" />
    </div>
</div>
```

### Campo somente leitura

```razor
<FieldText Value="@usuario.Email" Label="E-mail" ReadOnly=true
           HelpText="O e-mail não pode ser alterado após o cadastro." />
```

## Decisão de uso

- `nota geral`: 7;
- `limitações`: sem máscara de entrada nativa; prefixo/sufixo integrado visualmente requer composição manual; ação dentro do campo requer composição com Bar ou div flex; sem autocomplete customizado nativo;
- `recomendação`: `usar direto`
- `justificativa geral`:
  - `FieldText`, `FieldTextArea` e `FieldNumber` cobrem nativamente a anatomia completa de campo atômico;
  - Integração com `EditForm` + `DataAnnotationsValidator` para validação Blazor;
  - Nota 7 reflete cobertura sólida com limitações em máscaras e adornments integrados.
