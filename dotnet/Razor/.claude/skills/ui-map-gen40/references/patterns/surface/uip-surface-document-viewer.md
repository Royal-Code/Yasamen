# UIP-SURFACE-DOCUMENT_VIEWER - Document Viewer Surface

## Definição

**Categoria**: Superfície Especializada

**Definição curta**: Superfície especializada de documento paginado, PDF, preview, navegação, busca e anotação.

**Objetivo estrutural**: Permitir leitura, navegação e operação sobre documentos com estrutura própria de páginas, seções, zoom, busca, marcações ou anexos.

**Não confundir com**: UIP-CONTENT-RICH_TEXT_BLOCK (texto editorial fluido), UIP-CONTENT-MEDIA_VIEWER (preview simples de mídia), leitor de imagem isolada (fora do catálogo).

**Nível composicional possível**: Container

## Decisão

**Quando usar**: quando o documento é a superfície principal da tarefa; quando página, zoom, busca no documento, thumbnails, assinatura, anotação, download, impressão ou navegação por páginas são necessários.

**Quando evitar**: quando o conteúdo é texto reflowável simples; quando o arquivo é apenas anexo secundário; quando um link ou download resolve; quando a plataforma não suporta leitura útil do formato.

**Alternativas próximas**: UIP-CONTENT-RICH_TEXT_BLOCK (texto editorial), UIP-CONTENT-MEDIA_VIEWER (preview de mídia).

**Sinais de escolha**:
- PDF ou documento paginado com múltiplas páginas
- zoom, thumbnails, busca interna
- anotação, assinatura, revisão documental
- comparação entre páginas

**Grau de Rigidez**: Médio — superfície de documento paginado é invariante; anotação, busca e navegação variam.

## Composição

**Zonas usuais**: Superfície.

**Variantes reconhecidas**: viewer PDF; viewer de documento paginado; preview de contrato; documento com anotações; documento para assinatura; comparação de versões.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-DETAIL.

**Compatibilidade Secundária**: PP-LIST-DETAIL, PP-FORM, PP-WIZARD, PP-CANVAS.

**Incompatibilidades explícitas**: PP-DASHBOARD, PP-FEED, PP-LANDING quando o documento não é conteúdo funcional principal.

## Estrutura e Transição

**Estrutura Desktop**: documento central com navegação de páginas, zoom, busca, thumbnails, ações de download ou impressão e painel de metadados ou anotações quando necessário.

**Estrutura Mobile**: leitura em foco único com controles compactos, busca e ações essenciais acessíveis por menu ou barra contextual.

**Regra de Transição**: preservar acesso ao documento, página atual, navegação, zoom e ações críticas. Painéis auxiliares podem virar overlays ou telas progressivas.

## Estados

**Estados próprios**: carregando, documento disponível, página carregando, erro de página, formato não suportado, protegido ou sem permissão, busca ativa, anotando, assinando, fullscreen.

**Reação a estados da página**: `loading` → placeholder de documento ou página. `error` → arquivo indisponível, formato inválido ou permissão ausente. `empty` → nenhum documento disponível.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir renderização por página, busca, thumbnails, download, impressão, anotações e fallback por formato.

**Adaptação Mobile nativo**: priorizar leitura de página, gestos de zoom, ações essenciais e retomada de posição.

**Adaptação Desktop nativo**: pode integrar com arquivos locais, impressão, assinatura, múltiplas janelas e viewers nativos.
