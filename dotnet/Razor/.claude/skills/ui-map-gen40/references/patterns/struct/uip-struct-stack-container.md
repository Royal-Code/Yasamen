# UIP-STRUCT-STACK_CONTAINER - Stack Container

## Definição

**Categoria**: Estrutural

**Definição curta**: Contêiner que organiza elementos em sequência vertical com espaçamento coerente.

**Objetivo estrutural**: Organizar UI Patterns em sequência vertical com espaçamento consistente.

**Não confundir com**: UIP-INPUT-FORM_FIELD_GROUP (agrupamento semântico de formulário), UIP-STRUCT-LAYOUT_ZONE (zona com responsabilidade própria), UIP-STRUCT-COLLAPSIBLE_SECTION (seção expansível), UIP-STRUCT-GRID_CONTAINER (distribuição em grade).

**Nível composicional possível**: Container

## Decisão

**Quando usar**: quando o conteúdo deve ser lido ou percorrido verticalmente; quando a zona combina vários blocos sem necessidade de grade; quando a clareza depende de empilhamento simples e previsível.

**Quando evitar**: quando o agrupamento precisa de semântica própria de formulário ou detalhe; quando a composição real é de múltiplas colunas; quando a relação entre elementos é simultânea e lateral; quando cada grupo precisa de estado expandido ou recolhido próprio.

**Alternativas próximas**: UIP-STRUCT-COLLAPSIBLE_SECTION (seção expansível), UIP-STRUCT-GRID_CONTAINER (distribuição em grade), UIP-INPUT-FORM_FIELD_GROUP (agrupamento de formulário), UIP-STRUCT-LAYOUT_ZONE (zona funcional).

**Sinais de escolha**:
- os filhos são consumidos em ordem vertical
- o espaçamento uniforme é relevante
- a zona não precisa de layout em grade
- o contêiner é puramente estrutural

**Grau de Rigidez**: Baixo — sequência vertical com espaçamento coerente é fixa; conteúdo e densidade variam livremente.

## Composição

**Zonas usuais**: Conteúdo, Detalhe.

**Variantes reconhecidas**: stack simples; stack com separadores; stack com espaçamento variável por grupo.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-FORM, PP-SETTINGS, PP-WIZARD.

**Compatibilidade Secundária**: PP-DETAIL, PP-DASHBOARD.

**Incompatibilidades explícitas**: Nenhuma.

## Estrutura e Transição

**Estrutura Desktop**: coluna vertical. Espaçamento uniforme entre elementos filhos. Largura determinada pela zona pai.

**Estrutura Mobile**: comportamento preservado. O espaçamento pode ser reduzido.

**Regra de Transição**: estrutura mantida. Ajuste de espaçamento e padding lateral.

## Estados

**Estados próprios**: normal, com erro em filho.

**Reação a estados da página**: `loading` → substitui o conteúdo por loading state. `empty` → exibe zona vazia se todos os filhos estiverem vazios.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: preservar a ordem e a leitura vertical.

**Adaptação Mobile nativo**: stack é o padrão natural para conteúdo sequencial e formulários.

**Adaptação Desktop nativo**: preservar a ordem vertical e o espaçamento consistente.
