# UIP-INTERACTION-SELECTION - Selection

## Definição

**Categoria**: Interação & Manipulação

**Definição curta**: Seleção simples, múltipla ou por intervalo em coleções, listas, tabelas ou superfícies manipuláveis.

**Objetivo estrutural**: Declarar quais itens, objetos ou regiões estão em foco operacional para ação, edição, comparação ou manipulação.

**Não confundir com**: navegação ativa, foco de teclado, hover, filtro aplicado, estado de edição — conceitos de estado, fora do catálogo; nenhum substitui seleção.

**Nível composicional possível**: Leaf, Container

## Decisão

**Quando usar**: quando o usuário precisa agir sobre um ou mais itens; quando a seleção altera action bar, detalhe, inspector ou propriedades; quando múltiplos objetos podem ser manipulados em lote; quando intervalo, região ou grupo são parte da tarefa.

**Quando evitar**: quando cada item tem ação imediata e isolada; quando a seleção não muda nada no fluxo; quando a interface só precisa indicar o item atual de navegação; quando seleção múltipla adicionaria complexidade sem ganho.

**Alternativas próximas**: UIP-ACTION-CONTEXTUAL_MENU (ações sobre o item), UIP-ACTION-ACTION_BAR (ações sobre a seleção).

**Sinais de escolha**:
- checkbox ou seleção por clique ou tap
- action bar muda com a seleção
- contagem de selecionados
- shift ou range selection
- seleção em canvas
- seleção persistente entre páginas ou filtros

**Grau de Rigidez**: Médio — declaração de itens em foco operacional é estável; modo de seleção, persistência e range variam.

## Composição

**Zonas usuais**: Coleção, Superfície.

**Variantes reconhecidas**: seleção simples; seleção múltipla; seleção por intervalo; seleção por região; seleção persistente; seleção temporária; seleção por grupo.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-LIST-DETAIL, PP-CATALOG, PP-BOARD, PP-CANVAS.

**Compatibilidade Secundária**: PP-DASHBOARD, PP-MAP, PP-CALENDAR, PP-DETAIL.

**Incompatibilidades explícitas**: PP-LANDING e conteúdo puramente narrativo sem ação sobre itens.

## Estrutura e Transição

**Estrutura Desktop**: seleção por clique, teclado, checkbox, range ou região. Seleção múltipla pode ativar action bar, inspector ou ações em lote.

**Estrutura Mobile**: seleção por modo explícito, long press, checkbox, menu contextual ou ação de seleção. Ações em lote permanecem claras.

**Regra de Transição**: preservar a diferença entre foco, item ativo e item selecionado. Em mobile, a entrada em modo de seleção deve ser explícita quando seleção múltipla for possível.

## Estados

**Estados próprios**: nenhum selecionado, item selecionado, múltiplos selecionados, intervalo selecionado, seleção parcial, seleção bloqueada, seleção persistida, seleção inválida.

**Reação a estados da página**: `loading` → seleção preservada ou suspensa conforme a identidade dos itens. `empty` → seleção limpa. `no-permission` → seleção ou ações associadas desativadas.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir checkbox, range selection, seleção persistente, foco e action bar contextual.

**Adaptação Mobile nativo**: usar modo de seleção explícito para seleção múltipla e evitar conflito com navegação por tap.

**Adaptação Desktop nativo**: suportar teclado, range, multi-select, context menu e integração com drag/drop quando aplicável.
