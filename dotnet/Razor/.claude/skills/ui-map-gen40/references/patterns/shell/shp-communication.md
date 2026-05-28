# SHP-COMMUNICATION - Communication

## Definição

**Definição curta**: Shell orientado a conversa, inbox, threads e comunicação em tempo real.

**Objetivo estrutural**: Sustentar troca contínua de mensagens, contexto conversacional e atualização frequente.

**Interação dominante**: Comunicacional

**Não confundir com**: SHP-MEDIA_CONTENT (feed e consumo de conteúdo), SHP-WORKSPACE_ADMIN (operação multi-módulo), SHP-PORTAL (conteúdo público).

## Decisão

**Sinais de escolha**:
- thread como centro da tarefa
- presença de inbox
- atualização em tempo real
- histórico de mensagens
- necessidade de contexto conversacional persistente

**Limites**: não é adequado quando a conversa é apenas um recurso auxiliar e não a estrutura principal da experiência.

**Grau de Rigidez**: Alto — inbox, thread e composição são invariantes; layout de painéis e detalhes visuais variam por plataforma.

## Navegação e Estrutura

**Modelo de navegação global**: inbox, lista de threads, áreas de conversa e contexto lateral complementar.

**Estrutura Desktop**: lista de conversas e thread ativa com contexto complementar simultâneo.

**Estrutura Mobile**: alternância entre inbox e thread ativa, priorizando foco único.

**Regra de transição**: a simultaneidade em Desktop evolui para sequência navegável em Mobile.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-CONVERSATION, PP-LIST-DETAIL, PP-FEED.

**Compatibilidade Secundária**: PP-DETAIL, PP-SETTINGS.

**Incompatibilidades explícitas**: PP-LANDING como padrão dominante do shell.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir fallback entre split panel, stack e regiões com scroll independente.

**Adaptação Mobile nativo**: usar UIP-NAV-NAV_STACK, UIP-NAV-TAB_BAR quando houver destinos raiz, UIP-INTERACTION-PULL_REFRESH, UIP-SYSTEM-OFFLINE_SYNC e UIP-SYSTEM-APP_LIFECYCLE quando aplicável.

**Adaptação Desktop nativo**: pode ativar UIP-SYSTEM-TRAY, UIP-SYSTEM-DOCK_INTEGRATION, UIP-INTERACTION-KEYBOARD_FLOW e notificações de background.
