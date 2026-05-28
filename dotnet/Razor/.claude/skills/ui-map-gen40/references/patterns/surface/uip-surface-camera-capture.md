# UIP-SURFACE-CAMERA_CAPTURE - Camera Capture Surface

## Definição

**Categoria**: Superfície Especializada

**Definição curta**: Superfície de captura por câmera, com preview, permissão, enquadramento e confirmação.

**Objetivo estrutural**: Permitir captura de imagem ou vídeo a partir da câmera do dispositivo, com controle de permissão, preview, orientação e validação do resultado.

**Não confundir com**: UIP-CONTENT-MEDIA_VIEWER (visualizar mídia existente), UIP-SURFACE-SCANNER (leitura estruturada), UIP-INPUT-FILE_UPLOAD (upload de arquivo).

**Nível composicional possível**: Container

## Decisão

**Quando usar**: quando a captura por câmera é parte central da tarefa; quando o usuário precisa fotografar, gravar, confirmar ou recapturar evidência, perfil, documento, produto ou mídia.

**Quando evitar**: quando upload de arquivo resolve; quando a câmera não está disponível ou permitida; quando a captura é apenas opcional e secundária; quando o dado precisa de leitura estruturada automática.

**Alternativas próximas**: UIP-SURFACE-SCANNER (leitura estruturada), UIP-CONTENT-MEDIA_VIEWER (visualização de mídia), UIP-INPUT-FILE_UPLOAD (upload de arquivo).

**Sinais de escolha**:
- permissão de câmera e preview ao vivo
- enquadramento, alternância de câmera, flash
- captura, recaptura e confirmação
- compressão ou upload pós-captura

**Grau de Rigidez**: Alto — captura por câmera com preview e confirmação é invariante; orientação, flash e modo variam.

## Composição

**Zonas usuais**: Superfície.

**Variantes reconhecidas**: foto única; vídeo curto; captura de documento por imagem; captura com máscara ou guia; captura com confirmação; captura contínua.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-FORM, PP-WIZARD.

**Compatibilidade Secundária**: PP-DETAIL, PP-LIST-DETAIL, PP-CATALOG, PP-MAP, PP-CANVAS.

**Incompatibilidades explícitas**: PP-DASHBOARD, PP-LANDING, PP-FEED quando a captura não é tarefa principal.

## Estrutura e Transição

**Estrutura Desktop**: preview de câmera quando o hardware está disponível, seleção de dispositivo, captura, confirmação e fallback para upload.

**Estrutura Mobile**: preview em foco único, permissão, orientação, câmera frontal ou traseira, captura, recaptura e confirmação.

**Regra de Transição**: preservar permissão, preview, captura, revisão e fallback. O fluxo pode usar a UI nativa do sistema quando a plataforma fornecer captura adequada.

## Estados

**Estados próprios**: aguardando permissão, permissão negada, câmera indisponível, preview ativo, capturando, captura realizada, revisando, recapturando, enviando, erro.

**Reação a estados da página**: `loading` → inicializando câmera ou processando mídia. `error` → permissão negada, câmera indisponível ou falha de upload. `empty` → nenhuma captura realizada.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Mobile nativo, Web.


## Adaptação por Plataforma

**Adaptação Web**: validar APIs de câmera, permissão, HTTPS, fallback para upload e comportamento por browser.

**Adaptação Mobile nativo**: considerar permissões, lifecycle, orientação, câmera frontal ou traseira, flash, qualidade, compressão e retry.

**Adaptação Desktop nativo**: oferecer seleção de dispositivo, preview e fallback de arquivo quando a câmera não for confiável.
