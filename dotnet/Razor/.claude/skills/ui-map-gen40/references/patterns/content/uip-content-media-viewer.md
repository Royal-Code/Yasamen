# UIP-CONTENT-MEDIA_VIEWER - Media Viewer

## Definição

**Categoria**: Conteúdo

**Definição curta**: Área de visualização de mídia ou arquivo com controles adequados ao tipo de conteúdo exibido.

**Objetivo estrutural**: Apresentar e controlar conteúdo multimídia, imagem, vídeo, áudio, documento ou arquivo quando esse conteúdo é parte funcional da tarefa.

**Não confundir com**: UIP-CONTENT-MEDIA_COLLECTION (múltiplos anexos ou mídias), UIP-CONTENT-RICH_TEXT_BLOCK (conteúdo editorial), UIP-DATA-CARD_GRID (coleção de itens), UIP-SURFACE-DOCUMENT_VIEWER (documento paginado como superfície principal).

**Nível composicional possível**: Leaf, Container

## Decisão

**Quando usar**: quando a mídia ou arquivo é conteúdo principal da zona; quando o usuário precisa visualizar, navegar, reproduzir, ampliar ou controlar o conteúdo exibido; quando o tipo de mídia exige comportamento específico de visualização.

**Quando evitar**: quando a mídia é apoio visual secundário de um card ou texto; quando a zona precisa apenas de miniatura decorativa; quando existem múltiplas mídias que precisam de coleção; quando o conteúdo é melhor representado como texto estruturado; quando a superfície central exige mapa, canvas, documento paginado, câmera ou scanner.

**Alternativas próximas**: UIP-CONTENT-MEDIA_COLLECTION (coleção de mídias), UIP-CONTENT-RICH_TEXT_BLOCK (conteúdo editorial), UIP-DATA-CARD_GRID (grade de itens), UIP-SURFACE-DOCUMENT_VIEWER (documento paginado).

**Sinais de escolha**:
- o conteúdo principal é imagem, vídeo, áudio, documento ou arquivo
- existem controles ou gestos relevantes de visualização
- o usuário pode precisar ampliar, reproduzir, pausar, navegar ou alternar mídias
- a mídia ocupa papel funcional na tarefa

**Grau de Rigidez**: Médio — área de visualização com controles é invariante; tipo de mídia e controles específicos variam.

## Composição

**Zonas usuais**: Conteúdo, Detalhe.

**Variantes reconhecidas**: image viewer; video player; audio player; preview de documento ou arquivo; gallery viewer; preview de captura.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-DETAIL.

**Compatibilidade Secundária**: PP-FEED, PP-CATALOG, PP-LIST-DETAIL, PP-LANDING, PP-CANVAS.

**Incompatibilidades explícitas**: PP-DASHBOARD, PP-FORM (mídia que não é conteúdo funcional nem evidência necessária).

## Estrutura e Transição

**Estrutura Desktop**: área de visualização com controles adequados ao tipo de mídia. Pode incluir navegação secundária, thumbnails, fullscreen, download, zoom ou reprodução.

**Estrutura Mobile**: visualização em largura total ou foco único. Gestos e controles simplificados podem assumir papel principal conforme o tipo de mídia.

**Regra de Transição**: acesso ao conteúdo e aos controles essenciais é preservado. Layout, gestos, fullscreen e posição da navegação auxiliar variam conforme mídia, plataforma e modalidade de entrada.

## Estados

**Estados próprios**: carregando, disponível, pausado, reproduzindo, erro de carregamento, formato não suportado, sem permissão, em fullscreen, zoom ativo.

**Reação a estados da página**: `loading` → skeleton ou placeholder. `error` → arquivo indisponível, formato não suportado ou permissão ausente. `empty` → ausência de mídia.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir controles, fullscreen, download, thumbnails, acessibilidade e fallback por formato.

**Adaptação Mobile nativo**: priorizar gestos, fullscreen, permissões de mídia, offline ou cache e controles compatíveis com touch.

**Adaptação Desktop nativo**: pode integrar com arquivos locais, drag/drop, viewers nativos, múltiplas janelas ou painéis de preview.
