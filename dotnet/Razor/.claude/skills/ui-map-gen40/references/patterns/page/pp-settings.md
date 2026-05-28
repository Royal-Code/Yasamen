# PP-SETTINGS - Settings

## Definição

**Definição curta**: Página de configuração, preferências e parâmetros agrupados por seções estáveis.

**Objetivo estrutural**: Sustentar leitura, edição e gravação controlada de preferências e políticas.

**Interação dominante**: Configuracional

**Não confundir com**: PP-FORM (captura em etapa única), PP-WIZARD (fluxo guiado multi-etapa).

## Decisão

**Sinais de escolha**:
- parâmetros persistentes
- seções estáveis
- preferência ou política
- alterações não necessariamente lineares

**Limites**: não usar quando a tarefa é transação curta, onboarding guiado ou gestão intensiva de coleção.

**Grau de Rigidez**: Médio — agrupamento por seções estáveis é fixo; quantidade de parâmetros e tipo de controle variam.

## Composição

**Zonas funcionais obrigatórias**: Navegação; Conteúdo; Ações.

**UI Patterns tipicamente obrigatórios**: UIP-NAV-TABS ou UIP-NAV-BREADCRUMB, UIP-STRUCT-STACK_CONTAINER, UIP-INPUT-FORM_FIELD_GROUP, UIP-ACTION-ACTION_BAR, UIP-FEEDBACK-TOAST_ALERT.

## Compatibilidade com Shell Patterns

**Compatibilidade Primária**: SHP-WORKSPACE_ADMIN.

**Compatibilidade Secundária**: SHP-PORTAL, SHP-STUDIO_WORKBENCH.

**Incompatibilidades explícitas**: SHP-COMMUNICATION como experiência dominante.

## Estrutura e Transição

**Estrutura Desktop**: seções agrupadas com navegação local e ações persistentes.

**Estrutura Mobile**: seções empilhadas ou tabs compactas com ações no final ou fixas.

**Regra de transição**: preservar o agrupamento lógico e a segurança da ação de salvar.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir tabs, navegação local, salvamento e feedback.

**Adaptação Mobile nativo**: usar stack ou lista de configurações; evitar densidade alta e garantir retorno por seção.

**Adaptação Desktop nativo**: pode usar painel lateral, busca de configuração e keyboard flow.
