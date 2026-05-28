# UIP-SYSTEM-AUTH_SESSION - Auth Session

## Definição

**Categoria**: Sistema & Host

**Definição curta**: Tratamento de sessão expirada, lock, reautenticação, troca de usuário e retorno seguro à tela.

**Objetivo estrutural**: Preservar segurança e continuidade quando identidade, sessão ou autorização mudam durante o uso da interface.

**Não confundir com**: PP-AUTH (página de login), UIP-FEEDBACK-ERROR_STATE (falha técnica genérica), UIP-SYSTEM-PERMISSION_FLOW (permissão do host), onboarding (fora do catálogo).

**Nível composicional possível**: Root, Container

## Decisão

**Quando usar**: quando a sessão pode expirar; quando dados sensíveis exigem lock ou reauth; quando permissões podem mudar em tempo real; quando o retorno à tela original precisa ser controlado após autenticação.

**Quando evitar**: quando não há autenticação ou sessão; quando uma navegação simples para login resolve sem retorno contextual; quando o fluxo é público e não manipula dado protegido.

**Alternativas próximas**: PP-AUTH (fluxo de login e credenciais), UIP-FEEDBACK-ERROR_STATE (falha de autorização).

**Sinais de escolha**:
- sessão expirada ou refresh token falhou
- role ou permissão mudou
- o app volta do background
- operação sensível pede reauth
- troca de usuário
- deep link protegido

**Grau de Rigidez**: Alto — tratamento de sessão expirada e reauth é invariante; método de reauth e retorno variam.

## Composição

**Zonas usuais**: Overlay.

**Variantes reconhecidas**: silent refresh; sessão expirada; lock screen; reauth inline; reauth modal; redirect para login; troca de usuário; permission refresh.

## Compatibilidade com Shell Patterns

**Compatibilidade Primária**: SHP-WORKSPACE_ADMIN, SHP-COMMUNICATION, SHP-TRANSACTIONAL_COMMERCE, SHP-STUDIO_WORKBENCH.

**Compatibilidade Secundária**: SHP-DASHBOARD_ANALYTICS, SHP-MEDIA_CONTENT, SHP-PORTAL, SHP-KIOSK_EMBEDDED.

**Incompatibilidades explícitas**: experiências totalmente públicas sem identidade ou sessão.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: Todos os Page Patterns protegidos por autenticação.

**Compatibilidade Secundária**: Nenhuma.

**Incompatibilidades explícitas**: não substitui autorização por ação nem permission flow do sistema operacional.

## Estrutura e Transição

**Estrutura Desktop**: a sessão pode ser renovada silenciosamente, bloquear a tela, abrir reauth modal ou redirecionar preservando retorno seguro.

**Estrutura Mobile**: ao foreground ou operação sensível, pode exigir biometria, PIN, senha ou reauth, preservando contexto quando permitido.

**Regra de Transição**: preservar contexto apenas quando seguro. Nunca mostrar dado protegido após sessão expirada sem validação. Erros de autorização devem diferenciar expiração, falta de permissão e login ausente.

## Estados

**Estados próprios**: autenticado, renovando sessão, sessão expirada, locked, reauth required, reauth failed, usuário trocado, permissão atualizada, retorno restaurado.

**Reação a estados da página**: sessão expirada → bloquear, reautenticar ou redirecionar. `no-permission` → remover ações ou áreas restritas. `loading` → renovação ou validação de sessão.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: tratar refresh token, redirect, protected routes, retorno, múltiplas abas e sessão expirada.

**Adaptação Mobile nativo**: considerar biometria, secure storage, app foreground, lock screen e deep link protegido.

**Adaptação Desktop nativo**: tratar múltiplas janelas, lock do app, credential store e troca de usuário.
