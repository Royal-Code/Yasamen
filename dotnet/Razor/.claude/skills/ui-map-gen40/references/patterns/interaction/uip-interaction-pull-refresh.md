# UIP-INTERACTION-PULL_REFRESH - Pull to Refresh

## Definição

**Categoria**: Interação & Manipulação

**Definição curta**: Gesto de puxar para baixo no topo de uma lista ou região de scroll para atualizar conteúdo.

**Objetivo estrutural**: Permitir atualização manual de conteúdo via gesto direto, preservando a posição e o contexto da lista.

**Não confundir com**: UIP-FEEDBACK-LOADING_STATE (carregamento automático), UIP-NAV-PAGINATION (navegação por páginas), UIP-SYSTEM-BACKGROUND_PROGRESS (sincronização em background).

**Nível composicional possível**: Leaf

## Decisão

**Quando usar**: quando a lista pode ter conteúdo novo desde a última visualização; quando o usuário espera controle manual de atualização; quando a atualização é leve e rápida; quando a região tem topo claro de scroll.

**Quando evitar**: quando o conteúdo é estático ou muda raramente; quando real-time ou background sync já resolvem; quando a atualização é pesada ou cara; quando existe scroll aninhado que tornaria o gesto ambíguo.

**Alternativas próximas**: UIP-SYSTEM-BACKGROUND_PROGRESS (sincronização em background), UIP-NAV-PAGINATION (paginação ou infinite scroll), UIP-ACTION-ACTION_BAR (refresh por botão).

**Sinais de escolha**:
- dados potencialmente desatualizados
- o gesto é nativo ou esperado
- a atualização não deve descartar o conteúdo atual
- falha de refresh não deve apagar dados já carregados

**Grau de Rigidez**: Alto — gesto de puxar no topo para atualizar é invariante; animação e feedback visual variam.

## Composição

**Zonas usuais**: Coleção.

**Variantes reconhecidas**: refresh de lista; refresh de feed; refresh de inbox; refresh de região scrollável; refresh com última atualização visível.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-FEED, PP-CONVERSATION, PP-LIST-DETAIL.

**Compatibilidade Secundária**: PP-CATALOG, PP-DASHBOARD, PP-CALENDAR.

**Incompatibilidades explícitas**: PP-FORM, PP-WIZARD e fluxos transacionais em que puxar para atualizar poderia perder estado ou confundir a submissão.

## Estrutura e Transição

**Estrutura Desktop**: padrão primário é refresh por botão, atalho ou atualização automática.

**Estrutura Mobile**: gesto no topo da região scrollável, threshold de ativação e indicador de refresh; encerramento explícito ao concluir.

**Regra de Transição**: usar componente nativo; não conflitar com scroll; oferecer refresh alternativo quando o gesto não for descobrível ou acessível.

## Estados

**Estados próprios**: idle, puxando abaixo do threshold, acionado acima do threshold, atualizando, concluído, falhou.

**Reação a estados da página**: `error` após refresh falhado → mensagem inline ou toast sem remover o conteúdo existente. `loading` inicial é separado do refresh manual.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo.

**Plataformas primárias**: Mobile nativo.


## Adaptação por Plataforma

**Adaptação Web**: validar comportamento em browser móvel e oferecer botão de refresh quando necessário.

**Adaptação Mobile nativo**: usar componente nativo de refresh e preservar o conteúdo atual durante a atualização.

**Adaptação Desktop nativo**: preferir refresh por botão, atalho, comando ou atualização automática.
