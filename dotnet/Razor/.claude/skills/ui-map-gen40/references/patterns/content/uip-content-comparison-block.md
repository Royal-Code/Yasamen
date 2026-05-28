# UIP-CONTENT-COMPARISON_BLOCK - Comparison Block

## Definição

**Categoria**: Conteúdo

**Definição curta**: Bloco de comparação entre versões, estados, entidades, opções ou valores para apoiar revisão e decisão.

**Objetivo estrutural**: Apresentar diferenças, semelhanças, alterações ou alternativas de forma comparável, preservando a relação entre itens comparados e critérios relevantes.

**Não confundir com**: UIP-DATA-DATA_TABLE (coleção tabular ampla), UIP-CONTENT-DETAIL_BLOCK (leitura de uma entidade), UIP-SURFACE-CHART (análise gráfica), UIP-CONTENT-METRIC_CARD (indicador isolado).

**Nível composicional possível**: Container, Leaf

## Decisão

**Quando usar**: quando o usuário precisa comparar antes/depois, versão atual/nova, plano A/plano B, entidade A/entidade B, alterações propostas ou diferenças relevantes antes de aprovar, salvar, comprar ou decidir.

**Quando evitar**: quando há apenas uma entidade sem comparação; quando a comparação exige tabela extensa com muitas linhas e colunas; quando a diferença é puramente gráfica ou analítica; quando a decisão depende de leitura documental completa.

**Alternativas próximas**: UIP-CONTENT-DETAIL_BLOCK (leitura de uma entidade), UIP-DATA-DATA_TABLE (coleção tabular), UIP-CONTENT-RICH_TEXT_BLOCK (conteúdo editorial), UIP-CONTENT-METRIC_CARD (indicador isolado), UIP-SURFACE-CHART (análise gráfica).

**Sinais de escolha**:
- aparecem termos como comparar, revisar alterações, antes/depois, atual/novo, diff, alternativas, planos ou versões
- critérios equivalentes precisam ficar alinhados
- diferenças precisam ser destacadas

**Grau de Rigidez**: Médio — comparação estruturada entre versões ou opções é estável; formato, colunas e destaque de diferença variam.

## Composição

**Zonas usuais**: Conteúdo, Detalhe.

**Variantes reconhecidas**: comparação lado a lado; diff textual; resumo de mudanças; comparação de planos; antes/depois; matriz curta de critérios; comparação visual.

**UI Patterns tipicamente contidos**: UIP-CONTENT-DETAIL_BLOCK, UIP-CONTENT-RICH_TEXT_BLOCK, UIP-CONTENT-METRIC_CARD, UIP-CONTENT-MEDIA_VIEWER, UIP-ACTION-ACTION_BAR.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-FORM, PP-WIZARD, PP-DETAIL, PP-CATALOG.

**Compatibilidade Secundária**: PP-LIST-DETAIL, PP-SETTINGS, PP-DASHBOARD, PP-LANDING.

**Incompatibilidades explícitas**: PP-CONVERSATION (comparação fora do conteúdo persistente da conversa).

## Estrutura e Transição

**Estrutura Desktop**: comparação lado a lado, matriz curta, blocos pareados ou diff com realce de alterações. Critérios equivalentes ficam alinhados ou claramente vinculados.

**Estrutura Mobile**: pares empilhados, alternância por abas ou segmento, ou resumo de mudanças. Destaques de diferença permanecem claros sem leitura horizontal simultânea.

**Regra de Transição**: a relação entre itens comparados e critérios é preservada. O layout pode abandonar o lado a lado, sem perder a correspondência entre valores equivalentes.

## Estados

**Estados próprios**: sem diferenças, com diferenças, diferença adicionada, diferença removida, diferença alterada, comparação parcial, carregando, erro, item indisponível.

**Reação a estados da página**: `loading` → skeleton dos blocos comparados. `error` → erro no escopo da comparação. `empty` → sem diferenças ou sem itens comparáveis.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir lado a lado, diff, matriz, highlights e ações de aceitar ou rejeitar.

**Adaptação Mobile nativo**: evitar colunas simultâneas; usar pares empilhados, alternância ou resumo por mudanças.

**Adaptação Desktop nativo**: pode usar múltiplos painéis, diff rico, inspectors e navegação entre diferenças.
