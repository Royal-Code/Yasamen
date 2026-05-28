# SHP-FOCUSED - Focused

## Definição

**Definição curta**: Shell mínimo para tela autônoma de tarefa única, sem navegação global.

**Objetivo estrutural**: Sustentar uma tela focada com chrome mínimo: autenticação, erro em página cheia, splash, confirmação isolada, gate de consentimento.

**Interação dominante**: Focal

**Não confundir com**: SHP-KIOSK_EMBEDDED, SHP-PORTAL, SHP-WORKSPACE_ADMIN.

## Decisão

**Sinais de escolha**:
- sem navegação global nem alternância entre módulos
- tarefa única autocontida, fora do fluxo principal
- login, recuperação de conta, splash, erro em página cheia, confirmação isolada, gate de consentimento
- a página define toda a experiência

**Limites**: não usar quando há navegação entre destinos, módulos ou conteúdo persistente.

**Grau de Rigidez**: Alto — ausência de navegação global e área central única são invariantes; marca, rodapé legal e ilustração variam.

## Navegação e Estrutura

**Modelo de navegação global**: nenhuma. Acesso e saída por ação da página ou redirecionamento de fluxo.

**Estrutura Desktop**: área central única centralizada, chrome mínimo. Sem sidebar e sem header de navegação. Marca acima e rodapé legal opcionais.

**Estrutura Mobile**: área central em largura total, chrome mínimo. Ação primária acessível sem navegação extra.

**Regra de transição**: centralização e ausência de navegação global preservadas; largura total em Mobile.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-AUTH.

**Compatibilidade Secundária**: PP-LANDING, PP-FORM, PP-WIZARD, PP-DETAIL.

**Incompatibilidades explícitas**: PP-DASHBOARD, PP-LIST-DETAIL, PP-CATALOG, PP-FEED, PP-BOARD, PP-CALENDAR, PP-MAP, PP-CANVAS, PP-CONVERSATION, PP-SETTINGS como página dominante.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir largura da área central, marca, rodapé legal e comportamento em viewport pequeno.

**Adaptação Mobile nativo**: área central em largura total, teclado adequado, ações de confirmar e voltar explícitas.

**Adaptação Desktop nativo**: pode usar janela dedicada; manter chrome mínimo.
