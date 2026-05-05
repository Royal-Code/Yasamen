---
name: ui-map-gen2
description: "Analisar e mapear bibliotecas de componentes UI e design systems contra catálogos de patterns, gerando artefatos consumíveis por IA para implementação de telas: inventário de componentes, linguagem visual, ui-map, samples, blueprints, guides corporativos opcionais e manifest. Use quando Codex precisar analisar uma biblioteca por repositório local ou documentação pública, com fonte repo ou web, target web/mobile/desktop, state em `.ai/ui-map/{slug}/state.yaml`, retomada por etapa e execução orquestrada por workflow."
argument-hint: "Informe a biblioteca principal, fonte repo ou web, paths/URIs de código, docs, samples ou stories, versão conhecida, plataformas-alvo web/mobile/desktop e bibliotecas auxiliares opcionais."
---

# UI Map Generator

Skill para análise e mapeamento de bibliotecas de UI contra catálogos de patterns, gerando artefatos consumíveis por IA para implementação de telas.

## Objetivo

Analisar uma biblioteca de componentes UI por repositório local ou documentação pública e produzir:
- Inventário de componentes e estilos.
- Linguagem visual documentada.
- Mapeamento completo de patterns com notas de cobertura.
- Samples de uso por componente com profundidade proporcional à complexidade.
- Blueprints de implementação para gaps de cobertura.
- Guides corporativos opcionais para decisões que vão além dos componentes visuais.
- Manifest de reprodutibilidade.

Todos os artefatos são escritos para consumo por IA, especialmente pela skill `screen-designer`, não para documentação humana final.

## Ponto de entrada

Esta skill delega a execução ao protocolo de workflow.

Ao ativar esta skill:
1. Carregar `references/kernel-skills.md`.
2. Carregar `references/protocols/workflow.protocol.md`.
3. Executar o workflow como orquestrador da rodada.
4. Deixar o workflow resolver diretório, `state.yaml`, fontes, plataformas-alvo, bibliotecas auxiliares, etapa atual e delegação para protocolos específicos.

Não iniciar `components-summary`, `visual-language`, `ui-map`, `patterns-output`, `corporate-guides` ou `finalize` diretamente a partir do `SKILL.md`. Essas etapas são chamadas pelo workflow conforme estado, gates e aprovação humana.

## Regras gerais

[INSTRUÇÃO] Reler o kernel, workflow e protocolo da etapa corrente a cada início de etapa, validação de gate e verificação de checklist.

[INSTRUÇÃO] Não fazer duas etapas ao mesmo tempo. Uma etapa por vez, com gate e checklist satisfeitos antes de apresentar ao humano.

[INSTRUÇÃO] Ao concluir uma etapa: resumir ao humano, pedir avaliação e perguntar se pode seguir.

[INSTRUÇÃO] Atender pedidos de alteração antes de prosseguir.

[INSTRUÇÃO] Os arquivos gerados são para uso pela IA na skill `screen-designer`. Foco em instrução, rastreabilidade e baixa ambiguidade.

[INSTRUÇÃO] Não se basear em análises de outras bibliotecas. Não ler outros diretórios em `.ai/ui-map/` salvo o diretório da rodada atual.

[INSTRUÇÃO] Não inventar versões, APIs, props, tokens, classes, breakpoints, dependências, plataformas ou comportamento não evidenciado.

## Modo de operação

A skill é orquestrada por `workflow.protocol.md`, que:
1. Resolve dependências iniciais: diretório, state, fontes e plataformas-alvo.
2. Sequencia etapas na ordem fixa.
3. Delega execução a cada protocolo específico.
4. Valida gates.
5. Transita entre etapas com aprovação humana.

## Etapas

### Início: workflow

Resolver diretório, biblioteca principal, fontes, auxiliares, plataformas-alvo e state. Criar ou retomar `state.yaml` e iniciar ou atualizar `sources.inventory.md`.

### 1. components-summary

Levantar componentes disponíveis. Produzir `components.summary.md`, `structure.md` quando a fonte for repo e `styles.guide.md` quando aplicável.

### 2. visual-language

Analisar linguagem visual com classificação de evidência. Produzir `visual.language.md`. Produzir `styles.map.md` quando estilos forem mapeáveis.

### 3. ui-map

Mapear patterns dos catálogos para componentes da biblioteca. Registrar nota, cobertura, esforço e limitações por pattern. Produzir `ui-map.md`.

### 4. patterns-output

Sub-etapas sequenciais:
1. **Samples**: exemplos por componente, profundidade proporcional à complexidade. Produzir `samples/{component}.sample.md` e `samples/components.table.md`.
2. **Blueprints**: propostas para gaps de cobertura. Produzir `patterns-blueprint/{pattern}.blueprint.md` e `patterns-blueprint/blueprints.table.md`.
3. **Patterns map**: índice compacto final. Produzir `patterns.map.md`.

### 5. corporate-guides opcional

Descobrir guides por eixos de tecnologia e contexto. Entrevistar humano. Gerar `guides/corporative.guide.md` e guides individuais aprovados.

### 6. finalize

Gerar `manifest.md`, validar e consolidar `sources.inventory.md`, validar state e fechar rodada.

## Seleção de etapa

Ordem fixa:

```text
workflow -> components-summary -> visual-language -> ui-map -> patterns-output -> corporate-guides -> finalize
```

Regras:
- Rodada nova: iniciar pelo workflow.
- Retomada: carregar state e retomar da etapa incompleta.
- `styles.map`, sub-etapa de `visual-language`, pode ser `skipped` quando estilos não forem aplicáveis.
- `corporate-guides` só entra quando o humano pedir, houver política corporativa relevante, ou a skill detectar valor e pedir confirmação.
- Aprovação humana ocorre entre etapas principais, exceto sub-etapas internas definidas pelo workflow/protocolo ativo.

## Diretório de trabalho

```text
.ai/ui-map/{slug}/
```

Onde `slug` é o nome da biblioteca em dash-case.

## Artefatos principais

| Artefato | Etapa | Obrigatório |
|---|---|---|
| `state.yaml` | workflow | sim |
| `sources.inventory.md` | workflow + finalize | sim |
| `components.summary.md` | components-summary | sim |
| `structure.md` | components-summary | repo only |
| `styles.guide.md` | components-summary | condicional |
| `visual.language.md` | visual-language | sim |
| `styles.map.md` | visual-language | condicional |
| `ui-map.md` | ui-map | sim |
| `samples/components.table.md` | patterns-output | sim |
| `samples/{component}.sample.md` | patterns-output | sim |
| `patterns-blueprint/blueprints.table.md` | patterns-output | sim |
| `patterns-blueprint/{pattern}.blueprint.md` | patterns-output | condicional |
| `patterns.map.md` | patterns-output | sim |
| `guides/corporative.guide.md` | corporate-guides | se etapa ativa |
| `guides/{guide}.guide.md` | corporate-guides | por seleção |
| `manifest.md` | finalize | sim |

## State

O `state.yaml` controla retomada e progressão. Campos principais:
- `ui_map_id`, `directory`, `library` com nome, slug, source_kind, version, target_platforms e sources.
- `auxiliary_libraries` com nome, purpose, scope, source_ref e status.
- `current_stage`, `current_item`, `patterns_output.substage`.
- `stages` com status por etapa: `pending`, `done`, `blocked` ou `skipped`.
- `blockers`, `open_gaps`, `next_action`.

Usar `references/templates/state.template.yaml` somente para criar uma rodada nova. Depois disso, preservar e atualizar o state existente.

## Bibliotecas auxiliares

- Uma única biblioteca principal por rodada.
- Auxiliares entram com escopo controlado e motivo objetivo.
- Auxiliares são registradas no state e no manifest apenas se consumidas.
- Se a auxiliar cobrir parcela grande da principal, recomendar rodada própria.

## Regras de profundidade de samples

| Complexidade | Mínimo de exemplos |
|---|---|
| 1-3 baixa | 1 |
| 4-6 média | 2 |
| 7-10 alta | 3 |

Sem máximo: explorar mais quando a complexidade justificar.

## Regras de blueprints

- Patterns com nota menor ou igual a 4: blueprint obrigatório.
- Patterns com nota entre 5 e 7: ao menos 50% devem ter blueprint.
- Patterns com nota maior ou igual a 8: não gerar por padrão.
- Nível: `não gerar | resumido | completo`. Pode mudar durante geração.

## Guides corporativos

A skill busca guides candidatos por eixos:
- **Universais**: arquitetura, integração API, auth, feedback/erro.
- **Por tecnologia**: roteamento, state, SSR, forms para Web/SPA; hooks e providers para React; modules e signals para Angular; composables para Vue; nav nativa e offline para mobile; tokens e a11y para design system.
- **Por contexto**: CRUD/data-grid, shell/bootstrap, testes, i18n, permissões, branding, conteúdo, navegação, dashboards.
- **Variações abertas**: buscar nos fontes padrões recorrentes não cobertos pelos eixos.

O humano seleciona quais guides quer a partir da lista completa.

## Recursos locais

### Protocolos

- `references/protocols/workflow.protocol.md`
- `references/protocols/components-summary.protocol.md`
- `references/protocols/visual-language.protocol.md`
- `references/protocols/ui-map.protocol.md`
- `references/protocols/patterns-output.protocol.md`
- `references/protocols/corporate-guides.protocol.md`
- `references/protocols/finalize.protocol.md`

### Templates

- `references/templates/state.template.yaml`

### Catálogos de patterns base

- `references/patterns/shell.pattern.md`
- `references/patterns/page.pattern.md`
- `references/patterns/ui_struct.pattern.md`
- `references/patterns/ui_nav.pattern.md`
- `references/patterns/ui_data.pattern.md`
- `references/patterns/ui_input.pattern.md`
- `references/patterns/ui_action.pattern.md`
- `references/patterns/ui_feedback.pattern.md`
- `references/patterns/ui_content.pattern.md`

### Catálogos de patterns condicionais por plataforma

- `references/patterns/ui_mobile.pattern.md`: ativar quando `target_platforms` incluir iOS, Android, Flutter, React Native ou MAUI mobile.
- `references/patterns/ui_desktop.pattern.md`: ativar quando `target_platforms` incluir Windows, macOS, Linux, Electron, Tauri, Flutter Desktop ou MAUI desktop.
