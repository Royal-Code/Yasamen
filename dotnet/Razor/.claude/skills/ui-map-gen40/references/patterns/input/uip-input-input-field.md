# UIP-INPUT-INPUT_FIELD - Input Field

## Definição

**Categoria**: Entrada

**Definição curta**: Campo atômico para captura ou edição de um valor único, com anatomia de label, controle, ajuda, validação e complementos.

**Objetivo estrutural**: Definir a unidade mínima de entrada de dados antes do mapeamento para componente real da biblioteca.

**Não confundir com**: UIP-INPUT-FORM_FIELD_GROUP (agrupamento de vários campos), UIP-INPUT-OPTION_PICKER (escolha de opções), UIP-INPUT-LOOKUP_FIELD (seleção de entidade), UIP-INPUT-INLINE_EDITOR (edição no ponto de leitura).

**Nível composicional possível**: Leaf

## Decisão

**Quando usar**: quando a tela precisa capturar um valor escalar, textual, numérico, booleano simples ou outro dado unitário; quando é preciso decidir label, placeholder, ajuda, validação, estado, adornments ou ação acoplada ao campo.

**Quando evitar**: quando a entrada é uma coleção repetível; quando a escolha envolve muitas opções ou busca remota; quando a entrada é arquivo, mídia ou captura por hardware; quando a edição acontece diretamente sobre conteúdo já exibido.

**Alternativas próximas**: UIP-INPUT-OPTION_PICKER (escolha entre opções conhecidas), UIP-INPUT-CHOICE_GROUP (escolhas visíveis), UIP-INPUT-LOOKUP_FIELD (seleção de entidade), UIP-INPUT-FILE_UPLOAD (entrada de arquivo), UIP-INPUT-INLINE_EDITOR (edição no ponto de leitura).

**Sinais de escolha**:
- existe uma propriedade de modelo com valor único
- o campo precisa de rótulo e validação própria
- há placeholder, informação auxiliar, erro, ícone, prefixo, sufixo ou ação local
- o componente real ainda será decidido pelo `ui-map`

**Grau de Rigidez**: Médio — label, controle, validação e ajuda são invariantes; tipo de controle e complementos variam por dado.

## Composição

**Zonas usuais**: Conteúdo, Filtros.

**Variantes reconhecidas**: texto; senha; número; email; telefone; URL; textarea curta; campo com máscara; campo com prefixo ou sufixo; campo com ação local; campo somente leitura.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-FORM, PP-WIZARD, PP-SETTINGS.

**Compatibilidade Secundária**: PP-DETAIL, PP-CATALOG, PP-LIST-DETAIL.

**Incompatibilidades explícitas**: não substitui lookup, upload, choice group ou date picker quando a semântica da entrada for especializada.

## Estrutura e Transição

**Estrutura Desktop**: label, controle, placeholder opcional, ajuda ou descrição, erro inline e complementos como prepend, append, badge, ícone ou ação local quando agregarem decisão.

**Estrutura Mobile**: controle em largura confortável, teclado adequado ao tipo, erro próximo ao campo e ações explícitas quando o campo tiver efeito local.

**Regra de Transição**: preservar label, valor, erro e ajuda essencial. Complementos visuais ou ações secundárias podem virar texto, botão explícito, menu ou área abaixo do campo.

## Estados

**Estados próprios**: vazio, preenchido, focado, válido, inválido, obrigatório ausente, readonly, disabled, carregando, com ajuda, com ação local.

**Reação a estados da página**: `loading` na submissão → campo desativado ou readonly temporário. `error` de validação → erro inline e possível Validation Summary. `no-permission` → readonly, disabled ou oculto conforme regra.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: mapear tipo, autocomplete, máscara, validação, adornments, ações locais e componente real via `ui-map`.

**Adaptação Mobile nativo**: escolher teclado, autocorreção, máscara, picker nativo quando aplicável e ações de confirmar ou cancelar quando necessário.

**Adaptação Desktop nativo**: considerar keyboard flow, access keys, validação inline e ações acopladas ao campo.
