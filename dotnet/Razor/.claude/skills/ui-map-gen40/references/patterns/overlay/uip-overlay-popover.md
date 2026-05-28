# UIP-OVERLAY-POPOVER - Popover

## Definição

**Categoria**: Overlay & Superfície Temporária

**Definição curta**: Superfície contextual leve ancorada a um elemento de origem para opções, detalhe curto ou controles auxiliares.

**Objetivo estrutural**: Mostrar conteúdo ou controles próximos ao contexto que os originou sem alterar a estrutura da página nem bloquear toda a experiência.

**Não confundir com**: UIP-ACTION-CONTEXTUAL_MENU (menu de comandos), UIP-OVERLAY-TOOLTIP (ajuda curta), UIP-OVERLAY-MODAL (superfície bloqueante), UIP-OVERLAY-BOTTOM_SHEET (superfície deslizante).

**Nível composicional possível**: Container, Leaf

## Decisão

**Quando usar**: quando o conteúdo é contextual, curto e depende de um elemento originador; quando controles auxiliares precisam ficar próximos do ponto de interação; quando bloquear a página inteira seria excessivo.

**Quando evitar**: quando a tarefa é longa; quando o conteúdo precisa persistir como painel; quando há risco de colisão com viewport pequeno; quando o conteúdo é apenas texto de ajuda curto.

**Alternativas próximas**: UIP-ACTION-CONTEXTUAL_MENU (menu de comandos), UIP-OVERLAY-TOOLTIP (ajuda curta), UIP-OVERLAY-MODAL (superfície bloqueante), UIP-OVERLAY-BOTTOM_SHEET (superfície deslizante).

**Sinais de escolha**:
- origem clara
- conteúdo leve, ação ou leitura curta
- posicionamento contextual importa
- fechamento por outside click, escape ou seleção é aceitável

**Grau de Rigidez**: Médio — superfície contextual ancorada a elemento é invariante; posição, conteúdo e trigger variam.

## Composição

**Zonas usuais**: Overlay.

**Variantes reconhecidas**: popover informativo; popover de controle; mini picker; quick preview; rich tooltip interativo.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-FORM, PP-DETAIL, PP-LIST-DETAIL, PP-CATALOG, PP-DASHBOARD.

**Compatibilidade Secundária**: PP-CANVAS, PP-MAP, PP-CALENDAR, PP-SETTINGS.

**Incompatibilidades explícitas**: não usar como substituto de modal, drawer ou tela quando o conteúdo exige navegação, validação longa ou estado persistente.

## Estrutura e Transição

**Estrutura Desktop**: superfície ancorada ao elemento originador, com conteúdo curto, foco controlado quando interativo e posicionamento ajustável ao viewport.

**Estrutura Mobile**: pode virar bottom sheet, modal compacto ou tela de seleção quando não houver espaço ou precisão para ancoragem.

**Regra de Transição**: preservar a relação com o originador e o conteúdo contextual. A ancoragem pode ser substituída por sheet ou modal em touch pequeno.

## Estados

**Estados próprios**: fechado, aberto, reposicionado, com foco interno, carregando, erro interno, fechado por seleção, fechado por dismiss.

**Reação a estados da página**: `loading` → conteúdo interno em loading quando a busca é contextual. Modal ativo pode bloquear popovers fora do modal.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: tratar posicionamento, colisão de viewport, foco, aria semantics e fechamento por teclado.

**Adaptação Mobile nativo**: transformar em sheet, picker ou tela auxiliar quando ancoragem e toque não forem confiáveis.

**Adaptação Desktop nativo**: pode usar popover nativo, flyout ou callout conforme o framework.
