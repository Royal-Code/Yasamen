# UIP-NAV-STEPPER_INDICATOR - Stepper Indicator

## Definição

**Categoria**: Navegação

**Definição curta**: Indicador de progresso e posição dentro de um fluxo sequencial com etapas explícitas.

**Objetivo estrutural**: Indicar progresso e posição em fluxo multi-etapas com sequência obrigatória.

**Não confundir com**: UIP-NAV-TABS (alternância livre), UIP-NAV-BREADCRUMB (hierarquia entre níveis), UIP-NAV-NAVIGATION_MENU (navegação global).

**Nível composicional possível**: Leaf, Container

## Decisão

**Quando usar**: quando o usuário precisa entender em que etapa está e quantas faltam; quando o fluxo tem sequência explícita e avanço controlado; quando a navegação entre passos depende do estado do próprio fluxo.

**Quando evitar**: quando a alternância entre seções é livre; quando a navegação é global ou hierárquica; quando a página só precisa exibir progresso genérico sem etapas nomeáveis.

**Alternativas próximas**: UIP-NAV-TABS (alternância livre de vistas), UIP-NAV-BREADCRUMB (hierarquia entre níveis).

**Sinais de escolha**:
- existe ordem explícita entre etapas
- a etapa atual precisa ser clara
- etapas concluídas e futuras têm valor de orientação
- o fluxo depende de progressão e validação

**Grau de Rigidez**: Médio — indicação de posição em fluxo sequencial é invariante; formato, estados e retorno variam.

## Composição

**Zonas usuais**: Navegação, Cabeçalho.

**Variantes reconhecidas**: stepper horizontal; stepper vertical; stepper numérico; stepper com sub-etapas; stepper compacto.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-WIZARD.

**Compatibilidade Secundária**: Nenhuma.

**Incompatibilidades explícitas**: todos os Page Patterns que não sejam fluxo sequencial multi-etapas.

## Estrutura e Transição

**Estrutura Desktop**: barra horizontal com etapas numeradas ou nomeadas. Etapa atual destacada. Etapas concluídas marcadas.

**Estrutura Mobile**: versão compacta com contagem ou barra simplificada que preserve a etapa atual e a noção de progresso.

**Regra de Transição**: indicador completo → indicador compacto equivalente. Nunca omitir a etapa atual nem a progressão mínima percebida.

## Estados

**Estados próprios**: etapa atual, etapa concluída, etapa futura, etapa com erro, etapa desativada.

**Reação a estados da página**: `error` → etapa com erro sinalizada. `loading` → etapa em processamento indicada.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: preservar a etapa atual e a conclusão mesmo em modo compacto.

**Adaptação Mobile nativo**: usar versão compacta sem perder a etapa atual e a progressão mínima.

**Adaptação Desktop nativo**: pode integrar com o cabeçalho do fluxo e navegação por teclado entre etapas válidas.
