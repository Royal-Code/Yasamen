# Blueprints Table

## Resumo
- Não gerar (já atende): 9
- Não gerar (tecnologia externa): 4
- Gerar resumido: 20
- Gerar completo: 21

| Pattern | Decisão | Motivo | Status |
|---|---|---|---|
| SHP-WORKSPACE_ADMIN - Workspace/Admin | não gerar | A biblioteca já entrega shell administrativo forte com `AppLayout`, `AppMainLayout`, topbar, sidebar e outlets. | pulado |
| SHP-PORTAL - Portal | resumido | A estrutura informativa é possível com layout e composição, mas faltam convenções de portal, seções e estados editoriais. | gerado |
| SHP-COMMUNICATION - Communication | completo | Há base visual para estruturar inbox e thread, mas faltam mensagem, composer, leitura, agrupamento e estados conversacionais. | gerado |
| SHP-MEDIA_CONTENT - Media/Content | completo | A biblioteca sustenta layout e filtros simples, mas não cobre coleções de mídia, preview, player ou gestão de conteúdo. | gerado |
| SHP-DASHBOARD_ANALYTICS - Dashboard/Analytics | completo | Faltam cards analíticos, gráficos, estados de dado e grid responsivo de widgets. | gerado |
| SHP-STUDIO_WORKBENCH - Studio/Workbench | completo | A base de shell e painéis existe, mas faltam contrato de ferramentas, área de trabalho e coordenação entre painéis. | gerado |
| SHP-TRANSACTIONAL_COMMERCE - Transactional/Commerce | completo | Componentes cobrem ações e formulários, mas carrinho, checkout, resumo e fluxo transacional precisam de blueprint. | gerado |
| SHP-KIOSK_EMBEDDED - Kiosk/Embedded | completo | Há botões e modal para fluxo focado, mas faltam regras de touch, estado full-screen e navegação simplificada. | gerado |
| PP-LIST-DETAIL | completo | O padrão exige coordenação responsiva entre lista, detalhe, filtros, seleção e estado vazio. | gerado |
| PP-CATALOG | completo | A biblioteca oferece filtros, cards e paginação, mas o padrão precisa de composição de grade, refinamento e estados de catálogo. | gerado |
| PP-FORM | resumido | `TextField` e field components são bons, porém faltam controles variados, validação integrada e layout de formulário completo. | gerado |
| PP-WIZARD | completo | Não há stepper nativo nem orquestração de passos, validação por etapa e navegação sequencial. | gerado |
| PP-DASHBOARD | completo | A composição existe, mas faltam cartões de métrica, dados, gráficos, loading e responsividade de dashboard. | gerado |
| PP-DETAIL | resumido | Breadcrumb, badges e ações ajudam, mas faltam convenções para seções, metadados e ações de detalhe. | gerado |
| PP-LANDING | resumido | É possível compor uma página institucional simples, mas não há sistema próprio de hero, seções ou mídia. | gerado |
| PP-CONVERSATION | completo | Faltam componentes e contratos para mensagens, input persistente, agrupamento, autoria e estados de envio. | gerado |
| PP-FEED | completo | Há blocos e menus, mas faltam item de feed, agrupamento, ações, loading incremental e estados de atualização. | gerado |
| PP-SETTINGS | resumido | A biblioteca oferece campos, grupos e navegação, mas precisa de convenção para seções, salvamento e feedback. | gerado |
| PP-BOARD | completo | Não há colunas, cartões arrastáveis, ordenação ou estados de board; a composição precisa ser definida. | gerado |
| PP-CALENDAR | não gerar | A solução depende quase toda de calendário especializado; Yasamen só contribuiria com botões, badges e contorno visual. | pulado |
| PP-MAP | não gerar | O núcleo depende de SDK de mapa; a biblioteca teria papel periférico em filtros, painel e feedback. | pulado |
| PP-CANVAS | não gerar | Canvas/editor exige tecnologia própria de desenho; Yasamen ajuda apenas com toolbar e painéis auxiliares. | pulado |
| UIP-STRUCT-LAYOUT_ZONE - Layout Zone | resumido | A composição é forte, mas falta uma orientação reusable para zonas nomeadas e contratos de aplicação. | gerado |
| UIP-STRUCT-SPLIT_PANEL - Split Panel | completo | OffCanvas ajuda em mobile, porém falta split panel real, redimensionamento e comportamento responsivo coordenado. | gerado |
| UIP-STRUCT-SCROLLABLE_REGION - Scrollable Region | resumido | Classes utilitárias resolvem o básico, mas faltam regras para overflow, header fixo e feedback de conteúdo longo. | gerado |
| UIP-STRUCT-STACK_CONTAINER - Stack Container | não gerar | `Stack`, `Box` e utilitários já cobrem o pattern com boa suficiência. | pulado |
| UIP-STRUCT-GRID_CONTAINER - Grid Container | não gerar | `Container`, `Slot`, `LayoutSizes` e `LayoutTypes` já formam base adequada para grid/container. | pulado |
| UIP-NAV-NAVIGATION_MENU - Navigation Menu | não gerar | Menu lateral e itens de navegação já estão bem cobertos pelo conjunto de App/Menu/SideBar. | pulado |
| UIP-NAV-BREADCRUMB - Breadcrumb | não gerar | `Breadcrumb`, `BreadcrumbItem` e `DescribesBreadcrumbs` cobrem o padrão de forma direta. | pulado |
| UIP-NAV-TABS - Tabs | completo | A biblioteca não possui tabs reais, estado selecionado, painéis associados ou comportamento acessível. | gerado |
| UIP-NAV-PAGINATION - Pagination | não gerar | `Pagination` já cobre o padrão com modos, loading e tamanhos documentados. | pulado |
| UIP-NAV-STEPPER_INDICATOR - Stepper Indicator | completo | Falta stepper com estado de etapas, progresso, validação e uso em wizard. | gerado |
| UIP-DATA-DATA_TABLE - Data Table | completo | Não há tabela de dados com colunas, sorting, seleção, densidade, loading e ações por linha. | gerado |
| UIP-DATA-LIST_ITEM - List Item | resumido | Componentes base montam item de lista, mas faltam slots e convenções para metadados, ações e estados. | gerado |
| UIP-DATA-CARD_GRID - Card Grid | resumido | Container e cards manuais ajudam, mas falta blueprint de grade, responsividade e ações por card. | gerado |
| UIP-DATA-TIMELINE_ITEM - Timeline Item | resumido | A composição visual é possível, mas faltam marcadores, linha, hierarquia temporal e estados. | gerado |
| UIP-DATA-KANBAN_COLUMN - Kanban Column | completo | Não há coluna, cartão, estados de vazio, limite ou interação de board. | gerado |
| UIP-INPUT-FORM_FIELD_GROUP - Form Field Group | resumido | Field components dão base forte, mas o grupo precisa de orientação para validação, ajuda e composição. | gerado |
| UIP-INPUT-SEARCH_BAR - Search Bar | resumido | `TextField`, `FieldAction` e botões cobrem a base; falta contrato de submit, clear e sugestões. | gerado |
| UIP-INPUT-FILTER_PANEL - Filter Panel | completo | OffCanvas e campos ajudam, mas faltam chips, aplicação, reset, resumo e responsividade do painel. | gerado |
| UIP-INPUT-DATE_PICKER - Date Picker | completo | `TextField` cobre entrada textual, mas calendário, seleção, validação e popover precisam ser propostos. | gerado |
| UIP-INPUT-INLINE_EDITOR - Inline Editor | resumido | Há campos e ações, mas falta modo view/edit, commit, cancelamento e feedback local. | gerado |
| UIP-ACTION-ACTION_BAR - Action Bar | não gerar | `Bar`, `ButtonGroup`, botões e drops já cobrem bem barra de ações. | pulado |
| UIP-ACTION-CONTEXTUAL_MENU - Contextual Menu | não gerar | `DropButton`, `DropIconButton` e `DropItem` já atendem o menu contextual básico. | pulado |
| UIP-ACTION-FLOATING_ACTION - Floating Action | resumido | Botões e overlay existem, mas falta regra de posicionamento, prioridade, responsividade e colisão com shell. | gerado |
| UIP-FEEDBACK-EMPTY_STATE - Empty State | resumido | `Feedback` e botões cobrem mensagem e ação, mas faltam variações por domínio e uso em containers. | gerado |
| UIP-FEEDBACK-LOADING_STATE - Loading State | completo | Há sinais pontuais de loading, mas falta estratégia consistente para página, botão, lista e bloco. | gerado |
| UIP-FEEDBACK-ERROR_STATE - Error State | resumido | `Feedback` cobre a mensagem, mas faltam severidade, retry, detalhe técnico e relação com formulários. | gerado |
| UIP-FEEDBACK-TOAST_ALERT - Toast / Alert | não gerar | Notifications e `Notify` cobrem toast/alert de forma forte para a biblioteca. | pulado |
| UIP-FEEDBACK-CONFIRMATION_DIALOG - Confirmation Dialog | resumido | `Modal` e botões dão base, mas falta contrato de confirmação, ações destrutivas e estados assíncronos. | gerado |
| UIP-CONTENT-DETAIL_BLOCK - Detail Block | resumido | `Box`, `Stack`, `Badge` e ações ajudam, mas falta convenção para rótulo, valor, densidade e grupos. | gerado |
| UIP-CONTENT-METRIC_CARD - Metric Card | resumido | A composição é viável, mas faltam valor, delta, ícone, tendência e estados de dado. | gerado |
| UIP-CONTENT-RICH_TEXT_BLOCK - Rich Text Block | resumido | HTML semântico e containers cobrem leitura, mas faltam regras de densidade, ações e feedback editorial. | gerado |
| UIP-CONTENT-MEDIA_VIEWER - Media Viewer | não gerar | Visualização de mídia depende de player/preview especializado; Yasamen só acrescentaria ações e moldura. | pulado |
