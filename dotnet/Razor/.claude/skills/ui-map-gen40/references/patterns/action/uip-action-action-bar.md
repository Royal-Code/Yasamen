# UIP-ACTION-ACTION_BAR - Action Bar

## Definição

**Categoria**: Ação

**Definição curta**: Barra de ações visíveis para operações principais sobre a página, seleção ou entidade em foco.

**Objetivo estrutural**: Expor ações disponíveis sobre página, item selecionado, seleção múltipla ou entidade em foco.

**Não confundir com**: UIP-ACTION-CONTEXTUAL_MENU (ações por item), UIP-ACTION-FLOATING_ACTION (ação primária única), UIP-NAV-NAVIGATION_MENU (navegação).

**Nível composicional possível**: Container, Leaf

## Decisão

**Quando usar**: quando a página ou seleção exige ações principais visíveis; quando existe conjunto pequeno e recorrente de operações relevantes; quando as ações precisam ficar próximas da área de trabalho; quando permissões ou seleção alteram as ações disponíveis.

**Quando evitar**: quando as ações pertencem a um item específico e não ao contexto global; quando existe apenas uma ação primária dominante; quando a densidade de ações tornaria a barra ilegível; quando as operações são comandos de ferramenta especializada com tool palette própria.

**Alternativas próximas**: UIP-ACTION-CONTEXTUAL_MENU (menu local por item), UIP-ACTION-FLOATING_ACTION (ação primária destacada).

**Sinais de escolha**:
- ações são frequentes e devem ficar explícitas
- o contexto de página ou seleção altera a disponibilidade das ações
- existe ação primária e secundárias relacionadas
- o usuário não deve abrir menu para toda ação importante

**Grau de Rigidez**: Médio — barra de ações visíveis sobre o contexto ativo é invariante; posição, ações e overflow variam.

## Composição

**Zonas usuais**: Ações, Cabeçalho, Detalhe.

**Variantes reconhecidas**: barra de ações da página; barra contextual de seleção; barra de ações de detalhe; footer de ações persistente em fluxo mobile.

**UIPs frequentemente combinados**: UIP-DATA-DATA_TABLE, UIP-INTERACTION-SELECTION, UIP-FEEDBACK-CONFIRMATION_DIALOG, UIP-INPUT-SEARCH_BAR.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-LIST-DETAIL, PP-DETAIL, PP-FORM.

**Compatibilidade Secundária**: PP-DASHBOARD, PP-SETTINGS, PP-CATALOG, PP-BOARD.

**Incompatibilidades explícitas**: não substitui UIP-ACTION-CONTEXTUAL_MENU para ações por linha ou por item isolado.

## Estrutura e Transição

**Estrutura Desktop**: barra horizontal com ações primárias e secundárias. Ações destrutivas separadas ou em zona própria. Ações de seleção múltipla aparecem quando há itens selecionados.

**Estrutura Mobile**: ações primárias visíveis; secundárias em overflow ou menu contextual. A barra pode ficar fixa no fundo em detalhe, formulário ou seleção.

**Regra de Transição**: ações visíveis em desktop → primárias visíveis e secundárias em overflow no mobile. Nunca ocultar a ação primária sem alternativa acessível.

## Estados

**Estados próprios**: ações disponíveis, ações desativadas por ausência de seleção ou permissão, ação em progresso, ação concluída, ação com erro.

**Reação a estados da página**: `loading` → ações desativadas ou em progresso. `no-permission` → ações restritas ocultas ou desativadas. `error` → ações de recuperação podem permanecer disponíveis.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir ações visíveis, overflow, permissões, seleção múltipla e persistência por viewport.

**Adaptação Mobile nativo**: priorizar poucas ações visíveis, overflow touch-friendly e posição compatível com navegação raiz ou teclado.

**Adaptação Desktop nativo**: pode coexistir com menu global, toolbar e atalhos de teclado; ações refletem seleção e foco atuais.
