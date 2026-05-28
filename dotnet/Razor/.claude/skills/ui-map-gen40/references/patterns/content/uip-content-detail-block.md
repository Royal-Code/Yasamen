# UIP-CONTENT-DETAIL_BLOCK - Detail Block

## Definição

**Categoria**: Conteúdo

**Definição curta**: Bloco de leitura estruturada de atributos, propriedades e metadados de uma entidade ou contexto específico.

**Objetivo estrutural**: Apresentar atributos, metadados, estado e relações de uma entidade específica de forma estruturada.

**Não confundir com**: UIP-CONTENT-CONTENT_HEADER (identidade e contexto inicial), UIP-CONTENT-RICH_TEXT_BLOCK (conteúdo editorial), UIP-CONTENT-METRIC_CARD (indicador sintético), UIP-CONTENT-COMPARISON_BLOCK (leitura comparativa), UIP-INPUT-FORM_FIELD_GROUP (captura de dados).

**Nível composicional possível**: Container, Leaf

## Decisão

**Quando usar**: quando a prioridade é leitura estruturada de atributos e metadados; quando a entidade precisa ser apresentada em grupos lógicos de informação; quando a zona deve suportar leitura e eventual edição localizada por seção; quando status, proprietário, datas, tags ou identificadores precisam ficar consultáveis.

**Quando evitar**: quando o conteúdo é editorial, narrativo ou documental livre; quando a prioridade é destacar poucos indicadores sintéticos; quando a interação principal é captura de dados; quando a leitura depende de comparação entre várias entidades; quando a necessidade principal é cabeçalho de identidade.

**Alternativas próximas**: UIP-CONTENT-CONTENT_HEADER (cabeçalho de identidade), UIP-CONTENT-RICH_TEXT_BLOCK (conteúdo editorial), UIP-CONTENT-METRIC_CARD (indicador sintético), UIP-CONTENT-COMPARISON_BLOCK (leitura comparativa), UIP-INPUT-FORM_FIELD_GROUP (captura de dados), UIP-DATA-DATA_TABLE (coleção tabular).

**Sinais de escolha**:
- existem rótulos e valores estruturados
- os atributos podem ser agrupados por seções
- a leitura depende de pares nome/valor ou metadado/valor
- o usuário precisa consultar detalhes de uma entidade específica

**Grau de Rigidez**: Médio — leitura estruturada de atributos é estável; número de campos, layout e agrupamento variam.

## Composição

**Zonas usuais**: Detalhe, Conteúdo, Painel Auxiliar.

**Variantes reconhecidas**: bloco de atributos; status strip; metadata group; seção de detalhe com edição localizada; resumo estruturado de entidade.

**UIPs frequentemente combinados**: UIP-CONTENT-CONTENT_HEADER, UIP-NAV-TABS, UIP-ACTION-ACTION_BAR, UIP-CONTENT-MEDIA_COLLECTION, UIP-CONTENT-COMMENT_THREAD.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-LIST-DETAIL, PP-DETAIL.

**Compatibilidade Secundária**: PP-DASHBOARD, PP-SETTINGS, PP-FORM, PP-CANVAS.

**Incompatibilidades explícitas**: PP-FEED, PP-LANDING (estrutura principal narrativa ou promocional).

## Estrutura e Transição

**Estrutura Desktop**: seções com rótulo e valor lado a lado ou em coluna. Agrupamento lógico, separadores entre grupos. Status, identificador e ações de seção podem ficar no cabeçalho local.

**Estrutura Mobile**: rótulo e valor em coluna única. Agrupamento preservado. Edição por seção com ação explícita.

**Regra de Transição**: duas colunas → coluna única. Agrupamento, rótulos, status e relação entre atributo e valor são preservados.

## Estados

**Estados próprios**: carregando, com dados, sem dados, somente leitura, em edição, salvando, erro, entidade não encontrada.

**Reação a estados da página**: `loading` → skeleton dos atributos. `error` → mensagem com retry, ou de entidade não encontrada, no escopo do bloco. `empty` → ausência explícita de dados.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir colunas, seção colapsável, edição inline e estado de entidade conforme a densidade.

**Adaptação Mobile nativo**: priorizar seções empilhadas, ações explícitas de edição e navegação por stack quando o detalhe for profundo.

**Adaptação Desktop nativo**: pode compor inspectors, side panels e janelas auxiliares; preservar o foco da entidade ativa.
