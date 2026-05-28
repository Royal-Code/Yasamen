# UIP-NAV-PAGINATION - Pagination

## Definição

**Categoria**: Navegação

**Definição curta**: Navegação sequencial entre páginas discretas de uma coleção volumosa.

**Objetivo estrutural**: Navegar entre páginas de um conjunto de resultados volumoso.

**Não confundir com**: UIP-NAV-STEPPER_INDICATOR (fluxo sequencial de etapas), UIP-NAV-TABS (vistas locais), scroll infinito (fora do catálogo).

**Nível composicional possível**: Leaf

## Decisão

**Quando usar**: quando a coleção é grande e segmentada em páginas discretas; quando controle explícito de página, total e avanço faz sentido; quando performance ou previsibilidade favorecem paginação em vez de rolagem contínua.

**Quando evitar**: quando a experiência é naturalmente contínua ou cronológica; quando o volume é pequeno o suficiente para uma única lista; quando a navegação por etapas representa fluxo e não resultados.

**Alternativas próximas**: UIP-NAV-STEPPER_INDICATOR (progressão por etapas de fluxo).

**Sinais de escolha**:
- há total ou subconjuntos discretos de resultados
- o usuário precisa voltar a páginas específicas
- anterior, próxima e página atual são conceitos relevantes
- a coleção não é consumida melhor por feed contínuo

**Grau de Rigidez**: Alto — navegação sequencial entre páginas discretas é invariante; formato e posição variam.

## Composição

**Zonas usuais**: Coleção, Rodapé.

**Variantes reconhecidas**: paginação numerada; paginação simplificada anterior e próxima; load-more; paginação com salto para página.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-LIST-DETAIL, PP-CATALOG.

**Compatibilidade Secundária**: PP-DASHBOARD.

**Incompatibilidades explícitas**: PP-FEED, PP-CONVERSATION.

## Estrutura e Transição

**Estrutura Desktop**: barra horizontal com botões anterior, próxima, primeira, última e páginas numeradas. Indicador de página atual e total.

**Estrutura Mobile**: simplificado; botões anterior e próxima com indicador de página atual.

**Regra de Transição**: paginação completa → paginação simplificada. Páginas numeradas omitidas em Mobile.

## Estados

**Estados próprios**: página atual, anterior disponível, próxima disponível, primeira página, última página, carregando.

**Reação a estados da página**: `loading` → botões desativados durante o carregamento.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir paginação completa, simplificada ou load-more.

**Adaptação Mobile nativo**: preferir anterior e próxima ou carregamento progressivo quando paginação numerada for pesada.

**Adaptação Desktop nativo**: pode coexistir com data table, filtros e keyboard flow.
