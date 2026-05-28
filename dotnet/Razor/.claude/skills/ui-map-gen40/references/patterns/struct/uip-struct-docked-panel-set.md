# UIP-STRUCT-DOCKED_PANEL_SET - Docked Panel Set

## Definição

**Categoria**: Estrutural

**Definição curta**: Conjunto de painéis acoplados, persistentes e coordenados ao redor de uma área principal de trabalho.

**Objetivo estrutural**: Organizar workspaces densos com múltiplas responsabilidades simultâneas — navegação, propriedades, inspector, ferramentas, preview, console ou timeline — mantendo relação estável com a área central.

**Não confundir com**: UIP-STRUCT-SPLIT_PANEL (dois painéis), UIP-OVERLAY-FLOATING_PANEL (painel destacável), UIP-OVERLAY-DRAWER (painel temporário), UIP-NAV-NAVIGATION_MENU (navegação global).

**Nível composicional possível**: Root, Container

## Decisão

**Quando usar**: quando a tela precisa de vários painéis persistentes e coordenados; quando uma área central depende de painéis laterais, inferiores ou auxiliares; quando o usuário alterna continuamente entre navegação, edição, propriedades e saída; quando redimensionamento, colapso ou docking são parte natural do workspace.

**Quando evitar**: quando apenas dois painéis resolvem a relação; quando os painéis são temporários ou contextuais; quando a plataforma principal é phone; quando a tarefa é linear, formulário simples ou leitura sem operação contínua.

**Alternativas próximas**: UIP-STRUCT-SPLIT_PANEL (dois painéis), UIP-OVERLAY-FLOATING_PANEL (painel destacável), UIP-OVERLAY-DRAWER (painel temporário), UIP-STRUCT-LAYOUT_ZONE (zona funcional).

**Sinais de escolha**:
- há área principal de trabalho
- existem três ou mais regiões simultâneas
- painéis podem ser recolhidos, redimensionados ou alternados
- o uso é prolongado e operacional
- estado de foco e seleção afeta o conteúdo dos painéis

**Grau de Rigidez**: Alto — painéis acoplados ao redor da área principal são invariantes; número, posição e colapsibilidade variam por ferramenta.

## Composição

**Zonas usuais**: Painel Auxiliar, Conteúdo, Superfície.

**Variantes reconhecidas**: layout IDE; workbench com explorer e inspector; painel inferior de output; painéis recolhíveis; painéis redimensionáveis; painéis tabulados; docking fixo por perfil de usuário.

**UI Patterns tipicamente contidos**: UIP-STRUCT-SPLIT_PANEL, UIP-STRUCT-SCROLLABLE_REGION, UIP-STRUCT-COLLAPSIBLE_SECTION, UIP-OVERLAY-FLOATING_PANEL, UIP-NAV-TABS, UIP-CONTENT-DETAIL_BLOCK, UIP-ACTION-ACTION_BAR.

## Compatibilidade com Shell Patterns

**Compatibilidade Primária**: SHP-STUDIO_WORKBENCH.

**Compatibilidade Secundária**: SHP-WORKSPACE_ADMIN, SHP-DASHBOARD_ANALYTICS, SHP-COMMUNICATION.

**Incompatibilidades explícitas**: SHP-PORTAL, SHP-KIOSK_EMBEDDED, SHP-FOCUSED.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-CANVAS, PP-LIST-DETAIL.

**Compatibilidade Secundária**: PP-DASHBOARD, PP-DETAIL, PP-BOARD, PP-MAP, PP-CALENDAR.

**Incompatibilidades explícitas**: PP-FORM, PP-WIZARD, PP-LANDING.

## Estrutura e Transição

**Estrutura Desktop**: área central com painéis acoplados nas laterais e na base. Painéis podem ter abas, divisores, colapso, resize e estados persistidos. Foco, seleção e contexto coordenam o conteúdo dos painéis.

**Estrutura Mobile**: não preservar múltiplos painéis simultâneos em phone comum. Transformar painéis em stack, abas locais, sheets, telas auxiliares ou modos dedicados.

**Regra de Transição**: simultaneidade ampla → acesso sequencial ou modalizado. A área principal e o painel mais relevante ao contexto permanecem acessíveis sem perder a seleção ativa.

## Estados

**Estados próprios**: painel aberto, painel recolhido, painel oculto, painel em foco, painel redimensionado, painel tabulado, layout restaurado, sem seleção, conteúdo indisponível, permissão restrita.

**Reação a estados da página**: `loading` → painéis carregam independentemente. `error` → erro localizado no painel afetado. `empty` → painel contextual mostra ausência de seleção ou conteúdo.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Desktop nativo.

**Plataformas primárias**: Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir painéis fixos, colapsáveis, redimensionáveis, persistência de layout e breakpoints onde painéis viram overlays ou telas.

**Adaptação Mobile nativo**: decompor em navegação por stack, sheets ou telas auxiliares; manter seleção e retorno claros.

**Adaptação Desktop nativo**: pode usar docking persistente, atalhos, menus, janelas auxiliares e restauração por workspace.
