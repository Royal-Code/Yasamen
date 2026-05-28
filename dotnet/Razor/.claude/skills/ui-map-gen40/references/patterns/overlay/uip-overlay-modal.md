# UIP-OVERLAY-MODAL - Modal

## Definição

**Categoria**: Overlay & Superfície Temporária

**Definição curta**: Superfície bloqueante para tarefa, decisão ou conteúdo temporário que exige foco antes de retornar à tela.

**Objetivo estrutural**: Interromper temporariamente a interação com a página para concentrar o usuário em uma tarefa, decisão, formulário curto ou informação de prioridade alta.

**Não confundir com**: UIP-FEEDBACK-CONFIRMATION_DIALOG (confirmação específica), UIP-OVERLAY-BOTTOM_SHEET (superfície deslizante), UIP-OVERLAY-POPOVER (superfície contextual leve), página completa (fora do catálogo).

**Nível composicional possível**: Container

## Decisão

**Quando usar**: quando a interação precisa bloquear o escopo atrás; quando a tarefa é curta e autocontida; quando o usuário deve concluir, cancelar ou fechar antes de continuar; quando a superfície temporária não justifica rota ou tela própria.

**Quando evitar**: quando a tarefa exige navegação profunda, múltiplas etapas longas ou estado persistente; quando o conteúdo é apenas ajuda leve; quando um painel inline, drawer ou popover preserva melhor o contexto; quando bloquear a tela atrapalha a tarefa principal.

**Alternativas próximas**: UIP-FEEDBACK-CONFIRMATION_DIALOG (confirmação de ação), UIP-OVERLAY-BOTTOM_SHEET (superfície deslizante), UIP-OVERLAY-DRAWER (painel lateral), UIP-OVERLAY-POPOVER (superfície contextual leve).

**Sinais de escolha**:
- foco exclusivo necessário
- decisão ou tarefa curta com cancelamento explícito
- retorno ao contexto anterior
- conteúdo atrás deve ficar indisponível enquanto o modal está aberto

**Grau de Rigidez**: Alto — superfície bloqueante com foco exclusivo é invariante; tamanho, conteúdo e ações variam.

## Composição

**Zonas usuais**: Overlay.

**Variantes reconhecidas**: modal de tarefa; modal de formulário curto; modal informativo; modal fullscreen em mobile; nested modal apenas quando inevitável.

**UI Patterns tipicamente contidos**: UIP-CONTENT-CONTENT_HEADER, UIP-INPUT-FORM_FIELD_GROUP, UIP-ACTION-ACTION_BAR, UIP-FEEDBACK-LOADING_STATE, UIP-FEEDBACK-ERROR_STATE.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: Todos os Page Patterns.

**Compatibilidade Secundária**: Nenhuma.

**Incompatibilidades explícitas**: não usar como substituto de fluxo longo, navegação principal, wizard complexo ou página de detalhe persistente.

## Estrutura e Transição

**Estrutura Desktop**: superfície central ou contextual bloqueante, com título, conteúdo, ações primárias e secundárias e mecanismo claro de fechamento.

**Estrutura Mobile**: modal compacto, fullscreen modal ou sheet equivalente conforme complexidade e guideline da plataforma.

**Regra de Transição**: preservar bloqueio, foco, ação primária, cancelamento e retorno ao contexto. Em mobile, pode virar fullscreen quando o conteúdo exigir espaço.

## Estados

**Estados próprios**: fechado, aberto, validando, processando, com erro, com alterações pendentes, fechando.

**Reação a estados da página**: bloqueia a interação com o escopo atrás. `loading` e `error` internos pertencem ao conteúdo do modal. Modal ativo pode limitar command palette e atalhos globais.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: controlar foco, scroll, escape e cancelamento, backdrop, aria semantics e retorno ao elemento originador.

**Adaptação Mobile nativo**: escolher entre modal, fullscreen modal ou sheet conforme tamanho e criticidade; considerar teclado, safe areas e gesto de dismiss.

**Adaptação Desktop nativo**: pode usar diálogo nativo quando a operação envolve arquivos, permissões ou recursos do host.
