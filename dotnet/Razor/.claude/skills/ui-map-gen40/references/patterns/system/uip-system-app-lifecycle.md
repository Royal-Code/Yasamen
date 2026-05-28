# UIP-SYSTEM-APP_LIFECYCLE - App Lifecycle

## Definição

**Categoria**: Sistema & Host

**Definição curta**: Gestão visual de cold start, warm start, background, foreground, deep link, privacidade e preservação de contexto.

**Objetivo estrutural**: Garantir continuidade percebida, privacidade e feedback adequado nas transições de estado do app.

**Não confundir com**: UIP-FEEDBACK-LOADING_STATE (carregamento genérico), UIP-SYSTEM-AUTH_SESSION (sessão isolada), splash decorativa (fora do catálogo).

**Nível composicional possível**: Root

## Decisão

**Quando usar**: quando o cold start precisa de feedback significativo; quando o retorno de background exige refresh, reauth ou reconexão; quando dados sensíveis precisam ser ocultados em background; quando deep links precisam resolver destino e estado.

**Quando evitar**: quando o app carrega instantaneamente, não tem dados sensíveis e não muda estado ao retornar; quando splash decorativa não agrega decisão estrutural.

**Alternativas próximas**: UIP-SYSTEM-AUTH_SESSION (sessão e reautenticação), UIP-FEEDBACK-LOADING_STATE (carregamento genérico).

**Sinais de escolha**:
- start acima de 1s
- dados sensíveis
- sessão expirada ou background timeout
- deep link ou reconexão
- estado stale
- o thumbnail do app deve ocultar conteúdo

**Grau de Rigidez**: Alto — gestão de cold e warm start e background é invariante; animações e preservação de contexto variam.

## Composição

**Zonas usuais**: Conteúdo, Overlay.

**Variantes reconhecidas**: cold start; warm start; foreground resume; background privacy; deep link resolving; sessão expirada no resume; reconnecting.

## Compatibilidade com Shell Patterns

**Compatibilidade Primária**: Todos os Shell Patterns.

**Compatibilidade Secundária**: Nenhuma.

**Incompatibilidades explícitas**: páginas web simples sem ciclo de vida de app ou estado local significativo.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: Todos os Page Patterns.

**Compatibilidade Secundária**: Nenhuma.

**Incompatibilidades explícitas**: nenhuma ampla; o escopo depende da presença de ciclo de vida real na plataforma.

## Estrutura e Transição

**Estrutura Desktop**: mapear minimize e restore, múltiplas janelas, lock, processo em background e sessão.

**Estrutura Mobile**: launch screen refletindo o carregamento real, resolução de estado, foreground e background, proteção de dados sensíveis e retomada de sessão.

**Regra de Transição**: o cold start reflete o estado real de carregamento; background privacy oculta dados sensíveis; foreground resume valida sessão, conexão e dados stale antes de mostrar estado confiável.

## Estados

**Estados próprios**: cold start, warm start, foreground resume, background enter, privacy shield, sessão expirada, reconnecting, deep link resolving, estado restaurado, estado perdido.

**Reação a estados da página**: sessão expirada → reauth ou lock. Deep link → `loading` da tela destino. Dados stale → indicador ou refresh antes da interação crítica.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: considerar reload, visibility change, service worker, installability, deep links e sessão.

**Adaptação Mobile nativo**: tratar cold e warm start, background, foreground, deep link, privacidade e sessão com APIs nativas.

**Adaptação Desktop nativo**: mapear minimize e restore, múltiplas janelas, lock, processo em background e sessão.
