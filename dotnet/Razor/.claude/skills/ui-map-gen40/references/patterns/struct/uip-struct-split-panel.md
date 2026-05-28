# UIP-STRUCT-SPLIT_PANEL - Split Panel

## Definição

**Categoria**: Estrutural

**Definição curta**: Estrutura de dois painéis com responsabilidades simultâneas e complementares.

**Objetivo estrutural**: Dividir a área principal em dois painéis com responsabilidades distintas e simultâneas.

**Não confundir com**: UIP-STRUCT-DOCKED_PANEL_SET (múltiplos painéis acoplados), UIP-STRUCT-LAYOUT_ZONE (zona funcional genérica), UIP-STRUCT-GRID_CONTAINER (grade multicoluna), UIP-NAV-TABS (alternância local).

**Nível composicional possível**: Root, Container

## Decisão

**Quando usar**: quando duas áreas precisam coexistir e interagir ao mesmo tempo; quando a escolha em um painel altera o conteúdo do outro; quando a experiência depende de contexto simultâneo entre lista e detalhe ou áreas equivalentes.

**Quando evitar**: quando as áreas podem ser apenas empilhadas sem perda de contexto; quando a navegação é livre entre vistas e não simultânea; quando a tela exige três ou mais painéis persistentes coordenados; quando a tela é essencialmente formulário ou conteúdo linear.

**Alternativas próximas**: UIP-STRUCT-DOCKED_PANEL_SET (três ou mais painéis), UIP-STRUCT-LAYOUT_ZONE (zona funcional), UIP-NAV-TABS (alternância local).

**Sinais de escolha**:
- existem duas responsabilidades fortes no mesmo espaço
- simultaneidade importa
- a navegação de um lado alimenta o conteúdo do outro
- o usuário se beneficia de comparação ou contexto paralelo

**Grau de Rigidez**: Médio — dois painéis simultâneos com responsabilidades complementares são invariantes; proporção e orientação variam.

## Composição

**Zonas usuais**: Coleção, Detalhe, Painel Auxiliar.

**Variantes reconhecidas**: split horizontal; split vertical; split com divisor ajustável; split com painel secundário colapsável.

**UI Patterns tipicamente contidos**: UIP-DATA-DATA_TABLE, UIP-DATA-LIST_ITEM, UIP-CONTENT-DETAIL_BLOCK, UIP-STRUCT-SCROLLABLE_REGION.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-LIST-DETAIL, PP-CONVERSATION.

**Compatibilidade Secundária**: PP-SETTINGS, PP-DETAIL.

**Incompatibilidades explícitas**: PP-FORM, PP-WIZARD, PP-LANDING.

## Estrutura e Transição

**Estrutura Desktop**: dois painéis lado a lado. Primário à esquerda, secundário à direita. Divisor ajustável opcional.

**Estrutura Mobile**: painéis alternam; apenas um visível de cada vez. Navegação entre painéis por ação do usuário.

**Regra de Transição**: simultaneidade → sequência. Painel secundário vazio → exibe estado "nenhum item selecionado".

## Estados

**Estados próprios**: painel primário em foco, painel secundário em foco, painel secundário colapsado, painel secundário vazio.

**Reação a estados da página**: `loading` → cada painel exibe loading independente. `empty` → painel secundário exibe empty state. `error` → painel afetado exibe erro localizado.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: definir o breakpoint conceitual em que a simultaneidade vira sequência.

**Adaptação Mobile nativo**: usar UIP-NAV-NAV_STACK ou alternância explícita; não manter dois painéis simultâneos em phone comum.

**Adaptação Desktop nativo**: pode coexistir com floating panels, keyboard flow e multi-window.
