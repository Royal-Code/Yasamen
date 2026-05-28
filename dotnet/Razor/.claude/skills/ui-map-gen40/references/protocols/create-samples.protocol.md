# Protocolo create samples

## Regras do protocolo

[INSTRUÇÃO] Ler e seguir estritamente as regras de `/references/rules/kernel.rules.md`.

[INSTRUÇÃO] Ler e seguir estritamente as regras de `/references/rules/workflow.rules.md`.

[INSTRUÇÃO] Leia os arquivos como descrito na seção `Arquivos a ler`.

[INSTRUÇÃO] Execute em sequência as seções de 1 até 4, passo a passo de cada seção, sem pular.

[INSTRUÇÃO] Ler um componente por vez e fazer um por vez, sem paralelismo, sem batch. Ordem de iteração:
- agrupar os componentes pelo `grupo` declarado em `components.summary.md`;
- processar grupo a grupo, na ordem em que aparecem no summary;
- dentro de cada grupo, processar na ordem do summary.

[INSTRUÇÃO] Os arquivos `{component}.sample.md` são destinados ao uso exclusivo da IA em outros projetos. Devem ser escritos para leitura da IA e serem autocontidos.

[INSTRUÇÃO] Componente sem pattern em `patterns.table.md`:
- componente utilitário que aparece em exemplos de outros samples (ex: Skeleton, Portal, Divider) recebe sample com `implementa: -` e `compõe: {PATTERN_IDs}` listados em `Composição` nos `{pattern}.ui-map.md` que referenciam o componente;
- componente público/documentado sem relação identificável com patterns recebe sample mínimo (contrato + 1 exemplo + API relevante) e marca `implementa: -`, `compõe: -`;
- componente interno, experimental, privado ou sem API pública clara deve ser registrado como pendência/auxiliar e não recebe sample normal;
- não classificar como GAP; GAP é conceito de pattern, não de componente.

[INSTRUÇÃO] Versão da biblioteca:
- não registrar versão no header do sample por padrão;
- a rastreabilidade de versão fica em `state.yaml` e em `manifest.md`;
- registrar versão localmente no sample apenas quando a API demonstrada depender de versão específica (campo opcional `**Versão**` no contrato de uso, com a justificativa).

[INSTRUÇÃO] Regras para uso de subagente:
- quando usado subagente, ele sempre deve ler:
  - `/references/rules/kernel.rules.md` e seguir estritamente as regras;
  - `/references/rules/workflow.rules.md` e seguir estritamente as regras;
  - `/references/protocols/create-samples.protocol.md` e seguir estritamente as regras;
- outros arquivos podem ser lidos, conforme instrução ou necessidade;
- o subagente poderá escrever arquivos, atualizar e criar, conforme instruções dos protocolos;
- executar apenas conforme instrução do protocolo.

[INSTRUÇÃO] Para o código nos exemplos:
- Deve ser código real, funcional e válido na tecnologia da biblioteca;
- Deve usar a linguagem visual e as regras de estilo definidas em `visual.language.md` e `visual.map.md`;
- API real apenas — não inventar props, eventos, slots ou métodos;
- Comportamento inferido deve ser marcado como `[inferido]`;
- Sem paths internos do repositório ou links relativos a arquivos da biblioteca;
- Dados não-triviais mas controlados (2-4 itens; tipos simples com 3-5 campos);
- Tipagem inline curta quando ajuda a entender o shape; não criar types separados para dados mock;
- Imports explícitos no contrato de uso; repetir no exemplo quando o snippet precisar ser standalone ou quando o import for diferente;
- Composição: mostrar quando o pattern exige; não forçar quando é uso isolado.

[INSTRUÇÃO] Tamanho proporcional do sample (heurística de revisão, não gate hard):
- **componente simples** (1-3 patterns, props óbvias): 1-3 exemplos, API em bullets curtos, sem tabela por padrão; referência ~40-60 linhas;
- **componente médio** (4-6 patterns, ou props com opacidade média): 2-4 exemplos, eventos/estados relevantes, setup quando existir; referência ~60-100 linhas;
- **componente complexo** (7+ patterns, ou shapes complexos, ou interações não aditivas entre props): 3-6 exemplos, pode usar tabela para API crítica, defaults importantes, combinações frágeis; referência ~100-150 linhas.

[INSTRUÇÃO] Gatilhos para expandir API/tabelas no sample:
- prop com default que muda comportamento significativo;
- props que interagem de forma não aditiva;
- shape complexo cujo uso correto não é óbvio pelo exemplo;
- comportamento varia por contexto não visível no type (ex: inline vs portal);
- docs/stories insuficientes ou divergentes do código.

[INSTRUÇÃO] Gatilhos para reduzir:
- componente simples com poucos patterns;
- exemplo já demonstra toda API relevante;
- limitações já estão no ui-map e não afetam uso direto;
- tabela repetiria props óbvias visíveis no código.

[INSTRUÇÃO] Distinção entre seções de cuidado no sample:
- **Regras rápidas → "Evite quando"**: cenários de escolha de componente; quando outro componente é a opção correta. Sempre indicar alternativa concreta. Ex: "evite usar Badge como botão; use IconButton";
- **Limites e combinações frágeis**: comportamentos do próprio componente que falham, truncam ou exigem workaround. Ex: "`children={0}` não renderiza"; "sem `inline`, renderiza por portal em document.body";
- não duplicar conteúdo entre as duas seções.

[INSTRUÇÃO] Não repetir conteúdo já presente em outros artefatos:
- justificativas extensas do `{pattern}.ui-map.md` não entram no sample;
- descrição geral do componente do `components.summary.md` não entra no sample;
- tokens e regras visuais detalhadas do `visual.map.md` não entram no sample (referenciar).

[INSTRUÇÃO] Não inventar combinações frágeis, anti-padrões ou limitações sem evidência no código, docs, stories ou exemplos reais.

## Arquivos a ler

- `component-sample.template.md` como guia de cobertura para `{component}.sample.md`;
- `components.summary.md` para identificar e consumir os componentes;
- `patterns.table.md` para identificar quais patterns cada componente atende;
- `{pattern}.ui-map.md` (dos patterns que o componente atende) para reusar exemplos e contexto;
- `visual.language.md` para seguir a linguagem visual da biblioteca;
- `visual.map.md` para aplicar regras visuais;
- `state.yaml` para consultar etapa, gates, `library.sources`, `current_item` e status.

## 1. Validação das entradas

1. crie a pasta `samples/` dentro do diretório de trabalho se não existir.

2. identificar e ordenar os componentes a partir de `components.summary.md`:
- agrupar por `grupo` declarado no summary;
- manter a ordem do summary dentro de cada grupo;
- produzir a lista linear de iteração (grupo a grupo, na ordem do summary).

3. gravar `current_item` em `state.yaml` apontando para o primeiro componente.

### GATE CS.1

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- diretório `samples/` criado dentro do diretório de trabalho;
- lista ordenada de componentes identificada (por grupo, na ordem do summary);
- `current_item` em `state.yaml` apontando para o primeiro componente.

## 2. Geração dos samples

[INSTRUÇÃO] Somente após gate `CS.1` satisfeito.

1. para cada componente, executar a subseção `2.1 Iteração`.

### 2.1 Iteração

[INSTRUÇÃO] quando disponível o trabalho com subagentes, usar subagente conforme regras definidas no protocolo.

[INSTRUÇÃO] a execução desta subseção só termina com o gate `CS.2.1` satisfeito.

[INSTRUÇÃO] O sample deve ser produzido por **síntese de duas lentes**, não por preenchimento mecânico de seções. A ordem importa: a **Lente 1 (uso real)** precisa estar completa antes de a **Lente 2 (adequação)** decidir cenários, para impedir inventário de API. As duas lentes podem reusar a mesma leitura das fontes (uma passada só sobre `library.sources`), desde que a **decisão** sobre quais cenários incluir só ocorra na Lente 2.

1. ler `components.summary.md`, `visual.language.md` e `visual.map.md` a cada iteração:
- quando executado por subagente, ler todos os arquivos base;
- quando executado pelo agente principal, garantir que estão em contexto.

2. ler a seção do componente em `components.summary.md`.

3. **Lente 1 — Uso real implementável**. Objetivo: entender como o componente realmente funciona em código, antes de decidir o que mostrar.
3.1. ler as evidências disponíveis em `library.sources` relacionadas ao componente: código, docs, stories, exemplos, documentação web.
3.2. identificar **entrada pública**: import, tag, namespace, módulo ou pacote.
3.3. identificar **setup necessário**: provider, tema, CSS global, namespace, plugin, serviço ou registro de assets. Marcar `-` se nada além do import for necessário.
3.4. levantar API real do componente, foco no que será usado ou é crítico:
- props/parâmetros;
- eventos/comandos e payloads;
- slots/children/conteudo aceitos;
- estados, variantes e defaults importantes.
3.5. identificar **limites e combinações frágeis** com evidência (bugs reais, defaults não óbvios, props que falham juntas, truncamentos, comportamento de portal).
3.6. marcar como `[inferido]` qualquer comportamento não observado diretamente nas fontes.

4. **Lente 2 — Adequação a patterns e fronteiras**. Objetivo: decidir quais cenários o sample precisa mostrar.
4.1. identificar em `patterns.table.md` todos os patterns onde o componente aparece (colunas `Implementam` ou `Compõe`).
4.2. ler cada `{pattern}.ui-map.md` correspondente para entender o papel do componente no pattern.
4.3. decidir cenários necessários:
- um exemplo por pattern, salvo quando patterns puderem ser agrupados em um único exemplo (caso em que o título declara todos os PATTERN_IDs cobertos);
- exemplos adicionais somente quando uma propriedade, estado, evento, default ou combinação frágil for crítica e não estiver clara nos exemplos por pattern;
- componente sem pattern segue a regra de `Componente sem pattern` em `Regras do protocolo`.
4.4. identificar **alternativas** (quando NAO usar este componente; qual usar) com base em fronteiras semanticas observadas.
4.5. não repetir justificativas do `{pattern}.ui-map.md`.

5. **Síntese — produzir `{component}.sample.md`** em `samples/`, seguindo `component-sample.template.md`:
5.1. contrato de uso curto: entrada pública, grupo, propósito, patterns (`implementa`/`compõe`), setup;
5.2. regras rápidas: `Use para`, `Evite quando` (com alternativa concreta), `Cuidado` (limite ou default importante);
5.3. exemplos por pattern (ou grupo de patterns), cada um com frase instrutiva curta + código real + `API usada` (quando ajuda o scan) + `Nota` (quando há quirk ou inferido);
5.4. API relevante proporcional à complexidade/opacidade do componente — declarar apenas o que está nos exemplos OU é crítico para evitar uso incorreto. Não catalogar API completa por padrão;
5.5. limites e combinações frágeis de alto impacto, quando houver evidência;
5.6. defaults importantes apenas quando mudarem comportamento relevante; omitir a seção se não houver.

6. atualizar `current_item` em `state.yaml` para o próximo componente.

#### GATE CS.2.1

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- arquivo `{component}.sample.md` criado e persistido seguindo `component-sample.template.md`;
- contrato de uso preenchido (entrada pública, grupo, propósito, patterns, setup);
- **cobertura de patterns**: todo PATTERN_ID declarado em `implementa` e em `compõe` do contrato tem ao menos um exemplo que o referencia (isoladamente ou agrupado no título do exemplo);
- API relevante declarada conforme complexidade/opacidade do componente — suficiente para validar os exemplos sem inventar API;
- código real e válido nos exemplos, sem invencão de API; comportamento não observado marcado como `[inferido]`;
- nenhum path interno ou link relativo a arquivos da biblioteca;
- proporcionalidade respeitada (não expandiu API/tabelas sem gatilho, não reduziu abaixo da cobertura de patterns);
- `Regras rápidas → Evite quando` e `Limites e combinações frágeis` não duplicam conteúdo;
- `current_item` atualizado no `state.yaml`.

### GATE CS.2

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- todos os componentes de `components.summary.md` processados na ordem definida (por grupo, na ordem do summary);
- gate `CS.2.1` satisfeito para cada componente;
- arquivos `{component}.sample.md` criados para todos os componentes;
- `current_item` em `state.yaml` vazio ou marcado como concluído.

## 3. Revisão

[INSTRUÇÃO] Somente após gate `CS.2` satisfeito.



1. para cada `{component}.sample.md`, executar a subseção `3.1 Iteração da revisão`.

### 3.1 Iteração da revisão

[INSTRUÇÃO] Quando disponível o trabalho com subagentes, usar subagente conforme regras definidas no protocolo e as seguintes regras:
- o subagente deve executar **um único** `{component}.sample.md`;
- ler `components.summary.md` e `visual.map.md` para validar API e exemplos;
- pode corrigir somente o `{component}.sample.md` atribuído;
- não alterar `state.yaml`, ui-maps, blueprints, outros samples ou outros artefatos;
- quando identificar impacto fora do sample atribuído, registrar achado global com `arquivo`, `achado`, `impacto` e `ação sugerida`;
- o agente principal consolida relatórios e verifica se correções em um sample afetam exemplos de outros samples que referenciam o mesmo componente.

1. revisar como leitor externo (outra IA sem acesso ao repositório):
- marcar e remover trechos com path interno, link relativo ou referência a artefato não autocontido;
- garantir que o documento se sustenta apenas com `visual.language.md` e `visual.map.md` como dependentes externos.

2. validar tecnicamente a API:
- props, eventos, slots, estados e defaults batem com `components.summary.md` e com as fontes em `library.sources`;
- comportamentos inferidos marcados com `[inferido]`;
- nenhuma combinação frágil ou limitação sem evidência.

3. validar exemplos e cobertura:
- todo PATTERN_ID em `implementa` e `compõe` está coberto por algum exemplo (isolado ou agrupado);
- exemplos agrupados declaram todos os PATTERN_IDs no título;
- usam tokens, classes e recursos visuais conforme `visual.map.md`;
- código compilável ou executável na stack da biblioteca;
- dados não-triviais mas controlados; imports explícitos.

4. validar proporcionalidade e separação de seções:
- tamanho coerente com a complexidade/opacidade do componente (heurística, não gate hard);
- API não catalogada além do necessário;
- `Evite quando` (escolha de componente) não duplica `Limites e combinações frágeis` (comportamento do próprio componente).

5. aplicar correções:
- correções locais no `{component}.sample.md` revisado;
- quando a correção revelar impacto em outro sample, em `{pattern}.ui-map.md` ou em blueprint futuro, registrar achado global (`arquivo`, `achado`, `impacto`, `ação sugerida`) sem alterar os outros artefatos;
- agente principal consolida os achados globais e decide se outro sample precisa ser revisitado.

### GATE CS.3

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- revisão externa simulada feita em todos os samples;
- API validada contra `components.summary.md` e `library.sources`;
- todos PATTERN_IDs declarados em cada sample cobertos por exemplos;
- proporcionalidade verificada; seções não duplicam conteúdo;
- correções locais aplicadas;
- achados globais consolidados pelo agente principal e revisitados quando necessário.

## 4. Finalização

[INSTRUÇÃO] Somente após gate `CS.3` satisfeito.

1. atualizar estado da `task` do `state.yaml` como etapa concluída.

2. apresentar ao humano um resumo do que foi feito na etapa:
- total de componentes processados por grupo;
- total de exemplos gerados;
- componentes sem patterns identificados (declarados com `implementa: -`/`compõe: -`);
- componentes utilitários que entraram com `implementa: -` e `compõe: {PATTERN_IDs}`;
- principais achados globais consolidados na revisão.

3. delegar ao workflow a execução da etapa 5 do fluxo `gerar-ui-map`.

### GATE CS.FINAL

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- todas seções executadas em ordem: 1, 2, 3, 4.
- todos gates internos satisfeitos: `CS.1`, `CS.2`, `CS.3`.
- `state.yaml` atualizado com stage concluído e `next_action` apontando para `patterns-blueprints`.
