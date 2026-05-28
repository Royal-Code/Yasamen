# UIP-SYSTEM-BACKGROUND_PROGRESS - Background Progress

## Definição

**Categoria**: Sistema & Host

**Definição curta**: Comunicação de operação longa, progresso em background, pausa, erro, conclusão e retomada.

**Objetivo estrutural**: Permitir que operações longas continuem ou sejam acompanhadas fora do fluxo imediato sem perder estado, confiança ou controle.

**Não confundir com**: UIP-FEEDBACK-LOADING_STATE (carregamento local), UIP-SYSTEM-DOCK_INTEGRATION (integração com dock), UIP-SYSTEM-TRAY (presença em background), UIP-FEEDBACK-TOAST_ALERT (conclusão simples).

**Nível composicional possível**: Root, Container, Leaf

## Decisão

**Quando usar**: quando upload, download, export, import, build, sync, processamento ou geração leva tempo; quando o usuário pode sair da tela; quando progresso, cancelamento, retry ou retomada precisam ser visíveis.

**Quando evitar**: quando a ação é instantânea; quando loading local basta; quando a operação não pode continuar fora da tela; quando o progresso não é mensurável e não há valor em expor o background.

**Alternativas próximas**: UIP-FEEDBACK-LOADING_STATE (carregamento local), UIP-FEEDBACK-TOAST_ALERT (conclusão simples), UIP-SYSTEM-DOCK_INTEGRATION (progresso no dock), UIP-SYSTEM-NOTIFICATION_CENTER (histórico de eventos), UIP-SYSTEM-TRAY (presença em background).

**Sinais de escolha**:
- operação longa ou fila de tarefas
- progresso determinado ou indeterminado
- cancelamento e retry
- sair da tela sem perder a operação
- a conclusão precisa notificar

**Grau de Rigidez**: Médio — comunicação de operação longa em background é invariante; indicação, retomada e cancelamento variam.

## Composição

**Zonas usuais**: Cabeçalho, Overlay.

**Variantes reconhecidas**: progresso determinado; progresso indeterminado; fila de operações; operação pausável; operação cancelável; retry; retomada após restart do app.

## Compatibilidade com Shell Patterns

**Compatibilidade Primária**: SHP-WORKSPACE_ADMIN, SHP-STUDIO_WORKBENCH, SHP-MEDIA_CONTENT.

**Compatibilidade Secundária**: SHP-COMMUNICATION, SHP-TRANSACTIONAL_COMMERCE, SHP-DASHBOARD_ANALYTICS.

**Incompatibilidades explícitas**: experiências sem operações longas ou background.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-FORM, PP-WIZARD, PP-CANVAS, PP-DETAIL.

**Compatibilidade Secundária**: PP-CATALOG, PP-LIST-DETAIL, PP-DASHBOARD, PP-MAP, PP-CALENDAR.

**Incompatibilidades explícitas**: ações puramente locais e instantâneas.

## Estrutura e Transição

**Estrutura Desktop**: status persistente no shell, fila ou notification center, com progresso, cancelar, retry, abrir detalhe e conclusão.

**Estrutura Mobile**: pode usar foreground ou background task, notificação do sistema, status no app ou fila local conforme restrições do SO.

**Regra de Transição**: preservar a continuidade da operação ao navegar ou suspender o app quando a plataforma permitir. Separar progresso local, progresso em background e conclusão.

## Estados

**Estados próprios**: queued, running, progresso determinado, progresso indeterminado, paused, cancelling, cancelled, completed, failed, retrying, resumed.

**Reação a estados da página**: sair da página não perde a operação quando o background é suportado. `error` → falha recuperável com retry. A conclusão ou falha após o usuário sair é comunicada por UIP-FEEDBACK-TOAST_ALERT ou UIP-SYSTEM-NOTIFICATION_CENTER.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: validar service worker, uploads, downloads, abort e retry, visibility change e persistência.

**Adaptação Mobile nativo**: respeitar restrições de background, notificações, foreground service, retry e retomada após kill ou restart.

**Adaptação Desktop nativo**: integrar taskbar ou dock, tray, fila, notificações e persistência de jobs.
