# SHP-DASHBOARD_ANALYTICS - Blueprint completo

## Pattern

SHP-DASHBOARD_ANALYTICS — Dashboard/Analytics — ver `shp-dashboard-analytics.ui-map.md`

## Gap coberto

A lib cobre o shell e os KPIs. O gap é coordenar: `AppLayout + AppSideBar` com `NavLink` de áreas analíticas e `Badge` de alertas ativos; filtros globais de período no header via `ButtonGroup`; **GAP crítico de gráficos** (biblioteca externa obrigatória); drill-down via `OffCanvas`; alertas via `Feedback` e `NotificationService`.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `AnalyticsLayout.razor` com `AppLayout + AppSideBar(NavLink + Badge alertas)` + header com `Bar(ButtonGroup período + IconButton refresh)` + `main.flex-1.overflow-auto.p-6`; páginas filhas usam `Container+Slot+Box` para KPIs e `Box` para seções de gráfico (lib externa) + listas; `OffCanvas` para drill-down; `NotificationService` para alertas críticos.
- `eixos cobertos sem componente novo`:
  - shell → `AppLayout + AppSideBar(NavLink + Badge)`;
  - filtros globais → `Bar + ButtonGroup(Button Active/Outline)`;
  - KPIs → `Container+Slot+Box + Badge(variação)`;
  - gráficos → `Box` como container para lib externa (Chart.js, Radzen, etc.);
  - alertas → `Feedback(Danger/Warning) + NotificationService(toast)`;
  - drill-down → `OffCanvas` ao clicar em KPI.

## Componentes usados

- `AppLayout` — papel: principal (estrutura do shell analítico) — ver `app-layout.sample.md`
- `AppSideBar` — papel: principal (navegação de áreas analíticas) — ver `app-side-bar.sample.md`
- `Bar` — papel: composição (header com filtros globais) — ver `bar.sample.md`
- `ButtonGroup + Button` — papel: composição (seletor de período) — ver `button.sample.md`
- `Container + Slot` — papel: composição (grade de KPIs) — ver `container.sample.md`
- `Box` — papel: composição (KPI, seção de gráfico, lista) — ver `box.sample.md`
- `Badge` — papel: composição (variação KPI, alertas na nav) — ver `badge.sample.md`
- `OffCanvas` — papel: composição (drill-down de métrica) — ver `modal.sample.md`
- `Feedback` — papel: composição (alertas, empty state) — ver `feedback.sample.md`
- `Stack` — papel: composição (lista de atividade recente) — ver `stack.sample.md`

## Recursos visuais

- `flex items-center gap-2 px-3 py-2 text-sm rounded-md` — item de nav da sidebar
- `ActiveClass="bg-primary-50 text-primary-700 font-medium"` — item ativo
- `absolute right-3 top-1/2 -translate-y-1/2` — badge de alertas flutuante no item de nav
- `text-2xl font-bold text-dark-700` — valor do KPI
- `h-48` — altura padrão para container de gráfico

## Receita

### Estrutura base

`AnalyticsLayout.razor` com sidebar de navegação, header de filtros globais e área de conteúdo.

```razor
@* AnalyticsLayout.razor — shell de Dashboard/Analytics *@
@inherits LayoutComponentBase
@inject NotificationService NotificationService

@code {
    private readonly OffCanvasHandler drillDownHandler = new();
    private string periodoGlobal = "30d";
    private int alertasAtivos;
    private bool carregandoRefresh;

    [CascadingParameter] private string? CurrentPageTitle { get; set; }

    protected override async Task OnInitializedAsync()
        => alertasAtivos = await AlertaService.ContarAtivosAsync();

    private async Task RefreshAll()
    {
        carregandoRefresh = true;
        await InvokeAsync(StateHasChanged);
        // Notifica páginas filhas via serviço ou EventCallback
        await Task.Delay(100);
        carregandoRefresh = false;
    }
}

<CascadingValue Value="drillDownHandler" Name="DrillDownHandler">
<AppLayout>
    <AppSideBar>
        <div class="px-4 py-3 border-b border-light-200 flex-shrink-0">
            <span class="font-bold text-dark-700 text-sm">Analytics</span>
        </div>

        <nav class="flex-1 overflow-y-auto p-2">
            <Stack Gap="Gaps.None">
                @foreach (var item in navItems)
                {
                    <div class="relative">
                        <NavLink href="@item.Href"
                                 class="flex items-center gap-2 px-3 py-2 text-sm rounded-md
                                        text-dark-500 hover:bg-light-50 transition-colors"
                                 ActiveClass="bg-primary-50 text-primary-700 font-medium">
                            @item.Label
                        </NavLink>
                        @if (item.Id == "alertas" && alertasAtivos > 0)
                        {
                            <span class="absolute right-3 top-1/2 -translate-y-1/2">
                                <Badge Style="Themes.Danger"
                                       Text="@alertasAtivos.ToString()" />
                            </span>
                        }
                    </div>
                }
            </Stack>
        </nav>
    </AppSideBar>

    @* Área principal com header de filtros *@
    <div class="flex flex-col flex-1 overflow-hidden">
        <Bar AdditionalClasses="px-6 py-3 border-b border-light-200 bg-white flex-shrink-0">
            <StartContent>
                <h1 class="text-base font-semibold text-dark-700">
                    @(CurrentPageTitle ?? "Dashboard")
                </h1>
            </StartContent>
            <EndContent>
                <ButtonGroup>
                    @foreach (var p in new[] { ("7d","7d"), ("30d","30d"), ("90d","90d"), ("1y","1 ano") })
                    {
                        <Button Label="@p.Item2" Size="Sizes.Small"
                                Style="@(periodoGlobal == p.Item1 ? Themes.Primary : Themes.Default)"
                                OnClick="async () => { periodoGlobal = p.Item1; await RefreshAll(); }" />
                    }
                </ButtonGroup>
                <IconButton Icon="WellKnownIcons.Refresh" Style="Themes.Default"
                            Loading="@carregandoRefresh"
                            Title="Atualizar"
                            OnClick="RefreshAll" />
            </EndContent>
        </Bar>

        <main class="flex-1 overflow-auto p-6">
            @Body
        </main>
    </div>
</AppLayout>

@* OffCanvas de drill-down *@
<OffCanvas Handler="@drillDownHandler" Id="drill-down" Title="Detalhe">
    <ChildContent>
        @* Conteúdo injetado via serviço ou componente filho *@
    </ChildContent>
</OffCanvas>
</CascadingValue>
```

### Cenários de composição

#### Página de visão geral com KPIs + gráfico + alertas

```razor
@page "/analytics/overview"
@layout AnalyticsLayout

<Stack Gap="Gaps.Large">
    @* KPIs *@
    <Container Columns="4">
        @foreach (var kpi in dados?.Kpis ?? [])
        {
            <Slot>
                <Box Border="BorderBuilder.Box"
                     AdditionalClasses="p-4 cursor-pointer hover:shadow-sm"
                     @onclick="() => AbrirDrillDown(kpi)">
                    <p class="text-xs text-dark-400 mb-1">@kpi.Rotulo</p>
                    <p class="text-2xl font-bold text-dark-700">@kpi.Valor</p>
                    <div class="flex items-center gap-1 mt-1">
                        <Badge Style="@(kpi.Variacao >= 0 ? Themes.Success : Themes.Danger)"
                               Text="@($"{(kpi.Variacao >= 0 ? "+" : "")}{kpi.Variacao:F1}%")" />
                        <span class="text-xs text-dark-400">vs. anterior</span>
                    </div>
                </Box>
            </Slot>
        }
    </Container>

    @* Seção de gráfico (container para lib externa) *@
    <Container Columns="2">
        <Slot>
            <Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
                <Bar AdditionalClasses="mb-3">
                    <StartContent>
                        <p class="text-sm font-semibold text-dark-600">Evolução</p>
                    </StartContent>
                </Bar>
                @* Biblioteca externa: Chart.js, Radzen, ApexCharts *@
                <div id="chart-main" class="h-48">
                    @* Fallback CSS — barras proporcionais *@
                </div>
            </Box>
        </Slot>
        <Slot>
            @* Alertas ativos *@
            <Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
                <Bar AdditionalClasses="mb-3">
                    <StartContent>
                        <p class="text-sm font-semibold text-dark-600">Alertas</p>
                    </StartContent>
                    <EndContent>
                        @if (dados?.Alertas?.Any() == true)
                        {
                            <Badge Style="Themes.Danger"
                                   Text="@dados.Alertas.Count.ToString()" />
                        }
                    </EndContent>
                </Bar>
                @if (!dados?.Alertas?.Any() ?? true)
                {
                    <Feedback Style="Themes.Success" Text="Nenhum alerta ativo." />
                }
                else
                {
                    <Stack Gap="Gaps.Small">
                        @foreach (var a in dados!.Alertas.Take(3))
                        {
                            <Feedback Style="@a.Tema" Text="@a.Mensagem">
                                <ChildContent>
                                    <Button Style="Themes.Default" Outline="true"
                                            Size="Sizes.Small" Label="Reconhecer"
                                            OnClick="() => ReconhecerAlerta(a.Id)" />
                                </ChildContent>
                            </Feedback>
                        }
                    </Stack>
                }
            </Box>
        </Slot>
    </Container>
</Stack>
```

#### Drill-down ao clicar em KPI

```razor
@code {
    [CascadingParameter(Name = "DrillDownHandler")]
    private OffCanvasHandler? DrillDownHandler { get; set; }

    private async Task AbrirDrillDown(KpiDto kpi)
    {
        // Carregar dados detalhados do KPI
        drillDownData = await AnalyticsService.ObterDetalheKpiAsync(kpi.Id, periodoGlobal);
        if (DrillDownHandler is not null)
            await DrillDownHandler.Show();
    }
}
```

### Estados de página

- `loading` (KPIs): 4 boxes `animate-pulse` com placeholder de número;
- `loading` (gráfico): `div.animate-pulse.h-48.bg-light-100.rounded`;
- `error` (global): `Feedback(Danger)` no topo com `Button "Tentar novamente"`;
- `alertas críticos`: `NotificationService.ShowAsync(Style=Danger Title=alerta.Mensagem)`.

## Limites

- **Gráficos são GAP crítico** — toda visualização analítica requer biblioteca externa: Chart.js (via JS interop), Radzen Charts, Blazorise Charts, ApexCharts, Syncfusion, etc.;
- `periodoGlobal` no layout precisa ser propagado para páginas filhas — usar `CascadingValue` ou serviço singleton `AnalyticsFilterService`;
- `AppSideBar` com `NavLink` não tem sub-navegação hierárquica nativa;
- Sem grid de painéis redimensionáveis — `Container+Slot` é grade fixa;
- Alertas em tempo real requerem SignalR ou polling — fora do scope da lib.

### Responsividade

`AppLayout + AppSideBar`: sidebar colapsa nativamente em mobile. `ButtonGroup` de período: considerar `hidden sm:flex` em mobile muito estreito, substituindo por `InputSelect`.
