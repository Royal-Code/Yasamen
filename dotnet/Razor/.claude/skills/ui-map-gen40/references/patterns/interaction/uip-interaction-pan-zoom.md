# UIP-INTERACTION-PAN_ZOOM - Pan Zoom

## Definição

**Categoria**: Interação & Manipulação

**Definição curta**: Navegação espacial por arrasto, zoom e foco em superfície grande ou conteúdo ampliável.

**Objetivo estrutural**: Permitir explorar, enquadrar e manipular superfícies ou conteúdos maiores que a viewport disponível.

**Não confundir com**: UIP-INTERACTION-DRAG_DROP (manipulação de objetos), UIP-STRUCT-SCROLLABLE_REGION (scroll simples), UIP-NAV-PAGINATION (navegação por páginas), zoom de browser (fora do catálogo).

**Nível composicional possível**: Container, Leaf

## Decisão

**Quando usar**: quando a superfície tem escala espacial maior que a tela; quando mapa, canvas, documento, imagem, gráfico ou diagrama exige aproximação e deslocamento; quando foco em região específica faz parte da tarefa.

**Quando evitar**: quando scroll simples resolve; quando o conteúdo é linear; quando o zoom causaria perda de orientação; quando a plataforma não suporta gestos, pointer ou controles equivalentes.

**Alternativas próximas**: UIP-STRUCT-SCROLLABLE_REGION (scroll simples), UIP-NAV-PAGINATION (navegação por páginas).

**Sinais de escolha**:
- viewport sobre superfície ampla
- pinch, scroll wheel ou controles de zoom
- reset ou fit
- mini-map
- foco em seleção
- a escala afeta leitura ou edição

**Grau de Rigidez**: Médio — navegação espacial com arrasto e zoom é invariante; limites, controles e minimap variam.

## Composição

**Zonas usuais**: Superfície.

**Variantes reconhecidas**: pinch zoom; wheel zoom; pan por arraste; fit to screen; zoom to selection; mini-map; reset view; restrição de escala.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-CANVAS, PP-MAP.

**Compatibilidade Secundária**: PP-DETAIL, PP-DASHBOARD, PP-CALENDAR, PP-LIST-DETAIL.

**Incompatibilidades explícitas**: PP-FORM, PP-LANDING e conteúdo linear sem superfície espacial.

## Estrutura e Transição

**Estrutura Desktop**: pan por arraste ou modifier, zoom por wheel, trackpad ou controles, reset view, fit-to-screen e indicação de escala quando relevante.

**Estrutura Mobile**: pinch, arraste, double tap ou controles explícitos conforme plataforma. Gestos devem evitar conflito com o scroll da página.

**Regra de Transição**: preservar orientação, limites de escala e caminho para voltar ao enquadramento útil. Gestos podem virar controles explícitos quando a plataforma exigir.

## Estados

**Estados próprios**: fit, zoom in, zoom out, pan ativo, viewport deslocado, zoom to selection, escala mínima, escala máxima, reset view.

**Reação a estados da página**: `loading` → controles desativados ou superfície em placeholder. `error` → superfície indisponível. `empty` → viewport inicial sem objetos ou dados.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: tratar wheel, trackpad, touch, atalhos de teclado, foco e conflito com o scroll da página.

**Adaptação Mobile nativo**: usar gestos nativos e controles visíveis quando descoberta ou precisão forem críticas.

**Adaptação Desktop nativo**: integrar wheel, trackpad, modifiers, atalhos, mini-map e persistência de viewport quando aplicável.
