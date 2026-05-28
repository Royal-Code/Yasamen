# UIP-NAV-SECTION_NAV - Section Nav

## Definição

**Categoria**: Navegação

**Definição curta**: Navegação local por seções, headings ou âncoras dentro da mesma página, documento ou zona longa.

**Objetivo estrutural**: Orientar e acelerar o deslocamento dentro de conteúdo extenso sem trocar a página, o shell ou a entidade ativa.

**Não confundir com**: UIP-NAV-NAVIGATION_MENU (navegação global), UIP-NAV-BREADCRUMB (hierarquia entre níveis), UIP-NAV-TABS (vistas irmãs), UIP-STRUCT-COLLAPSIBLE_SECTION (expansão de conteúdo).

**Nível composicional possível**: Container, Leaf

## Decisão

**Quando usar**: quando a página possui seções longas ou numerosas; quando o usuário precisa saltar para headings, grupos ou regiões internas; quando documentação, settings, detalhe ou landing precisam de orientação local; quando a posição atual na página deve ser perceptível.

**Quando evitar**: quando há poucas seções visíveis sem scroll relevante; quando cada item muda a vista ativa como tabs; quando os destinos são módulos globais; quando a estrutura real é uma coleção de entidades e não seções internas.

**Alternativas próximas**: UIP-NAV-TABS (vistas irmãs), UIP-NAV-BREADCRUMB (hierarquia entre níveis), UIP-NAV-NAVIGATION_MENU (navegação global), UIP-STRUCT-COLLAPSIBLE_SECTION (expansão de conteúdo).

**Sinais de escolha**:
- existem headings ou âncoras internas
- a navegação mantém o mesmo contexto
- o scroll é parte dominante da experiência
- a seção atual pode ser destacada
- links apontam para regiões da própria página

**Grau de Rigidez**: Médio — navegação por âncoras dentro da página é estável; posição, formato e destaque variam.

## Composição

**Zonas usuais**: Navegação, Painel Auxiliar.

**Variantes reconhecidas**: sumário lateral; nav sticky por seção; índice inline; âncoras horizontais; outline de documento; section nav com destaque da seção ativa.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-DETAIL, PP-SETTINGS, PP-LANDING.

**Compatibilidade Secundária**: PP-FORM, PP-WIZARD, PP-CATALOG, PP-DASHBOARD.

**Incompatibilidades explícitas**: PP-CONVERSATION, PP-FEED (stream contínuo sem seções estáveis).

## Estrutura e Transição

**Estrutura Desktop**: índice lateral, superior ou inline com links para seções internas. Pode ser sticky e sinalizar a seção ativa conforme o scroll.

**Estrutura Mobile**: pode virar índice colapsável, barra horizontal de âncoras, botão de índice ou seção inicial com links. A navegação retorna ao conteúdo sem esconder contexto.

**Regra de Transição**: destinos internos e seção ativa são preservados. O layout lateral pode virar horizontal, colapsável ou inline, sem se transformar em navegação global.

## Estados

**Estados próprios**: seção ativa, seção inativa, seção indisponível, seção com erro, seção com pendência, índice colapsado, índice fixo, destino não encontrado.

**Reação a estados da página**: `loading` → índice skeleton ou oculto até os headings existirem. `error` → seções afetadas sinalizam erro. `empty` → índice oculto ou reduzido.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir sticky nav, scrollspy, hash anchors, offset de header fixo e comportamento de deep-link.

**Adaptação Mobile nativo**: usar índice colapsável, barra de seções ou navegação local compacta; preservar retorno claro ao conteúdo.

**Adaptação Desktop nativo**: pode compor outline documental, painel lateral e navegação por teclado entre seções.
