# UIP-INPUT-DATE_PICKER - Blueprint

## Identificação
- **Pattern**: UIP-INPUT-DATE_PICKER - Date Picker.
- **Nível final**: completo.
- **Cobertura atual**: 1.
- **Meta de cobertura proposta**: 7.
- **Evidências usadas**: `ui-map.md`, `ui_input.pattern.md`, samples de `TextField`, `FieldText`, `Feedback`, `ButtonGroup`, `Button`, `Icon`, `Modal`, `visual.language.md` e `styles.map.md`.

## Resumo executivo
Yasamen não possui calendário. `TextField` pode capturar texto e `Modal` pode hospedar um calendário proposto, mas seleção de data exige implementação nova. A meta fica em 7 porque o núcleo do date picker não existe.

## Requisitos ainda não atendidos
- Calendário mensal.
- Data selecionada e intervalo.
- Datas desabilitadas.
- Validação de formato.
- Variante mobile.

## Diagnóstico estruturado do gap
`TextField` cobre label, erro e complemento textual. `Modal` pode hospedar seleção em mobile. A grade de calendário, navegação por mês e regras de data são `[API proposta]`.

## Justificativa detalhada da meta
Não é correto prometer 8+ sem calendário nativo. A melhor cobertura plausível é 7: campo + contrato + calendário proposto.

## Estratégia de composição
- `TextField` como entrada visível.
- `FieldText` com texto curto ou `IconFragment` validado no app destino.
- `Modal` ou dropdown proposto para calendário.
- `Feedback`/`Error` para data inválida.
- `ButtonGroup` para mês anterior/próximo.

## Proposta de peças, contratos e responsabilidades
- `[API proposta] DatePicker`: Value, ValueChanged, Min, Max, DisabledDates, Mode.
- `[API proposta] CalendarPanel`: Month, SelectedDate, OnSelect.
- `[API proposta] DateRangePicker`: Start, End.

## Aplicação objetiva da linguagem visual
Dia selecionado usa `Primary`; hoje pode usar borda `primary-500/50`; data inválida usa `Danger`; dias fora do mês usam `text-dark-400`.

## Aplicação de estilos e tokens
Calendário deve usar `bg-white`, `border-light-300`, `rounded-md`, `p-4`, botões pequenos e movimento curto.

## Estrutura sugerida por tecnologia

```razor
@* [API proposta] DatePicker *@
<TextField Label="@Label" Value="@FormattedValue" Error="@Error">
    <Prepend>
        <FieldText>Data</FieldText>
    </Prepend>
    <FooterAction>
        <FieldAction Label="Escolher" Style="Themes.Primary" OnClick="OpenCalendar" />
    </FooterAction>
</TextField>
```

## Blocos principais de código

```razor
@* [API proposta] CalendarPanel *@
<Box AdditionalClasses="p-4 bg-white border border-light-300 rounded-md space-y-4">
    <Bar>
        <Start><strong>@CurrentMonthLabel</strong></Start>
        <End>
            <ButtonGroup Size="Sizes.Small" AriaLabel="Navegação do calendário">
                <Button Label="Anterior" Style="Themes.Light" OnClick="PreviousMonth" />
                <Button Label="Próximo" Style="Themes.Light" OnClick="NextMonth" />
            </ButtonGroup>
        </End>
    </Bar>
    <div class="grid grid-cols-7 gap-2">
        @CalendarDays
    </div>
</Box>
```

## Estados e comportamento responsivo
- Desktop: dropdown/popover proposto.
- Mobile: `Modal` ou sheet proposto.
- Data inválida: `TextField Error`.
- Range incompleto: feedback inline.
- Loading não é estado típico, exceto datas remotas.

## Exemplo principal de uso

```razor
@* [API proposta] *@
<DatePicker Label="Data inicial"
            Value="@startDate"
            ValueChanged="SetStartDate"
            Min="@DateTime.Today" />
```

## Comparação entre cobertura atual e proposta
| Critério | Atual | Proposta |
|---|---|---|
| Campo | `TextField` | mantido |
| Calendário | ausente | proposto |
| Validação | parcial | contrato |
| Mobile | ausente | modal proposto |

## Limitações remanescentes
- Calendário é nova implementação.
- Localização, timezone e máscara dependem do app.
- Ícone de calendário deve ser fornecido via `IconFragment` ou enum validado no pacote de ícones antes de uso final.

## Pontos de adaptação
- Definir formato de data e cultura.
- Definir regras de min/max e datas bloqueadas.
- Escolher entrada textual livre ou somente seleção.
