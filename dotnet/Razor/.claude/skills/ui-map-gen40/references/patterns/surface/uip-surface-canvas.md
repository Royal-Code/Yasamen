# UIP-SURFACE-CANVAS - Canvas Surface

## Definição

**Categoria**: Superfície Especializada

**Definição curta**: Superfície editável para objetos, layers, pan/zoom, seleção, handles e manipulação direta.

**Objetivo estrutural**: Sustentar criação, composição, diagramação, desenho ou edição técnica por manipulação direta de objetos em uma área de trabalho.

**Não confundir com**: PP-CANVAS (página completa de canvas), UIP-CONTENT-MEDIA_VIEWER (visualização de mídia), UIP-STRUCT-GRID_CONTAINER (grade de layout), área decorativa (fora do catálogo).

**Nível composicional possível**: Container

## Decisão

**Quando usar**: quando o artefato principal é manipulado diretamente em uma superfície; quando objetos, layers, conectores, guias, zoom, pan, seleção ou handles são parte essencial da tarefa; quando a criação ou edição depende de posição espacial relativa.

**Quando evitar**: quando a tarefa é formulário, leitura ou listagem; quando objetos não precisam de manipulação direta; quando uma prévia estática resolve; quando a plataforma só comporta revisão simples e não edição.

**Alternativas próximas**: PP-CANVAS (página de canvas), UIP-CONTENT-MEDIA_VIEWER (visualização de mídia), UIP-DATA-KANBAN_COLUMN (organização visual por colunas).

**Sinais de escolha**:
- objetos editáveis e seleção múltipla
- layers ou hierarquia visual
- pan e zoom
- ferramentas persistentes e inspector de propriedades
- undo/redo e histórico são esperados

**Grau de Rigidez**: Alto — superfície editável com pan/zoom e objetos é invariante; ferramentas, layers e handles variam.

## Composição

**Zonas usuais**: Superfície.

**Variantes reconhecidas**: canvas de desenho; editor de diagrama; editor de layout; flow builder; whiteboard; canvas com nodes; superfície de anotação.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-CANVAS.

**Compatibilidade Secundária**: PP-DETAIL, PP-FORM, PP-BOARD.

**Incompatibilidades explícitas**: PP-LANDING, PP-CONVERSATION, PP-FEED quando a experiência dominante não é criação ou manipulação.

## Estrutura e Transição

**Estrutura Desktop**: superfície dominante com pan/zoom, seleção, handles, objetos, guias, layers, ferramentas e painéis auxiliares simultâneos.

**Estrutura Mobile**: revisão, anotação ou edição reduzida. Ferramentas e painéis tendem a alternar por overlays ou modos.

**Regra de Transição**: preservar a primazia da superfície, o estado do artefato e as ações essenciais. A edição completa pode ser limitada quando a plataforma não comporta precisão, atalhos ou painéis simultâneos.

## Estados

**Estados próprios**: vazio, carregando, pronto, pan ativo, zoom ativo, objeto selecionado, seleção múltipla, editando objeto, arrastando, redimensionando, conectando, salvando, alterações não salvas, conflito, erro.

**Reação a estados da página**: `loading` → placeholder da superfície. `empty` → canvas inicial com ação de criação. `error` → falha de carregamento ou salvamento do artefato.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir pan/zoom, seleção, drag/drop, atalhos, undo/redo, persistência de painéis e fallback touch.

**Adaptação Mobile nativo**: limitar o escopo de edição ou transformar em revisão ou anotação; não assumir painéis simultâneos nem precisão de pointer.

**Adaptação Desktop nativo**: pode ativar multi-window, floating panel, keyboard flow, command palette, cross-window drag/drop e integração com arquivos.
