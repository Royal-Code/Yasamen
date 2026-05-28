# UIP-SYSTEM-PERMISSION_FLOW - Permission Flow

## Definição

**Categoria**: Sistema & Host

**Definição curta**: Fluxo de pedido de permissão do sistema operacional com pré-contexto, prompt nativo e tratamento de recusa.

**Objetivo estrutural**: Permitir que funcionalidades dependentes de permissão do host expliquem a necessidade, solicitem acesso e ofereçam alternativa quando a permissão não é concedida.

**Não confundir com**: UIP-FEEDBACK-CONFIRMATION_DIALOG (confirmação genérica), UIP-SYSTEM-AUTH_SESSION (login e sessão), onboarding (fora do catálogo), configuração interna do app (fora do catálogo).

**Nível composicional possível**: Container

## Decisão

**Quando usar**: quando uma funcionalidade depende de permissão do sistema — câmera, localização, notificações, contatos, microfone, arquivos, bluetooth ou sensores; quando o pedido precisa de justificativa contextual; quando a recusa deve ter fallback.

**Quando evitar**: quando a permissão já foi concedida; quando a funcionalidade não depende de permissão do host; quando pedir antecipadamente piora a decisão; quando uma alternativa sem permissão atende ao fluxo principal.

**Alternativas próximas**: UIP-CONTENT-CALLOUT_BLOCK (orientação contextual sem prompt do host).

**Sinais de escolha**:
- funcionalidade bloqueada sem permissão
- o SO exibirá prompt nativo limitado
- a contextualização aumenta o entendimento
- a recusa precisa ser tratada sem bloquear todo o app

**Grau de Rigidez**: Alto — pedido com pré-contexto e tratamento de recusa é invariante; tipo de permissão e fallback variam.

## Composição

**Zonas usuais**: Overlay.

**Variantes reconhecidas**: pré-screen de permissão; prompt nativo just-in-time; recusa temporária; recusa permanente; redirect para settings; funcionalidade degradada.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-FORM, PP-WIZARD, PP-MAP.

**Compatibilidade Secundária**: PP-DETAIL, PP-CATALOG, PP-CONVERSATION, PP-FEED, PP-CANVAS.

**Incompatibilidades explícitas**: não usar como confirmação genérica quando não há permissão real do host.

## Estrutura e Transição

**Estrutura Desktop**: mapear permissões de câmera, microfone, arquivos, notificações e sandbox do SO; pré-contexto quando necessário.

**Estrutura Mobile**: pré-contexto quando necessário, prompt nativo, tratamento de concedida, recusada e recusada permanente, e instrução para Settings.

**Regra de Transição**: pedir a permissão no momento em que o valor da funcionalidade está claro. Nunca bloquear todo o app por uma permissão local. Sempre prever estado concedido, recusado, recusado permanente e funcionalidade degradada.

## Estados

**Estados próprios**: não solicitada, pré-screen, aguardando resposta do host, concedida, recusada, recusada permanente, funcionalidade degradada, settings aberto, permissão revogada.

**Reação a estados da página**: permissão recusada → alternativa, mensagem contextual ou CTA para settings. `loading` → aguardando resposta do host. `error` → falha de API ou permissão indisponível.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Mobile nativo, Web.


## Adaptação por Plataforma

**Adaptação Web**: tratar permissões do browser, HTTPS, prompt bloqueado, revogação e fallback manual.

**Adaptação Mobile nativo**: respeitar prompts, rationales, settings e limitações específicas de iOS e Android.

**Adaptação Desktop nativo**: mapear permissões de câmera, microfone, arquivos, notificações e sandbox do SO.
