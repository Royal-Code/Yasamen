# UIP-INPUT-FORM_FIELD_GROUP - Form Field Group

## Definição

**Categoria**: Entrada

**Definição curta**: Agrupamento lógico de campos relacionados, com validação e feedback coerentes dentro da mesma seção.

**Objetivo estrutural**: Agrupar campos de entrada relacionados em uma seção lógica com validação, feedback e ordem de leitura coerentes.

**Não confundir com**: UIP-INPUT-INPUT_FIELD (campo atômico), UIP-INPUT-FILTER_PANEL (refinamento de coleções), UIP-CONTENT-DETAIL_BLOCK (leitura estruturada), formulário completo de múltiplas seções (fora do catálogo).

**Nível composicional possível**: Container, Leaf

## Decisão

**Quando usar**: quando vários campos pertencem à mesma seção lógica de captura; quando a validação e o feedback precisam ficar associados ao grupo; quando a tela exige organização clara por blocos de formulário; quando a ordem entre campos expressa dependência, prioridade ou fluxo de preenchimento.

**Quando evitar**: quando a intenção é filtrar resultados e não persistir dados; quando a zona é apenas leitura estruturada; quando um único campo isolado resolve a interação; quando cada item da coleção precisa repetir o mesmo conjunto de campos.

**Alternativas próximas**: UIP-INPUT-INPUT_FIELD (campo atômico), UIP-INPUT-REPEATING_GROUP (grupo repetível), UIP-INPUT-FILTER_PANEL (refinamento de coleções), UIP-CONTENT-DETAIL_BLOCK (leitura estruturada).

**Sinais de escolha**:
- campos compartilham o mesmo objetivo de edição
- existe título ou agrupamento de seção
- a validação do grupo é relevante
- a captura acontece por bloco lógico com ordem significativa
- campos podem depender de escolhas anteriores

**Grau de Rigidez**: Médio — agrupamento lógico com validação coerente é estável; número de campos, layout e dependências variam.

## Composição

**Zonas usuais**: Conteúdo.

**Variantes reconhecidas**: seção de formulário simples; grupo de campos compostos; seção com campos dependentes; seção com validação de grupo.

**UI Patterns tipicamente contidos**: UIP-INPUT-INPUT_FIELD, UIP-INPUT-CHOICE_GROUP, UIP-INPUT-OPTION_PICKER, UIP-INPUT-LOOKUP_FIELD, UIP-INPUT-DATE_PICKER, UIP-INPUT-FILE_UPLOAD, UIP-INPUT-VALIDATION_SUMMARY.

**UIPs frequentemente combinados**: UIP-ACTION-ACTION_BAR, UIP-FEEDBACK-LOADING_STATE, UIP-CONTENT-CALLOUT_BLOCK.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-FORM, PP-SETTINGS, PP-WIZARD.

**Compatibilidade Secundária**: PP-DETAIL, PP-LIST-DETAIL.

**Incompatibilidades explícitas**: não substitui UIP-INPUT-FILTER_PANEL em contexto de filtros.

## Estrutura e Transição

**Estrutura Desktop**: seção com título opcional, campos em 1 ou 2 colunas, validação inline abaixo de cada campo.

**Estrutura Mobile**: campos em coluna única. Títulos preservados. Teclado nativo considerado no layout.

**Regra de Transição**: 2 colunas → 1 coluna. Campos em largura completa. Validação inline preservada.

## Estados

**Estados próprios**: vazio, preenchendo, válido, com erro de validação, desativado, somente leitura, submetendo.

**Reação a estados da página**: `error` de submissão → campos com erro destacados. `loading` de submissão → campos desativados.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir colunas, validação, foco, envio e erro por viewport.

**Adaptação Mobile nativo**: considerar teclado virtual, pickers nativos, foco e confirmação ou cancelamento.

**Adaptação Desktop nativo**: garantir keyboard flow, foco entre campos e validação inline.
