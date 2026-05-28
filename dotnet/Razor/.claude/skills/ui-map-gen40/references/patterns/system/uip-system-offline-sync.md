# UIP-SYSTEM-OFFLINE_SYNC - Offline Sync

## Definição

**Categoria**: Sistema & Host

**Definição curta**: Indicação de conectividade, sincronização pendente, conflitos e dados locais.

**Objetivo estrutural**: Comunicar estado de conexão e sincronização para permitir uso confiável mesmo com dados locais, fila pendente ou conflitos.

**Não confundir com**: UIP-FEEDBACK-LOADING_STATE (carregamento pontual), UIP-FEEDBACK-ERROR_STATE (falha isolada), UIP-SYSTEM-BACKGROUND_PROGRESS (operação longa), cache implícito sem feedback (fora do catálogo).

**Nível composicional possível**: Root, Container, Leaf

## Decisão

**Quando usar**: quando o app suporta uso offline; quando operações podem ser enfileiradas localmente; quando conflitos de sincronização são possíveis; quando o usuário precisa saber se opera sobre dado local, pendente ou sincronizado.

**Quando evitar**: quando o app é 100% online e bloqueia uso offline; quando a sincronização é instantânea e sem estado relevante; quando o estado offline não altera confiança, edição ou leitura.

**Alternativas próximas**: UIP-FEEDBACK-ERROR_STATE (falha isolada), UIP-SYSTEM-BACKGROUND_PROGRESS (operação longa de sync).

**Sinais de escolha**:
- fila pendente e conflitos
- badges de estado em itens
- estado online ou offline
- dados locais e retry de sync
- confiança sobre a versão dos dados

**Grau de Rigidez**: Médio — indicação de conectividade e sincronização é invariante; estratégia de sync e conflitos variam.

## Composição

**Zonas usuais**: Cabeçalho, Coleção, Overlay.

**Variantes reconhecidas**: offline funcional; offline limitado; sync pendente; sync em background; conflito de dados; retry de sync; dado local não sincronizado.

## Compatibilidade com Shell Patterns

**Compatibilidade Primária**: SHP-WORKSPACE_ADMIN, SHP-COMMUNICATION, SHP-TRANSACTIONAL_COMMERCE.

**Compatibilidade Secundária**: SHP-DASHBOARD_ANALYTICS, SHP-MEDIA_CONTENT, SHP-KIOSK_EMBEDDED.

**Incompatibilidades explícitas**: produtos sem persistência local, sem fila e sem comportamento offline.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-FORM, PP-LIST-DETAIL, PP-CONVERSATION, PP-FEED.

**Compatibilidade Secundária**: PP-MAP, PP-CALENDAR, PP-BOARD, PP-CATALOG, PP-DETAIL.

**Incompatibilidades explícitas**: páginas estáticas ou apenas públicas sem dependência de sync.

## Estrutura e Transição

**Estrutura Desktop**: status global ou contextual de conexão, indicadores por item, fila de operações, mensagens de conflito e ações de retry ou resolução.

**Estrutura Mobile**: banner, snackbar persistente, badge ou status em item sem bloquear o uso local quando a funcionalidade offline existe.

**Regra de Transição**: sempre distinguir offline, sincronizando, sincronizado, pendente, falha e conflito. Operações locais não devem parecer sincronizadas quando ainda estão pendentes.

## Estados

**Estados próprios**: online sincronizado, online sincronizando, offline funcional, offline limitado, pendente, fila com N operações, conflito detectado, sync failed, retrying.

**Reação a estados da página**: modo offline → dados marcados como locais quando relevante. Conflito → resolução explícita. `error` de sync → feedback sem apagar as alterações locais.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: tratar service worker, storage local, fila, eventos online e offline e limitações de background.

**Adaptação Mobile nativo**: considerar conectividade, background tasks, banco local, retry, conflito e retomada após foreground.

**Adaptação Desktop nativo**: integrar sync em background, arquivos locais, tray ou dock e notificações quando aplicável.
