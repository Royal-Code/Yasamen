# UIP-INPUT-VALIDATION_SUMMARY - Validation Summary

## Definição

**Categoria**: Entrada

**Definição curta**: Resumo de erros, avisos ou pendências de validação de formulário, seção ou fluxo.

**Objetivo estrutural**: Agregar problemas de validação para orientar correção sem depender apenas de mensagens inline por campo.

**Não confundir com**: UIP-FEEDBACK-ERROR_STATE (falha técnica), UIP-FEEDBACK-TOAST_ALERT (evento), erro inline de campo isolado (fora do catálogo).

**Nível composicional possível**: Leaf, Container

## Decisão

**Quando usar**: quando há múltiplos campos; quando erros podem ficar fora da viewport; quando a submissão precisa listar pendências; quando wizard ou repeating group exige navegação até campos inválidos.

**Quando evitar**: quando existe apenas um campo e erro inline é suficiente; quando o problema é falha técnica; quando a mensagem é informativa e não exige correção de entrada.

**Alternativas próximas**: UIP-INPUT-INPUT_FIELD (erro inline de campo), UIP-FEEDBACK-ERROR_STATE (falha técnica), UIP-FEEDBACK-TOAST_ALERT (evento não bloqueante).

**Sinais de escolha**:
- submissão falhou por validação
- erros em várias seções
- link para campo inválido
- contagem de pendências
- grupos repetíveis ou validação assíncrona ou cruzada

**Grau de Rigidez**: Médio — resumo de erros e pendências é invariante; posição, agrupamento e severidade variam.

## Composição

**Zonas usuais**: Conteúdo, Cabeçalho.

**Variantes reconhecidas**: resumo global; resumo por seção; lista de erros com âncoras; banner de validação; contador de pendências; resumo de wizard.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-FORM, PP-WIZARD.

**Compatibilidade Secundária**: PP-SETTINGS, PP-DETAIL, PP-LIST-DETAIL.

**Incompatibilidades explícitas**: não usar para falhas técnicas ou ausência de dados sem relação com validação.

## Estrutura e Transição

**Estrutura Desktop**: bloco de resumo próximo ao início ou ao ponto de submissão, com mensagens e links ou foco para campos ou seções inválidas.

**Estrutura Mobile**: resumo aparece antes da área de correção ou após a submissão, com navegação clara para o primeiro erro.

**Regra de Transição**: preservar a relação entre erro resumido e campo de origem. Em telas pequenas, priorizar levar ao primeiro erro e manter erros inline.

## Estados

**Estados próprios**: oculto, sem erros, com erros, com avisos, validando, erro resolvido parcialmente, foco no primeiro erro.

**Reação a estados da página**: `error` de submissão por validação → exibe o resumo e mantém erros inline. `loading` de validação → indicador de validação. `no-permission` → remove pendências de campos inacessíveis.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir posição, foco, links para campos, aria-live e integração com validação inline.

**Adaptação Mobile nativo**: levar ao primeiro erro, manter mensagens inline e evitar resumo longo sem navegação.

**Adaptação Desktop nativo**: integrar keyboard focus, lista de erros e navegação por seção.
