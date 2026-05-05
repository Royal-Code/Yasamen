# UI Patterns Desktop Nativo

UI Patterns que existem exclusivamente ou primariamente em plataformas desktop nativas e frameworks que produzem apps desktop. Não substituem os catálogos base — complementam-nos com interações que não têm equivalente direto na web ou mobile.

## Aplicabilidade

Estes patterns aplicam-se quando o target da biblioteca ou do projeto é:
- Windows nativo (WPF, WinUI, Windows Forms)
- macOS nativo (AppKit, SwiftUI for macOS)
- Linux (GTK, Qt)
- Electron / Tauri (apps desktop com web runtime)
- .NET MAUI (target desktop)
- Flutter Desktop
- Kotlin Multiplatform (KMP desktop)

Para Electron e Tauri: estes patterns aplicam-se quando a app explora capacidades desktop além do que uma web app faria (multi-window, system tray, file system, etc.). Se a app Electron é apenas uma web app empacotada sem explorar APIs desktop, os catálogos base são suficientes.

## Patterns

### Multi Window

**ID_UI_PATTERN:** UIP-DESKTOP-MULTI_WINDOW
**Categoria:** Desktop Nativo
**Definição curta:** Gestão de múltiplas janelas independentes com comunicação entre elas e controle de ciclo de vida.
**Objetivo estrutural:** Permitir trabalho paralelo em múltiplos contextos com gestão de foco, posição e comunicação inter-janela.
**Não confundir com:** UIP-STRUCT-SPLIT_PANEL dentro da mesma janela, tabs do browser, modais/dialogs
**Nível composicional possível:** Root
**Quando usar:** quando o utilizador beneficia de ver dois contextos simultaneamente em monitores diferentes; quando inspectors ou ferramentas precisam ser destacáveis; quando documentos independentes devem coexistir; quando arrastar entre contextos faz sentido
**Quando evitar:** quando toda a interação cabe numa única janela com painéis; quando o overhead de gestão de janelas supera o benefício; quando a app é single-purpose e simples
**Alternativas próximas:** UIP-STRUCT-SPLIT_PANEL, UIP-DESKTOP-FLOATING_PANEL, tabs internas
**Sinais de escolha:** IDEs, editores gráficos, ferramentas de produtividade; múltiplos monitores são cenário comum; documentos independentes; inspectors ou paletas destacáveis
**Plataformas:** Windows (WPF Window, WinUI AppWindow), macOS (NSWindow, WindowGroup), Electron (BrowserWindow), Tauri (WebviewWindow), Flutter Desktop (multi-window experimental), MAUI (Window)
**Estrutura Windows:** janelas independentes no taskbar. Cada janela pode ter menu, toolbar e status bar próprios. Comunicação por IPC ou shared state.
**Estrutura macOS:** janelas com title bar nativo. Menu bar global partilhado. Window groups. Cycle through windows (⌘`). Gestão por Mission Control.
**Regra de adaptação cross-platform:** cada janela deve funcionar autonomamente (não quebrar se outra fechar). Comunicação entre janelas deve ser resiliente. Posição e tamanho devem ser restaurados entre sessões. Janela principal vs auxiliares devem ter hierarquia clara.
**Estados próprios:** janela principal activa, janela auxiliar activa, janela em background, janela minimizada, janela maximizada, janela em arranjo (snap), janela destacada de painel
**Reação a estados da página:** Error State em janela auxiliar → não propagar para principal. Janela fechada → limpar referências sem crash.
**Grau de Rigidez:** Médio

### Command Palette

**ID_UI_PATTERN:** UIP-DESKTOP-COMMAND_PALETTE
**Categoria:** Desktop Nativo
**Definição curta:** Overlay de busca e execução rápida de comandos, ficheiros ou ações por teclado.
**Objetivo estrutural:** Permitir acesso rápido a qualquer comando ou destino sem navegar por menus ou toolbars.
**Não confundir com:** UIP-INPUT-SEARCH_BAR para busca de conteúdo, menu de aplicação, spotlight do SO
**Nível composicional possível:** Root
**Quando usar:** quando a app tem muitos comandos dispersos por menus e toolbars; quando power users precisam de atalho para qualquer acção; quando a navegação entre ficheiros ou entidades precisa ser instantânea; quando busca e execução devem ser unificadas
**Quando evitar:** quando a app tem poucos comandos (<20); quando o público alvo não usa teclado frequentemente; quando a busca por conteúdo já resolve via search bar
**Alternativas próximas:** UIP-INPUT-SEARCH_BAR, menu global, spotlight/Raycast do SO, shortcut customizável
**Sinais de escolha:** app tipo IDE, editor ou ferramenta de produtividade; volume alto de comandos; utilizadores expert; atalhos de teclado são insuficientes sozinhos; fuzzy matching agrega valor
**Plataformas:** Windows (WPF/WinUI custom, VS Code pattern), macOS (NSMenu custom, Spotlight-like), Electron (nativo no VS Code, Figma, Notion), Tauri (custom), Flutter Desktop (custom widget)
**Estrutura Windows:** Ctrl+Shift+P ou Ctrl+K. Overlay centrado com campo de busca, lista de resultados filtrada, categorias, atalhos visíveis por item.
**Estrutura macOS:** ⌘+Shift+P ou ⌘+K. Overlay semelhante. Integração com menu bar para commands. Fuzzy matching com ranking por frequência.
**Regra de adaptação cross-platform:** atalho consistente por plataforma (Ctrl no Windows/Linux, ⌘ no macOS). Fuzzy matching obrigatório. Mostrar atalho de teclado ao lado de cada resultado quando existir. Categorias ou prefixos (> para comandos, @ para símbolos, : para linha). Histórico de recentes no topo.
**Estados próprios:** oculto, aberto vazio, com resultados, sem resultados, executando comando, com erro de comando
**Reação a estados da página:** Loading State → comandos context-sensitive indisponíveis temporariamente.
**Grau de Rigidez:** Alto

### Floating Panel

**ID_UI_PATTERN:** UIP-DESKTOP-FLOATING_PANEL
**Categoria:** Desktop Nativo
**Definição curta:** Painel destacável, reposicionável e opcionalmente ancorável, para ferramentas, inspectors ou paletas.
**Objetivo estrutural:** Permitir que painéis auxiliares flutuem sobre o conteúdo ou sejam ancorados conforme preferência do utilizador.
**Não confundir com:** UIP-STRUCT-SPLIT_PANEL fixo, UIP-DESKTOP-MULTI_WINDOW independente, tooltip ou popover
**Nível composicional possível:** Container
**Quando usar:** quando inspectors, propriedades ou ferramentas precisam estar visíveis sem ocupar espaço fixo; quando o utilizador quer personalizar o layout; quando painéis devem poder ser ancorados (docked) ou flutuantes; quando a área de trabalho principal não deve ser comprometida
**Quando evitar:** quando painéis fixos resolvem; quando a app não justifica personalização de layout; quando o conteúdo do painel é raramente consultado
**Alternativas próximas:** UIP-STRUCT-SPLIT_PANEL, UIP-DESKTOP-MULTI_WINDOW, sidebar colapsável, UIP-MOBILE-BOTTOM_SHEET
**Sinais de escolha:** IDEs, editores gráficos, DAWs; inspector de propriedades; paletas de ferramentas; o utilizador frequentemente reorganiza o workspace visual
**Plataformas:** Windows (WPF DockPanel/AvalonDock, WinUI), macOS (NSPanel, inspector windows), Electron (custom docking), Flutter Desktop (custom), Qt (QDockWidget)
**Estrutura Windows:** painéis com title bar compacto, botão de pin/float/close. Drag para reposicionar. Drop zones para ancorar. Auto-hide quando não pinned.
**Estrutura macOS:** NSPanel (utility window) para floating. Inspector pattern nativo. Transparência e always-on-top opcionais.
**Regra de adaptação cross-platform:** suportar ambos os modos (float e dock). Persistir layout entre sessões. Permitir reset para layout default. Title bar do painel deve ser compacto. Nunca bloquear acesso ao conteúdo principal. Auto-hide quando não pinned é desejável.
**Estados próprios:** docked (ancorado), floating (flutuante), auto-hidden (collapsed com tab), dragging (reposicionando), pinned, minimizado no dock
**Reação a estados da página:** Loading State → painel mostra skeleton do inspector. Contexto vazio → painel mostra empty state ou desactiva.
**Grau de Rigidez:** Baixo

### System Tray

**ID_UI_PATTERN:** UIP-DESKTOP-SYSTEM_TRAY
**Categoria:** Desktop Nativo
**Definição curta:** Presença persistente no system tray / menu bar do SO com menu, status e notificações fora da janela principal.
**Objetivo estrutural:** Manter a app acessível e comunicar estado mesmo quando a janela principal está fechada ou minimizada.
**Não confundir com:** taskbar icon/badge, notificação do SO, floating widget, dock icon
**Nível composicional possível:** Root
**Quando usar:** quando a app precisa funcionar em background (sync, monitoring, communication); quando fechar a janela não deve matar o processo; quando status ou acções rápidas devem estar acessíveis sem abrir a janela; quando notificações precisam de presença persistente
**Quando evitar:** quando a app só funciona com a janela aberta; quando não há função em background; quando o SO desencorage uso do tray (macOS guidelines para apps simples)
**Alternativas próximas:** dock/taskbar badges, notificações do SO, UIP-DESKTOP-DOCK_INTEGRATION, menu bar app (macOS)
**Sinais de escolha:** app de comunicação, sync, monitoramento, VPN, cloud storage; precisa de presença contínua; acções rápidas sem abrir janela; estado visível (online, syncing, error)
**Plataformas:** Windows (NotifyIcon / SystemTray), macOS (NSStatusItem / menu bar app), Linux (AppIndicator / StatusNotifierItem), Electron (Tray), Tauri (SystemTray)
**Estrutura Windows:** ícone no system tray. Right-click → context menu. Left-click → abrir/focar janela. Tooltip com status. Balloon notification.
**Estrutura macOS:** ícone na menu bar (status item). Click → menu dropdown ou popover. Estado comunicado por variação do ícone.
**Regra de adaptação cross-platform:** ícone deve comunicar estado por variação visual (cor, badge, animação subtil). Menu deve ter: status, acções rápidas, separador, abrir janela, sair. Nunca forçar presença no tray sem funcionalidade background real. Respeitar guidelines do SO.
**Estados próprios:** idle, activo (com processo background), com notificação pendente, em erro, a sincronizar
**Reação a estados da página:** app em background → tray mantém-se activo. Erro crítico → ícone muda para estado de alerta.
**Grau de Rigidez:** Alto

### Keyboard Flow

**ID_UI_PATTERN:** UIP-DESKTOP-KEYBOARD_FLOW
**Categoria:** Desktop Nativo
**Definição curta:** Navegação e operação completa da interface via teclado, com focus management, atalhos e indicadores visuais de foco.
**Objetivo estrutural:** Permitir operação produtiva sem mouse através de atalhos, tab navigation, focus rings e landmarks.
**Não confundir com:** acessibilidade genérica (a11y), UIP-DESKTOP-COMMAND_PALETTE, atalhos isolados
**Nível composicional possível:** Root
**Quando usar:** quando o público alvo são power users que preferem teclado; quando a produtividade depende de não tirar as mãos do teclado; quando a app é usada por longos períodos; quando shortcut customizável é expectativa
**Quando evitar:** quando a app é predominantemente visual/canvas e mouse é essencial; quando o público alvo é casual e não aprenderá atalhos; quando a app mobile-first não justifica investimento
**Alternativas próximas:** UIP-DESKTOP-COMMAND_PALETTE (complementar), mouse-only flow, voice control
**Sinais de escolha:** IDE, editor, terminal, ferramenta de produtividade, spreadsheet; utilizadores expert; sessões longas; operações repetitivas; múltiplos atalhos já esperados
**Plataformas:** Windows (WPF/WinUI KeyBindings, AccessKeys), macOS (NSResponder chain, menu shortcuts), Electron (accelerators, globalShortcut), Flutter Desktop (Shortcuts widget, FocusNode), MAUI (keyboard accelerators)
**Estrutura Windows:** Tab/Shift+Tab para navegação. Alt+Key para access keys. Ctrl+Key para atalhos. Focus ring visível. F6 para landmarks.
**Estrutura macOS:** Tab navigation. ⌘+Key para atalhos. Menu bar como repositório de atalhos. Full Keyboard Access.
**Regra de adaptação cross-platform:** Ctrl→⌘ no macOS. Focus ring deve ser sempre visível em modo keyboard. Tab order lógico obrigatório. Atalhos devem ser descobríveis (mostrar nos menus e tooltips). Shortcuts customizáveis para apps complexas. Não capturar atalhos do SO.
**Estados próprios:** mouse mode (focus ring oculto), keyboard mode (focus ring visível), shortcut overlay activo (mostrar todos os atalhos), conflict detected (atalho duplicado)
**Reação a estados da página:** Modal activo → trap focus dentro. Disabled element → skip no tab order.
**Grau de Rigidez:** Alto

### Cross Window Drag and Drop

**ID_UI_PATTERN:** UIP-DESKTOP-CROSS_WINDOW_DND
**Categoria:** Desktop Nativo
**Definição curta:** Arrastar e soltar entre janelas da mesma app, entre apps ou entre a app e o sistema de ficheiros.
**Objetivo estrutural:** Permitir transferência de dados por gesto directo entre contextos diferentes.
**Não confundir com:** drag & drop interno (reordenação dentro de uma lista), file upload por drag, clipboard copy/paste
**Nível composicional possível:** Leaf
**Quando usar:** quando o utilizador trabalha com ficheiros ou objectos que devem poder ser movidos entre janelas; quando a integração com o SO (drag para Finder/Explorer) é esperada; quando a app tem múltiplas janelas com conteúdo transferível
**Quando evitar:** quando todo o drag & drop é interno à mesma vista; quando clipboard resolve melhor; quando a interacção é rara e o custo de implementação não justifica
**Alternativas próximas:** clipboard (copy/paste), file picker, import/export explícito, drag interno
**Sinais de escolha:** app com ficheiros ou assets; múltiplas janelas; integração com Finder/Explorer desejada; editores gráficos com layers arrastáveis; file managers
**Plataformas:** Windows (OLE Drag&Drop, WPF DragDrop), macOS (NSDraggingSource/Destination, NSPasteboard), Electron (HTML5 DnD + native file), Tauri (drag-drop event), Flutter Desktop (limitado)
**Estrutura Windows:** drag source com preview translúcido. Drop targets com highlight. Cursors indicam operação (copy, move, link). Drop no Explorer = save file.
**Estrutura macOS:** drag com thumbnail. Spring-loaded folders. Drop zones com highlight. Promessa de file (NSFilePromiseProvider) para lazy creation.
**Regra de adaptação cross-platform:** sempre mostrar preview durante drag. Indicar claramente drop zones válidas. Suportar ao menos copy e move. Integrar com sistema de ficheiros quando relevante. Cancelar com Escape. Nunca travar a UI durante drag.
**Estados próprios:** idle, dragging (com preview), over valid target (highlight), over invalid target (cursor negativo), dropped (processando), cancelled
**Reação a estados da página:** No Permission State → drop zone desactivada. Error State ao drop → feedback com undo quando possível.
**Grau de Rigidez:** Médio

### Dock Integration

**ID_UI_PATTERN:** UIP-DESKTOP-DOCK_INTEGRATION
**Categoria:** Desktop Nativo
**Definição curta:** Integração com dock/taskbar do SO para comunicar progresso, badges, jump lists e acções rápidas sem abrir a janela.
**Objetivo estrutural:** Usar a presença no dock/taskbar para comunicar estado e oferecer acesso rápido a destinos ou acções.
**Não confundir com:** UIP-DESKTOP-SYSTEM_TRAY (presença em background), ícone estático da app, notificações do SO
**Nível composicional possível:** Leaf
**Quando usar:** quando a app tem progresso longo (download, export, build) comunicável via taskbar; quando badges numéricos (mensagens não lidas) são relevantes; quando jump lists ou dock menu aceleram acesso a documentos recentes ou acções
**Quando evitar:** quando a app não tem estado comunicável pelo dock; quando badges seriam noise (muitas notificações sem valor); quando a app é efémera/descartável
**Alternativas próximas:** UIP-DESKTOP-SYSTEM_TRAY, notificações nativas, UIP-FEEDBACK-LOADING_STATE interno
**Sinais de escolha:** download/upload/build com progresso; mensagens não lidas; documentos recentes; acções frequentes (new document, open recent)
**Plataformas:** Windows (Taskbar progress, JumpList, badge overlay), macOS (NSDockTile badge, dock menu, progress), Electron (setProgressBar, setBadgeCount, setUserTasks), Tauri (limited)
**Estrutura Windows:** progress bar na taskbar (indeterminate, normal, error, paused). Badge overlay no ícone. Jump List com recent, frequent e custom tasks.
**Estrutura macOS:** badge numérico no dock icon. Dock menu com items custom. Bouncing para chamar atenção (usar com moderação).
**Regra de adaptação cross-platform:** progress bar para operações longas. Badge para contadores não-lidos. Documentos recentes no jump list/dock menu. Nunca abusar do bounce/flash (usar apenas para eventos que requerem atenção imediata). Limpar badge quando conteúdo lido.
**Estados próprios:** sem indicação, com badge (numérico), com progresso (0-100%), progresso indeterminado, progresso com erro, progress paused
**Reação a estados da página:** operação em background → progresso na taskbar. Erro na operação → progress state error. Completo → flash/bounce once + limpar progress.
**Grau de Rigidez:** Médio
