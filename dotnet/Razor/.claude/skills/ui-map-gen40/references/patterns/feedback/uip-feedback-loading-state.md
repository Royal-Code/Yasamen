# UIP-FEEDBACK-LOADING_STATE - Loading State

## Definição

**Categoria**: Feedback & Estado

**Definição curta**: Estado de progresso enquanto conteúdo, navegação, operação ou ação ainda está carregando ou processando.

**Objetivo estrutural**: Indicar que uma operação está em curso e preservar continuidade enquanto a interface aguarda dados, execução ou conclusão.

**Não confundir com**: UIP-FEEDBACK-EMPTY_STATE (sem dados), UIP-FEEDBACK-ERROR_STATE (falha), UIP-FEEDBACK-TOAST_ALERT (ação concluída).

**Nível composicional possível**: Leaf

## Decisão

**Quando usar**: quando conteúdo ou ação ainda não está pronto; quando a página ou zona precisa preservar continuidade durante a espera; quando o usuário deve perceber progresso, indisponibilidade temporária ou execução em background.

**Quando evitar**: quando já há falha técnica estabelecida; quando não existe mais conteúdo esperado; quando o feedback é apenas posterior a uma ação concluída; quando a operação é instantânea e o indicador causaria ruído.

**Alternativas próximas**: UIP-FEEDBACK-EMPTY_STATE (sem dados), UIP-FEEDBACK-ERROR_STATE (falha), UIP-SYSTEM-BACKGROUND_PROGRESS (operação longa em background).

**Sinais de escolha**:
- a operação está em curso
- o conteúdo será exibido depois
- a zona precisa sinalizar espera
- parte da interface fica temporariamente indisponível
- há progresso determinado, indeterminado ou execução em background

**Grau de Rigidez**: Médio — indicação de progresso ou carregamento é invariante; formato (skeleton, spinner, barra) varia por contexto.

## Composição

**Zonas usuais**: Conteúdo, Coleção, Ações, Painel Auxiliar.

**Variantes reconhecidas**: loading inicial; loading parcial; skeleton de conteúdo; progresso determinado; progresso indeterminado; loading inline de ação; operação em background.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: Todos os Page Patterns.

**Compatibilidade Secundária**: Nenhuma.

**Incompatibilidades explícitas**: não deve permanecer ativo após erro, ausência definitiva de dados ou conclusão da operação.

## Estrutura e Transição

**Estrutura Desktop**: pode ocupar a zona do conteúdo esperado, aparecer inline junto à ação executada ou representar progresso de operação longa em área persistente.

**Estrutura Mobile**: estrutura preservada. Indicadores inline ou de zona consideram navegação, teclado e interrupções do app.

**Regra de Transição**: preservar o escopo do loading. Loading de página, zona, ação e background não se misturam sem clareza.

## Estados

**Estados próprios**: carregamento inicial, carregamento parcial, carregamento incremental, ação processando, progresso determinado, progresso indeterminado, operação em background, cancelando.

**Reação a estados da página**: renderiza `loading`. Ativo durante qualquer carregamento ou processamento. `error` o substitui em caso de falha; `empty` o substitui quando a operação conclui sem dados.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: diferenciar loading de rota, zona, tabela, ação e background para evitar bloqueio excessivo.

**Adaptação Mobile nativo**: considerar ciclo de vida do app, perda de conexão, operação em background e feedback após a retomada.

**Adaptação Desktop nativo**: pode integrar progresso com taskbar ou dock quando a operação longa continuar fora da janela ativa.
