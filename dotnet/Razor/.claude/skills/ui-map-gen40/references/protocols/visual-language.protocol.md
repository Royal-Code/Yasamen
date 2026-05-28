# Protocolo visual language

## Regras do protocolo

[INSTRUÇÃO] Ler e seguir estritamente as regras de `/references/rules/kernel.rules.md`.

[INSTRUÇÃO] Ler e seguir estritamente as regras de `/references/rules/workflow.rules.md`.

[INSTRUÇÃO] Leia os arquivos como descrito na seção `Arquivos a ler`.

[INSTRUÇÃO] Execute em sequência as seções de 1 até 5, passo a passo de cada seção, sem pular.

[INSTRUÇÃO] Não inventar regra visual, comportamento visual ou capacidade visual da biblioteca.

[INSTRUÇÃO] Não deduzir capacidade visual por semelhança de nome ou aparência de componente.

[INSTRUÇÃO] Separar contrato de consumo externo (`visual.language.md`) de auditoria interna (`visual.language.evidence.md`):
- `visual.language.md` é autocontido, sem paths internos, sem tabela de auditoria, sem detalhes que só fazem sentido para esta skill;
- `visual.language.evidence.md` é artefato operacional da rodada — fontes, força, contradições, veredito;
- no `visual.language.md` registrar apenas a força por regra (`forte` ou `fraca`) — sem evidências detalhadas, sem fontes, sem tabela de auditoria.

[INSTRUÇÃO] Critério de qualidade final: o `visual.language.md` deve ser utilizável por outra IA para orientar o desenho de telas bonitas e coerentes, sem depender de gosto subjetivo, sem contradizer a biblioteca real, sem ambiguidade sobre o que fazer.

## Arquivos a ler

- `visual-language.template.md` como guia de cobertura para `visual.language.md`;
- `visual-language-evidence.template.md` como guia de cobertura para `visual.language.evidence.md`;
- `visual-map.template.md` como guia de cobertura para `visual.map.md`;
- `components.summary.md` para consumir componentes, variações, props e estados;
- `ui-guide.md` para consumir a camada técnica de estilos/tema da biblioteca;
- `structure.md` quando existir;
- `state.yaml` para consultar etapa, gates, `library.technical_family`, `library.sources` e status;
- fontes originais da biblioteca conforme `library.sources` do `state.yaml` — não depender apenas dos resumos da etapa anterior.

## 1. Validação das entradas

1. Identificar fontes visuais disponíveis por ordem de confiabilidade:
- design tokens, theme API, variáveis CSS ou classes — evidência direta e verificável;
- documentação oficial de design ou componentes — evidência explícita;
- stories, demos, exemplos — evidência observável;
- código-fonte de componentes e estilos — evidência inferível;
- screenshots, previews — fonte de baixa confiabilidade (classificação de força depende de convergência com outras fontes).

2. Ler `library.technical_family` do `state.yaml` e confirmar que `ui-guide.md` existe quando família ≠ `none`.

3. Perguntar ao humano quando faltar fonte crítica ou houver dúvida bloqueante sobre o escopo visual.

### GATE VL.1

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- fontes visuais disponíveis identificadas e qualificadas;
- `library.technical_family` lida do state e `ui-guide.md` localizado quando família ≠ `none`;
- dúvidas bloqueantes convertidas em questão ao humano ou resolvidas.

## 2. Auditoria de evidências visuais

[INSTRUÇÃO] Somente após gate `VL.1` satisfeito.

[INSTRUÇÃO] Executar duas leituras separadas antes da síntese. Isso produz cobertura tanto de sistema visual primitivo quanto de uso visual aplicado.

### 2.1 Leitura visual primitiva

[INSTRUÇÃO] Analisar tokens, theme, resources, CSS, styles, tipografia, cor, spacing, radius, shadow, motion, breakpoints e estados base.

1. Investigar fontes de evidência direta:
- design tokens e variáveis;
- theme API, resource dictionaries ou equivalente;
- escalas tipográficas, paletas, espaçamento;
- superfícies, elevações, bordas;
- motion e transições;
- breakpoints e adaptação.

2. Resultado esperado:
- matriz de primitivas visuais;
- regras fortes de valor e semântica;
- lacunas técnicas.

#### GATE VL.2.1

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- fontes de evidência direta investigadas;
- primitivas visuais levantadas: tokens/escalas, tipografia, cor, spacing, elevação, bordas, motion e breakpoints;
- lacunas técnicas da leitura primitiva identificadas.

### 2.2 Leitura visual aplicada

[INSTRUÇÃO] Analisar componentes, docs de uso, exemplos, stories e telas demonstradas para identificar como a biblioteca compõe experiências reais.

1. Cobrir:
- shells e navegação;
- páginas CRUD e listagens;
- dados tabulares e escaneáveis;
- formulários;
- dashboards e métricas;
- overlays e interrupção;
- feedback e estados;
- fluxos recorrentes;
- decisões de quando usar componente X vs Y.

2. Resultado esperado:
- padrões visuais recorrentes;
- regras de composição por tipo de tela;
- anti-padrões práticos;
- escolhas preferenciais entre componentes próximos.

#### GATE VL.2.2

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- fontes de uso aplicado investigadas: componentes, documentação, stories/demos e telas demonstradas;
- tipos de tela cobertos: shells, navegação, listagens, formulários, dashboards, overlays, feedback;
- padrões recorrentes e anti-padrões com escolhas preferenciais identificados.

### 2.3 Síntese

1. Cruzar leitura primitiva + leitura aplicada cobrindo os eixos obrigatórios:
- identidade visual dominante;
- hierarquia perceptiva (tipografia, cor, tamanho, peso, posição);
- spacing, ritmo e densidade;
- peso e proporção entre zonas (shell, conteúdo, overlays);
- ação principal e ações secundárias;
- tipografia, cor e superfície;
- contenção ou ornamentação;
- estados e interação (hover, focus, disabled, error, loading);
- responsividade e adaptação;
- padrões visuais recorrentes;
- limites, lacunas e anti-padrões.

2. Quando leituras divergirem:
- valores concretos vêm da leitura primitiva;
- intenção de uso vem da leitura aplicada/documentação;
- casos isolados viram lacuna ou observação, não regra.

3. Classificar cada observação por força:
- `forte` — token, API ou documentação oficial explícita;
- `fraca` — 3+ evidências de código/exemplos convergentes;
- `inconclusiva` — ≤2 ocorrências isoladas ou evidência contraditória.

4. Identificar contradições entre fontes e registrar decisão de resolução.

5. Identificar lacunas que afetam o consumo externo do contrato visual.

6. Produzir `visual.language.evidence.md` usando template como guia:
- organizar por eixo visual;
- registrar fontes, observações, força, contradições e veredito;
- não omitir evidência relevante por falta de campo no template.

#### GATE VL.2.3

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- todos os eixos obrigatórios cruzados entre leitura primitiva e aplicada;
- cada observação classificada por força: `forte`, `fraca` ou `inconclusiva`;
- contradições entre fontes identificadas com decisão de resolução registrada;
- lacunas que afetam o contrato externo registradas;
- `visual.language.evidence.md` criado e persistido.

### GATE VL.2

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- leitura visual primitiva executada e registrada;
- leitura visual aplicada executada e registrada;
- síntese entre leitura primitiva e aplicada realizada;
- todos os eixos obrigatórios investigados;
- observações classificadas por força;
- contradições identificadas com decisão de resolução;
- lacunas registradas;
- `visual.language.evidence.md` criado e persistido.

## 3. Contrato visual externo

[INSTRUÇÃO] Somente após gate `VL.2` satisfeito.

[INSTRUÇÃO] Usar `visual-language.template.md` como guia de cobertura. A IA pode reorganizar, fundir ou expandir seções conforme a biblioteca real, mas NÃO pode omitir eixo da lista de cobertura obrigatória.

[INSTRUÇÃO] Formato obrigatório para cada regra visual no documento:
- **Regra**: {afirmação clara e acionável}
- **Força**: forte | fraca
- **Aplicação**: {o que fazer}
- **Evitar**: {o que não fazer}

[INSTRUÇÃO] Regras de produção do `visual.language.md`:
- transformar evidência forte em regra visual clara;
- transformar evidência fraca convergente em recomendação conservadora;
- transformar evidência inconclusiva em lacuna ou limitação;
- usar tabelas, diagramas textuais ou snippets quando reduzirem ambiguidade;
- manter foco em linguagem visual — citar tecnologia apenas quando explicar decisão visual, limitação ou convenção;
- não colocar paths internos, tabela de auditoria ou detalhes internos ao repositório.

1. Produzir `visual.language.md` cobrindo todos os eixos obrigatórios:
- identidade visual dominante;
- princípios visuais observados;
- hierarquia perceptiva;
- spacing, ritmo e densidade;
- peso e proporção entre zonas;
- ação principal e ações secundárias;
- tipografia, cor e superfície;
- contenção ou ornamentação;
- estados e interação;
- responsividade e adaptação;
- padrões visuais recorrentes;
- critérios de uso por IA;
- resolução de conflitos;
- limites, lacunas e anti-padrões.

2. Garantir que o documento:
- é autocontido e utilizável fora do repositório da biblioteca;
- cada regra com formato Regra/Força/Aplicação/Evitar;
- critérios de uso por IA permitem decisão sem ambiguidade;
- anti-padrões têm alternativa segura;
- resolução de conflitos está explícita:
  - para **valor concreto** (cor, size, spacing, radius): token > doc > padrão recorrente > caso isolado;
  - para **intenção de uso** (quando usar, onde posicionar, qual componente): doc > padrão recorrente > token > caso isolado.

3. Quando um eixo obrigatório não tiver evidência suficiente para produzir regra, documentar como limite ou lacuna nesse eixo. Nunca preencher com afirmação genérica.

4. Registrar limitações conhecidas quando a evidência não sustentar regra forte.

### GATE VL.3

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- `visual.language.md` criado e persistido;
- documento autocontido e sem paths internos;
- todos os eixos obrigatórios cobertos;
- cada regra com formato Regra/Força/Aplicação/Evitar;
- critérios de uso por IA preenchidos sem ambiguidade;
- anti-padrões com alternativa;
- resolução de conflitos explícita;
- limitações registradas.

## 4. Mapa visual

[INSTRUÇÃO] Somente após gate `VL.3` satisfeito.

[INSTRUÇÃO] Quando `library.technical_family` = `none`, criar `visual.map.md` informando que não há mapa técnico aplicável e encerrar esta seção.

[INSTRUÇÃO] O `visual.map.md` é documento de **tradução** — cruza intenção visual com recurso concreto de implementação. Não duplicar integralmente o `visual.language.md` nem o `ui-guide.md`.

1. Ler `library.technical_family` do `state.yaml`.

2. Produzir `visual.map.md` usando template como guia, cobrindo:
- tabela principal de mapeamento (eixo visual → recurso concreto → receita de uso);
- gramática de layout para composição de telas (regras de composição + exemplos estruturais);
- receitas operacionais com código real para cenários recorrentes;
- recursos visuais disponíveis organizados por família semântica (cores, tipografia, spacing, bordas, elevação), usando nomenclatura nativa da stack;
- lacunas e alternativas.

3. Garantir que:
- cada conclusão nasce do cruzamento entre regra visual e recurso concreto;
- não inventa nomes de token, classes ou capacidades não evidenciadas;
- distingue o que pertence à biblioteca do que pertence ao app consumidor;
- receitas usam API real e válida dos componentes;
- gramática de layout tem regras de composição e exemplos com código.

### GATE VL.4

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- `visual.map.md` criado e persistido;
- quando família = `none`: arquivo informa ausência de mapa técnico;
- quando família ≠ `none`: tabela de mapeamento com eixos cobertos, receitas com código real, gramática de layout com exemplos, recursos visuais documentados;
- nenhum token ou classe inventado;
- lacunas e alternativas documentadas.

## 5. Finalização

[INSTRUÇÃO] Somente após gate `VL.4` satisfeito.

1. Atualizar estado da `task` do `state.yaml` como etapa concluída.

2. Apresentar ao humano um resumo do que foi feito na etapa:
- status de `visual.language.md`;
- status de `visual.language.evidence.md`;
- status de `visual.map.md`;
- lacunas relevantes identificadas.

3. Delegar ao workflow a execução da etapa 3 do fluxo `gerar-ui-map`.

### GATE VL.FINAL

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- todas seções executadas em ordem: 1, 2, 3, 4, 5.
- todos gates internos satisfeitos: `VL.1`, `VL.2`, `VL.3`, `VL.4`.
- `state.yaml` atualizado com stage concluído e `next_action` apontando para `ui-map`.
