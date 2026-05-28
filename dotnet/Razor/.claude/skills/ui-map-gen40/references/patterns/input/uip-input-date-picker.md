# UIP-INPUT-DATE_PICKER - Date Picker

## Definição

**Categoria**: Entrada

**Definição curta**: Controle estruturado para seleção de data única ou intervalo de datas.

**Objetivo estrutural**: Capturar data ou intervalo de datas de forma estruturada.

**Não confundir com**: UIP-INPUT-INPUT_FIELD (campo de texto livre), UIP-INPUT-FILTER_PANEL (filtro genérico sem calendário).

**Nível composicional possível**: Leaf

## Decisão

**Quando usar**: quando a data ou intervalo é parte explícita da entrada ou do filtro; quando calendário, validação de datas e restrições de período agregam valor; quando o usuário não deve digitar datas complexas livremente.

**Quando evitar**: quando um texto livre basta e não há regra temporal relevante; quando o período é pré-definido por atalhos fixos sem escolha granular; quando a data é apenas exibida e não editada.

**Alternativas próximas**: UIP-INPUT-INPUT_FIELD (campo com máscara), UIP-INPUT-FILTER_PANEL (filtro de período).

**Sinais de escolha**:
- a data é parte estrutural da ação ou do filtro
- intervalo de datas pode ser necessário
- restrições como datas inválidas ou desativadas importam
- o usuário precisa de apoio visual de calendário

**Grau de Rigidez**: Médio — seleção de data com validação é invariante; intervalo, formato, presets e calendário variam.

## Composição

**Zonas usuais**: Conteúdo, Filtros.

**Variantes reconhecidas**: data única; intervalo de datas; data com hora; com presets de período; calendário inline; calendário em dropdown.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-FORM, PP-CALENDAR.

**Compatibilidade Secundária**: PP-SETTINGS, PP-DASHBOARD, PP-CATALOG, PP-LIST-DETAIL.

**Incompatibilidades explícitas**: Nenhuma fora de contexto de entrada.

## Estrutura e Transição

**Estrutura Desktop**: campo de texto com ícone de calendário. Calendário em dropdown. Navegação por mês e ano. Seleção de intervalo opcional.

**Estrutura Mobile**: pode usar modal, sheet ou picker nativo, conforme plataforma, granularidade da seleção e complexidade da interação.

**Regra de Transição**: dropdown → variante mobile equivalente. Picker nativo pode substituir calendário custom quando melhorar consistência e usabilidade.

## Estados

**Estados próprios**: vazio, com data selecionada, com intervalo selecionado, data inválida, data desativada, calendário aberto.

**Reação a estados da página**: `error` → campo com mensagem de data inválida ou obrigatória.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir dropdown, range, validação e restrições.

**Adaptação Mobile nativo**: preferir picker nativo quando ele preservar granularidade e regras de seleção.

**Adaptação Desktop nativo**: considerar keyboard flow, entrada textual validada e atalhos de período.
