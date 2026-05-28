# UIP-NAV-NAV_STACK - Navigation Stack

## Definição

**Categoria**: Navegação

**Definição curta**: Navegação hierárquica por push/pop de vistas com gestão de pilha e gestos de retorno.

**Objetivo estrutural**: Organizar a progressão entre vistas mantendo contexto de retorno e hierarquia implícita.

**Não confundir com**: UIP-NAV-TABS (alternância entre vistas irmãs), UIP-NAV-NAVIGATION_MENU (navegação global), UIP-NAV-BREADCRUMB (trilha hierárquica).

**Nível composicional possível**: Root

## Decisão

**Quando usar**: quando a experiência é hierárquica, como lista → detalhe → sub-detalhe; quando cada vista empilhada depende do contexto anterior; quando gestos de retorno nativos devem funcionar; quando a profundidade é previsível, normalmente entre 2 e 5 níveis.

**Quando evitar**: quando as vistas são irmãs sem hierarquia; quando a navegação é circular sem hierarquia clara; quando a profundidade pode ser excessiva sem motivo.

**Alternativas próximas**: UIP-NAV-TABS (vistas irmãs), UIP-NAV-NAVIGATION_MENU (navegação global), UIP-OVERLAY-BOTTOM_SHEET (detalhe leve sobreposto).

**Sinais de escolha**:
- existe relação pai-filho entre telas
- swipe back no iOS ou botão back no Android são esperados
- a barra de navegação muda por nível
- deep link precisa resolver a hierarquia

**Grau de Rigidez**: Alto — push/pop de vistas com retorno é invariante; transição, header e deep link variam por plataforma.

## Composição

**Zonas usuais**: Navegação.

**Variantes reconhecidas**: stack padrão push/pop; stack modal; stack com deep link; stack aninhada por tab.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-LIST-DETAIL, PP-DETAIL, PP-CATALOG, PP-CONVERSATION, PP-SETTINGS.

**Compatibilidade Secundária**: PP-FORM, PP-WIZARD, PP-CALENDAR, PP-MAP.

**Incompatibilidades explícitas**: páginas sem hierarquia real ou com alternância livre entre vistas irmãs.

## Estrutura e Transição

**Estrutura Desktop**: a pilha mapeia para rotas e histórico navegável; níveis podem virar split panel quando houver espaço e ganho estrutural.

**Estrutura Mobile**: push/pop de vistas com header por nível, botão ou gesto de retorno e transição animada; cada nível depende do contexto anterior.

**Regra de Transição**: respeitar o idioma de retorno de cada plataforma — swipe da borda no iOS, botão do sistema no Android. Deep links reconstituem a pilha correta.

## Estados

**Estados próprios**: root sem back, empilhado com back, em transição push/pop, deep link resolvendo a pilha.

**Reação a estados da página**: `loading` na vista destino → skeleton enquanto resolve. `error` na navegação → permanece na vista atual com feedback.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo.

**Plataformas primárias**: Mobile nativo.


## Adaptação por Plataforma

**Adaptação Web**: mapear a pilha para rotas, histórico e estado navegável; preservar o back do browser quando aplicável.

**Adaptação Mobile nativo**: usar as regras de plataforma para retorno, deep link e reconstrução da pilha.

**Adaptação Desktop nativo**: normalmente substituir por navegação por rotas ou split panel; não usar push/pop como navegação primária.
