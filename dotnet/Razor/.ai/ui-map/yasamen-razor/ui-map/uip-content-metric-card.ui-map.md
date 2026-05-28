# UIP-CONTENT-METRIC_CARD - Metric Card

## Componentes

**Principais**:

1. Box
- `cobertura`: card de KPI com borda, padding e sombra opcional; `Border=BorderBuilder.Box` + `AdditionalClasses="p-4"`;
- `nota`: 8;
- `justificativa`: container do card de métrica — delimita visualmente cada KPI.

**Composição**:

1. Bar
- `cobertura`: linha de rótulo (StartContent) + variação/badge (EndContent) no topo do card; ou valor principal (StartContent) + ícone de tendência (EndContent);
- `nota`: 8;
- `justificativa`: layout horizontal de label + contexto dentro do card.

2. Badge
- `cobertura`: variação percentual (`Themes.Success` para positiva, `Themes.Danger` para negativa, `Themes.Light` para neutra); status de meta atingida;
- `nota`: 8;
- `justificativa`: indicador visual de variação e tendência.

3. Container+Slot
- `cobertura`: grade de 2-4 colunas para múltiplos cards de KPI em dashboard;
- `nota`: 8;
- `justificativa`: grade responsiva de cards de métrica.

**Descartados**: nenhum.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `sparkline no card`: sem nativo — requer biblioteca externa de chart ou SVG inline simples;
  - `ícone de tendência (↑↓)`: usar `WellKnownIcons.TrendUp/TrendDown` ou `↑`/`↓` em HTML;
  - `skeleton de loading`: div com `animate-pulse` via AdditionalClasses.

- `tipo de adaptação`: composição direta
- `o que precisa ser feito`:
  - `Box` com padding como container; valor principal em `<p class="text-3xl font-bold">`;
  - `Bar` para label + badge de variação; grade de cards via `Container+Slot`.

## Como usar

### KPI simples

```razor
<Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
    <p class="text-xs text-dark-400 mb-1">Total de vendas</p>
    <p class="text-3xl font-bold text-dark-600">R$ 48.350</p>
    <p class="text-xs text-dark-400 mt-1">Mês atual</p>
</Box>
```

### KPI com variação

```razor
<Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
    <Bar AdditionalClasses="mb-2">
        <StartContent>
            <p class="text-xs text-dark-400">Novos clientes</p>
        </StartContent>
        <EndContent>
            <Badge Style="@(variacao > 0 ? Themes.Success : Themes.Danger)"
                   Text="@($"{(variacao > 0 ? "+" : "")}{variacao}%")" />
        </EndContent>
    </Bar>
    <p class="text-3xl font-bold text-dark-600">@totalClientes</p>
    <p class="text-xs text-dark-400 mt-1">vs. mês anterior</p>
</Box>
```

### Grade de 4 KPIs em dashboard

```razor
<Container Columns="4" AdditionalClasses="mb-6">
    <Slot>
        <Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
            <p class="text-xs text-dark-400 mb-1">Pedidos</p>
            <p class="text-2xl font-bold text-dark-600">@totalPedidos</p>
        </Box>
    </Slot>
    <Slot>
        <Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
            <p class="text-xs text-dark-400 mb-1">Receita</p>
            <p class="text-2xl font-bold text-dark-600">@receita.ToString("C")</p>
        </Box>
    </Slot>
    <Slot>
        <Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
            <p class="text-xs text-dark-400 mb-1">Clientes ativos</p>
            <p class="text-2xl font-bold text-success-600">@clientesAtivos</p>
        </Box>
    </Slot>
    <Slot>
        <Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
            <p class="text-xs text-dark-400 mb-1">Pendentes</p>
            <p class="text-2xl font-bold text-warning-600">@pendentes</p>
        </Box>
    </Slot>
</Container>
```

## Decisão de uso

- `nota geral`: 6;
- `limitações`: sem componente de metric card dedicado; sparkline requer biblioteca externa; skeleton manual; cor do valor principal (verde/vermelho por tendência) requer classe condicional;
- `recomendação`: `usar por composição`
- `justificativa geral`:
  - `Box` + `Bar` + `Badge` + HTML de tipografia cobrem todas as variantes de metric card;
  - `Container+Slot` provê grade responsiva de KPIs;
  - Nota 6 reflete boa cobertura via composição com apenas sparkline sem suporte nativo.
