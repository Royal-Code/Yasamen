# UIP-OVERLAY-BOTTOM_SHEET - Bottom Sheet

## Definição

**Categoria**: Overlay & Superfície Temporária

**Definição curta**: Superfície modal ou semi-modal deslizante a partir da base da tela, com alturas progressivas e contexto preservado.

**Objetivo estrutural**: Expor conteúdo complementar, opções, detalhe ou tarefa curta sem trocar o contexto principal da tela.

**Não confundir com**: UIP-OVERLAY-MODAL (superfície bloqueante), UIP-OVERLAY-DRAWER (painel lateral), UIP-ACTION-CONTEXTUAL_MENU (menu por item), UIP-STRUCT-SPLIT_PANEL (painéis simultâneos).

**Nível composicional possível**: Container

## Decisão

**Quando usar**: quando é necessário mostrar opções, detalhe ou formulário curto sem perder o contexto atrás; quando alturas parciais agregam progressive disclosure; quando o usuário pode arrastar para expandir ou fechar; quando mobile ou touch é o plataforma dominante.

**Quando evitar**: quando o conteúdo precisa de navegação profunda própria; quando uma confirmação forte e bloqueante é necessária; quando a tarefa exige tela completa persistente; quando um menu ou popover curto resolve melhor.

**Alternativas próximas**: UIP-OVERLAY-MODAL (superfície bloqueante), UIP-ACTION-CONTEXTUAL_MENU (menu por item), UIP-OVERLAY-DRAWER (painel lateral), UIP-STRUCT-SPLIT_PANEL (painéis simultâneos).

**Sinais de escolha**:
- conteúdo auxiliar ou complementar
- contexto atrás deve permanecer parcialmente perceptível
- o sheet pode ter estados de altura
- dismiss por gesto faz sentido
- a tarefa é curta ou progressiva

**Grau de Rigidez**: Médio — sheet deslizante a partir da base é invariante; alturas, conteúdo e dismiss variam.

## Composição

**Zonas usuais**: Overlay.

**Variantes reconhecidas**: modal bottom sheet; persistent bottom sheet; half sheet; full-height sheet; action sheet; sheet com snap points.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-LIST-DETAIL, PP-CATALOG, PP-FEED, PP-MAP, PP-CALENDAR.

**Compatibilidade Secundária**: PP-FORM, PP-DETAIL, PP-BOARD.

**Incompatibilidades explícitas**: PP-WIZARD e fluxos com navegação profunda quando o sheet viraria uma tela paralela complexa.

## Estrutura e Transição

**Estrutura Desktop**: normalmente substituído por popover, drawer ou floating panel.

**Estrutura Mobile**: sheet deslizante a partir da base com alturas progressivas — peek, half, expanded —, indicador de arraste, dismiss por swipe e contexto preservado atrás.

**Regra de Transição**: preservar alturas progressivas, dismiss e contexto. Não reduzir a dialog simples quando a altura parcial é parte da decisão estrutural.

## Estados

**Estados próprios**: oculto, peek, half-expanded, expanded, arrastando, fechando, conteúdo carregando, erro interno.

**Reação a estados da página**: `loading` → conteúdo do sheet em skeleton ou progresso local. `error` → mensagem dentro do sheet quando o erro pertence ao seu conteúdo.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo.

**Plataformas primárias**: Mobile nativo.


## Adaptação por Plataforma

**Adaptação Web**: garantir foco, scroll interno, dismiss acessível e fallback para modal ou drawer em viewport amplo.

**Adaptação Mobile nativo**: respeitar a navegação do sistema, safe areas, teclado, gestos de dismiss e estados de altura da plataforma.

**Adaptação Desktop nativo**: substituir por popover, drawer ou floating panel, que preservam melhor simultaneidade e controle.
