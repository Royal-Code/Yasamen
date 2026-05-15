# UIP-CONTENT-METRIC_CARD - Blueprint

## Identificação
- **Pattern**: UIP-CONTENT-METRIC_CARD - Metric Card.
- **Nível final**: resumido.
- **Cobertura atual**: 4.
- **Meta de cobertura proposta**: 8.
- **Evidências usadas**: `ui-map.md`, `ui_content.pattern.md`, samples de `Box`, `Badge`, `Icon`, `Feedback`, `visual.language.md` e `styles.map.md`.

## Gap resumido
Yasamen possui `Box` e `Badge`, mas não há card de métrica com valor, delta, período e estado.

## Decisão arquitetural principal
Criar `[API proposta] MetricCard` como leaf de conteúdo para dashboards.

## Componentes reaproveitados
`Box`, `Badge`, `Icon`, `Feedback`.

## Bloco principal de código

```razor
@* [API proposta] MetricCard *@
<Box AdditionalClasses="p-6 bg-white border border-light-300 rounded-md space-y-3">
    <div class="flex items-start justify-between gap-3">
        <span class="text-sm text-dark-500">@Label</span>
        @if (!string.IsNullOrWhiteSpace(Delta))
        {
            <Badge Text="@Delta" Style="@DeltaTheme" Size="Sizes.Small" />
        }
    </div>
    <div class="text-3xl font-medium text-dark-900">@Value</div>
    <p class="text-sm text-dark-500">@Period</p>
</Box>
```

## Exemplo principal de uso
Use em dashboard, resumo de detalhe e cabeçalho de métricas.

## Justificativa breve da cobertura proposta
Define a estrutura de KPI sem depender de chart. Delta positivo/negativo usa semântica de `Themes`.

## Limitações remanescentes
- Sparkline/chart não é nativo.
- Formatação numérica depende do app.

## Pontos de adaptação
- Usar `Success` para delta positivo e `Danger` para negativo.
- Exibir "--" ou empty state quando não houver dado.
