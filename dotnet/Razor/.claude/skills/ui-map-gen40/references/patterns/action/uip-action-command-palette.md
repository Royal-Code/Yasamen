# UIP-ACTION-COMMAND_PALETTE - Command Palette

## Definição

**Categoria**: Ação

**Definição curta**: Overlay de busca e execução rápida de comandos, arquivos, destinos ou ações por teclado.

**Objetivo estrutural**: Permitir acesso rápido a comandos e destinos sem navegar por menus, toolbars ou hierarquias de navegação.

**Não confundir com**: UIP-INPUT-SEARCH_BAR (busca de conteúdo), menu de aplicação (fora do catálogo), busca global do sistema operacional (fora do catálogo).

**Nível composicional possível**: Root

## Decisão

**Quando usar**: quando o app tem muitos comandos dispersos por menus, toolbars ou páginas; quando usuários avançados precisam de atalho para qualquer ação; quando a navegação entre arquivos, entidades ou destinos precisa ser instantânea; quando busca e execução devem ser unificadas.

**Quando evitar**: quando o app tem poucos comandos; quando o público não usa teclado com frequência; quando a busca por conteúdo já resolve a tarefa principal; quando a plataforma não tem entrada textual eficiente.

**Alternativas próximas**: UIP-INPUT-SEARCH_BAR (busca de conteúdo), UIP-ACTION-ACTION_BAR (ações visíveis), UIP-NAV-NAVIGATION_MENU (destinos principais).

**Sinais de escolha**:
- app tipo IDE, editor, console administrativo ou ferramenta de produtividade
- volume alto de comandos
- sessões longas
- fuzzy matching agrega valor
- comandos têm atalhos, categorias ou histórico

**Grau de Rigidez**: Alto — overlay de busca e execução por teclado é invariante; comandos, filtros e atalhos variam.

## Composição

**Zonas usuais**: Overlay.

**Variantes reconhecidas**: paleta de comandos; quick switcher de arquivos ou entidades; launcher de ações; busca global com execução.

## Compatibilidade com Shell Patterns

**Compatibilidade Primária**: SHP-STUDIO_WORKBENCH, SHP-WORKSPACE_ADMIN.

**Compatibilidade Secundária**: SHP-DASHBOARD_ANALYTICS, SHP-COMMUNICATION, SHP-MEDIA_CONTENT.

**Incompatibilidades explícitas**: SHP-KIOSK_EMBEDDED, SHP-FOCUSED e shells sem entrada textual eficiente.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: Todos os Page Patterns.

**Compatibilidade Secundária**: Nenhuma.

**Incompatibilidades explícitas**: não substitui UIP-INPUT-SEARCH_BAR para busca local de conteúdo nem UIP-NAV-NAVIGATION_MENU para destinos principais.

## Estrutura e Transição

**Estrutura Desktop**: atalho global abre overlay com campo de entrada, resultados filtrados, categorias, histórico recente e atalhos por item.

**Estrutura Mobile**: inadequado em mobile puro; em tablet com teclado físico, exigir acionamento explícito além do atalho.

**Regra de Transição**: o overlay e a busca com execução são preservados. O atalho respeita a convenção da plataforma; fuzzy matching é esperado; resultados mostram comando, destino, categoria e atalho.

## Estados

**Estados próprios**: oculto, aberto vazio, com resultados, sem resultados, executando comando, comando indisponível, erro de comando.

**Reação a estados da página**: `loading` → comandos context-sensitive indisponíveis temporariamente. `no-permission` → comandos restritos ocultos ou desativados. Com modal ativo, a paleta pode ficar limitada ao contexto modal.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Desktop nativo, Mobile nativo.

**Plataformas primárias**: Web, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: evitar atalhos reservados pelo browser, prover acionador visível e manter o foco controlado dentro do overlay.

**Adaptação Mobile nativo**: usar somente em apps produtivos com teclado e entrada textual eficiente; caso contrário, preferir navegação, busca local ou action bar.

**Adaptação Desktop nativo**: respeitar `Ctrl` no Windows/Linux e `Cmd` no macOS; integrar com menus e atalhos do sistema quando aplicável.
