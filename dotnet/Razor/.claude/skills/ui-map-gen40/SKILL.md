---
name: ui-map-gen40
description: "Analisar e mapear bibliotecas de componentes UI e design systems contra catálogos de patterns, gerando artefatos consumíveis por IA para implementação de telas. Use para mapear patterns e componentes, revisão de ui-map, criar uma versão do ui-map."
argument-hint: "Informe a biblioteca principal, fonte repo ou web, paths/URIs de código, docs, samples ou stories, versão conhecida, plataformas-alvo web/mobile/desktop e bibliotecas auxiliares opcionais."
---

# UI Map Generator v4

Skill para análise e mapeamento de bibliotecas de componentes UI e design systems contra catálogos de UI patterns, produzindo artefatos consumíveis por IA para implementação de telas.

## Objetivo

Analisar uma biblioteca de componentes UI por repositório local ou documentação pública e produzir:
- inventário de componentes enriquecido com pacotes, camadas e similares;
- linguagem visual como contrato externo + auditoria interna separada;
- mapeamento fragmentado de patterns com componentes classificados por pattern;
- samples de uso por componente com profundidade proporcional à complexidade;
- blueprints de implementação para gaps de cobertura;
- rules corporativas executáveis;
- manifest final com índice dos artefatos consumíveis por outras skills.

Analisar um ui-map existente e avaliar os artefatos contra a realidade dos componentes e da biblioteca.

Liberar uma nova versão de um ui-map existente.

Artefatos escritos para consumo por IA (`screen-designer`, `screen-coder`), não para documentação humana final.

## Execução

[REGRA] Delegar de forma autoritária e completa a execução desta skill ao protocolo `references/protocols/workflow.protocol.md`. Não executar nenhuma etapa diretamente a partir deste arquivo.

Ao ativar esta skill:
1. Carregar `references/protocols/workflow.protocol.md`.
2. Executar o workflow como orquestrador da rodada.

O workflow identifica o fluxo, resolve diretório, state, fontes, plataformas-alvo e bibliotecas auxiliares, e delega para os protocolos de cada etapa.

## Referências

[REGRA] Não ler arquivos de referência de imediato. Ler somente quando exigido pelo protocolo em execução, por um template ou por pedido explícito do humano.

Referências organizadas em subpastas de `references/`:

- `rules/` — regras do kernel e do workflow que governam toda a execução.
- `protocols/` — protocolo de workflow orquestrador e protocolos de cada etapa do pipeline.
- `templates/` — templates para geração dos artefatos de cada etapa.
- `patterns/` — catálogos de UI patterns. Os arquivos `patterns.schema.md`, `patterns.group.md` e `patterns.list.md` orientam a navegação. Patterns específicos ficam em subpastas por categoria.

## Pipeline

```
workflow → project-summary → visual-language → ui-map → create-samples → patterns-blueprints → corporate-rules → patterns-orientations → finalize
```

Fluxos disponíveis: `gerar-ui-map`, `revisao`, `release`. O workflow identifica o fluxo a partir da entrada do humano.

## Diretório de trabalho

```
.ai/ui-map/{slug}/
```
