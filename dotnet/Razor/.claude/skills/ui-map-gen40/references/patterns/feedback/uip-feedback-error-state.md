# UIP-FEEDBACK-ERROR_STATE - Error State

## Definição

**Categoria**: Feedback & Estado

**Definição curta**: Feedback de falha técnica ou recuperação necessária, com mensagem compreensível e caminho claro de retorno.

**Objetivo estrutural**: Comunicar falha, bloqueio ou indisponibilidade e oferecer retry, correção, autenticação, alternativa ou orientação de recuperação.

**Não confundir com**: UIP-FEEDBACK-EMPTY_STATE (ausência sem erro), UIP-FEEDBACK-TOAST_ALERT (evento não bloqueante), UIP-FEEDBACK-CONFIRMATION_DIALOG (decisão antes de uma ação).

**Nível composicional possível**: Leaf

## Decisão

**Quando usar**: quando conteúdo ou ação falhou por erro técnico, rede, autenticação, permissão operacional, offline, timeout ou recurso não encontrado; quando a página ou zona precisa oferecer retry, alternativa ou orientação de recuperação; quando a falha impede a leitura normal do conteúdo.

**Quando evitar**: quando não há erro e apenas não existem dados; quando o feedback pode ser não bloqueante após uma ação concluída; quando a situação pede confirmação antes de agir; quando a falha pertence apenas a um campo de formulário.

**Alternativas próximas**: UIP-FEEDBACK-EMPTY_STATE (ausência sem erro), UIP-FEEDBACK-TOAST_ALERT (feedback não bloqueante), UIP-INPUT-VALIDATION_SUMMARY (erro de formulário), UIP-SYSTEM-AUTH_SESSION (reautenticação).

**Sinais de escolha**:
- carregamento ou submissão falhou
- há caminho de retry ou ação corretiva
- a falha precisa ser explicada no contexto da zona ou página
- o conteúdo esperado não pode ser exibido normalmente

**Grau de Rigidez**: Médio — feedback de falha com caminho de retorno é invariante; mensagem, ação e detalhe variam.

## Composição

**Zonas usuais**: Conteúdo, Detalhe, Coleção, Ações.

**Variantes reconhecidas**: erro de carregamento; erro de submissão; erro de rede ou offline; não encontrado; permissão insuficiente; autenticação expirada; conflito de dados; falha parcial.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: Todos os Page Patterns.

**Compatibilidade Secundária**: Nenhuma.

**Incompatibilidades explícitas**: não substitui UIP-FEEDBACK-EMPTY_STATE quando há ausência de dados sem erro; não substitui validação de campo quando o erro é local e recuperável inline.

## Estrutura e Transição

**Estrutura Desktop**: estado de erro no escopo afetado, com mensagem principal, explicação quando necessária e ação de recuperação — retry, login, voltar ou alternativa.

**Estrutura Mobile**: estrutura preservada em zona compacta. Ação de recuperação acessível no fluxo atual.

**Regra de Transição**: preservar o escopo do erro. Erro global substitui a página; erro de zona substitui apenas a zona; erro de ação permanece próximo da ação.

## Estados

**Estados próprios**: erro de carregamento com retry, erro de submissão, erro de permissão, erro de autenticação expirada, erro de não encontrado, erro de rede ou offline, erro parcial, erro irrecuperável.

**Reação a estados da página**: renderiza `error`. Substitui o conteúdo quando o carregamento falha; aparece inline quando a ação falha; pode acionar UIP-FEEDBACK-TOAST_ALERT quando a página continua utilizável.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: distinguir erro de rota, zona, submissão, autenticação e offline para escolher o escopo correto.

**Adaptação Mobile nativo**: considerar offline, sessão expirada, permissões de sistema e retomada após o app voltar ao foreground.

**Adaptação Desktop nativo**: falhas de arquivo, processo, sync e permissões do sistema podem exigir ações específicas do host.
