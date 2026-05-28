# UIP-SYSTEM-TRAY - System Tray

## Definição

**Categoria**: Sistema & Host

**Definição curta**: Presença persistente no system tray ou menu bar do sistema operacional com menu, status e notificações fora da janela principal.

**Objetivo estrutural**: Manter o app acessível, comunicar estado e oferecer ações rápidas quando a janela está fechada, minimizada ou em background.

**Não confundir com**: UIP-SYSTEM-DOCK_INTEGRATION (integração com dock ou taskbar), notificação isolada do SO (fora do catálogo), floating widget (fora do catálogo).

**Nível composicional possível**: Root

## Decisão

**Quando usar**: quando o app precisa funcionar em background; quando fechar a janela não deve encerrar o processo; quando status ou ações rápidas precisam existir fora da janela; quando notificações precisam de presença persistente.

**Quando evitar**: quando o app só funciona com a janela aberta; quando não há função de background real; quando as guidelines do SO desencorajam tray ou menu bar para apps simples; quando a presença persistente seria ruído.

**Alternativas próximas**: UIP-SYSTEM-DOCK_INTEGRATION (integração com dock), UIP-SYSTEM-BACKGROUND_PROGRESS (progresso em background), UIP-SYSTEM-NOTIFICATION_CENTER (agregação de notificações).

**Sinais de escolha**:
- sync, comunicação, monitoramento, VPN ou cloud storage
- estado online ou offline
- ações rápidas sem abrir janela
- processo em background

**Grau de Rigidez**: Alto — presença no tray com menu e status é invariante; ações, badges e notificações variam.

## Composição

**Zonas usuais**: Overlay.

**Variantes reconhecidas**: tray icon Windows; menu bar app macOS; app indicator Linux; tray com status; tray com menu de ações; tray com processo em background.

## Compatibilidade com Shell Patterns

**Compatibilidade Primária**: SHP-COMMUNICATION, SHP-WORKSPACE_ADMIN, SHP-DASHBOARD_ANALYTICS.

**Compatibilidade Secundária**: SHP-MEDIA_CONTENT, SHP-TRANSACTIONAL_COMMERCE, SHP-STUDIO_WORKBENCH.

**Incompatibilidades explícitas**: SHP-PORTAL, SHP-FOCUSED e apps sem processo de background ou status persistente.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: Todos os Page Patterns.

**Compatibilidade Secundária**: Nenhuma.

**Incompatibilidades explícitas**: não substitui feedback dentro da página para ações locais.

## Estrutura e Transição

**Estrutura Desktop**: ícone no system tray ou menu bar, menu contextual com status e ações rápidas, abrir ou focar a janela e notificações quando aplicável.

**Estrutura Mobile**: substituir por notificações, background tasks e app lifecycle.

**Regra de Transição**: a presença no tray só existe com função de background real. O menu inclui status, ações rápidas, abrir ou focar a janela e sair.

## Estados

**Estados próprios**: idle, processo em background ativo, sincronizando, com notificação pendente, erro, offline, pausado, encerrando.

**Reação a estados da página**: app em background → o tray mantém a presença. Erro crítico → estado refletido no tray. Sessão expirada → ação de reautenticar ou abrir o app.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Desktop nativo.

**Plataformas primárias**: Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: usar apenas quando a plataforma instalada oferece capacidade equivalente; caso contrário, usar notificações e estado dentro do app.

**Adaptação Mobile nativo**: substituir por notificações, background tasks e app lifecycle.

**Adaptação Desktop nativo**: integrar com APIs do SO, lifecycle, notificações, menu, processo em background e encerramento.
