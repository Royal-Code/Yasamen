# Protocolo Plan Spec

## Regras do protocolo

[INSTRUÇÃO] Ler e seguir estritamente as regras de `/references/rules/kernel.rules.md`.

[INSTRUÇÃO] Ler e seguir estritamente as regras de `/references/rules/workflow.rules.md`.

[INSTRUÇÃO] Ler e seguir estritamente as regras de `/references/rules/component-plan.rules.md`.

[INSTRUÇÃO] Ler o template `/references/templates/planning.template.md` antes de produzir `planning.md`.

[INSTRUÇÃO] Trabalhar em gates. Em cada gate, apresentar proposta curta, decisões, pontos em aberto e uma pergunta objetiva.

[INSTRUÇÃO] Esperar aprovação do humano antes de avançar para o próximo gate, salvo override explícito válido conforme `kernel.rules.md`.

[INSTRUÇÃO] Não criar `requirements.md`, `design.md`, `tasks.md` ou `delivery.md` neste protocolo.

## Arquivos a ler

[INSTRUÇÃO] Ler os documentos do workspace quando existirem:
- ui-map do projeto;
- plano de UI;
- lista de componentes planejados;
- guia de decisões transversais;
- guides especializados aplicáveis ao alvo.

[INSTRUÇÃO] Se algum documento esperado estiver ausente, registrar como GAP no plano.

## 1. Gate alvo e contexto

1. Identificar alvo, slug, tipo de entrega e razão de prioridade.
2. Cruzar o alvo com roadmap, ui-map e lista de componentes quando existirem.
3. Classificar o alvo como planejado, derivado, dependência natural ou fora do plano.
4. Formular pergunta objetiva para aprovação do alvo.

### GATE PLAN.1

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- alvo e slug identificados;
- contexto de backlog registrado;
- ausência no roadmap registrada quando aplicável;
- aprovação humana do alvo obtida ou override válido registrado.

## 2. Gate problema, objetivo e escopo macro

[INSTRUÇÃO] Somente após gate `PLAN.1` satisfeito.

1. Definir problema que o componente resolve.
2. Definir objetivo do primeiro release.
3. Definir escopo e fora de escopo.
4. Identificar entregáveis esperados.
5. Formular pergunta objetiva para aprovação.

### GATE PLAN.2

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- problema definido;
- objetivo definido;
- escopo e fora de escopo definidos;
- aprovação humana obtida ou override válido registrado.

## 3. Gate casos de uso, acessibilidade e aceite

[INSTRUÇÃO] Somente após gate `PLAN.2` satisfeito.

1. Definir casos de uso principais e secundários.
2. Definir estados mínimos.
3. Definir requisitos de acessibilidade e responsividade.
4. Definir critérios de aceite.
5. Formular pergunta objetiva para aprovação.

### GATE PLAN.3

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- casos de uso definidos;
- acessibilidade e responsividade definidas;
- critérios de aceite definidos;
- aprovação humana obtida ou override válido registrado.

## 4. Gate estrutura técnica, composição e dependências

[INSTRUÇÃO] Somente após gate `PLAN.3` satisfeito.

1. Definir pacote alvo preliminar.
2. Classificar componente como primitivo base ou composto.
3. Identificar componentes existentes para reuso.
4. Identificar dependências composicionais e pré-requisitos.
5. Decidir se algum componente-base deve vir antes.
6. Formular pergunta objetiva para aprovação.

### GATE PLAN.4

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- pacote alvo preliminar definido;
- composição classificada;
- dependências registradas;
- pré-requisitos definidos ou justificados;
- aprovação humana obtida ou override válido registrado.

## 5. Gate API pública, variações e contrato visual

[INSTRUÇÃO] Somente após gate `PLAN.4` satisfeito.

1. Definir componentes públicos.
2. Definir parâmetros, slots, eventos e atributos adicionais.
3. Decidir `Style: Themes`.
4. Definir fallback de `Themes.Default`, quando houver `Style`.
5. Decidir `Size: Sizes`.
6. Definir tokens de `yasamen.css`, CSS público e classes `ya-*`.
7. Formular pergunta objetiva para aprovação.

### GATE PLAN.5

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- API pública definida;
- decisão de `Style` fechada;
- fallback de tema definido quando necessário;
- decisão de `Size` fechada;
- tokens e CSS público definidos;
- aprovação humana obtida ou override válido registrado.

## 6. Gate pacote, projeto e implementação estrutural

[INSTRUÇÃO] Somente após gate `PLAN.5` satisfeito.

1. Decidir se o pacote alvo existe ou se pacote novo é necessário.
2. Quando houver pacote novo, definir nome do pacote e dependência do subfluxo técnico de criação de projeto.
3. Definir namespaces, arquivos previstos e referências diretas.
4. Definir showcase no docs.
5. Formular pergunta objetiva para aprovação.

### GATE PLAN.6

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- pacote existente versus novo decidido;
- pacote novo registrado quando aplicável;
- estrutura técnica prevista;
- showcase planejado;
- aprovação humana obtida ou override válido registrado.

## 7. Gate plano de execução e fechamento

[INSTRUÇÃO] Somente após gate `PLAN.6` satisfeito.

1. Definir tasks principais de implementação futura.
2. Definir validação esperada: build, testes, showcase, validação visual e aceite humano.
3. Definir risks, gaps e hipóteses adotadas.
4. Preparar `planning.md` usando `/references/templates/planning.template.md`.
5. Criar e persistir `planning.md` no diretório de trabalho.
6. Delegar ao workflow a execução de `create-spec`.

### GATE PLAN.FINAL

[INSTRUÇÃO] Use as regras de validação de GATE do `kernel.rules.md` para validar os itens:
- gates `PLAN.1` até `PLAN.6` satisfeitos;
- decisões obrigatórias registradas;
- gaps, hipóteses e aprovações registrados;
- `planning.md` criado e persistido;
- próxima etapa delegada para `create-spec`.
