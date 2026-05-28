# UIP-NAV-BREADCRUMB - Breadcrumb

## Definição

**Categoria**: Navegação

**Definição curta**: Trilha hierárquica que mostra onde o usuário está e como voltar a níveis anteriores.

**Objetivo estrutural**: Orientar o usuário na hierarquia de navegação atual e permitir retorno a níveis anteriores.

**Não confundir com**: UIP-NAV-NAVIGATION_MENU (navegação global), UIP-NAV-TABS (vistas irmãs locais), botão de voltar sem contexto hierárquico (fora do catálogo).

**Nível composicional possível**: Leaf

## Decisão

**Quando usar**: quando a página está inserida numa hierarquia de navegação real; quando o usuário pode precisar regressar a níveis anteriores com contexto; quando o detalhe ou viewer deriva de navegação progressiva por níveis.

**Quando evitar**: quando a página é topo de módulo sem hierarquia relevante; quando a navegação local é entre vistas irmãs; quando um simples retorno resolve sem perda de contexto.

**Alternativas próximas**: UIP-NAV-NAVIGATION_MENU (navegação global), UIP-NAV-TABS (vistas irmãs).

**Sinais de escolha**:
- existe caminho hierárquico identificável
- níveis anteriores precisam continuar acessíveis
- a localização atual importa para orientação
- a página não é apenas uma aba ou estado local

**Grau de Rigidez**: Alto — trilha hierárquica com retorno é invariante; profundidade, truncamento e estilo variam.

## Composição

**Zonas usuais**: Cabeçalho.

**Variantes reconhecidas**: trilha completa; trilha truncada com overflow; trilha com dropdown de nível.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-LIST-DETAIL, PP-DETAIL.

**Compatibilidade Secundária**: PP-CATALOG, PP-SETTINGS.

**Incompatibilidades explícitas**: PP-DASHBOARD, PP-LANDING, PP-FEED.

## Estrutura e Transição

**Estrutura Desktop**: linha horizontal de itens separados por separador. Item atual destacado e não clicável. Itens anteriores clicáveis.

**Estrutura Mobile**: truncamento dos níveis intermediários. Exibe apenas o nível anterior e o atual, ou só o anterior como link de retorno.

**Regra de Transição**: hierarquia completa → versão compacta. Nunca ocultar o nível atual.

## Estados

**Estados próprios**: nível atual não navegável, nível anterior navegável, nível truncado.

**Reação a estados da página**: `loading` → itens em skeleton até a navegação estar definida.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Desktop nativo.

**Plataformas primárias**: Web, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: truncar em viewport pequeno sem ocultar a localização atual.

**Adaptação Mobile nativo**: normalmente substituir por UIP-NAV-NAV_STACK e título ou back contextual.

**Adaptação Desktop nativo**: pode coexistir com menu global e detalhes hierárquicos.
