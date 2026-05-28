# Protocolo patterns orientations

## Regras do protocolo

[INSTRUÇÃO] Ler e seguir estritamente as regras de `/references/rules/kernel.rules.md`.

[INSTRUÇÃO] Ler e seguir estritamente as regras de `/references/rules/workflow.rules.md`.

[INSTRUÇÃO] Leia os arquivos como descrito na seção `Arquivos a ler`.

[INSTRUÇÃO] Execute em sequência as seções de 1 até 5, passo a passo de cada seção, sem pular.

[INSTRUÇÃO] O arquivo `patterns.orientations.md` é destinado ao uso exclusivo da IA em outros projetos. Deve ser escrito como orientação operacional curta para escolha de patterns.

[INSTRUÇÃO] `patterns.orientations.md` não decide se um pattern é semanticamente correto. Ele ordena preferência entre patterns semanticamente adequados à intenção de tela.

[INSTRUÇÃO] Não substituir um pattern correto por outro melhor coberto apenas por conveniência técnica da biblioteca.

[INSTRUÇÃO] Quando o pattern correto tiver baixa cobertura, classificar como condicional, via blueprint, com adaptação ou evitar como escolha padrão.

[INSTRUÇÃO] Não criar orientação para pattern não analisado em `patterns.table.md`.

[INSTRUÇÃO] Não repetir API real de componentes, código de samples, conteúdo de blueprints, regras visuais ou regras corporativas.

[INSTRUÇÃO] Componentes podem ser mencionados apenas como apoio à decisão, nunca como conteúdo principal do artefato.

[INSTRUÇÃO] `Abrir depois` lista artefatos do ui-map que a IA consumidora deve consultar quando precisar detalhar a decisão, confirmar uso real ou implementar aquela intenção de tela. Não significa leitura obrigatória em todo uso.

[INSTRUÇÃO] `Abrir depois` deve apontar apenas para artefatos gerados do ui-map, como `ui-map/{pattern}.ui-map.md`, `samples/{component}.sample.md`, `patterns-blueprints/{pattern}.blueprint.md`, `rules/*.rules.md`, `visual.language.md` ou `visual.map.md`.

## Arquivos a ler

- `patterns-orientations.template.md` como guia de cobertura para `patterns.orientations.md`;
- `patterns.list.md` para validar IDs canônicos;
- `patterns.table.md` para identificar cobertura, nota geral, montagem e GAPs dos patterns;
- `{pattern}.ui-map.md` quando o pattern for relevante para preferência, combinação, uso com blueprint ou evitar;
- `blueprints.table.md` para identificar gaps solucionáveis, patterns cobertos por blueprint e patterns que não devem gerar orientação forte;
- `{pattern}.blueprint.md` somente quando a orientação depender de condição concreta do blueprint;
- `visual.language.md` para avaliar naturalidade visual da biblioteca;
- `visual.map.md` para avaliar recursos visuais concretos sem repetir regras;
- `rules/corporate.rules.md` para identificar rules aplicáveis;
- `rules/*.rules.md` apenas quando delegadas por `corporate.rules.md` e relevantes para a intenção de tela;
- `{component}.sample.md` apenas quando a preferência depender de confirmação de uso real de componente específico;
- `state.yaml` para consultar etapa, diretório de trabalho, biblioteca, `current_item` e status.

## Classificação de orientação

[INSTRUÇÃO] Use estas classificações durante a síntese:
- `Preferir`: pattern semanticamente adequado, natural na linguagem da biblioteca e com boa cobertura nativa ou composição simples.
- `Combinar com`: pattern que aparece como apoio recorrente para uma intenção de tela.
- `Usar com blueprint`: pattern adequado, mas com gap localizado ou estrutural resolvido por blueprint.
- `Evitar`: pattern pouco natural para a biblioteca, dominado por tecnologia externa ou que tende a gerar tela desalinhada.
- `Evitar como padrão`: pattern pode ser usado quando requisito exigir, mas não deve ser primeira escolha da IA.

## 1. Validação das entradas

1. Ler `state.yaml` e confirmar que a etapa atual é `patterns-orientations` ou foi delegada pelo workflow.

2. Verificar existência dos artefatos obrigatórios:
- `patterns.table.md`;
- `blueprints.table.md`;
- `visual.language.md`;
- `visual.map.md`;
- `rules/corporate.rules.md`;
- `patterns-orientations.template.md`.

3. Verificar retomada:
- se `patterns.orientations.md` já existir, ler antes de continuar;
- preservar conteúdo existente apenas quando ainda estiver coerente com este protocolo;
- remover seções explicativas sem uso operacional.

### GATE PO.1

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- etapa autorizada pelo workflow ou contexto da rodada;
- artefatos obrigatórios existem;
- retomada verificada quando aplicável.

## 2. Leitura e seleção de bases

[INSTRUÇÃO] Somente após gate `PO.1` satisfeito.

1. Ler bases fixas:
- `patterns.table.md`;
- `blueprints.table.md`;
- `visual.language.md`;
- `visual.map.md`.

2. Ler `rules/corporate.rules.md`:
- identificar rules relevantes por tipo de tela, pattern, operação ou decisão de componente;
- ler apenas rules delegadas e aplicáveis.

3. Identificar patterns candidatos:
- patterns com boa cobertura nativa ou composição simples;
- patterns com blueprint útil;
- patterns dominados por tecnologia externa;
- patterns com GAP ou baixa nota, mas ainda semanticamente relevantes para alguma intenção de tela.

4. Ler `{pattern}.ui-map.md` dos candidates que serão citados.

5. Ler `{pattern}.blueprint.md` quando a orientação for `usar com blueprint`.

6. Ler `{component}.sample.md` somente quando a preferência depender de confirmar uso real de componente específico.

### GATE PO.2

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- `patterns.table.md` lido;
- `blueprints.table.md` lido;
- linguagem visual e visual map lidos;
- rules aplicáveis avaliadas;
- candidates identificados;
- ui-maps relevantes lidos;
- blueprints e samples relevantes lidos quando necessários.

## 3. Síntese das orientações

[INSTRUÇÃO] Somente após gate `PO.2` satisfeito.

1. Identificar intenções de tela recorrentes favorecidas pela biblioteca:
- usar evidências de cobertura em `patterns.table.md`;
- usar naturalidade visual de `visual.language.md`;
- usar regras operacionais de `rules/corporate.rules.md` e rules relevantes;
- usar blueprints para distinguir cobertura direta de adaptação documentada.

2. Para cada intenção de tela:
- identificar patterns semanticamente adequados;
- ordenar os adequados por cobertura, naturalidade visual, rules, samples e existência de blueprint;
- classificar patterns como `Preferir`, `Combinar com`, `Usar com blueprint`, `Evitar` ou `Evitar como padrão`;
- registrar motivo curto.

3. Identificar combinações recorrentes:
- Shell/Page;
- Estrutura;
- Dados/Conteúdo;
- Entrada/Ações;
- Feedback.

4. Identificar patterns que devem ir para `Uso de blueprints`:
- quando o pattern é adequado, mas depende de blueprint para gap localizado ou estrutural;
- quando o blueprint resolve uma composição recorrente;
- quando o blueprint deve ser usado em vez de gerar orientação direta por cobertura nativa.

5. Identificar patterns que devem ir para `Evitar`:
- dominados por tecnologia externa;
- pouco naturais para a linguagem da biblioteca;
- com baixa cobertura e sem blueprint útil;
- que tendem a gerar tela desalinhada quando escolhidos como padrão.

### GATE PO.3

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- intenções de tela identificadas;
- patterns semanticamente adequados separados de patterns apenas bem cobertos;
- preferências ordenadas por evidência;
- combinações recorrentes identificadas;
- patterns com blueprint identificados;
- patterns a evitar identificados.

## 4. Escrita do artefato

[INSTRUÇÃO] Somente após gate `PO.3` satisfeito.

1. Criar ou substituir `patterns.orientations.md` usando `patterns-orientations.template.md`.

2. Preencher `Preferências gerais`:
- bullets curtos;
- sem API de componente;
- sem repetir regras visuais ou corporativas;
- sem justificar com texto longo.

3. Preencher `Orientação por tipo de tela`:
- uma seção por intenção de tela relevante;
- `Preferir`, `Combinar com`, `Evitar`, `Evitar como padrão`, `Abrir depois` e `Motivo`;
- usar apenas IDs canônicos de patterns;
- incluir `Evitar como padrão` quando o pattern for semanticamente válido, mas pouco natural, pouco coberto ou dependente de adaptação para a biblioteca;
- `Abrir depois` deve listar artefatos do ui-map a consultar para detalhar decisão, confirmar uso real ou implementar aquela intenção; não é leitura obrigatória em todo uso.

4. Preencher `Patterns preferenciais`.

5. Preencher `Combinações recomendadas`.

6. Preencher `Uso de blueprints`.

7. Preencher `Evitar`.

### GATE PO.4

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- `patterns.orientations.md` criado e persistido;
- template seguido;
- seções operacionais preenchidas;
- `Evitar como padrão` registrado quando aplicável;
- `Abrir depois` aplicado com semântica operacional;
- sem seção explicativa sem uso operacional;
- sem API de componentes;
- sem código de sample;
- sem regra visual ou corporativa duplicada.

## 5. Revisão e finalização

[INSTRUÇÃO] Somente após gate `PO.4` satisfeito.

1. Validar IDs:
- todos os IDs existem em `patterns.list.md`;
- todos os patterns citados existem em `patterns.table.md`.

2. Validar evidência:
- toda preferência tem base em `patterns.table.md`, `{pattern}.ui-map.md`, `blueprints.table.md`, `visual.language.md`, `visual.map.md`, samples ou rules;
- nenhum pattern foi promovido apenas por cobertura técnica quando não for semanticamente adequado;
- patterns com baixa cobertura, mas semanticamente corretos, foram tratados como condicionais, via blueprint, com adaptação ou evitar como padrão.

3. Revisar fronteiras:
- remover API de componentes;
- remover código;
- remover repetição de samples, blueprints, visual language, visual map ou rules;
- remover paths internos e links relativos de fontes do repositório analisado.

4. Corrigir inconsistências locais.

5. Atualizar `state.yaml`:
- etapa `patterns-orientations` concluída;
- `next_action` apontando para `finalize`.

6. Apresentar resumo ao humano:
- total de intenções de tela cobertas;
- total de patterns preferenciais citados;
- principais patterns condicionais, com blueprint ou a evitar;
- pendências, se existirem.

### GATE PO.FINAL

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- todas seções executadas em ordem: 1, 2, 3, 4, 5;
- gates `PO.1`, `PO.2`, `PO.3`, `PO.4` satisfeitos;
- `patterns.orientations.md` criado e persistido;
- IDs validados;
- evidências validadas;
- fronteiras com outros artefatos preservadas;
- revisão final realizada;
- `state.yaml` atualizado com etapa concluída e próxima ação `finalize`.
