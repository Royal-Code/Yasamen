# UIP-NAV-TABS - Tabs

## Definição

**Categoria**: Navegação

**Definição curta**: Navegação local entre vistas irmãs da mesma página ou zona, sem trocar o papel estrutural da tela.

**Objetivo estrutural**: Alternar entre vistas ou seções dentro da mesma página sem navegação de rota.

**Não confundir com**: UIP-NAV-NAVIGATION_MENU (navegação global), UIP-NAV-SECTION_NAV (âncoras internas), UIP-NAV-STEPPER_INDICATOR (fluxo sequencial), UIP-STRUCT-COLLAPSIBLE_SECTION (conteúdo colapsável).

**Nível composicional possível**: Container

## Decisão

**Quando usar**: quando várias vistas compartilham o mesmo contexto de página; quando o usuário precisa alternar entre seções irmãs sem perder o contexto principal; quando o conteúdo ativo deve trocar sem reestruturar o shell.

**Quando evitar**: quando a navegação é global do sistema; quando os links apontam para seções da própria página sem trocar a vista ativa; quando existe sequência obrigatória entre etapas; quando a quantidade de opções torna a leitura horizontal instável.

**Alternativas próximas**: UIP-NAV-SECTION_NAV (âncoras internas), UIP-NAV-NAVIGATION_MENU (navegação global), UIP-NAV-STEPPER_INDICATOR (fluxo sequencial), UIP-INPUT-OPTION_PICKER (selector de vistas).

**Sinais de escolha**:
- vistas irmãs compartilham o mesmo cabeçalho ou contexto
- o usuário pode alternar livremente entre seções
- apenas uma vista fica ativa por vez
- a zona de conteúdo abaixo muda, mas a página continua a mesma

**Grau de Rigidez**: Médio — alternância entre vistas irmãs dentro da mesma zona é invariante; scroll, dropdown e estilo variam.

## Composição

**Zonas usuais**: Navegação, Conteúdo.

**Variantes reconhecidas**: tabs fixas; tabs com scroll lateral; tabs com overflow ou dropdown; tabs com badge ou contagem.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-DETAIL, PP-SETTINGS.

**Compatibilidade Secundária**: PP-DASHBOARD, PP-LIST-DETAIL.

**Incompatibilidades explícitas**: PP-WIZARD, PP-FEED.

## Estrutura e Transição

**Estrutura Desktop**: barra de tabs horizontal no topo da zona. Conteúdo da tab ativa abaixo.

**Estrutura Mobile**: tabs horizontais com scroll lateral se excederem a largura. Alternativa: selector dropdown para muitas tabs.

**Regra de Transição**: barra horizontal preservada. Scroll lateral em Mobile. Nunca colapsar tabs em menu oculto sem alternativa visível.

## Estados

**Estados próprios**: tab ativa, tab inativa, tab com badge ou contagem, tab desativada, tab com erro.

**Reação a estados da página**: `loading` → conteúdo da tab ativa em loading. `error` → tab com erro sinalizada.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir scroll, wrap ou selector quando houver muitas tabs.

**Adaptação Mobile nativo**: diferenciar tabs locais de UIP-NAV-TAB_BAR, que é navegação raiz.

**Adaptação Desktop nativo**: decidir scroll, overflow e foco por teclado entre tabs.
