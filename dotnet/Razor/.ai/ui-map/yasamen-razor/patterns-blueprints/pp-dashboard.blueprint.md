# PP-DASHBOARD - Blueprint completo

## Pattern

PP-DASHBOARD — Dashboard — ver `pp-dashboard.ui-map.md`

## Gap coberto

A lib cobre KPIs e listas. O gap é documentar: (a) **GAP crítico de gráficos** — Charts requerem biblioteca externa (Chart.js, Radzen, etc.); (b) coordenar múltiplas zonas (filtros, KPIs, gráficos, listas, alertas) em uma página; (c) skeleton de carregamento por zona; (d) alternativas CSS para gráficos simples (barras proporcionais, listas de progresso).

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `Bar(ButtonGroup filtros temporais)` no header; `Container(Columns=4) + Slot + Box` para KPIs; `Container(Columns=2) + Slot + Box` para gráficos (lib externa ou fallback CSS); `Container(Columns=2) + Slot + Box` para listas e alertas; skeleton `animate-pulse` por seção.
- `eixos cobertos sem componente novo`:
  - filtros temporais → `Bar + ButtonGroup(Button Active/Outline)`;
  - KPIs → `Container(Columns=4) + Slot + Box + Badge(variação)`;
  - listas recentes → `Stack + Bar + Badge` dentro de `Box`;
  - alertas → `Stack + Feedback` dentro de `Box`;
  - empty state de seção → `Feedback(Light)`;
  - gráfico fallback → barras CSS `div.h-2.bg-primary-400.rounded-full` com `style="width: X%"`.

## Componentes usados

- `Bar` — papel: principal (header com filtros) — ver `bar.sample.md`
- `Container + Slot` — papel: principal (grades de zonas) — ver `bar.sample.md`
- `Box` — papel: composição (card de KPI, seção de gráfico, lista, alertas) — ver `box.sample.md`
- `Badge` — papel: composição (variação de KPI, tipo de evento, contador de alertas) — ver `badge.sample.md`
- `ButtonGroup + Button` — papel: composição (seletor de período) — ver `button.sample.md`
- `Feedback` — papel: composição (empty state, alertas, error) — ver `feedback.sample.md`
- `Stack` — papel: composição (listas de atividade) — ver `bar.sample.md`

## Recursos visuais

- `animate-pulse bg-light-200 rounded` — skeleton de KPI/gráfico
- `text-2xl font-bold text-dark-700` — valor principal do KPI
- `h-2 bg-primary-400 rounded-full` + `style="width: X%"` — barra proporcional CSS
- `py-2 border-b border-light-100 last:border-0` — linha de item de lista recente

## Receita

### Estrutura base

Dashboard com filtros, KPIs, gráficos (biblioteca externa + fallback) e listas.

```razor
@page "/dashboard"
@inject IJSRuntime JS

@code {
    private string periodo = "30d";
    private DashboardDto? dados;
    private bool carregando = true;
    private string? erro;

    protected override async Task OnInitializedAsync()
        => await Carregar();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender && dados is not null)
            await InicializarGraficos();
    }

    private async Task Carregar()
    {
        carregando = true;
        erro = null;
        try
        {
            dados = await Service.ObterDashboardAsync(periodo);
            await InvokeAsync(StateHasChanged);
            await InicializarGraficos();
        }
        catch (Exception ex) { erro = ex.Message; }
        finally { carregando = false; }
    }

    private async Task InicializarGraficos()
    {
        // Inicializar Chart.js ou biblioteca externa
        if (dados?.EvolucaoMensal is not null)
            await JS.InvokeVoidAsync("charts.renderEvolucao", "chart-evolucao",
                dados.EvolucaoMensal);
    }

    private async Task AlterarPeriodo(string p)
    {
        periodo = p;
        await Carregar();
    }
}

@* Header com filtros *@
<Bar AdditionalClasses="mb-6">
    <StartContent>
        <h1 class="text-lg font-semibold text-dark-700">Dashboard</h1>
    </StartContent>
    <EndContent>
        <ButtonGroup>
            @foreach (var p in new[] { ("7d","7 dias"), ("30d","30 dias"), ("90d","90 dias") })
            {
                <Button Label="@p.Item2" Size="Sizes.Small"
                        Style="@(periodo == p.Item1 ? Themes.Primary : Themes.Default)"
                        OnClick="() => AlterarPeriodo(p.Item1)" />
            }
        </ButtonGroup>
        <Button Style="Themes.Default" Size="Sizes.Small" Label="Atualizar"
                OnClick="Carregar" />
    </EndContent>
</Bar>

@if (erro is not null)
{
    <Feedback Style="Themes.Danger" Text="@erro" AdditionalClasses="mb-4">
        <ChildContent>
            <Button Style="Themes.Danger" Outline="true" Size="Sizes.Small"
                    Label="Tentar novamente" OnClick="Carregar" />
        </ChildContent>
    </Feedback>
}

@* Grade de KPIs *@
<Container Columns="4" AdditionalClasses="mb-6">
    @if (carregando)
    {
        @for (int i = 0; i < 4; i++)
        {
            <Slot>
                <Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
                    <div class="animate-pulse space-y-2">
                        <div class="h-3 bg-light-200 rounded w-1/2"></div>
                        <div class="h-7 bg-light-200 rounded w-3/4"></div>
                        <div class="h-3 bg-light-100 rounded w-1/3"></div>
                    </div>
                </Box>
            </Slot>
        }
    }
    else if (dados?.Kpis is not null)
    {
        @foreach (var kpi in dados.Kpis)
        {
            <Slot>
                <Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
                    <p class="text-xs text-dark-400 mb-1">@kpi.Rotulo</p>
                    <p class="text-2xl font-bold text-dark-700">@kpi.Valor</p>
                    <div class="flex items-center gap-1 mt-1">
                        <Badge Style="@(kpi.Variacao >= 0 ? Themes.Success : Themes.Danger)"
                               Text="@($"{(kpi.Variacao >= 0 ? "+" : "")}{kpi.Variacao:F1}%")" />
                        <span class="text-xs text-dark-400">vs. período anterior</span>
                    </div>
                </Box>
            </Slot>
        }
    }
</Container>

@* Seção de gráficos *@
<Container Columns="2" AdditionalClasses="mb-6">
    <Slot>
        <Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
            <Bar AdditionalClasses="mb-3">
                <StartContent>
                    <p class="text-sm font-semibold text-dark-600">Evolução mensal</p>
                </StartContent>
            </Bar>
            @if (carregando)
            {
                <div class="animate-pulse h-48 bg-light-100 rounded"></div>
            }
            else
            {
                @* Container para biblioteca externa (Chart.js, Radzen, etc.) *@
                <div id="chart-evolucao" class="h-48">
                    @* Fallback CSS quando lib externa não disponível *@
                    @if (dados?.EvolucaoMensal is not null)
                    {
                        <div class="flex items-end gap-1 h-full">
                            @foreach (var ponto in dados.EvolucaoMensal)
                            {
                                <div class="flex-1 flex flex-col items-center gap-1">
                                    <div class="w-full bg-primary-200 rounded-t"
                                         style="height: @(ponto.Percentual)%"></div>
                                    <span class="text-xs text-dark-400">@ponto.Label</span>
                                </div>
                            }
                        </div>
                    }
                </div>
            }
        </Box>
    </Slot>
    <Slot>
        <Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
            <Bar AdditionalClasses="mb-3">
                <StartContent>
                    <p class="text-sm font-semibold text-dark-600">Por categoria</p>
                </StartContent>
            </Bar>
            @if (carregando)
            {
                <Stack Gap="Gaps.Small">
                    @for (int i = 0; i < 4; i++)
                    {
                        <div class="animate-pulse h-8 bg-light-100 rounded"></div>
                    }
                </Stack>
            }
            else if (dados?.PorCategoria is not null)
            {
                <Stack Gap="Gaps.Small">
                    @foreach (var cat in dados.PorCategoria)
                    {
                        <div>
                            <div class="flex justify-between text-xs text-dark-500 mb-0.5">
                                <span>@cat.Label</span>
                                <span class="font-medium">@cat.Percentual%</span>
                            </div>
                            <div class="h-2 bg-light-100 rounded-full">
                                <div class="h-2 bg-primary-400 rounded-full transition-all duration-500"
                                     style="width: @cat.Percentual%"></div>
                            </div>
                        </div>
                    }
                </Stack>
            }
        </Box>
    </Slot>
</Container>

@* Listas e alertas *@
<Container Columns="2">
    <Slot>
        <Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
            <Bar AdditionalClasses="mb-3">
                <StartContent>
                    <p class="text-sm font-semibold text-dark-600">Atividade recente</p>
                </StartContent>
                <EndContent>
                    <a href="/atividade"
                       class="text-xs text-primary-600 hover:underline">Ver tudo</a>
                </EndContent>
            </Bar>
            @if (carregando)
            {
                <Stack Gap="Gaps.None">
                    @for (int i = 0; i < 4; i++)
                    {
                        <div class="py-2 border-b border-light-100">
                            <div class="animate-pulse flex justify-between items-center">
                                <div class="h-3 bg-light-200 rounded w-2/3"></div>
                                <div class="h-4 bg-light-100 rounded w-12"></div>
                            </div>
                        </div>
                    }
                </Stack>
            }
            else if (!dados?.AtividadeRecente?.Any() ?? true)
            {
                <Feedback Style="Themes.Light" Text="Sem atividade no período." />
            }
            else
            {
                <Stack Gap="Gaps.None">
                    @foreach (var evento in dados!.AtividadeRecente.Take(5))
                    {
                        <div class="py-2 border-b border-light-100 last:border-0">
                            <Bar>
                                <StartContent>
                                    <div>
                                        <p class="text-xs font-medium text-dark-600">
                                            @evento.Descricao
                                        </p>
                                        <p class="text-xs text-dark-300">
                                            @evento.DataHora.ToString("dd/MM HH:mm")
                                        </p>
                                    </div>
                                </StartContent>
                                <EndContent>
                                    <Badge Style="@evento.TipoTema" Text="@evento.Tipo" />
                                </EndContent>
                            </Bar>
                        </div>
                    }
                </Stack>
            }
        </Box>
    </Slot>
    <Slot>
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
            @if (carregando)
            {
                <Stack Gap="Gaps.Small">
                    @for (int i = 0; i < 2; i++)
                    {
                        <div class="animate-pulse h-12 bg-light-100 rounded"></div>
                    }
                </Stack>
            }
            else if (!dados?.Alertas?.Any() ?? true)
            {
                <Feedback Style="Themes.Success" Text="Nenhum alerta no momento." />
            }
            else
            {
                <Stack Gap="Gaps.Small">
                    @foreach (var alerta in dados!.Alertas)
                    {
                        <Feedback Style="@alerta.Tema" Text="@alerta.Mensagem" />
                    }
                </Stack>
            }
        </Box>
    </Slot>
</Container>
```

### Cenários de composição

#### KPI com drill-down via OffCanvas

```razor
<Box Border="BorderBuilder.Box" AdditionalClasses="p-4 cursor-pointer hover:shadow-sm"
     @onclick="() => AbrirDrillDown(kpi.Id)">
    <p class="text-xs text-dark-400 mb-1">@kpi.Rotulo</p>
    <p class="text-2xl font-bold text-dark-700">@kpi.Valor</p>
    <div class="flex items-center gap-1 mt-1">
        <Badge Style="Themes.Success" Text="@($"+{kpi.Variacao:F1}%")" />
        <span class="text-xs text-dark-400 underline text-primary-600">Ver detalhes</span>
    </div>
</Box>
```

### Estados de página

- `loading` (por seção): skeleton `animate-pulse` dentro de cada `Box` mantendo a estrutura visual;
- `empty` (por seção): `Feedback(Light)` dentro do `Box` da seção;
- `error` (global): `Feedback(Danger)` no topo com `Button "Tentar novamente"`;
- `sem dados no período`: `Feedback(Light) "Sem dados para o período selecionado."` em cada seção.

## Limites

- **Gráficos são GAP crítico** — Chart.js (via JS interop), Radzen Charts, Syncfusion, ApexCharts ou outros são necessários para gráficos interativos;
- `InicializarGraficos()` no `OnAfterRenderAsync` pode ser chamado antes do DOM estar pronto — usar `await Task.Yield()` ou verificar se `dados is not null`;
- `Container(Columns=4)` colapsa para 1 coluna em mobile — considerar `Columns=2` para KPIs em telas médias;
- Barras CSS proporcionais (`style="width: X%"`) requerem classes inline — não sujeitas a purge do Tailwind;
- Atualização automática (refresh periódico) requer `System.Threading.Timer` ou `IDisposable` + `Task.Delay` loop.

### Responsividade

`Container(Columns=4)` → mobile: 1 col, tablet: 2 col, desktop: 4 col (automático). `Container(Columns=2)` → mobile: 1 col, desktop: 2 col (automático). Gráficos com altura fixa `h-48` se adaptam à largura do container naturalmente.
