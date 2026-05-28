# UIP-STRUCT-SCROLLABLE_REGION - Scrollable Region

## Definição

**Categoria**: Estrutural

**Definição curta**: Região com scroll próprio, independente do scroll principal da página.

**Objetivo estrutural**: Delimitar uma área com scroll independente do restante da página.

**Não confundir com**: UIP-STRUCT-LAYOUT_ZONE (zona sem scroll próprio), página inteira rolável (fora do catálogo), feed completo (fora do catálogo).

**Nível composicional possível**: Container

## Decisão

**Quando usar**: quando uma subárea precisa rolar sem deslocar toda a página; quando a experiência exige foco local em lista, feed ou conversa; quando a altura da região é delimitada pelo contexto estrutural.

**Quando evitar**: quando o scroll da página inteira resolve naturalmente; quando o conteúdo da área é pequeno e estável; quando múltiplas regiões roláveis degradariam a usabilidade.

**Alternativas próximas**: UIP-STRUCT-LAYOUT_ZONE (zona funcional sem scroll próprio).

**Sinais de escolha**:
- a região tem altura definida
- o conteúdo pode crescer independentemente do resto da página
- o usuário precisa interagir longamente com a área sem perder o entorno
- o scroll local faz parte da tarefa

**Grau de Rigidez**: Baixo — scroll independente é invariante; tamanho, posição e comportamento de overflow variam.

## Composição

**Zonas usuais**: Coleção, Conteúdo, Painel Auxiliar.

**Variantes reconhecidas**: scroll vertical; scroll horizontal; scroll bidirecional; scroll virtualizado; scroll com sticky header.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-FEED, PP-CONVERSATION.

**Compatibilidade Secundária**: PP-LIST-DETAIL, PP-CATALOG, PP-DETAIL.

**Incompatibilidades explícitas**: PP-FORM simples, PP-LANDING.

## Estrutura e Transição

**Estrutura Desktop**: área com altura definida e scroll vertical interno. Largura determinada pela zona pai.

**Estrutura Mobile**: scroll nativo da região. A altura pode expandir para a viewport completa em contextos de foco único.

**Regra de Transição**: comportamento de scroll preservado. A altura pode expandir para a viewport em Mobile.

## Estados

**Estados próprios**: conteúdo disponível, carregando mais conteúdo, fim do conteúdo, erro ao carregar mais.

**Reação a estados da página**: `loading` → indicador no topo ou fundo da região. `empty` → conteúdo de zona vazia centrado.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: evitar múltiplos scrolls concorrentes sem necessidade estrutural.

**Adaptação Mobile nativo**: preservar scroll nativo, pull to refresh quando aplicável e comportamento com teclado.

**Adaptação Desktop nativo**: pode coexistir com painéis e listas virtualizadas.
