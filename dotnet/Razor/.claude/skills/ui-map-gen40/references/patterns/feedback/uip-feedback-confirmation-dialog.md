# UIP-FEEDBACK-CONFIRMATION_DIALOG - Confirmation Dialog

## Definição

**Categoria**: Feedback & Estado

**Definição curta**: Confirmação modal de ação arriscada, irreversível ou operacionalmente sensível.

**Objetivo estrutural**: Solicitar decisão explícita antes de executar ação com impacto relevante, risco de perda, irreversibilidade ou efeito operacional sensível.

**Não confundir com**: UIP-FEEDBACK-TOAST_ALERT (feedback informativo), UIP-FEEDBACK-ERROR_STATE (falha), UIP-ACTION-ACTION_BAR (execução direta).

**Nível composicional possível**: Leaf

## Decisão

**Quando usar**: quando a ação tem impacto irreversível ou risco elevado; quando a decisão precisa ser explícita antes de executar; quando o usuário deve entender o impacto; quando desfazer não é possível ou não é suficiente.

**Quando evitar**: quando a ação é reversível ou de baixo risco; quando undo, soft-delete ou restauração posterior resolvem melhor; quando o feedback deve acontecer depois da ação; quando a confirmação seria fricção desnecessária.

**Alternativas próximas**: UIP-FEEDBACK-TOAST_ALERT (feedback reversível com undo), PP-WIZARD (revisão final de fluxo).

**Sinais de escolha**:
- existe risco real ou irreversibilidade
- a interface precisa bloquear até a decisão
- há distinção clara entre confirmar e cancelar
- o impacto precisa ser lido antes da execução
- permissões, custos ou dados críticos estão envolvidos

**Grau de Rigidez**: Alto — confirmação bloqueante para ação arriscada é invariante; mensagem, consequência e ações variam.

## Composição

**Zonas usuais**: Overlay.

**Variantes reconhecidas**: confirmação destrutiva simples; confirmação com resumo de impacto; confirmação digitada; confirmação inline para risco moderado; confirmação com alternativa de undo.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: Todos os Page Patterns.

**Compatibilidade Secundária**: Nenhuma.

**Incompatibilidades explícitas**: não usar para ações reversíveis, frequentes e de baixo risco quando undo ou feedback posterior for suficiente.

## Estrutura e Transição

**Estrutura Desktop**: confirmação bloqueante com título, descrição do impacto, ação de confirmação, cancelamento e estado de processamento após confirmar.

**Estrutura Mobile**: modal, sheet ou confirmação nativa com clareza equivalente para impacto, confirmação e cancelamento.

**Regra de Transição**: modal centrado → variante compacta touch-friendly ou nativa. A inteligibilidade da decisão, o cancelamento e a distinção da ação de maior risco são preservados.

## Estados

**Estados próprios**: aberto aguardando decisão, confirmado, cancelado, processando após confirmação, falha após confirmação, fechado.

**Reação a estados da página**: bloqueia a interação com o escopo afetado. `loading` aparece após a confirmação enquanto processa. `error` comunica falha após confirmar.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: controlar foco, escape e cancelamento, estado de processamento e comunicação do resultado.

**Adaptação Mobile nativo**: usar modal, alert ou sheet conforme a plataforma e o risco; botões claros em touch e safe areas.

**Adaptação Desktop nativo**: pode usar diálogo nativo quando a operação envolve arquivo, permissão do sistema ou recurso do host.
