---
name: component-plan
description: Planejar e criar specs de componentes, pacotes ou biblioteca no fluxo spec-first da solução Yasamen/RoyalCode Razor. Use quando Codex precisar selecionar ou confirmar um componente alvo, conduzir plan-spec por gates com aprovação humana, gerar um arquivo de planejamento persistido, e em seguida materializar requirements.md, design.md, tasks.md e delivery.md em .ai/specs/lib/{slug}/ sem implementar código.
---

# Component Plan

Skill para planejar e criar specs de componentes da biblioteca em fluxo executável por IA.

## Objetivo

Conduzir o fluxo de componente em duas etapas obrigatórias:
- `plan-spec`: fechar decisões por gates, registrar hipóteses e aprovações, e gerar `planning.md`;
- `create-spec`: transformar `planning.md` em `requirements.md`, `design.md`, `tasks.md` e `delivery.md`.

A skill não implementa componentes. Depois da criação da spec, outra skill ou fluxo deve executar a implementação.

## Execução

[REGRA] Delegar de forma autoritária e completa a execução desta skill ao protocolo `references/protocols/workflow.protocol.md`. Não executar nenhuma etapa diretamente a partir deste arquivo.

Ao ativar esta skill:
1. Carregar `references/protocols/workflow.protocol.md`.
2. Executar o workflow como orquestrador da rodada.

O workflow deve carregar e seguir estritamente `references/rules/kernel.rules.md` antes de qualquer decisão, gate ou etapa operacional.

O workflow identifica o alvo, resolve diretório de spec, executa o planejamento, persiste o plano e delega a criação dos artefatos finais.

## Referências

[REGRA] Não ler arquivos de referência de imediato. Ler somente quando exigido pelo protocolo em execução, por um template ou por pedido explícito do humano.

Referências organizadas em subpastas de `references/`:

- `rules/kernel.rules.md` - kernel obrigatório; deve ser seguido estritamente.
- `rules/workflow.rules.md` - regras gerais do workflow.
- `rules/component-plan.rules.md` - regras específicas de planejamento e criação de specs de componente.
- `protocols/` - protocolo orquestrador e protocolos das etapas `plan-spec` e `create-spec`.
- `templates/` - templates dos artefatos `planning.md`, `requirements.md`, `design.md`, `tasks.md` e `delivery.md`.

## Pipeline

```text
workflow -> plan-spec -> create-spec
```

Fluxo principal: `planejar-e-criar-spec`.

## Diretório de trabalho

```text
.ai/specs/lib/{slug}/
```

Artefatos esperados:

```text
planning.md
requirements.md
design.md
tasks.md
delivery.md
```
