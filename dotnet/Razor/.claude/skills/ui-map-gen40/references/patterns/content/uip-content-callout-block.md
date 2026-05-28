# UIP-CONTENT-CALLOUT_BLOCK - Callout Block

## Definição

**Categoria**: Conteúdo

**Definição curta**: Bloco persistente de orientação, aviso, nota, regra ou contexto importante dentro do conteúdo da tela.

**Objetivo estrutural**: Destacar informação contextual estável que muda a interpretação ou a execução da tarefa, sem representar evento temporário, erro técnico ou estado global da página.

**Não confundir com**: UIP-FEEDBACK-TOAST_ALERT (feedback temporário), UIP-FEEDBACK-ERROR_STATE (falha técnica), UIP-CONTENT-RICH_TEXT_BLOCK (conteúdo editorial longo), UIP-OVERLAY-TOOLTIP (ajuda pontual).

**Nível composicional possível**: Leaf, Container

## Decisão

**Quando usar**: quando uma regra, restrição, aviso, nota operacional, recomendação, contexto legal ou explicação curta precisa permanecer visível no fluxo da tela; quando a informação não é erro, mas influencia a decisão do usuário.

**Quando evitar**: quando a mensagem é resultado temporário de uma ação; quando representa erro bloqueante; quando o conteúdo é documentação longa; quando a informação pode ser resolvida por label, help text ou microcopy local.

**Alternativas próximas**: UIP-FEEDBACK-TOAST_ALERT (feedback temporário), UIP-FEEDBACK-ERROR_STATE (falha técnica), UIP-CONTENT-RICH_TEXT_BLOCK (conteúdo editorial), UIP-INPUT-VALIDATION_SUMMARY (resumo de validação).

**Sinais de escolha**:
- a mensagem fica ancorada em uma seção
- a informação é contextual e persistente
- há severidade ou intenção clara como info, warning, caution ou tip
- o usuário deve considerar a informação antes de continuar

**Grau de Rigidez**: Médio — bloco persistente de orientação ou aviso é invariante; severidade, ícone e ação variam.

## Composição

**Zonas usuais**: Conteúdo.

**Variantes reconhecidas**: informação contextual; aviso operacional; nota legal; dica; restrição de permissão; bloqueio parcial; recomendação; callout com ação secundária.

**UI Patterns tipicamente contidos**: UIP-ACTION-ACTION_BAR, UIP-CONTENT-RICH_TEXT_BLOCK.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-FORM, PP-SETTINGS, PP-DETAIL, PP-WIZARD.

**Compatibilidade Secundária**: PP-LANDING, PP-CATALOG, PP-DASHBOARD, PP-LIST-DETAIL, PP-CANVAS.

**Incompatibilidades explícitas**: PP-CONVERSATION (orientação que pertence à própria troca conversacional).

## Estrutura e Transição

**Estrutura Desktop**: bloco inline ou lateral próximo da seção afetada, com intenção clara, texto curto e ação opcional. Fica visualmente associado ao conteúdo que contextualiza.

**Estrutura Mobile**: bloco empilhado no fluxo, com texto conciso e ação abaixo ou inline. Evitar ocupar espaço excessivo antes da tarefa principal.

**Regra de Transição**: a mensagem e sua relação com a seção afetada são preservadas. Ícones, ações e densidade variam; a informação não vira feedback temporário nem se separa do contexto.

## Estados

**Estados próprios**: informativo, aviso, atenção, sucesso contextual, bloqueio parcial, com ação, dispensável, oculto por permissão ou regra.

**Reação a estados da página**: `loading` → oculto até o contexto estar disponível. `error` → não substitui o erro global. `empty` → pode orientar o próximo passo quando a ausência for contextual.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir posição inline, lateral ou sticky conforme o escopo da orientação.

**Adaptação Mobile nativo**: manter o bloco no fluxo da seção e reduzir o texto para leitura rápida; ações explícitas e tocáveis.

**Adaptação Desktop nativo**: pode aparecer em painéis, inspectors ou área de ajuda contextual persistente.
