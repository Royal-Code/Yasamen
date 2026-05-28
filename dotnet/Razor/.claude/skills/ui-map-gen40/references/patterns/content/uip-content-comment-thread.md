# UIP-CONTENT-COMMENT_THREAD - Comment Thread

## Definição

**Categoria**: Conteúdo

**Definição curta**: Thread de comentários, notas ou discussão colaborativa vinculada a uma entidade, documento, item ou tarefa.

**Objetivo estrutural**: Representar troca assíncrona contextual como parte do conteúdo de uma entidade, preservando autoria, ordem, respostas, estados e ações de colaboração sem transformar a página inteira em conversa.

**Não confundir com**: PP-CONVERSATION (página conversacional principal), UIP-DATA-TIMELINE_ITEM (histórico ou evento), UIP-CONTENT-RICH_TEXT_BLOCK (conteúdo editorial), UIP-FEEDBACK-TOAST_ALERT (evento temporário).

**Nível composicional possível**: Container

## Decisão

**Quando usar**: quando comentários, notas, revisões, observações, menções ou respostas ficam associados a uma entidade, tarefa, documento, ticket, aprovação ou item; quando a discussão precisa permanecer consultável junto ao conteúdo principal.

**Quando evitar**: quando a experiência principal é chat ou mensageria; quando os itens são eventos históricos sem conversa; quando o conteúdo é uma descrição editorial única; quando a colaboração acontece fora do escopo da tela.

**Alternativas próximas**: PP-CONVERSATION (página conversacional), UIP-DATA-TIMELINE_ITEM (histórico de eventos), UIP-CONTENT-RICH_TEXT_BLOCK (conteúdo editorial), UIP-INPUT-INLINE_EDITOR (edição no ponto de leitura), UIP-CONTENT-MEDIA_COLLECTION (anexos da entidade).

**Sinais de escolha**:
- existem autor, timestamp, corpo de comentário, replies, menções, anexos, edição ou resolução
- a thread pertence a uma entidade e não a um canal independente

**Grau de Rigidez**: Médio — thread com composição e leitura cronológica é invariante; reações, menções e formatação variam.

## Composição

**Zonas usuais**: Conteúdo, Painel Auxiliar.

**Variantes reconhecidas**: comentários planos; respostas aninhadas; notas internas; comentários resolvíveis; thread com anexos; discussão de revisão; comentários por trecho de documento.

**UI Patterns tipicamente contidos**: UIP-CONTENT-RICH_TEXT_BLOCK, UIP-CONTENT-MEDIA_COLLECTION, UIP-INPUT-INLINE_EDITOR, UIP-ACTION-CONTEXTUAL_MENU, UIP-DATA-TIMELINE_ITEM.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-DETAIL, PP-LIST-DETAIL, PP-BOARD.

**Compatibilidade Secundária**: PP-CONVERSATION, PP-FEED, PP-CANVAS, PP-FORM, PP-WIZARD.

**Incompatibilidades explícitas**: PP-DASHBOARD (comentários fora da decisão operacional).

## Estrutura e Transição

**Estrutura Desktop**: lista ou thread com autoria, timestamp, corpo, respostas, ações por comentário e compositor. Pode viver em painel lateral, seção inferior ou área de revisão vinculada a um trecho.

**Estrutura Mobile**: thread em lista vertical, compositor destacado e ações secundárias em menu. Respostas profundas simplificadas ou navegadas por foco.

**Regra de Transição**: ordem, autoria, relação de resposta e vínculo com a entidade são preservados. Menus, anexos e composer mudam de posição sem perder contexto.

## Estados

**Estados próprios**: sem comentários, carregando, com comentários, compondo, enviando, envio falhou, editando, resolvido, não resolvido, restrito por permissão, comentários desativados.

**Reação a estados da página**: `loading` → skeleton de comentários. `error` → erro no escopo da thread com retry. `empty` → ausência de comentários e ação para iniciar quando permitido.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir painel lateral ou seção inferior, replies, composer, menções, anexos e resolução.

**Adaptação Mobile nativo**: priorizar leitura vertical, composer acessível e menus compactos para ações por comentário.

**Adaptação Desktop nativo**: pode integrar com inspectors, comentários por seleção, notificações locais e múltiplas janelas.
