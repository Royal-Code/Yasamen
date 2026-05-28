# UIP-SURFACE-CHART - Chart Surface

**GAP — sem componente dedicado**

A biblioteca não tem componente de chart/gráfico. Requer biblioteca externa de visualização (Chart.js, ApexCharts, Plotly, Blazor-Charts, Radzen Charts, etc.).

## Componentes

**Principais**: nenhum.

**Composição**:

1. Box
- `cobertura`: container do gráfico com borda e padding;
- `nota`: 4;
- `justificativa`: container visual para gráfico externo — não provê capacidade analítica.

2. Bar + Badge / Feedback
- `cobertura`: header do card de gráfico (título, período, legenda simplificada);
- `nota`: 4;
- `justificativa`: metadado do gráfico — não é o gráfico em si.

**Descartados**: nenhum.

## Esforço de adaptação

- `tipo de adaptação`: biblioteca externa obrigatória
- `o que precisa ser feito`:
  - Integrar biblioteca de charts: Chart.js via JSInterop, Radzen.Blazor Charts (Blazor-native), ApexCharts.Blazor, MudBlazor Charts;
  - Usar `Box` como container do componente de chart externo;
  - Para KPI isolado sem gráfico: usar `UIP-CONTENT-METRIC_CARD` — não é este pattern.

## Como usar

### Skeleton de integração com chart externo

```razor
<Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
    <Bar AdditionalClasses="mb-3">
        <StartContent>
            <span class="font-semibold text-dark-600">Vendas por mês</span>
        </StartContent>
        <EndContent>
            <Badge Style="Themes.Light" Text="Últimos 12 meses" />
        </EndContent>
    </Bar>
    @* Componente de chart externo (ex: Radzen, Chart.js) *@
    <div class="h-64">
        @* <RadzenChart> ou <canvas @ref="chartRef"> aqui *@
    </div>
</Box>
```

## Decisão de uso

- `nota geral`: 0;
- `limitações`: sem componente de chart nativo; visualizações gráficas requerem biblioteca externa; `Box` serve apenas como container visual;
- `recomendação`: `evitar`
- `justificativa geral`:
  - A lib não provê nenhuma capacidade de visualização gráfica;
  - Para KPI isolado sem gráfico, usar `UIP-CONTENT-METRIC_CARD`;
  - Nota 0 reflete ausência total de suporte nativo para charts.
