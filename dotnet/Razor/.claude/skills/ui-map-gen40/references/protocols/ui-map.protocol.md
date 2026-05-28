# Protocolo UI-MAP

## Regras do protocolo

[INSTRUÇÃO] Ler e seguir estritamente as regras de `/references/rules/kernel.rules.md`.

[INSTRUÇÃO] Ler e seguir estritamente as regras de `/references/rules/workflow.rules.md`.

[INSTRUÇÃO] Leia os arquivos como descrito na seção `Arquivos a ler`.

[INSTRUÇÃO] Execute em sequência as seções de 1 até 5, passo a passo de cada seção, sem pular.

[INSTRUÇÃO] Ler um arquivo de pattern por vez e fazer um por vez, sem paralelismo, sem batch, seguindo a ordem conforme instruções abaixo.

[INSTRUÇÃO] Ordem de execução por dependência composicional:
1. UIPs (UI-*) — todos primeiro;
2. PPs (PP-*) — após todos os UIPs concluídos;
3. SHPs (SHP-*) — por último, após todos os PPs concluídos.

[INSTRUÇÃO] Ordem dos grupos UIP:
1. UI-STRUCT (`LAYOUT_ZONE`, `STACK`, `GRID`, `SCROLLABLE`)
2. UI-FEEDBACK
3. UI-INTERACTION
4. UI-NAV
5. UI-ACTION
6. UI-SURFACE
7. UI-SYSTEM
8. UI-INPUT
9. UI-CONTENT
10. UI-DATA
11. UI-OVERLAY
12. UI-STRUCT (`SPLIT_PANEL`, `COLLAPSIBLE_SECTION`, `DOCKED_PANEL_SET`)

[INSTRUÇÃO] Os arquivos `{pattern}.ui-map.md` são destinados ao uso exclusivo da IA em outros projetos. Devem ser escritos para leitura da IA e serem autocontidos.

[INSTRUÇÃO] Regras para uso de subagente:
- quando usado subagente, ele sempre deve ler:
  - `/references/rules/kernel.rules.md` e seguir estritamente as regras;
  - `/references/rules/workflow.rules.md` e seguir estritamente as regras;
  - `/references/protocols/ui-map.protocol.md` e seguir estritamente as regras;
- outros arquivos podem ser lidos, conforme instrução ou necessidade;
- o subagente poderá escrever arquivos, atualizar e criar, conforme instruções dos protocolos;
- executar apenas conforme instrução do protocolo.

[INSTRUÇÃO] **Rubricas de Nota**: três rubricas distintas, cada uma para um campo específico do template.

**Rubrica A — Nota do componente Principal** (cobertura do pattern por um único componente).
Aplica-se ao campo `nota` em **Principais** (`pattern-ui-map.template.md`).

| Nota | Significado |
|------|-------------|
| 9–10 | Cobertura nativa — componente cobre o pattern com semântica, variantes e estados próprios |
| 7–8  | Cobertura alta — cobre o essencial; falta detalhe acessório (algumas variantes ou estados) |
| 5–6  | Cobertura parcial — cobre só parte; precisa composição ou estilos para completar |
| 3–4  | Cobertura baixa — componente relacionado mas com gaps estruturais |
| 1–2  | Vestigial — só primitivo aplicável com bastante trabalho |
| 0    | Ausente — não cobre |

**Rubrica B — Nota do componente em Composição** (utilidade composicional).
Aplica-se ao campo `nota` em **Composição** (`pattern-ui-map.template.md`).

| Nota | Significado |
|------|-------------|
| 9–10 | Encaixe natural — papel evidente; API suporta uso composicional sem fricção |
| 7–8  | Boa peça — fornece o que precisa; ajuste pequeno de prop ou estilo |
| 5–6  | Peça parcial — útil mas falta um aspecto (estado, evento, variante) |
| 3–4  | Peça limitada — funciona como apoio com restrições |
| 1–2  | Peça forçada — só serve com bastante coordenação manual |
| 0    | Não compõe — sem papel útil aqui |

**Rubrica C — Nota Geral do pattern** (implementabilidade na biblioteca como um todo: principal + composição + visual.map + estilos + código novo).
Aplica-se ao campo `nota geral` em **Decisão de uso** (`pattern-ui-map.template.md`) e à coluna `Nota` em `patterns.table.md`.

| Nota | Significado |
|------|-------------|
| 9–10 | Implementável direto — componente principal nativo cobre |
| 7–8  | Pouca composição — componente + variantes ou estilos da lib |
| 5–6  | Composição moderada — múltiplos componentes + estilos do visual.map |
| 3–4  | Adaptação significativa — composição rica + customização manual |
| 1–2  | Nova implementação — lib só fornece primitivos |
| 0    | Não implementável — GAP |

[INSTRUÇÃO] Consistência entre rubricas: a Nota Geral (C) considera as notas de componentes (A, B) somadas ao esforço de adaptação e aos recursos do `visual.map.md`. Não é fórmula rígida, mas serve de checagem — ex.: principal A=8 sem composição → C≈8; principal A=4 com duas peças de composição B=8 bem encaixadas → C pode chegar a 6.

[INSTRUÇÃO] Para o campo "Como usar":
- Deve ser código real, funcional e válido na tecnologia da biblioteca.
- Deve usar a linguagem visual e as regras de estilo definidas nos documentos gerados anteriormente (`visual.language.md`, `visual.map.md` quando existir).
- Deve demonstrar como implementar o pattern completo, não apenas instanciar o componente.
- Quando a cobertura é por composição: mostrar a composição completa.
- Quando há customização necessária: mostrar a customização aplicada.
- O código é o artefato mais valioso desta seção — é o que a skill screen-designer usará diretamente.

[INSTRUÇÃO] Exemplos não podem inventar API nem comportamento não observado nos componentes. Se um comportamento for inferido, marcar explicitamente como `[inferido]`.

## Arquivos a ler

- `pattern-ui-map.template.md` como guia de cobertura para `{pattern}.ui-map.md`;
- `patterns-table.template.md` como guia de cobertura para `patterns.table.md`;
- `patterns.list.md` para identificar cada pattern existente;
- `patterns.schema.md` para entender a semântica dos campos dos arquivos de patterns;
- `components.summary.md` para identificar os componentes da biblioteca;
- `visual.language.md` para seguir a linguagem visual da biblioteca;
- `visual.map.md` para saber como aplicar regras visuais;
- `state.yaml` para consultar etapa, gates, `library.platforms`, `current_item` e `status`.

## 1. Validação das entradas

1. crie a pasta `ui-map/` dentro do diretório de trabalho se não existir.

2. crie o `patterns.table.md` dentro de `ui-map/` se não existir
- use o `patterns-table.template.md` como template;
- atualize a tabela a cada iteração.

### GATE MAP.1

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- diretório `ui-map/` criado dentro do diretório de trabalho;
- `patterns.table.md` criado e persistido.

## 2. Geração dos UI-MAP

[INSTRUÇÃO] Somente após gate `MAP.1` satisfeito.

1. identificar e ordenar os patterns conforme as instruções `Ordem de execução` e `Ordem dos grupos UIP` definidas em `Regras gerais`.

2. para cada patterns, executar a subseção `2.1 Iteração`.

### 2.1 Iteração

[INSTRUÇÃO] quando disponível o trabalho com subagentes, usar subagente conforme regras definidas no protocolo.

[INSTRUÇÃO] a execução desta subseção só termina com o gate `MAP.2.1` satisfeito;

1. ler: o `components.summary.md`, `visual.language.md` e `visual.map.md` a cada iteração:
- quando executado por subagente, ler todos os arquivos base; 
- quando executado pelo agente principal, garantir que estão em contexto.

2. ler o arquivo do pattern, conforme link do `patterns.list.md`.

3. entender a proposta do pattern.

4. avaliar no `components.summary.md` quais os componentes alinhados como implementação do pattern ou que podem ser usados em composição para o pattern.

4.1. quando o pattern atual é PP-*:
- ler os `{UIP}.ui-map.md` listados em `UI Patterns tipicamente obrigatórios` do pattern (já produzidos em iterações anteriores);
- reutilizar notas, limitações e descrições consolidadas em vez de reavaliar do zero.

4.2. quando o pattern atual é SHP-*:
- ler os `{PP}.ui-map.md` listados em  `Compatibilidade Primária` do shell (já produzidos em iterações anteriores).
- reutilizar notas gerais consolidadas em vez de reavaliar do zero.

5. para cada componente candidato:
5.1. ler as evidências disponíveis em `library.sources` relacionadas ao componente — código, docs, stories, exemplos ou documentação web.
5.2. avaliar cada candidato:
- definir `papel`: principal | composição | descartado;
- definir `cobertura`;
- definir `limitações`;
- atribuir nota pela Rubrica A ou B;
- justificar com evidência concreta.

6. tratamento de ausência de cobertura:
- só executar se não há um componente fortemente alinhado em implementar o pattern;
- checar `library.platforms` contra `Plataformas aplicáveis` do pattern.
6.1. quando o pattern não é destinado à plataforma da biblioteca e não existe componente que implemente bem o pattern: registrar GAP `fora da plataforma` em `patterns.table.md`; não gerar `{pattern}.ui-map.md`.
6.2. quando o pattern é destinado à plataforma da biblioteca: avaliar composição com componentes classificados como `composição`, `visual.language.md` e `visual.map.md`.
6.3. se composição inviável: registrar GAP `sem cobertura viável` em `patterns.table.md`; gerar `{pattern}.ui-map.md` limitando `como usar` a uma implementação básica usando `visual.language.md` e `visual.map.md`.

7. produzir decisão de implementação quando não for GAP:
7.1. esforço de adaptação:
- `requisitos mal cobertos`:
  - avaliar os requisitos do pattern mal cobertos pelos componentes selecionados,
  - descrever o problema conforme instrução do template;
- tipo de adaptação:
  - componente principal implementa,
  - componentes principais + composição,
  - composição + estilos,
  - nova implementação com composição + estilos,
  - nova implementação + estilos;
- descrever de forma direta **o que precisa ser feito** para cobrir os GAPs dos componentes em relação aos requisitos do pattern;
- não dizer "esforço médio" — dizer o que concretamente precisa ser construído.
7.2. produzir `como usar` com código real e válido, e cenários derivados dos componentes:
- cenário mínimo obrigatório: um exemplo usando o componente principal cobrindo o pattern integral;
- cenários adicionais quando:
  - existem componentes de composição que alteram a montagem (cenário com composição),
  - o componente principal tem variantes que cobrem sub-tipos do pattern (cenário por variante relevante),
  - a implementação exige customização significativa (cenário mostrando a customização aplicada);
- não gerar cenários redundantes — se a composição não muda a estrutura do código, um único cenário basta.
7.3. registrar limitações e workarounds, avaliar:
- limitação funcional, visual, responsiva, de estado ou de API;
- workaround seguro quando existir.
7.4. definir `nota geral` (considerando componente que implementa, composições e montagem com estilos, temas, exemplos e documentação).
7.5. desenvolver `recomendação` e a `justificativa geral`.

8. escrever `{pattern}.ui-map.md` conforme regras:
- gerar quando não-GAP;
- com GAP `fora da plataforma`, não gerar;
- com GAP `sem cobertura viável` (pattern destinado à plataforma da biblioteca), gerar.

9. atualizar a linha do pattern em `patterns.table.md`.

10. atualizar `current_item` em `state.yaml` para o próximo pattern.

#### GATE MAP.2.1

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- arquivo `{pattern}.ui-map.md` criado quando não-GAP ou quando GAP com plataforma compatível;
- template seguido, regras do protocolo para o conteúdo seguidas;
- `Como usar` presente quando aplicável;
- GAP declarado quando não aplicável;
- linha atualizada em `patterns.table.md`;
- `current_item` atualizado no `state.yaml`.

### GATE MAP.2

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- todos os patterns processados na ordem definida em `Regras gerais` (UIPs → PPs → SHPs; e ordem intra-UIP);
- gate `MAP.2.1` satisfeito para cada pattern processado;
- `patterns.table.md` consolida todos os patterns: nenhuma linha duplicada, todo pattern presente em uma tabela de grupo OU na seção GAP;
- arquivos `{pattern}.ui-map.md` criados para todos patterns não-GAP;
- `current_item` em `state.yaml` vazio ou marcado como concluído.

## 3. Consolidação

[INSTRUÇÃO] Somente após gate `MAP.2` satisfeito.

[INSTRUÇÃO] quando disponível o trabalho com subagentes, usar subagente conforme regras definidas no protocolo e as seguintes regras:
- o subagente valida **um grupo de patterns** por vez (ex: todos UI-FEEDBACK, ou todos PPs);
- executar os passos 1 a 5 apenas como auditoria no grupo atribuído;
- verbos como corrigir, reavaliar, ajustar e registrar devem ser interpretados como achados a reportar;
- não alterar `{pattern}.ui-map.md`, `patterns.table.md`, `state.yaml` ou outros artefatos;
- retornar achados objetivos com `arquivo`, `achado`, `impacto` e `ação sugerida`;
- o agente principal consolida achados inter-grupo, aplica correções necessárias e executa a verificação de cobertura final;
- quando o volume de achados inviabilizar consolidação em lote, o agente principal pode aplicar correções por grupo e revalidar coerência global antes do gate `MAP.3`.

1. verificar coerência composicional:
- para cada PP, validar que as responsabilidades dos `UI Patterns tipicamente obrigatórios` estão cobertas pela composição do PP;
- quando o PP declarar alternativas (`A ou B`), exigir cobertura de ao menos uma alternativa viável, não presença literal de todas;
- quando um UIP obrigatório estiver em GAP, conferir que a ausência foi refletida na nota, limitações e justificativa do PP;
- para cada SHP, validar que os PPs de `Compatibilidade Primária` foram considerados na decisão do SHP: usados quando viáveis, rebaixados quando secundários, ou descartados com justificativa quando inviáveis;
- não interpretar `Compatibilidade Primária` como obrigação de compor todos os PPs simultaneamente;
- corrigir inconsistências encontradas ou registrar GAP quando a cobertura estrutural não puder ser sustentada.

2. verificar coerência de notas:
- comparar Nota Geral (C) de cada PP com as notas dos UIPs que compõe;
- comparar Nota Geral (C) de cada SHP com as notas dos PPs que compõe;
- quando a discrepância for grande, reavaliar a nota ou ajustar a justificativa.

3. verificar vocabulário:
- nomes de componentes batem com `components.summary.md`;
- ids de pattern batem com os arquivos de pattern;
- tokens, classes e recursos visuais mencionados batem com `visual.map.md`;
- nenhum nome inventado.

4. auditar exemplos `Como usar` por amostragem:
- selecionar um subconjunto de ui-maps de cada grupo;
- conferir props, eventos, slots contra `components.summary.md`;
- garantir que inferências estão marcadas como `[inferido]`.

5. verificar GAPs em `patterns.table.md`:
- cada GAP tem `Tipo` (`fora da plataforma` ou `sem cobertura viável`);
- cada GAP tem `Descrição`, `Componentes` (avaliados ou `nenhum`) e `Justificativa`.

6. verificar cobertura final em `patterns.table.md`:
- 100% dos patterns de `patterns.list.md` presentes em tabela de grupo ou seção GAP;
- nenhuma linha duplicada.

### GATE MAP.3

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- coerência composicional verificada;
- coerência de notas verificada;
- vocabulário consistente com as fontes;
- exemplos auditados por amostragem;
- GAPs classificados e justificados;
- cobertura 100% sem duplicação.

## 4. Revisão

[INSTRUÇÃO] Somente após gate `MAP.3` satisfeito.

[INSTRUÇÃO] quando disponível o trabalho com subagentes, usar subagente conforme regras definidas no protocolo e as seguintes regras:
- o subagente executa a subseção `4.1 Iteração da revisão` para **um único** `{pattern}.ui-map.md`;
- pode aplicar correções locais diretamente no `{pattern}.ui-map.md` atribuído;
- não alterar `patterns.table.md`, `state.yaml`, outros ui-maps, nota geral ou cascata;
- quando identificar que a nota geral parece incorreta, registrar achado global com nota atual, nota sugerida e justificativa, sem aplicar;
- retornar achados globais com `arquivo`, `achado`, `impacto` e `ação sugerida`;
- o agente principal consolida relatórios, decide alterações de nota, atualiza `patterns.table.md` e aplica cascata quando necessário.

1. para cada `{pattern}.ui-map.md`, executar a subseção `4.1 Iteração da revisão`.

### 4.1 Iteração da revisão

1. revisar como leitor externo (outra IA sem acesso ao repositório):
- marcar e remover trechos com path interno, link relativo ou referência a artefato não autocontido;
- garantir que o documento se sustenta apenas com `visual.language.md` e `visual.map.md` como dependentes externos.

2. concretizar `esforço de adaptação`:
- rejeitar bullets genéricos ("esforço médio", "ajustar estilos");
- cada bullet deve dizer **o que** construir.

3. concretizar `limitações`:
- cada limitação deve ter tipo (funcional, visual, responsiva, estado ou API);
- workaround presente quando existir.

4. validar tecnicamente os exemplos `Como usar`:
- conferir props, eventos, slots e tokens contra `components.summary.md` e `visual.map.md`;
- marcar com `[inferido]` qualquer comportamento não observado.

5. checar consistência entre `recomendação` e `nota geral`:
- nota 9–10 → `usar direto`;
- nota 7–8 → `usar direto` ou `usar por composição`;
- nota 5–6 → `usar por composição` ou `usar com adaptação`;
- nota 3–4 → `usar com adaptação` ou `usar apenas como apoio`;
- nota 1–2 → `usar apenas como apoio` ou `evitar`;
- nota 0 → `evitar` (e pattern deve estar em GAP).

6. aplicar correções:
- corrigir trechos identificados nos passos anteriores;
- quando alterar nota de UIP, reavaliar PPs que o reusaram;
- quando alterar nota de PP, reavaliar SHPs que o reusaram;
- atualizar `patterns.table.md` quando a nota geral mudar.

### GATE MAP.4

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- revisão externa simulada feita em todos ui-maps;
- esforço e limitações concretizados;
- exemplos validados tecnicamente;
- recomendação coerente com nota geral;
- correções aplicadas;
- dependentes reavaliados quando nota mudou.

## 5. Finalização

[INSTRUÇÃO] Somente após gate `MAP.4` satisfeito.

1. atualizar estado da `task` do `state.yaml` como etapa concluída.

2. apresentar ao humano um resumo do que foi feito na etapa:
- total de patterns processados por grupo;
- total de GAPs por tipo;
- distribuição da Nota Geral por faixa;
- principais lacunas registradas.

3. delegar ao workflow a execução da etapa 4 do fluxo `gerar-ui-map`.

### GATE MAP.FINAL

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- todas seções executadas em ordem: 1, 2, 3, 4, 5.
- todos gates internos satisfeitos: `MAP.1`, `MAP.2`, `MAP.3`, `MAP.4`.
- `state.yaml` atualizado com stage concluído e `next_action` apontando para `create-samples`.
