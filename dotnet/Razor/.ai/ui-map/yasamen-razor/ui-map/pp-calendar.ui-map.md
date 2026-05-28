# PP-CALENDAR - Calendar

**GAP crítico — UIP-SURFACE-CALENDAR é GAP (nota 0)**

A biblioteca não tem componente de calendário. PP-CALENDAR depende de `UIP-SURFACE-CALENDAR` como superfície temporal, que é GAP completo. A implementação requer biblioteca externa (FullCalendar, Telerik Scheduler, MudBlazor DatePicker, Radzen Scheduler, etc.) ou implementação manual de grade mensal/semanal.

## Componentes por zona funcional

### Zona: Superfície (calendário) — GAP

1. (UIP-SURFACE-CALENDAR — nota 0)
- `cobertura`: sem cobertura nativa; grade mensal/semanal/diária requer biblioteca externa;
- `nota`: 0;
- `justificativa`: GAP crítico — toda a grade de calendário é responsabilidade de biblioteca externa.

2. HTML `<table>` manual (substituto parcial para grade mensal)
- `cobertura`: grade mensal básica de 7 colunas × 5 semanas via `<table>`; eventos como badges nas células;
- `nota`: 2;
- `justificativa`: calendário manual funcional mas com implementação substancial requerida.

### Zona: Controles temporais

1. Bar + IconButton (navegação de mês/semana)
- `cobertura`: "◀ Anterior" / "Hoje" / "Próximo ▶"; display do mês/ano atual;
- `nota`: 8;
- `justificativa`: controles de navegação temporal — direto.

2. ButtonGroup (seletor de vista)
- `cobertura`: toggle "Mês / Semana / Dia / Agenda";
- `nota`: 7;
- `justificativa`: seleção de granularidade temporal.

3. FieldText Type="date" (date picker — UIP-INPUT-DATE_PICKER)
- `cobertura`: seleção de data de início de período;
- `nota`: 4;
- `justificativa`: input de data para navegação — browser nativo sem grade visual.

### Zona: Detalhe do evento

1. Modal ou OffCanvas (detalhe/edição de evento)
- `cobertura`: detalhe completo do evento; formulário de criação/edição;
- `nota`: 9;
- `justificativa`: detalhe e edição de evento — excelente cobertura.

2. Box + Bar (mini-detalhe em popover)
- `cobertura`: preview rápido do evento ao clicar na célula;
- `nota`: 5;
- `justificativa`: popover manual de detalhe rápido.

### Zona: Estados

1. Badge (categoria/tipo de evento)
- `cobertura`: cor por tipo de evento na grade;
- `nota`: 8;
- `justificativa`: classificação visual de eventos.

2. Feedback + animate-pulse (loading)
- `cobertura`: estado de loading dos eventos;
- `nota`: 7;
- `justificativa`: loading do calendário.

**Descartados**: nenhum.

## Composição alternativa: vista "Agenda" (lista temporal)

```razor
@* Vista de agenda como lista ordenada por data — alternativa sem calendário *@
@page "/agenda"
@code {
    private DateTime mesAtual = DateTime.Today;
    private List<EventoDto> eventos = [];
    private bool carregando = true;

    protected override async Task OnInitializedAsync() => await Carregar();

    private async Task Carregar()
    {
        carregando = true;
        eventos = await Service.ObterEventosDoMesAsync(mesAtual);
        carregando = false;
    }

    private IEnumerable<IGrouping<DateTime, EventoDto>> EventosPorDia =>
        eventos.GroupBy(e => e.Inicio.Date).OrderBy(g => g.Key);
}

@* Controles de navegação *@
<Bar AdditionalClasses="mb-4">
    <StartContent>
        <IconButton Icon="WellKnownIcons.ChevronLeft" Style="Themes.Default"
                   OnClick='async () => { mesAtual = mesAtual.AddMonths(-1); await Carregar(); }' />
        <span class="text-base font-semibold text-dark-700 w-36 text-center">
            @mesAtual.ToString("MMMM yyyy")
        </span>
        <IconButton Icon="WellKnownIcons.ChevronRight" Style="Themes.Default"
                   OnClick='async () => { mesAtual = mesAtual.AddMonths(1); await Carregar(); }' />
    </StartContent>
    <EndContent>
        <Button Style="Themes.Default" Size="Sizes.Small" Label="Hoje"
                OnClick='async () => { mesAtual = DateTime.Today; await Carregar(); }' />
        <Button Style="Themes.Primary" Size="Sizes.Small" Label="Novo evento"
                OnClick='() => ModalService.Open<NovoEventoModal>()' />
    </EndContent>
</Bar>

@if (carregando)
{
    <Stack Gap="Gaps.Medium">
        @for (int i = 0; i < 5; i++)
        {
            <div class="animate-pulse">
                <div class="h-3 bg-light-200 rounded w-24 mb-2"></div>
                <div class="h-12 bg-light-100 rounded"></div>
            </div>
        }
    </Stack>
}
else if (!eventos.Any())
{
    <Feedback Style="Themes.Light" Text="Nenhum evento neste mês." />
}
else
{
    <Stack Gap="Gaps.Medium">
        @foreach (var diaGrupo in EventosPorDia)
        {
            <div>
                @* Separador de dia *@
                <div class="flex items-center gap-3 mb-2">
                    <div class="@(diaGrupo.Key == DateTime.Today.Date
                                  ? "w-8 h-8 rounded-full bg-primary-500 text-white"
                                  : "w-8 h-8 text-dark-600")
                                 flex items-center justify-center text-sm font-bold">
                        @diaGrupo.Key.Day
                    </div>
                    <div>
                        <p class="text-xs font-semibold text-dark-600">
                            @diaGrupo.Key.ToString("dddd")
                        </p>
                        <p class="text-xs text-dark-400">
                            @diaGrupo.Key.ToString("dd 'de' MMMM")
                        </p>
                    </div>
                </div>

                @* Eventos do dia *@
                <Stack Gap="Gaps.Small" AdditionalClasses="ml-11">
                    @foreach (var evento in diaGrupo.OrderBy(e => e.Inicio))
                    {
                        <Box Border="BorderBuilder.Box"
                             AdditionalClasses="p-3 cursor-pointer hover:shadow-sm transition-shadow
                                               border-l-4 @evento.CorBorda"
                             @onclick='() => ModalService.Open<DetalhEventoModal>(
                                 p => p.Add(x => x.Evento, evento))'>
                            <Bar>
                                <StartContent>
                                    <div>
                                        <p class="text-sm font-medium text-dark-600">@evento.Titulo</p>
                                        <p class="text-xs text-dark-400">
                                            @evento.Inicio.ToString("HH:mm") –
                                            @evento.Fim.ToString("HH:mm")
                                            @if (!string.IsNullOrEmpty(evento.Local))
                                            {
                                                @(" · ")@evento.Local
                                            }
                                        </p>
                                    </div>
                                </StartContent>
                                <EndContent>
                                    <Badge Style="@evento.CategoriaTema" Text="@evento.Categoria" />
                                    <DropIconButton Icon="WellKnownIcons.MoreVertical"
                                                   Style="Themes.Default" Size="Sizes.Small">
                                        <DropItem Label="Editar"
                                                  OnClick='() => ModalService.Open<EditarEventoModal>(
                                                      p => p.Add(x => x.Evento, evento))' />
                                        <DropItem Label="Excluir" Style="Themes.Danger"
                                                  OnClick="() => Excluir(evento.Id)" />
                                    </DropIconButton>
                                </EndContent>
                            </Bar>
                        </Box>
                    }
                </Stack>
            </div>
        }
    </Stack>
}
```

## Decisão de uso

- `nota geral`: 2;
- `limitações`: sem componente de calendário nativo — GAP crítico; grade mensal/semanal requer biblioteca externa ou implementação manual substancial; drag/drop de eventos não disponível;
- `recomendação`: `usar apenas como apoio`
- `justificativa geral`:
  - Vista "Agenda" (lista temporal) é a alternativa mais prática sem calendário nativo — `Bar` + `Box` + `Badge` + `Modal` cobrem funcionalidade base;
  - Para grade visual de calendário: FullCalendar (via JS interop) ou Radzen Scheduler (Blazor nativo) são as opções mais práticas;
  - Nota 2 reflete que PP-CALENDAR requer investimento substancial em componente externo para a zona de superfície temporal.
