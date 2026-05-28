# PP-DASHBOARD - Dashboard

## Componentes por zona funcional

### Zona: Filtros

1. Bar + FieldSelect (filtro temporal)
- `cobertura`: "Hoje / 7 dias / 30 dias / Período personalizado" como select ou ButtonGroup;
- `nota`: 8;
- `justificativa`: filtros temporais inline no header do dashboard.

### Zona: Métricas (KPIs)

1. Container+Slot + Box (UIP-CONTENT-METRIC_CARD)
- `cobertura`: grade de 2-4 colunas de metric cards; valor, rótulo, variação com Badge; skeleton;
- `nota`: 8;
- `justificativa`: grade de KPIs — cobertura direta com Container+Slot.

### Zona: Gráficos

1. (UIP-SURFACE-CHART — GAP, nota 0)
- `cobertura`: sem componente de gráfico nativo; requer Chart.js via JS interop ou biblioteca externa;
- `nota`: 0;
- `justificativa`: GAP crítico no dashboard — gráficos requerem biblioteca externa.
- `alternativa`: tabelas HTML, mini sparklines CSS ou barras proporcionais em Tailwind como substitutos visuais básicos.

### Zona: Detalhe / Listas recentes

1. Stack + Box/Bar (UIP-DATA-LIST_ITEM)
- `cobertura`: "Últimas transações", "Alertas recentes", "Top itens" como listas dentro de cards;
- `nota`: 8;
- `justificativa`: listas de resumo dentro de cards de dashboard.

2. HTML `<table>` + Tailwind (UIP-DATA-DATA_TABLE)
- `cobertura`: tabela de dados recentes dentro de seção do dashboard;
- `nota`: 6;
- `justificativa`: tabela compacta de dados históricos.

### Zona: Estados

1. Feedback + animate-pulse (UIP-FEEDBACK-LOADING_STATE)
- `cobertura`: skeleton de métricas e listas durante carregamento inicial;
- `nota`: 7;
- `justificativa`: estado de loading do dashboard.

2. Feedback Style=Light (UIP-FEEDBACK-EMPTY_STATE)
- `cobertura`: "Sem dados no período selecionado";
- `nota`: 9;
- `justificativa`: estado vazio de seção do dashboard.

**Descartados**: nenhum (gráficos: GAP documentado).

## Composição completa da página

```razor
@page "/dashboard"
@code {
    private string periodo = "30d";
    private DashboardDto? dados;
    private bool carregando = true;

    protected override async Task OnInitializedAsync() => await Carregar();

    private async Task Carregar()
    {
        carregando = true;
        dados = await Service.ObterDashboardAsync(periodo);
        carregando = false;
    }
}

@* Header com filtros *@
<Bar AdditionalClasses="mb-6">
    <StartContent>
        <h1 class="text-lg font-semibold text-dark-700">Dashboard</h1>
    </StartContent>
    <EndContent>
        <FieldSelect Value="@periodo"
                     ValueChanged="async v => { periodo = v; await Carregar(); }"
                     Options='new[] { ("7d","7 dias"), ("30d","30 dias"), ("90d","90 dias") }' />
        <Button Style="Themes.Default" Size="Sizes.Small" Label="Atualizar"
                OnClick="Carregar" />
    </EndContent>
</Bar>

@* Grade de KPIs *@
@if (carregando)
{
    <Container Columns="4" AdditionalClasses="mb-6">
        @for (int i = 0; i < 4; i++)
        {
            <Slot>
                <Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
                    <div class="space-y-2 animate-pulse">
                        <div class="h-3 bg-light-200 rounded w-1/2"></div>
                        <div class="h-7 bg-light-200 rounded w-3/4"></div>
                        <div class="h-3 bg-light-100 rounded w-1/3"></div>
                    </div>
                </Box>
            </Slot>
        }
    </Container>
}
else if (dados is not null)
{
    <Container Columns="4" AdditionalClasses="mb-6">
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
    </Container>

    @* Seção de gráficos (GAP — placeholder ou biblioteca externa) *@
    <Container Columns="2" AdditionalClasses="mb-6">
        <Slot>
            <Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
                <Bar AdditionalClasses="mb-3">
                    <StartContent>
                        <p class="text-sm font-semibold text-dark-600">Evolução mensal</p>
                    </StartContent>
                </Bar>
                @* Gráfico via Chart.js ou biblioteca externa *@
                <div id="chart-evolucao" class="h-48">
                    @* Fallback: barras proporcionais CSS *@
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
                </div>
            </Box>
        </Slot>
        <Slot>
            <Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
                <Bar AdditionalClasses="mb-3">
                    <StartContent>
                        <p class="text-sm font-semibold text-dark-600">Por categoria</p>
                    </StartContent>
                </Bar>
                @* Distribuição como lista de barras *@
                <Stack Gap="Gaps.Small">
                    @foreach (var cat in dados.PorCategoria)
                    {
                        <div>
                            <div class="flex justify-between text-xs text-dark-500 mb-0.5">
                                <span>@cat.Label</span>
                                <span>@cat.Percentual%</span>
                            </div>
                            <div class="h-2 bg-light-100 rounded-full">
                                <div class="h-2 bg-primary-400 rounded-full"
                                     style="width: @cat.Percentual%"></div>
                            </div>
                        </div>
                    }
                </Stack>
            </Box>
        </Slot>
    </Container>

    @* Seção de atividade recente *@
    <Container Columns="2">
        <Slot>
            <Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
                <Bar AdditionalClasses="mb-3">
                    <StartContent>
                        <p class="text-sm font-semibold text-dark-600">Atividade recente</p>
                    </StartContent>
                    <EndContent>
                        <a href="/atividade" class="text-xs text-primary-600 hover:underline">
                            Ver tudo
                        </a>
                    </EndContent>
                </Bar>
                @if (!dados.AtividadeRecente.Any())
                {
                    <Feedback Style="Themes.Light" Text="Sem atividade no período." />
                }
                else
                {
                    <Stack Gap="Gaps.None">
                        @foreach (var evento in dados.AtividadeRecente.Take(5))
                        {
                            <div class="py-2 border-b border-light-100 last:border-0">
                                <Bar>
                                    <StartContent>
                                        <div>
                                            <p class="text-xs font-medium text-dark-600">@evento.Descricao</p>
                                            <p class="text-xs text-dark-300">@evento.DataHora.ToString("dd/MM HH:mm")</p>
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
            @* Alertas *@
            <Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
                <Bar AdditionalClasses="mb-3">
                    <StartContent>
                        <p class="text-sm font-semibold text-dark-600">Alertas</p>
                    </StartContent>
                    <EndContent>
                        @if (dados.Alertas.Any())
                        {
                            <Badge Style="Themes.Danger" Text="@dados.Alertas.Count.ToString()" />
                        }
                    </EndContent>
                </Bar>
                @if (!dados.Alertas.Any())
                {
                    <Feedback Style="Themes.Success" Text="Nenhum alerta no momento." />
                }
                else
                {
                    <Stack Gap="Gaps.Small">
                        @foreach (var alerta in dados.Alertas)
                        {
                            <Feedback Style="@alerta.Tema" Text="@alerta.Mensagem" />
                        }
                    </Stack>
                }
            </Box>
        </Slot>
    </Container>
}
```

## Decisão de uso

- `nota geral`: 5;
- `limitações`: gráficos (charts) são GAP crítico — requerem biblioteca externa (Chart.js, Radzen Charts, MudBlazor Charts, etc.); sem chart nativo a análise visual é limitada a barras CSS e listas;
- `recomendação`: `usar por composição`
- `justificativa geral`:
  - `Container+Slot` + `Box` + metric cards + `Feedback` + listas cobrem a estrutura do dashboard;
  - O GAP de gráficos é o bloqueio principal — para dashboards com visualizações analíticas ricas, biblioteca de charts é obrigatória;
  - Nota 5 reflete cobertura estrutural sólida mas com GAP crítico na zona de gráficos.
