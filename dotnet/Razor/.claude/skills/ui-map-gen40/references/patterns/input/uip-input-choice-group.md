# UIP-INPUT-CHOICE_GROUP - Choice Group

## Definição

**Categoria**: Entrada

**Definição curta**: Grupo de escolhas visíveis para seleção única, múltipla ou binária entre opções pequenas e conhecidas.

**Objetivo estrutural**: Permitir escolha explícita entre alternativas de baixa cardinalidade sem depender de menu oculto ou busca.

**Não confundir com**: UIP-INPUT-OPTION_PICKER (listas maiores ou colapsadas), UIP-INPUT-LOOKUP_FIELD (entidades remotas), UIP-NAV-TABS (alternância de vistas).

**Nível composicional possível**: Leaf, Container

## Decisão

**Quando usar**: quando há poucas opções conhecidas; quando as opções precisam ficar comparáveis; quando seleção única, múltipla ou liga/desliga é parte clara da captura; quando a escolha impacta campos dependentes.

**Quando evitar**: quando há muitas opções; quando as opções precisam de busca, paginação ou carregamento remoto; quando a escolha representa navegação local e não entrada de dado; quando a opção precisa de descrição longa demais.

**Alternativas próximas**: UIP-INPUT-OPTION_PICKER (lista colapsada ou pesquisável), UIP-INPUT-LOOKUP_FIELD (entidade remota), UIP-NAV-TABS (alternância de vistas), UIP-INPUT-INPUT_FIELD (valor booleano).

**Sinais de escolha**:
- radio, checkbox, switch, toggle ou segmented choice
- número baixo de opções
- escolha precisa ser visível
- pode haver dependência entre opção e campos subsequentes
- poucas opções (2-7) que cabem visíveis simultaneamente

**Grau de Rigidez**: Médio — opções visíveis simultaneamente são estáveis; tipo de controle e layout variam.

## Composição

**Zonas usuais**: Conteúdo, Filtros.

**Variantes reconhecidas**: radio group; checkbox group; switch ou toggle; segmented choice; yes/no; multi-select curto.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-FORM, PP-SETTINGS, PP-WIZARD.

**Compatibilidade Secundária**: PP-CATALOG, PP-LIST-DETAIL, PP-DASHBOARD.

**Incompatibilidades explícitas**: não usar para coleção grande, entidade remota ou seleção que exige busca.

## Estrutura e Transição

**Estrutura Desktop**: opções visíveis agrupadas por label comum, com estado selecionado, desativado, erro e ajuda quando necessário.

**Estrutura Mobile**: opções empilhadas ou segmentadas conforme quantidade e densidade. Área de toque suficiente e seleção atual inequívoca.

**Regra de Transição**: preservar a visibilidade das alternativas e a seleção atual. Opções horizontais podem virar lista vertical em telas estreitas.

## Estados

**Estados próprios**: nenhuma seleção, opção selecionada, múltiplas selecionadas, opção desativada, grupo inválido, readonly, disabled, dependência ativa.

**Reação a estados da página**: `loading` → grupo desativado quando opções ou dependências estão carregando. `error` → mensagem de validação do grupo. `no-permission` → opções restritas ocultas ou desativadas.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: mapear radio, checkbox, switch, segmented control ou toggle conforme semântica e `ui-map`.

**Adaptação Mobile nativo**: preferir controles nativos quando preservarem semântica e área de toque adequada.

**Adaptação Desktop nativo**: garantir keyboard flow, foco e acesso por label.
