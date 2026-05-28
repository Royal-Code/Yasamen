# Protocolo corporate rules

## Regras do protocolo

[INSTRUÇÃO] Ler e seguir estritamente as regras de `/references/rules/kernel.rules.md`.

[INSTRUÇÃO] Ler e seguir estritamente as regras de `/references/rules/workflow.rules.md`.

[INSTRUÇÃO] Leia os arquivos como descrito na seção `Arquivos a ler`.

[INSTRUÇÃO] Execute em sequência as seções de 1 até 5, passo a passo de cada seção, sem pular.

[INSTRUÇÃO] Os arquivos `rules/*.rules.md` são destinados ao uso exclusivo da IA em outros projetos. Devem ser escritos como regras executáveis, não como documentação explicativa.

[INSTRUÇÃO] Não criar rules que dupliquem `visual.language.md`, `visual.map.md`, `components.summary.md`, samples, ui-map ou blueprints.

[INSTRUÇÃO] Não inventar regra corporativa sem evidência nos fontes ou confirmação explícita do humano.

[INSTRUÇÃO] Não incluir paths, URIs ou links do repositório analisado nos arquivos de rules.

[INSTRUÇÃO] O formato de cada rule é flexível. Use o shape necessário para a tecnologia, plataforma e assunto, mantendo linguagem direta, curta e operacional.

## Arquivos a ler

- `state.yaml` para consultar etapa, fontes, plataforma, família técnica, `current_item` e retomada;
- `components.summary.md` para identificar stack, dependências, componentes, papéis e convenções;
- `structure.md` para identificar arquitetura, organização de projeto, naming, imports, testes, exemplos e bootstrap;
- `ui-guide.md` para regras técnicas de estilos, temas, resources ou presentation;
- `visual.language.md` e `visual.map.md` para evitar duplicação e identificar fronteira entre regra corporativa e linguagem visual;
- `patterns.table.md`, `{pattern}.ui-map.md`, `{component}.sample.md` e `{pattern}.blueprint.md` quando a rule envolver uso operacional de patterns, componentes ou receitas;
- fontes declaradas em `state.yaml.library.sources` para procurar docs, configs, templates, steerings, exemplos e convenções oficiais.

## Regras de escrita das rules

[INSTRUÇÃO] Escrever rules como obrigação, proibição ou sequência executável:
- use frases como `Use`, `Não use`, `Sempre`, `Nunca`, `Antes de`, `Depois de`, `Quando`;
- evite justificativa longa, história, intenção vaga ou texto de onboarding humano;
- prefira bullets, checklists curtos e exemplos de código quando a rule envolver implementação;
- declare consequência operacional quando a regra evita erro recorrente;
- marque `[proposta]` somente quando o humano aprovar uma regra sem evidência completa.

[INSTRUÇÃO] Cada rule deve conter somente seções úteis para aplicação. Seções comuns:
- `## Quando aplicar`;
- `## Regras`;
- `## Sequência`;
- `## Exemplos`;
- `## Anti-padrões`;
- `## Consequência`.

[INSTRUÇÃO] `rules/corporate.rules.md` é índice e roteador:
- lista rules aprovadas e recusadas;
- informa quando carregar cada rule;
- declara regras corporativas transversais;
- declara ordem recomendada de leitura por tipo de tarefa, quando existir.

[INSTRUÇÃO] `rules/{rule}.rules.md` é rule específica:
- uma decisão corporativa por arquivo;
- pode agrupar sub-regras somente quando elas são inseparáveis na execução;
- deve ser autocontida para a IA aplicar sem consultar fontes internas do repositório analisado.

## 1. Validação das entradas

1. Ler `state.yaml` e confirmar que a etapa atual é `corporate-rules` ou foi delegada pelo workflow.

2. Criar pasta `rules/` no diretório de trabalho se não existir.

3. Verificar retomada:
- se `rules/corporate.rules.md` já existir, ler antes de continuar;
- se houver rules individuais já geradas, preservar e atualizar somente quando a seleção humana ou revisão exigir.

### GATE CR.1

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- etapa autorizada pelo workflow;
- pasta `rules/` criada;
- retomada verificada.

## 2. Descoberta de candidatos

[INSTRUÇÃO] Somente após gate `CR.1` satisfeito.

[INSTRUÇÃO] Procurar rules por lentes. As lentes são orientação de busca, não catálogo fixo.

1. **Lente 1 — Fonte oficial e recorrência**
- procurar docs, configs, templates, steerings, exemplos, stories, testes e código repetido;
- identificar decisões aplicadas em mais de um lugar ou declaradas como padrão oficial;
- descartar achado isolado sem evidência de regra.

2. **Lente 2 — Tarefa da IA consumidora**
- identificar decisões que outra IA precisa aplicar ao criar projeto, tela, rota, API, formulário, CRUD, dashboard, teste, mock, permissão ou integração;
- priorizar regras que evitam código incorreto, componente errado, API errada, arquitetura errada ou fluxo operacional fora do padrão.

3. **Lente 3 — Fronteira com artefatos existentes**
- não transformar linguagem visual em rule;
- não repetir API de componente já coberta por sample;
- não repetir mapping de pattern já coberto por ui-map ou blueprint;
- criar rule apenas quando houver decisão corporativa acima desses artefatos.

4. **Lente 4 — Eixos candidatos**
- arquitetura e organização de código;
- bootstrap e criação de projeto;
- padrões de API, data fetching, cache, mappers e services;
- autenticação, autorização e permissões;
- roteamento, navegação e estado em URL;
- estado local/global e limites de responsabilidade;
- formulários, filtros e validação;
- CRUD, dashboard e telas operacionais recorrentes;
- feedback, erro, loading e confirmação;
- testes, mocks, fixtures e dados de desenvolvimento;
- acessibilidade, i18n, permissões de plataforma, offline ou lifecycle quando forem regras corporativas reais.

5. Para cada candidato, registrar internamente:
- nome sugerido;
- eixo;
- evidência ou confirmação humana necessária;
- valor para a IA consumidora;
- risco se não virar rule;
- se compete com outro artefato.

### GATE CR.2

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- fontes oficiais e recorrências verificadas;
- eixos aplicáveis explorados;
- fronteira com visual language, visual map, samples, ui-map e blueprints verificada;
- candidatos registrados com evidência, valor e risco.

## 3. Seleção humana

[INSTRUÇÃO] Somente após gate `CR.2` satisfeito.

1. Apresentar candidatos ao humano sem tabela.

2. Para cada candidato, escrever um parágrafo curto com:
- nome sugerido;
- regra que seria criada;
- evidência ou origem;
- por que ajuda outra IA;
- risco de gerar ou não gerar.

3. Perguntar ao humano:
- quais rules devem ser geradas;
- quais devem ser recusadas;
- se há decisão corporativa adicional não detectada;
- se quer validação individual ou em lote.

4. Registrar seleção, recusas, pendências e modo de entrega.

### GATE CR.3

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- candidatos apresentados ao humano em texto, sem tabela;
- humano escolheu rules aprovadas e recusadas;
- decisões adicionais do humano registradas;
- modo de entrega definido;
- nenhuma pendência bloqueante de escopo.

## 4. Geração das rules

[INSTRUÇÃO] Somente após gate `CR.3` satisfeito.

1. Criar ou atualizar `rules/corporate.rules.md`:
- incluir roteamento do índice;
- listar rules aprovadas, recusadas e pendentes;
- registrar regras transversais obrigatórias, recomendadas e condicionais quando existirem;
- declarar ordem recomendada por tipo de tarefa quando houver sequência operacional.

2. Para cada rule aprovada, uma por vez:
- gravar `current_item` no `state.yaml`;
- reler fontes relevantes e artefatos relacionados;
- criar `rules/{rule}.rules.md`;
- escrever como instrução executável;
- omitir seção de fontes;
- não referenciar paths, URIs ou links internos;
- usar exemplos reais quando a rule envolver código;
- registrar anti-padrões quando evitarem erro provável da IA.

3. Se validação for individual:
- apresentar cada rule ao humano antes de seguir para a próxima;
- aplicar ajustes solicitados.

4. Se validação for em lote:
- gerar todas as aprovadas;
- apresentar resumo consolidado ao humano;
- aplicar ajustes solicitados.

5. Atualizar `rules/corporate.rules.md` com status final.

6. Limpar `current_item` no `state.yaml`.

### GATE CR.4

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- `rules/corporate.rules.md` criado e persistido;
- cada rule aprovada criada em `rules/{rule}.rules.md`;
- rules recusadas não foram geradas;
- cada rule é executável, autocontida e sem fonte interna exposta;
- nenhuma rule duplica visual language, visual map, sample, ui-map ou blueprint;
- exemplos de código são reais e válidos quando aplicáveis;
- validação humana feita conforme modo escolhido;
- `current_item` limpo no `state.yaml`.

## 5. Revisão e finalização

[INSTRUÇÃO] Somente após gate `CR.4` satisfeito.

1. Revisar como IA consumidora:
- cada rule tem condição de aplicação clara;
- cada rule informa o que fazer e o que não fazer;
- o índice ajuda a escolher quais rules carregar;
- rules não dependem de path interno, link ou memória do repositório analisado;
- rules não conflitam entre si nem com os artefatos anteriores.

2. Corrigir inconsistências locais.

3. Atualizar `state.yaml`:
- etapa `corporate-rules` concluída;
- `next_action` apontando para `finalize`.

4. Apresentar resumo ao humano:
- total de candidates;
- total de rules geradas;
- rules recusadas;
- pendências ou decisões não resolvidas.

### GATE CR.FINAL

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- todas seções executadas em ordem: 1, 2, 3, 4, 5;
- gates `CR.1`, `CR.2`, `CR.3`, `CR.4` satisfeitos;
- `rules/corporate.rules.md` criado e persistido;
- rules aprovadas criadas e persistidas;
- rules recusadas registradas no índice;
- revisão final realizada;
- `state.yaml` atualizado com etapa concluída e próxima ação `finalize`.
