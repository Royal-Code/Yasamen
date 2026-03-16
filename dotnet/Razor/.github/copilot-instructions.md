# RoyalCode.Razor — Instruções de Repositório para Copilot

Este repositório é uma solução .NET de biblioteca de componentes Razor.

## Contexto base

- Use `.ai/ui-map/ui-map.md` como mapa de cobertura e lacunas.
- Use `.ai/ui-map/ui-plan.md` como fonte de fase, prioridade e sequência.
- Use `.ai/guides/` como referência normativa para estrutura, CSS, anatomia de componentes, showcases e execução de specs.
- Use `.ai/specs/_template/` como base para novas specs.

## Regras de trabalho

- Em documentação e specs, use sempre acentuação.
- Preserve a separação entre `requirements.md`, `design.md`, `tasks.md` e `delivery.md`.
- Não copie templates sem adaptação.
- Preserve mudanças existentes do utilizador; não sobrescreva trabalho alheio sem necessidade.

## Componentes e CSS

- Novos componentes devem seguir a estrutura e os namespaces definidos nos guides.
- Prefira CSS público em `RoyalCode.Razor.Styles/wwwroot/css/components/` com import em `RoyalCode.Razor.Styles/wwwroot/yasamen.css`.
- Trate `*.razor.css` em pacotes da biblioteca como legado ou exceção justificada, não como padrão a expandir.

## Showcase e documentação

- O host atual de showcase é `RoyalCode.Razor.Docs/RoyalCode.Razor.Docs.Client`.
- Não trate `RoyalCode.Razor.Show` como host operacional atual.
- Quando a tarefa envolver showcase, siga `.ai/guides/09-showcases-and-docs.md`.
- Para trabalho focado em showcases e páginas de documentação, prefira o agente `showcase-docs`.

## Fluxo de specs

- Para escolher o próximo alvo, consulte as specs existentes em `.ai/specs/` antes de sugerir criar algo novo.
- Para criar ou refinar specs, mantenha rastreabilidade com `ui-map.md`, `ui-plan.md` e os guides aplicados.
- Para implementar uma spec, feche também `delivery.md` e `tasks.md`, e atualize `ui-map.md` ou `ui-plan.md` quando a cobertura ou o roadmap mudarem.
- Para revisão crítica de implementação, bugs, regressões e aderência à spec, prefira o agente `component-review`.
