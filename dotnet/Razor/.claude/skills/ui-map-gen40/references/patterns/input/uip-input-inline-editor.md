# UIP-INPUT-INLINE_EDITOR - Inline Editor

## Definição

**Categoria**: Entrada

**Definição curta**: Edição localizada no próprio ponto de leitura, sem abrir formulário separado.

**Objetivo estrutural**: Permitir edição de um valor diretamente no local onde é exibido, sem abrir formulário separado.

**Não confundir com**: UIP-INPUT-FORM_FIELD_GROUP (grupo de campos completo), UIP-DATA-DATA_TABLE (edição tabular massiva), UIP-CONTENT-DETAIL_BLOCK (leitura sem edição).

**Nível composicional possível**: Leaf

## Decisão

**Quando usar**: quando a edição é simples e localizada; quando a leitura e a edição precisam coexistir no mesmo ponto; quando abrir formulário separado seria fricção desnecessária.

**Quando evitar**: quando múltiplos campos dependem um do outro; quando a validação é complexa; quando a edição precisa de contexto amplo ou confirmação extensa.

**Alternativas próximas**: UIP-INPUT-FORM_FIELD_GROUP (grupo de campos), UIP-OVERLAY-MODAL (edição em modal), UIP-DATA-DATA_TABLE (edição tabular).

**Sinais de escolha**:
- o valor pode ser alterado isoladamente
- a edição pode acontecer em contexto de leitura
- o usuário se beneficia de mudança rápida
- a confirmação pode ser local e simples

**Grau de Rigidez**: Baixo — edição no ponto de leitura é estável; tipo de campo, confirmação e cancelamento variam.

## Composição

**Zonas usuais**: Detalhe, Coleção, Conteúdo.

**Variantes reconhecidas**: edição de campo único; edição de bloco curto; edição com confirmar e cancelar; edição com auto-save; edição em célula.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-DETAIL, PP-LIST-DETAIL.

**Compatibilidade Secundária**: PP-SETTINGS.

**Incompatibilidades explícitas**: edição de múltiplos campos relacionados (usar UIP-INPUT-FORM_FIELD_GROUP).

## Estrutura e Transição

**Estrutura Desktop**: campo ativado por clique ou duplo clique. Confirmação por Enter ou blur. Cancelamento por Escape.

**Estrutura Mobile**: ativação por toque. Campo com botões de confirmar e cancelar explícitos.

**Regra de Transição**: ativação implícita → botões explícitos em Mobile.

## Estados

**Estados próprios**: exibindo valor, em edição, salvando, salvo, com erro de validação.

**Reação a estados da página**: `loading` → campo desativado com indicador ao salvar. `error` → erro de validação no próprio campo.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir foco, commit, cancelamento, validação e feedback.

**Adaptação Mobile nativo**: exigir botões explícitos ou fluxo claro para confirmar e cancelar.

**Adaptação Desktop nativo**: pode usar teclado, foco e edição em tabela quando seguro.
