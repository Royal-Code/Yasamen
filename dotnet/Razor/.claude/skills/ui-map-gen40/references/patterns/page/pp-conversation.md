# PP-CONVERSATION - Conversation

## Definição

**Definição curta**: Página de thread conversacional com composição, leitura e atualização contínua.

**Objetivo estrutural**: Sustentar troca de mensagens, leitura de contexto e continuidade de conversa.

**Interação dominante**: Comunicacional

**Não confundir com**: PP-FEED (stream cronológico unilateral), PP-LIST-DETAIL (coleção operacional com detalhe).

## Decisão

**Sinais de escolha**:
- thread dominante
- composição de mensagem
- histórico conversacional
- contexto de participantes
- atualização em tempo real

**Limites**: não usar quando a cronologia é unilateral, sem resposta, ou quando a conversa é apenas um detalhe secundário.

**Grau de Rigidez**: Alto — thread, composição e leitura cronológica são invariantes; features adicionais e layout periférico variam.

## Composição

**Zonas funcionais obrigatórias**: Coleção; Conteúdo; Painel Auxiliar; Ações.

**UI Patterns tipicamente obrigatórios**: UIP-STRUCT-SCROLLABLE_REGION, UIP-DATA-TIMELINE_ITEM, UIP-ACTION-ACTION_BAR, UIP-DATA-LIST_ITEM, UIP-FEEDBACK-EMPTY_STATE.

## Compatibilidade com Shell Patterns

**Compatibilidade Primária**: SHP-COMMUNICATION.

**Compatibilidade Secundária**: SHP-WORKSPACE_ADMIN.

**Incompatibilidades explícitas**: SHP-PORTAL como shell dominante.

## Estrutura e Transição

**Estrutura Desktop**: thread e contexto coexistem, com scroll independente quando necessário.

**Estrutura Mobile**: alternância entre lista de conversas e thread ativa, ou foco direto na thread.

**Regra de transição**: preservar continuidade conversacional, composição e leitura do histórico.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir entre split panel, thread única, regiões com scroll e fallback mobile.

**Adaptação Mobile nativo**: usar UIP-NAV-NAV_STACK, lifecycle, push ou deep link e possível offline ou sync.

**Adaptação Desktop nativo**: pode ativar tray ou dock, teclado, command palette e notificações.
