# UIP-INPUT-DATE_PICKER - Blueprint resumido

## Pattern

UIP-INPUT-DATE_PICKER — Date Picker — ver `uip-input-date-picker.ui-map.md`

## Gap coberto

A lib não tem date picker e `InputType` não suporta `date`. O gap é orientar: `<input type="date">` HTML para data simples, `<InputDate>` Blazor para formulários, `grid 2 colunas` para intervalos, e `ButtonGroup` para presets de período.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `<InputDate @bind-Value>` dentro de `EditForm` + label/validation manual; `<input type="date" @bind>` fora de EditForm; `ButtonGroup(presets)` + dois inputs de data para range.

## Componentes usados

- `ButtonGroup / Button` — papel: principal (presets de período) — ver `button.sample.md`
- `Feedback` — papel: composição (erro de validação de intervalo) — ver `feedback.sample.md`

## Recursos visuais

- `w-full border border-light-300 rounded-md px-3 py-2 text-sm` — estilo manual dos inputs
- `grid grid-cols-2 gap-3` — layout de intervalo De/Até
- `max="@DateTime.Today.ToString("yyyy-MM-dd")"` — restrição de data máxima

## Receita

`<InputDate>` para formulários; `<input type="date">` fora de EditForm; `ButtonGroup` para presets de período.

```razor
@* Data simples em EditForm (InputDate Blazor) *@
<div class="flex flex-col gap-1 mb-4">
    <label class="text-sm font-medium text-dark-600">
        Data de nascimento <span class="text-danger-500">*</span>
    </label>
    <InputDate @bind-Value="model.DataNascimento"
               max="@DateTime.Today.ToString("yyyy-MM-dd")"
               class="w-full border border-light-300 rounded-md px-3 py-2 text-sm
                      focus:outline-none focus:ring-2 focus:ring-primary-400" />
    <ValidationMessage For="() => model.DataNascimento" class="text-xs text-danger-600" />
</div>

@* Data simples fora de EditForm (HTML nativo) *@
<div class="flex flex-col gap-1 mb-4">
    <label class="text-sm font-medium text-dark-600">Data de entrega</label>
    <input type="date" @bind="dataEntrega"
           min="@DateTime.Today.ToString("yyyy-MM-dd")"
           class="w-full border border-light-300 rounded-md px-3 py-2 text-sm" />
</div>

@* Seleção de intervalo com presets *@
@code {
    private DateTime? dataInicio;
    private DateTime? dataFim;

    private void AplicarPreset(int dias)
    {
        dataFim = DateTime.Today;
        dataInicio = dias == 0 ? DateTime.Today : DateTime.Today.AddDays(-dias);
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
        <Button Label="90 dias" Style="Themes.Secondary" Outline=true Size="Sizes.Small"
                OnClick="() => AplicarPreset(90)" />
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
        <Feedback Style="Themes.Danger"
                  Text="A data de início não pode ser maior que a data fim." />
    }
</div>
```

## Limites

- Visual de `<input type="date">` e `<InputDate>` depende do browser/SO — não segue o design system;
- Sem calendário visual customizado — para UX consistente multiplataforma considerar biblioteca externa (Radzen, MudBlazor);
- `InputType` do `TextField` não aceita `date` — não usar `TextField` para campos de data;
- Datas específicas não podem ser desabilitadas via HTML nativo `input[type=date]`.
