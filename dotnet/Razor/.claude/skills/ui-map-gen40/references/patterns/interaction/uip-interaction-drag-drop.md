# UIP-INTERACTION-DRAG_DROP - Drag and Drop

## Definição

**Categoria**: Interação & Manipulação

**Definição curta**: Manipulação direta por arraste e soltura dentro da mesma tela, lista, superfície ou contexto.

**Objetivo estrutural**: Permitir mover, associar, reordenar, agrupar ou aplicar itens por gesto direto dentro de um escopo controlado.

**Não confundir com**: UIP-INTERACTION-CROSS_WINDOW_DND (arraste entre janelas), UIP-INTERACTION-SWIPE_ACTION (ações por gesto horizontal), UIP-INTERACTION-PAN_ZOOM (navegação espacial), upload simples por drop (fora do catálogo).

**Nível composicional possível**: Leaf, Container

## Decisão

**Quando usar**: quando manipulação espacial ou reordenação é mais direta que formulário; quando o usuário precisa mover itens entre zonas; quando associação por destino de soltar é clara; quando a posição ou grupo resultante tem significado.

**Quando evitar**: quando a operação precisa ser precisa demais para a plataforma; quando não há fallback acessível; quando o gesto conflita com scroll, seleção ou swipe; quando botões ou menus seriam mais previsíveis.

**Alternativas próximas**: UIP-INTERACTION-CROSS_WINDOW_DND (arraste entre janelas), UIP-INTERACTION-SELECTION (selecionar e aplicar ação), UIP-ACTION-CONTEXTUAL_MENU (mover por menu).

**Sinais de escolha**:
- reorder, mover entre colunas, arrastar cards
- associar arquivo ou objeto a uma zona
- canvas com objetos
- feedback de destino válido ou inválido
- undo esperado

**Grau de Rigidez**: Médio — manipulação por arraste dentro da mesma tela é estável; ghost, drop zones e feedback variam.

## Composição

**Zonas usuais**: Coleção, Superfície.

**Variantes reconhecidas**: reorder; mover entre listas; arraste para associar; arraste em canvas; arraste de arquivo para upload; resize por handle; drop com validação.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-BOARD, PP-CANVAS.

**Compatibilidade Secundária**: PP-LIST-DETAIL, PP-CATALOG, PP-CALENDAR, PP-MAP, PP-FORM.

**Incompatibilidades explícitas**: PP-LANDING, PP-CONVERSATION e fluxos em que drag/drop não seja descobrível ou acessível.

## Estrutura e Transição

**Estrutura Desktop**: drag source, preview, destino de soltars, indicação de operação, cancelamento e resultado com feedback.

**Estrutura Mobile**: long press ou handle explícito para iniciar o arraste quando houver conflito com scroll. Destinos de soltar grandes e claros.

**Regra de Transição**: preservar a operação e o fallback. Em touch, iniciar o arraste deve evitar conflito com scroll, swipe action e navegação.

## Estados

**Estados próprios**: idle, arraste iniciado, arrastando, sobre destino válido, sobre destino inválido, solto, processando, reordenado, cancelado, undo disponível, falhou.

**Reação a estados da página**: `loading` → arraste desativado quando os destinos não estão prontos. `no-permission` → destinos ou itens restritos desativados. `error` → feedback local com rollback ou undo.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: validar pointer, teclado, foco, fallback por botões e regras de destino de soltar.

**Adaptação Mobile nativo**: usar handle ou long press quando necessário e evitar conflito com scroll e swipe.

**Adaptação Desktop nativo**: suportar modifiers, cursor e preview, cancelamento por escape e integração com seleção.
