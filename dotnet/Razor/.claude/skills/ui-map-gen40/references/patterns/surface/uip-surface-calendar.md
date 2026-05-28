# UIP-SURFACE-CALENDAR - Calendar Surface

## Definição

**Categoria**: Superfície Especializada

**Definição curta**: Superfície temporal para agenda, slots, eventos, disponibilidade e conflitos.

**Objetivo estrutural**: Representar entidades distribuídas no tempo e permitir leitura, seleção, criação, edição ou análise por eixo temporal.

**Não confundir com**: PP-CALENDAR (página completa de calendário), UIP-INPUT-DATE_PICKER (seleção pontual de data), UIP-DATA-TIMELINE_ITEM (eventos em lista cronológica).

**Nível composicional possível**: Container

## Decisão

**Quando usar**: quando tempo, agenda, duração, disponibilidade, recorrência ou conflito são a estrutura principal da zona; quando o usuário precisa operar eventos, reservas, turnos, compromissos ou slots em uma grade temporal.

**Quando evitar**: quando basta escolher uma data; quando eventos podem ser lidos como feed simples; quando o tempo é apenas metadado secundário; quando a plataforma não comporta uma representação temporal compreensível.

**Alternativas próximas**: PP-CALENDAR (página de calendário), UIP-INPUT-DATE_PICKER (seleção de data), UIP-DATA-TIMELINE_ITEM (lista cronológica).

**Sinais de escolha**:
- dia, semana, mês ou agenda são modos centrais
- conflitos e disponibilidade importam
- eventos têm duração
- seleção por intervalo é relevante
- ações de criar, mover ou editar evento dependem de posição temporal

**Grau de Rigidez**: Médio — superfície temporal com eventos e navegação por período é invariante; vistas, criação e drag variam.

## Composição

**Zonas usuais**: Superfície.

**Variantes reconhecidas**: mês; semana; dia; agenda ou lista temporal; grade de disponibilidade; timeline de recursos; calendário de reservas.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-CALENDAR.

**Compatibilidade Secundária**: PP-DASHBOARD, PP-DETAIL, PP-LIST-DETAIL, PP-FORM.

**Incompatibilidades explícitas**: não substitui UIP-INPUT-DATE_PICKER quando a tarefa é apenas selecionar uma data ou intervalo simples.

## Estrutura e Transição

**Estrutura Desktop**: superfície temporal com controles de período, visão ativa, eventos ou slots posicionados, detalhe contextual e ações de criação ou edição.

**Estrutura Mobile**: visão por dia, agenda ou lista temporal com drill-down para detalhe. Grades densas podem ser simplificadas para leitura progressiva.

**Regra de Transição**: preservar eixo temporal, disponibilidade, seleção e conflitos. A densidade visual pode reduzir, sem perder a relação entre evento, duração e período.

## Estados

**Estados próprios**: carregando, vazio, com eventos, evento selecionado, intervalo selecionado, conflito detectado, indisponível, somente leitura, editando, salvando, erro.

**Reação a estados da página**: `loading` → skeleton ou placeholder temporal. `empty` → agenda sem eventos ou sem disponibilidade. `error` → falha de carregamento ou sincronização do período.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir visão principal, navegação temporal, seleção, drag/drop e fallback para viewport pequeno.

**Adaptação Mobile nativo**: priorizar dia ou lista, drill-down, gestos de navegação temporal e integração com permissões e calendários quando aplicável.

**Adaptação Desktop nativo**: pode ativar drag/drop, keyboard flow, múltiplas janelas, impressão ou exportação e ações por atalho.
