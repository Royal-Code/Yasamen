# Workflow — Orquestração do ui-map-gen

## Finalidade

Este protocolo orquestra a execução completa do ui-map-gen. Ele resolve dependências iniciais, sequencia etapas, delega execução aos protocolos específicos e mantém o estado do progresso.

## REGRAS GERAIS

[INSTRUÇÃO] Os arquivos gerados são destinados para uso da IA na skill screen-designer. Devem ser escritos com foco no entendimento, instrução e uso da IA para gerar telas bonitas e coerentes seguindo a linguagem visual e padrões corporativos.

[INSTRUÇÃO] Para esta análise, não se basear em análises de outras bibliotecas. Não ler outros arquivos de mapeamento que possam existir em `.ai/ui-map/` ou ler arquivos de outra lib.

[INSTRUÇÃO] Reler o arquivo da SKILL, o kernel, este protocolo (workflow), e o protocolo da etapa corrente a cada início de etapa, a cada validação de gate e a cada verificação de checklist. Isso garante que as regras e instruções não sejam compactadas ou esquecidas.

[INSTRUÇÃO] Não fazer duas etapas ao mesmo tempo. Executar uma etapa por vez, respeitar gates e checklists, e pedir aprovação explícita do humano quando exigido.

[INSTRUÇÃO] Ao concluir uma etapa: apresentar um resumo do que foi feito ao humano; pedir avaliação e perguntar se precisa alterar ou melhorar algo; falar sobre a próxima etapa e o que será feito; perguntar se pode seguir.

[INSTRUÇÃO] Só dar como concluída uma etapa se o GATE e o checklist da etapa estiverem completamente satisfeitos.

[INSTRUÇÃO] Quando o GATE ou checklist não estiver satisfeito:
- Informar ao humano os problemas e GAPs não satisfeitos.
- Elaborar perguntas para tentar resolver os problemas e satisfazer o checklist.
- Quando não for possível satisfazer, informar ao humano e pedir permissão para prosseguir.
- Só prosseguir com permissão explícita.

[INSTRUÇÃO] Só seguir para outra etapa após a anterior estar concluída, o resumo apresentado ao humano, e ele ter confirmado para prosseguir.

[INSTRUÇÃO] Antes de seguir a próxima etapa, atender a pedidos de alterações ou melhorias quando o humano pedir. Após feitas as mudanças: resumir as alterações e apresentar ao humano; perguntar se quer mais alguma alteração; perguntar novamente se pode prosseguir.

---

## SEQUÊNCIA DE ETAPAS

```
workflow → components-summary → visual-language → ui-map → patterns-output → corporate-guides → finalize
```

### Etapas opcionais
- `styles-map` (sub-etapa de visual-language) — pular quando estilos não forem aplicáveis à tecnologia.
- `corporate-guides` — pular quando o humano não pedir e não houver valor claro detectado.

---

## INSTRUÇÕES DE INICIALIZAÇÃO

[INSTRUÇÃO] Executar os passos abaixo na ordem, um a um, antes de iniciar a primeira etapa de geração.

### Passo 1: Resolver diretório de trabalho

1. Se o humano informar diretório explícito, usar.
2. Se não informar, usar convenção: `.ai/ui-map/{slug}/` onde `slug` = nome da biblioteca em dash-case.
3. Criar diretório se não existir.
4. Criar subpastas `samples/` e `patterns-blueprint/`.

### Passo 2: Criar ou carregar state

**Se `state.yaml` NÃO existir (rodada nova):**
1. Criar a partir do template `state.template.yaml`.
2. Preencher `ui_map_id`, `directory`.
3. Definir `current_stage: workflow`.
4. Todas as stages ficam `pending`.

**Se `state.yaml` JÁ existir (retomada):**
1. Carregar e validar consistência.
2. Verificar se cada stage marcada `done` tem artefato correspondente no diretório.
3. Se inconsistente: registrar blocker, perguntar ao humano como proceder (corrigir, refazer ou abortar).
4. Se válido: retomar de `current_stage` / `current_item`.
5. Apresentar ao humano o estado encontrado e pedir confirmação para continuar de onde parou.

### Passo 3: Resolver biblioteca principal

[INSTRUÇÃO] Perguntar ou confirmar com o humano:
- Nome da biblioteca principal.
- Tipo de fonte: `repo` (código local) ou `web` (documentação pública).
- Versão conhecida (ou `desconhecida`).
- Plataforma(s)-alvo: `web` | `mobile` | `desktop` | combinação.

[INSTRUÇÃO] Garantir ao menos uma fonte acessível:
- Se `repo`: o humano deve indicar paths de código, docs, exemplos e stories disponíveis.
- Se `web`: o humano deve indicar URIs da documentação, ou a skill pesquisa e apresenta o que encontrou para validação.

[INSTRUÇÃO] Validar que a fonte é realmente acessível (ler diretório ou acessar URI).

[INSTRUÇÃO] Registrar em `library` no state: name, slug, source_kind, version, target_platforms, sources.

### Passo 4: Bibliotecas auxiliares (quando aplicável)

Quando o humano declarar biblioteca auxiliar:
1. Registrar em `auxiliary_libraries`: name, purpose, scope, source_ref, status=pending.
2. A auxiliar só será analisada no nível necessário para os componentes/patterns declarados.
3. Se a auxiliar começar a cobrir parcela grande da biblioteca principal, recomendar rodada própria.

### Passo 5: Criar `sources.inventory.md`

[INSTRUÇÃO] Criar arquivo `sources.inventory.md` no diretório de trabalho registrando todas as fontes conhecidas: biblioteca principal, auxiliares e quaisquer fontes corporativas/contextuais já declaradas.

---

## INSTRUÇÕES DE DELEGAÇÃO

[INSTRUÇÃO] Ao transitar para uma etapa, executar exatamente esta sequência:

1. **Reler** o kernel (se disponível), este workflow, e o protocolo da etapa-alvo.
2. **Atualizar** `current_stage` no state para o nome da etapa.
3. **Atualizar** `next_action` no state com descrição curta da próxima ação.
4. **Executar** o protocolo da etapa seguindo suas instruções internas na íntegra.
5. **Validar** o GATE e checklist da etapa antes de apresentar ao humano.
6. **Apresentar** resumo ao humano, pedir avaliação, perguntar se pode prosseguir.
7. **Repetir** do passo 1 para a próxima etapa.

### Tabela de delegação

| Etapa | Protocolo | Artefatos produzidos |
|-------|-----------|---------------------|
| components-summary | `components-summary.protocol.md` | `components.summary.md`, opcional: `structure.md`, `styles.guide.md` |
| visual-language | `visual-language.protocol.md` | `visual.language.md`, opcional: `styles.map.md` |
| ui-map | `ui-map.protocol.md` | `ui-map.md` |
| patterns-output | `patterns-output.protocol.md` | `samples/*.sample.md`, `components.table.md`, `patterns-blueprint/*.blueprint.md`, `blueprints.table.md`, `patterns.map.md` |
| corporate-guides | `corporate-guides.protocol.md` | guides variáveis |
| finalize | `finalize.protocol.md` | `manifest.md`, `sources.inventory.md` atualizado |

---

## INSTRUÇÕES DE TRANSIÇÃO ENTRE ETAPAS

[INSTRUÇÃO] Ao concluir uma etapa com aprovação do humano:
1. Marcar a stage como `done` no state.
2. Atualizar `current_stage` para a próxima etapa da sequência.
3. Atualizar `next_action`.
4. Se houver gaps críticos não resolvidos: registrar em `open_gaps` no state.

[INSTRUÇÃO] Antes de iniciar a próxima etapa, verificar que:
- O state está salvo e consistente.
- Todos os artefatos da etapa anterior estão persistidos.
- O humano deu aprovação explícita.

---

## REGISTROS DE FONTES

### Tipos de fonte e precedência

| Tipo | Descrição | Precedência |
|------|-----------|-------------|
| Principal | Biblioteca sendo mapeada | 1 (mais alta) |
| Auxiliar | Biblioteca complementar com escopo controlado | 2 |
| Corporativa | Docs/regras corporativas do projeto | 3 |
| Contextual | Exemplos, demos, playgrounds | 4 (mais baixa) |

### Regras de conflito
- Conflito entre fontes resolve por precedência.
- A fonte principal é obrigatória — sem ela a rodada não inicia.
- Fontes corporativas e contextuais podem ser adicionadas a qualquer momento.

---

## GATE WORKFLOW

- Diretório raiz resolvido e criado.
- Nome da biblioteca identificado.
- Tipo de fonte resolvido (`repo` ou `web`).
- Ao menos uma fonte validada como acessível.
- Arquivo de estado criado ou carregado com consistência.
- `sources.inventory.md` criado.
- Resumo do estado inicial apresentado ao humano.
- Autorização explícita para iniciar a primeira etapa de geração.

### Checklist
- Estrutura mínima do state.yaml preenchida e consistente.
- Diretórios e subpastas criados.
- Fontes validadas como acessíveis.
- Humano confirmou biblioteca, tipo de fonte e plataforma-alvo.
