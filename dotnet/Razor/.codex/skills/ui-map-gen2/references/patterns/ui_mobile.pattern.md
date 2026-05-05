# UI Patterns Mobile Nativo

UI Patterns que existem exclusivamente ou primariamente em plataformas móveis nativas (iOS, Android) e seus frameworks cross-platform (Flutter, React Native, MAUI). Não substituem os catálogos base — complementam-nos com interações que não têm equivalente direto na web.

## Aplicabilidade

Estes patterns aplicam-se quando o target da biblioteca ou do projeto é:
- iOS nativo (UIKit, SwiftUI)
- Android nativo (Jetpack Compose, Views)
- Flutter
- React Native
- .NET MAUI
- Kotlin Multiplatform (KMP)

Não se aplicam a web responsiva ou PWA — para esses cenários, os catálogos base (`ui_nav`, `ui_action`, etc.) com suas regras de transição são suficientes.

## Patterns

### Bottom Sheet

**ID_UI_PATTERN:** UIP-MOBILE-BOTTOM_SHEET
**Categoria:** Mobile Nativo
**Definição curta:** Superfície modal deslizante a partir da base da tela, activada por gesto ou acção, com alturas progressivas.
**Objetivo estrutural:** Expor conteúdo complementar, opções ou detalhe sem sair do contexto actual.
**Não confundir com:** Dialog/Modal web, Drawer lateral, Contextual Menu por overflow
**Nível composicional possível:** Container
**Quando usar:** quando é necessário mostrar opções, detalhe ou formulário curto sem perder o contexto por trás; quando alturas parciais (half-sheet, full-sheet) fazem sentido para progressive disclosure; quando o utilizador precisa poder arrastar para expandir ou fechar
**Quando evitar:** quando o conteúdo precisa de navegação profunda própria; quando a acção é destrutiva e precisa de confirmação forte antes de aparecer; quando um dialog simples resolve
**Alternativas próximas:** UIP-FEEDBACK-CONFIRMATION_DIALOG, UIP-ACTION-CONTEXTUAL_MENU, UIP-STRUCT-SPLIT_PANEL
**Sinais de escolha:** o conteúdo é auxiliar ou complementar; alturas progressivas agregam valor; gesto de dismiss faz sentido; o contexto por trás deve permanecer parcialmente visível
**Plataformas:** iOS (UISheetPresentationController), Android (BottomSheetBehavior), Flutter (showModalBottomSheet), React Native (BottomSheet libs), MAUI (BottomSheet)
**Estrutura iOS:** sheet com detents (.medium, .large), grab indicator, dismiss por swipe down, backdrop dimming
**Estrutura Android:** BottomSheet com estados COLLAPSED, HALF_EXPANDED, EXPANDED, peek height, drag handle, scrim
**Regra de adaptação cross-platform:** preservar alturas progressivas e gesto de dismiss. Em Flutter/RN: usar lib que suporte detents ou snap points. Nunca substituir por dialog simples quando alturas parciais são parte da UX.
**Estados próprios:** oculto, peek (parcialmente visível), half-expanded, expanded, a fechar (animação de dismiss)
**Reação a estados da página:** Loading State → conteúdo do sheet em skeleton. Error State → mensagem dentro do sheet, não como overlay sobre o sheet.
**Grau de Rigidez:** Médio

### Swipe Action

**ID_UI_PATTERN:** UIP-MOBILE-SWIPE_ACTION
**Categoria:** Mobile Nativo
**Definição curta:** Acções reveladas por gesto horizontal sobre itens de lista, com distinção visual por tipo de acção.
**Objetivo estrutural:** Expor ações rápidas por item sem ocupar espaço permanente na interface.
**Não confundir com:** UIP-ACTION-CONTEXTUAL_MENU por long-press, drag & drop para reordenação, gesto de navegação (swipe back)
**Nível composicional possível:** Leaf
**Quando usar:** quando itens de lista têm 1-3 acções frequentes (delete, archive, pin, mute); quando a densidade de itens exige economia de espaço; quando a acção precisa ser rápida e repetível em sequência
**Quando evitar:** quando a acção é rara ou destrutiva sem possibilidade de undo; quando existem mais de 3 ações por lado; quando o item já exige scroll horizontal para seu conteúdo
**Alternativas próximas:** UIP-ACTION-CONTEXTUAL_MENU, UIP-ACTION-ACTION_BAR contextual, checkbox + batch action
**Sinais de escolha:** 1-3 acções de alta frequência por item; a lista é longa e repetitiva; as acções são reversíveis ou de baixo risco; o gesto é natural para a plataforma
**Plataformas:** iOS (UISwipeActionsConfiguration), Android (ItemTouchHelper), Flutter (Dismissible, flutter_slidable), React Native (Swipeable), MAUI (SwipeView)
**Estrutura iOS:** leading e trailing swipe actions com ícone, cor e texto. Full swipe para acção primária. Confirmação automática ou com threshold.
**Estrutura Android:** Swipe com background reveal e ícone. Snap back ou dismiss completo. Snackbar com undo quando destrutivo.
**Regra de adaptação cross-platform:** manter distinção leading/trailing. Acção destrutiva sempre com cor vermelha/alerta. Full swipe opcional — nunca obrigatório como único método. Fallback por long-press para acessibilidade.
**Estados próprios:** neutro, swiping (parcial), acções reveladas, full-swipe confirmado, executando, undo disponível
**Reação a estados da página:** No Permission State → swipe desactivado ou acção indisponível visualmente.
**Grau de Rigidez:** Médio

### Pull to Refresh

**ID_UI_PATTERN:** UIP-MOBILE-PULL_REFRESH
**Categoria:** Mobile Nativo
**Definição curta:** Gesto de puxar para baixo no topo de uma lista ou scroll para disparar atualização do conteúdo.
**Objetivo estrutural:** Permitir atualização manual do conteúdo via gesto natural sem botão explícito.
**Não confundir com:** Loading State automático, paginação por scroll, refresh por botão na toolbar
**Nível composicional possível:** Leaf
**Quando usar:** quando a lista pode ter conteúdo novo desde a última visualização; quando o utilizador espera controle manual sobre atualização; quando a atualização é rápida (< 5s na maioria dos casos)
**Quando evitar:** quando o conteúdo é estático ou muda raramente; quando existe push/real-time automático que elimina a necessidade; quando a atualização é pesada e deve ser consciente (download grande)
**Alternativas próximas:** Botão de refresh, real-time subscription, background sync automático
**Sinais de escolha:** lista com dados potencialmente desatualizados; plataforma suporta o gesto nativamente; atualização é uma operação leve e rápida; o utilizador tem expectativa do gesto
**Plataformas:** iOS (UIRefreshControl), Android (SwipeRefreshLayout), Flutter (RefreshIndicator), React Native (RefreshControl), MAUI (RefreshView)
**Estrutura iOS:** pull revela spinner circular. Threshold de ativação. Bouncing natural. Feedback háptico ao activar.
**Estrutura Android:** indicador circular Material que desce do topo. Progresso indeterminado. Cor customizável.
**Regra de adaptação cross-platform:** usar componente nativo da plataforma. Não simular com scroll events customizados. Em apps cross-platform: usar wrapper da plataforma (RefreshIndicator em Flutter, RefreshControl em RN).
**Estados próprios:** idle, pulling (abaixo do threshold), triggered (acima do threshold), refreshing, completed
**Reação a estados da página:** Error State → mensagem inline após refresh falhado, não substituir conteúdo existente.
**Grau de Rigidez:** Alto

### Navigation Stack

**ID_UI_PATTERN:** UIP-MOBILE-NAV_STACK
**Categoria:** Mobile Nativo
**Definição curta:** Navegação hierárquica por push/pop de vistas com gestão de pilha e gestos de retorno.
**Objetivo estrutural:** Organizar progressão entre vistas mantendo contexto de retorno e hierarquia implícita.
**Não confundir com:** UIP-NAV-TABS alternância entre vistas irmãs, Navigation Menu global, UIP-NAV-BREADCRUMB
**Nível composicional possível:** Root
**Quando usar:** quando a experiência é hierárquica (lista → detalhe → sub-detalhe); quando cada vista empilhada depende do contexto anterior; quando gestos de retorno nativos devem funcionar; quando a profundidade é previsível (2-5 níveis)
**Quando evitar:** quando as vistas são irmãs sem hierarquia; quando a navegação é circular sem hierarquia clara; quando a profundidade pode ser excessiva (>7 níveis sem motivo)
**Alternativas próximas:** UIP-NAV-TABS, UIP-NAV-NAVIGATION_MENU, UIP-MOBILE-BOTTOM_SHEET para detalhe leve
**Sinais de escolha:** existe relação pai-filho entre telas; swipe back (iOS) ou botão back (Android) são esperados; a barra de navegação muda por nível; deep link precisa resolver hierarquia
**Plataformas:** iOS (UINavigationController, NavigationStack), Android (NavController, Fragment back stack), Flutter (Navigator 2.0, GoRouter), React Native (React Navigation stack), MAUI (NavigationPage)
**Estrutura iOS:** UINavigationBar com título, botão back automático, large title no root. Swipe from edge para pop. Transição push/pop animada.
**Estrutura Android:** Toolbar com up button. Back button do sistema faz pop. Transições por animação ou shared element.
**Regra de adaptação cross-platform:** respeitar idioma de cada plataforma para animação de transição. iOS = swipe from left edge. Android = back button do sistema. Deep links devem reconstituir a pilha correta. Nunca usar gestos de outra plataforma (não colocar swipe back no Android).
**Estados próprios:** root (sem back), empilhado (com back), em transição (push/pop animado), deep link resolvendo pilha
**Reação a estados da página:** Loading State na vista destino → mostrar skeleton enquanto resolve. Error State na navegação → permanecer na vista actual com feedback.
**Grau de Rigidez:** Alto

### Tab Bar Nativa

**ID_UI_PATTERN:** UIP-MOBILE-TAB_BAR
**Categoria:** Mobile Nativo
**Definição curta:** Barra de navegação fixa na base do ecrã com destinos principais do app, cada um com stack própria.
**Objetivo estrutural:** Organizar os destinos de topo do app em acesso persistente com alternância rápida.
**Não confundir com:** UIP-NAV-TABS alternância local dentro de uma página, UIP-NAV-NAVIGATION_MENU sidebar, Bottom Sheet
**Nível composicional possível:** Root
**Quando usar:** quando o app tem 3-5 destinos principais de igual importância; quando cada destino tem navegação interna própria (stack); quando o utilizador alterna frequentemente entre destinos; quando a tab bar é a raiz estrutural do app
**Quando evitar:** quando há mais de 5 destinos (usar drawer); quando um destino domina completamente (usar stack simples); quando o app é single-purpose sem secções paralelas
**Alternativas próximas:** UIP-NAV-NAVIGATION_MENU (drawer), UIP-MOBILE-NAV_STACK (single stack), UIP-NAV-TABS (local)
**Sinais de escolha:** 3-5 secções top-level; alternância frequente; cada secção mantém estado; ícone + label curto são suficientes; a barra deve estar sempre acessível
**Plataformas:** iOS (UITabBarController, TabView), Android (BottomNavigationView, NavigationBar Material 3), Flutter (BottomNavigationBar, NavigationBar), React Native (Bottom Tabs), MAUI (TabbedPage / Shell TabBar)
**Estrutura iOS:** barra no fundo com ícone + label. Badge numérico. Oculta em push profundo opcional. Cada tab mantém stack própria.
**Estrutura Android:** NavigationBar Material 3 com ícone + label. Badge. Scrollable se >5 (mas evitar). Cada destino preserva estado via NavGraph.
**Regra de adaptação cross-platform:** sempre na base. 3-5 itens. Cada tab preserva estado e stack. Badge para notificações. Ao alternar tab, não resetar stack (salvo tap no tab activo = pop to root). Ocultar em fullscreen ou teclado.
**Estados próprios:** tab activa, tab inactiva, tab com badge, tab desactivada (por permissão), barra oculta (fullscreen/keyboard)
**Reação a estados da página:** No Permission State → tab oculta ou desactivada.
**Grau de Rigidez:** Alto

### Permission Flow

**ID_UI_PATTERN:** UIP-MOBILE-PERMISSION_FLOW
**Categoria:** Mobile Nativo
**Definição curta:** Fluxo de pedido de permissão do sistema operativo com pré-contextualização e tratamento de recusa.
**Objetivo estrutural:** Maximizar concessão de permissão através de contextualização prévia e tratamento gracioso de recusa.
**Não confundir com:** UIP-FEEDBACK-CONFIRMATION_DIALOG genérico, onboarding, login/auth flow
**Nível composicional possível:** Container
**Quando usar:** quando a funcionalidade depende de permissão do SO (câmara, localização, notificações, contatos, microfone); quando o pedido precisa de justificativa contextual; quando a recusa deve ser tratada com alternativa
**Quando evitar:** quando a permissão já foi concedida; quando a funcionalidade não depende de permissão do SO; quando é melhor pedir just-in-time do que antecipadamente
**Alternativas próximas:** onboarding educativo, just-in-time prompt sem pré-screen, settings redirect
**Sinais de escolha:** funcionalidade bloqueada sem permissão; o SO vai mostrar dialog nativo que só aparece uma vez; contextualizar antes aumenta taxa de concessão; recusa precisa de fallback
**Plataformas:** iOS (Info.plist usage descriptions + requestAuthorization), Android (runtime permissions + shouldShowRequestPermissionRationale), Flutter (permission_handler), React Native (react-native-permissions), MAUI (Permissions API)
**Estrutura iOS:** pré-screen com explicação → dialog nativo do SO → tratamento de resposta. Se recusado: screen com instruções para Settings.
**Estrutura Android:** rationale screen se shouldShowRationale → dialog nativo → tratamento. Se "don't ask again": redirect para Settings do app.
**Regra de adaptação cross-platform:** sempre pré-contextualizar antes do prompt nativo. Nunca pedir permissão sem motivo visível. Tratar recusa com funcionalidade degradada ou alternativa. Não bloquear o app inteiro por uma permissão. Respeitar "don't ask again" — redirect para settings.
**Estados próprios:** não solicitada, pré-screen (explicação), aguardando resposta do SO, concedida, recusada (primeira vez), recusada permanente, funcionalidade degradada
**Reação a estados da página:** permissão recusada → funcionalidade alternativa ou mensagem com CTA para settings.
**Grau de Rigidez:** Alto

### Offline Sync

**ID_UI_PATTERN:** UIP-MOBILE-OFFLINE_SYNC
**Categoria:** Mobile Nativo
**Definição curta:** Indicação de estado de conectividade e gestão visual de sincronização pendente, conflitos e dados locais.
**Objetivo estrutural:** Comunicar ao utilizador o estado da conexão e das operações pendentes sem bloquear o uso.
**Não confundir com:** UIP-FEEDBACK-LOADING_STATE para carregamento online, UIP-FEEDBACK-ERROR_STATE para falha técnica, cache implícito sem feedback
**Nível composicional possível:** Leaf, Container
**Quando usar:** quando o app suporta uso offline com sync posterior; quando operações podem ser enfileiradas localmente; quando conflitos de sync são possíveis; quando o utilizador precisa saber se está a operar com dados locais
**Quando evitar:** quando o app é 100% online sem funcionalidade offline; quando a sincronização é instantânea e transparente; quando o estado offline deve bloquear toda interação
**Alternativas próximas:** UIP-FEEDBACK-ERROR_STATE (para falha), banner de status, indicador na toolbar
**Sinais de escolha:** app funciona offline; há fila de operações pendentes; conflitos são possíveis; o utilizador precisa de confiança sobre o estado dos dados
**Plataformas:** iOS (NWPathMonitor + Core Data/CloudKit sync), Android (ConnectivityManager + WorkManager), Flutter (connectivity_plus + local DB), React Native (NetInfo + async storage), MAUI (Connectivity + local storage)
**Estrutura iOS:** banner discreto ou ícone na nav bar quando offline. Badge em itens pendentes. Resolução de conflitos por sheet ou dialog.
**Estrutura Android:** Snackbar persistente ou banner Material quando offline. Indicador de sync em itens. Notification para sync em background.
**Regra de adaptação cross-platform:** nunca bloquear o app por estar offline se há funcionalidade local. Indicar claramente: offline, syncing, synced, conflict. Operações enfileiradas devem ser visíveis. Conflitos exigem resolução humana explícita.
**Estados próprios:** online (synced), online (syncing), offline (funcional), offline (limitado), pendente (n operações), conflito detectado, sync failed
**Reação a estados da página:** modo offline → dados marcados como "local". Sync pendente → badge ou indicador. Conflito → dialog de resolução.
**Grau de Rigidez:** Médio

### App Lifecycle

**ID_UI_PATTERN:** UIP-MOBILE-APP_LIFECYCLE
**Categoria:** Mobile Nativo
**Definição curta:** Gestão visual de transições entre estados do app (cold start, warm start, background, foreground) com preservação de contexto.
**Objetivo estrutural:** Garantir continuidade percebida e feedback adequado nas transições de estado do app.
**Não confundir com:** UIP-FEEDBACK-LOADING_STATE genérico, splash screen decorativa, deep link handling
**Nível composicional possível:** Root
**Quando usar:** quando o cold start precisa de splash/skeleton significativo; quando o retorno de background precisa de refresh ou re-auth; quando dados sensíveis exigem blur/lock ao ir para background; quando deep links precisam de resolução com loading
**Quando evitar:** quando o app carrega instantaneamente; quando não há dados sensíveis; quando background→foreground não muda nada
**Alternativas próximas:** UIP-FEEDBACK-LOADING_STATE, splash screen simples, lock screen do SO
**Sinais de escolha:** cold start leva >1s; dados sensíveis existem; background timeout exige re-auth; deep link precisa resolver contexto
**Plataformas:** iOS (UIApplicationDelegate / SceneDelegate lifecycle), Android (Activity/Fragment lifecycle), Flutter (WidgetsBindingObserver), React Native (AppState), MAUI (Application lifecycle events)
**Estrutura iOS:** LaunchScreen.storyboard → splash animada opcional → resolução de estado → tela funcional. Background: blur de privacidade. Foreground: verificar sessão.
**Estrutura Android:** SplashScreen API → resolução de estado → tela funcional. Background: FLAG_SECURE se necessário. Recent apps: thumbnail controlada.
**Regra de adaptação cross-platform:** cold start deve ter skeleton que espelha a tela real (não logo centrada). Background privacy: blur ou placeholder para dados sensíveis. Foreground resume: verificar sessão e reconectar. Nunca mostrar dados stale sem indicador.
**Estados próprios:** cold start (first launch), warm start (from recent), foreground resume, background enter, expired session, deep link resolving
**Reação a estados da página:** expired session → lock screen ou re-auth flow. Deep link → skeleton da tela destino enquanto resolve pilha.
**Grau de Rigidez:** Alto
