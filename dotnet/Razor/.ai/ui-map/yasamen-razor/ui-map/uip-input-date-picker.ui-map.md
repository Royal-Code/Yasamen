# UIP-INPUT-DATE_PICKER - Date Picker

**GAP parcial — sem componente dedicado de calendário**

A biblioteca não tem componente de date picker com calendário visual. Blazor provê `<input type="date">` nativo do browser. Para calendário customizado, requer biblioteca externa (Radzen Calendar, MudDatePicker, etc.).

## Componentes

**Principais**: nenhum dedicado.

**Composição**:

1. FieldText com `Type="date"`
- `cobertura`: campo de data com picker nativo do browser; `Type="date"` para seleção de data; `Type="datetime-local"` para data + hora; `Min`/`Max` para restrição de intervalo; integração com `EditForm` e `DataAnnotationsValidator`;
- `limitações`: visual e UX dependentes do browser/SO (especialmente em mobile); sem calendário customizado; sem presets de período; sem seleção de intervalo visual;
- `nota`: 6;
- `justificativa`: seleção de data funcional via input nativo — sem dependência de lib externa.

2. Bar com dois FieldText `Type="date"` (para intervalo)
- `cobertura`: intervalo de datas via dois campos "De" e "Até" em linha;
- `nota`: 5;
- `justificativa`: intervalo de datas funcional com dois campos nativos — sem calendário range visual.

**Descartados**: nenhum.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `calendário visual customizado`: sem nativo — requer biblioteca externa;
  - `presets de período (Hoje, Esta semana, Último mês)`: compor `ButtonGroup` + `Button` que preenche os campos;
  - `date range picker visual`: sem nativo — dois `FieldText type="date"` ou biblioteca externa;
  - `desabilitar datas específicas (fins de semana, feriados)`: sem suporte nativo em `input[type=date]`.

- `tipo de adaptação`: componente parcial (input nativo) + biblioteca externa para picker visual
- `o que precisa ser feito`:
  - Para data simples: `FieldText Type="date"` com `Min`/`Max`;
  - Para intervalo: dois campos lado a lado com validação de `dataDe <= dataAte`;
  - Para presets: `ButtonGroup` + botões que preenchem os campos de datas.

## Como usar

### Campo de data simples

```razor
<FieldText @bind-Value="model.DataNascimento" Type="date" Label="Data de nascimento"
           Max="@DateTime.Today.ToString("yyyy-MM-dd")" Required=true />
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
        <FieldText @bind-Value="dataInicioStr" Type="date" Label="De" />
        <FieldText @bind-Value="dataFimStr" Type="date" Label="Até" />
    </div>
</div>
```

### Validação de intervalo

```razor
@if (dataInicio.HasValue && dataFim.HasValue && dataInicio > dataFim)
{
    <Feedback Style="Themes.Danger" Text="A data de início não pode ser maior que a data fim." />
}
```

## Decisão de uso

- `nota geral`: 2;
- `limitações`: sem calendário visual customizado; visual nativo do browser em `type="date"` varia por plataforma; sem seleção de range visual; sem desabilitar datas específicas; sem presets integrados;
- `recomendação`: `usar com adaptação`
- `justificativa geral`:
  - `FieldText Type="date"` com input nativo do browser cobre a maioria dos casos de formulário sem necessidade de calendário visual;
  - Para calendário visual rico, requer biblioteca externa;
  - Nota 2 reflete ausência de componente de date picker dedicado — apenas input nativo disponível.
