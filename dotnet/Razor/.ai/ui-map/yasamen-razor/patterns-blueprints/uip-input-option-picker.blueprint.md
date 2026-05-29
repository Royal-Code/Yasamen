# UIP-INPUT-OPTION_PICKER - Blueprint resumido

## Pattern

UIP-INPUT-OPTION_PICKER — Option Picker — ver `uip-input-option-picker.ui-map.md`

## Gap coberto

A lib não tem `FieldSelect`. O gap é orientar três variantes: `<InputSelect>` Blazor para formulários com validação, `<select>` HTML nativo para uso simples, e combobox com busca local via `TextField` + lista de sugestões.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `<InputSelect @bind-Value>` dentro de `EditForm` + label/validation manual com classes Tailwind; combobox manual com `TextField + @oninput + lista absoluta` para busca com filtragem.

## Componentes usados

- `TextField` — papel: composição (trigger de busca no combobox) — ver `field-text.sample.md`

## Recursos visuais

- `w-full border border-light-300 rounded-md px-3 py-2 text-sm bg-white` — estilo manual para select
- `text-xs text-danger-600` — mensagem de erro de validação
- `absolute z-10 w-full bg-white border border-light-200 rounded-md shadow-md mt-1 max-h-48 overflow-y-auto` — lista de sugestões do combobox

## Receita

`<InputSelect>` para formulários; `<select>` para uso simples; `TextField + lista` para combobox com busca.

```razor
@* Select em formulário Blazor (InputSelect com label + validation manual) *@
<div class="flex flex-col gap-1 mb-4">
    <label class="text-sm font-medium text-dark-600">Status <span class="text-danger-500">*</span></label>
    <InputSelect @bind-Value="model.Status"
                 class="w-full border border-light-300 rounded-md px-3 py-2 text-sm bg-white
                        focus:outline-none focus:ring-2 focus:ring-primary-400">
        <option value="">Selecione...</option>
        <option value="ativo">Ativo</option>
        <option value="inativo">Inativo</option>
        <option value="pendente">Pendente</option>
    </InputSelect>
    <ValidationMessage For="() => model.Status" class="text-xs text-danger-600" />
</div>

@* Select com opções dinâmicas *@
<div class="flex flex-col gap-1 mb-4">
    <label class="text-sm font-medium text-dark-600">Categoria</label>
    <InputSelect @bind-Value="model.CategoriaId"
                 class="w-full border border-light-300 rounded-md px-3 py-2 text-sm bg-white">
        <option value="0">Selecione...</option>
        @foreach (var cat in categorias)
        {
            <option value="@cat.Id">@cat.Nome</option>
        }
    </InputSelect>
    <ValidationMessage For="() => model.CategoriaId" class="text-xs text-danger-600" />
</div>

@* Select agrupado (HTML nativo) *@
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

@* Combobox com busca local (TextField + lista absoluta) *@
@code {
    private string termoBusca = "";
    private bool mostrarSugestoes;
    private List<string> todasOpcoes = ["Opção A", "Opção B", "Opção C"];

    private IEnumerable<string> Sugestoes =>
        todasOpcoes.Where(o => o.Contains(termoBusca, StringComparison.OrdinalIgnoreCase));

    private void Selecionar(string opcao)
    {
        termoBusca = opcao;
        mostrarSugestoes = false;
    }
}

<div class="relative">
    <TextField @bind-Value="termoBusca" Label="Buscar opção"
               Placeholder="Digite para buscar..."
               @onfocus="() => mostrarSugestoes = true"
               @oninput="() => mostrarSugestoes = true" />
    @if (mostrarSugestoes && Sugestoes.Any())
    {
        <div class="fixed inset-0 z-10" @onclick="() => mostrarSugestoes = false"></div>
        <div class="absolute z-20 w-full bg-white border border-light-200 rounded-md shadow-md
                    mt-1 max-h-48 overflow-y-auto">
            @foreach (var opcao in Sugestoes)
            {
                <button class="w-full text-left px-4 py-2 text-sm hover:bg-primary-50
                               text-dark-700"
                        @onclick="() => Selecionar(opcao)">
                    @opcao
                </button>
            }
        </div>
    }
</div>
```

## Limites

- `<InputSelect>` e `<select>` têm visual nativo do browser — divergem do estilo do `TextField`;
- `label`, `information` e `error` não são gerenciados pelo select — requerem HTML manual;
- Combobox manual sem navegação por teclado (↑↓ Enter) — adicionar via `@onkeydown` e estado `indiceAtivo` se necessário;
- Para picker com dados remotos (busca assíncrona) adicionar debounce e chamada de API em `@oninput`.
