# Protocolo patterns blueprints

## Regras do protocolo

[INSTRUÇÃO] Ler e seguir estritamente as regras de `/references/rules/kernel.rules.md`.

[INSTRUÇÃO] Ler e seguir estritamente as regras de `/references/rules/workflow.rules.md`.

[INSTRUÇÃO] Leia os arquivos como descrito na seção `Arquivos a ler`.

[INSTRUÇÃO] Execute em sequência as seções de 1 até 5, passo a passo de cada seção, sem pular.

[INSTRUÇÃO] Ler um pattern por vez e fazer um por vez, sem paralelismo, sem batch.

[INSTRUÇÃO] Os arquivos `{pattern}.blueprint.md` são destinados ao uso exclusivo da IA em outros projetos. Devem ser escritos para leitura da IA e serem autocontidos.

[INSTRUÇÃO] Regras para uso de subagente:
- quando usado subagente, ele sempre deve ler:
  - `/references/rules/kernel.rules.md` e seguir estritamente as regras;
  - `/references/rules/workflow.rules.md` e seguir estritamente as regras;
  - `/references/protocols/patterns-blueprints.protocol.md` e seguir estritamente as regras;
- outros arquivos podem ser lidos, conforme instrução ou necessidade;
- o subagente poderá escrever arquivos, atualizar e criar, conforme instruções dos protocolos;
- executar apenas conforme instrução do protocolo.

## Arquivos a ler

- `pattern-blueprint-resumido.template.md` como guia de cobertura para `{pattern}.blueprint.md` quando classificação `resumido`;
- `pattern-blueprint-completo.template.md` como guia de cobertura para `{pattern}.blueprint.md` quando classificação `completo`;
- `blueprints-table.template.md` como guia de cobertura para `blueprints.table.md`;
- `patterns.list.md` para identificar os arquivos de patterns;
- `patterns.table.md` para identificar todos os patterns processados na etapa de ui-map;
- `{pattern}.ui-map.md` para consumir cobertura, esforço, limitações e exemplos;
- `{component}.sample.md` para consumir API real dos componentes envolvidos;
- `components.summary.md` para validar nomes e papéis dos componentes e consultar padrões de naming da biblioteca;
- `structure.md` para consultar convenções de naming e organização da biblioteca;
- `visual.language.md` para seguir a linguagem visual da biblioteca;
- `visual.map.md` para aplicar regras visuais e recursos concretos;
- `state.yaml` para consultar etapa, gates, `library.sources`, `current_item` e status.

## 1. Validação das entradas

1. crie a pasta `patterns-blueprints/` dentro do diretório de trabalho se não existir.

2. crie o `blueprints.table.md` dentro de `patterns-blueprints/` se não existir:
- use o `blueprints-table.template.md` como template;
- atualize a tabela durante a triagem.

### GATE PB.1

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- diretório `patterns-blueprints/` criado dentro do diretório de trabalho;
- `blueprints.table.md` criado e persistido.

## 2. Triagem

[INSTRUÇÃO] Somente após gate `PB.1` satisfeito.

[INSTRUÇÃO] **Classificação de triagem** por pattern:
- `não gerar` — existe componente principal com nota ≥ 8 cobrindo o pattern, ou solução depende de tecnologia externa com contribuição periférica da lib;
- `resumido` — gap localizado, composicional, de baixa ou média orquestração;
- `completo` — gap estrutural, comportamental, responsivo, de shell, navegação ou coordenação entre múltiplos componentes e estados.

1. iterar sobre cada linha de `patterns.table.md`, um por vez, preservando a ordem da tabela:
- quando a linha estiver em grupo de pattern e tiver `{pattern}.ui-map.md`, ler o arquivo e triar normalmente;
- quando a linha estiver na seção `GAP` com tipo `fora da plataforma`, classificar como `não gerar` e justificar pela incompatibilidade de plataforma, sem exigir `{pattern}.ui-map.md`;
- quando a linha estiver na seção `GAP` com tipo `sem cobertura viável`, ler `{pattern}.ui-map.md` quando existir e triar normalmente, pois pode exigir blueprint `completo`;
- quando um pattern fora da plataforma tiver `{pattern}.ui-map.md` porque a biblioteca possui componente que implementa bem o pattern, triar pelo `{pattern}.ui-map.md` normalmente e registrar a ressalva de plataforma na justificativa.

2. para cada pattern, classificar conforme as regras de classificação de triagem (Regras do protocolo):
- avaliar nota geral, esforço de adaptação, limitações e tipo de gap declarado no ui-map ou em `patterns.table.md`;
- atribuir `não gerar`, `resumido` ou `completo`;
- justificar a classificação com base em evidência do ui-map e/ou da linha de GAP em `patterns.table.md`.

3. registrar a classificação em `blueprints.table.md`:
- separar por grupos de patterns;
- incluir id, nome, classificação e justificativa.

4. apresentar a triagem ao humano:
- mostrar totais por classificação;
- solicitar confirmação ou ajuste antes de avançar para a geração;
- aplicar ajustes solicitados em `blueprints.table.md`.

### GATE PB.2

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- todos os patterns de `patterns.table.md` triados ou explicitamente excluídos por regra de plataforma;
- patterns fora da plataforma sem componente que implemente bem registrados como `não gerar`;
- patterns fora da plataforma com componente que implemente bem triados pelo `{pattern}.ui-map.md`;
- `blueprints.table.md` consolidado com classificação por pattern;
- triagem confirmada pelo humano.

## 3. Geração dos blueprints

[INSTRUÇÃO] Somente após gate `PB.2` satisfeito.

[INSTRUÇÃO] Para o código nos blueprints:
- Deve ser código real, funcional e válido na tecnologia da biblioteca;
- API real obrigatória para componentes existentes — não inventar props, eventos, slots ou métodos de componentes da lib;
- API proposta permitida somente para componente novo, wrapper ou receita proposta declarada no próprio blueprint;
- código que usa API proposta deve ser consistente com o contrato proposto no blueprint;
- Deve usar a linguagem visual e as regras de `visual.language.md` e `visual.map.md`;
- Comportamento inferido deve ser marcado como `[inferido]`;
- Sem paths internos do repositório ou links relativos a arquivos da biblioteca.

1. selecionar a lista de patterns marcados como `resumido` ou `completo` em `blueprints.table.md`.

2. gravar `current_item` em `state.yaml` apontando para o primeiro pattern selecionado.

3. para cada pattern selecionado, executar a subseção `3.1 Iteração`.

### 3.1 Iteração

[INSTRUÇÃO] quando disponível o trabalho com subagentes, usar subagente conforme regras definidas no protocolo.

[INSTRUÇÃO] a execução desta subseção só termina com o gate `PB.3.1` satisfeito.

1. ler `visual.language.md` e `visual.map.md` a cada iteração:
- quando executado por subagente, ler todos os arquivos base;
- quando executado pelo agente principal, garantir que estão em contexto.

2. ler `{pattern}.ui-map.md` do pattern atual.

3. ler o arquivo do pattern (conforme `patterns.list.md`) e entender seus requisitos.

4. identificar componentes relacionados a partir do ui-map (principais e composição).

5. para cada componente relacionado:
- ler `{component}.sample.md`;
- ler as evidências disponíveis em `library.sources` relacionadas ao componente.

6. **Lente 1 — Arquitetura do pattern**:
- enumerar os eixos ortogonais que o pattern exige (semântica, estado, comportamento, coordenação, responsividade, integrações);
- para cada eixo, descrever o que faz e quando varia; não combinar eixos prematuramente;
- extrair do arquivo do pattern (`{pattern}.md`): requisitos estruturais obrigatórios, estados próprios, reação a estados da página, responsividade, UIPs tipicamente contidos, limites, incompatibilidades e sinais de escolha;
- extrair do `{pattern}.ui-map.md`: requisitos mal cobertos, limitações, tipo de adaptação, recomendação, nota geral e exemplo `Como usar` quando existir.
- formar uma hipótese arquitetural para cobrir bem o pattern antes de reduzir pela biblioteca: `composição direta`, `wrapper leve`, `componente único`, `compound`, `conjunto coordenado` ou `tecnologia externa`;
- tratar a hipótese arquitetural como baseline de comparação, não como decisão final;
- declarar quais responsabilidades seriam componentes se a biblioteca precisasse resolver o pattern de forma canônica.

7. **Lente 2 — Viabilidade operacional da biblioteca**:
- para cada eixo da Lente 1, mapear:
  - componentes existentes em `components.summary.md` que cobrem total ou parcialmente o eixo;
  - utilities, classes, tokens e recursos visuais de `visual.language.md` e `visual.map.md` que reduzem a necessidade de componente novo;
  - API real aproveitável dos `{component}.sample.md` dos componentes relacionados (variantes, estados, eventos, slots, defaults, limitações, comportamentos `[inferido]`);
  - convenções de naming da própria biblioteca, lidas de `structure.md` e `components.summary.md` (sufixos, prefixos, estilo semântico vs descritivo, padrões compound);
  - convenções de naming da stack — observar libs populares e consolidadas da mesma plataforma, linguagem e framework da biblioteca analisada, apenas como fallback quando a biblioteca não der sinal suficiente; não usar convenções de plataformas, linguagens ou frameworks diferentes da biblioteca analisada.
- produzir uma receita viável mínima usando API real da biblioteca;
- identificar se a receita mínima fica clara como composição direta, se ganha consistência com wrapper leve, ou se exige componente/coordenação maior.

8. **Síntese** — aplicar a matriz e registrar decisão.

8.1. Matriz de classificação final:

| Classificação final | Usar quando |
|---|---|
| `não gerar` | cobertura suficiente ou tecnologia externa domina o núcleo |
| `resumido` | gap localizado resolvido por composição direta ou wrapper leve |
| `completo` | gap estrutural, multi-eixo, responsivo, comportamental ou coordenado |

8.2. Tipo de artefato:
- componente existente/utility cobre bem → não propor componente;
- receita real curta e clara → `composição apenas`;
- receita repetida ou ambígua → `wrapper/componente leve`;
- responsabilidade estrutural própria → `componente novo único`;
- relação pai-filho forte → `compound`;
- múltiplas responsabilidades independentes → `conjunto coordenado`.

8.3. Heurísticas de naming e limites:
- seguir `components.summary.md` e `structure.md`;
- conferir samples/componentes correlatos;
- usar convenção da stack só como fallback;
- evitar nomes genéricos ou inventados;
- registrar `convenção de referência`;
- declarar tipo de artefato, limites, dependências externas e eixos cobertos sem componente novo.

8.4. Quando a classificação final divergir da triagem:
- se mudar para `não gerar`, não criar `{pattern}.blueprint.md`;
- atualizar `blueprints.table.md` com a classificação final, justificativa e status `reclassificado`;
- atualizar `current_item` no `state.yaml` para o próximo pattern selecionado;
- seguir para o próximo pattern.

9. produzir `{pattern}.blueprint.md` em `patterns-blueprints/`:
9.1. quando classificação final `resumido`:
- usar `pattern-blueprint-resumido.template.md`;
- permitir apenas `composição apenas` ou `wrapper/componente leve`;
- quando houver wrapper/componente leve, declarar API proposta curta e usar API real dos componentes existentes internamente;
- não gerar compound amplo, conjunto coordenado ou arquitetura de shell complexa.
9.2. quando classificação final `completo`:
- usar `pattern-blueprint-completo.template.md`;
- declarar `Componentes propostos` com `convenção de referência`, ou omitir quando não houver componente novo;
- declarar eixos cobertos sem componente novo.

10. atualizar `blueprints.table.md` na seção `Resultado da geração`:
- pattern id;
- classificação final;
- status (`gerado`, `reclassificado` ou `bloqueado`);
- tipo de artefato;
- componentes propostos (lista separada por vírgula; `-` quando só composição);
- limites declarados (resumo curto).

11. atualizar `current_item` em `state.yaml` para o próximo pattern selecionado.

#### GATE PB.3.1

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- Lente 1 (passo 6), Lente 2 (passo 7) e Síntese (passo 8) executados;
- Síntese declara: classificação final, tipo de artefato quando gerar, limites e eixos cobertos sem componente novo;
- se a classificação final mudar para `não gerar`, `blueprints.table.md` registra status `reclassificado`, não há blueprint criado e `current_item` aponta para o próximo pattern;
- componentes propostos com nome final + `convenção de referência` declarados (quando houver);
- quando a classificação final for `resumido` ou `completo`, `{pattern}.blueprint.md` criado e persistido seguindo o template correto;
- quando gerar blueprint, conteúdo aderente à classificação; quando `resumido`, tipo de artefato limitado a `composição apenas` ou `wrapper/componente leve`;
- código real e válido; API real respeitada para componentes existentes; API proposta declarada antes de uso quando houver wrapper/componente proposto; tokens e recursos existem em `visual.map.md`; sem path interno;
- componentes consumidos existem em `components.summary.md`;
- linha em `blueprints.table.md` atualizada;
- `current_item` atualizado no `state.yaml`.

### GATE PB.3

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- todos os patterns marcados como `resumido` ou `completo` processados;
- gate `PB.3.1` satisfeito para cada pattern;
- arquivos `{pattern}.blueprint.md` criados para cada pattern com classificação final `resumido` ou `completo`;
- `current_item` em `state.yaml` vazio ou marcado como concluído.

## 4. Revisão

[INSTRUÇÃO] Somente após gate `PB.3` satisfeito.

1. para cada `{pattern}.blueprint.md`, executar a subseção `4.1 Iteração da revisão`.

### 4.1 Iteração da revisão

[INSTRUÇÃO] quando disponível o trabalho com subagentes, usar subagente conforme regras definidas no protocolo.

[INSTRUÇÃO] quando executado por subagente:
- ler os arquivos base (kernel, workflow, protocolo) e `{component}.sample.md` dos componentes referenciados no blueprint;
- executar para **um único** `{pattern}.blueprint.md` atribuído;
- pode corrigir somente o `{pattern}.blueprint.md` atribuído;
- não alterar `blueprints.table.md`, `state.yaml`, classificação de triagem, samples, ui-maps ou outros blueprints.

1. revisar como leitor externo (outra IA sem acesso ao repositório):
- marcar e remover trechos com path interno, link relativo ou referência a artefato não autocontido;
- garantir que o documento se sustenta apenas com `visual.language.md`, `visual.map.md` e `{component}.sample.md` como dependentes externos.

2. validar tecnicamente o código:
- API dos componentes confere com `{component}.sample.md`;
- API proposta de wrapper/componente novo está declarada antes do uso e é usada de forma consistente;
- tokens, classes e recursos batem com `visual.map.md`;
- comportamentos inferidos marcados com `[inferido]`.

3. validar aderência à classificação:
- `resumido` cobre apenas o gap localizado, sem expandir escopo;
- `completo` cobre todos os aspectos estruturais e comportamentais previstos.

4. aplicar correções:
- correções locais no `{pattern}.blueprint.md` revisado;
- quando a correção revelar classificação incorreta ou impacto em `{component}.sample.md` ou `{pattern}.ui-map.md`, registrar achado global (`arquivo`, `achado`, `impacto`, `ação sugerida`) sem alterar os outros artefatos;
- agente principal consolida os achados globais e decide reclassificações ou revisita do sample/ui-map de origem.

#### GATE PB.4.1

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- paths internos e links relativos removidos; blueprint autocontido;
- código validado contra `{component}.sample.md` e `visual.map.md`;
- API proposta validada quando houver wrapper/componente novo;
- comportamentos inferidos marcados com `[inferido]`;
- aderência à classificação verificada;
- correções locais aplicadas;
- achados globais registrados quando identificados (sem alterar outros artefatos).

### GATE PB.4

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- gate `PB.4.1` satisfeito para cada `{pattern}.blueprint.md`;
- achados globais consolidados pelo agente principal;
- reclassificações e correções cruzadas decididas e aplicadas.

## 5. Finalização

[INSTRUÇÃO] Somente após gate `PB.4` satisfeito.

1. atualizar estado da `task` do `state.yaml` como etapa concluída.

2. apresentar ao humano um resumo do que foi feito na etapa:
- total de patterns triados;
- distribuição por classificação (`não gerar`, `resumido`, `completo`);
- total de blueprints gerados;
- principais lacunas registradas.

3. delegar ao workflow a execução da etapa 6 do fluxo `gerar-ui-map`.

### GATE PB.FINAL

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- todas seções executadas em ordem: 1, 2, 3, 4, 5.
- todos gates internos satisfeitos: `PB.1`, `PB.2`, `PB.3`, `PB.4`.
- `state.yaml` atualizado com stage concluído e `next_action` apontando para `corporate-rules`.
