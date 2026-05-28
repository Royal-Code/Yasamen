# UIP-SYSTEM-NOTIFICATION_CENTER - Notification Center

## Definição

**Categoria**: Sistema & Host

**Definição curta**: Agregação, leitura e ação sobre notificações do sistema ou produto em uma área persistente.

**Objetivo estrutural**: Centralizar eventos, alertas, mensagens, tarefas pendentes e resultados assíncronos para consulta, triagem e ação posterior.

**Não confundir com**: UIP-FEEDBACK-TOAST_ALERT (feedback efêmero), PP-CONVERSATION (inbox conversacional), PP-FEED (feed de conteúdo), notificação nativa isolada (fora do catálogo).

**Nível composicional possível**: Root, Container

## Decisão

**Quando usar**: quando o produto gera múltiplos eventos assíncronos; quando notificações precisam ser lidas depois; quando há ações por notificação; quando badges, agrupamento, leitura e histórico são necessários.

**Quando evitar**: quando feedback efêmero basta; quando notificações são raras; quando o produto já possui inbox dedicada com semântica própria; quando eventos não exigem retenção.

**Alternativas próximas**: UIP-FEEDBACK-TOAST_ALERT (feedback efêmero), PP-FEED (feed de atividade), SHP-COMMUNICATION (shell de inbox conversacional).

**Sinais de escolha**:
- badge de não lidos
- lista de notificações com marcar como lido
- ações rápidas por notificação
- agrupamento por tipo
- preferências de notificação
- eventos persistentes

**Grau de Rigidez**: Médio — agregação e ação sobre notificações é invariante; agrupamento, prioridade e descarte variam.

## Composição

**Zonas usuais**: Cabeçalho, Overlay.

**Variantes reconhecidas**: notification dropdown; notification drawer; activity center; system inbox; entrada de preferências de notificação; notificações agrupadas.

## Compatibilidade com Shell Patterns

**Compatibilidade Primária**: SHP-WORKSPACE_ADMIN, SHP-COMMUNICATION, SHP-DASHBOARD_ANALYTICS.

**Compatibilidade Secundária**: SHP-TRANSACTIONAL_COMMERCE, SHP-MEDIA_CONTENT, SHP-STUDIO_WORKBENCH, SHP-PORTAL.

**Incompatibilidades explícitas**: experiências públicas simples sem eventos assíncronos persistentes.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: Todos os Page Patterns.

**Compatibilidade Secundária**: Nenhuma.

**Incompatibilidades explícitas**: não substitui PP-CONVERSATION quando o objeto principal é troca de mensagens.

## Estrutura e Transição

**Estrutura Desktop**: badge no shell, painel, dropdown ou drawer com lista, filtros simples, estado lido ou não lido, ações e navegação para o destino.

**Estrutura Mobile**: pode coexistir com push notifications do SO, tab de notificações, tela dedicada ou painel de shell conforme arquitetura.

**Regra de Transição**: preservar persistência, leitura posterior, ação e deep link. Toasts podem anunciar eventos, mas o centro mantém o histórico quando a retenção é necessária.

## Estados

**Estados próprios**: vazio, com não lidas, todas lidas, carregando, agrupado, filtrado, item acionável, item expirado, erro de carregamento.

**Reação a estados da página**: eventos globais aparecem independentemente da página. `no-permission` → notificações restritas ocultas. Sessão expirada (UIP-SYSTEM-AUTH_SESSION) → centro bloqueado ou reduzido.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir dropdown, drawer, página dedicada, badge, permissões de push e deep links.

**Adaptação Mobile nativo**: integrar push notification, badges, deep links e tela ou painel de notificações dentro do app.

**Adaptação Desktop nativo**: pode integrar tray, dock ou taskbar, notificações do SO e painel interno persistente.
