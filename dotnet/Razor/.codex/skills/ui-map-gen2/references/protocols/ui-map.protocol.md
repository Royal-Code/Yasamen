# Protocolo: UI Map

## Objetivo

Mapear todos os patterns dos catálogos para componentes, composições ou ausências reais da biblioteca. Atribuir nota, justificativa detalhada e estratégia de implementação para cada pattern. Registrar limitações e gaps. Fechar a relação entre patterns e componentes levantados no resumo.

O resultado deste protocolo é o artefato principal do ui-map-gen: o `ui-map.md` será usado pela skill screen-designer para saber como implementar cada pattern com a biblioteca.

---

## INSTRUÇÕES DE EXECUÇÃO

[INSTRUÇÃO] Reler o kernel, workflow e este protocolo antes de iniciar.

[INSTRUÇÃO] Executar os passos na ordem.

[INSTRUÇÃO] Nunca usar referências internas do repositório para o documento `ui-map.md`. Este documento deve ser autocontido. Será usado em outros repositórios que não terão acesso direto ao código fonte, documentação, storybook ou exemplos, salvo quando expostos na web via URI.

### Passo 1: Seleccionar catálogos de patterns

[INSTRUÇÃO] Ler os catálogos na seguinte ordem (do mais estrutural ao mais específico):

**Catálogos base (sempre ler):**
1. `shell.pattern.md` — shells e containers de aplicação
2. `page.pattern.md` — pages e layouts de conteúdo
3. `ui_struct.pattern.md` — estrutura e organização visual
4. `ui_nav.pattern.md` — navegação
5. `ui_data.pattern.md` — exibição de dados
6. `ui_input.pattern.md` — entrada de dados
7. `ui_action.pattern.md` — ações e comandos
8. `ui_feedback.pattern.md` — feedback e status
9. `ui_content.pattern.md` — conteúdo e mídia

**Catálogos condicionais (ler conforme `target_platforms` do state):**
10. `ui_mobile.pattern.md` — ler quando target inclui iOS, Android, Flutter, React Native, MAUI mobile.
11. `ui_desktop.pattern.md` — ler quando target inclui Windows, macOS, Linux, Electron, Tauri, Flutter Desktop, MAUI desktop.

[INSTRUÇÃO] Se a biblioteca é exclusivamente web: não ler catálogos condicionais. Registrar no state quais catálogos foram activados.

### Passo 2: Analisar pattern a pattern

[INSTRUÇÃO] Para cada pattern de cada catálogo activado, analisar na ordem do catálogo:

1. Ler a definição completa do pattern no arquivo de referência.
2. Identificar quais componentes da biblioteca (do `components.summary.md`) correspondem ao pattern.
3. Avaliar se o componente atende os **objetivos** do pattern e pode ser usado como implementação.

### Passo 3: Produzir seção de cada pattern no `ui-map.md`

[INSTRUÇÃO] Para cada pattern, criar uma seção contendo obrigatoriamente:

**Componentes**: Quais componentes atendem o pattern, seja de forma direta ou por composição. Listar cada componente com seu papel.

**Nota de adaptação**: Usar a tabela:
| Nota | Significado |
|------|-------------|
| 9–10 | Cobertura total — o componente implementa o padrão diretamente com comportamento, estados e variantes declarados |
| 7–8  | Cobertura alta — estrutura e comportamento cobertos; alguma composição ou CSS extra necessário |
| 5–6  | Cobertura parcial — o padrão é atingível por composição mas sem semântica específica |
| 3–4  | Cobertura baixa — existe um componente relacionado mas incompleto para o padrão |
| 1–2  | Vestigial — apenas primitivos genéricos aplicáveis com muito trabalho personalizado |
| 0    | Ausente — nenhum componente cobre o padrão; implementação inteiramente manual necessária |

**Justificativa**: Um parágrafo explicando **detalhadamente** o motivo da nota. Não pode ser genérico. Deve mencionar o que o componente faz bem, o que falta, e por que a nota é essa e não outra.

**Tipo de cobertura**: Descrever resumidamente como os componentes cobrem os requisitos do pattern (nativo, composição, parcial, ausente).

**Esforço de adaptação**: Descrever de forma direta **o que precisa ser feito** para cobrir os GAPs dos componentes em relação aos requisitos do pattern. Não dizer "esforço médio" — dizer o que concretamente precisa ser construído.

**Como usar**: Ao menos um exemplo de código fonte válido para usar cada componente de forma a atender os requisitos do pattern.

[INSTRUÇÃO] Para o campo "Como usar":
- Deve ser código real, funcional e válido na tecnologia da biblioteca.
- Deve usar a linguagem visual e as regras de estilo definidas nos documentos gerados anteriormente (`visual.language.md`, `styles.map.md` quando existir).
- Deve demonstrar como implementar o pattern completo, não apenas instanciar o componente.
- Quando a cobertura é por composição: mostrar a composição completa.
- Quando há customização necessária: mostrar a customização aplicada.
- O código é o artefato mais valioso desta seção — é o que a skill screen-designer usará diretamente.

[INSTRUÇÃO] Exemplos não podem inventar API nem comportamento não observado nos componentes. Se um comportamento for inferido, marcar explicitamente como `[inferido]`.

**Limitações** (quando aplicável): Definir limitações de uso do componente em relação à adaptação ao pattern. O que não funciona, o que precisa de workaround, o que quebra em determinadas condições.

### Passo 4: Estruturar o documento

[INSTRUÇÃO] O `ui-map.md` deve seguir esta estrutura:
- Uma seção de nível 2 para cada grupo de patterns (ex: `## UI Struct`, `## Navigation`).
- Uma seção de nível 3 para cada pattern dentro do grupo.
- Uma seção final de "Análise por Grupo" com tabela consolidada.

Cada campo deve estar em negrito: `**Componentes**:`, `**Nota**:`, etc.

### Passo 5: Enquadrar componentes não mapeados

[INSTRUÇÃO] Após produzir o mapeamento completo e persistir o arquivo, analisar se TODOS os componentes de `components.summary.md` foram contemplados em algum pattern.

Para cada componente que não foi contemplado:
1. Analisar se ele pode entrar em algum dos patterns já mapeados.
2. Se puder: alterar a seção do pattern, incluindo o componente e exemplos de uso. Reavaliar nota e justificativa.
3. Se não enquadrar em nenhum pattern:
   - Criar seção `## Componentes sem pattern mapeado` no final.
   - Para cada componente: informar que não tem pattern, com justificativa.
   - Avaliar se o componente é: muito específico, utilitário/interno, ou candidato a novo pattern.

### Passo 6: Análise por grupo

[INSTRUÇÃO] Ao final do documento, gerar uma seção `## Análise por Grupo` com tabela:

| Grupo | Nota média | Patterns fortes (≥7) | Patterns fracos (≤4) | Observações de adaptação |
|---|---|---|---|---|

[INSTRUÇÃO] Para cada grupo, incluir também:
- Componentes-chave que sustentam o grupo.
- Gaps críticos que impactam uso real.
- Recomendação: o que resolver prioritariamente na etapa de blueprints.

### Passo 7: Bibliotecas auxiliares (quando aplicável)

Quando a rodada inclui bibliotecas auxiliares:
- Indicar na seção do pattern quando depende da auxiliar.
- Nota considera a composição com auxiliar (penalização moderada -3 a -4, não eliminação).
- Registrar quais patterns justificam a existência da auxiliar.

---

## REGRAS DE NOTA

[INSTRUÇÃO] A nota reflete a cobertura da **biblioteca**, não a qualidade do pattern.

[INSTRUÇÃO] Composição usando apenas componentes da biblioteca principal: penalizar levemente (max -2).

[INSTRUÇÃO] Composição que exige biblioteca auxiliar: penalizar moderadamente (-3 a -4).

[INSTRUÇÃO] Ausência total: nota 0, independente de ser possível construir do zero.

---

## GATE UIMAP

- Todos os grupos de pattern dos catálogos activados foram analisados.
- Cada pattern possui cobertura declarada ou ausência declarada.
- Cada pattern possui nota, justificativa detalhada, tipo de cobertura e exemplo de código válido.
- Os componentes levantados no resumo foram enquadrados em algum pattern ou justificados na seção de componentes sem pattern.
- Análise por grupo foi gerada com tabela e recomendações.
- Exemplos usam linguagem visual e regras de estilo quando aplicável.
- Nenhum exemplo inventa API.
- Resumo apresentado ao humano.
- Aprovação explícita para seguir.

### Checklist
- Cada pattern possui nota, justificativa detalhada, tipo de cobertura e exemplo de código válido.
- Componentes sem enquadramento foram tratados ou motivaram justificativa.
- Exemplos não inventam API nem comportamento não observado.
- Análise por grupo está consistente com as avaliações individuais.
- O documento é autocontido — não depende de paths internos do repositório.
- O documento é utilizável pela skill screen-designer para gerar telas com a biblioteca.
