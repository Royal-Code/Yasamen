# PP-CALENDAR - Blueprint resumido

## Pattern

PP-CALENDAR — Calendar Page — ver `pp-calendar.ui-map.md`

## Gap coberto

**GAP crítico (nota 2):** A lib não tem componente de calendário. A grade de semanas/meses requer biblioteca externa ou implementação HTML customizada. O gap é orientar: (a) alternativa funcional via vista "Agenda" (lista agrupada por dia) com componentes da lib; (b) shell de navegação temporal com `Bar + IconButton` para mês; (c) `Modal` para criar/editar evento; (d) `Badge` de categoria por evento.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: alternativa preferida = vista "Agenda" com `GroupBy(e => e.DataHora.Date)` + `Box(border-l-4)` por evento + marcação de hoje; vista "Grade" requer HTML customizado ou lib externa fora do escopo da lib Yasamen; `ButtonGroup(Agenda/Semana/Mês)` para alternar vista; `Modal` para CRUD de evento.

## Componentes usados

- `Bar` — papel: composição (header de navegação e por dia) — ver `bar.sample.md`
- `Box` — papel: composição (card de evento) — ver `box.sample.md`
- `Stack` — papel: composição (lista de eventos por dia) — ver `bar.sample.md`
- `Badge` — papel: composição (categoria do evento) — ver `badge.sample.md`
- `ButtonGroup + Button` — papel: composição (seletor de vista e ações) — ver `button.sample.md`
- `Modal` — papel: composição (criar/editar evento) — ver `modal.sample.md`
- `Feedback` — papel: composição (estado vazio) — ver `feedback.sample.md`
- `IconButton` — papel: composição (navegar mês, fechar) — ver `button.sample.md`

## Recursos visuais

- `w-8 h-8 rounded-full bg-primary-500 text-white` — marcador "hoje" no cabeçalho do dia
- `border-l-4` + cor da categoria — identificação visual do evento
- `text-xs text-dark-400 tabular-nums` — hora do evento

## Receita

Header com navegação de mês + seletor de vista; vista Agenda = dias agrupados com `Box` por evento; `Modal` para criação.

```razor
@page "/calendario"
@inject ModalService ModalService
@inject EventoService EventoService

@code {
    private DateTime mesAtual = DateTime.Today;
    private List<EventoDto> eventos = [];
    private bool carregando = true;
    private string vista = "agenda"; // "agenda" | "semana" | "mes"
    private EventoDto? eventoEdicao;

    protected override async Task OnInitializedAsync() => await CarregarEventos();

    private async Task CarregarEventos()
    {
        carregando = true;
        var inicio = new DateTime(mesAtual.Year, mesAtual.Month, 1);
        var fim = inicio.AddMonths(1).AddDays(-1);
        eventos = await EventoService.ObterAsync(inicio, fim);
        carregando = false;
    }

    private async Task NavMes(int delta)
    {
        mesAtual = mesAtual.AddMonths(delta);
        await CarregarEventos();
    }

    private IEnumerable<IGrouping<DateTime, EventoDto>> EventosPorDia =>
        eventos.OrderBy(e => e.DataHora)
               .GroupBy(e => e.DataHora.Date);

    private void AbrirNovoEvento()
    {
        eventoEdicao = new EventoDto { DataHora = DateTime.Now };
        ModalService.OpenAsync("evento-form");
    }

    private void AbrirEdicaoEvento(EventoDto ev)
    {
        eventoEdicao = ev with { };
        ModalService.OpenAsync("evento-form");
    }
}

@* Header de navegação *@
<Bar AdditionalClasses="mb-4">
    <StartContent>
        <IconButton Icon="WellKnownIcons.ChevronLeft" Style="Themes.Default"
                    Size="Sizes.Small" OnClick="() => NavMes(-1)" />
        <h1 class="text-base font-semibold text-dark-700 w-36 text-center">
            @mesAtual.ToString("MMMM yyyy")
        </h1>
        <IconButton Icon="WellKnownIcons.ChevronRight" Style="Themes.Default"
                    Size="Sizes.Small" OnClick="() => NavMes(1)" />
        <Button Style="Themes.Default" Size="Sizes.Small" Label="Hoje"
                OnClick='() => { mesAtual = DateTime.Today; _ = CarregarEventos(); }' />
    </StartContent>
    <EndContent>
        <ButtonGroup>
            <Button Style="@(vista == "agenda" ? Themes.Primary : Themes.Default)"
                    Size="Sizes.Small" Label="Agenda"
                    OnClick='() => vista = "agenda"' />
            <Button Style="@(vista == "semana" ? Themes.Primary : Themes.Default)"
                    Size="Sizes.Small" Label="Semana"
                    OnClick='() => vista = "semana"' />
            <Button Style="@(vista == "mes" ? Themes.Primary : Themes.Default)"
                    Size="Sizes.Small" Label="Mês"
                    OnClick='() => vista = "mes"' />
        </ButtonGroup>
        <Button Style="Themes.Primary" Size="Sizes.Small" Label="+ Evento"
                OnClick="AbrirNovoEvento" />
    </EndContent>
</Bar>

@* Conteúdo *@
@if (carregando)
{
    <Stack Gap="Gaps.Medium">
        @for (int i = 0; i < 3; i++)
        {
            <div class="animate-pulse space-y-2">
                <div class="h-3 bg-light-200 rounded w-24"></div>
                <div class="h-14 bg-light-100 rounded"></div>
                <div class="h-14 bg-light-100 rounded"></div>
            </div>
        }
    </Stack>
}
else if (vista == "agenda")
{
    @if (!eventos.Any())
    {
        <Feedback Style="Themes.Light" Text="Nenhum evento neste mês." />
    }
    else
    {
        <Stack Gap="Gaps.Large">
            @foreach (var diaGrupo in EventosPorDia)
            {
                <div>
                    @* Cabeçalho do dia *@
                    <div class="flex items-center gap-2 mb-2">
                        <div class="w-8 h-8 rounded-full flex items-center justify-center text-sm font-bold
                                    @(diaGrupo.Key == DateTime.Today.Date
                                      ? "bg-primary-500 text-white"
                                      : "bg-light-100 text-dark-500")">
                            @diaGrupo.Key.Day
                        </div>
                        <div>
                            <p class="text-xs font-semibold text-dark-600">
                                @diaGrupo.Key.ToString("dddd")
                            </p>
                            <p class="text-xs text-dark-400">
                                @diaGrupo.Key.ToString("dd/MM/yyyy")
                            </p>
                        </div>
                    </div>

                    @* Eventos do dia *@
                    <Stack Gap="Gaps.Small">
                        @foreach (var ev in diaGrupo.OrderBy(e => e.DataHora))
                        {
                            <Box Border="BorderBuilder.Box"
                                 AdditionalClasses="@($"p-3 cursor-pointer hover:shadow-sm border-l-4 {ev.CorBorda}")"
                                 @onclick="() => AbrirEdicaoEvento(ev)">
                                <Bar>
                                    <StartContent>
                                        <div class="flex flex-col gap-0.5">
                                            <span class="text-sm font-medium text-dark-700">
                                                @ev.Titulo
                                            </span>
                                            <span class="text-xs text-dark-400 tabular-nums">
                                                @ev.DataHora.ToString("HH:mm")
                                                @if (ev.DataFim.HasValue)
                                                {
                                                    <span> – @ev.DataFim.Value.ToString("HH:mm")</span>
                                                }
                                            </span>
                                        </div>
                                    </StartContent>
                                    <EndContent>
                                        <Badge Style="@ev.CategoriaTema" Text="@ev.Categoria" />
                                    </EndContent>
                                </Bar>
                            </Box>
                        }
                    </Stack>
                </div>
            }
        </Stack>
    }
}
else
{
    @* Vista Semana / Mês — requer lib externa ou HTML customizado *@
    <Feedback Style="Themes.Warning"
              Text="Vista @vista requer biblioteca de calendário externa. Use a vista Agenda como alternativa." />
}

@* Modal de evento *@
<Modal Id="evento-form"
       Title="@(eventoEdicao?.Id > 0 ? "Editar evento" : "Novo evento")">
    <ChildContent>
        @if (eventoEdicao is not null)
        {
            <EditForm Model="eventoEdicao" OnValidSubmit="SalvarEvento">
                <DataAnnotationsValidator />
                <Stack Gap="Gaps.Medium">
                    <TextField @bind-Value="eventoEdicao.Titulo" Label="Título" required />
                    <div class="grid grid-cols-2 gap-3">
                        <div class="flex flex-col gap-1">
                            <label class="text-sm font-medium text-dark-600">Início</label>
                            <InputDate @bind-Value="eventoEdicao.DataHora"
                                       class="w-full border border-light-300 rounded-md px-3 py-2 text-sm" />
                        </div>
                        <div class="flex flex-col gap-1">
                            <label class="text-sm font-medium text-dark-600">Término</label>
                            <InputDate @bind-Value="eventoEdicao.DataFim"
                                       class="w-full border border-light-300 rounded-md px-3 py-2 text-sm" />
                        </div>
                    </div>
                    <div class="flex flex-col gap-1">
                        <label class="text-sm font-medium text-dark-600">Categoria</label>
                        <InputSelect @bind-Value="eventoEdicao.Categoria"
                                     class="w-full border border-light-300 rounded-md px-3 py-2 text-sm bg-white">
                            @foreach (var cat in categorias)
                            {
                                <option value="@cat.Id">@cat.Nome</option>
                            }
                        </InputSelect>
                    </div>
                </Stack>
                <Bar AdditionalClasses="mt-4">
                    <StartContent>
                        @if (eventoEdicao.Id > 0)
                        {
                            <Button Style="Themes.Danger" Outline="true" Size="Sizes.Small"
                                    Label="Excluir" OnClick="() => ExcluirEvento(eventoEdicao.Id)" />
                        }
                    </StartContent>
                    <EndContent>
                        <Button Style="Themes.Default" Label="Cancelar"
                                OnClick='() => ModalService.CloseAsync("evento-form")' />
                        <Button Style="Themes.Primary" Label="Salvar" Type="submit" />
                    </EndContent>
                </Bar>
            </EditForm>
        }
    </ChildContent>
</Modal>
```

## Limites

- **Vista grade (semana/mês) não coberta** — requer lib externa (FullCalendar, Radzen Scheduler, etc.) ou implementação HTML customizada complexa;
- Vista Agenda cobre os casos mais comuns de leitura e é a alternativa funcional recomendada com a lib;
- `InputDate` renderiza `<input type="date">` nativo — aparência varia por navegador e não recebe estilo da lib;
- Arrastar eventos (drag & drop) requer JS interop + lib externa;
- `border-l-4 {ev.CorBorda}` assume que a classe Tailwind já está no safelist ou é gerada dinamicamente — considerar classes concretas em vez de dinâmicas para evitar purge.
