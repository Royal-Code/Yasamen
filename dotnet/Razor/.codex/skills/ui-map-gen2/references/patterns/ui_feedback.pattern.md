# UI Patterns de Feedback e Estado

UI Patterns de feedback e estado comunicam ausência, progresso, falha, confirmação e resultados de ações sem alterar a semântica estrutural do shell ou da página.

## Patterns

### Empty State

**ID_UI_PATTERN:** UIP-FEEDBACK-EMPTY_STATE
**Categoria:** Feedback & Estado
**Definição curta:** Estado de ausência de dados ou resultados, com orientação sobre o próximo passo possível.
**Objetivo estrutural:** Comunicar ausência de dados e orientar o utilizador para o próximo passo.
**Não confundir com:** Error State por falha técnica, Toast/Alert por evento transitório, placeholder de loading
**Nível composicional possível:** Leaf
**Quando usar:** quando não há dados iniciais ou a busca/filtro não retornou resultados; quando a zona ou página precisa explicar a ausência de conteúdo; quando um CTA pode orientar criação, ajuste de filtros ou novo caminho
**Quando evitar:** quando a ausência decorre de erro técnico; quando o feedback é transitório após uma ação; quando o conteúdo ainda está a carregar
**Alternativas próximas:** UIP-FEEDBACK-ERROR_STATE, UIP-FEEDBACK-LOADING_STATE, UIP-FEEDBACK-TOAST_ALERT
**Sinais de escolha:** não há conteúdo para exibir; a situação não é erro técnico; existe orientação possível ao utilizador; a zona pode ser substituída por mensagem e CTA
**Zonas usuais:** Content-Body, List, Table-Area, Detail-Panel
**Compatibilidade Primária:** Todos os Page Patterns
**Compatibilidade Secundária:** —
**Incompatibilidades explícitas:** Não substitui Error State quando o motivo é falha técnica
**Estrutura Desktop:** Área centrada com ícone/ilustração, título, subtítulo opcional, CTA quando aplicável.
**Estrutura Mobile:** Estrutura preservada. Ilustração pode simplificar. CTA em destaque.
**Regra de Transição:** Layout centrado preservado.
**Estados próprios:** sem dados (com CTA quando aplicável), sem resultados para filtro ou busca activa
**Reação a estados da página:** Substitui conteúdo quando dados estão ausentes.
**Grau de Rigidez:** Baixo

### Loading State

**ID_UI_PATTERN:** UIP-FEEDBACK-LOADING_STATE
**Categoria:** Feedback & Estado
**Definição curta:** Estado visual de progresso enquanto conteúdo ou ação ainda está em carregamento ou processamento.
**Objetivo estrutural:** Indicar que dados ou acção estão em progresso.
**Não confundir com:** Empty State sem dados, Error State por falha, toast de ação concluída
**Nível composicional possível:** Leaf
**Quando usar:** quando conteúdo ou ação ainda não está pronto; quando a página ou zona precisa preservar continuidade durante espera; quando o utilizador deve perceber progresso ou indisponibilidade temporária
**Quando evitar:** quando já há falha técnica estabelecida; quando não existe mais conteúdo esperado; quando o feedback é apenas posterior a uma ação concluída
**Alternativas próximas:** UIP-FEEDBACK-EMPTY_STATE, UIP-FEEDBACK-ERROR_STATE, indicador inline simples
**Sinais de escolha:** a operação está em curso; o conteúdo será exibido depois; a zona precisa sinalizar espera; a interface deve evitar sensação de quebra
**Zonas usuais:** Content-Body, Table-Area, Form Submit, Panel Body
**Compatibilidade Primária:** Todos os Page Patterns
**Compatibilidade Secundária:** —
**Incompatibilidades explícitas:** Nenhuma
**Estrutura Desktop:** Skeleton da área de conteúdo esperada (preferencial) ou spinner centrado.
**Estrutura Mobile:** Skeleton preservado. Spinner como alternativa em áreas pequenas.
**Regra de Transição:** Skeleton preservado em ambas as plataformas.
**Estados próprios:** carregamento inicial, carregamento parcial (scroll progressivo), carregamento de acção (overlay ou inline)
**Reação a estados da página:** Activo durante qualquer estado de carregamento.
**Grau de Rigidez:** Médio

### Error State

**ID_UI_PATTERN:** UIP-FEEDBACK-ERROR_STATE
**Categoria:** Feedback & Estado
**Definição curta:** Feedback de falha técnica ou de recuperação necessária, com mensagem compreensível e caminho claro de retorno.
**Objetivo estrutural:** Comunicar falha técnica e oferecer caminho claro de recuperação.
**Não confundir com:** Empty State por ausência de dados, Toast / Alert pós-ação, No Permission State estrutural
**Nível composicional possível:** Leaf
**Quando usar:** quando o conteúdo ou a ação falhou por erro técnico, de rede, de permissão operacional ou de recurso não encontrado; quando a página ou a zona precisa oferecer retry, alternativa ou orientação de recuperação; quando a falha precisa substituir ou interromper a leitura normal do conteúdo
**Quando evitar:** quando não há erro e apenas não existem dados; quando o feedback pode ser não bloqueante após uma ação concluída; quando a situação pede confirmação antes de agir, não recuperação após falha
**Alternativas próximas:** UIP-FEEDBACK-EMPTY_STATE, UIP-FEEDBACK-TOAST_ALERT, No Permission State
**Sinais de escolha:** carregamento ou submissão falhou; há caminho de retry ou ação corretiva; a falha precisa ser explicada no próprio contexto da zona ou página; o conteúdo esperado não pode ser exibido normalmente
**Zonas usuais:** Content-Body, Detail-Panel, Form Body, Table-Area
**Compatibilidade Primária:** Todos os Page Patterns
**Compatibilidade Secundária:** —
**Incompatibilidades explícitas:** Não substitui Empty State quando há ausência de dados sem erro
**Estrutura Desktop:** Área com ícone de erro, título descritivo, subtítulo opcional, acção de retry ou alternativa.
**Estrutura Mobile:** Estrutura preservada. CTA de retry em destaque.
**Regra de Transição:** Layout preservado.
**Estados próprios:** erro de carregamento (com retry), erro de submissão, erro de permissão, erro de não encontrado, erro de rede
**Reação a estados da página:** Substitui conteúdo quando carregamento falha. Inline quando acção falha.
**Grau de Rigidez:** Médio

### Toast / Alert

**ID_UI_PATTERN:** UIP-FEEDBACK-TOAST_ALERT
**Categoria:** Feedback & Estado
**Definição curta:** Feedback não bloqueante sobre resultado de ação ou evento do sistema, em forma flutuante temporária ou alerta contextual persistente.
**Objetivo estrutural:** Notificar o utilizador de resultado de acção ou evento do sistema de forma não bloqueante, seja por toast flutuante temporário ou alerta inline/contextual.
**Não confundir com:** Error State que substitui conteúdo, Confirmation Dialog que exige decisão prévia, Empty State sem evento disparador
**Nível composicional possível:** Leaf
**Quando usar:** quando o sistema precisa confirmar, avisar ou sinalizar algo sem bloquear a tarefa em curso; quando o feedback está ligado a uma ação concluída ou a um evento contextual; quando a mensagem deve ficar global ou local sem substituir a estrutura principal
**Quando evitar:** quando a falha exige substituição do conteúdo ou recuperação explícita no corpo da página; quando a interação exige decisão prévia do utilizador; quando a mensagem precisa permanecer como conteúdo primário da zona
**Alternativas próximas:** UIP-FEEDBACK-ERROR_STATE, UIP-FEEDBACK-CONFIRMATION_DIALOG, mensagem inline de formulário
**Sinais de escolha:** a tarefa principal pode continuar; o feedback é complementar e não estrutural; a mensagem pode ser efêmera ou contextual; não há necessidade de bloquear a interface
**Zonas usuais:** Global Overlay, Header contextual, Inline Feedback, Form Feedback
**Compatibilidade Primária:** Todos os Page Patterns
**Compatibilidade Secundária:** —
**Incompatibilidades explícitas:** Não substitui Confirmation Dialog para acções que exigem confirmação prévia
**Estrutura Desktop:** Pode ser notificação flutuante temporária ou alerta inline/contextual. Ícone de tipo, mensagem, fechar e acção secundária opcional quando fizer sentido.
**Estrutura Mobile:** Variante não bloqueante equivalente ao contexto. Pode aparecer como toast compacto, faixa contextual ou alerta inline touch-friendly.
**Regra de Transição:** A semântica do feedback deve ser preservada. Posição, largura e modo de apresentação podem variar conforme contexto global, local e plataforma.
**Estados próprios:** sucesso, aviso, erro, informação, persistente, a desaparecer
**Reação a estados da página:** Independente do estado da página — aparece após acção ou evento.
**Grau de Rigidez:** Médio
**Variantes reconhecidas:** Toast flutuante temporário; Alert inline/contextual persistente

### Confirmation Dialog

**ID_UI_PATTERN:** UIP-FEEDBACK-CONFIRMATION_DIALOG
**Categoria:** Feedback & Estado
**Definição curta:** Confirmação modal de ação arriscada, irreversível ou operacionalmente sensível.
**Objetivo estrutural:** Solicitar confirmação explícita antes de acção irreversível ou de alto impacto.
**Não confundir com:** Toast / Alert informativo, Error State de falha, Action Bar de execução direta
**Nível composicional possível:** Leaf
**Quando usar:** quando a ação tem impacto irreversível ou risco elevado; quando a decisão precisa ser explícita antes de executar; quando o utilizador deve entender claramente o impacto antes de prosseguir
**Quando evitar:** quando a ação é reversível ou de baixo risco; quando o feedback deve acontecer depois da ação e não antes; quando a confirmação seria fricção desnecessária
**Alternativas próximas:** UIP-FEEDBACK-TOAST_ALERT, inline confirmation leve, dupla ação reversível
**Sinais de escolha:** existe risco real ou irreversibilidade; a interface precisa bloquear até a decisão; há distinção clara entre confirmar e cancelar; o impacto precisa ser lido antes da execução
**Zonas usuais:** Global Overlay, Destructive Action Confirmation
**Compatibilidade Primária:** Todos os Page Patterns
**Compatibilidade Secundária:** —
**Incompatibilidades explícitas:** Não usar para acções reversíveis sem risco
**Estrutura Desktop:** Modal centrado com título, descrição do impacto, botão de confirmação (destrutivo quando aplicável) e cancelar. Overlay no fundo.
**Estrutura Mobile:** Sheet ou modal compacto, com clareza equivalente para impacto, confirmação e cancelamento. Botões podem ser empilhados ou distribuídos conforme guideline da plataforma.
**Regra de Transição:** Modal centrado → variante compacta touch-friendly. A inteligibilidade da decisão e a distinção da ação destrutiva devem ser preservadas.
**Estados próprios:** aberto aguardando decisão, a processar após confirmação, fechado
**Reação a estados da página:** Bloqueia interacção com a página. Loading State após confirmação enquanto processa.
**Grau de Rigidez:** Alto
