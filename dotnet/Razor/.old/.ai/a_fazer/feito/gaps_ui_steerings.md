# Gaps dos UI Steerings

> Consolidacao dos desvios encontrados entre o `ui-map`, os guides em `.ai/guides/` e o codigo real da biblioteca.
> Objetivo: transformar observacoes soltas em backlog acionavel.

---

## Resumo Executivo

Os pontos encontrados se dividem em 3 grupos:

1. Guides que ja nao descrevem fielmente a implementacao atual.
2. Itens do `ui-map` que estao corretos em intencao, mas com justificativa, exemplo ou nota desatualizados.
3. Uma decisao de arquitetura ainda em aberto: o uso de `*.razor.css` dentro dos pacotes da biblioteca.

### Prioridade sugerida

| Gap | Escopo | Prioridade | Tipo | Recomendacao curta |
|---|---|---|---|---|
| GAP-01 | Guide 08 | P1 | Divergencia forte entre doc e codigo | Reescrever o guide com base no fluxo real de Notifications, Modal e OffCanvas |
| GAP-02 | Guide 01 | P1 | Regras estruturais inconsistentes | Separar "arquitetura logica" de "ProjectReference real" e corrigir regra de `_Imports` |
| GAP-03 | Guide 02 + arquitetura de estilos | P1 | Decisao tecnica em aberto | Tratar CSS isolation como problema a resolver; definir fonte canonica de estilo |
| GAP-04 | UI Map - Navigation Menu | P2 | Exemplo/API desatualizados | Corrigir exemplo de integracao e explicitar que busca ainda nao existe |
| GAP-05 | UI Map - Toast / Alert | P2 | Justificativa desatualizada | Atualizar texto para refletir suporte a `Placements` |
| GAP-06 | UI Map - Form Field Group | P2 | Nota subestimada | Recalibrar nota e mapear a infraestrutura real de formularios |
| GAP-07 | Guide 03 | P3 | Desvio pequeno | Ajustar descricao do projeto Commons para incluir `Ripple` |

---

## GAP-01 - Guide 08 nao representa mais o padrao real de overlays

### Escopo

- `.ai/guides/expand/service-pattern.md`
- `RoyalCode.Razor.Alerts/Internal/Notifications/*`
- `RoyalCode.Razor.Modals/*`
- `RoyalCode.Razor.OffCanvas/*`
- `RoyalCode.Razor.Layouts.Apps/Layouts/Apps/AppLayout.razor`

### Problema

O guide 08 descreve um modelo simplificado e uniforme de `Service + Outlet`, baseado em evento simples e exemplos pseudo-implementados. Isso nao corresponde ao estado atual da biblioteca:

- `Notification` usa `NotificationService` + `NotificationOutlet`, mas nao usa `SectionOutlet/SectionContent`.
- `Modal` e `OffCanvas` usam `SectionContent/SectionOutlet`, services internos e handlers async.
- O guide mistura regras conceituais corretas com exemplos que ja nao servem como steering para implementar novos componentes reais.

Na pratica, se alguem seguir o guide 08 literalmente, vai criar um novo overlay diferente da arquitetura que a biblioteca ja usa hoje.

### Justificativa

Este e o guide com maior potencial de gerar implementacao errada.

Nao se trata apenas de "exemplo simplificado":

- o mecanismo de renderizacao esta diferente;
- o contrato dos handlers esta diferente;
- o acoplamento com os outlets esta diferente;
- `Modal` e `OffCanvas` ja dependem de services internos e lifecycle async;
- `Notification` tem logica de agrupamento por `Placement`, nao uma lista simples.

Ou seja: o document nao esta apenas resumindo, ele esta descrevendo outro desenho.

### Opcoes

#### Opcao A - Reescrever o guide para descrever o padrao real atual

Pros:

- vira fonte de verdade;
- reduz risco de novas implementacoes divergentes;
- preserva a arquitetura ja adotada na biblioteca;
- facilita futuras evolucoes por comparacao com o codigo real.

Contras:

- da mais trabalho agora;
- o guide fica mais tecnico e menos "didatico".

#### Opcao B - Simplificar a implementacao real para encaixar no guide

Pros:

- deixaria a documentacao mais simples;
- reduziria variacao entre tipos de overlay.

Contras:

- custo alto;
- risco de regressao;
- exigiria refactor em Notifications, Modal e OffCanvas;
- nao ha evidencia de ganho tecnico que justifique a mudanca.

#### Opcao C - Assumir oficialmente que o guide e apenas conceitual

Pros:

- menor esforco imediato.

Contras:

- deixa de ser steering file de verdade;
- continua abrindo margem para erro;
- obriga qualquer implementador a ler o codigo fonte para descobrir o padrao real.

### Recomendacao

Adotar a Opcao A.

O guide 08 precisa ser reescrito para representar dois subpadroes reais:

1. `Service + Outlet` global para notificacoes.
2. `Component + Handler + Service interno + SectionOutlet/SectionContent` para modais e off-canvas.

### Plano de alteracao

#### O que fazer

- Reescrever o guide 08 com base nas classes reais, nao em pseudocodigo.
- Explicar explicitamente que Notifications, Modal e OffCanvas nao seguem a mesma estrategia de renderizacao.
- Incluir tabela de decisao: quando usar facade publica, quando usar handler, quando usar `SectionContent`.

#### Como fazer

- Ler e mapear os contratos reais:
  - `NotificationService`, `Notify`, `NotificationOutlet`, `NotificationGroup`.
  - `Modal`, `ModalHandler`, `ModalService`, `ModalOutlet`.
  - `OffCanvas`, `OffCanvasHandler`, `OffCanvasService`, `OffCanvasOutlet`.
- Trocar o texto de "padrao unico" por "familia de padroes correlatos".
- Atualizar exemplos para:
  - `Notify.Success(...)` com callback opcional de configuracao;
  - `ModalHandler.OpenAsync()` e `CloseAsync()`;
  - `OffCanvasHandler.Show()` e `Hide()` com o fluxo real.

#### Onde alterar

- `.ai/guides/expand/service-pattern.md`

---

## GAP-02 - Guide 01 mistura arquitetura logica com estrutura fisica real

### Escopo

- `.ai/guides/expand/project-structure.md`
- `_Imports.razor` dos pacotes
- `.csproj` dos projetos principais

### Problema

O guide 01 tem duas inconsistencias:

1. O "grafo de dependencias" parece descrever referencias diretas de projeto, mas varios `.csproj` usam um grafo bem mais enxuto, contando com transitividade.
2. O guide afirma que namespaces internos nao entram em `_Imports.razor`, mas o codigo atual ja faz isso em alguns pacotes.

Isso transforma uma diretriz estrutural em algo ambiguo:

- nao fica claro se a regra e normativa ou apenas idealizada;
- nao fica claro se devemos refletir o estado atual ou um estado desejado;
- um novo pacote pode seguir o guide e acabar com padrao diferente do usado hoje.

### Justificativa

Steering file estrutural precisa ser extremamente preciso. Ele define onde por arquivos, como referenciar projetos e o que e publico ou interno.

Quando o guide erra aqui, ele gera:

- referencias redundantes ou faltantes;
- `_Imports` inconsistentes;
- confusao entre dependencia logica e dependencia tecnica real.

### Opcoes

#### Opcao A - Corrigir o guide para refletir o estado atual do repo

Pros:

- steering fiel ao codigo;
- menor custo;
- reduz conflito para quem cria pacote novo hoje.

Contras:

- oficializa algumas decisoes que talvez ainda nao sejam ideais.

#### Opcao B - Ajustar o repo para obedecer ao guide atual

Pros:

- aumenta consistencia entre documentacao e implementacao.

Contras:

- pode adicionar `ProjectReference` desnecessario;
- pode exigir limpeza de `_Imports`;
- resolve documentacao mexendo no codigo sem beneficio funcional claro.

#### Opcao C - Separar explicitamente dois modelos no guide

- "Arquitetura logica por camadas"
- "Referencias diretas reais dos `.csproj`"

Pros:

- elimina ambiguidade;
- preserva valor arquitetural e valor operacional;
- provavelmente e a forma mais correta de documentar.

Contras:

- guide fica um pouco maior.

### Recomendacao

Adotar a Opcao C, com ajuste textual adicional.

Refinamento importante:

- a regra de `_Imports` nao deve ser "proibir namespaces internos";
- a regra correta e permitir `RoyalCode.Razor.Internal.*` no `_Imports.razor` do proprio pacote quando isso reduz repeticao nos componentes internos;
- o ponto normativo e que esses namespaces internos nao se tornem contrato para consumidores externos.

### Plano de alteracao

#### O que fazer

- Reescrever o grafo como duas visoes:
  - visao logica;
  - visao de `ProjectReference` real.
- Corrigir a regra de `_Imports` para algo como:
  - "evitar namespaces internos no contrato publico";
  - "usar `RoyalCode.Razor.Internal.*` no `_Imports.razor` do proprio pacote quando isso simplificar os componentes internos".

#### Como fazer

- Inventariar os `.csproj` atuais.
- Inventariar os `_Imports.razor`.
- Atualizar o texto para deixar claro quando uma regra e "preferencia" e quando e "obrigatoria".

#### Onde alterar

- `.ai/guides/expand/project-structure.md`

---

## GAP-03 - Modelo de estilos indefinido; CSS isolation deve ser tratado como problema a corrigir

### Escopo

- `.ai/guides/expand/styles-and-css.md`
- `RoyalCode.Razor.Styles/wwwroot/yasamen.css`
- Arquivos `*.razor.css` existentes em pacotes da biblioteca:
  - `RoyalCode.Razor.Animations/Animations/RotateEffect.razor.css`
  - `RoyalCode.Razor.Animations/Animations/RotationMotion.razor.css`
  - `RoyalCode.Razor.Drops/Internal/Drops/DropBase.razor.css`
  - `RoyalCode.Razor.Drops/Components/DropItem.razor.css`
  - `RoyalCode.Razor.OffCanvas/Components/AsideBox.razor.css`
  - `RoyalCode.Razor.OffCanvas/Components/OffCanvas.razor.css`

### Problema

O guide 02 assume implicitamente que o sistema de estilos da biblioteca vive de forma centralizada em `RoyalCode.Razor.Styles`. Porem, o codigo real da biblioteca tambem usa CSS isolation em alguns componentes.

Para uma app comum isso nao seria necessariamente um problema. Para uma biblioteca de design system, isso e uma decisao importante e hoje ela esta indefinida.

O problema nao e apenas documental. O uso de `*.razor.css` dentro dos pacotes da biblioteca introduz:

- fonte de verdade fragmentada;
- estilos fora do pipeline canonico do `yasamen.css`;
- dificuldade de auditoria do design system;
- tendencia a acoplamento entre estrutura interna do componente e estilo;
- risco de tratar excecao como se fosse padrao.

### Justificativa

Concordando com a leitura levantada: "CSS isolation em componentes" nao deve ser documentado como padrao consolidado. Hoje ele parece mais um estado intermediario/tecnico herdado do que uma diretriz desejada.

Se a biblioteca quer ser coerente como design system, precisa definir:

- onde vive o estilo canonico;
- quando um componente pode ter estilo local;
- se `ya-*` e realmente a API visual publica;
- se CSS isolation em pacote de biblioteca e permitido, excepcional ou proibido.

### Opcoes

#### Opcao A - Oficializar modelo hibrido

Descricao:

- estilos compartilhados e publicos ficam em `RoyalCode.Razor.Styles`;
- detalhes internos e comportamentos muito locais podem ficar em `*.razor.css`.

Pros:

- menor custo de curto prazo;
- pouca migracao;
- aceita o estado atual.

Contras:

- mantem duas fontes de verdade;
- enfraquece a ideia de design system centralizado;
- abre margem para crescimento descontrolado de CSS local.

#### Opcao B - Eliminar CSS isolation dos pacotes da biblioteca e migrar tudo que for estilo de componente para `RoyalCode.Razor.Styles`

Descricao:

- `RoyalCode.Razor.Styles` vira a unica fonte canonica para estilos de componentes da biblioteca;
- `*.razor.css` deixa de ser permitido em pacotes de library, salvo excecao muito justificada;
- estilos atuais sao migrados para `wwwroot/css/components/` ou area equivalente.

Pros:

- maximiza consistencia;
- facilita auditoria;
- fortalece o contrato visual `ya-*`;
- reduz espalhamento de regra visual;
- melhora steering para novos componentes.

Contras:

- exige migracao;
- alguns estilos com `::deep` ou dependencia estrutural podem precisar de ajuste de markup/classe;
- custo imediato maior.

#### Opcao C - Manter o estado atual e apenas documentar como "transitorio"

Pros:

- custo baixo imediato.

Contras:

- nao resolve a causa;
- tende a perpetuar o problema;
- empurra decisao arquitetural para depois.

### Recomendacao

Adotar a Opcao B.

`CSS isolation` deve ser tratado como estado a reduzir, nao como padrao a perpetuar.

Refinamento importante:

- a migracao nao deve ser mecanica;
- seletores com `::deep` ou dependentes da hierarquia atual precisam de analise caso a caso;
- parte da migracao pode exigir ajuste de markup e novos hooks CSS antes da transferencia para `RoyalCode.Razor.Styles`.

Sugestao de regra futura:

- Pacotes da biblioteca: evitar `*.razor.css`.
- Estilos publicos, reutilizaveis ou de contrato visual: sempre em `RoyalCode.Razor.Styles`.
- `*.razor.css` permitido apenas em apps consumidoras/docs e em casos internos muito excepcionais, com justificativa explicita.

### Plano de alteracao

#### O que fazer

- Tomar decisao formal de arquitetura sobre CSS.
- Inventariar cada `*.razor.css` da biblioteca.
- Classificar o risco de migracao de cada arquivo: baixo, medio, alto.
- Classificar cada regra em:
  - publica/semantica (`ya-*`, estados, variants);
  - estrutural interna;
  - workaround tecnico.
- Separar:
  - migracao direta para `RoyalCode.Razor.Styles`;
  - migracao que exige ajuste previo no markup.
- Migrar o que for de contrato visual para `RoyalCode.Razor.Styles`.

#### Como fazer

1. Criar uma matriz arquivo a arquivo.
2. Para cada seletor:
   - identificar se pode virar classe `ya-*`;
   - identificar se depende de `::deep`;
   - identificar se precisa de classe extra no markup.
3. Criar ou ampliar arquivos em `RoyalCode.Razor.Styles/wwwroot/css/components/`.
4. Registrar os imports no `yasamen.css`.
5. Ajustar markup dos componentes para expor hooks CSS explicitamente quando necessario.
6. Remover os `*.razor.css` migrados.
7. Atualizar o guide 02 para documentar a regra final.

#### Onde alterar

- `.ai/guides/expand/styles-and-css.md`
- `RoyalCode.Razor.Styles/wwwroot/yasamen.css`
- `RoyalCode.Razor.Styles/wwwroot/css/components/*`
- Componentes com `*.razor.css` listados acima

---

## GAP-04 - UI Map de Navigation Menu com exemplo e integracao desatualizados

### Escopo

- `.ai/ui-map/ui-map.md`
- `RoyalCode.Razor.Layouts.Apps/Layouts/Apps/AppMenu.razor`
- `RoyalCode.Razor.Layouts.Apps/Extensions/LayoutAppsServiceCollectionExtensions.cs`
- `RoyalCode.Razor.Layouts.Apps/Layouts/Models/*`

### Problema

O mapeamento do pattern `UIP-NAV-NAVIGATION_MENU` esta bom em termos de cobertura geral, mas o exemplo de uso operacional nao corresponde ao codigo atual.

Problemas concretos:

- o exemplo fala em `IMenuProvider`, mas a biblioteca trabalha com `AddYasamenMenu()`, `IMenuLoader` e `MenuService`;
- o texto passa impressao de sistema completo de menu, mas a busca no `AppMenu` ainda e placeholder.

Isso nao invalida o mapeamento, mas torna o documento menos confiavel como base para implementacao.

### Justificativa

O `ui-map` nao e apenas um inventario; ele tambem esta sendo usado como artefato de planejamento e referencia tecnica. Exemplo errado aqui induz integracao errada.

Confianca atual: media.

Antes da edicao final do `ui-map`, vale confirmar linha a linha os trechos que ainda apontam para nomenclatura antiga ou sugerem busca pronta no `AppMenu`.

### Opcoes

#### Opcao A - Atualizar apenas o `ui-map`

Pros:

- resolve o problema documental rapido;
- sem impacto no codigo.

Contras:

- a busca continua ausente no produto.

#### Opcao B - Atualizar o `ui-map` e abrir gap separado para busca no AppMenu

Pros:

- documentacao fica correta;
- backlog funcional fica explicito.

Contras:

- cria mais um item de backlog.

#### Opcao C - Implementar a busca antes de corrigir o `ui-map`

Pros:

- documento e codigo convergem num salto so.

Contras:

- custo desnecessario para corrigir erro documental simples;
- busca pode demandar decisao funcional maior.

### Recomendacao

Adotar a Opcao B.

### Plano de alteracao

#### O que fazer

- Corrigir o exemplo de integracao do menu.
- Corrigir a justificativa para explicitar que a busca ainda nao esta pronta.
- Opcionalmente, baixar levemente a nota ou manter a nota com ressalva explicita de gap funcional no search.

#### Como fazer

- Trocar referencia a `IMenuProvider` por:
  - `AddYasamenMenu()`
  - `IMenuLoader`
  - `MenuService`
- Inserir nota textual:
  - "A navegacao hierarquica existe"
  - "a busca no AppMenu ainda nao esta implementada"

#### Onde alterar

- `.ai/ui-map/ui-map.md`
- Opcional: abrir item funcional em `.ai/a_fazer/` para busca do AppMenu

---

## GAP-05 - UI Map de Toast / Alert subestima a capacidade de posicionamento

### Escopo

- `.ai/ui-map/ui-map.md`
- `RoyalCode.Razor.Alerts/Internal/Notifications/*`
- `RoyalCode.Razor.Alerts/Components/Notify.cs`

### Problema

O mapeamento de `UIP-FEEDBACK-TOAST_ALERT` atribui nota alta corretamente, mas a justificativa diz que falta posicionamento configuravel e que o outlet fica "sempre no topo".

Isso nao esta alinhado ao codigo atual:

- o service agrupa notificacoes por `Placements`;
- o outlet renderiza por grupo de placement;
- o `Notify` expoe callback de configuracao do item, permitindo ajustar placement.

### Justificativa

Aqui o problema principal nao e a nota, e sim a interpretacao. Quem ler o documento pode concluir que a infra de placement ainda nao existe, quando ela ja existe.

### Opcoes

#### Opcao A - Corrigir apenas a justificativa

Pros:

- resolve o desvio principal;
- simples e rapido.

Contras:

- nao muda nada no produto.

#### Opcao B - Corrigir a justificativa e expandir o exemplo

Pros:

- melhora a documentacao;
- torna a capacidade mais visivel para futuros planejamentos.

Contras:

- exemplo fica um pouco maior.

### Recomendacao

Adotar a Opcao B.

### Plano de alteracao

#### O que fazer

- Ajustar a justificativa de `Toast / Alert`.
- Inserir exemplo com callback de configuracao setando `Placement`.

#### Como fazer

- Trocar o trecho "falta posicionamento configuravel" por algo como:
  - "ja existe suporte a placement por `Placements`, embora a API declarativa esteja concentrada na infraestrutura de notificacoes"
- Adicionar snippet com `Notify.Success(..., configure: item => item.Placement = ...)`.

#### Onde alterar

- `.ai/ui-map/ui-map.md`

---

## GAP-06 - UI Map de Form Field Group subestima a infraestrutura de formularios existente

### Escopo

- `.ai/ui-map/ui-map.md`
- `RoyalCode.Razor.Forms/Internal/Forms/*`
- `RoyalCode.Razor.Forms/Components/TextField.cs`

### Problema

O `ui-map` resume `UIP-INPUT-FORM_FIELD_GROUP` como algo coberto por `Stack`, `FieldText`, `FieldBadge` e `FieldAction`, com nota `3/10`.

Isso e insuficiente para o estado real da biblioteca. O projeto Forms ja possui:

- `FieldBase`
- `FieldGroup`
- `ControlGroup`
- `InputFieldBase<TValue>`
- `TextField`

Ou seja: a infraestrutura base do pattern existe. O que ainda falta nao e o pattern inteiro, mas um conjunto maior de inputs concretos.

### Justificativa

Do jeito atual, o `ui-map` transmite a ideia de que a biblioteca mal arranhou formularios, quando na verdade o framework de campo ja foi construido.

Isso afeta:

- priorizacao de roadmap;
- leitura de maturidade do pacote Forms;
- expectativa de esforco para novos campos.

### Opcoes

#### Opcao A - Recalibrar a nota e corrigir os componentes mapeados

Pros:

- melhora a acuracia do mapa;
- sem mudar codigo.

Contras:

- exige criterio editorial para a nova nota.

#### Opcao B - Manter a nota baixa ate existirem mais inputs concretos

Pros:

- favorece leitura conservadora.

Contras:

- esconde a maturidade da infraestrutura;
- mistura ausencia de componentes concretos com ausencia de pattern-base.

### Recomendacao

Adotar a Opcao A.

Sugestao:

- nota entre `5/10` e `6/10`;
- justificativa diferenciando:
  - "infraestrutura base do pattern existe"
  - "biblioteca ainda tem poucos campos concretos".

### Plano de alteracao

#### O que fazer

- Atualizar componentes mapeados.
- Reescrever justificativa.
- Ajustar a nota.

#### Como fazer

- Incluir no mapping:
  - `FieldGroup`
  - `ControlGroup`
  - `InputFieldBase<TValue>`
  - `TextField`
  - `FieldText`
  - `FieldBadge`
  - `FieldAction`
- Reescrever o texto para separar:
  - pattern-base;
  - biblioteca de inputs concretos.

#### Onde alterar

- `.ai/ui-map/ui-map.md`

---

## GAP-07 - Guide 03 descreve Commons como 100% nao visual, mas o pacote contem `Ripple`

### Escopo

- `.ai/guides/expand/commons-infrastructure.md`
- `RoyalCode.Razor.Commons/Ripple.razor`

### Problema

O guide 03 define `Commons` como projeto sem componentes visuais. Na pratica, o pacote expoe `Ripple.razor`.

Isto e um desvio pequeno, mas relevante para steering: alguem pode assumir que qualquer componente Razor em Commons viola a regra, quando o proprio projeto ja abre essa excecao.

### Justificativa

Nao e um problema arquitetural grave. E um problema de precisao do texto.

### Opcoes

#### Opcao A - Ajustar o texto do guide

Pros:

- suficiente para refletir o estado atual.

Contras:

- oficializa a excecao.

#### Opcao B - Mover `Ripple` para outro pacote

Pros:

- deixa Commons mais puro.

Contras:

- custo sem ganho funcional claro;
- pode quebrar organizacao ja estabilizada.

### Recomendacao

Adotar a Opcao A.

### Plano de alteracao

#### O que fazer

- Ajustar a descricao do Commons para algo como:
  - "nao contem componentes visuais de UI final, exceto utilitarios visuais de infraestrutura como `Ripple`".

#### Como fazer

- Atualizar a secao de proposito do projeto.
- Opcionalmente adicionar `Ripple` na lista de ativos do pacote.

#### Onde alterar

- `.ai/guides/expand/commons-infrastructure.md`

---
## Sequencia sugerida de execucao

1. Executar `GAP-07` como ajuste rapido inicial, se houver interesse em um warm-up de baixo risco.
2. Tratar `GAP-03` e decidir o destino do CSS isolation.
3. Reescrever `GAP-01`, porque o guide 08 e o mais arriscado como steering.
4. Se houver capacidade paralela, `GAP-01` e `GAP-03` podem rodar em paralelo, porque sao independentes.
5. Corrigir `GAP-02`, para estabilizar regras de estrutura e `_Imports`.
6. Atualizar o `ui-map` em lote (`GAP-04`, `GAP-05`, `GAP-06`), idealmente em uma unica sessao editorial.

---

## Resultado esperado apos as correcoes

- Os guides voltam a ser utilizaveis como steering files reais, nao apenas como resumos.
- O `ui-map` passa a refletir melhor a maturidade dos componentes existentes.
- A estrategia de estilos deixa de ficar ambigua.
- A criacao de novos componentes fica menos sujeita a divergencias arquiteturais.

