# UIP-CONTENT-CONTENT_HEADER - Content Header

## Definição

**Categoria**: Conteúdo

**Definição curta**: Cabeçalho semântico de entidade, seção ou conteúdo, com identidade, resumo, status e contexto essencial.

**Objetivo estrutural**: Ancorar a leitura de uma entidade, seção ou conteúdo antes do corpo principal, deixando claro o que está sendo visto, em que estado está e quais metadados essenciais contextualizam a tarefa.

**Não confundir com**: UIP-STRUCT-LAYOUT_ZONE (região estrutural), UIP-ACTION-ACTION_BAR (comandos), UIP-CONTENT-DETAIL_BLOCK (atributos detalhados), UIP-CONTENT-METRIC_CARD (KPI isolado).

**Nível composicional possível**: Container, Leaf

## Decisão

**Quando usar**: quando uma tela, painel, seção ou entidade precisa de título, subtítulo, identificador, status, resumo curto, proprietário, datas ou metadados de orientação antes do conteúdo detalhado; quando o usuário precisa reconhecer rapidamente o objeto ativo.

**Quando evitar**: quando a zona é apenas estrutural; quando todos os dados precisam ser lidos como atributos detalhados; quando o elemento é somente uma barra de ações; quando o conteúdo não possui identidade própria.

**Alternativas próximas**: UIP-CONTENT-DETAIL_BLOCK (atributos detalhados), UIP-CONTENT-METRIC_CARD (KPI isolado), UIP-STRUCT-LAYOUT_ZONE (região estrutural), UIP-ACTION-ACTION_BAR (barra de ações).

**Sinais de escolha**:
- existe um título dominante
- status ou identidade mudam a interpretação do restante da tela
- ações dependem do objeto ativo
- metadados curtos precisam ficar visíveis antes de detalhes, listas, mídia ou comentários

**Grau de Rigidez**: Médio — identidade, resumo e status são invariantes; layout, ações e metadados variam por entidade.

## Composição

**Zonas usuais**: Cabeçalho.

**Variantes reconhecidas**: header de entidade; header de seção; header de documento; header de perfil; header com status; header com resumo e métricas curtas; header com ações contextuais.

**UI Patterns tipicamente contidos**: UIP-ACTION-ACTION_BAR, UIP-ACTION-CONTEXTUAL_MENU, UIP-CONTENT-METRIC_CARD, UIP-CONTENT-DETAIL_BLOCK.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-DETAIL, PP-LIST-DETAIL, PP-CATALOG, PP-LANDING.

**Compatibilidade Secundária**: PP-DASHBOARD, PP-SETTINGS, PP-FORM, PP-BOARD, PP-FEED.

**Incompatibilidades explícitas**: PP-CONVERSATION (sem entidade ou tópico persistente a ancorar).

## Estrutura e Transição

**Estrutura Desktop**: título e identidade em destaque, metadados curtos próximos, status visível e ações principais no mesmo eixo ou em área adjacente. Pode incluir resumo, avatar, imagem, tags ou métricas curtas quando forem parte da identidade.

**Estrutura Mobile**: empilhar título, status, metadados e ações. Ações secundárias podem ir para menu contextual ou barra inferior conforme a plataforma.

**Regra de Transição**: identidade, status e relação com o conteúdo abaixo são preservados. A distribuição horizontal pode virar pilha vertical e ações secundárias podem ser compactadas; o objeto ativo não pode ficar ambíguo.

## Estados

**Estados próprios**: carregando, com conteúdo, sem metadados, entidade arquivada, entidade bloqueada, entidade inativa, entidade não encontrada, permissões restritas.

**Reação a estados da página**: `loading` → skeleton de título e metadados. `error` → mensagem de entidade indisponível no escopo do header. `empty` → ausência explícita de entidade ou seção.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir densidade, ações no topo, breadcrumbs próximos, status, tags e relação com UIP-ACTION-ACTION_BAR.

**Adaptação Mobile nativo**: priorizar título, status e ação principal; mover ações secundárias para menu ou área contextual.

**Adaptação Desktop nativo**: pode integrar com inspectors, toolbars e painéis persistentes; preservar o vínculo com a entidade ativa.
