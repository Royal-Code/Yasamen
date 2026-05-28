# UIP-DATA-TIMELINE_ITEM - Timeline Item

## Definição

**Categoria**: Dados & Listagem

**Definição curta**: Entrada cronológica de evento, atividade ou histórico em uma linha temporal.

**Objetivo estrutural**: Representar um evento ou entrada em feed cronológico ou histórico de atividade.

**Não confundir com**: UIP-DATA-LIST_ITEM (item de lista genérico), UIP-DATA-CARD_GRID (card de catálogo), mensagem conversacional (fora do catálogo).

**Nível composicional possível**: Leaf

## Decisão

**Quando usar**: quando tempo, sequência e histórico importam; quando cada item representa um evento ou atualização; quando o usuário precisa percorrer atividade em ordem temporal.

**Quando evitar**: quando a coleção é operacional e comparativa; quando a experiência é de catálogo ou grade; quando a interação principal é diálogo bidirecional.

**Alternativas próximas**: UIP-DATA-LIST_ITEM (item de lista), UIP-DATA-CARD_GRID (grade de cards).

**Sinais de escolha**:
- a ordem temporal é central
- cada item representa evento ou atividade
- timestamp e contexto do evento são relevantes
- o histórico pode crescer continuamente

**Grau de Rigidez**: Baixo — entrada cronológica na linha temporal é estável; conteúdo, ações e agrupamento variam.

## Composição

**Zonas usuais**: Coleção.

**Variantes reconhecidas**: evento pontual; evento com duração; item agrupado por data; item com mídia ou anexo; item de auditoria.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-FEED.

**Compatibilidade Secundária**: PP-DASHBOARD, PP-DETAIL.

**Incompatibilidades explícitas**: PP-LIST-DETAIL operacional, PP-CATALOG.

## Estrutura e Transição

**Estrutura Desktop**: linha com indicador de tempo, avatar ou ícone, conteúdo principal e ações inline.

**Estrutura Mobile**: estrutura preservada. Ações por gesto longo ou menu contextual.

**Regra de Transição**: layout preservado com ajuste de espaçamento. Ações inline → menu contextual.

## Estados

**Estados próprios**: normal, não lido ou novo, expandido, colapsado, com ação em progresso, erro.

**Reação a estados da página**: `loading` → skeleton do item.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir scroll, atualização incremental e ações por item.

**Adaptação Mobile nativo**: pode combinar com pull to refresh, menu contextual, swipe action com fallback e offline sync.

**Adaptação Desktop nativo**: decidir histórico denso, ações por item e atualização incremental.
