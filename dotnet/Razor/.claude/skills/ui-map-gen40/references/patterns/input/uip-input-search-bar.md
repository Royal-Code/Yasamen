# UIP-INPUT-SEARCH_BAR - Search Bar

## Definição

**Categoria**: Entrada

**Definição curta**: Entrada textual de busca para localizar itens, entidades ou conteúdo numa coleção.

**Objetivo estrutural**: Capturar termos de busca textual e iniciar pesquisa em coleção.

**Não confundir com**: UIP-INPUT-FILTER_PANEL (filtros estruturados), UIP-INPUT-INPUT_FIELD (campo de formulário), UIP-ACTION-COMMAND_PALETTE (comandos globais).

**Nível composicional possível**: Leaf

## Decisão

**Quando usar**: quando a principal forma de localizar conteúdo é por termo textual; quando o usuário precisa refinar rapidamente grandes coleções; quando sugestões, histórico ou autocomplete agregam valor à descoberta.

**Quando evitar**: quando o refinamento depende de múltiplos atributos estruturados; quando a interação principal é captura de dado persistente; quando a busca não tem papel relevante na página.

**Alternativas próximas**: UIP-INPUT-FILTER_PANEL (filtros estruturados), UIP-ACTION-COMMAND_PALETTE (comandos e destinos globais).

**Sinais de escolha**:
- há volume de itens que justifica busca textual
- o usuário tende a conhecer nomes, termos ou códigos
- a busca pode disparar resultados ou sugestões
- a zona precisa suportar limpar e reexecutar busca

**Grau de Rigidez**: Médio — entrada textual de busca é invariante; sugestões, filtros e comportamento variam.

## Composição

**Zonas usuais**: Cabeçalho, Filtros.

**Variantes reconhecidas**: busca simples; busca com sugestões ou autocomplete; busca com histórico; busca com escopo; busca com filtros embutidos.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-CATALOG, PP-LIST-DETAIL.

**Compatibilidade Secundária**: PP-FEED, PP-DASHBOARD.

**Incompatibilidades explícitas**: PP-FORM, PP-WIZARD.

## Estrutura e Transição

**Estrutura Desktop**: campo de texto com ícone de busca, botão de limpar e sugestões em dropdown opcionais.

**Estrutura Mobile**: campo expandido para largura total. Sugestões em overlay em contextos complexos.

**Regra de Transição**: campo preservado. Sugestões → overlay. Botão de cancelar visível em Mobile.

## Estados

**Estados próprios**: vazio ou inativo, digitando, buscando, com resultados, sem resultados, com sugestões visíveis.

**Reação a estados da página**: `loading` da busca → indicador de progresso no campo.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir sugestões, debounce, limpar e estado de resultados.

**Adaptação Mobile nativo**: considerar teclado virtual, tela dedicada de busca, overlay de sugestões e botão cancelar.

**Adaptação Desktop nativo**: pode coexistir com command palette; distinguir busca de conteúdo de execução de comandos.
