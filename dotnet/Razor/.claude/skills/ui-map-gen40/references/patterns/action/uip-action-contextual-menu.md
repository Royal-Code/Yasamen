# UIP-ACTION-CONTEXTUAL_MENU - Contextual Menu

## Definição

**Categoria**: Ação

**Definição curta**: Menu de ações locais associado a um item ou contexto específico, ativado sob demanda.

**Objetivo estrutural**: Expor ações disponíveis sobre um item, seleção ou contexto local sem ocupar espaço permanente.

**Não confundir com**: UIP-ACTION-ACTION_BAR (ações globais visíveis), UIP-NAV-NAVIGATION_MENU (navegação), UIP-FEEDBACK-CONFIRMATION_DIALOG (confirmação de ação).

**Nível composicional possível**: Leaf

## Decisão

**Quando usar**: quando as ações pertencem a um item específico; quando a interface precisa economizar espaço permanente; quando ações secundárias ou avançadas não precisam ficar sempre visíveis; quando a lista de ações muda conforme o item.

**Quando evitar**: quando as ações são globais da página ou da seleção; quando a ação principal precisa ser imediatamente visível; quando uma ação arriscada precisa de confirmação antes da execução; quando a plataforma não oferece forma clara de descobrir o menu.

**Alternativas próximas**: UIP-ACTION-ACTION_BAR (ações globais visíveis), UIP-FEEDBACK-CONFIRMATION_DIALOG (confirmação de ação), UIP-INTERACTION-SWIPE_ACTION (ações por gesto).

**Sinais de escolha**:
- há ações locais por item
- o espaço visual é restrito
- parte das ações pode ficar oculta até demanda
- a lista de ações precisa ser contextual
- ações destrutivas precisam ficar separadas das ações comuns

**Grau de Rigidez**: Médio — menu de ações locais sob demanda é invariante; trigger, posição e ações variam por item.

## Composição

**Zonas usuais**: Ações, Coleção, Superfície.

**Variantes reconhecidas**: menu de overflow por item; menu de clique secundário; menu contextual de seleção; menu adaptado como sheet em touch.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-LIST-DETAIL, PP-CATALOG.

**Compatibilidade Secundária**: PP-FEED, PP-BOARD, PP-DETAIL, PP-CANVAS.

**Incompatibilidades explícitas**: não substitui UIP-ACTION-ACTION_BAR para ações globais de página ou seleção múltipla recorrente.

## Estrutura e Transição

**Estrutura Desktop**: dropdown por ícone de overflow, menu por clique secundário ou menu ancorado ao item. Lista com agrupamentos ou separadores quando necessário. Ações destrutivas no final ou em grupo próprio.

**Estrutura Mobile**: variante touch-friendly — sheet, popover adaptado ou menu nativo. O cancelamento depende do padrão da plataforma e do risco das ações.

**Regra de Transição**: menu compacto de desktop → variante touch-friendly equivalente. Ações, agrupamentos, disponibilidade e distinção de destrutividade são preservados.

## Estados

**Estados próprios**: fechado, aberto, item disponível, item desativado, item destrutivo, executando ação.

**Reação a estados da página**: `loading` → menu indisponível ou itens context-sensitive desativados. `no-permission` → ações restritas ocultas ou desativadas.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: prever abertura por botão, teclado e clique secundário, com foco retornando ao originador.

**Adaptação Mobile nativo**: preferir menu nativo, action sheet ou bottom sheet conforme quantidade e risco; oferecer fallback visível quando depender de gesto.

**Adaptação Desktop nativo**: integrar com o menu de contexto do sistema quando fizer sentido e preservar atalhos visíveis para comandos frequentes.
