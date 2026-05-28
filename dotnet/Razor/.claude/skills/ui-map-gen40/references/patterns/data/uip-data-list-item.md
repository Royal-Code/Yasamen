# UIP-DATA-LIST_ITEM - List Item

## Definição

**Categoria**: Dados & Listagem

**Definição curta**: Unidade simples de listagem para leitura linear e ação localizada sobre um item.

**Objetivo estrutural**: Representar um item individual dentro de uma lista simples.

**Não confundir com**: UIP-DATA-DATA_TABLE (comparação por colunas), UIP-DATA-TREE_VIEW (hierarquia expansível), UIP-DATA-CARD_GRID (grade exploratória), UIP-DATA-TIMELINE_ITEM (entrada cronológica).

**Nível composicional possível**: Leaf

## Decisão

**Quando usar**: quando a leitura principal é item a item, em sequência linear; quando a coleção é simples ou de baixa densidade informacional; quando o foco está em título, subtítulo e poucos metadados.

**Quando evitar**: quando comparação por múltiplos atributos é central; quando imagem e apelo visual são dominantes; quando a relação pai/filho e expansão de nós é central; quando a ordem temporal e o contexto de evento são o centro da experiência.

**Alternativas próximas**: UIP-DATA-DATA_TABLE (comparação por colunas), UIP-DATA-TREE_VIEW (hierarquia expansível), UIP-DATA-CARD_GRID (grade exploratória), UIP-DATA-TIMELINE_ITEM (entrada cronológica).

**Sinais de escolha**:
- cada item cabe em uma linha ou bloco simples
- poucos atributos precisam ficar visíveis ao mesmo tempo
- ações por item são leves e localizadas
- a lista pode ser percorrida rapidamente em sequência
- leitura linear sem necessidade de comparação entre colunas

**Grau de Rigidez**: Baixo — unidade de listagem linear com ação localizada é estável; layout interno, metadados e ações variam.

## Composição

**Zonas usuais**: Coleção, Navegação.

**Variantes reconhecidas**: item simples; item com avatar ou ícone; item com metadados; item com ação inline; item selecionável; item de navegação.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: Todos os Page Patterns.

**Compatibilidade Secundária**: Nenhuma.

**Incompatibilidades explícitas**: não substitui UIP-DATA-DATA_TABLE em coleções com múltiplos atributos comparáveis.

## Estrutura e Transição

**Estrutura Desktop**: linha horizontal com ícone ou avatar opcional, título, subtítulo opcional, metadado secundário e ação contextual.

**Estrutura Mobile**: estrutura preservada. Metadados secundários podem ser omitidos. Área de toque ampliada.

**Regra de Transição**: layout preservado, com redução da informação secundária. Área de toque adequada quando houver touch.

## Estados

**Estados próprios**: normal, hover, selecionado, desativado, com badge ou notificação.

**Reação a estados da página**: `loading` → skeleton do item.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir hover ou foco, ações contextuais e densidade por viewport.

**Adaptação Mobile nativo**: pode compor com UIP-INTERACTION-SWIPE_ACTION, menu contextual ou navegação por stack.

**Adaptação Desktop nativo**: decidir foco por teclado, ações por linha e densidade.
