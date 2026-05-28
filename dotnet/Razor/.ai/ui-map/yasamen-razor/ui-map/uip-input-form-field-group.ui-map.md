# UIP-INPUT-FORM_FIELD_GROUP - Form Field Group

**GAP parcial — sem componente dedicado de seção de formulário**

A biblioteca não tem `FormGroup` ou `Fieldset` component. Seções de formulário são compostas com `Box` + `Stack` + HTML `<fieldset>/<legend>` ou heading manual.

## Componentes

**Principais**: nenhum dedicado.

**Composição**:

1. Stack
- `cobertura`: sequência vertical de campos com espaçamento coerente via `Gap`; principal mecanismo de layout de formulário;
- `nota`: 8;
- `justificativa`: layout vertical de campos com espaçamento consistente — cobre o requisito central de agrupamento linear.

2. Box
- `cobertura`: container visual de seção com borda e padding via `Border="BorderBuilder.Box"`; delimita visualmente um grupo de campos;
- `nota`: 7;
- `justificativa`: delimitação visual de seção — cobre o aspecto de agrupamento visual sem semântica de fieldset.

3. HTML `<fieldset>/<legend>` nativo
- `cobertura`: agrupamento semântico de campos com título; compatível com Blazor e `EditForm`; sem estilização da biblioteca;
- `nota`: 5;
- `justificativa`: semântica correta mas requer CSS manual para estilização coerente com o design system.

**Descartados**:
- `FormGroup`: componente não existe na biblioteca.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `título de seção estilizado`: `<h3>` ou `<p class="text-sm font-semibold text-dark-700">` acima do Stack;
  - `help text de seção`: `<p class="text-xs text-dark-400">` abaixo do título;
  - `borda semântica de fieldset`: Box com `Border="BorderBuilder.Box"` + padding;
  - `layout 2 colunas responsivo`: grid CSS `grid-cols-1 sm:grid-cols-2 gap-4` dentro do Stack ou Box.

- `tipo de adaptação`: composição + HTML nativo
- `o que precisa ser feito`:
  - Título de seção: heading HTML (`<h3>`) acima do Stack;
  - Layout de campos: `Stack Gap="Gaps.Medium"` com os campos internos;
  - Container visual: `Box` com borda para separação visual de seções;
  - Validação: `EditForm` + `DataAnnotationsValidator` cascateiam pelo contexto — não requer container específico.

## Como usar

### Seção básica com título

```razor
<EditForm Model="@model" OnValidSubmit="Salvar">
    <DataAnnotationsValidator />

    <div class="flex flex-col gap-6">
        @* Seção 1: Dados pessoais *@
        <div>
            <p class="text-sm font-semibold text-dark-700 mb-1">Dados pessoais</p>
            <p class="text-xs text-dark-400 mb-4">Informações de identificação do usuário.</p>
            <Stack Gap="Gaps.Medium">
                <TextField @bind-Value="model.Nome" Label="Nome completo" required />
                <TextField @bind-Value="model.Email" Label="E-mail" required />
                <TextField @bind-Value="model.Telefone" Label="Telefone" />
            </Stack>
        </div>

        @* Seção 2: Endereço *@
        <div>
            <p class="text-sm font-semibold text-dark-700 mb-4">Endereço</p>
            <Stack Gap="Gaps.Medium">
                <TextField @bind-Value="model.Cep" Label="CEP" required />
                <TextField @bind-Value="model.Cidade" Label="Cidade" required />
                <TextField @bind-Value="model.Estado" Label="Estado" />
            </Stack>
        </div>
    </div>

    <Bar AdditionalClasses="mt-6">
        <EndContent>
            <Button Style="Themes.Secondary" Outline=true Label="Cancelar" OnClick="Cancelar" />
            <Button Style="Themes.Primary" Label="Salvar" Loading="@salvando" />
        </EndContent>
    </Bar>
</EditForm>
```

### Seção com Box delimitador

```razor
<Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
    <p class="text-sm font-semibold text-dark-700 mb-4">Configurações de notificação</p>
    <Stack Gap="Gaps.Medium">
        <TextField @bind-Value="model.EmailNotificacao" Label="E-mail de notificação" />
        <TextField @bind-Value="model.Webhook" Label="URL de Webhook" />
    </Stack>
</Box>
```

### Layout 2 colunas (grid CSS)

```razor
<div>
    <p class="text-sm font-semibold text-dark-700 mb-4">Endereço</p>
    <div class="grid grid-cols-1 sm:grid-cols-2 gap-4">
        <TextField @bind-Value="model.Cep" Label="CEP" required />
        <TextField @bind-Value="model.Cidade" Label="Cidade" required />
        <TextField @bind-Value="model.Estado" Label="Estado" />
        <TextField @bind-Value="model.Logradouro" Label="Logradouro" />
    </div>
</div>
```

### Seção com campos dependentes

```razor
<div>
    <p class="text-sm font-semibold text-dark-700 mb-4">Configuração de envio</p>
    <Stack Gap="Gaps.Medium">
        @* [inferido] FieldSelect não existe — usar <InputSelect> Blazor ou HTML <select> *@
        <div class="flex flex-col gap-1">
            <label class="text-sm font-medium text-dark-600">Tipo de envio</label>
            <InputSelect @bind-Value="model.TipoEnvio"
                         class="w-full border border-light-300 rounded-md px-3 py-2 text-sm">
                <option value="email">E-mail</option>
                <option value="sms">SMS</option>
            </InputSelect>
        </div>
        @if (model.TipoEnvio == "email")
        {
            <TextField @bind-Value="model.EmailDestino" Label="E-mail de destino" />
        }
        @if (model.TipoEnvio == "sms")
        {
            <TextField @bind-Value="model.Celular" Label="Celular" />
        }
    </Stack>
</div>
```

## Decisão de uso

- `nota geral`: 6;
- `limitações`: sem componente dedicado `FormGroup`; título e help text da seção requerem HTML manual; sem semântica `<fieldset>/<legend>` nativa estilizada; layout 2 colunas requer grid CSS manual;
- `recomendação`: `usar por composição`
- `justificativa geral`:
  - `Stack` cobre o layout de campos; `Box` cobre a delimitação visual de seção;
  - Título e descrição de seção por HTML com classes Tailwind — funcionam mas sem abstração dedicada;
  - Nota 6 reflete composição funcional mas sem componente de agrupamento semântico nativo.
