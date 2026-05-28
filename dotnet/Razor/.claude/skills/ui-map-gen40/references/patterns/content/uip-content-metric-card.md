# UIP-CONTENT-METRIC_CARD - Metric Card

## Definição

**Categoria**: Conteúdo

**Definição curta**: Card de síntese para exibir um indicador ou KPI de leitura imediata.

**Objetivo estrutural**: Apresentar um indicador, KPI, contagem ou métrica de forma destacada e rapidamente comparável.

**Não confundir com**: UIP-CONTENT-CONTENT_HEADER (identidade e contexto inicial), UIP-CONTENT-DETAIL_BLOCK (atributos detalhados), UIP-CONTENT-COMPARISON_BLOCK (leitura comparativa), UIP-SURFACE-CHART (visualização analítica principal), card de catálogo (fora do catálogo).

**Nível composicional possível**: Leaf

## Decisão

**Quando usar**: quando a informação principal pode ser resumida em um indicador; quando a tela precisa de leitura rápida de status ou performance; quando valor, variação, período ou meta importam mais que a narrativa detalhada.

**Quando evitar**: quando a zona precisa mostrar múltiplos atributos estruturados; quando o conteúdo depende de explicação longa ou editorial; quando a métrica não é prioritária o bastante para destaque; quando a análise depende de gráfico interativo ou drill-down central.

**Alternativas próximas**: UIP-CONTENT-CONTENT_HEADER (cabeçalho de identidade), UIP-CONTENT-DETAIL_BLOCK (atributos detalhados), UIP-CONTENT-COMPARISON_BLOCK (leitura comparativa), UIP-SURFACE-CHART (visualização analítica).

**Sinais de escolha**:
- existe um valor principal dominante
- comparação rápida importa
- variação, período, meta ou tendência agregam contexto
- a leitura deve ser quase imediata

**Grau de Rigidez**: Médio — KPI com leitura imediata é invariante; formato do número, comparação e trend variam.

## Composição

**Zonas usuais**: Conteúdo, Cabeçalho.

**Variantes reconhecidas**: KPI simples; KPI com variação; KPI com meta; KPI com sparkline; status metric; contador operacional.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-DASHBOARD.

**Compatibilidade Secundária**: PP-DETAIL, PP-LIST-DETAIL, PP-BOARD, PP-CATALOG.

**Incompatibilidades explícitas**: PP-FORM, PP-WIZARD, PP-CONVERSATION (foco em captura, progressão ou troca conversacional).

## Estrutura e Transição

**Estrutura Desktop**: card com valor principal, rótulo, variação, período de referência, meta ou sparkline opcional. Pode formar linha ou grade de KPIs.

**Estrutura Mobile**: card compacto com valor e rótulo. Variação preservada quando for decisiva. Sparkline e metadados secundários podem ser omitidos.

**Regra de Transição**: card preservado com simplificação de elementos secundários. Valor, rótulo e significado da variação não podem ficar ambíguos.

## Estados

**Estados próprios**: com dados, carregando, sem dados, variação positiva, variação negativa, variação neutra, meta atingida, meta não atingida, erro.

**Reação a estados da página**: `loading` → skeleton do card. `error` → indicador de erro no card. `empty` → sem dados, valor ausente ou placeholder explícito.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir densidade, grade responsiva, drill-down e relação com UIP-SURFACE-CHART.

**Adaptação Mobile nativo**: limitar quantidade por tela, priorizar leitura em lista ou grade simples e preservar a métrica principal.

**Adaptação Desktop nativo**: pode compor dashboards densos com filtros, charts e painéis de detalhe.
