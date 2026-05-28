# UIP-SURFACE-SCANNER - Scanner Surface

## Definição

**Categoria**: Superfície Especializada

**Definição curta**: Superfície de captura ou leitura estruturada de código, documento, imagem ou dado físico.

**Objetivo estrutural**: Ler, detectar ou extrair informação estruturada a partir de câmera, scanner, sensor ou arquivo, com validação e retorno operacional.

**Não confundir com**: UIP-SURFACE-CAMERA_CAPTURE (captura livre), UIP-CONTENT-MEDIA_VIEWER (visualização de mídia), entrada manual de dados (fora do catálogo).

**Nível composicional possível**: Container

## Decisão

**Quando usar**: quando a tarefa depende de leitura automática de QR code, barcode, documento, OCR, cartão, etiqueta, asset tag ou imagem estruturada; quando validação, retry e fallback manual são necessários.

**Quando evitar**: quando uma foto livre basta; quando o usuário pode inserir o dado manualmente sem custo relevante; quando o ambiente físico torna a leitura pouco confiável; quando não há permissão ou sensor adequado.

**Alternativas próximas**: UIP-SURFACE-CAMERA_CAPTURE (captura livre), UIP-INPUT-FORM_FIELD_GROUP (entrada manual), UIP-INPUT-FILE_UPLOAD (upload de arquivo).

**Sinais de escolha**:
- alvo reconhecível e área de escaneamento
- feedback de detecção e validação automática
- fallback manual
- integração com hardware ou câmera
- resultado estruturado

**Grau de Rigidez**: Alto — captura de código ou documento é invariante; tipo de scan, feedback e fallback variam.

## Composição

**Zonas usuais**: Superfície.

**Variantes reconhecidas**: QR ou barcode scanner; OCR de documento; scanner de cartão; scanner por arquivo; captura com guia; scanner contínuo; scanner com fallback manual.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-FORM, PP-WIZARD.

**Compatibilidade Secundária**: PP-LIST-DETAIL, PP-DETAIL, PP-MAP, PP-CATALOG.

**Incompatibilidades explícitas**: PP-DASHBOARD, PP-LANDING, PP-FEED quando a leitura estruturada não é tarefa central.

## Estrutura e Transição

**Estrutura Desktop**: entrada por scanner físico, câmera ou upload. Exibe resultado, validação, retry e fallback manual.

**Estrutura Mobile**: scanner em foco único com guia de enquadramento, permissão, detecção, confirmação e fallback manual.

**Regra de Transição**: preservar detecção, validação, confirmação e fallback. O método de captura pode variar entre câmera, sensor, arquivo, scanner físico ou input manual.

## Estados

**Estados próprios**: aguardando permissão, sensor indisponível, pronto para leitura, detectando, leitura bem-sucedida, leitura inválida, múltiplos resultados, validando, fallback manual, erro.

**Reação a estados da página**: `loading` → inicializando sensor ou validando resultado. `error` → falha de permissão, leitura ou validação. `empty` → nenhum resultado lido.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Mobile nativo.


## Adaptação por Plataforma

**Adaptação Web**: validar APIs de câmera, permissões, HTTPS, fallback manual e compatibilidade de browser.

**Adaptação Mobile nativo**: considerar permissões, lifecycle, foco, iluminação, orientação, feedback e leitura contínua.

**Adaptação Desktop nativo**: integrar scanner físico quando disponível e oferecer fallback por arquivo, câmera ou entrada manual.
