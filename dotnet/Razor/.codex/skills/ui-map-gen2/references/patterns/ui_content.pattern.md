# UI Patterns de Conteúdo

UI Patterns de conteúdo organizam leitura, síntese e visualização de informação semântica ou multimédia.

## Patterns

### Detail Block

**ID_UI_PATTERN:** UIP-CONTENT-DETAIL_BLOCK
**Categoria:** Conteúdo
**Definição curta:** Bloco de leitura estruturada de atributos, propriedades e metadados de uma entidade ou contexto específico.
**Objetivo estrutural:** Apresentar atributos e metadados de uma entidade específica de forma estruturada.
**Não confundir com:** Rich Text Block editorial, Metric Card sintético, Form Field Group para captura de dados
**Nível composicional possível:** Container, Leaf
**Quando usar:** quando a prioridade é leitura estruturada de atributos e metadados; quando a entidade precisa ser apresentada em grupos lógicos de informação; quando a zona deve suportar leitura e eventual edição localizada por secção
**Quando evitar:** quando o conteúdo é editorial, narrativo ou documental livre; quando a prioridade é destacar poucos indicadores sintéticos; quando a interação principal é captura de dados em vez de leitura
**Alternativas próximas:** UIP-CONTENT-RICH_TEXT_BLOCK, UIP-CONTENT-METRIC_CARD, UIP-INPUT-FORM_FIELD_GROUP
**Sinais de escolha:** existem rótulos e valores estruturados; os atributos podem ser agrupados por secções; a leitura depende de pares nome/valor ou metadado/valor; o utilizador precisa consultar detalhes de uma entidade específica
**Zonas usuais:** Detail-Panel, Content-Body, Summary Section
**Compatibilidade Primária:** List+Detail, Detail/Viewer
**Compatibilidade Secundária:** Dashboard
**Incompatibilidades explícitas:** Feed/Timeline, Landing/Content
**Estrutura Desktop:** Secções com rótulo e valor lado a lado ou em coluna. Agrupamento lógico. Separadores entre grupos. Edição por secção opcional.
**Estrutura Mobile:** Rótulo e valor em coluna única. Espaçamento aumentado. Edição com botão explícito.
**Regra de Transição:** Duas colunas → coluna única. Agrupamento preservado.
**Estados próprios:** a carregar, com dados, sem dados, em edição, a guardar, erro
**Reação a estados da página:** Loading State → skeleton dos atributos. Error State → mensagem com retry. Not Found State → mensagem de entidade não encontrada.
**Grau de Rigidez:** Médio

### Metric Card

**ID_UI_PATTERN:** UIP-CONTENT-METRIC_CARD
**Categoria:** Conteúdo
**Definição curta:** Card de síntese para exibir um indicador ou KPI de leitura imediata.
**Objetivo estrutural:** Apresentar um indicador, KPI ou métrica de forma destacada e de leitura rápida.
**Não confundir com:** Detail Block de atributos, Rich Text Block editorial, card genérico de catálogo
**Nível composicional possível:** Leaf
**Quando usar:** quando a informação principal pode ser resumida em um indicador; quando a tela precisa de leitura rápida de status ou performance; quando o valor e sua variação importam mais que a narrativa detalhada
**Quando evitar:** quando a zona precisa mostrar múltiplos atributos estruturados; quando o conteúdo depende de explicação longa ou editorial; quando a métrica não é prioritária o bastante para destaque
**Alternativas próximas:** UIP-CONTENT-DETAIL_BLOCK, chart summary, card informativo genérico
**Sinais de escolha:** existe um valor principal dominante; comparação rápida importa; variação, período ou tendência agregam contexto; a leitura deve ser quase imediata
**Zonas usuais:** KPI-Row, Dashboard Header, Summary Strip
**Compatibilidade Primária:** Dashboard
**Compatibilidade Secundária:** Detail/Viewer
**Incompatibilidades explícitas:** Form, Wizard/Stepper, Conversation
**Estrutura Desktop:** Card com valor principal grande, rótulo, variação (positiva/negativa), período de referência, sparkline opcional.
**Estrutura Mobile:** Card compacto com valor e rótulo. Variação preservada. Sparkline opcional omitida.
**Regra de Transição:** Card preservado com possível simplificação de elementos secundários.
**Estados próprios:** com dados, a carregar, sem dados, variação positiva, variação negativa, variação neutra, erro
**Reação a estados da página:** Loading State → skeleton do card. Error State → indicador de erro. Empty State → "--" ou sem dados.
**Grau de Rigidez:** Médio

### Rich Text Block

**ID_UI_PATTERN:** UIP-CONTENT-RICH_TEXT_BLOCK
**Categoria:** Conteúdo
**Definição curta:** Bloco de conteúdo livre e editorial, com formatação textual e elementos embutidos.
**Objetivo estrutural:** Apresentar conteúdo editorial ou documental de formato livre com suporte a formatação.
**Não confundir com:** Detail Block estruturado, Form Field Group de captura, Metric Card sintético
**Nível composicional possível:** Leaf
**Quando usar:** quando o conteúdo é narrativo, editorial, explicativo ou documental; quando headings, listas, links e imagens fazem parte natural da leitura; quando a estrutura principal é textual e não de pares atributo/valor
**Quando evitar:** quando a zona depende de leitura estruturada de campos; quando a tarefa principal é editar ou preencher dados; quando o valor central é um KPI ou síntese analítica
**Alternativas próximas:** UIP-CONTENT-DETAIL_BLOCK, UIP-CONTENT-METRIC_CARD, viewer documental específico
**Sinais de escolha:** a leitura é livre e contínua; headings e parágrafos são elementos naturais do conteúdo; o utilizador precisa consumir explicação, política, descrição ou documentação; a semântica editorial é mais importante que grade de dados
**Zonas usuais:** Content-Body, Article Body, Policy/Help Section
**Compatibilidade Primária:** Detail/Viewer, Landing/Content
**Compatibilidade Secundária:** Feed/Timeline, Settings
**Incompatibilidades explícitas:** Dashboard
**Estrutura Desktop:** Área com tipografia editorial. Headings, parágrafos, listas, imagens inline, links. Largura máxima de leitura confortável.
**Estrutura Mobile:** Largura total com padding lateral. Tipografia ajustada. Imagens responsivas.
**Regra de Transição:** Largura máxima → largura total com padding. Tipografia preservada em proporção.
**Estados próprios:** a carregar, com conteúdo, sem conteúdo, erro de carregamento
**Reação a estados da página:** Loading State → skeleton de parágrafos. Error State → mensagem com retry.
**Grau de Rigidez:** Baixo

### Media Viewer

**ID_UI_PATTERN:** UIP-CONTENT-MEDIA_VIEWER
**Categoria:** Conteúdo
**Definição curta:** Área de visualização de mídia ou ficheiro com controles adequados ao tipo de conteúdo exibido.
**Objetivo estrutural:** Apresentar e controlar conteúdo multimédia — imagem, vídeo, documento ou ficheiro.
**Não confundir com:** Rich Text Block editorial, Card Grid de coleção, componente puramente decorativo de mídia
**Nível composicional possível:** Leaf, Container (galeria com múltiplos viewers)
**Quando usar:** quando a mídia ou ficheiro é conteúdo principal da zona; quando o utilizador precisa visualizar, navegar ou controlar o conteúdo exibido; quando o tipo de mídia exige comportamento específico de visualização
**Quando evitar:** quando a mídia é apenas apoio visual secundário de um card ou texto; quando a zona precisa apenas de miniatura decorativa; quando o conteúdo é melhor representado como texto estruturado ou editorial
**Alternativas próximas:** UIP-CONTENT-RICH_TEXT_BLOCK, miniatura de Card Grid, viewer documental específico
**Sinais de escolha:** o conteúdo principal é imagem, vídeo, documento ou ficheiro; existem controles ou gestos relevantes de visualização; o utilizador pode precisar ampliar, reproduzir ou navegar entre mídias; a mídia ocupa papel funcional na tarefa
**Zonas usuais:** Detail-Panel, Content-Body, Gallery Area
**Compatibilidade Primária:** Detail/Viewer
**Compatibilidade Secundária:** Feed/Timeline, Catalog/Grid
**Incompatibilidades explícitas:** Dashboard, Form
**Estrutura Desktop:** Área de visualização com controles adequados ao tipo de mídia. Pode incluir navegação secundária, thumbnails ou ações auxiliares quando fizer sentido.
**Estrutura Mobile:** Visualização em largura total ou foco único. Gestos e controles simplificados podem assumir o papel principal conforme o tipo de mídia.
**Regra de Transição:** A experiência de visualização deve preservar acesso ao conteúdo e aos controles essenciais. Layout, gestos e posição de navegação auxiliar podem variar conforme mídia e plataforma.
**Estados próprios:** a carregar, disponível, pausado, erro de carregamento, formato não suportado, em fullscreen
**Reação a estados da página:** Loading State → skeleton ou placeholder. Error State → ficheiro indisponível.
**Grau de Rigidez:** Médio
**Variantes reconhecidas:** Image Viewer; Video Viewer; Document/File Viewer