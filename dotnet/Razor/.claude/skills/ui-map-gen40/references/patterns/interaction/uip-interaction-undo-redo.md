# UIP-INTERACTION-UNDO_REDO - Undo Redo

## Definição

**Categoria**: Interação & Manipulação

**Definição curta**: Reversão e reaplicação de ações em fluxos editáveis, manipuláveis ou operacionais.

**Objetivo estrutural**: Permitir recuperar estados anteriores e reaplicar mudanças sem depender de confirmação prévia para toda ação.

**Não confundir com**: UIP-FEEDBACK-TOAST_ALERT (undo pontual de uma ação), cancelar formulário (fora do catálogo), retry de erro (fora do catálogo).

**Nível composicional possível**: Root, Container

## Decisão

**Quando usar**: quando ações editáveis são frequentes; quando erros do usuário precisam ser reversíveis; quando canvas, editor, board, texto, configuração ou manipulação direta exigem histórico; quando undo reduz a necessidade de confirmações excessivas.

**Quando evitar**: quando ações têm efeito externo irreversível imediato; quando a operação depende de confirmação legal ou financeira; quando o sistema não consegue restaurar o estado com consistência; quando salvar ou cancelar de formulário resolve.

**Alternativas próximas**: UIP-FEEDBACK-CONFIRMATION_DIALOG (confirmação prévia), UIP-FEEDBACK-TOAST_ALERT (toast com undo único).

**Sinais de escolha**:
- edição contínua
- ações pequenas e reversíveis
- histórico de mudanças
- atalhos esperados
- toolbar de undo/redo
- risco de erro operacional recorrente

**Grau de Rigidez**: Alto — reversão e reaplicação de ações é invariante; granularidade, stack e UI do histórico variam.

## Composição

**Zonas usuais**: Superfície, Conteúdo, Ações.

**Variantes reconhecidas**: undo/redo linear; histórico por documento; undo por seleção; undo de ação única via snackbar; version history; revert to saved.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-CANVAS, PP-FORM, PP-BOARD.

**Compatibilidade Secundária**: PP-DETAIL, PP-SETTINGS, PP-WIZARD, PP-CALENDAR.

**Incompatibilidades explícitas**: ações externas irreversíveis, transações financeiras concluídas, envio definitivo sem janela de reversão.

## Estrutura e Transição

**Estrutura Desktop**: atalhos e comandos de undo/redo, histórico por documento ou contexto, estado habilitado ou desabilitado e integração com salvamento.

**Estrutura Mobile**: undo por toolbar, menu, gesto da plataforma ou snackbar para ação recente. Redo pode estar em menu quando menos frequente.

**Regra de Transição**: preservar reversibilidade e escopo. O usuário precisa saber o que será desfeito e se a ação afeta documento, seleção, item ou operação global.

## Estados

**Estados próprios**: sem histórico, pode desfazer, pode refazer, desfazendo, refazendo, histórico limpo após salvar, conflito, ação irreversível, undo expirado.

**Reação a estados da página**: `loading` → comandos temporariamente indisponíveis enquanto o estado sincroniza. `error` → rollback ou retry conforme consistência. `no-permission` → histórico pode existir sem permitir nova edição.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: definir atalhos, toolbar, escopo do histórico, persistência, confirmação para ações irreversíveis e integração com salvar.

**Adaptação Mobile nativo**: oferecer undo descobrível por toolbar, menu ou snackbar; evitar depender apenas de gesto não explícito.

**Adaptação Desktop nativo**: integrar menu de edição, atalhos, command palette, histórico por documento e estado dirty ou saved.
