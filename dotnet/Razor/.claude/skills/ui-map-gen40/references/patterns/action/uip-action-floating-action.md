# UIP-ACTION-FLOATING_ACTION - Floating Action

## Definição

**Categoria**: Ação

**Definição curta**: Ação primária destacada e persistente, acessível acima do conteúdo da página.

**Objetivo estrutural**: Destacar a ação primária mais importante da página de forma sempre acessível.

**Não confundir com**: UIP-ACTION-ACTION_BAR (barra com múltiplas ações), UIP-NAV-NAVIGATION_MENU (controle de navegação), botão inline contextual (fora do catálogo).

**Nível composicional possível**: Leaf

## Decisão

**Quando usar**: quando existe uma única ação primária dominante; quando a ação deve permanecer acessível durante a rolagem; quando a página é orientada a criação ou execução recorrente de uma ação; quando o contexto tolera uma superfície flutuante persistente.

**Quando evitar**: quando há muitas ações equivalentes; quando a página já possui barra de ações suficiente; quando o elemento flutuante conflita com leitura, navegação, teclado, safe areas ou acessibilidade; quando a ação não é realmente dominante.

**Alternativas próximas**: UIP-ACTION-ACTION_BAR (barra de ações da página).

**Sinais de escolha**:
- há uma ação claramente dominante
- a rolagem não deve esconder a ação principal
- a tarefa principal é recorrente e rápida
- a ação pode ser descrita de forma curta e inequívoca

**Grau de Rigidez**: Alto — ação primária flutuante e persistente é invariante; posição, expansão e ação secundária variam.

## Composição

**Zonas usuais**: Ações.

**Variantes reconhecidas**: botão flutuante circular; botão flutuante estendido; ação flutuante com menu curto de ações relacionadas.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-FEED, PP-CATALOG.

**Compatibilidade Secundária**: PP-LIST-DETAIL, PP-DASHBOARD, PP-MAP, PP-CANVAS.

**Incompatibilidades explícitas**: PP-FORM, PP-WIZARD, PP-SETTINGS quando a ação principal já pertence ao fluxo ou ao footer.

## Estrutura e Transição

**Estrutura Desktop**: botão flutuante fixo ou ação destacada em canto de baixa interferência. Rótulo opcional quando o ícone não basta.

**Estrutura Mobile**: botão flutuante fixo acima de navegação inferior, teclado, barras do sistema e safe areas. Área de toque adequada.

**Regra de Transição**: posição e comportamento preservados. O rótulo pode ser omitido se a ação continuar inequívoca. Nunca sobrepor controles críticos, conteúdo essencial ou navegação raiz.

## Estados

**Estados próprios**: normal, hover ou foco, pressionado, processando, desativado, oculto por contexto.

**Reação a estados da página**: `loading` → desativado ou em progresso. `no-permission` → oculto ou desativado. `empty` → pode ser a ação principal de criação.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo.


## Adaptação por Plataforma

**Adaptação Web**: validar colisão com conteúdo, responsividade, foco por teclado e alternativas em header ou footer.

**Adaptação Mobile nativo**: considerar navegação inferior, teclado virtual, safe areas, gestos do sistema e mudança de visibilidade por scroll quando adotada pela plataforma.

**Adaptação Desktop nativo**: usar com parcimônia; em apps densas, preferir action bar, toolbar ou command palette.
