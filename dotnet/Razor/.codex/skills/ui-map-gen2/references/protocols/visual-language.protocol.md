# Protocolo: Visual Language

## Objetivo

Identificar a gramática visual transversal da biblioteca, consolidar o documento de linguagem visual de forma autocontida, distinguir regras fortes/fracas/inconclusivas, e quando aplicável cruzar com sistema de estilos.

Artefatos: `visual.language.md` (obrigatório), `styles.map.md` (condicional).

---

## INSTRUÇÕES DE EXECUÇÃO

[INSTRUÇÃO] Reler o kernel, workflow e este protocolo antes de iniciar.

[INSTRUÇÃO] Executar os passos na ordem.

### Passo 1: Analisar fontes de evidência visual

[INSTRUÇÃO] Ler as seguintes fontes na ordem de confiabilidade:

1. **Design tokens / theme API** — evidência direta e verificável.
2. **Documentação de design principles** — evidência explícita quando oficial.
3. **Storybook / demos / examples** — evidência observável.
4. **Código-fonte dos componentes** — evidência inferível (estilos hardcoded, defaults).
5. **Screenshots / previews** — evidência visual fraca (sem garantia de atualidade).

[INSTRUÇÃO] Para cada evidência encontrada, classificar a força:

| Força | Critério | Ação |
|-------|----------|------|
| **Forte** | Token, API ou doc oficial explícita | Registrar como regra confirmada |
| **Fraca** | Inferida de código, exemplos ou padrões recorrentes | Registrar como observação com fonte |
| **Inconclusiva** | Apenas 1 ocorrência ou evidência contraditória | Registrar como lacuna com hipótese |

[INSTRUÇÃO] Nunca registrar observação fraca como regra confirmada. Toda regra deve ter ao menos uma evidência forte OU 3+ evidências fracas convergentes.

### Passo 2: Produzir `visual.language.md`

[INSTRUÇÃO] Nunca usar referências internas do repositório para o documento `visual.language.md`. Este documento deve ser autocontido. Será usado em outros repositórios que não terão acesso direto ao código fonte, documentação, storybook ou exemplos, salvo quando expostos na web via URI.

[INSTRUÇÃO] O artefato deve responder, com base em evidências reais:
- Qual é a identidade visual dominante da biblioteca.
- Como a hierarquia perceptiva costuma ser construída.
- Como aparecem ritmo, respiro e densidade.
- Como o peso visual é distribuído entre zonas principais e secundárias.
- Como costuma funcionar a ação principal (CTA).
- Como tipografia, cor e superfície se combinam.
- Qual é o nível típico de contenção, neutralidade ou ornamentação.
- Como essas regras mudam por faixa de dispositivo.
- Quais limites visuais a biblioteca impõe.
- Quais anti-padrões devem ser evitados.

[INSTRUÇÃO] Regras de execução:
- Separar fato, hipótese e lacuna.
- Não inferir comportamento visual sem evidência.
- Não tratar snippet ilustrativo como padrão oficial.
- Não declarar capacidade visual total por semelhança de nome.
- Sempre citar a evidência principal de cada conclusão.
- Registrar quando uma regra visual é forte, fraca ou inconclusiva.

[INSTRUÇÃO] O documento deve seguir este formato de saída:

```md
# Visual Language — {nome da biblioteca}

## Resumo executivo
{Parágrafo denso descrevendo a identidade visual geral, forças e limitações}

## Identidade visual dominante
{O que define visualmente esta biblioteca — personalidade, tom, filosofia de design}
{Evidências: ...}

## Princípios visuais observados
{Princípios de design identificados, com fonte e classificação de força}

## Regras de hierarquia perceptiva
{Como tamanho, peso, cor e posição constroem hierarquia}
{Para cada regra: evidência e força}

## Regras de spacing, ritmo e respiro
{Padrões de espaçamento, grid, density levels}
{Para cada regra: evidência e força}

## Regras de peso e proporção entre zonas
{Como a lib distribui atenção visual — hero, sidebar, content, footer}
{Para cada regra: evidência e força}

## Regras para ação principal e ações secundárias
{Como CTAs são tratados — cor, tamanho, posição, destaque}
{Hierarquia de botões, links, ações inline}
{Para cada regra: evidência e força}

## Regras de tipografia, cor e superfície
{Famílias, pesos, escalas tipográficas}
{Paleta de cores, semântica de cor}
{Superfícies, cards, elevações}
{Para cada regra: evidência e força}

## Regras de contenção ou ornamentação
{Nível de decoração vs minimalismo}
{Borders, dividers, backgrounds, ornamentos}
{Para cada regra: evidência e força}

## Regras responsivas
{Como a linguagem visual muda por breakpoint}
{O que colapsa, reorganiza, desaparece}
{Para cada regra: evidência e força}

## Limites e restrições da biblioteca
{O que a lib NÃO faz — capacidades ausentes}
{O que a lib faz mal — capacidades limitadas}

## Anti-padrões
{O que não fazer, baseado em evidência de problemas reais}
{Para cada anti-padrão: por que é ruim e qual é a alternativa}

## Critérios de uso por IA
{Instruções claras de quando e como uma IA deve usar este documento ao desenhar telas}
{O que consultar primeiro, o que priorizar, o que ignorar}
{Como resolver conflitos entre regras}

## Evidências principais
{Tabela ou lista das evidências mais importantes e suas fontes}

## Lacunas abertas
| Eixo | O que falta | Evidência encontrada | Impacto |
|------|-------------|---------------------|---------|
| {eixo} | {gap} | {evidência fraca ou nenhuma} | {impacto nas etapas seguintes} |

## Avaliação de qualidade
{Auto-avaliação: o documento é suficiente para outra IA desenhar telas bonitas e coerentes?}
{Justificativa da avaliação}
```

[INSTRUÇÃO] Para cada seção, o conteúdo deve ser:
- **Denso e útil** — frases que instruem diretamente, não descrições genéricas.
- **Rastreável** — cada regra aponta para a evidência que a sustenta.
- **Classificado** — cada regra é marcada como forte, fraca ou inconclusiva.
- **Acionável** — uma IA lendo este documento consegue tomar decisões de design sem ambiguidade.

**Critério de qualidade final:** O artefato deve ser utilizável por outra IA para orientar o desenho de telas bonitas e coerentes, sem depender de gosto subjetivo solto e sem contradizer a biblioteca real.

### Passo 3: Styles Map (condicional)

[INSTRUÇÃO] Quando estilos não são aplicáveis à tecnologia da biblioteca, pular esta sub-etapa. Registrar `stages.styles_map: skipped` no state com justificativa.

[INSTRUÇÃO] Produzir `styles.map.md` quando a biblioteca possuir sistema de estilos mapeável (tokens, classes, theme API, variáveis CSS).

[INSTRUÇÃO] Regras de execução do styles map:
- Não duplicar integralmente o `styles.guide` nem o `visual.language`. O artefato é de **tradução** entre intenção visual e implementação.
- Cada conclusão deve nascer do cruzamento entre uma regra visual e um recurso concreto de estilo.
- Não inventar nomes de token, variações de tema, breakpoints ou capacidades não evidenciadas.
- Distinguir o que pertence à camada base da lib, ao website e ao recurso de documentação.
- Preservar a classificação de evidência: forte, fraca ou inconclusiva.
- Transformar anti-padrões visuais em restrições operacionais.
- Quando a linguagem visual pedir efeito não coberto pelo sistema de estilos, registrar lacuna.
- Adicionar seção com design tokens, estilos, classes, customizações utilizáveis em outros projetos.

[INSTRUÇÃO] Formato de saída do `styles.map.md`:

```md
# Styles Map — {nome da biblioteca}

## Resumo executivo
{O que este documento faz: traduz linguagem visual para implementação concreta}

## Como ler este documento
{Instruções de uso para a IA que vai implementar telas}

## Tabela principal de mapeamento

| Eixo visual | Regra visual | Token/Classe/Variável | Receita de uso | Força |
|---|---|---|---|---|
| Hierarquia | {regra} | {implementação concreta} | {como aplicar} | {forte|fraca} |
| ... | ... | ... | ... | ... |

## Receitas operacionais

### {Contexto: ex. "Ação principal em card"}
- Intenção visual: {o que se quer comunicar}
- Implementação: {código/tokens/classes concretas}
- Variações: {breakpoints, temas}

### {Outro contexto}
...

## Design tokens disponíveis

### Cores e temas
{Lista completa de tokens de cor com uso semântico}

### Tipografia
{Tokens de tipografia: família, peso, escala}

### Espaçamento, bordas e elevação
{Tokens de spacing, radius, shadow}

## Lacunas e zonas de cuidado

| Regra visual | Por que não tem correspondência | Alternativa | Risco |
|---|---|---|---|
| {regra} | {motivo} | {alternativa ou nenhuma} | {o que pode dar errado} |

## Critérios de uso por IA
{Quando consultar este documento, em que ordem, o que priorizar}
```

[INSTRUÇÃO] Cobertura mínima esperada no styles.map: identidade visual, ação principal/secundária, cor semântica, tipografia, superfície e borda, spacing e densidade, profundidade e overlays, feedback, iconografia, navegação estrutural, responsividade, contenção e ornamentação, design tokens completos.

---

## GATE LANGUAGE

- Identidade visual dominante identificada com evidência.
- Todas as seções obrigatórias do documento preenchidas com conteúdo denso.
- Cada conclusão principal sustentada por evidência ou marcada como lacuna.
- Não há contradição explícita com documentação, exemplos ou design system observável.
- Cada regra visual classificada como forte, fraca ou inconclusiva.
- Critérios de uso por outra IA preenchidos sem ambiguidade.
- Evidências documentadas.
- Lacunas identificadas e documentadas.
- Quando aplicável: `styles.map.md` produzido com cruzamento real (não cópia).
- Resumo apresentado ao humano.
- Aprovação explícita para seguir.

### Checklist
- Todas seções atendidas sem ambiguidade e sem inventar.
- Cada regra visual classificada como forte, fraca ou inconclusiva.
- Critérios de uso por outra IA preenchidos sem ambiguidade.
- Evidências documentadas.
- Lacunas identificadas e documentadas.
- O documento é utilizável por outra IA para orientar o desenho de telas bonitas e coerentes, sem contradizer a biblioteca real.
- Quando produzido, `styles.map.md` cobre os eixos mínimos e não inventa tokens.
