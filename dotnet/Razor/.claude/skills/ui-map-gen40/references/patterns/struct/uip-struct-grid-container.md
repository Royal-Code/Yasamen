# UIP-STRUCT-GRID_CONTAINER - Grid Container

## Definição

**Categoria**: Estrutural

**Definição curta**: Contêiner de organização em grade para distribuir elementos por colunas e linhas.

**Objetivo estrutural**: Organizar UI Patterns em grade de múltiplas colunas.

**Não confundir com**: UIP-DATA-CARD_GRID (coleção visual semântica), UIP-STRUCT-LAYOUT_ZONE (zona funcional), UIP-DATA-DATA_TABLE (tabela de dados).

**Nível composicional possível**: Container

## Decisão

**Quando usar**: quando a composição exige distribuição em múltiplas colunas; quando os blocos precisam manter alinhamento visual em grade; quando o layout responde por densidade e distribuição, não por semântica de coleção.

**Quando evitar**: quando a intenção é uma coleção visual de cards; quando a leitura é predominantemente linear; quando a zona tem significado funcional próprio além da distribuição.

**Alternativas próximas**: UIP-DATA-CARD_GRID (coleção visual), UIP-STRUCT-STACK_CONTAINER (empilhamento vertical), UIP-STRUCT-LAYOUT_ZONE (zona funcional).

**Sinais de escolha**:
- a grade serve à composição dos blocos
- colunas variáveis fazem sentido
- os elementos compartilham alinhamento visual, não papel semântico comum
- a ordem deve ser preservada entre faixas responsivas

**Grau de Rigidez**: Médio — distribuição por colunas e linhas é fixa; número de colunas, gaps e breakpoints variam.

## Composição

**Zonas usuais**: Conteúdo.

**Variantes reconhecidas**: grade de N colunas fixa; grade responsiva; grade de larguras proporcionais; grade com gap variável.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-CATALOG, PP-DASHBOARD.

**Compatibilidade Secundária**: PP-FEED, PP-LANDING.

**Incompatibilidades explícitas**: PP-FORM, PP-WIZARD, PP-CONVERSATION.

## Estrutura e Transição

**Estrutura Desktop**: grade de N colunas declaradas por contexto. Espaçamento uniforme. Itens de largura igual ou proporcional.

**Estrutura Mobile**: redução de colunas, tipicamente para 1 ou 2. Empilhamento progressivo conforme a faixa.

**Regra de Transição**: N colunas Desktop → M colunas Mobile, com M menor que N. Nunca alterar a ordem dos itens.

## Estados

**Estados próprios**: normal, carregando, vazio, filtro ativo.

**Reação a estados da página**: `loading` → skeleton da grade completa. `empty` → exibe empty state centrado. `error` → exibe error state.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: definir a redução de colunas sem alterar a ordem dos itens.

**Adaptação Mobile nativo**: reduzir densidade e evitar grades que prejudiquem toque ou leitura.

**Adaptação Desktop nativo**: decidir número de colunas, gaps e alinhamento por viewport.
