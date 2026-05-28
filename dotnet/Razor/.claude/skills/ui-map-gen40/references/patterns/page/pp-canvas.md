# PP-CANVAS - Canvas

## Definição

**Definição curta**: Página centrada em superfície de criação, composição, desenho ou edição técnica.

**Objetivo estrutural**: Sustentar manipulação direta de artefatos com ferramentas, inspector e contexto especializado.

**Interação dominante**: Composicional

**Não confundir com**: PP-DETAIL (visualização de entidade), PP-FORM (captura de dados), PP-BOARD (organização por colunas).

## Decisão

**Sinais de escolha**:
- superfície editável central
- manipulação direta
- painéis de propriedades
- toolbar persistente
- objetos, layers ou assets como matéria de trabalho

**Limites**: exige superfície especializada de edição como núcleo da página.

**Grau de Rigidez**: Alto — superfície de edição com pan/zoom e ferramentas são invariantes; tipo de objetos e painéis variam por ferramenta.

## Composição

**Zonas funcionais obrigatórias**: Superfície; Painel Auxiliar; Ações.

**UI Patterns tipicamente obrigatórios**: UIP-SURFACE-CANVAS, UIP-STRUCT-LAYOUT_ZONE, UIP-NAV-TABS, UIP-ACTION-ACTION_BAR, UIP-ACTION-CONTEXTUAL_MENU, UIP-FEEDBACK-CONFIRMATION_DIALOG, UIP-FEEDBACK-EMPTY_STATE.

## Compatibilidade com Shell Patterns

**Compatibilidade Primária**: SHP-STUDIO_WORKBENCH.

**Compatibilidade Secundária**: Nenhuma.

**Incompatibilidades explícitas**: SHP-PORTAL, SHP-COMMUNICATION, SHP-KIOSK_EMBEDDED como experiência dominante.

## Estrutura e Transição

**Estrutura Desktop**: superfície dominante com painéis laterais simultâneos e ferramentas persistentes.

**Estrutura Mobile**: revisão, anotação ou ajustes pontuais; a edição completa pode ser restringida.

**Regra de transição**: preservar a primazia da superfície principal, mesmo quando a edição integral não couber em Mobile.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir pan/zoom, seleção, atalhos, drag/drop, persistência de painéis e fallback touch.

**Adaptação Mobile nativo**: limitar o escopo de edição ou transformar em revisão ou anotação; não assumir painéis simultâneos.

**Adaptação Desktop nativo**: pode ativar multi-window, floating panel, keyboard flow, command palette e cross-window drag/drop.
