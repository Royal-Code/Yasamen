# UIP-INPUT-DATE_PICKER - Date Picker

**GAP parcial — sem componente dedicado; usar HTML `<input type="date">` ou Blazor `<InputDate>`**

A biblioteca não tem componente de date picker nem suporta `type="date"` via `InputType` (que só tem `Text` e `Password`). Para seleção de data: HTML `<input type="date">` nativo ou Blazor `<InputDate>` dentro de `EditForm`. Para calendário visual customizado, requer biblioteca externa.

## Componentes

**Principais**: nenhum dedicado.

**Composição**:

1. HTML `<input type="date">` nativo
- `cobertura`: seleção de data com picker nativo do browser; `min`/`max` para restrição de intervalo; `@bind` para binding fora de EditForm;
- `limitações`: visual e UX dependentes do browser/SO; sem calendário customizado; sem presets; sem range visual;
- `nota`: 5;
- `justificativa`: seleção de data funcional — sem dependência de lib externa ou componente da lib.

2. Blazor `<InputDate<T>>` (em EditForm)
- `cobertura`: campo de data integrado com `EditForm` e `DataAnnotationsValidator`; `@bind-Value` para `DateTime`, `DateOnly`, `DateTimeOffset`; sem estilização da biblioteca;
- `nota`: 5;
- `justificativa`: data com validação Blazor nativa — sem estilo da lib.

3. ButtonGroup + Button (presets de período)
- `cobertura`: presets "Hoje", "7 dias", "30 dias" que preenchem os campos de data;
- `nota`: 8;
- `justificativa`: presets de período — cobertura nativa com ButtonGroup.

**Descartados**:
- `FieldText com Type="date"`: InputType enum só suporta Text e Password — não suporta date.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `calendário visual customizado`: sem nativo — requer biblioteca externa (Radzen, MudBlazor, etc.);
  - `date range picker visual`: sem nativo — dois `<InputDate>` ou biblioteca externa;
  - `desabilitar datas específicas`: sem suporte nativo em `input[type=date]`.

- `tipo de adaptação`: composição + HTML nativo
- `o que precisa ser feito`:
  - Para data simples fora de EditForm: `<input type="date" @bind="dataVar" class="..." />`;
  - Para data em EditForm: `<InputDate @bind-Value="model.Data" class="..." />` + label/validation manual;
  - Para intervalo: dois campos lado a lado com validação de `dataDe <= dataAte`;
  - Para presets: `ButtonGroup` + botões que atualizam as datas.

## Como usar

### Campo de data simples (HTML nativo fora de EditForm)

```razor
<div class="flex flex-col gap-1 mb-4">
    <label class="text-sm font-medium text-dark-600">Data de nascimento</label>
    <input type="date" @bind="model.DataNascimento"
           max="@DateTime.Today.ToString("yyyy-MM-dd")"
           class="w-full border border-light-300 rounded-md px-3 py-2 text-sm" />
</div>
```

### Campo de data em EditForm (InputDate Blazor)

```razor
<div class="flex flex-col gap-1 mb-4">
    <label class="text-sm font-medium text-dark-600">Data de nascimento</label>
    <InputDate @bind-Value="model.DataNascimento"
               class="w-full border border-light-300 rounded-md px-3 py-2 text-sm" />
    <ValidationMessage For="() => model.DataNascimento" class="text-xs text-danger-600" />
</div>
```

### Seleção de intervalo com presets

```razor
@code {
    private DateTime? dataInicio;
    private DateTime? dataFim;

    private void AplicarPreset(int dias)
    {
        dataFim = DateTime.Today;
        dataInicio = DateTime.Today.AddDays(-dias);
    }
}

<div class="flex flex-col gap-3 mb-4">
    <label class="text-sm font-medium text-dark-600">Período</label>
    <ButtonGroup>
        <Button Label="Hoje" Style="Themes.Secondary" Outline=true Size="Sizes.Small"
                OnClick="() => AplicarPreset(0)" />
        <Button Label="7 dias" Style="Themes.Secondary" Outline=true Size="Sizes.Small"
                OnClick="() => AplicarPreset(7)" />
        <Button Label="30 dias" Style="Themes.Secondary" Outline=true Size="Sizes.Small"
                OnClick="() => AplicarPreset(30)" />
    </ButtonGroup>
    <div class="grid grid-cols-2 gap-3">
        <div class="flex flex-col gap-1">
            <label class="text-xs text-dark-500">De</label>
            <input type="date" @bind="dataInicio"
                   class="w-full border border-light-300 rounded-md px-3 py-2 text-sm" />
        </div>
        <div class="flex flex-col gap-1">
            <label class="text-xs text-dark-500">Até</label>
            <input type="date" @bind="dataFim"
                   class="w-full border border-light-300 rounded-md px-3 py-2 text-sm" />
        </div>
    </div>
    @if (dataInicio.HasValue && dataFim.HasValue && dataInicio > dataFim)
    {
        <Feedback Style="Themes.Danger" Text="A data de início não pode ser maior que a data fim." />
    }
</div>
```

## Decisão de uso

- `nota geral`: 2;
- `limitações`: sem calendário visual customizado; `InputType` não suporta `date`; visual nativo do browser varia por plataforma; sem range visual; sem desabilitar datas específicas; sem presets integrados;
- `recomendação`: `usar apenas como apoio`
- `justificativa geral`:
  - HTML `<input type="date">` ou Blazor `<InputDate>` cobrem data funcional sem componente da lib;
  - `ButtonGroup` cobre presets de período com boa qualidade;
  - Nota 2 reflete ausência de componente de date picker dedicado — apenas input nativo e ButtonGroup disponíveis.
