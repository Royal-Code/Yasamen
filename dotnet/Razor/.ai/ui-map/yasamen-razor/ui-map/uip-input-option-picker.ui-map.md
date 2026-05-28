# UIP-INPUT-OPTION_PICKER - Option Picker

**GAP parcial — sem FieldSelect nativo; usar InputSelect Blazor ou HTML select**

A biblioteca não tem `FieldSelect`. Para select simples usa-se `<InputSelect>` Blazor (sem estilização da lib) ou HTML `<select>` nativo. Combobox com busca e multi-select estilizado requerem composição manual.

## Componentes

**Principais**: nenhum dedicado para option picker.

**Composição**:

1. Blazor `<InputSelect>` (select em EditForm)
- `cobertura`: select integrado com `EditForm` e `DataAnnotationsValidator`; `@bind-Value` para tipo string/enum; opções via `<option>` HTML filho; sem estilização da biblioteca;
- `limitações`: visual nativo do browser; sem label, information, error estilizados da lib; requer HTML manual de label + validation message;
- `nota`: 5;
- `justificativa`: funcional dentro de EditForm mas sem anatomia de campo estilizado da biblioteca.

2. HTML `<select>` nativo
- `cobertura`: select fora de EditForm via `@bind`; opções via `<option>` e `<optgroup>`; sem integração direta com validação Blazor;
- `nota`: 4;
- `justificativa`: select funcional sem contexto de formulário Blazor.

3. DropButton (como picker de opções)
- `cobertura`: dropdown de opções customizadas; `DropItem` por opção; estado selecionado gerenciado em C#; sem semântica de form field nativo;
- `limitações`: sem label associado; sem `@bind-Value`; sem integração direta com `EditForm`; sem validação inline;
- `nota`: 4;
- `justificativa`: dropdown customizável mas sem anatomia de campo de formulário.

**Descartados**:
- `FieldSelect`: componente não existe na biblioteca.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `select estilizado com label e validation`: `<InputSelect>` Blazor + HTML `<label>` + `<ValidationMessage>` com classes Tailwind manuais;
  - `combobox com busca local (autocomplete)`: composição manual — `TextField` + `@oninput` + lista de sugestões absoluta via CSS;
  - `multi-select estilizado`: `<select multiple>` HTML nativo ou composição com checkboxes em dropdown;
  - `opções com imagem ou detalhe`: `DropButton` + `DropItem` com `ChildContent` customizado.

- `tipo de adaptação`: composição + HTML nativo
- `o que precisa ser feito`:
  - Select em formulário Blazor: `<InputSelect @bind-Value>` dentro de `EditForm` + label/validation manual;
  - Select de opções estáticas fora de EditForm: HTML `<select @bind>`;
  - Para combobox com busca: composição manual — `TextField` + lista de sugestões via `@oninput`.

## Como usar

### Select em formulário Blazor (InputSelect)

```razor
<div class="flex flex-col gap-1 mb-4">
    <label class="text-sm font-medium text-dark-600">Status</label>
    <InputSelect @bind-Value="model.Status"
                 class="w-full border border-light-300 rounded-md px-3 py-2 text-sm bg-white">
        <option value="">Selecione...</option>
        <option value="ativo">Ativo</option>
        <option value="inativo">Inativo</option>
        <option value="pendente">Pendente</option>
    </InputSelect>
    <ValidationMessage For="() => model.Status" class="text-xs text-danger-600" />
</div>
```

### Select com opções dinâmicas

```razor
<div class="flex flex-col gap-1 mb-4">
    <label class="text-sm font-medium text-dark-600">Categoria</label>
    <InputSelect @bind-Value="model.CategoriaId"
                 class="w-full border border-light-300 rounded-md px-3 py-2 text-sm bg-white">
        <option value="0">Selecione uma categoria...</option>
        @foreach (var cat in categorias)
        {
            <option value="@cat.Id">@cat.Nome</option>
        }
    </InputSelect>
    <ValidationMessage For="() => model.CategoriaId" class="text-xs text-danger-600" />
</div>
```

### Select agrupado (HTML nativo)

```razor
<div class="flex flex-col gap-1 mb-4">
    <label class="text-sm font-medium text-dark-600">Região</label>
    <select @bind="model.Regiao"
            class="w-full border border-light-300 rounded-md px-3 py-2 text-sm bg-white">
        <optgroup label="Sul">
            <option value="pr">Paraná</option>
            <option value="sc">Santa Catarina</option>
            <option value="rs">Rio Grande do Sul</option>
        </optgroup>
        <optgroup label="Sudeste">
            <option value="sp">São Paulo</option>
            <option value="rj">Rio de Janeiro</option>
        </optgroup>
    </select>
</div>
```

### Combobox com busca local (composição manual)

```razor
@code {
    private string termoBusca = "";
    private bool mostrarSugestoes = false;
    private List<string> todasOpcoes = ["Opção A", "Opção B", "Opção C", "Opção D"];
    private IEnumerable<string> Sugestoes =>
        todasOpcoes.Where(o => o.Contains(termoBusca, StringComparison.OrdinalIgnoreCase));
}

<div class="relative">
    <TextField @bind-Value="termoBusca" Label="Buscar opção"
               @onfocus="() => mostrarSugestoes = true"
               @oninput="() => mostrarSugestoes = true"
               Placeholder="Digite para buscar..." />
    @if (mostrarSugestoes && Sugestoes.Any())
    {
        <div class="absolute z-10 w-full bg-white border border-light-200 rounded-md shadow-md mt-1 max-h-48 overflow-y-auto">
            @foreach (var opcao in Sugestoes)
            {
                <button class="w-full text-left px-4 py-2 text-sm hover:bg-primary-50"
                        @onclick="() => { termoBusca = opcao; mostrarSugestoes = false; }">
                    @opcao
                </button>
            }
        </div>
    }
</div>
```

## Decisão de uso

- `nota geral`: 2;
- `limitações`: sem `FieldSelect` nativo; `<InputSelect>` Blazor provê binding mas sem estilização da lib; label, information e error requerem HTML manual; combobox e autocomplete requerem composição manual complexa;
- `recomendação`: `usar apenas como apoio`
- `justificativa geral`:
  - `<InputSelect>` Blazor cobre select funcional dentro de EditForm mas sem anatomia estilizada;
  - Para combobox/autocomplete: composição manual com `TextField` + lista;
  - Nota 2 reflete ausência de componente de select estilizado e de combobox/picker customizado nativos.
