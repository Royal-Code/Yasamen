# UIP-CONTENT-MEDIA_COLLECTION - Media Collection

## Definição

**Categoria**: Conteúdo

**Definição curta**: Coleção de mídias, anexos ou arquivos relacionados a uma entidade, conteúdo ou tarefa.

**Objetivo estrutural**: Organizar múltiplos arquivos, imagens, vídeos, documentos, evidências ou anexos como parte do conteúdo principal, permitindo leitura, seleção, preview, remoção, download ou abertura em viewer apropriado.

**Não confundir com**: UIP-CONTENT-MEDIA_VIEWER (mídia única em foco), UIP-DATA-CARD_GRID (coleção de entidades), UIP-INPUT-FILE_UPLOAD (captura ou envio), UIP-SURFACE-DOCUMENT_VIEWER (documento paginado como superfície principal).

**Nível composicional possível**: Container

## Decisão

**Quando usar**: quando uma entidade ou conteúdo possui múltiplos anexos, evidências, imagens, documentos ou mídias relacionadas; quando o usuário precisa reconhecer, selecionar, abrir, remover, baixar ou comparar arquivos associados.

**Quando evitar**: quando há apenas uma mídia principal; quando a coleção representa entidades de negócio independentes; quando a tarefa principal é somente enviar arquivo; quando o foco é leitura profunda de um documento único.

**Alternativas próximas**: UIP-CONTENT-MEDIA_VIEWER (mídia única), UIP-DATA-CARD_GRID (coleção de entidades), UIP-DATA-LIST_ITEM (listagem linear), UIP-INPUT-FILE_UPLOAD (envio de arquivo), UIP-SURFACE-DOCUMENT_VIEWER (documento paginado).

**Sinais de escolha**:
- existem vários arquivos vinculados ao mesmo contexto
- thumbnails, nomes, tipos, tamanhos, status ou ações por arquivo importam
- a coleção depende da entidade atual e não de navegação independente

**Grau de Rigidez**: Médio — coleção de mídias ou anexos é estável; layout, preview e ações por item variam.

## Composição

**Zonas usuais**: Conteúdo, Detalhe.

**Variantes reconhecidas**: galeria de imagens; lista de anexos; grade de arquivos; evidências de vistoria; documentos relacionados; coleção com upload; coleção com seleção múltipla.

**UI Patterns tipicamente contidos**: UIP-CONTENT-MEDIA_VIEWER, UIP-INPUT-FILE_UPLOAD, UIP-DATA-LIST_ITEM, UIP-DATA-CARD_GRID, UIP-INTERACTION-SELECTION.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-DETAIL, PP-LIST-DETAIL, PP-FORM.

**Compatibilidade Secundária**: PP-CATALOG, PP-FEED, PP-WIZARD, PP-BOARD, PP-CONVERSATION.

**Incompatibilidades explícitas**: PP-DASHBOARD (anexos fora da decisão operacional).

## Estrutura e Transição

**Estrutura Desktop**: grade, lista ou strip com previews, metadados curtos e ações por item. Pode abrir UIP-CONTENT-MEDIA_VIEWER ou UIP-SURFACE-DOCUMENT_VIEWER para visualização detalhada.

**Estrutura Mobile**: lista compacta, carrossel ou grade simples com preview e ações contextuais. Visualização detalhada tende a ocupar tela inteira.

**Regra de Transição**: a relação entre item, preview, metadados e ações é preservada. A coleção pode mudar de grade para lista ou carrossel; seleção e abertura de item continuam claras.

## Estados

**Estados próprios**: vazio, carregando, com itens, upload em progresso, processamento, item indisponível, erro de item, seleção ativa, limite atingido, permissão restrita.

**Reação a estados da página**: `loading` → skeleton de itens. `error` → erro no escopo da coleção ou por item. `empty` → ausência de anexos ou mídia relacionada.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir grade ou lista, drag/drop, preview, download, seleção múltipla e integração com upload.

**Adaptação Mobile nativo**: priorizar preview tocável, fullscreen para mídia e integração com câmera, galeria e permissões.

**Adaptação Desktop nativo**: pode integrar com arquivos locais, drag/drop entre janelas, preview lateral e ações de lote.
