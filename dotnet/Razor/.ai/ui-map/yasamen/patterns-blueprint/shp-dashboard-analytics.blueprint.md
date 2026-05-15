# SHP-DASHBOARD_ANALYTICS - Blueprint

## Identificação
- **Pattern**: SHP-DASHBOARD_ANALYTICS - Dashboard/Analytics.
- **Nível final**: completo.
- **Cobertura atual**: 3.
- **Meta de cobertura proposta**: 8.
- **Evidências usadas**: `ui-map.md`, `shell.pattern.md`, samples de `AppLayout`, `Container`, `Slot`, `Box`, `Badge`, `Feedback`, `ButtonGroup`, `TextField`, `Pagination`, `visual.language.md` e `styles.map.md`.

## Resumo executivo
Yasamen fornece shell, grid, badges e feedback, mas não possui chart, KPI card ou painel analítico. O blueprint propõe um shell analítico com filtros globais, métrica, bloco de visualização e drill-down, reaproveitando os componentes da biblioteca no contorno e marcando visualizações ricas como integração externa.

## Requisitos ainda não atendidos
- KPIs com valor, delta, tendência e estado.
- Filtros globais persistentes.
- Área analítica com chart ou tabela resumida.
- Drill-down controlado para detalhe.
- Estados de carregamento e dado indisponível.

## Diagnóstico estruturado do gap
`AppLayout` e `Container` resolvem estrutura responsiva; `Badge` resolve status leve; `Feedback` resolve estados; `TextField` cobre filtro textual. Não há gráfico, data grid, sparkline ou métrica nativa, então esses elementos precisam de peças propostas ou bibliotecas externas.

## Justificativa detalhada da meta
A meta 8 cobre shell e padrão analítico sem afirmar que Yasamen fornece chart. O blueprint melhora a IA de destino porque estabelece zonas, hierarquia e semântica visual, mas mantém chart e cálculos fora da lib.

## Estratégia de composição
- `AppLayout` como shell analítico.
- `ButtonGroup` para período e ações de exportar/atualizar.
- `Container`/`Slot` para grade de KPIs e visualizações.
- `Box` para cada métrica e painel.
- `Badge` para delta/status.
- `Feedback` para empty/loading/error.

## Proposta de peças, contratos e responsabilidades
- `[API proposta] MetricCard`: label, value, delta, trend, theme, loading.
- `[API proposta] AnalyticsPanel`: título, toolbar, conteúdo de chart externo e estado.
- `[API proposta] GlobalFiltersBar`: período, busca, filtros e ação atualizar.

## Aplicação objetiva da linguagem visual
KPIs ficam em superfícies brancas, borda `light-300`, radius `rounded-md`, número em `text-dark-900`, delta positivo em `Themes.Success`, delta negativo em `Themes.Danger`, neutro em `Themes.Secondary`.

## Aplicação de estilos e tokens
Usar `p-6`, `space-y-6`, `gap-6`, grid 4/8/12/16. Gráficos externos devem respeitar paleta `primary`, `success`, `warning`, `danger`, `info` e não introduzir gradientes dominantes.

## Estrutura sugerida por tecnologia

```razor
@* [API proposta] AnalyticsShell *@
<AppLayout AdditionalMainClasses="p-8 bg-light-100">
    <TopStart><strong>Indicadores</strong></TopStart>
    <TopEnd>
        <ButtonGroup Size="Sizes.Small" AriaLabel="Período">
            <Button Label="7d" Active="@(period == "7d")" OnClick="@(_ => period = "7d")" />
            <Button Label="30d" Active="@(period == "30d")" OnClick="@(_ => period = "30d")" />
            <Button Label="Atualizar" Style="Themes.Primary" OnClick="Reload" />
        </ButtonGroup>
    </TopEnd>
    <Main>
        <Stack AdditionalClasses="space-y-6">
            @Metrics
            @Panels
        </Stack>
    </Main>
</AppLayout>
```

## Blocos principais de código

```razor
@* [API proposta] MetricCard *@
<Box AdditionalClasses="p-6 bg-white border border-light-300 rounded-md space-y-3">
    <div class="flex items-center justify-between gap-3">
        <span class="text-sm text-dark-500">@Label</span>
        <Badge Text="@Delta" Style="@DeltaTheme" Size="Sizes.Small" />
    </div>
    <div class="text-3xl font-medium text-dark-900">@Value</div>
    <p class="text-sm text-dark-500">@Description</p>
</Box>

@* [API proposta] painel com chart externo *@
<Box AdditionalClasses="p-6 bg-white border border-light-300 rounded-md space-y-4">
    <Bar>
        <Start><h2 class="font-medium text-dark-900">@Title</h2></Start>
        <End><Button Label="Detalhar" Style="Themes.Light" Size="Sizes.Small" /></End>
    </Bar>
    <div class="min-h-64 bg-light-100 border border-light-300 rounded-md">
        @ChartContent
    </div>
</Box>
```

## Estados e comportamento responsivo
- Desktop: KPIs em 4 cards e painéis em 2 colunas.
- Mobile: KPIs empilhados, filtros compactos e drill-down por página ou modal.
- Loading: `Feedback Style="Themes.Info"` no painel ou placeholder proposto.
- Empty: `Feedback Style="Themes.Info"` com texto sobre ausência de dados.
- Error: `Feedback Style="Themes.Danger"` com ação de tentar novamente.

## Exemplo principal de uso

```razor
@* [API proposta] *@
<AnalyticsShell Metrics="metrics"
                Panels="panels"
                Period="@period"
                OnPeriodChanged="LoadByPeriod"
                OnRefresh="Reload" />
```

## Comparação entre cobertura atual e proposta
| Critério | Atual | Proposta |
|---|---|---|
| Shell | parcial com `AppLayout` | shell analítico |
| KPI | ausente | `MetricCard` proposto |
| Chart | ausente | slot externo formalizado |
| Filtros | manual | barra global proposta |
| Estados | `Feedback` | padrão por painel |

## Limitações remanescentes
- Charts e data grid continuam externos.
- Acessibilidade de gráfico depende do componente escolhido.
- Não há data fetching ou cache no blueprint.

## Pontos de adaptação
- Escolher biblioteca de chart no app destino.
- Padronizar período e filtros globais.
- Definir unidade, formatação e regra de delta por domínio.
