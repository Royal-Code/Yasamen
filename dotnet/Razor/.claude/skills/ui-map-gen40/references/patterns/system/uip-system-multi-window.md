# UIP-SYSTEM-MULTI_WINDOW - Multi Window

## Definição

**Categoria**: Sistema & Host

**Definição curta**: Gestão de múltiplas janelas independentes com comunicação entre elas e controle de ciclo de vida.

**Objetivo estrutural**: Permitir trabalho paralelo em múltiplos contextos com foco, posição, estado, comunicação e fechamento resiliente entre janelas.

**Não confundir com**: UIP-STRUCT-SPLIT_PANEL (divisão dentro da mesma janela), UIP-OVERLAY-FLOATING_PANEL (painel destacável), UIP-OVERLAY-MODAL (superfície bloqueante), UIP-NAV-TABS (abas internas).

**Nível composicional possível**: Root

## Decisão

**Quando usar**: quando o usuário se beneficia de ver contextos simultâneos em janelas ou monitores diferentes; quando documentos independentes coexistem; quando inspectors, previews ou ferramentas precisam ser destacáveis; quando drag/drop entre contextos faz sentido.

**Quando evitar**: quando toda interação cabe em uma janela com painéis; quando a gestão de janelas aumenta complexidade sem ganho; quando o app é single-purpose; quando a plataforma não oferece lifecycle confiável.

**Alternativas próximas**: UIP-STRUCT-SPLIT_PANEL (divisão dentro da janela), UIP-OVERLAY-FLOATING_PANEL (painel destacável), UIP-NAV-TABS (abas internas).

**Sinais de escolha**:
- IDEs, editores gráficos, ferramentas de produtividade
- múltiplos monitores
- documentos independentes
- paletas destacáveis
- comunicação entre janelas

**Grau de Rigidez**: Médio — múltiplas janelas com comunicação é invariante; layout, sincronização e ciclo de vida variam.

## Composição

**Zonas usuais**: Conteúdo.

**Variantes reconhecidas**: janelas de documento; janela principal e auxiliares; multi-monitor; pop-out window; inspector destacado; workspace independente.

## Compatibilidade com Shell Patterns

**Compatibilidade Primária**: SHP-STUDIO_WORKBENCH.

**Compatibilidade Secundária**: SHP-WORKSPACE_ADMIN, SHP-DASHBOARD_ANALYTICS, SHP-MEDIA_CONTENT.

**Incompatibilidades explícitas**: SHP-KIOSK_EMBEDDED, SHP-PORTAL, SHP-FOCUSED.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-CANVAS, PP-DETAIL.

**Compatibilidade Secundária**: PP-LIST-DETAIL, PP-DASHBOARD, PP-MAP, PP-CATALOG.

**Incompatibilidades explícitas**: PP-LANDING, PP-WIZARD e fluxos onde múltiplas janelas quebram a sequência ou a segurança.

## Estrutura e Transição

**Estrutura Desktop**: janelas independentes, cada uma com lifecycle, foco, menu ou toolbar quando aplicável e comunicação por IPC ou shared state. Posição e tamanho restauráveis.

**Estrutura Mobile**: substituir por split, tabs, stack ou navegação progressiva.

**Regra de Transição**: cada janela funciona de modo resiliente se outra fechar. A hierarquia entre janela principal e auxiliares é clara.

## Estados

**Estados próprios**: janela principal ativa, janela auxiliar ativa, background, minimizada, maximizada, em arranjo, destacada, fechada, comunicação perdida.

**Reação a estados da página**: `error` em janela auxiliar não derruba a principal. Janela fechada → limpar referências. Sessão expirada → coordenar todas as janelas.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Desktop nativo.

**Plataformas primárias**: Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: considerar limitações de pop-up, segurança, foco e comunicação entre janelas.

**Adaptação Mobile nativo**: substituir por split, tabs, stack ou navegação progressiva.

**Adaptação Desktop nativo**: usar APIs nativas de janela, lifecycle, foco, restauração, IPC e integração com taskbar ou dock.
