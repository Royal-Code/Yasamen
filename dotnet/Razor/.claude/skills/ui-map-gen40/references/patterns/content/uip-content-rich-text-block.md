# UIP-CONTENT-RICH_TEXT_BLOCK - Rich Text Block

## Definição

**Categoria**: Conteúdo

**Definição curta**: Bloco de conteúdo livre e editorial, com formatação textual e elementos embutidos.

**Objetivo estrutural**: Apresentar conteúdo editorial, documental, explicativo ou narrativo de formato livre com suporte a estrutura textual.

**Não confundir com**: UIP-CONTENT-DETAIL_BLOCK (leitura estruturada de atributos), UIP-CONTENT-CALLOUT_BLOCK (orientação contextual curta), UIP-CONTENT-COMMENT_THREAD (discussão colaborativa), UIP-INPUT-FORM_FIELD_GROUP (captura de dados), UIP-CONTENT-METRIC_CARD (indicador sintético).

**Nível composicional possível**: Leaf, Container

## Decisão

**Quando usar**: quando o conteúdo é narrativo, editorial, explicativo ou documental; quando headings, listas, links, imagens, anexos, código ou anotações fazem parte natural da leitura; quando a estrutura principal é textual e não de pares atributo/valor.

**Quando evitar**: quando a zona depende de leitura estruturada de campos; quando a tarefa principal é editar ou preencher dados; quando o valor central é um KPI ou síntese analítica; quando o documento exige viewer paginado; quando a informação é um aviso contextual curto ou uma discussão colaborativa.

**Alternativas próximas**: UIP-CONTENT-DETAIL_BLOCK (leitura estruturada), UIP-CONTENT-CALLOUT_BLOCK (orientação curta), UIP-CONTENT-COMMENT_THREAD (discussão colaborativa), UIP-CONTENT-METRIC_CARD (indicador sintético), UIP-CONTENT-MEDIA_VIEWER (mídia em foco), UIP-SURFACE-DOCUMENT_VIEWER (documento paginado).

**Sinais de escolha**:
- a leitura é livre e contínua
- headings e parágrafos são elementos naturais do conteúdo
- o usuário precisa consumir explicação, política, descrição, documentação ou help
- a semântica editorial é mais importante que grade de dados

**Grau de Rigidez**: Baixo — bloco de conteúdo editorial formatado é estável; tipos de formatação e mídia embarcada variam.

## Composição

**Zonas usuais**: Conteúdo.

**Variantes reconhecidas**: artigo; help ou documentação; política ou termos; release notes; bloco com código; bloco com anotações ou comentários.

## Compatibilidade com Page Patterns

**Compatibilidade Primária**: PP-DETAIL, PP-LANDING.

**Compatibilidade Secundária**: PP-FEED, PP-SETTINGS, PP-CATALOG.

**Incompatibilidades explícitas**: PP-DASHBOARD (leitura principal de métrica ou análise operacional).

## Estrutura e Transição

**Estrutura Desktop**: área de leitura com headings, parágrafos, listas, links, imagens inline, blocos de código, tabelas simples ou anotações. Pode ter índice local quando o conteúdo for longo.

**Estrutura Mobile**: largura disponível com espaçamento lateral adequado. Elementos embutidos reflowam ou viram blocos empilhados.

**Regra de Transição**: estrutura documental e ordem de leitura preservadas. Elementos embutidos mudam de posição ou escala sem quebrar a sequência semântica.

## Estados

**Estados próprios**: carregando, com conteúdo, sem conteúdo, conteúdo truncado, conteúdo expandido, erro de carregamento.

**Reação a estados da página**: `loading` → skeleton de parágrafos. `error` → mensagem com retry. `empty` → ausência explícita de conteúdo.

## Plataformas e Aplicabilidade

**Plataformas aplicáveis**: Web, Mobile nativo, Desktop nativo.

**Plataformas primárias**: Web, Mobile nativo, Desktop nativo.


## Adaptação por Plataforma

**Adaptação Web**: decidir largura de leitura, índice local, links, blocos de código e elementos embutidos.

**Adaptação Mobile nativo**: manter leitura sequencial; tratar imagens, tabelas e blocos de código como blocos roláveis ou adaptados.

**Adaptação Desktop nativo**: pode compor com painel de navegação documental, busca local e ações de impressão ou exportação.
