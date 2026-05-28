# UIP-INTERACTION-PULL_REFRESH - Pull to Refresh

**GAP — sem cobertura viável**

Gesto de pull-to-refresh não é suportado pela biblioteca. Primariamente um padrão mobile nativo.

## Componentes

**Principais**: nenhum.
**Composição**: nenhum.

## Esforço de adaptação

- `tipo de adaptação`: nova implementação externa
- `o que precisa ser feito`:
  - Para web mobile: implementar com touch events JS + indicador de carregamento (`RotationMotion` como spinner);
  - Alternativa web: botão "Atualizar" explícito com `Button` e `IconAnimation`.

## Como usar

```razor
@* Alternativa web acessível: botão Atualizar explícito *@
<Bar AdditionalClasses="mb-4">
    <EndContent>
        <Button Style="Themes.Default" Icon="WellKnownIcons.RefreshIcon"
                Label="Atualizar"
                IconAnimation="@(isRefreshing ? Spinning : null)"
                Disabled="@isRefreshing"
                OnClick="Atualizar" />
    </EndContent>
</Bar>
```

## Decisão de uso

- `nota geral`: 0;
- `limitações`: sem suporte nativo; alternativa: botão explícito de atualização;
- `recomendação`: `evitar`
- `justificativa geral`: pull-to-refresh é padrão mobile nativo sem equivalente na lib; botão de atualização é a alternativa web.
