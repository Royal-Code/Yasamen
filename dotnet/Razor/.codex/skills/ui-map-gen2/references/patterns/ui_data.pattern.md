# UI Patterns de Dados e Listagem

UI Patterns de dados e listagem sustentam leitura, comparação, navegação e operação sobre coleções ou fluxos de itens.

## Patterns

### Data Table

**ID_UI_PATTERN:** UIP-DATA-DATA_TABLE
**Categoria:** Dados & Listagem
**Definição curta:** Representação tabular de colecções com comparação por linha e coluna, normalmente com ações e seleção.
**Objetivo estrutural:** Apresentar colecções de entidades em formato tabular com acções por linha e selecção múltipla.
**Não confundir com:** Card Grid exploratório, List Item simples, planilha livre de edição massiva
**Nível composicional possível:** Root, Container (contém Action Bar, Pagination)
**Quando usar:** quando o utilizador precisa comparar múltiplos atributos por linha; quando há seleção em lote, ordenação, filtros e ações operacionais; quando a densidade informacional é mais importante que apelo exploratório
**Quando evitar:** quando a apresentação depende de imagem, identidade visual ou descoberta exploratória; quando a coleção tem poucos atributos e leitura linear simples; quando a interação principal é cronológica, conversacional ou editorial
**Alternativas próximas:** UIP-DATA-CARD_GRID, UIP-DATA-LIST_ITEM, variante Kanban/Board
**Sinais de escolha:** comparação por colunas é relevante; existem ações por linha ou seleção múltipla; ordenação e paginação fazem sentido; a coleção tem estrutura previsível por atributo
**Zonas usuais:** List, Table-Area, Results
**Compatibilidade Primária:** List+Detail
**Compatibilidade Secundária:** Dashboard
**Incompatibilidades explícitas:** Feed/Timeline, Catalog/Grid, Conversation
**Estrutura Desktop:** Tabela com cabeçalho fixo, linhas de dados, coluna de acções, checkbox de selecção, ordenação por coluna clicável. Action Bar acima. Pagination abaixo.
**Estrutura Mobile:** Representação tabular compacta ou híbrida. Pode reduzir densidade, colapsar colunas secundárias, usar detalhe expandido e redistribuir ações para overflow contextual.
**Regra de Transição:** Tabela completa → tabela compacta ou híbrida. Informação crítica e ações essenciais nunca podem ser omitidas; podem ser reorganizadas para formatos touch-friendly.
**Estados próprios:** vazio, a carregar, com resultados, linha seleccionada, múltiplas linhas seleccionadas, filtro activo, ordenação activa, erro
**Reação a estados da página:** Empty State → exibe Empty State dentro da tabela. Loading State → skeleton de linhas. Error State → mensagem com retry. No Permission State → tabela oculta ou sem acções restritas.
**Grau de Rigidez:** Médio
**Variantes reconhecidas:** Data Table com expansão de linha — linha expansível com detalhe inline; Data Table editável — células editáveis inline sem Form separado

### List Item

**ID_UI_PATTERN:** UIP-DATA-LIST_ITEM
**Categoria:** Dados & Listagem
**Definição curta:** Unidade simples de listagem para leitura linear e ação localizada sobre um item.
**Objetivo estrutural:** Representar um item individual dentro de uma lista simples.
**Não confundir com:** Data Table com comparação por colunas, Card Grid exploratório, Timeline Item cronológico
**Nível composicional possível:** Leaf
**Quando usar:** quando a leitura principal é item a item, em sequência linear; quando a coleção é simples ou de baixa densidade informacional; quando o foco está em título, subtítulo e poucos metadados
**Quando evitar:** quando comparação por múltiplos atributos é central; quando imagem e apelo visual são dominantes; quando a ordem temporal e o contexto de evento são o centro da experiência
**Alternativas próximas:** UIP-DATA-DATA_TABLE, UIP-DATA-CARD_GRID, UIP-DATA-TIMELINE_ITEM
**Sinais de escolha:** cada item cabe em uma linha ou bloco simples; poucos atributos precisam ficar visíveis ao mesmo tempo; ações por item são leves e localizadas; a lista pode ser percorrida rapidamente em sequência
**Zonas usuais:** List, Search Results, Navigation List
**Compatibilidade Primária:** Navigation Menu, resultados de Search Bar
**Compatibilidade Secundária:** Todos os Page Patterns como unidade em listas simples
**Incompatibilidades explícitas:** Não substitui Data Table em colecções com múltiplos atributos
**Estrutura Desktop:** Linha horizontal com ícone/avatar opcional, título, subtítulo opcional, metadado secundário, acção contextual.
**Estrutura Mobile:** Estrutura preservada. Metadados secundários podem ser omitidos. Área de toque ampliada.
**Regra de Transição:** Layout preservado. Redução de informação secundária. Área de toque nunca inferior a 44px.
**Estados próprios:** normal, hover, seleccionado, desactivado, com badge/notificação
**Reação a estados da página:** Loading State → skeleton do item.
**Grau de Rigidez:** Baixo

### Card Grid

**ID_UI_PATTERN:** UIP-DATA-CARD_GRID
**Categoria:** Dados & Listagem
**Definição curta:** Grade de itens visuais para exploração, descoberta e comparação leve entre cards.
**Objetivo estrutural:** Apresentar colecções de itens em formato visual exploratório com ênfase em imagem ou identidade visual.
**Não confundir com:** Data Table operacional, List Item linear, Grid Container apenas estrutural
**Nível composicional possível:** Root, Container
**Quando usar:** quando a descoberta visual ou identidade do item ajuda a decisão; quando imagem, ícone ou resumo visual têm peso real; quando a coleção beneficia de exploração em grade e leitura mais livre
**Quando evitar:** quando a operação exige comparação densa por atributo; quando há muitas ações complexas por item; quando o contexto é puramente cronológico ou conversacional
**Alternativas próximas:** UIP-DATA-DATA_TABLE, UIP-DATA-LIST_ITEM, UIP-STRUCT-GRID_CONTAINER
**Sinais de escolha:** cada item tem representação visual própria; a coleção é exploratória ou catálogo; poucos dados estruturados bastam por item; a navegação parte do reconhecimento visual
**Zonas usuais:** Catalog Area, Grid Results, Dashboard Collections
**Compatibilidade Primária:** Catalog/Grid
**Compatibilidade Secundária:** Dashboard, Feed/Timeline
**Incompatibilidades explícitas:** List+Detail operacional com acções complexas
**Estrutura Desktop:** Grelha de cards com 3 a 5 colunas. Card com imagem/ícone, título, subtítulo, metadado, acção primária.
**Estrutura Mobile:** 1 a 2 colunas. Card compacto com informação essencial.
**Regra de Transição:** Redução de colunas. Card pode simplificar conteúdo secundário. Nunca ocultar acção primária.
**Estados próprios:** a carregar (skeleton), sem resultados, com resultados, filtro activo, card hover, card seleccionado
**Reação a estados da página:** Empty State → exibe Empty State na área da grelha. Loading State → skeleton de cards. Error State → mensagem com retry.
**Grau de Rigidez:** Médio

### Timeline Item

**ID_UI_PATTERN:** UIP-DATA-TIMELINE_ITEM
**Categoria:** Dados & Listagem
**Definição curta:** Entrada cronológica de evento, actividade ou histórico em uma linha temporal.
**Objetivo estrutural:** Representar um evento ou entrada num feed cronológico ou histórico de actividade.
**Não confundir com:** List Item genérico, card de catálogo, mensagem conversacional
**Nível composicional possível:** Leaf
**Quando usar:** quando tempo, sequência e histórico importam; quando cada item representa um evento ou actualização; quando o utilizador precisa percorrer atividade em ordem temporal
**Quando evitar:** quando a coleção é operacional e comparativa; quando a experiência é de catálogo ou grid; quando a interação principal é diálogo bidirecional
**Alternativas próximas:** UIP-DATA-LIST_ITEM, UIP-DATA-CARD_GRID, item de conversation
**Sinais de escolha:** a ordem temporal é central; cada item representa evento ou atividade; timestamp e contexto do evento são relevantes; o histórico pode crescer continuamente
**Zonas usuais:** Feed List, Activity History, Audit Trail
**Compatibilidade Primária:** Feed/Timeline
**Compatibilidade Secundária:** Dashboard, Detail/Viewer
**Incompatibilidades explícitas:** List+Detail operacional, Catalog/Grid
**Estrutura Desktop:** Linha com indicador de tempo, avatar/ícone, conteúdo principal, acções inline.
**Estrutura Mobile:** Estrutura preservada. Acções por gesto longo ou menu contextual.
**Regra de Transição:** Layout preservado com ajuste de espaçamento. Acções inline → menu contextual.
**Estados próprios:** normal, não lido/novo, expandido, colapsado, com acção em progresso, erro
**Reação a estados da página:** Loading State → skeleton do item.
**Grau de Rigidez:** Baixo

### Kanban Column

**ID_UI_PATTERN:** UIP-DATA-KANBAN_COLUMN
**Categoria:** Dados & Listagem
**Definição curta:** Coluna de board que agrupa itens por estado, etapa ou categoria operacional.
**Objetivo estrutural:** Agrupar e apresentar itens por categoria/estado em formato de coluna arrastável.
**Não confundir com:** Data Table por status, Grid Container estrutural, Split Panel de duas áreas
**Nível composicional possível:** Container
**Quando usar:** quando o fluxo é melhor entendido por estados ou colunas; quando mover itens entre categorias faz parte da tarefa; quando a visão de board agrega mais valor que lista linear
**Quando evitar:** quando comparação tabular é mais importante; quando a coleção não tem estados ou agrupamentos claros; quando o mobile não consegue sustentar a interação de board sem perda excessiva
**Alternativas próximas:** UIP-DATA-DATA_TABLE, board simplificado por listas, UIP-STRUCT-GRID_CONTAINER
**Sinais de escolha:** os itens pertencem a colunas semânticas; mudança de estado é recorrente; a visão horizontal por coluna ajuda a operação; drag-and-drop ou equivalente faz sentido
**Zonas usuais:** Board Area, Workflow Board, Stage Columns
**Compatibilidade Primária:** List+Detail (variante Kanban/Board)
**Compatibilidade Secundária:** —
**Incompatibilidades explícitas:** Dashboard, Feed/Timeline, Catalog/Grid
**Estrutura Desktop:** Colunas horizontais com scroll vertical interno. Cabeçalho com nome e contagem. Itens arrastáveis entre colunas.
**Estrutura Mobile:** Uma coluna visível de cada vez com navegação horizontal. Drag-and-drop substituído por acção de menu.
**Regra de Transição:** Múltiplas colunas simultâneas → coluna única com navegação. Arrastar → acção de menu.
**Estados próprios:** normal, em destaque (item a ser solto), vazia, com limite atingido
**Reação a estados da página:** Loading State → skeleton das colunas. Empty State → coluna vazia com CTA de criação.
**Grau de Rigidez:** Médio
