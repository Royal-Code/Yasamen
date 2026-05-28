# UIP-INPUT-OPTION_PICKER - Option Picker

**GAP parcial — sem combobox ou multi-select nativo**

A biblioteca tem `FieldSelect` para select simples e `DropButton` para dropdown, mas não tem combobox com busca local, multi-select estilizado ou picker com autocomplete.

## Componentes

**Principais**: nenhum dedicado para combobox/autocomplete.

**Composição**:

1. FieldSelect
- `cobertura`: select HTML nativo estilizado; opções via `<option>` e `<optgroup>`; seleção única; integração com `EditForm` e validação; `@bind-Value` para two-way binding; `Disabled`, `Required`;
- `limitações`: sem busca/filtro nativo; sem multi-select estilizado; sem opções carregadas remotamente com debounce; visual de `<select>` nativo do browser em mobile;
- `nota`: 7;
- `justificativa`: select de opções conhecidas com validação Blazor — cobre a maioria dos casos de option picker simples.

**Composição adicional**:

1. DropButton (como picker de opções)
- `cobertura`: dropdown de opções customizadas; `DropItem` por opção; estado selecionado gerenciado em C#; sem semântica de form field nativo;
- `limitações`: sem label associado; sem `@bind-Value`; sem integração direta com `EditForm`; sem validação inline;
- `nota`: 4;
- `justificativa`: dropdown customizável mas sem anatomia de campo de formulário.

**Descartados**: nenhum.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `combobox com busca local (autocomplete)`: sem nativo — implementar com `FieldText` + `@oninput` + lista de sugestões absoluta via CSS;
  - `multi-select estilizado`: sem nativo — `<select multiple>` HTML nativo ou composição com `FieldCheckbox` em dropdown;
  - `opções com imagem ou detalhe`: `DropItem` com `ChildContent` customizado.

- `tipo de adaptação`: componente parcial (FieldSelect) + composição para casos avançados
- `o que precisa ser feito`:
  - Para select simples de opções estáticas: `FieldSelect` com `<option>` internas;
  - Para select de opções dinâmicas: `FieldSelect` com `@foreach` de opções em C#;
  - Para combobox com busca: composição manual — `FieldText` + lista de sugestões via `@oninput`.

## Como usar

### Select simples

```razor
<FieldSelect @bind-Value="model.Status" Label="Status" Required=true>
    <option value="">Selecione...</option>
    <option value="ativo">Ativo</option>
    <option value="inativo">Inativo</option>
    <option value="pendente">Pendente</option>
</FieldSelect>
```

### Select com opções dinâmicas

```razor
<FieldSelect @bind-Value="model.CategoriaId" Label="Categoria" Required=true>
    <option value="0">Selecione uma categoria...</option>
    @foreach (var cat in categorias)
    {
        <option value="@cat.Id">@cat.Nome</option>
    }
</FieldSelect>
```

### Select agrupado

```razor
<FieldSelect @bind-Value="model.Regiao" Label="Região">
    <optgroup label="Sul">
        <option value="pr">Paraná</option>
        <option value="sc">Santa Catarina</option>
        <option value="rs">Rio Grande do Sul</option>
    </optgroup>
    <optgroup label="Sudeste">
        <option value="sp">São Paulo</option>
        <option value="rj">Rio de Janeiro</option>
    </optgroup>
</FieldSelect>
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
    <FieldText @bind-Value="termoBusca" Label="Buscar opção"
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
- `limitações`: sem combobox nativo com busca; sem multi-select estilizado; `FieldSelect` cobre select simples com visual nativo do browser; combobox e autocomplete requerem composição manual complexa;
- `recomendação`: `usar com adaptação`
- `justificativa geral`:
  - `FieldSelect` cobre o caso de uso mais comum (select de domínio controlado) com boa cobertura;
  - Para combobox/autocomplete: composição manual com `FieldText` + lista;
  - Nota 2 reflete a ausência de combobox, multi-select ou picker customizado nativos.
