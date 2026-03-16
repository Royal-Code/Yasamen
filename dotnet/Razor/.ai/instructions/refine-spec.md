# Instrução Operacional — Refinar uma Spec

> Use este arquivo como base em novos chats para que a IA fortaleça uma spec existente antes da implementação.

## Objetivo

Quando o utilizador pedir para refinar uma spec `<nome-da-spec>`, a IA deve assumir que a spec está localizada em:

```text
.ai/specs/<nome-da-spec>/
```

E deve melhorar a qualidade da spec existente, sem partir automaticamente para implementação de código.

## Arquivos da Spec

Para a spec `<nome-da-spec>`, a IA deve localizar e ler:

- `.ai/specs/<nome-da-spec>/requirements.md`
- `.ai/specs/<nome-da-spec>/design.md`
- `.ai/specs/<nome-da-spec>/tasks.md`
- `.ai/specs/<nome-da-spec>/delivery.md`

Se algum arquivo estiver ausente:

- a IA deve informar claramente;
- criar o arquivo ausente quando isso for coerente com o template da solução;
- só parar se a ausência impedir análise segura.

## Fontes Obrigatórias

Antes de refinar a spec, a IA deve ler:

- `.ai/specs/_template/requirements.md`
- `.ai/specs/_template/design.md`
- `.ai/specs/_template/tasks.md`
- `.ai/specs/_template/delivery.md`
- `.ai/ui-map/ui-map.md`
- `.ai/ui-map/ui-plan.md`
- os guides listados em `Guides aplicados`

Além disso:

- se a spec envolver showcase, aplicar `09-showcases-and-docs.md`;
- sempre aplicar `10-spec-execution-and-delivery.md`.

## O Que Significa Refinar

Refinar uma spec significa torná-la:

- mais consistente;
- mais específica;
- mais executável;
- mais rastreável;
- menos ambígua para uma IA ou desenvolvedor que vá implementá-la depois.

Refinamento **não** é implementar código do componente, salvo se o utilizador pedir isso explicitamente.

## Fluxo Obrigatório

### 1. Diagnóstico

Comparar a spec atual com:

- o template;
- o `ui-map.md`;
- o `ui-plan.md`;
- os guides aplicados.

Identificar:

- contradições entre `requirements.md` e `design.md`;
- tasks insuficientes ou genéricas;
- falta de showcase, validação ou encerramento;
- decisões de pacote, namespaces ou CSS ainda vagas;
- sobra de texto do template;
- critérios de aceite pouco testáveis.

### 2. Correção estrutural

A IA deve ajustar a spec para que:

- `requirements.md` descreva claramente objetivo, escopo, critérios de aceite e conclusão;
- `design.md` detalhe pacote, API, estrutura, CSS, showcase e validação esperada;
- `tasks.md` vire um checklist verificável;
- `delivery.md` esteja pronto para receber a entrega futura.

### 3. Alinhamento com guides

A IA deve revisar se a spec respeita os guides, especialmente:

- `01-project-structure.md`
- `02-styles-and-css.md`
- `06-component-anatomy.md`
- `07-form-components.md`, se for caso de formulário
- `08-service-pattern.md`, se houver serviço/outlet
- `09-showcases-and-docs.md`, se houver showcase
- `10-spec-execution-and-delivery.md`

Se houver desvio:

- corrigir a spec;
- ou registrar claramente a dúvida ainda em aberto.

### 4. Tornar a spec implementável

A spec refinada deve sair:

- com pacote sugerido claro;
- com showcase bem definido;
- com validação esperada definida;
- com tasks objetivas;
- com critérios de conclusão prontos para execução futura.

## Regras de Qualidade

- Usar sempre acentuação.
- Não reescrever a spec inteira sem necessidade.
- Preservar decisões já boas.
- Remover ambiguidades, não criar novas.
- Não tratar `RoyalCode.Razor.Show` como host atual.
- Não deixar placeholders do template quando a decisão já puder ser tomada.

## Quando Atualizar `ui-map.md` ou `ui-plan.md`

Ao refinar uma spec, a IA pode atualizar `ui-map.md` ou `ui-plan.md` se:

- descobrir inconsistência evidente entre a spec e os documentos de planeamento;
- a correção for pequena, objetiva e claramente justificável.

Se a mudança for maior ou controversa:

- registrar a observação e não alterar automaticamente.

## Formato Esperado da Resposta Final

A resposta final da IA deve ser curta e conter:

1. o que foi refinado;
2. quais arquivos da spec foram ajustados;
3. principais melhorias introduzidas;
4. pontos ainda em aberto, se houver.

## Prompt Curto Recomendado

```text
Leia `.ai/instructions/refine-spec.md` e refine a spec `pagination`.
```

Ou:

```text
Leia `.ai/instructions/refine-spec.md` e refine a spec `tabs`.
```

Ou:

```text
Leia `.ai/instructions/refine-spec.md` e fortaleça a spec `docs-showcase-foundation`.
```
