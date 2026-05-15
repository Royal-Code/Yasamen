# PP-DASHBOARD - Blueprint

## Identificação
- **Pattern**: PP-DASHBOARD.
- **Nível final**: completo.
- **Cobertura atual**: 3.
- **Meta de cobertura proposta**: 8.
- **Evidências usadas**: `ui-map.md`, `page.pattern.md`, samples de `Container`, `Slot`, `Box`, `Badge`, `ButtonGroup`, `Feedback`, `Pagination`, `visual.language.md` e `styles.map.md`.

## Resumo executivo
Yasamen organiza dashboard com grid e blocos, mas não tem métricas, chart ou painel analítico. Este blueprint propõe uma página de dashboard com `MetricCard`, `DashboardPanel` e filtros compactos.

## Requisitos ainda não atendidos
- Cards de métrica com valor e delta.
- Painéis analíticos com título, ação e estado.
- Filtros de período.
- Loading/empty/error por painel.
- Responsividade de densidade analítica.

## Diagnóstico estruturado do gap
`Container`/`Slot` resolve grid; `Box` resolve painel; `Badge` resolve delta/status; `Feedback` resolve estado. Falta contrato para métrica e chart externo.

## Justificativa detalhada da meta
A meta 8 cobre estrutura e leitura de dashboard, aceitando que chart e data grid ficam externos. O blueprint padroniza a forma de encaixar essas integrações.

## Estratégia de composição
- `ButtonGroup` para período.
- `Container`/`Slot` para métrica e painel.
- `MetricCard` proposto em `Box`.
- `DashboardPanel` proposto com slot `Content`.
- `Feedback` por painel.

## Proposta de peças, contratos e responsabilidades
- `[API proposta] DashboardPage`: Metrics, Panels, Filters.
- `[API proposta] MetricCard`: Label, Value, Delta, Theme.
- `[API proposta] DashboardPanel`: Title, Toolbar, State, Content.

## Aplicação objetiva da linguagem visual
Métricas são blocos brancos, sem cor forte no fundo. Delta usa `Badge`. Chart externo deve herdar paleta semântica.

## Aplicação de estilos e tokens
Usar `gap-6`, `p-6`, `border-light-300`, `rounded-md`. Em mobile, empilhar cards e reduzir painéis para leitura sequencial.

## Estrutura sugerida por tecnologia

```razor
@* [API proposta] DashboardPage *@
<Stack AdditionalClasses="space-y-6">
    <Bar>
        <Start><h1 class="text-2xl font-medium text-dark-900">Dashboard</h1></Start>
        <End>
            <ButtonGroup Size="Sizes.Small" AriaLabel="Período">
                <Button Label="Hoje" />
                <Button Label="30 dias" Active="true" />
            </ButtonGroup>
        </End>
    </Bar>

    <Container Type="LayoutTypes.Grid" Size="LayoutSizes.Default" AdditionalClasses="gap-6">
        @MetricCards
        @Panels
    </Container>
</Stack>
```

## Blocos principais de código

```razor
@* [API proposta] MetricCard *@
<Slot Span="4" LaptopSpan="3">
    <Box AdditionalClasses="p-6 bg-white border border-light-300 rounded-md space-y-3">
        <div class="flex justify-between gap-3">
            <span class="text-sm text-dark-500">@Label</span>
            <Badge Text="@Delta" Style="@DeltaTheme" Size="Sizes.Small" />
        </div>
        <div class="text-3xl font-medium text-dark-900">@Value</div>
        <p class="text-sm text-dark-500">@Hint</p>
    </Box>
</Slot>
```

## Estados e comportamento responsivo
- Desktop: KPIs em linha, painéis abaixo.
- Mobile: KPIs empilhados, filtros acima da lista.
- Loading: feedback por painel, não tela inteira.
- Empty: painel com `Feedback Info`.
- Error: painel com `Feedback Danger` e ação retry.

## Exemplo principal de uso

```razor
@* [API proposta] *@
<DashboardPage Metrics="metrics"
               Panels="panels"
               Period="@period"
               OnPeriodChanged="Reload" />
```

## Comparação entre cobertura atual e proposta
| Critério | Atual | Proposta |
|---|---|---|
| Grid | forte | mantido |
| Métrica | ausente | card proposto |
| Painel | manual | contrato proposto |
| Chart | ausente | slot externo |

## Limitações remanescentes
- Chart e tabela avançada continuam externos.
- Agregação de dados depende do domínio.
- Drill-down usa rotas ou modais do app.

## Pontos de adaptação
- Definir formatação de valores.
- Definir estado de cada painel.
- Usar cores semânticas apenas para delta/status.
