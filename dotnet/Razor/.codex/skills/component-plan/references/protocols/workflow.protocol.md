# Protocolo do Workflow de Component Plan

## Regras gerais

[INSTRUÇÃO] Ler e seguir estritamente as regras de `/references/rules/kernel.rules.md`.

[INSTRUÇÃO] Ler e seguir estritamente as regras de `/references/rules/workflow.rules.md`.

[INSTRUÇÃO] Ler e seguir estritamente as regras de `/references/rules/component-plan.rules.md`.

[INSTRUÇÃO] Ao ser escolhido um fluxo, fazer:
- quando escolhido **planejar-e-criar-spec**, seguir as instruções da seção `Fluxo planejar e criar spec`;
- quando escolhido **criar-a-partir-de-plano**, seguir as instruções da seção `Fluxo criar a partir de plano`.

[INSTRUÇÃO] Não seguir etapas de um fluxo não escolhido.

[INSTRUÇÃO] Executar o `Setup da rodada` após identificado o fluxo e antes de qualquer etapa.

## Escolha do fluxo

Quando a skill for acionada, avaliar a entrada do humano e identificar o fluxo seguindo estas regras:

1. usar o fluxo **planejar-e-criar-spec** quando:
- o humano quer planejar uma spec de componente;
- o humano quer criar uma spec de componente e não informou um plano já aprovado;
- o humano quer um componente novo em fluxo spec-first;
- o humano menciona `plan-spec`, `component-plan`, `crie uma spec`, `planeje a spec`, `quero um componente` ou equivalente.

2. usar o fluxo **criar-a-partir-de-plano** quando:
- o humano informa que o plano já está aprovado;
- existe `planning.md` no diretório da spec e o humano pede para criar os arquivos finais;
- o humano fornece um plano equivalente no chat e autoriza transformá-lo em spec.

3. quando não identificado:
- levantar o que foi entendido sobre o pedido;
- apresentar os fluxos atendidos pela skill;
- perguntar ao humano qual fluxo deve seguir.

4. quando o pedido estiver fora da abrangência da skill:
- informar que esta skill só planeja e cria specs;
- recomendar o próximo fluxo adequado;
- abandonar o uso desta skill sem carregar novos protocolos.

## Setup da rodada

[INSTRUÇÃO] Somente após fluxo identificado.

1. Identificar o alvo:
- nome humano do componente, pacote ou spec;
- slug em dash-case;
- se o alvo não estiver claro, consultar os documentos de roadmap do workspace quando existirem e apresentar recomendação curta;
- se ainda houver ambiguidade, perguntar ao humano.

2. Resolver diretório de trabalho:
- usar diretório explícito informado pelo humano; ou
- usar `.ai/specs/lib/{slug}/`.

3. Verificar artefatos existentes:
- se existir `planning.md`, avaliar se ele pode ser reutilizado;
- se existirem `requirements.md`, `design.md`, `tasks.md` ou `delivery.md`, perguntar antes de sobrescrever, salvo pedido explícito de recriação/refino.

### GATE WF.SETUP

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- fluxo identificado;
- alvo e slug identificados;
- diretório de trabalho resolvido;
- conflito com artefatos existentes tratado.

## Fluxo planejar e criar spec

[INSTRUÇÃO] Seguir etapa por etapa, avançar somente quando a atual for concluída.

### Etapa 1 - **plan-spec**

[INSTRUÇÃO] Somente após gate `WF.SETUP` satisfeito.

[INSTRUÇÃO] Leia, siga as instruções e execute passo a passo o protocolo `plan-spec.protocol.md`.

#### GATE WF.CP.PLAN

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- todos os gates do planejamento foram executados em ordem;
- decisões obrigatórias de componente foram fechadas ou registradas como GAP com hipótese/pendência;
- `planning.md` foi criado e persistido no diretório de trabalho;
- gate `PLAN.FINAL` satisfeito;
- próxima etapa delegada para `create-spec`.

### Etapa 2 - **create-spec**

[INSTRUÇÃO] Somente após gate `WF.CP.PLAN` satisfeito.

[INSTRUÇÃO] Leia, siga as instruções e execute passo a passo o protocolo `create-spec.protocol.md`.

#### GATE WF.CP.CREATE

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- `planning.md` foi usado como fonte primária;
- `requirements.md`, `design.md`, `tasks.md` e `delivery.md` foram criados e persistidos;
- os arquivos seguem os templates internos da skill;
- revisão local da spec foi executada e ajustes relevantes incorporados;
- gate `CREATE.FINAL` satisfeito.

### GATE WF.COMPONENT-PLAN

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- fluxo `planejar-e-criar-spec` executado em sequência;
- gates `WF.CP.PLAN` e `WF.CP.CREATE` satisfeitos;
- nenhum GAP bloqueante sem aprovação explícita.

### Finalização do fluxo

[INSTRUÇÃO] Somente após gate `WF.COMPONENT-PLAN` satisfeito.

[INSTRUÇÃO] Siga para seção final de `Finalização`.

## Fluxo criar a partir de plano

[INSTRUÇÃO] Seguir quando houver plano aprovado ou autorização explícita para usar o plano fornecido.

### Etapa única - **create-spec**

[INSTRUÇÃO] Leia, siga as instruções e execute passo a passo o protocolo `create-spec.protocol.md`.

#### GATE WF.CP.CREATE-FROM-PLAN

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- plano aprovado identificado;
- `requirements.md`, `design.md`, `tasks.md` e `delivery.md` criados e persistidos;
- revisão local da spec executada;
- gate `CREATE.FINAL` satisfeito.

### Finalização do fluxo criar a partir de plano

[INSTRUÇÃO] Somente após gate `WF.CP.CREATE-FROM-PLAN` satisfeito.

[INSTRUÇÃO] Siga para seção final de `Finalização`.

## Finalização

[INSTRUÇÃO] Informar sobre a conclusão da tarefa, dando um resumo do que foi realizado.

[INSTRUÇÃO] Informar o próximo passo recomendado:
- `implement lib-spec`, quando a spec estiver pronta para implementação;
- `refine lib-spec`, quando houver inconsistência ou decisão pendente;
- `create-library-project`, quando o design confirmar pacote novo e a spec estiver madura.
