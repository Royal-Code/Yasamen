# UIP-NAV-TAB_BAR - Tab Bar

## Definição

**Categoria**: Navegação

**Definição curta**: Barra de navegação fixa na base da tela com destinos principais do app, cada um com stack própria.

**Objetivo estrutural**: Organizar os destinos de topo do app em acesso persistente com alternância rápida.

**Não confundir com**: UIP-NAV-TABS (alternância local dentro de uma página), UIP-NAV-NAVIGATION_MENU (sidebar de navegação global), UIP-OVERLAY-BOTTOM_SHEET (superfície deslizante temporária).

**Nível composicional possível**: Root

## Decisão

**Quando usar**: quando o app tem 3-5 destinos principais de igual importância; quando cada destino tem navegação interna própria; quando o usuário alterna frequentemente entre destinos; quando a tab bar é a raiz estrutural do app.

**Quando evitar**: quando há mais de 5 destinos; quando um destino domina completamente; quando o app é single-purpose sem seções paralelas.

**Alternativas próximas**: UIP-NAV-NAVIGATION_MENU (navegação global em sidebar), UIP-NAV-NAV_STACK (navegação hierárquica), UIP-NAV-TABS (alternância local).

**Sinais de escolha**:
- 3-5 seções de topo
- alternância frequente
- cada seção mantém estado
- ícone e label curto são suficientes
- a barra deve estar sempre acessível

**Grau de Rigidez**: Alto — barra fixa na base com destinos raiz é invariante; número de destinos e badges variam.

## Composição

**Zonas usuais**: Navegação.

**Variantes reconhecidas**: tab bar fixa; tab bar com badge; tab bar com ação central destacada; tab bar que oculta em scroll.

## Compatibilidade com Shell Patterns

**Compatibilidade Primária**: SHP-COMMUNICATION, SHP-MEDIA_CONTENT, SHP-TRANSACTIONAL_COMMERCE, SHP-PORTAL.

**Compatibilidade Secundária**: SHP-WORKSPACE_ADMIN, SHP-DASHBOARD_ANALYTICS.

**Incompatibilidades explícitas**: SHP-FOCUSED, fluxos de etapa única e shells com hierarquia global profunda demais para 3-5 destinos.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: Todos os Page Patterns como destino raiz.

**Compatibilidade Secundária**: Nenhuma.

**Incompatibilidades explícitas**: não substitui UIP-NAV-TABS para alternância local dentro de uma página.

## Estrutura e Transição

**Estrutura Desktop**: normalmente substituída por navigation menu, sidebar ou top navigation.

**Estrutura Mobile**: barra fixa na base com 3-5 destinos (ícone e label), badge para notificações, cada destino com stack própria. Oculta em fullscreen ou com teclado.

**Regra de Transição**: 3-5 itens; cada tab preserva estado e stack; ao alternar, não resetar a stack salvo regra de pop-to-root no tap da tab ativa.

## Estados

**Estados próprios**: tab ativa, tab inativa, tab com badge, tab desativada por permissão, barra oculta em fullscreen ou com teclado.

**Reação a estados da página**: `no-permission` → tab oculta ou desativada.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo.

**Plataformas primárias**: Mobile nativo.


## Adaptação por Plataforma

**Adaptação Web**: mapear tabs para rotas e estado preservado quando a experiência for app-like.

**Adaptação Mobile nativo**: preservar stacks por tab, badges e retorno conforme a plataforma.

**Adaptação Desktop nativo**: normalmente substituir por navigation menu, sidebar ou top navigation.
