# SHP-MEDIA_CONTENT - Media/Content

## Definição

**Definição curta**: Shell para descoberta, consumo e navegação de conteúdo, catálogo ou mídia.

**Objetivo estrutural**: Sustentar exploração, comparação leve, consumo recorrente e continuidade de descoberta.

**Interação dominante**: Exploratória

**Não confundir com**: SHP-PORTAL (conteúdo institucional), SHP-DASHBOARD_ANALYTICS (monitoramento de métricas), SHP-TRANSACTIONAL_COMMERCE (conversão e transação).

## Decisão

**Sinais de escolha**:
- catálogo, feed, coleções ou descoberta como atividade principal
- recomendação de conteúdo
- consumo de mídia recorrente

**Limites**: não é o shell adequado para operações densas, workflows transacionais complexos ou edição técnica de artefatos.

**Grau de Rigidez**: Médio — descoberta e navegação de conteúdo são estáveis; organização interna varia por tipo de mídia e modelo de consumo.

## Navegação e Estrutura

**Modelo de navegação global**: navegação superior ou lateral leve, busca proeminente e acesso rápido a coleções e recomendações.

**Estrutura Desktop**: navegação leve com áreas de descoberta, destaques e conteúdo principal.

**Estrutura Mobile**: foco em scroll, descoberta contínua e navegação compacta.

**Regra de transição**: preservar descoberta e continuidade de consumo com simplificação da navegação periférica.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-CATALOG, PP-FEED, PP-DETAIL, PP-LANDING.

**Compatibilidade Secundária**: PP-MAP, PP-CALENDAR.

**Incompatibilidades explícitas**: PP-LIST-DETAIL operacional como padrão dominante.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir entre grid, feed, busca, filtros e scroll contínuo conforme o page pattern dominante.

**Adaptação Mobile nativo**: priorizar stack, tab bar e scroll; ativar UIP-SYSTEM-OFFLINE_SYNC quando o conteúdo puder ficar local.

**Adaptação Desktop nativo**: pode ativar integração com arquivos, atalhos e janelas quando o consumo for biblioteca ou ferramenta de mídia.
