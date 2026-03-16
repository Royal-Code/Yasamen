# Instrução Operacional — Criar uma Spec

> Use este arquivo como base em novos chats para que a IA crie uma spec completa, consistente com os templates, guides e documentos de planeamento da solução.

## Objetivo

Quando o utilizador pedir para criar uma spec `<nome-da-spec>`, a IA deve assumir que a spec ficará em:

```text
.ai/specs/<nome-da-spec>/
```

E deve criar ou revisar todos os artefatos necessários da spec, não apenas um rascunho parcial.

## Artefatos da Spec

Uma spec nova deve conter:

- `.ai/specs/<nome-da-spec>/requirements.md`
- `.ai/specs/<nome-da-spec>/design.md`
- `.ai/specs/<nome-da-spec>/tasks.md`
- `.ai/specs/<nome-da-spec>/delivery.md`

Todos devem nascer a partir do template em:

- `.ai/specs/_template/requirements.md`
- `.ai/specs/_template/design.md`
- `.ai/specs/_template/tasks.md`
- `.ai/specs/_template/delivery.md`

Se a pasta da spec já existir:

- a IA deve ler o conteúdo atual antes de editar;
- preservar trabalho existente;
- tratar a tarefa como evolução da spec, não como substituição cega.

## Fontes Obrigatórias

Antes de escrever a spec, a IA deve ler:

- `.ai/ui-map/ui-map.md`
- `.ai/ui-map/ui-plan.md`
- os guides relevantes em `.ai/guides/`
- o template da spec em `.ai/specs/_template/`

Além disso:

- se houver um documento de gaps relacionado, considerar seu conteúdo;
- se a spec envolver showcase, aplicar obrigatoriamente `09-showcases-and-docs.md`;
- toda spec nova deve incluir `10-spec-execution-and-delivery.md` em `Guides aplicados`.

## Fluxo Obrigatório

### 1. Entender o alvo da spec

A IA deve identificar:

- qual componente, fluxo ou iniciativa a spec descreve;
- se isso já aparece no `ui-map.md`;
- se já existe fase ou prioridade em `ui-plan.md`;
- se a spec é de componente, infraestrutura, showcase, docs ou outra frente transversal.

### 2. Escolher o nome e a pasta

Regra recomendada:

- usar `kebab-case`;
- preferir nomes curtos, estáveis e ligados ao assunto principal.

Exemplos:

- `tabs`
- `pagination`
- `empty-state`
- `docs-showcase-foundation`
- `search-field`

### 3. Selecionar guides aplicados

A IA deve listar em `requirements.md` apenas os guides realmente necessários, mas:

- `10-spec-execution-and-delivery.md` é obrigatório em toda spec nova;
- `09-showcases-and-docs.md` é obrigatório quando houver showcase no `Docs.Client`.

Exemplos comuns:

- componente visual simples:
  - `01-project-structure`
  - `02-styles-and-css`
  - `06-component-anatomy`
  - `09-showcases-and-docs`
  - `10-spec-execution-and-delivery`
- componente de formulário:
  - adicionar `07-form-components`
- componente com service/outlet:
  - adicionar `08-service-pattern`

### 4. Preencher `requirements.md`

O `requirements.md` deve definir:

- metadados;
- objetivo;
- escopo;
- fora de escopo;
- casos de uso;
- requisitos funcionais;
- acessibilidade e responsividade;
- showcase obrigatório;
- critérios de aceite;
- critérios de conclusão.

Não deixar texto genérico do template quando a intenção já estiver clara.

### 5. Preencher `design.md`

O `design.md` deve definir:

- pacote sugerido;
- namespaces;
- referências diretas;
- API pública;
- estrutura interna;
- CSS e contrato visual;
- showcase no Docs;
- riscos e questões em aberto;
- validação esperada.

O design deve ser específico o suficiente para orientar uma implementação posterior.

### 6. Preencher `tasks.md`

O `tasks.md` deve virar um checklist executável, cobrindo:

- preparação;
- implementação;
- estilos;
- testes;
- documentação;
- encerramento.

As tasks devem ser concretas e verificáveis.

### 7. Criar `delivery.md`

Toda spec nova deve nascer já com `delivery.md`, mesmo vazio ou com placeholders.

Isso garante que a execução posterior da spec já tenha onde registrar:

- changelog;
- rastreabilidade;
- validação;
- revisão de código;
- fechamento das tasks.

## Relação com `ui-map.md` e `ui-plan.md`

Ao criar a spec, a IA deve:

- usar `ui-map.md` como fonte de gap, nota atual e contexto funcional;
- usar `ui-plan.md` como fonte de fase, prioridade e encadeamento.

A IA não precisa alterar esses arquivos sempre que criar uma spec nova, mas deve:

- apontar no conteúdo da spec a ligação com eles;
- e atualizar os documentos se a criação da spec mudar o planeamento de forma objetiva e clara.

## Regras de Qualidade

- Usar sempre acentuação.
- Não copiar o template sem adaptação.
- Não inventar pacotes ou dependências sem justificativa.
- Não tratar `RoyalCode.Razor.Show` como host atual de showcase.
- Não deixar referências vagas quando o repositório já permite uma decisão concreta.
- Não omitir `delivery.md`.

## Formato Esperado da Resposta Final

A resposta final da IA deve ser curta e conter:

1. qual spec foi criada ou atualizada;
2. quais arquivos foram criados/alterados;
3. principais decisões de design;
4. pontos em aberto, se houver.

## Prompt Curto Recomendado

```text
Leia `.ai/instructions/create-spec.md` e crie a spec `search-field`.
```

Ou:

```text
Leia `.ai/instructions/create-spec.md` e crie a spec `filter-panel`.
```

Ou, para revisão de uma spec existente:

```text
Leia `.ai/instructions/create-spec.md` e revise a spec `pagination`.
```
