# UI Patterns de Entrada

UI Patterns de entrada sustentam captura, refinamento, edição e parametrização de informação.

## Patterns

### Form Field Group

**ID_UI_PATTERN:** UIP-INPUT-FORM_FIELD_GROUP
**Categoria:** Entrada
**Definição curta:** Agrupamento lógico de campos relacionados, com validação e feedback coerentes dentro da mesma secção.
**Objetivo estrutural:** Agrupar campos de entrada relacionados numa secção lógica com validação e feedback.
**Não confundir com:** Filter Panel para refinamento de colecções, Detail Block para leitura, formulário inteiro de múltiplas secções
**Nível composicional possível:** Container, Leaf
**Quando usar:** quando vários campos pertencem à mesma secção lógica de captura; quando a validação e o feedback precisam ficar associados ao grupo; quando a tela exige organização clara por blocos de formulário
**Quando evitar:** quando a intenção é filtrar resultados e não persistir dados; quando a zona é apenas leitura estruturada; quando um único campo isolado resolve a interação
**Alternativas próximas:** UIP-INPUT-FILTER_PANEL, UIP-CONTENT-DETAIL_BLOCK, campo isolado
**Sinais de escolha:** campos compartilham um mesmo objetivo de edição; existe título ou agrupamento de secção; validação do grupo é relevante; a captura acontece por bloco, não só por campo isolado
**Zonas usuais:** Form Body, Settings Section, Step Body
**Compatibilidade Primária:** Form, Settings, Wizard/Stepper
**Compatibilidade Secundária:** Detail/Viewer (edição inline de secção)
**Incompatibilidades explícitas:** Não substitui Filter Panel em contexto de filtros
**Estrutura Desktop:** Secção com título opcional, campos em 1 ou 2 colunas, validação inline abaixo de cada campo.
**Estrutura Mobile:** Campos em coluna única. Títulos preservados. Teclado nativo considerado no layout.
**Regra de Transição:** 2 colunas → 1 coluna. Campos em largura completa. Validação inline preservada.
**Estados próprios:** vazio, preenchendo, válido, com erro de validação, desactivado, somente leitura, a submeter
**Reação a estados da página:** Error State (submissão) → campos com erro destacados. Loading State (submissão) → campos desactivados.
**Grau de Rigidez:** Médio
**Variantes reconhecidas:** Secção de formulário simples; Grupo de campos repetíveis ou compostos

### Search Bar

**ID_UI_PATTERN:** UIP-INPUT-SEARCH_BAR
**Categoria:** Entrada
**Definição curta:** Entrada textual de busca para localizar itens, entidades ou conteúdo numa coleção.
**Objetivo estrutural:** Capturar termos de busca textual e iniciar pesquisa em colecção.
**Não confundir com:** Filter Panel estruturado, campo de formulário genérico, command palette global
**Nível composicional possível:** Leaf
**Quando usar:** quando a principal forma de localizar conteúdo é por termo textual; quando o utilizador precisa refinar rapidamente grandes colecções; quando sugestões, histórico ou autocomplete agregam valor à descoberta
**Quando evitar:** quando o refinamento depende de múltiplos atributos estruturados; quando a interação principal é captura de dado persistente; quando a busca não tem papel relevante na página
**Alternativas próximas:** UIP-INPUT-FILTER_PANEL, campo de formulário, command/search global
**Sinais de escolha:** há volume de itens que justifica busca textual; o utilizador tende a conhecer nomes, termos ou códigos; a busca pode disparar resultados ou sugestões; a zona precisa suportar limpar e reexecutar busca
**Zonas usuais:** Header, List Toolbar, Catalog Header
**Compatibilidade Primária:** Catalog/Grid, List+Detail
**Compatibilidade Secundária:** Feed/Timeline, Dashboard
**Incompatibilidades explícitas:** Form, Wizard/Stepper
**Estrutura Desktop:** Campo de texto com ícone de busca, botão de limpar, sugestões dropdown opcionais.
**Estrutura Mobile:** Campo expandido para largura total. Sugestões em overlay em contextos complexos.
**Regra de Transição:** Campo preservado. Sugestões → overlay. Botão de cancelar visível em Mobile.
**Estados próprios:** vazio/inactivo, digitando, buscando, com resultados, sem resultados, com sugestões visíveis
**Reação a estados da página:** Loading State (busca) → indicador de progresso no campo.
**Grau de Rigidez:** Médio

### Filter Panel

**ID_UI_PATTERN:** UIP-INPUT-FILTER_PANEL
**Categoria:** Entrada
**Definição curta:** Área de filtros estruturados para refinar coleções por atributos, estados ou facetas.
**Objetivo estrutural:** Filtrar colecções por múltiplos atributos estruturados com aplicação explícita ou reactiva.
**Não confundir com:** Search Bar textual, Form Field Group de captura, menu de ordenação simples
**Nível composicional possível:** Container
**Quando usar:** quando a coleção precisa ser refinada por múltiplos atributos; quando facetas, intervalos, estados e filtros compostos fazem parte da navegação; quando os filtros precisam permanecer visíveis ou acessíveis como bloco coerente
**Quando evitar:** quando um único termo textual resolve a busca; quando a tela é formulário de captura e não refinamento de resultados; quando os filtros são tão simples que cabem em controle único isolado
**Alternativas próximas:** UIP-INPUT-SEARCH_BAR, controlo de ordenação, UIP-INPUT-FORM_FIELD_GROUP
**Sinais de escolha:** existem vários atributos filtráveis; filtros activos precisam ser visíveis e reversíveis; o utilizador combina critérios; o refinamento altera uma coleção já exibida
**Zonas usuais:** Filter, Sidebar, Results Toolbar
**Compatibilidade Primária:** List+Detail, Catalog/Grid
**Compatibilidade Secundária:** Dashboard
**Incompatibilidades explícitas:** Form, Wizard/Stepper, Conversation
**Estrutura Desktop:** Painel lateral ou área superior com filtros por atributo. Botão de aplicar ou reactivo. Indicador de filtros activos. Opção de limpar todos.
**Estrutura Mobile:** Filtros em drawer/gaveta ou modal. Botão de filtro na página com indicador de activos.
**Regra de Transição:** Painel visível → gaveta ou modal. Indicador de filtros activos sempre visível.
**Estados próprios:** sem filtros activos, com filtros activos, a aplicar filtros, resultados filtrados
**Reação a estados da página:** Loading State → filtros desactivados durante carregamento.
**Grau de Rigidez:** Médio

### Date Picker

**ID_UI_PATTERN:** UIP-INPUT-DATE_PICKER
**Categoria:** Entrada
**Definição curta:** Controle estruturado para seleção de data única ou intervalo de datas.
**Objetivo estrutural:** Capturar data ou intervalo de datas de forma estruturada.
**Não confundir com:** campo textual livre, filtro genérico sem calendário, seletor de período exclusivamente analítico
**Nível composicional possível:** Leaf
**Quando usar:** quando a data ou intervalo é parte explícita da entrada ou do filtro; quando calendário, validação de datas e restrições de período agregam valor; quando o utilizador não deve digitar datas complexas livremente
**Quando evitar:** quando um texto livre basta e não há regra temporal relevante; quando o período é pré-definido por atalhos fixos sem escolha granular; quando a data é apenas exibida e não editada
**Alternativas próximas:** campo de texto com máscara, seletor de período predefinido, filtro simples
**Sinais de escolha:** a data é parte estrutural da ação ou filtro; intervalo de datas pode ser necessário; restrições como datas inválidas ou desactivadas importam; o utilizador precisa apoio visual de calendário
**Zonas usuais:** Form Body, Filter Panel, Settings
**Compatibilidade Primária:** Form, Filter Panel
**Compatibilidade Secundária:** Settings
**Incompatibilidades explícitas:** Nenhuma fora de contexto de entrada
**Estrutura Desktop:** Campo de texto com ícone de calendário. Calendário em dropdown. Navegação por mês/ano. Selecção de intervalo opcional.
**Estrutura Mobile:** Pode usar modal, sheet ou picker nativo, conforme plataforma, granularidade da selecção e complexidade da interação.
**Regra de Transição:** Dropdown → variante mobile equivalente. Picker nativo pode substituir calendário custom quando melhorar consistência e usabilidade.
**Estados próprios:** vazio, com data seleccionada, com intervalo seleccionado, data inválida, data desactivada, calendário aberto
**Reação a estados da página:** Error State → campo com mensagem de data inválida ou obrigatória.
**Grau de Rigidez:** Médio

### Inline Editor

**ID_UI_PATTERN:** UIP-INPUT-INLINE_EDITOR
**Categoria:** Entrada
**Definição curta:** Edição localizada no próprio ponto de leitura, sem abrir formulário separado.
**Objetivo estrutural:** Permitir edição de um valor directamente no local onde é exibido, sem abrir Form separado.
**Não confundir com:** Form Field Group completo, edição em tabela massiva, Detail Block apenas de leitura
**Nível composicional possível:** Leaf
**Quando usar:** quando a edição é simples e localizada; quando a leitura e a edição precisam coexistir no mesmo ponto; quando abrir formulário separado seria fricção desnecessária
**Quando evitar:** quando múltiplos campos dependem um do outro; quando a validação é complexa; quando a edição precisa de contexto amplo ou confirmação extensa
**Alternativas próximas:** UIP-INPUT-FORM_FIELD_GROUP, edição em modal, Data Table editável
**Sinais de escolha:** o valor pode ser alterado isoladamente; a edição pode acontecer em contexto de leitura; o utilizador beneficia de mudança rápida; a confirmação pode ser local e simples
**Zonas usuais:** Detail Block, Table Cell, Settings Value
**Compatibilidade Primária:** Detail/Viewer, List+Detail (variante Data Table editável)
**Compatibilidade Secundária:** Settings
**Incompatibilidades explícitas:** Edição de múltiplos campos relacionados — usar Form Field Group
**Estrutura Desktop:** Campo activado por clique/duplo clique. Confirmação por Enter ou blur. Cancelamento por Escape.
**Estrutura Mobile:** Activação por toque. Campo com botões de confirmar/cancelar explícitos.
**Regra de Transição:** Activação implícita → botões explícitos em Mobile.
**Estados próprios:** exibindo valor, em edição, a guardar, guardado, com erro de validação
**Reação a estados da página:** Loading State (guardar) → campo desactivado com indicador.
**Grau de Rigidez:** Baixo