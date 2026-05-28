# UIP-OVERLAY-FLOATING_PANEL - Floating Panel

## Definição

**Categoria**: Overlay & Superfície Temporária

**Definição curta**: Painel destacável, reposicionável e opcionalmente ancorável para ferramentas, inspectors, propriedades ou paletas.

**Objetivo estrutural**: Permitir que painéis auxiliares flutuem sobre o conteúdo ou sejam ancorados conforme contexto e preferência do usuário.

**Não confundir com**: UIP-STRUCT-SPLIT_PANEL (painel fixo), UIP-SYSTEM-MULTI_WINDOW (janela independente), UIP-OVERLAY-POPOVER (superfície leve), UIP-OVERLAY-TOOLTIP (ajuda informativa).

**Nível composicional possível**: Container

## Decisão

**Quando usar**: quando inspectors, propriedades ou ferramentas precisam estar visíveis sem ocupar espaço fixo; quando o usuário pode personalizar o layout; quando painéis devem alternar entre docked e floating; quando a área principal não deve ser permanentemente reduzida.

**Quando evitar**: quando painéis fixos resolvem; quando o app não justifica personalização de layout; quando o conteúdo do painel é raramente consultado; quando o painel bloquearia a tarefa principal de forma imprevisível.

**Alternativas próximas**: UIP-STRUCT-SPLIT_PANEL (painel fixo), UIP-SYSTEM-MULTI_WINDOW (janela independente), UIP-OVERLAY-DRAWER (painel temporário lateral), UIP-OVERLAY-BOTTOM_SHEET (superfície deslizante).

**Sinais de escolha**:
- IDEs, editores gráficos, ferramentas de produtividade avançada
- inspector de propriedades
- paletas de ferramentas
- o usuário reorganiza frequentemente o workspace

**Grau de Rigidez**: Baixo — painel destacável e reposicionável é estável; ancoragem, conteúdo e persistência variam.

## Composição

**Zonas usuais**: Painel Auxiliar, Overlay.

**Variantes reconhecidas**: floating panel; docked panel; auto-hide panel; pinned panel; utility window; palette.

## Compatibilidade com Shell Patterns

**Compatibilidade Primária**: SHP-STUDIO_WORKBENCH.

**Compatibilidade Secundária**: SHP-WORKSPACE_ADMIN, SHP-DASHBOARD_ANALYTICS, SHP-MEDIA_CONTENT.

**Incompatibilidades explícitas**: SHP-KIOSK_EMBEDDED, SHP-PORTAL, SHP-FOCUSED.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-CANVAS.

**Compatibilidade Secundária**: PP-DETAIL, PP-DASHBOARD, PP-LIST-DETAIL, PP-MAP.

**Incompatibilidades explícitas**: PP-LANDING, PP-CONVERSATION, PP-FEED quando painéis flutuantes não fazem parte da tarefa.

## Estrutura e Transição

**Estrutura Desktop**: painel com cabeçalho compacto, controles de fechar, pin e dock, drag para reposicionar e persistência de posição e tamanho.

**Estrutura Mobile**: transformar em bottom sheet, drawer ou tela de detalhe; flutuação livre não é adequada.

**Regra de Transição**: suportar float e dock quando ambos fazem parte da experiência. Persistir o layout entre sessões e oferecer reset. O painel não impede o acesso ao conteúdo principal de forma permanente.

## Estados

**Estados próprios**: docked, floating, auto-hidden, dragging, resizing, pinned, unpinned, minimizado, contexto vazio, carregando.

**Reação a estados da página**: `loading` → painel mostra skeleton do conteúdo próprio. `empty` → empty state ou painel desativado. `no-permission` → ações restritas ocultas ou desativadas.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Desktop nativo.

**Plataformas primárias**: Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: limitar a posição ao viewport, tratar responsividade e oferecer modo docked ou colapsado.

**Adaptação Mobile nativo**: transformar em bottom sheet, drawer ou tela de detalhe quando não houver espaço para flutuação controlável.

**Adaptação Desktop nativo**: integrar com foco, janelas utilitárias, atalhos, docking e persistência de layout.
