# UIP-INPUT-FORM_FIELD_GROUP - Form Field Group

## Componentes

**Principais**:

1. FormGroup
- `cobertura`: container de seção de formulário com `Legend` (título da seção) e `HelpText` (descrição contextual); semântica de `<fieldset>`; validação no nível do grupo; borda/padding configuráveis; compatível com `EditForm` do Blazor;
- `limitações`: sem layout de 2 colunas nativo — requer `AdditionalClasses="grid grid-cols-2 gap-4"` nos campos internos;
- `nota`: 9;
- `justificativa`: container semântico de seção de formulário com título, help text e suporte a validação por grupo.

**Composição**:

1. Stack
- `cobertura`: sequência vertical dos campos dentro do grupo com espaçamento coerente;
- `nota`: 8;
- `justificativa`: espaçamento entre campos em layout de coluna única (mobile e formulários simples).

2. Container+Slot
- `cobertura`: layout de 2 colunas para formulários desktop com campos lado a lado;
- `nota`: 7;
- `justificativa`: grid de 2+ colunas para campos relacionados em desktop.

3. Box
- `cobertura`: container de seção com borda e padding quando `FormGroup` não é o container principal;
- `nota`: 7;
- `justificativa`: delimitação visual de seção de formulário.

**Descartados**: nenhum.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `layout 2 colunas responsivo`: usar `Container+Slot` com `cols-sm:2` ou `AdditionalClasses="grid grid-cols-1 sm:grid-cols-2 gap-4"`;
  - `campos com dependência condicional`: lógica de visibilidade/estado em C# via `@if (campo == valor)`;
  - `seção colapsável`: usar `UIP-STRUCT-COLLAPSIBLE_SECTION` como wrapper do FormGroup.

- `tipo de adaptação`: componente principal implementa
- `o que precisa ser feito`:
  - Usar `FormGroup` com `Legend` por seção lógica dentro de `EditForm`;
  - `Stack` para campos em coluna única; `Container+Slot` para 2 colunas;
  - Validação inline via DataAnnotations + `ValidationMessage` do Blazor em cada campo.

## Como usar

### Seção de formulário básica

```razor
<EditForm Model="@model" OnValidSubmit="Salvar">
    <DataAnnotationsValidator />
    
    <FormGroup Legend="Dados pessoais" HelpText="Informações de identificação do usuário">
        <Stack Gap="Gaps.Medium">
            <FieldText @bind-Value="model.Nome" Label="Nome completo" Required=true />
            <FieldText @bind-Value="model.Email" Type="email" Label="E-mail" Required=true />
            <FieldText @bind-Value="model.Telefone" Label="Telefone" />
        </Stack>
    </FormGroup>

    <FormGroup Legend="Endereço" AdditionalClasses="mt-6">
        <div class="grid grid-cols-1 sm:grid-cols-2 gap-4">
            <FieldText @bind-Value="model.Cep" Label="CEP" Required=true />
            <FieldText @bind-Value="model.Cidade" Label="Cidade" Required=true />
            <FieldText @bind-Value="model.Estado" Label="Estado" />
            <FieldText @bind-Value="model.Logradouro" Label="Logradouro" />
        </div>
    </FormGroup>

    <Bar AdditionalClasses="mt-6">
        <EndContent>
            <Button Style="Themes.Secondary" Outline=true Label="Cancelar" OnClick="Cancelar" />
            <Button Style="Themes.Primary" Label="Salvar" Loading="@salvando" />
        </EndContent>
    </Bar>
</EditForm>
```

### Seção com campos dependentes

```razor
<FormGroup Legend="Configuração de envio">
    <Stack Gap="Gaps.Medium">
        <FieldSelect @bind-Value="model.TipoEnvio" Label="Tipo de envio">
            <option value="email">E-mail</option>
            <option value="sms">SMS</option>
        </FieldSelect>
        @if (model.TipoEnvio == "email")
        {
            <FieldText @bind-Value="model.EmailDestino" Type="email" Label="E-mail de destino" />
        }
        @if (model.TipoEnvio == "sms")
        {
            <FieldText @bind-Value="model.Celular" Label="Celular" />
        }
    </Stack>
</FormGroup>
```

## Decisão de uso

- `nota geral`: 8;
- `limitações`: sem layout 2 colunas nativo — requer grid CSS; campos dependentes por lógica C# manual; sem agrupamento de validação por seção nativo (Blazor valida pelo EditForm completo);
- `recomendação`: `usar por composição`
- `justificativa geral`:
  - `FormGroup` provê semântica, título e help text de seção de formulário nativamente;
  - Combinado com `Stack` ou grid CSS, cobre todas as variantes de layout de grupo de campos;
  - Nota 8 reflete cobertura nativa sólida com apenas limitação de layout 2 colunas não automático.
