# UIP-STRUCT-LAYOUT_ZONE - Layout Zone

## Definição

**Categoria**: Estrutural

**Definição curta**: Região funcional da interface que agrupa conteúdo com responsabilidade própria dentro de uma página ou shell.

**Objetivo estrutural**: Delimitar uma área funcional da página com responsabilidade distinta. Âncora que agrupa os UI Patterns de uma zona.

**Não confundir com**: UIP-STRUCT-SPLIT_PANEL (dois painéis simultâneos), UIP-STRUCT-DOCKED_PANEL_SET (múltiplos painéis acoplados), UIP-STRUCT-GRID_CONTAINER (distribuição visual em grade), UIP-STRUCT-COLLAPSIBLE_SECTION (seção expansível), shell de navegação completo (fora do catálogo).

**Nível composicional possível**: Root, Container

## Decisão

**Quando usar**: quando a página precisa separar responsabilidades funcionais em áreas distintas; quando a mesma página combina listagem, detalhe, filtros, ações ou conteúdo auxiliar; quando a zona precisa agrupar outros UIPs sem virar um padrão semântico próprio.

**Quando evitar**: quando a necessidade real é apenas distribuir colunas ou espaçamento visual; quando a estrutura exige dois ou mais painéis com simultaneidade explícita; quando a área inteira já é o shell de navegação; quando a decisão central é expandir ou recolher conteúdo.

**Alternativas próximas**: UIP-STRUCT-SPLIT_PANEL (dois painéis simultâneos), UIP-STRUCT-DOCKED_PANEL_SET (múltiplos painéis acoplados), UIP-STRUCT-COLLAPSIBLE_SECTION (seção expansível), UIP-STRUCT-GRID_CONTAINER (distribuição em grade).

**Sinais de escolha**:
- existe uma zona funcional nomeável na página
- a zona tem responsabilidade própria e reage a estados localizados
- a zona contém outros UIPs, não apenas conteúdo solto
- a página precisa explicitar cabeçalho, filtro, lista, detalhe ou ações em áreas separadas

**Grau de Rigidez**: Baixo — a zona é abstrata; implementação e subdivisão interna variam por página e contexto.

## Composição

**Zonas usuais**: Cabeçalho, Navegação, Filtros, Coleção, Detalhe, Conteúdo, Ações, Painel Auxiliar, Rodapé.

**Variantes reconhecidas**: Nenhuma reconhecida — pattern abstrato.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: Todos os Page Patterns.

**Compatibilidade Secundária**: Nenhuma.

**Incompatibilidades explícitas**: Nenhuma.

## Estrutura e Transição

**Estrutura Desktop**: área retangular com dimensões definidas pela zona funcional. Pode ser fixa ou flexível conforme o conteúdo.

**Estrutura Mobile**: ocupa a largura total. Empilhamento vertical entre zonas.

**Regra de Transição**: layout lateral → empilhamento vertical. Zonas simultâneas → zonas sequenciais navegáveis quando necessário.

## Estados

**Estados próprios**: ativa, colapsada, oculta por permissão ou contexto.

**Reação a estados da página**: `loading`, `error` e `empty` → exibe o estado correspondente dentro da própria zona. `no-permission` → zona oculta ou bloqueada.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir ordem, colapso e comportamento de zonas por viewport.

**Adaptação Mobile nativo**: zonas tendem a empilhar, virar telas sequenciais ou áreas dentro de stack ou sheet.

**Adaptação Desktop nativo**: zonas podem coexistir com painéis, janelas e keyboard flow.
