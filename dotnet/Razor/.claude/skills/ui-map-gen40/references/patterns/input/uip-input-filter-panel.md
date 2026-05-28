# UIP-INPUT-FILTER_PANEL - Filter Panel

## Definição

**Categoria**: Entrada

**Definição curta**: Área de filtros estruturados para refinar coleções por atributos, estados ou facetas.

**Objetivo estrutural**: Filtrar coleções por múltiplos atributos estruturados com aplicação explícita ou reativa.

**Não confundir com**: UIP-INPUT-SEARCH_BAR (busca textual), UIP-INPUT-FORM_FIELD_GROUP (captura de dados), menu de ordenação (fora do catálogo).

**Nível composicional possível**: Container

## Decisão

**Quando usar**: quando a coleção precisa ser refinada por múltiplos atributos; quando facetas, intervalos, estados e filtros compostos fazem parte da navegação; quando os filtros precisam permanecer visíveis ou acessíveis como bloco coerente.

**Quando evitar**: quando um único termo textual resolve a busca; quando a tela é formulário de captura e não refinamento de resultados; quando os filtros são tão simples que cabem em controle único isolado.

**Alternativas próximas**: UIP-INPUT-SEARCH_BAR (busca textual), UIP-INPUT-FORM_FIELD_GROUP (captura de dados).

**Sinais de escolha**:
- existem vários atributos filtráveis
- filtros ativos precisam ser visíveis e reversíveis
- o usuário combina critérios
- o refinamento altera uma coleção já exibida
- a intenção é filtrar resultados, não persistir dados

**Grau de Rigidez**: Médio — facetas e filtros estruturados são estáveis; quantidade, tipo de controle e posição variam por coleção.

## Composição

**Zonas usuais**: Filtros.

**Variantes reconhecidas**: filtros em painel lateral; filtros em barra superior; filtros em drawer ou sheet; filtros por facetas; filtros com aplicação reativa.

**UI Patterns tipicamente contidos**: UIP-INPUT-CHOICE_GROUP, UIP-INPUT-OPTION_PICKER, UIP-INPUT-DATE_PICKER, UIP-INPUT-INPUT_FIELD.

**UIPs frequentemente combinados**: UIP-DATA-DATA_TABLE, UIP-DATA-CARD_GRID, UIP-DATA-LIST_ITEM, UIP-INPUT-SEARCH_BAR, UIP-ACTION-ACTION_BAR.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-LIST-DETAIL, PP-CATALOG.

**Compatibilidade Secundária**: PP-DASHBOARD.

**Incompatibilidades explícitas**: PP-FORM, PP-WIZARD, PP-CONVERSATION.

## Estrutura e Transição

**Estrutura Desktop**: painel lateral ou área superior com filtros por atributo. Aplicação por botão ou reativa. Indicador de filtros ativos. Opção de limpar todos.

**Estrutura Mobile**: filtros em drawer ou modal. Botão de filtro na página com indicador de ativos.

**Regra de Transição**: painel visível → drawer ou modal. Indicador de filtros ativos sempre visível.

## Estados

**Estados próprios**: sem filtros ativos, com filtros ativos, aplicando filtros, resultados filtrados.

**Reação a estados da página**: `loading` → filtros desativados durante o carregamento.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir painel lateral, barra superior, drawer ou modal por viewport.

**Adaptação Mobile nativo**: usar sheet, drawer ou tela dedicada; filtros ativos continuam visíveis no ponto de retorno.

**Adaptação Desktop nativo**: pode coexistir com data table, saved filters e keyboard flow.
