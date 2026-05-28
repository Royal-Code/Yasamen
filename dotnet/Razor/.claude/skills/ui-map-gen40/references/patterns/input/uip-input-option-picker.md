# UIP-INPUT-OPTION_PICKER - Option Picker

## Definição

**Categoria**: Entrada

**Definição curta**: Controle de seleção a partir de opções conhecidas, colapsadas ou pesquisáveis, com valor único ou múltiplo.

**Objetivo estrutural**: Capturar uma opção de domínio controlado quando exibir todas as opções simultaneamente não é adequado.

**Não confundir com**: UIP-INPUT-CHOICE_GROUP (poucas opções visíveis), UIP-INPUT-LOOKUP_FIELD (entidade remota ou rica), UIP-INPUT-SEARCH_BAR (busca de conteúdo).

**Nível composicional possível**: Leaf

## Decisão

**Quando usar**: quando a entrada deve escolher uma opção de lista conhecida; quando há opções demais para radio ou checkbox; quando dropdown, select, combobox, autocomplete local ou multi-select resolvem a seleção.

**Quando evitar**: quando a lista é pequena e comparabilidade visual importa; quando o dado é entidade remota com detalhe, permissões ou criação; quando entrada livre é aceita sem domínio controlado.

**Alternativas próximas**: UIP-INPUT-CHOICE_GROUP (poucas opções visíveis), UIP-INPUT-LOOKUP_FIELD (entidade remota), UIP-INPUT-INPUT_FIELD (entrada livre), UIP-INPUT-FILTER_PANEL (refinamento de coleções).

**Sinais de escolha**:
- opções conhecidas de domínio enumerado
- pode haver busca local
- seleção única ou múltipla
- opções com labels, grupos, disabled state ou ordenação
- opções numerosas demais para exibir todas (8+)

**Grau de Rigidez**: Médio — seleção colapsada ou pesquisável é estável; apresentação, busca e multiselect variam.

## Composição

**Zonas usuais**: Conteúdo, Filtros.

**Variantes reconhecidas**: select; dropdown; combobox; autocomplete local; multi-select; grouped options; option picker nativo.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-FORM, PP-SETTINGS, PP-WIZARD.

**Compatibilidade Secundária**: PP-CATALOG, PP-LIST-DETAIL, PP-DASHBOARD.

**Incompatibilidades explícitas**: não usar quando a seleção depende de busca remota rica, criação de entidade ou detalhe contextual complexo.

## Estrutura e Transição

**Estrutura Desktop**: campo com valor selecionado, lista colapsada ou combobox, estados de opção e feedback de validação.

**Estrutura Mobile**: picker nativo, sheet, modal ou lista dedicada conforme quantidade de opções e necessidade de busca.

**Regra de Transição**: preservar domínio de opções, seleção atual e validação. Dropdown desktop pode virar picker nativo, sheet ou tela de seleção em mobile.

## Estados

**Estados próprios**: vazio, aberto, opção selecionada, múltiplas opções selecionadas, filtrando, sem opções, opção desativada, inválido, carregando opções.

**Reação a estados da página**: `loading` → opções carregando ou controle desativado. `error` → falha ao carregar opções. `empty` → sem opções disponíveis.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir select, dropdown, combobox, autocomplete, multi-select e fallback por teclado.

**Adaptação Mobile nativo**: usar picker nativo, sheet ou tela de seleção conforme quantidade e busca.

**Adaptação Desktop nativo**: garantir keyboard flow, typeahead e estados de opção.
