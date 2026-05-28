# PP-FORM - Form

## Definição

**Definição curta**: Página de captura, atualização ou confirmação de dados em uma única etapa principal.

**Objetivo estrutural**: Sustentar entrada de dados com contexto claro, validação e submissão controlada.

**Interação dominante**: Transacional simples

**Não confundir com**: PP-WIZARD (fluxo guiado multi-etapa), PP-DETAIL (visualização de entidade).

## Decisão

**Sinais de escolha**:
- uma única etapa dominante
- campos agrupados
- validação direta e submissão única
- captura ou edição de dados em etapa única ou seções simultâneas
- não há dependência sequencial entre blocos que exija progressão obrigatória

**Limites**: não usar quando a tarefa exige múltiplas etapas explícitas, navegação por estados temporais ou exploração de coleção.

**Grau de Rigidez**: Médio — captura em etapa única com validação é estável; número de seções, layout de campos e fluxo de confirmação variam.

## Composição

**Zonas funcionais obrigatórias**: Cabeçalho; Conteúdo; Ações.

**UI Patterns tipicamente obrigatórios**: UIP-INPUT-FORM_FIELD_GROUP, UIP-INPUT-INPUT_FIELD, UIP-INPUT-VALIDATION_SUMMARY, UIP-ACTION-ACTION_BAR, UIP-FEEDBACK-ERROR_STATE, UIP-FEEDBACK-TOAST_ALERT, UIP-FEEDBACK-CONFIRMATION_DIALOG.

## Compatibilidade com Shell Patterns

**Compatibilidade Primária**: SHP-WORKSPACE_ADMIN, SHP-TRANSACTIONAL_COMMERCE, SHP-KIOSK_EMBEDDED.

**Compatibilidade Secundária**: SHP-PORTAL, SHP-STUDIO_WORKBENCH, SHP-FOCUSED.

**Incompatibilidades explícitas**: SHP-DASHBOARD_ANALYTICS como padrão dominante.

## Estrutura e Transição

**Estrutura Desktop**: formulário em coluna única ou dupla, com ações claramente separadas.

**Estrutura Mobile**: coluna única com ações acessíveis e validação contextual.

**Regra de transição**: reduzir colunas e preservar a hierarquia dos campos e da ação primária.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir validação, submissão, estado de erro e comportamento responsivo dos campos.

**Adaptação Mobile nativo**: considerar teclado virtual, permissões, picker nativo e confirmação ou cancelamento explícitos.

**Adaptação Desktop nativo**: decidir colunas, foco por teclado, validação inline e ações separadas.
