# UIP-INPUT-REPEATING_GROUP - Repeating Group

## Definição

**Categoria**: Entrada

**Definição curta**: Grupo repetível de campos para capturar lista de itens, endereços, contatos, parcelas, regras ou subentidades.

**Objetivo estrutural**: Permitir adicionar, remover, ordenar e validar múltiplas instâncias de um mesmo conjunto de campos.

**Não confundir com**: UIP-DATA-LIST_ITEM (listagem apenas de leitura), UIP-DATA-DATA_TABLE (edição tabular massiva), UIP-INPUT-FORM_FIELD_GROUP (grupo não repetível).

**Nível composicional possível**: Container

## Decisão

**Quando usar**: quando o formulário captura coleção de subitens; quando cada item tem campos próprios; quando o usuário precisa adicionar, remover ou reordenar entradas; quando a validação pode ocorrer por item e no conjunto.

**Quando evitar**: quando há apenas um grupo de campos; quando a edição é massiva e tabular; quando cada item exige fluxo próprio complexo; quando a coleção é melhor gerida em página separada.

**Alternativas próximas**: UIP-INPUT-FORM_FIELD_GROUP (grupo não repetível), UIP-DATA-DATA_TABLE (edição tabular), PP-LIST-DETAIL (gestão de coleção), PP-WIZARD (item por etapa).

**Sinais de escolha**:
- botão adicionar e remover item
- campos repetidos
- validação por índice
- min/max de itens, reorder
- anexos ou opções por item

**Grau de Rigidez**: Médio — grupo repetível de campos é invariante; número de repetições, layout e ações variam.

## Composição

**Zonas usuais**: Conteúdo.

**Variantes reconhecidas**: lista de grupos; cards repetíveis; tabela editável simples; accordion por item; grupo reordenável; grupo repetível aninhado.

**UI Patterns tipicamente contidos**: UIP-INPUT-FORM_FIELD_GROUP, UIP-INPUT-INPUT_FIELD, UIP-INTERACTION-DRAG_DROP, UIP-ACTION-CONTEXTUAL_MENU.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-FORM, PP-WIZARD.

**Compatibilidade Secundária**: PP-SETTINGS, PP-DETAIL, PP-LIST-DETAIL.

**Incompatibilidades explícitas**: não usar para coleções grandes que exigem paginação, busca, filtros ou operação independente por item.

## Estrutura e Transição

**Estrutura Desktop**: itens repetíveis em cards, linhas, accordion ou tabela simples, com ações de adicionar, remover, duplicar e reordenar quando permitido.

**Estrutura Mobile**: itens empilhados, ações explícitas por item e edição progressiva quando muitos campos competem por espaço.

**Regra de Transição**: preservar identidade do item, ordem, validação e ações de adicionar ou remover. Tabela desktop pode virar cards ou seções empilhadas em mobile.

## Estados

**Estados próprios**: vazio, item adicionado, item removido, item expandido, item colapsado, item inválido, limite mínimo, limite máximo, reordenando, salvando.

**Reação a estados da página**: `error` de submissão → erros por item e Validation Summary. `loading` → ações de adicionar e remover desativadas. `no-permission` → grupo readonly ou ações restritas.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir cards, tabela simples, accordion, reorder, validação por item e resumo.

**Adaptação Mobile nativo**: usar edição progressiva, seções colapsáveis ou tela por item quando o grupo for denso.

**Adaptação Desktop nativo**: pode integrar keyboard flow, drag/drop reorder e edição tabular simples.
