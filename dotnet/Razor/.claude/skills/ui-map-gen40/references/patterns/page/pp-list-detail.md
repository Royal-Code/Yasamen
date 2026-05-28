# PP-LIST-DETAIL - List Detail

## Definição

**Definição curta**: Página operacional com coleção e detalhe sincronizados, simultâneos ou alternáveis.

**Objetivo estrutural**: Permitir selecionar itens numa coleção e operar sobre o detalhe com contexto persistente.

**Interação dominante**: Operacional

**Não confundir com**: PP-CATALOG (coleção exploratória), PP-DETAIL (entidade singular).

## Decisão

**Sinais de escolha**:
- existe coleção principal
- a seleção altera um detalhe
- o usuário alterna entre operar na lista e consultar ou editar o item
- operação recorrente sobre coleção com detalhe associado
- seleção de item altera um detalhe ou preview relevante

**Limites**: não usar quando a descoberta visual é o foco principal, quando não existe detalhe relevante ou quando a página é essencialmente formulário.

**Grau de Rigidez**: Alto — zonas de coleção e detalhe sincronizados são invariantes; a representação interna de cada zona varia.

## Composição

**Zonas funcionais obrigatórias**: Navegação; Filtros; Coleção; Detalhe; Ações.

**UI Patterns tipicamente obrigatórios**: UIP-STRUCT-LAYOUT_ZONE, UIP-STRUCT-SPLIT_PANEL, UIP-DATA-DATA_TABLE ou UIP-DATA-LIST_ITEM, UIP-CONTENT-DETAIL_BLOCK, UIP-ACTION-ACTION_BAR, UIP-FEEDBACK-EMPTY_STATE.

## Compatibilidade com Shell Patterns

**Compatibilidade Primária**: SHP-WORKSPACE_ADMIN, SHP-COMMUNICATION.

**Compatibilidade Secundária**: SHP-DASHBOARD_ANALYTICS, SHP-TRANSACTIONAL_COMMERCE.

**Incompatibilidades explícitas**: SHP-PORTAL como shell dominante.

## Estrutura e Transição

**Estrutura Desktop**: lista e detalhe coexistem em painéis simultâneos ou em master-detail forte.

**Estrutura Mobile**: lista e detalhe tornam-se vistas alternáveis.

**Regra de transição**: a simultaneidade em Desktop evolui para sequência navegável em Mobile.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: definir comportamento de split panel, colapso em viewport pequeno e preservação de seleção.

**Adaptação Mobile nativo**: usar UIP-NAV-NAV_STACK; lista e detalhe viram sequência, não painéis simultâneos em phone.

**Adaptação Desktop nativo**: pode ativar keyboard flow, command palette e multi-window quando a operação for densa.
