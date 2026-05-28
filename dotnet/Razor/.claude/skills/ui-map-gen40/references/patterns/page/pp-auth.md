# PP-AUTH - Authentication

## Definição

**Definição curta**: Página de autenticação e gestão de acesso: login, cadastro, recuperação e verificação de identidade.

**Objetivo estrutural**: Capturar credenciais ou confirmar identidade em tela focada, com erro de credencial claro e acesso aos fluxos vizinhos de conta.

**Interação dominante**: Transacional simples

**Não confundir com**: PP-FORM, PP-WIZARD, PP-LANDING, PP-SETTINGS.

## Decisão

**Sinais de escolha**:
- autentica, cria conta, recupera acesso ou verifica identidade
- captura de credenciais: e-mail, senha, código, provedor de identidade
- roda fora do shell principal, antes do acesso ao produto
- chrome mínimo, zona central única, ação primária única
- links auxiliares para os outros fluxos de conta
- variantes: login; cadastro; recuperação de senha; nova senha; verificação ou MFA; provedor de identidade (SSO)

**Limites**: cadastro extenso ou onboarding multi-etapa de negócio migra para PP-FORM ou PP-WIZARD; gestão de conta já autenticada é PP-SETTINGS.

**Grau de Rigidez**: Médio — zona central de credenciais com ação primária e erro de credencial é invariante; número de campos, etapas de verificação e provedores variam por variante.

## Composição

**Zonas funcionais obrigatórias**: Cabeçalho; Conteúdo; Ações.

**UI Patterns tipicamente obrigatórios**: UIP-STRUCT-LAYOUT_ZONE, UIP-CONTENT-CONTENT_HEADER, UIP-INPUT-FORM_FIELD_GROUP, UIP-INPUT-INPUT_FIELD, UIP-ACTION-ACTION_BAR, UIP-INPUT-VALIDATION_SUMMARY, UIP-FEEDBACK-ERROR_STATE.

## Compatibilidade com Shell Patterns

**Compatibilidade Primária**: SHP-FOCUSED.

**Compatibilidade Secundária**: SHP-PORTAL, SHP-TRANSACTIONAL_COMMERCE.

**Incompatibilidades explícitas**: SHP-WORKSPACE_ADMIN, SHP-STUDIO_WORKBENCH, SHP-DASHBOARD_ANALYTICS, SHP-COMMUNICATION, SHP-MEDIA_CONTENT como shell dominante.

## Estrutura e Transição

**Estrutura Desktop**: zona central única centralizada — marca e título do fluxo, grupo de campos de credenciais, ação primária, feedback de erro, links auxiliares. Largura contida, chrome mínimo.

**Estrutura Mobile**: zona central em largura total, teclado adequado ao campo, ação primária acessível, erro próximo aos campos.

**Regra de transição**: zona central única e ordem marca → campos → ação → links preservadas; largura total em Mobile.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir provedores de identidade, persistência de sessão, verificação anti-abuso e responsividade da zona central.

**Adaptação Mobile nativo**: considerar biometria, autofill, teclado adequado, deep link de recuperação e verificação por código.

**Adaptação Desktop nativo**: considerar keyboard flow, autofill, gestor de credenciais do sistema e janela dedicada.
