# PP-WIZARD - Wizard

## Definição

**Definição curta**: Página de fluxo guiado em múltiplas etapas, com progressão declarada e validação por fase.

**Objetivo estrutural**: Sustentar tarefas transacionais complexas divididas em etapas explícitas.

**Interação dominante**: Transacional multi-etapa

**Não confundir com**: PP-FORM (captura em etapa única), PP-SETTINGS (configuração por seções).

## Decisão

**Sinais de escolha**:
- sequência obrigatória
- dependência entre etapas
- progressão monitorada
- validação por fase antes de avançar
- volume de campos ou complexidade exige divisão em passos

**Limites**: não usar quando a tarefa cabe confortavelmente numa única página ou quando a ordem das ações é flexível.

**Grau de Rigidez**: Alto — progressão sequencial, validação por fase e stepper são invariantes; o conteúdo de cada etapa varia.

## Composição

**Zonas funcionais obrigatórias**: Navegação; Conteúdo; Ações.

**UI Patterns tipicamente obrigatórios**: UIP-NAV-STEPPER_INDICATOR, UIP-INPUT-FORM_FIELD_GROUP, UIP-ACTION-ACTION_BAR, UIP-FEEDBACK-ERROR_STATE, UIP-FEEDBACK-LOADING_STATE.

## Compatibilidade com Shell Patterns

**Compatibilidade Primária**: SHP-WORKSPACE_ADMIN, SHP-TRANSACTIONAL_COMMERCE, SHP-KIOSK_EMBEDDED.

**Compatibilidade Secundária**: SHP-PORTAL, SHP-FOCUSED.

**Incompatibilidades explícitas**: SHP-COMMUNICATION, SHP-DASHBOARD_ANALYTICS como experiência dominante.

## Estrutura e Transição

**Estrutura Desktop**: stepper visível com corpo da etapa e ações de navegação.

**Estrutura Mobile**: progressão vertical ou compacta, com foco numa etapa por vez.

**Regra de transição**: preservar ordem, progresso e critérios de validação em qualquer viewport.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo.


## Adaptação por Plataforma

**Adaptação Web**: definir stepper, roteamento, persistência de progresso e recuperação de erro.

**Adaptação Mobile nativo**: manter a etapa atual e o progresso mínimo visíveis; tratar teclado, permissões e retomada do app quando afetam o fluxo.

**Adaptação Desktop nativo**: stepper visível, navegação por teclado entre etapas válidas e persistência de progresso.
