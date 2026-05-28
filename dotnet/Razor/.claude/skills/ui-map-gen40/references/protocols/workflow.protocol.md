# Protocolo do Workflow de UI-MAP-GEN

## Regras gerais

[INSTRUÇÃO] Ler e seguir estritamente as regras de `/references/rules/kernel.rules.md`.

[INSTRUÇÃO] Ler e seguir estritamente as regras de `/references/rules/workflow.rules.md`.

[INSTRUÇÃO] Ao ser escolhido um fluxo, fazer:
- quando escolhido **gerar-ui-map** seguir as instruções da seção `Fluxo gerar ui-map`;
- quando escolhido **revisao** seguir as instruções da seção `Fluxo revisão`;
- quando escolhido **release** seguir as instruções da seção `Fluxo release`;

[INSTRUÇÃO] Não seguir etapas de um fluxo não escolhido.

[INSTRUÇÃO] Executar o `Setup da rodada` após identificado o fluxo e antes de qualquer etapa.

## Escolha do fluxo

Quando a skill for acionada, avaliar a entrada do humano e identificar o fluxo seguindo essas regras:

1. usar o fluxo **gerar-ui-map** quando:
- o humano quer avaliar uma biblioteca, repositório de código fonte ou documentação web.
- gerar ou criar ui-map.
- criar artefatos para mapear ui patterns a componentes de ui/telas.

2. usar o fluxo **revisao** quando:
- não estiver no meio de uma geração de ui-map.
- o humano quer uma análise/revisão de artefatos gerados, seja por arquivo em específico, diretório, ou etapa.
  - se for arquivo ou diretório, deve estar referenciando um diretório de trabalho do ui-map.
  - se não referenciar o diretório do ui-map, deve ser perguntado ao humano qual o diretório do ui-map.

3. usar o fluxo **release** quando:
- o humano quer lançar/liberar/publicar uma nova versão do ui-map já gerado.
  - se o humano não informar o diretório de trabalho do ui-map, deve ser perguntado qual é.

4. quando não identificado, não atende as regras de seleção de fluxo:
- em caso de ambiguidade questionar o humano sobre o que ele quer fazer:
  - levantar os pontos conhecidos
  - levantar os pontos de dúvida
  - criar perguntas necessárias para definição
- em caso de identificar o fluxo mas uma regra de negação ou bloqueio não permitir o fluxo:
  - informar ao humano os pontos conhecidos para escolha do fluxo
  - informar a violação que não permite a seleção do fluxo
  - se houver opções, apresentar as opções ao humano
  - questionar o humano sobre como seguir
- em caso de não identificar nenhum fluxo ou o humano pedir algo completamente fora da abrangência da skill:
  - levantar o que foi entendido sobre pedido do humano e apresentar a ele
  - apresentar os fluxos que a skill atender explicando cada um
  - solicitar que o humano escolha um fluxo para seguir
- em caso do humano insistir em pedidos fora dos fluxos da skill, abandone o uso da skill e não carregue nenhum protocolo, template, regra, ou arquivo de referência.

## Setup da rodada

[INSTRUÇÃO] Somente após fluxo identificado.

[INSTRUÇÃO] Regra de retomada para quando escolhido fluxo **gerar-ui-map**, definido diretório de trabalho e `state.yaml` existir, faça:
- leia `state.yaml`;
- identifique a `task` do `type` = `ui-map`;
- avalie a etapa atual baseada em `stage`; seção em `section`; item atual se aplicável em `current_item`; `gaps` e `satisfied_gates`;
- avalie a próxima ação em `next_action`;
- inicie a execução do fluxo na etapa atual identificada na `task` do `state.yaml`;
- avalie se já existe o documento a ser gerado na etapa e gates satisfeitos;
- prossiga com a próxima ação.

## Fluxo gerar ui-map

[INSTRUÇÃO] Seguir etapa por etapa, avançar somente quando a atual for concluída.

### Etapa 1 - **project-summary**

[INSTRUÇÃO] Leia, siga as instruções, execute passa a passo o protocolo `project-summary.protocol.md`.

#### GATE WF.UI.PS

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- Diretórios de trabalho do ui-map criado, state.yaml criado e persistido.
- Artefatos `components.summary.md`, `structure.md` e `ui-guide.md` criados e persistidos.
- Gate de finalização do protocolo `PS.FINAL` satisfeito.
- Próxima etapa delegada pelo protocolo.

### Etapa 2 - **visual-language**

[INSTRUÇÃO] Somente após gate `WF.UI.PS` satisfeito.

[INSTRUÇÃO] Leia, siga as instruções, execute passa a passo o protocolo `visual-language.protocol.md`.

#### GATE WF.UI.VL

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- Artefatos `visual.language.md`, e `visual.map.md` criados e persistidos.
- Gate de finalização do protocolo `VL.FINAL` satisfeito.
- Próxima etapa delegada pelo protocolo.

### Etapa 3 - **ui-map**

[INSTRUÇÃO] Somente após gate `WF.UI.VL` satisfeito.

[INSTRUÇÃO] Leia, siga as instruções, execute passa a passo o protocolo `ui-map.protocol.md`.

#### GATE WF.UI.MAP

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- Artefatos criados e persistidos em `ui-map/`.
- Todos patterns analisados contra os componentes.
- Gate de finalização do protocolo `MAP.FINAL` satisfeito.
- Próxima etapa delegada pelo protocolo.

### Etapa 4 - **create-samples**

[INSTRUÇÃO] Somente após gate `WF.UI.MAP` satisfeito.

[INSTRUÇÃO] Leia, siga as instruções, execute passa a passo o protocolo `create-samples.protocol.md`.

#### GATE WF.UI.CS

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- Artefatos criados e persistidos em `samples\`.
- Todos componentes analisados e exemplos criados.
- Gate de finalização do protocolo `CS.FINAL` satisfeito.
- Próxima etapa delegada pelo protocolo.

### Etapa 5 - **patterns-blueprints**

[INSTRUÇÃO] Somente após gate `WF.UI.CS` satisfeito.

[INSTRUÇÃO] Leia, siga as instruções, execute passa a passo o protocolo `patterns-blueprints.protocol.md`.

#### GATE WF.UI.PB

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- Artefato `blueprints.table.md` criado e persistido em `patterns-blueprints/`.
- Artefatos de blueprint criados e persistidos em `patterns-blueprints/`.
- Todos patterns triados e os marcados para gerar blueprint com seus arquivos criados.
- Gate de finalização do protocolo `PB.FINAL` satisfeito.
- Próxima etapa delegada pelo protocolo.

### Etapa 6 - **corporate-rules**

[INSTRUÇÃO] Somente após gate `WF.UI.PB` satisfeito.

[INSTRUÇÃO] Leia, siga as instruções, execute passa a passo o protocolo `corporate-rules.protocol.md`.

#### GATE WF.UI.CR

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- Artefato `corporate.rules.md` criado e persistido em `rules\`.
- Artefatos de regras criados e persistidos em `rules\`.
- Gate de finalização do protocolo `CR.FINAL` satisfeito.
- Próxima etapa delegada pelo protocolo.

### Etapa 7 - **patterns-orientations**

[INSTRUÇÃO] Somente após gate `WF.UI.CR` satisfeito.

[INSTRUÇÃO] Leia, siga as instruções, execute passa a passo o protocolo `patterns-orientations.protocol.md`.

#### GATE WF.UI.PO

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- Artefato `patterns.orientations.md` criado e persistido.
- Gate de finalização do protocolo `PO.FINAL` satisfeito.
- Próxima etapa delegada pelo protocolo.

### Etapa 8 - **finalize**

[INSTRUÇÃO] Somente após gate `WF.UI.PO` satisfeito.

[INSTRUÇÃO] Leia, siga as instruções, execute passa a passo o protocolo `finalize-ui-map.protocol.md`.

#### GATE WF.UI.FIM

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- Artefato `manifest.md` criado e persistido.
- Gate de finalização do protocolo `FIM.FINAL` satisfeito.
- Processo dado como finalizado pelo protocolo.

### GATE WF.UI-MAP

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- Todas etapas do fluxo executadas na sequência e concluídas.
- Todos gates das etapas deste fluxo satisfeitos.
- O `state.yaml` marcado como processo de ui-map finalizado.

### Finalização do ui-map

[INSTRUÇÃO] Somente após gate `WF.UI-MAP` satisfeito.

[INSTRUÇÃO] Siga para seção final de `Finalização`.

## Fluxo revisão

[INSTRUÇÃO] Fluxo em desenvolvimento, informar ao humano que ainda não há nada o que fazer.

### GATE WF.REVIEW

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- {em desenvolvimento}

### Finalização da revisão

[INSTRUÇÃO] Somente após gate `WF.REVIEW` satisfeito.

[INSTRUÇÃO] Siga para seção final de `Finalização`.

## Fluxo release

[INSTRUÇÃO] Fluxo em desenvolvimento, informar ao humano que ainda não há nada o que fazer.

### GATE WF.RELEASE

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- {em desenvolvimento}

### Finalização do release

[INSTRUÇÃO] Somente após gate `WF.RELEASE` satisfeito.

[INSTRUÇÃO] Siga para seção final de `Finalização`.

## Finalização

[INSTRUÇÃO] Somente após um dos gates satisfeitos: `WF.UI-MAP` ou `WF.REVIEW` ou `WF.RELEASE`.

[INSTRUÇÃO] Informe sobre a conclusão da tarefa, dando um resumo do que foi realizado.
