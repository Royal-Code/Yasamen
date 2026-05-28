# PP-LANDING - Landing

## Definição

**Definição curta**: Página de entrada, campanha, boas-vindas ou narrativa institucional com progressão linear.

**Objetivo estrutural**: Ancorar proposta de valor, orientação inicial ou conversão simples.

**Interação dominante**: Informativa

**Não confundir com**: PP-DETAIL (entidade específica), PP-CATALOG (coleção exploratória).

## Decisão

**Sinais de escolha**:
- hero principal
- narrativa linear
- CTAs claros
- seções editoriais
- intenção de apresentação ou entrada

**Limites**: não usar para operações densas, configuração complexa ou exploração de coleções grandes.

**Grau de Rigidez**: Médio — progressão narrativa e CTAs são estáveis; estrutura interna de seções, blocos e mídia varia por campanha e público.

## Composição

**Zonas funcionais obrigatórias**: Cabeçalho; Conteúdo; Ações.

**UI Patterns tipicamente obrigatórios**: UIP-CONTENT-RICH_TEXT_BLOCK, UIP-STRUCT-GRID_CONTAINER, UIP-CONTENT-MEDIA_VIEWER, UIP-ACTION-ACTION_BAR.

## Compatibilidade com Shell Patterns

**Compatibilidade Primária**: SHP-PORTAL.

**Compatibilidade Secundária**: SHP-MEDIA_CONTENT, SHP-TRANSACTIONAL_COMMERCE, SHP-FOCUSED.

**Incompatibilidades explícitas**: SHP-WORKSPACE_ADMIN, SHP-STUDIO_WORKBENCH como experiência dominante.

## Estrutura e Transição

**Estrutura Desktop**: fluxo por seções com hierarquia visual clara e CTA destacado.

**Estrutura Mobile**: narrativa vertical contínua com CTA acessível.

**Regra de transição**: preservar a sequência narrativa, o destaque do CTA e a leitura confortável.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web.


## Adaptação por Plataforma

**Adaptação Web**: tratar como página linear responsiva.

**Adaptação Mobile nativo**: transformar em onboarding, welcome ou entrada curta; não copiar a estrutura longa de site quando isso prejudicar o fluxo de app.

**Adaptação Desktop nativo**: uso típico é tela de boas-vindas ou entrada do app; manter a progressão linear.
