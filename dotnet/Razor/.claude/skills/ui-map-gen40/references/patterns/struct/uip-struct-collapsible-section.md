# UIP-STRUCT-COLLAPSIBLE_SECTION - Collapsible Section

## Definição

**Categoria**: Estrutural

**Definição curta**: Seção estrutural que pode expandir ou recolher conteúdo mantendo cabeçalho, estado e relação com a sequência da página.

**Objetivo estrutural**: Controlar densidade, progressividade e foco de leitura em conteúdos agrupados, permitindo ocultar detalhes sem remover a seção da estrutura da tela.

**Não confundir com**: UIP-NAV-TABS (alternância entre vistas irmãs), UIP-OVERLAY-DRAWER (superfície temporária), UIP-STRUCT-STACK_CONTAINER (empilhamento simples), UIP-INPUT-FORM_FIELD_GROUP (agrupamento semântico de formulário).

**Nível composicional possível**: Container

## Decisão

**Quando usar**: quando uma página ou zona possui grupos de conteúdo opcionais, longos ou secundários; quando o usuário precisa abrir detalhes sob demanda; quando progressive disclosure reduz ruído sem perder orientação; quando seções têm título e estado próprio.

**Quando evitar**: quando o conteúdo é essencial e deve ficar sempre visível; quando alternar entre seções muda a vista ativa inteira; quando o conteúdo precisa de superfície própria ou navegação profunda; quando o recolhimento esconderia validações ou ações críticas sem sinalização.

**Alternativas próximas**: UIP-STRUCT-STACK_CONTAINER (empilhamento simples), UIP-STRUCT-LAYOUT_ZONE (zona funcional), UIP-NAV-TABS (alternância de vistas), UIP-OVERLAY-DRAWER (superfície temporária).

**Sinais de escolha**:
- há seções nomeadas com cabeçalho reconhecível
- detalhes podem ser escondidos sem quebrar a tarefa
- o estado expandido ou recolhido precisa ser previsível
- pode haver contador, erro ou status no cabeçalho

**Grau de Rigidez**: Médio — comportamento expansível e recolhível é invariante; conteúdo interno e trigger variam.

## Composição

**Zonas usuais**: Conteúdo, Detalhe, Filtros.

**Variantes reconhecidas**: accordion simples; múltiplas seções expansíveis; disclosure único; seção colapsável com status; seção colapsável com validação; grupo colapsável dentro de painel.

**UI Patterns tipicamente contidos**: UIP-STRUCT-STACK_CONTAINER, UIP-INPUT-FORM_FIELD_GROUP, UIP-CONTENT-DETAIL_BLOCK, UIP-CONTENT-RICH_TEXT_BLOCK, UIP-CONTENT-CALLOUT_BLOCK.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-SETTINGS, PP-FORM, PP-DETAIL.

**Compatibilidade Secundária**: PP-WIZARD, PP-LANDING, PP-DASHBOARD, PP-LIST-DETAIL, PP-CATALOG.

**Incompatibilidades explícitas**: PP-CONVERSATION quando recolher conteúdo quebra a continuidade de leitura da conversa.

## Estrutura e Transição

**Estrutura Desktop**: cabeçalho de seção com título, estado e ação de expandir ou recolher. Conteúdo aparece abaixo quando expandido. Pode haver múltiplas seções independentes ou comportamento accordion.

**Estrutura Mobile**: padrão útil para reduzir altura. Cabeçalhos tocáveis, estados claros e conteúdo expandido preservando a ordem de leitura.

**Regra de Transição**: a relação cabeçalho → conteúdo é preservada. Conteúdo visível em desktop pode iniciar recolhido em mobile quando for secundário; informações críticas e erros permanecem sinalizados.

## Estados

**Estados próprios**: expandida, recolhida, desativada, com erro, com aviso, carregando conteúdo interno, conteúdo vazio, bloqueada por permissão.

**Reação a estados da página**: `loading` → skeleton no cabeçalho ou conteúdo interno. `error` → erro sinalizado no cabeçalho e detalhado ao expandir. `empty` → seção vazia sinalizada ou omitida conforme contexto.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir accordion único ou múltiplas seções independentes, persistência de estado e sinalização de erro no cabeçalho.

**Adaptação Mobile nativo**: usar como estratégia de densidade; garantir alvo de toque, estado visual e acesso a erros ou ações críticas.

**Adaptação Desktop nativo**: pode compor inspectors, painéis de propriedades, grupos de preferências e seções persistentes.
