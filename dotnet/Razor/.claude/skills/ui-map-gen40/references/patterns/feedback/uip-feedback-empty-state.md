# UIP-FEEDBACK-EMPTY_STATE - Empty State

## Definição

**Categoria**: Feedback & Estado

**Definição curta**: Estado de ausência de dados ou resultados, com orientação sobre o próximo passo possível.

**Objetivo estrutural**: Comunicar ausência de conteúdo esperado e orientar para criação, ajuste de busca ou filtros, permissões ou outro caminho de continuidade.

**Não confundir com**: UIP-FEEDBACK-ERROR_STATE (falha técnica), UIP-FEEDBACK-TOAST_ALERT (evento transitório), UIP-FEEDBACK-LOADING_STATE (conteúdo ainda carregando).

**Nível composicional possível**: Leaf

## Decisão

**Quando usar**: quando não há dados iniciais; quando busca ou filtro não retorna resultados; quando uma zona ou página precisa explicar a ausência de conteúdo; quando um CTA pode orientar criação, ajuste de filtros, solicitação de acesso ou novo caminho.

**Quando evitar**: quando a ausência decorre de erro técnico; quando o feedback é transitório após uma ação; quando o conteúdo ainda está carregando; quando a ausência é estado interno sem impacto para o usuário.

**Alternativas próximas**: UIP-FEEDBACK-ERROR_STATE (falha técnica), UIP-FEEDBACK-LOADING_STATE (espera em curso), UIP-FEEDBACK-TOAST_ALERT (feedback não bloqueante).

**Sinais de escolha**:
- não há conteúdo para exibir
- a situação não é falha técnica
- existe orientação possível ao usuário
- a zona pode ser substituída por mensagem e ação sem quebrar a estrutura da página

**Grau de Rigidez**: Baixo — mensagem de ausência com orientação é invariante; ilustração, CTA e tom variam.

## Composição

**Zonas usuais**: Conteúdo, Coleção, Detalhe.

**Variantes reconhecidas**: vazio de primeiro uso; vazio por filtro; vazio por busca; vazio por permissão; vazio de conteúdo opcional.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: Todos os Page Patterns.

**Compatibilidade Secundária**: Nenhuma.

**Incompatibilidades explícitas**: não substitui UIP-FEEDBACK-ERROR_STATE quando o motivo é falha técnica, offline, autenticação expirada ou recurso indisponível.

## Estrutura e Transição

**Estrutura Desktop**: zona de estado no lugar do conteúdo esperado, com mensagem principal, explicação opcional e ação quando houver próximo passo claro.

**Estrutura Mobile**: estrutura preservada na área disponível. Ação principal acessível sem navegação extra.

**Regra de Transição**: a semântica da ausência e o próximo passo são preservados. Elementos auxiliares podem ser reduzidos; a razão da ausência não pode ficar ambígua.

## Estados

**Estados próprios**: sem dados iniciais, sem resultados para busca ativa, sem resultados para filtro ativo, vazio por permissão insuficiente, vazio por configuração pendente.

**Reação a estados da página**: renderiza `empty`; renderiza `no-permission` na variante de permissão. Substitui o conteúdo da zona quando os dados estão ausentes. `loading` tem precedência enquanto houver operação em curso; `error` tem precedência quando a ausência decorre de falha.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: distinguir vazio inicial, vazio por busca ou filtro e vazio por permissão para orientar ações diferentes.

**Adaptação Mobile nativo**: mensagem curta e ação primária acessível; evitar navegação longa para corrigir busca, filtros ou permissão.

**Adaptação Desktop nativo**: pode coexistir com painéis ou listas vazias; preservar o contexto da zona vazia.
