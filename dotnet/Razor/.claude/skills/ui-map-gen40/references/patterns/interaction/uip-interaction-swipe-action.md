# UIP-INTERACTION-SWIPE_ACTION - Swipe Action

## Definição

**Categoria**: Interação & Manipulação

**Definição curta**: Ações reveladas por gesto horizontal sobre itens de lista, com fallback acessível e distinção por tipo de ação.

**Objetivo estrutural**: Expor ações rápidas por item sem ocupar espaço permanente na interface.

**Não confundir com**: UIP-ACTION-CONTEXTUAL_MENU (menu por long press ou overflow), UIP-INTERACTION-DRAG_DROP (reordenação), gesto de navegação de retorno (fora do catálogo).

**Nível composicional possível**: Leaf

## Decisão

**Quando usar**: quando itens de lista têm poucas ações frequentes; quando a densidade de itens exige economia de espaço; quando a ação precisa ser rápida e repetível; quando a plataforma torna o gesto esperado.

**Quando evitar**: quando a ação é rara ou destrutiva sem undo; quando existem muitas ações por item; quando o item já exige rolagem horizontal; quando o gesto seria o único caminho para executar a ação.

**Alternativas próximas**: UIP-ACTION-CONTEXTUAL_MENU (menu de ações por item), UIP-ACTION-ACTION_BAR (ações contextuais), UIP-INTERACTION-SELECTION (seleção com ação em lote).

**Sinais de escolha**:
- 1-3 ações de alta frequência por item
- lista longa e repetitiva
- ações reversíveis ou de baixo risco
- fallback por menu, botão ou long press disponível

**Grau de Rigidez**: Médio — gesto horizontal revelando ações é invariante; ações, cores e fallback variam.

## Composição

**Zonas usuais**: Coleção.

**Variantes reconhecidas**: swipe leading ou trailing; swipe parcial com ações reveladas; full swipe opcional; swipe com undo; swipe com confirmação posterior.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-FEED, PP-LIST-DETAIL, PP-CONVERSATION.

**Compatibilidade Secundária**: PP-CATALOG, PP-BOARD, PP-CALENDAR.

**Incompatibilidades explícitas**: não usar como único mecanismo para ação crítica, destrutiva ou sem alternativa acessível.

## Estrutura e Transição

**Estrutura Desktop**: inadequado como interação primária; usar menu contextual ou botões inline.

**Estrutura Mobile**: ações leading ou trailing reveladas por swipe; full swipe opcional para ação primária reversível ou segura.

**Regra de Transição**: full swipe nunca é o único método. Sempre prever fallback acessível por menu, botão ou teclado.

## Estados

**Estados próprios**: neutro, swiping parcial, ações reveladas, full swipe confirmado, executando, undo disponível, ação indisponível.

**Reação a estados da página**: `no-permission` → swipe desativado ou ação indisponível. `loading` → ações temporariamente bloqueadas. `error` após a ação → feedback com retry ou undo quando possível.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo.

**Plataformas primárias**: Mobile nativo.


## Adaptação por Plataforma

**Adaptação Web**: validar touch, pointer, teclado e fallback por menu contextual ou action bar; em desktop, o swipe não é a interação primária.

**Adaptação Mobile nativo**: usar APIs ou padrões nativos de swipe, preservar undo e fallback e evitar conflito com a navegação por gesto.

**Adaptação Desktop nativo**: substituir por menu contextual, botões inline ou seleção em lote.
