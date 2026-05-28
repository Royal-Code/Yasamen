# UIP-NAV-NAVIGATION_MENU - Navigation Menu

## Definição

**Categoria**: Navegação

**Definição curta**: Navegação estrutural principal que dá acesso aos destinos globais do sistema ou do shell ativo.

**Objetivo estrutural**: Acesso estruturado aos módulos e seções do sistema. Âncora de navegação global.

**Não confundir com**: UIP-NAV-TABS (vistas irmãs na mesma página), UIP-NAV-SECTION_NAV (seções internas da página), UIP-NAV-BREADCRUMB (contexto hierárquico), UIP-ACTION-CONTEXTUAL_MENU (ações locais).

**Nível composicional possível**: Root

## Decisão

**Quando usar**: quando o usuário precisa acessar módulos, áreas ou seções globais do sistema; quando o shell exige navegação persistente entre destinos principais; quando a hierarquia de navegação deve permanecer disponível ao longo da sessão.

**Quando evitar**: quando a alternância é apenas entre vistas locais da mesma página; quando a navegação aponta para seções da própria página; quando a necessidade é contextual a um item específico; quando a navegação existe só dentro de um fluxo sequencial.

**Alternativas próximas**: UIP-NAV-SECTION_NAV (seções internas), UIP-NAV-TABS (vistas irmãs), UIP-NAV-BREADCRUMB (contexto hierárquico), UIP-NAV-TAB_BAR (destinos raiz em mobile).

**Sinais de escolha**:
- destinos representam módulos ou seções globais
- a navegação precisa sobreviver à troca de páginas internas
- há relação forte com o shell ativo
- permissões podem ocultar ou desativar destinos inteiros

**Grau de Rigidez**: Alto — destinos globais persistentes são invariantes; formato, posição e colapso variam por shell e plataforma.

## Composição

**Zonas usuais**: Navegação.

**Variantes reconhecidas**: sidebar; top navigation; navigation rail; drawer navigation; menu hierárquico; árvore de navegação quando os destinos são globais ou do shell.

## Compatibilidade com Shell Patterns

**Compatibilidade Primária**: Todos os Shell Patterns.

**Compatibilidade Secundária**: Nenhuma.

**Incompatibilidades explícitas**: Nenhuma; elemento global.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: Todos os Page Patterns.

**Compatibilidade Secundária**: Nenhuma.

**Incompatibilidades explícitas**: não substitui UIP-NAV-TABS nem UIP-NAV-SECTION_NAV para navegação local.

## Estrutura e Transição

**Estrutura Desktop**: sidebar vertical em workspace ou barra superior em portal. Itens hierárquicos com agrupamento por módulo.

**Estrutura Mobile**: navegação compacta equivalente ao shell. Pode usar navegação inferior para escopo reduzido ou drawer quando a hierarquia exigir mais profundidade.

**Regra de Transição**: navegação expandida → navegação compacta equivalente. Hierarquia, destinos principais e clareza de acesso são preservados, mesmo com redistribuição visual.

## Estados

**Estados próprios**: item ativo, item inativo, item com badge ou notificação, item desativado, menu expandido, menu colapsado.

**Reação a estados da página**: `no-permission` → item oculto ou desativado conforme a permissão do módulo.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir sidebar, header, drawer ou navegação compacta por viewport.

**Adaptação Mobile nativo**: quando houver 3-5 destinos principais, considerar UIP-NAV-TAB_BAR; quando a hierarquia for profunda, usar drawer ou menu equivalente.

**Adaptação Desktop nativo**: pode integrar sidebar persistente, agrupamento por módulo e foco por teclado.
