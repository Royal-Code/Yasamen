# Protocolo: Patterns Output

## Objetivo

Produzir três artefatos sequenciais: exemplos por componente (samples), blueprints de patterns com gaps, e o índice final de mapeamento (patterns map). A etapa tem 3 sub-etapas com gates internos.

---

## INSTRUÇÕES DE EXECUÇÃO

[INSTRUÇÃO] Reler o kernel, workflow e este protocolo antes de iniciar.

[INSTRUÇÃO] Executar as sub-etapas na ordem: Samples → Blueprints → Patterns Map.

[INSTRUÇÃO] Controlar no state: `patterns_output.substage` = `samples` | `blueprints` | `patterns_map`.

---

## SUB-ETAPA 1: SAMPLES

### Objetivo

Produzir um arquivo exclusivo por componente com exemplos de como usar o componente para reduzir invenção em repositórios de destino. Explicar como cada componente atende os patterns a que adere. Consolidar complexidade, propriedades, eventos úteis e limitações.

### Instruções

[INSTRUÇÃO] Analisar a complexidade de cada componente da biblioteca para atender os patterns mapeados no `ui-map.md`.

[INSTRUÇÃO] Medir complexidade (1-10) baseada em:
- Quantidade de variações de uso do componente.
- Quantidade de patterns que o componente adere.
- Quantidade de propriedades que o componente tem.
- Quantidade de eventos que o componente tem.
- Nível de configuração necessária para uso real.
- Interação com outros componentes (dependências).

[INSTRUÇÃO] Para cada componente, criar um arquivo exclusivo de exemplos: `{nome-do-componente-dash-case}.sample.md` no diretório `samples/`.

[INSTRUÇÃO] No arquivo de exemplos deve conter:
- Visão geral do componente.
- Exemplos válidos por pattern.
- Propriedades críticas.
- Eventos úteis.
- Limitações.
- Combinações proibidas ou frágeis, quando aplicável.

[INSTRUÇÃO] A quantidade de exemplos deve ser proporcional à complexidade:

| Complexidade | Mínimo de exemplos | Orientação |
|---|---|---|
| 1-3 (baixa) | 1 exemplo | Cobrir uso principal |
| 4-6 (média) | 2 exemplos | Cobrir uso principal + variação relevante |
| 7-10 (alta) | 3 exemplos | Cobrir uso principal + variações + composição |

Sem máximo — explorar mais quando a complexidade justificar.

[INSTRUÇÃO] Para criar os exemplos, avaliar:
- Exemplos devem atender duas coisas: como usar o componente, e como atender o pattern.
- Quando há muitas variações de uso:
  - Levantar quais variações são importantes.
  - Definir quantidade de exemplos baseado na complexidade.
  - Elaborar exemplos ao estilo documentação, explicando as variações possíveis.
- Quando há muitos patterns aderidos:
  - Definir se um exemplo atende todos patterns ou se é necessário mais.
  - Elaborar exemplos que satisfaçam cada pattern segundo o grau de aderência.
- Quando há muitas propriedades:
  - Avaliar se exemplos ou lista descritiva é suficiente.
  - Criar exemplos ou seção com propriedades explicando quando usar.
- Quando há muitos eventos:
  - Avaliar utilidade dos eventos ao pattern.
  - Quando útil: criar exemplos de uso.
  - Quando não: criar apenas descrição.

[INSTRUÇÃO] Toda prop, evento ou slot usado nos exemplos deve ter evidência nos fontes. Se um comportamento for inferido: marcar como `[inferido]`. Nunca usar API hipotética sem flag explícito.

[INSTRUÇÃO] Após completar todos os samples, criar `components.table.md` no diretório de exemplos com tabela:

| Componente | Variações | Patterns cobertos | Props críticas | Eventos | Complexidade |
|---|---|---|---|---|---|

E para cada componente, uma subseção com:
- Nome do componente.
- Número total de exemplos por tipo (variações, patterns, propriedades, eventos).
- Justificativa por tipo.
- Resumo do que foi atendido.

### Formato do `{component}.sample.md`

```md
# {Component} — Sample

## Visão geral
- **Propósito**: {para que serve}
- **Complexidade**: {1-10}
- **Patterns cobertos**: {lista com IDs}
- **Variações demonstradas**: {lista}

## Exemplos

### {Pattern: ID e nome}

**Objetivo**: {o que o exemplo demonstra em relação ao pattern}

{código completo e funcional demonstrando o uso}

**Props usadas**: {lista com descrição de cada prop usada no exemplo}
**Eventos relevantes**: {lista com descrição}
**Por que atende o pattern**: {explicação de como o exemplo satisfaz os requisitos do pattern}

### {Outro pattern ou variação}
...

## Propriedades críticas

| Prop | Tipo | Quando usar | Impacto |
|---|---|---|---|
| {prop} | {tipo} | {situação} | {o que muda} |

## Eventos úteis

| Evento | Quando dispara | Uso típico |
|---|---|---|
| {evento} | {gatilho} | {para que serve} |

## Limitações
- {o que o componente não cobre}
- {gaps identificados}
- {situações onde quebra ou se comporta mal}

## Combinações frágeis
- {composições que parecem funcionar mas têm problemas}
```

### Gate interno samples

- Todo componente com complexidade ≥ 4 tem ao menos 2 exemplos.
- `components.table.md` está completo.
- Cada arquivo explicita quais patterns cobre.
- Os exemplos usam apenas APIs validadas do componente.

---

## SUB-ETAPA 2: BLUEPRINTS

### Objetivo

Transformar gaps de cobertura em propostas de solução reutilizáveis, sem tratar como implementação oficial. Criar triagem enxuta, iterar pattern a pattern com aprovação humana.

### Etapa 2.1: Triagem inicial

[INSTRUÇÃO] A partir do `ui-map.md`, para cada pattern decidir uma das opções:
- **não gerar** — nota ≥ 8, ou solução depende de tecnologia externa com contribuição periférica da lib.
- **resumido** — gap localizado, composicional e de baixa/média orquestração.
- **completo** — gap estrutural, comportamental, responsivo, de shell, navegação ou coordenação.

[INSTRUÇÃO] Critérios:
- Em regra, considerar blueprint para patterns com nota 6 ou menor.
- Permitir blueprint mesmo para nota muito baixa quando a biblioteca oferecer base útil.
- Preferir não gerar quando a solução depender quase toda de tecnologia externa.

[INSTRUÇÃO] Produzir `blueprints.table.md` com:

```md
# Blueprints Table

## Resumo
- Não gerar (já atende): {n}
- Não gerar (tecnologia externa): {n}
- Gerar resumido: {n}
- Gerar completo: {n}

| Pattern | Decisão | Motivo | Status |
|---|---|---|---|
| {pattern} | {não gerar|resumido|completo} | {uma frase de triagem} | {triado|gerando|gerado|pulado} |
```

[INSTRUÇÃO] Apresentar a tabela ao humano e pedir aprovação explícita antes de iniciar o loop.

### Etapa 2.2: Loop pattern a pattern

[INSTRUÇÃO] Processar um pattern por vez. Não iniciar o próximo sem concluir o atual e sem aprovação humana para seguir.

[INSTRUÇÃO] Para cada pattern elegível (resumido ou completo), executar na ordem:
1. Ler a seção correspondente do pattern em `ui-map.md`.
2. Ler o arquivo canônico de referência do pattern (do catálogo).
3. Ler o bloco "Como usar" da seção do ui-map.
4. Ler os arquivos de sample dos componentes citados, quando existirem.
5. Ler `visual.language.md`.
6. Ler `styles.map.md` quando existir.
7. Confirmar ou ajustar o nível (resumido/completo/não gerar).
8. Montar o arquivo do blueprint e persistir.
9. Atualizar status na tabela.

[INSTRUÇÃO] Apresentar ao humano: o que foi gerado, nível final, lógica da solução, justificativa da meta. Perguntar se pode seguir.

### Regras do loop

[INSTRUÇÃO] O blueprint deve transformar diagnóstico em proposta — não copiar mecanicamente a justificativa do ui-map.

[INSTRUÇÃO] Usar os componentes da biblioteca sempre que houver reaproveitamento real.

[INSTRUÇÃO] Quando propor API nova, marcar explicitamente como `[API proposta]`. Nunca atribuir aos componentes comportamentos não observados.

[INSTRUÇÃO] Usar os samples como evidência prática de API e composição.

[INSTRUÇÃO] Usar a linguagem visual e o styles map como contrato, não como sugestão opcional.

[INSTRUÇÃO] O blueprint deve buscar cobertura 8+. Quando isso não for plausível: explicar por quê, propor a melhor cobertura plausível, e pedir validação humana.

### Mudança de nível

Promover de resumido para completo quando a leitura profunda revelar:
- Estados próprios relevantes.
- Responsividade crítica.
- Coordenação entre múltiplos componentes.
- Dependência de shell.
- Interação rica.
- Tecnologia complementar importante.

Permitir mudar para "não gerar" quando a proposta não for realmente útil ou reaproveitável.

### Conteúdo dos blueprints

[INSTRUÇÃO] O conteúdo varia conforme a proposta, mas todo blueprint deve ter um núcleo mínimo:
- Identificação do pattern.
- Nível final.
- Por que a cobertura atual não atende bem.
- Objetivo da proposta.
- Meta de cobertura proposta.
- Estratégia de composição com a biblioteca.
- Proposta de solução.
- Código necessário para a tecnologia alvo.
- Exemplo de uso.
- Limitações remanescentes.
- Pontos de adaptação para outro repositório.

[INSTRUÇÃO] **Blueprint resumido** deve ter:
- Resumo curto do gap.
- Decisão arquitetural principal.
- Componentes reaproveitados.
- Peça nova ou composição proposta.
- Bloco principal de código.
- Um exemplo principal de uso.
- Justificativa breve da cobertura proposta.
- Limitações remanescentes.

[INSTRUÇÃO] **Blueprint completo** deve ter:
- Resumo executivo.
- Requisitos do pattern ainda não atendidos.
- Diagnóstico estruturado do gap.
- Justificativa detalhada da meta de cobertura.
- Estratégia de composição.
- Proposta de novas peças, contratos e responsabilidades.
- Aplicação objetiva da linguagem visual.
- Aplicação objetiva dos estilos, tokens e camadas.
- Estrutura sugerida por tecnologia.
- Blocos principais de código.
- Estados e comportamento responsivo.
- Exemplos principais de uso.
- Comparação entre cobertura atual e proposta.
- Limitações remanescentes.
- Pontos de adaptação para outro repositório.

[INSTRUÇÃO] Regra tecnológica:
- O código deve ser suficiente para explicar a solução, mantendo natureza de blueprint.
- Não expandir com código desnecessário quando o esforço for baixo.
- Detalhar mais quando exigir estrutura, estados, responsividade, shell, orquestração ou integração.

### Gate interno blueprints

- Todos os patterns da fila foram processados.
- Cada mudança de nível foi justificada.
- Cada dispensa foi justificada.
- O loop releu ui-map, pattern canônico, samples, linguagem visual e styles map.
- Todo blueprint mostra como reaproveita a biblioteca antes de propor algo novo.
- APIs propostas marcadas como propostas.
- Limitações e pontos de adaptação documentados.

---

## SUB-ETAPA 3: PATTERNS MAP

### Objetivo

Gerar índice compacto e rápido do mapeamento final. Permitir consulta rápida por pattern sem reler o documento principal. Conectar pattern, componente, nota, exemplo e referência.

[INSTRUÇÃO] Ler o `ui-map.md` gerado anteriormente.

[INSTRUÇÃO] Para cada grupo de patterns, criar uma tabela com colunas:
- ID do Pattern
- Nome do Pattern
- Componentes que implementam
- Nota
- Arquivo de exemplos (dos componentes)
- Pattern blueprint (quando disponível)
- URI da documentação (quando pública ou disponível na web)
- URI do código fonte (quando disponível na web)

[INSTRUÇÃO] Não informar path interno do repositório nas tabelas. Apenas paths relativos ao diretório do ui-map ou URIs públicas.

[INSTRUÇÃO] Criar o documento `patterns.map.md` com as tabelas.

---

## GATE PATTERNS-OUTPUT

- Tabela de componentes × patterns criada (`components.table.md`).
- Complexidade definida para cada componente.
- Cada componente possui arquivo próprio de exemplo.
- Cada arquivo contém visão geral, exemplos por pattern, propriedades, eventos, limitações.
- Quantidade de exemplos coerente com complexidade.
- Triagem de blueprints aprovada pelo humano.
- Cada pattern elegível foi processado individualmente.
- Todo blueprint mostra reaproveitamento da biblioteca.
- `blueprints.table.md` reflete status final.
- `patterns.map.md` gerado com todas as colunas.
- Uma tabela por grupo de pattern.
- Resumo apresentado ao humano.
- Aprovação explícita para seguir.

### Checklist
- Cada componente tem ao menos um exemplo.
- Quantidade de exemplos coerente com complexidade.
- Cada arquivo explicita quais patterns cobre.
- Exemplos usam apenas APIs validadas.
- Todos patterns da fila de blueprints processados.
- Toda mudança de nível justificada.
- Todo blueprint proporcional ao esforço.
- APIs propostas marcadas.
- Patterns map completo com todos patterns listados.
- Cada linha referencia arquivo de exemplo quando cobertura ≠ ausente.
- Não há path interno do repo nas tabelas.
