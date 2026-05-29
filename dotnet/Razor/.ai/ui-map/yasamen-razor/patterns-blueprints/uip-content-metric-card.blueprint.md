# UIP-CONTENT-METRIC_CARD - Blueprint resumido

## Pattern

UIP-CONTENT-METRIC_CARD — Metric Card — ver `uip-content-metric-card.ui-map.md`

## Gap coberto

A lib não tem componente de metric card dedicado. O gap é orientar a composição com `Box + Bar + Badge` para cards de KPI simples e com variação, e `Container+Slot` para grade de 4 KPIs em dashboard.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `Box(Border.Box, p-4)` + tipografia HTML direta para rótulo/valor; `Bar` para linha de label + badge de variação; `Container(Columns=4)` para grade responsiva de KPIs.

## Componentes usados

- `Box` — papel: principal (container do card) — ver `box.sample.md`
- `Bar` — papel: composição (label + badge de variação) — ver `bar.sample.md`
- `Badge` — papel: composição (variação percentual, status) — ver `badge.sample.md`
- `Container + Slot` — papel: composição (grade de cards) — ver `bar.sample.md`

## Recursos visuais

- `text-3xl font-bold text-dark-600` — valor principal do KPI
- `text-2xl font-bold` — variante menor para grade densa
- `text-xs text-dark-400` — rótulo e contexto do KPI
- `text-success-600 / text-danger-600 / text-warning-600` — cor semântica do valor

## Receita

`Box` + tipografia HTML para KPI simples; `Bar + Badge` para variação; `Container(Columns=4)` para grade de dashboard.

```razor
@* KPI simples *@
<Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
    <p class="text-xs text-dark-400 mb-1">Total de vendas</p>
    <p class="text-3xl font-bold text-dark-600">R$ 48.350</p>
    <p class="text-xs text-dark-400 mt-1">Mês atual</p>
</Box>

@* KPI com badge de variação *@
@code {
    private int variacao = 12;
    private int totalClientes = 1284;
}

<Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
    <Bar AdditionalClasses="mb-2">
        <StartContent>
            <p class="text-xs text-dark-400">Novos clientes</p>
        </StartContent>
        <EndContent>
            <Badge Style="@(variacao >= 0 ? Themes.Success : Themes.Danger)"
                   Text="@($"{(variacao >= 0 ? "+" : "")}{variacao}%")" />
        </EndContent>
    </Bar>
    <p class="text-3xl font-bold text-dark-600">@totalClientes</p>
    <p class="text-xs text-dark-400 mt-1">vs. mês anterior</p>
</Box>

@* Grade de 4 KPIs em dashboard *@
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

## Limites

- Sem sparkline (mini-gráfico no card) — requer biblioteca externa de chart ou SVG manual;
- `Container(Columns=4)` pode não colapsar adequadamente em mobile — verificar responsividade e usar grid CSS manual se necessário;
- Ícone de tendência (seta ↑↓) pode ser `WellKnownIcons.TrendUp/TrendDown` se disponíveis, ou Unicode `↑`/`↓` inline.
