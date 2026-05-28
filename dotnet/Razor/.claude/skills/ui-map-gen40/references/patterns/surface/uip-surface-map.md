# UIP-SURFACE-MAP - Map Surface

## Definição

**Categoria**: Superfície Especializada

**Definição curta**: Superfície espacial para viewport cartográfico, marcadores, camadas, rotas e seleção geográfica.

**Objetivo estrutural**: Representar entidades, ações e decisões cuja localização, proximidade, área, rota ou distribuição espacial é estruturalmente relevante.

**Não confundir com**: PP-MAP (página completa de mapa), UIP-DATA-CARD_GRID (lista visual de locais), UIP-CONTENT-MEDIA_VIEWER (visualização de mídia), imagem estática (fora do catálogo).

**Nível composicional possível**: Container

## Decisão

**Quando usar**: quando a localização é decisiva para a tarefa; quando o usuário precisa explorar pontos, áreas, rotas, camadas ou proximidade; quando seleção e detalhe dependem do contexto geográfico.

**Quando evitar**: quando a localização é apenas atributo textual; quando uma lista de endereços resolve melhor; quando a plataforma não permite interação espacial segura ou útil; quando o mapa seria apenas ilustração.

**Alternativas próximas**: PP-MAP (página de mapa), UIP-DATA-LIST_ITEM (lista de locais), UIP-CONTENT-DETAIL_BLOCK (endereço estruturado).

**Sinais de escolha**:
- pontos, áreas, rotas ou camadas importam
- a proximidade altera a decisão
- zoom, pan e seleção são necessários
- o detalhe contextual depende de marcador ou região selecionada

**Grau de Rigidez**: Médio — viewport cartográfico com marcadores é invariante; camadas, filtros, rotas e interação variam.

## Composição

**Zonas usuais**: Superfície.

**Variantes reconhecidas**: mapa de pontos; mapa com rotas; mapa com polígonos ou áreas; mapa com camadas; seleção de localização; geofencing; mapa offline.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-MAP.

**Compatibilidade Secundária**: PP-DASHBOARD, PP-DETAIL, PP-CATALOG, PP-LIST-DETAIL, PP-FORM.

**Incompatibilidades explícitas**: não substitui lista ou detail block quando a espacialidade não altera a decisão.

## Estrutura e Transição

**Estrutura Desktop**: viewport espacial dominante com controles, camadas, legenda, filtros, seleção e painel contextual.

**Estrutura Mobile**: mapa de foco único com painéis sobrepostos ou alternáveis para filtros, legenda e detalhe.

**Regra de Transição**: preservar contexto espacial, seleção, camadas essenciais e leitura do detalhe. Painéis simultâneos podem virar overlays ou navegação progressiva.

## Estados

**Estados próprios**: carregando tiles ou dados, mapa disponível, localização solicitada, permissão negada, localização indisponível, marcador selecionado, camada ativa, rota calculada, offline, erro.

**Reação a estados da página**: `loading` → loading de tiles e dados. `empty` → sem entidades no recorte ou filtro. `error` → falha de mapa, geocoding, rota ou permissão.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir overlays, filtros, busca, detalhe, zoom, camadas e fallback para viewport pequeno.

**Adaptação Mobile nativo**: considerar permissão de localização, ciclo de vida, offline ou cache, gestos e painéis sobrepostos.

**Adaptação Desktop nativo**: pode ativar atalhos, múltiplas janelas, import/export de dados espaciais e integração com arquivos.
