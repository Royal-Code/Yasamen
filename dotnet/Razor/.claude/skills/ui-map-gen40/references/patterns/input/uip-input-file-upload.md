# UIP-INPUT-FILE_UPLOAD - File Upload

## Definição

**Categoria**: Entrada

**Definição curta**: Entrada de arquivo, anexo, mídia ou documento com seleção, validação, progresso e remoção.

**Objetivo estrutural**: Capturar arquivos ou mídia como parte de formulário, mensagem, tarefa ou evidência operacional.

**Não confundir com**: UIP-SURFACE-CAMERA_CAPTURE (captura por câmera como superfície principal), UIP-SURFACE-SCANNER (leitura estruturada), UIP-CONTENT-MEDIA_VIEWER (visualização de arquivo existente).

**Nível composicional possível**: Leaf, Container

## Decisão

**Quando usar**: quando a entrada exige anexar arquivo, imagem, vídeo, documento ou mídia; quando há restrições de tipo, tamanho, quantidade, preview, progresso de upload, remoção ou retry.

**Quando evitar**: quando a tarefa é apenas visualizar arquivo; quando a captura por câmera ou scanner é a superfície central; quando o arquivo é selecionado fora do formulário por integração do host.

**Alternativas próximas**: UIP-SURFACE-CAMERA_CAPTURE (captura por câmera), UIP-SURFACE-SCANNER (leitura estruturada), UIP-CONTENT-MEDIA_VIEWER (visualização de arquivo), UIP-INPUT-INPUT_FIELD (entrada de URL).

**Sinais de escolha**:
- botão selecionar arquivo ou drag/drop
- anexo em lista, preview, progresso
- validação de extensão ou tamanho
- múltiplos arquivos, remover ou substituir
- upload em background

**Grau de Rigidez**: Médio — entrada de arquivo com validação e progresso é estável; tipos aceitos, preview e múltiplos variam.

## Composição

**Zonas usuais**: Conteúdo.

**Variantes reconhecidas**: upload único; múltiplos anexos; drag/drop upload; image upload com preview; document upload; upload com progresso; upload com captura alternativa.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-FORM, PP-WIZARD, PP-CONVERSATION.

**Compatibilidade Secundária**: PP-DETAIL, PP-LIST-DETAIL, PP-CATALOG, PP-CANVAS.

**Incompatibilidades explícitas**: não usar como viewer de mídia ou documento após o upload.

## Estrutura e Transição

**Estrutura Desktop**: botão de seleção, drop zone opcional, lista de arquivos, preview quando útil, validações, progresso e ações de remover ou substituir.

**Estrutura Mobile**: seleção por file picker, câmera, galeria ou sheet de origem. Progresso e remoção próximos ao anexo.

**Regra de Transição**: preservar restrições, feedback de upload, preview necessário e ação de remover. Drag/drop desktop deve ter fallback por picker.

## Estados

**Estados próprios**: vazio, selecionando, arquivo selecionado, validando, inválido, enviando, progresso, enviado, falha, retry, removido, formato não suportado.

**Reação a estados da página**: `loading` na submissão → bloquear remoção ou permitir cancelamento conforme regra. `error` → erro por arquivo ou upload. A operação pode continuar em background via UIP-SYSTEM-BACKGROUND_PROGRESS.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir picker, drag/drop, preview, validação, progresso, retry e integração com UIP-SYSTEM-BACKGROUND_PROGRESS.

**Adaptação Mobile nativo**: considerar permissões, origem da mídia, câmera ou galeria, compressão e upload em background.

**Adaptação Desktop nativo**: pode integrar file picker, drag/drop, filesystem e preview local.
