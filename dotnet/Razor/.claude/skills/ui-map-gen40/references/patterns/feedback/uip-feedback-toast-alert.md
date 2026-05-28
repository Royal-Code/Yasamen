# UIP-FEEDBACK-TOAST_ALERT - Toast / Alert

## Definição

**Categoria**: Feedback & Estado

**Definição curta**: Feedback não bloqueante sobre resultado de ação ou evento do sistema, em forma temporária, contextual ou persistente.

**Objetivo estrutural**: Notificar o usuário de resultado de ação, aviso ou evento sem substituir a estrutura principal nem bloquear a tarefa em curso.

**Não confundir com**: UIP-FEEDBACK-ERROR_STATE (substitui conteúdo), UIP-FEEDBACK-CONFIRMATION_DIALOG (exige decisão prévia), UIP-FEEDBACK-EMPTY_STATE (sem evento disparador).

**Nível composicional possível**: Leaf

## Decisão

**Quando usar**: quando o sistema precisa confirmar, avisar ou sinalizar algo sem bloquear a tarefa; quando o feedback está ligado a uma ação concluída ou evento contextual; quando a mensagem deve ser global ou local sem substituir a estrutura principal; quando uma ação reversível pode oferecer undo.

**Quando evitar**: quando a falha exige substituição do conteúdo ou recuperação explícita; quando a interação exige decisão prévia; quando a mensagem precisa permanecer como conteúdo primário; quando a mensagem é crítica demais para desaparecer sozinha.

**Alternativas próximas**: UIP-FEEDBACK-ERROR_STATE (falha que substitui conteúdo), UIP-FEEDBACK-CONFIRMATION_DIALOG (decisão prévia), UIP-SYSTEM-NOTIFICATION_CENTER (histórico de notificações).

**Sinais de escolha**:
- a tarefa principal pode continuar
- o feedback é complementar e não estrutural
- a mensagem pode ser efêmera ou contextual
- não há necessidade de bloquear a interface
- undo ou ação secundária curta resolve melhor que confirmação prévia

**Grau de Rigidez**: Médio — feedback não bloqueante e temporário é invariante; posição, duração, ação e severidade variam.

## Composição

**Zonas usuais**: Overlay, Cabeçalho, Conteúdo.

**Variantes reconhecidas**: toast temporário; snackbar com ação; alert inline ou contextual persistente; banner de aviso; entrada em notification center.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: Todos os Page Patterns.

**Compatibilidade Secundária**: Nenhuma.

**Incompatibilidades explícitas**: não substitui UIP-FEEDBACK-CONFIRMATION_DIALOG para ações que exigem confirmação prévia e não são reversíveis; não substitui UIP-FEEDBACK-ERROR_STATE quando a falha impede o uso da zona.

## Estrutura e Transição

**Estrutura Desktop**: feedback global ou local com mensagem, tipo de evento, fechar opcional e ação secundária curta quando fizer sentido.

**Estrutura Mobile**: variante não bloqueante equivalente ao contexto — toast compacto, snackbar, faixa contextual ou alerta inline.

**Regra de Transição**: a semântica do feedback é preservada. Posição, persistência e modo de apresentação variam conforme escopo global ou local, risco da mensagem e plataforma.

## Estados

**Estados próprios**: sucesso, aviso, erro não bloqueante, informação, persistente, temporário, com ação, a desaparecer, empilhado, lido.

**Reação a estados da página**: independente do estado principal da página. Aparece após ação ou evento; respeita modais ativos, foco, leitor de tela e operações em progresso.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir entre toast, snackbar, alert inline, banner e notification center conforme escopo e persistência.

**Adaptação Mobile nativo**: respeitar padrões de snackbar, toast e alerta da plataforma; evitar colisão com teclado, navegação inferior e safe areas.

**Adaptação Desktop nativo**: pode integrar com o notification center do sistema quando o app está em background; dentro da janela, manter o escopo claro.
