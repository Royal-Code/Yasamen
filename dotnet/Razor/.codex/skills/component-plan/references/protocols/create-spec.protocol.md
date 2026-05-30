# Protocolo Create Spec

## Regras do protocolo

[INSTRUÇÃO] Ler e seguir estritamente as regras de `/references/rules/kernel.rules.md`.

[INSTRUÇÃO] Ler e seguir estritamente as regras de `/references/rules/workflow.rules.md`.

[INSTRUÇÃO] Ler e seguir estritamente as regras de `/references/rules/component-plan.rules.md`.

[INSTRUÇÃO] Ler os templates:
- `/references/templates/requirements.template.md`;
- `/references/templates/design.template.md`;
- `/references/templates/tasks.template.md`;
- `/references/templates/delivery.template.md`.

[INSTRUÇÃO] Usar `planning.md` como fonte primária quando existir.

[INSTRUÇÃO] Não implementar código.

## Arquivos a ler

[INSTRUÇÃO] Ler:
- `planning.md` no diretório de trabalho; ou
- plano equivalente fornecido no chat, quando autorizado pelo humano.

[INSTRUÇÃO] Ler os documentos do workspace quando existirem e quando ajudarem a confirmar decisões do plano:
- ui-map do projeto;
- plano de UI;
- lista de componentes planejados;
- guia de decisões transversais;
- guides especializados aplicáveis ao alvo.

## 1. Preparar criação

1. Validar que existe plano aprovado.
2. Extrair decisões finais do plano.
3. Identificar gaps bloqueantes.
4. Se houver gap bloqueante, parar e perguntar ao humano.

### GATE CREATE.1

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- plano aprovado identificado;
- decisões finais extraídas;
- nenhum gap bloqueante sem aprovação explícita.

## 2. Criar requirements

[INSTRUÇÃO] Somente após gate `CREATE.1` satisfeito.

1. Criar `requirements.md` seguindo `requirements.template.md`.
2. Adaptar todos os placeholders ao componente.
3. Registrar critérios de aceite rastreáveis.
4. Registrar validação humana futura quando houver UI, showcase ou comportamento observável.

### GATE CREATE.2

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- `requirements.md` criado e persistido;
- objetivo, escopo, casos de uso e requisitos funcionais completos;
- decisões de Style, Size, tokens, pacote e composição registradas.

## 3. Criar design

[INSTRUÇÃO] Somente após gate `CREATE.2` satisfeito.

1. Criar `design.md` seguindo `design.template.md`.
2. Registrar pacote alvo, namespaces, arquitetura, composição e dependências.
3. Registrar API pública.
4. Registrar CSS público, classes `ya-*`, tokens, showcase e validação esperada.
5. Registrar riscos e questões em aberto.

### GATE CREATE.3

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- `design.md` criado e persistido;
- pacote existente versus novo decidido;
- API pública, composição, CSS, showcase e validação descritos.

## 4. Criar tasks

[INSTRUÇÃO] Somente após gate `CREATE.3` satisfeito.

1. Criar `tasks.md` seguindo `tasks.template.md`.
2. Ajustar checklists ao componente.
3. Incluir tasks de validação humana quando aplicável.
4. Incluir task de criação de pacote/projeto quando o design exigir pacote novo.

### GATE CREATE.4

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- `tasks.md` criado e persistido;
- tasks refletem requirements e design;
- validação humana e pacote novo cobertos quando aplicável.

## 5. Criar delivery

[INSTRUÇÃO] Somente após gate `CREATE.4` satisfeito.

1. Criar `delivery.md` seguindo `delivery.template.md`.
2. Deixar status inicial coerente com spec recém-criada.
3. Registrar que a validação será preenchida na implementação futura.

### GATE CREATE.5

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- `delivery.md` criado e persistido;
- status inicial coerente;
- seções de rastreabilidade, validação e fechamento presentes.

## 6. Revisão local da spec

[INSTRUÇÃO] Somente após gate `CREATE.5` satisfeito.

1. Revisar coerência entre `planning.md`, `requirements.md`, `design.md`, `tasks.md` e `delivery.md`.
2. Conferir decisões obrigatórias de `component-plan.rules.md`.
3. Corrigir inconsistências pequenas e claras.
4. Se houver inconsistência que mude escopo, parar e perguntar ao humano.

### GATE CREATE.FINAL

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- arquivos finais criados;
- revisão local executada;
- inconsistências pequenas corrigidas;
- inconsistências maiores registradas como pendência ou levadas ao humano;
- próximo passo recomendado definido.
