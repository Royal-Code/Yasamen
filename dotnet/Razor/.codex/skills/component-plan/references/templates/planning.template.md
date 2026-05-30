# Component Planning - <Nome do Componente>

## Metadados

| Campo | Valor |
|---|---|
| Status | `Planejado` |
| Spec slug | `<slug-da-spec>` |
| Tipo | `Componente` / `Pacote` / `Biblioteca` |
| Prioridade | `P?` |
| Fase do plano | `F?.?` |
| UI Pattern | `UIP-...` |
| Roadmap | `R? > ...` |
| Diretório da spec | `.ai/specs/lib/<slug>/` |

## Contexto de Backlog

- Evidência no ui-map:
- Evidência no ui-plan:
- Evidência no components-plan-list:
- Ausências ou divergências:
- Justificativa para seguir:

## Gate 1 - Alvo

- Alvo aprovado:
- Slug:
- Motivo da prioridade:
- Aprovação humana:
- GAPs:

## Gate 2 - Problema, Objetivo e Escopo

### Problema

- ...

### Objetivo

- ...

### Escopo

- ...

### Fora de Escopo

- ...

### Aprovação

- ...

## Gate 3 - Casos de Uso, Acessibilidade e Aceite

### Casos de Uso

1. ...
2. ...
3. ...

### Estados Obrigatórios

- ...

### Acessibilidade e Responsividade

- ...

### Critérios de Aceite

- [ ] ...

### Aprovação

- ...

## Gate 4 - Estrutura Técnica, Composição e Dependências

- Pacote alvo preliminar:
- Primitivo base ou composto:
- Componentes reutilizados:
- Dependências composicionais:
- Componente-base ausente:
- Decisão sobre pré-requisito:
- Aprovação:

## Gate 5 - API Pública, Variações e Contrato Visual

### Componentes Públicos

- ...

### Parâmetros, Slots e Eventos

- ...

### Style: Themes

- Decisão:
- Temas:
- Fallback de `Themes.Default`:
- Impacto no CSS e showcase:

### Size: Sizes

- Decisão:
- Tamanhos:
- Impacto visual e estrutural:

### CSS Público e Tokens

- Arquivo CSS:
- Classes `ya-*`:
- Tokens de `yasamen.css`:
- Exceções:

### Aprovação

- ...

## Gate 6 - Pacote, Projeto e Showcase

- Pacote existente ou novo:
- Pacote alvo:
- Namespaces:
- Arquivos previstos:
- Referências diretas:
- Subfluxo técnico de criação de projeto:
- Rota de showcase:
- Página de showcase:
- Menu:
- Aprovação:

## Gate 7 - Plano de Execução e Fechamento

### Tasks Principais

- ...

### Validação Esperada

- Build:
- Testes:
- Showcase:
- Validação visual:
- Aceite humano:

### Riscos

- ...

### GAPs e Hipóteses

| Tipo | Item | Hipótese adotada | Impacto | Status |
|---|---|---|---|---|
| GAP | `...` | `...` | `...` | `Aberto` / `Resolvido` |

### Guides Aplicados

- ...

## Decisões Transversais

- [ ] Backlog e contexto fechados.
- [ ] Pacote existente versus pacote novo decidido.
- [ ] API pública definida.
- [ ] `Style: Themes` decidido.
- [ ] Fallback de `Themes.Default` definido quando aplicável.
- [ ] `Size: Sizes` decidido.
- [ ] Tokens de `yasamen.css` definidos.
- [ ] CSS público e classes `ya-*` definidos.
- [ ] Composição, reuso e pré-requisitos definidos.
- [ ] Showcase planejado.
- [ ] Evidência de entrega e validação humana definidas.

## Próximo Passo

- `create-spec`
