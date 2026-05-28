# UIP-DATA-KANBAN_COLUMN - Kanban Column

## Definição

**Categoria**: Dados & Listagem

**Definição curta**: Coluna de board que agrupa itens por estado, etapa ou categoria operacional.

**Objetivo estrutural**: Agrupar e apresentar itens por categoria ou estado em formato de coluna arrastável.

**Não confundir com**: UIP-DATA-DATA_TABLE (tabela por status), UIP-STRUCT-GRID_CONTAINER (grade estrutural), UIP-STRUCT-SPLIT_PANEL (duas áreas simultâneas).

**Nível composicional possível**: Container

## Decisão

**Quando usar**: quando o fluxo é melhor entendido por estados ou colunas; quando mover itens entre categorias faz parte da tarefa; quando a visão de board agrega mais valor que lista linear.

**Quando evitar**: quando comparação tabular é mais importante; quando a coleção não tem estados ou agrupamentos claros; quando o mobile não sustenta a interação de board sem perda excessiva.

**Alternativas próximas**: UIP-DATA-DATA_TABLE (tabela operacional), UIP-STRUCT-GRID_CONTAINER (grade estrutural).

**Sinais de escolha**:
- os itens pertencem a colunas semânticas
- mudança de estado é recorrente
- a visão horizontal por coluna ajuda a operação
- drag-and-drop ou equivalente faz sentido
- itens possuem estado ou etapa com transição operacional
- visualização de fluxo entre estados é mais útil que comparação tabular

**Grau de Rigidez**: Médio — colunas com itens transitáveis são invariantes; número de colunas, tipo de card e drag variam.

## Composição

**Zonas usuais**: Coleção.

**Variantes reconhecidas**: coluna simples; coluna com limite WIP; coluna colapsável; coluna com agrupamento interno; coluna como destino de drag.

**UI Patterns tipicamente contidos**: UIP-INTERACTION-DRAG_DROP, UIP-INTERACTION-SELECTION, UIP-ACTION-CONTEXTUAL_MENU, UIP-FEEDBACK-EMPTY_STATE.

**UIPs frequentemente combinados**: UIP-ACTION-FLOATING_ACTION, UIP-OVERLAY-MODAL.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-BOARD.

**Compatibilidade Secundária**: PP-LIST-DETAIL.

**Incompatibilidades explícitas**: PP-DASHBOARD, PP-FEED, PP-CATALOG.

## Estrutura e Transição

**Estrutura Desktop**: colunas horizontais com scroll vertical interno. Cabeçalho com nome e contagem. Itens arrastáveis entre colunas.

**Estrutura Mobile**: uma coluna visível de cada vez, com navegação horizontal. Drag-and-drop substituído por ação de menu.

**Regra de Transição**: múltiplas colunas simultâneas → coluna única com navegação. Arrastar → ação de menu.

## Estados

**Estados próprios**: normal, em destaque como destino de item, vazia, com limite atingido.

**Reação a estados da página**: `loading` → skeleton das colunas. `empty` → coluna vazia com CTA de criação. `error` → erro no escopo do board.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir scroll horizontal, drag/drop, filtros e ação alternativa.

**Adaptação Mobile nativo**: exibir uma coluna por vez e mover itens por menu ou ação explícita.

**Adaptação Desktop nativo**: pode ativar keyboard flow, drag/drop e múltiplas janelas quando itens transitarem entre contextos.
