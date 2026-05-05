# Protocolo: Components Summary

## Objetivo

Levantar todos os componentes da biblioteca, produzir `components.summary.md`, e quando aplicável `structure.md` e `styles.guide.md`.

---

## INSTRUÇÕES DE EXECUÇÃO

[INSTRUÇÃO] Reler o kernel, workflow e este protocolo antes de iniciar.

[INSTRUÇÃO] Executar os passos abaixo na ordem. Cada passo deve ser completado antes de avançar ao próximo.

### Passo 1: Identificar cenário

Existem dois cenários possíveis:

**Cenário A — Repositório com código fonte:**
- A biblioteca está disponível localmente com código, exemplos e documentação.
- Garantir que o humano forneceu os locais onde ficam o código fonte, documentação e exemplos.
- Se não forneceu: perguntar ao humano antes de prosseguir.

**Cenário B — Biblioteca pública (web):**
- É necessário pesquisar na internet os componentes existentes.
- Garantir que o humano passou os links da biblioteca, ou pesquisar na internet.
- Verificar os links e validar o acesso à documentação.
- Apresentar feedback do que foi encontrado ao humano.
- Antes de seguir, validar com humano se o que foi encontrado é suficiente.

### Passo 2: Levantamento de componentes

[INSTRUÇÃO] Para cada componente da biblioteca, levantar e registrar:
- Nome do componente.
- Para que pode ser usado (propósito funcional).
- Capacidade de componentização:
  - O que ele pode compor (quais outros componentes aceita como filhos).
  - O que pode ser composto nele (em quais containers ele se encaixa).
- Se for repositório: path do componente e arquivos relacionados (css, js, types, etc.).
- Se for web: URI do componente (página oficial ou código fonte público).
- Se existe documentação: o caminho (path ou URI) dela.
- Se existe exemplos (storybook, aplicativos reais, outros): os caminhos (path ou URI) deles.

[INSTRUÇÃO] Classificar cada componente em um grupo funcional: inputs, layout, navigation, data display, feedback, overlay, utility, etc.

[INSTRUÇÃO] Marcar explicitamente componentes ambíguos — aqueles com nome genérico, API pouco clara, ou função não óbvia. Para cada ambíguo: registrar motivo da ambiguidade e hipótese de classificação.

[INSTRUÇÃO] Se houver mais de 5 componentes ambíguos: apresentar lista ao humano e pedir classificação antes de prosseguir.

[INSTRUÇÃO] Persistir todos os componentes em `components.summary.md`.

### Passo 3: Estrutura do repositório (apenas cenário A)

[INSTRUÇÃO] Quando for repositório com acesso ao código fonte:
- Analisar estrutura de pastas, projetos e organização.
- Detectar como são organizados os componentes, projetos, css, js, outros.
- Montar o arquivo `structure.md` definindo como é organizado o repositório, de modo que se for preciso criar novos componentes ele sirva de guia de onde criar e como organizar os artefatos.

O `structure.md` deve ser completo o suficiente para que outra IA consiga criar um novo componente seguindo exatamente o mesmo padrão de organização, imports, exports e convenções.

Obs.: quando for biblioteca pública não produzir `structure.md`.

### Passo 4: Estilos (quando aplicável)

[INSTRUÇÃO] Quando a biblioteca usa css/estilos:
- Detectar a biblioteca de estilos utilizada (tailwindcss, bootstrap, styled-components, etc.).
- Avaliar se há personalizações e descrever como é utilizada.
- Descrever themes de estilos: padrão de cores, espaçamento, breakpoints, bordas, sombras, etc.
- Escrever no arquivo `styles.guide.md`: o padrão de estilo, personalizações, e regras de uso de estilo para a biblioteca.

Obs.: quando a biblioteca não utiliza estilos, não produzir `styles.guide.md`.

---

## INSTRUÇÕES DE CONTEÚDO DO `components.summary.md`

[INSTRUÇÃO] O arquivo deve conter para cada componente:

```md
### {Nome do Componente}

**Grupo**: {grupo funcional}
**Propósito**: {para que serve, em 1-2 frases}
**Compõe**: {quais componentes aceita como filhos ou conteúdo}
**Composto em**: {em quais containers/layouts se encaixa}
**Variações**: {variantes conhecidas: sizes, variants, states}
**Complexidade**: {1-10}
**Referência**: {path ou URI}
**Docs**: {path ou URI da documentação}
**Exemplos**: {paths ou URIs de exemplos}
**Notas**: {ambiguidade, limitações, ou — quando não há}
```

[INSTRUÇÃO] Não inventar informação. Se um campo não puder ser determinado com evidência, registrar como `desconhecido` ou `não documentado`.

[INSTRUÇÃO] No início do arquivo, incluir uma visão geral:
```md
# Components Summary — {nome da biblioteca}

## Visão geral
- Total de componentes: {n}
- Grupos identificados: {lista}
- Ambiguidades: {n}
- Fonte: {repo|web}

## Tabela rápida

| Componente | Grupo | Variações | Complexidade | Notas |
|---|---|---|---|---|
| ... | ... | ... | ... | ... |

## Detalhamento por componente
```

---

## GATE SUMMARY

- Nome da biblioteca identificado.
- Fontes mínimas aplicáveis ao cenário identificadas e validadas.
- Todos os componentes da biblioteca levantados e registrados.
- Componentes ambíguos marcados explicitamente e resolvidos (ou confirmados com humano).
- Quando repositório: estrutura entendida e documentada em `structure.md`.
- Quando usa estilos: regras documentadas em `styles.guide.md`.
- Resumo apresentado ao humano.
- Aprovação explícita para seguir.

### Checklist
- Todos componentes da biblioteca levantados e registrados.
- Componentes ambíguos ou não classificáveis marcados explicitamente.
- Quando repositório, estrutura documentada plenamente para poder criar novos componentes seguindo o mesmo padrão.
- Quando usa estilos, padrão de uso entendido, personalizações levantadas e documentadas, regras identificadas e organizadas.
- O documento `components.summary.md` tem informação suficiente para que a etapa seguinte (visual-language) opere sem precisar reanalisar fontes do zero.
