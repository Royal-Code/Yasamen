# Instrução Operacional — Selecionar a Próxima Spec

> Use este arquivo como base em novos chats para que a IA analise o estado atual do planeamento e recomende qual spec deve ser criada, refinada ou implementada a seguir.

## Fontes Obrigatórias

Antes de recomendar o próximo passo, a IA deve ler:

- `.ai/ui-map/ui-map.md`
- `.ai/roadmap/ui-plan.md`
- `.ai/roadmap/components-plan-list.md`
- `.ai/specs/`
- `.ai/guides/rules/spec-execution-and-delivery.md`
- `.ai/guides/expand/cross-cutting-component-decisions.md`

## Critérios de Decisão

1. prioridade no `ui-plan.md`;
2. cobertura atual no `ui-map.md`;
3. poder de desbloqueio;
4. existência e maturidade da spec;
5. coerência de pacote e infraestrutura;
6. custo e risco;
7. dependências composicionais e pré-requisitos.

## Regra adicional de pré-requisitos

Se o alvo recomendado depender naturalmente de um componente-base ainda ausente em `components-plan-list.md`, a IA deve explicitar isso e decidir entre:

- criar primeiro a spec do componente-base;
- refinar uma spec existente para incluir esse pré-requisito;
- ou justificar por que o alvo pode seguir sem ele no primeiro release.

## Formato Esperado da Resposta

1. próximo melhor passo;
2. justificativa curta;
3. alternativas próximas;
4. pré-requisitos composicionais, se houver;
5. prompt recomendado.


