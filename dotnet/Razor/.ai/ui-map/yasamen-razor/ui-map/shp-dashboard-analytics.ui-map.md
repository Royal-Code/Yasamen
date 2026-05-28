# SHP-DASHBOARD_ANALYTICS - Dashboard/Analytics

## Componentes por zona funcional

### Zona: Shell (estrutura)

1. AppLayout + AppSideBar (estrutura raiz)
- `cobertura`: layout com sidebar de áreas analíticas + área principal de dashboards;
- `nota`: 8;
- `justificativa`: shell de analytics similar ao SHP-WORKSPACE_ADMIN — AppLayout como base.

2. Bar (header com filtros globais)
- `cobertura`: seletor de período global, filtros de contexto (produto, região, equipe), botão de refresh;
- `nota`: 8;
- `justificativa`: toolbar de filtros globais do shell analítico.

### Zona: Métricas

1. Container+Slot + Box (grade de KPIs)
- `cobertura`: 2-4 colunas de metric cards; skeleton durante loading; responsive;
- `nota`: 8;
- `justificativa`: grade de KPIs — cobertura direta com Container+Slot.

2. Badge (variação / alerta de métrica)
- `cobertura`: badge colorido de variação positiva/negativa; alertas de threshold;
- `nota`: 9;
- `justificativa`: indicador visual de tendência.

### Zona: Gráficos — GAP

1. (UIP-SURFACE-CHART — nota 0)
- `cobertura`: sem componente de gráfico nativo — GAP crítico;
- `nota`: 0;
- `justificativa`: gráficos analíticos requerem biblioteca externa.
- `alternativa`: barras CSS proporcionais (sem tooltip, sem interação) + tabelas de dados.

### Zona: Alertas e Notificações

1. Feedback Style=Danger/Warning (alertas)
- `cobertura`: alerta de threshold atingido, anomalia detectada, serviço down;
- `nota`: 8;
- `justificativa`: alertas de estado operacional.

2. NotificationService + Notification (alertas em tempo real)
- `cobertura`: toast de novo alerta crítico;
- `nota`: 9;
- `justificativa`: notificação de alerta em tempo real.

3. Badge no `AppSideBar` (contador global)
- `cobertura`: badge de alertas ativos no item de navegação "Alertas";
- `nota`: 8;
- `justificativa`: indicador de alertas pendentes na navegação.

### Zona: Drill-down

1. OffCanvas (drill-down de métrica)
- `cobertura`: detalhe de uma métrica ao clicar — histórico, itens relacionados, ações;
- `nota`: 8;
- `justificativa`: drill-down contextual sem abandonar o dashboard.

2. Modal (ação sobre alerta)
- `cobertura`: modal de ação rápida sobre alerta (reconhecer, escalar, comentar);
- `nota`: 9;
- `justificativa`: ação sobre alerta do dashboard.

**Descartados**: nenhum.

## Estrutura de shell

```razor
@* AnalyticsLayout.razor — shell de Dashboard/Analytics *@
@inherits LayoutComponentBase

@code {
    private string periodoGlobal = "30d";
    private int alertasAtivos;
}

<AppLayout>
    <AppSideBar>
        <div class="px-4 py-3 border-b border-light-200">
            <span class="font-bold text-dark-700 text-sm">Analytics</span>
        </div>

        <nav class="flex-1 overflow-y-auto p-2">
            <Stack Gap="Gaps.None">
                <NavLink href="/analytics/overview"
                         class="flex items-center gap-2 px-3 py-2 text-sm rounded-md
                                text-dark-500 hover:bg-light-50"
                         ActiveClass="bg-primary-50 text-primary-700 font-medium">
                    Visão geral
                </NavLink>
                <NavLink href="/analytics/receita"
                         class="flex items-center gap-2 px-3 py-2 text-sm rounded-md
                                text-dark-500 hover:bg-light-50"
                         ActiveClass="bg-primary-50 text-primary-700 font-medium">
                    Receita
                </NavLink>
                <NavLink href="/analytics/usuarios"
                         class="flex items-center gap-2 px-3 py-2 text-sm rounded-md
                                text-dark-500 hover:bg-light-50"
                         ActiveClass="bg-primary-50 text-primary-700 font-medium">
                    Usuários
                </NavLink>
                <div class="relative">
                    <NavLink href="/analytics/alertas"
                             class="flex items-center gap-2 px-3 py-2 text-sm rounded-md
                                    text-dark-500 hover:bg-light-50"
                             ActiveClass="bg-primary-50 text-primary-700 font-medium">
                        Alertas
                    </NavLink>
                    @if (alertasAtivos > 0)
                    {
                        <span class="absolute right-3 top-1/2 -translate-y-1/2">
                            <Badge Style="Themes.Danger" Text="@alertasAtivos.ToString()" />
                        </span>
                    }
                </div>
            </Stack>
        </nav>
    </AppSideBar>

    @* Header com filtros globais *@
    <div class="flex flex-col flex-1 overflow-hidden">
        <Bar AdditionalClasses="px-6 py-3 border-b border-light-200 bg-white flex-shrink-0">
            <StartContent>
                <h1 class="text-base font-semibold text-dark-700">
                    @currentPageTitle
                </h1>
            </StartContent>
            <EndContent>
                @* Seletor de período global *@
                <FieldSelect Value="@periodoGlobal"
                             ValueChanged="async v => { periodoGlobal = v; await RefreshAll(); }"
                             Options='new[] { ("7d","7 dias"), ("30d","30 dias"),
                                             ("90d","90 dias"), ("1y","1 ano") }' />
                <IconButton Icon="WellKnownIcons.Refresh" Style="Themes.Default"
                           title="Atualizar"
                           OnClick="async () => await RefreshAll()" />
            </EndContent>
        </Bar>

        <main class="flex-1 overflow-auto p-6">
            @Body
        </main>
    </div>
</AppLayout>
```

## Decisão de uso

- `nota geral`: 5;
- `limitações`: GAP crítico em gráficos (charts) — toda visualização analítica requer biblioteca externa; sem componente de sparkline nativo; sem grid de painéis redimensionáveis; alternativa de barras CSS é muito limitada para análise real;
- `recomendação`: `usar por composição`
- `justificativa geral`:
  - `AppLayout` + grade de KPIs + `Feedback` de alertas + `NotificationService` + drill-down via `OffCanvas` cobrem o shell analítico;
  - O GAP de gráficos é o bloqueio principal — para dashboards analíticos com visualizações ricas, biblioteca de charts é obrigatória (Chart.js, Radzen Charts, Blazorise Charts, ApexCharts);
  - Nota 5 reflete shell estrutural sólido com GAP crítico na zona de gráficos analíticos.
