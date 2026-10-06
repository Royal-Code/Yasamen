# Protocolo Operacional para Agentes de IA — Yasamen React

> **DIRETIVA MANDATÓRIA**: Este documento é de leitura e execução obrigatória para qualquer agente de IA operando no diretório `js/react/yasamen`. Sem prosa, orientado a comandos imperativos e gates estritos.

---

## 1. Protocolo de Inicialização

Toda sessão iniciada por IA neste repositório DEVE executar o seguinte checklist inicial antes de produzir qualquer código:

1. **LER OBRIGATORIAMENTE**:
   - `docs/structure.md` (Padrões técnicos, convenções CSS, Tailwind e Roadmap).
   - `.kiro/steering/yasamen-css-guidelines.md` (Diretrizes estritas de CSS).
2. **IDENTIFICAR A INTENÇÃO DO USUÁRIO** e chavear para o gatilho correspondente na Seção 2.
3. **NUNCA PULAR ETAPAS DO DUAL TRACK**:
   - Não iniciar implementação sem `requirements.md` e `design.md` aprovados.
   - Não marcar spec como concluída sem validação humana e `delivery.md` preenchido.

---

## 2. Gatilhos de Intenção e Roteamento

| Gatilho | Comando / Pedido Típico | Ação Requerida da IA |
| :--- | :--- | :--- |
| **`GATILHO_1: PLANEJAR_SPEC`** | "Planeje o componente X", "Quero a spec do componente X" | Executar Track 1: Gerar `specs/<componente>/requirements.md` e `design.md`. |
| **`GATILHO_2: GERAR_TAREFAS`** | "Crie as tarefas para a spec X", "Gere o tasks.md" | Executar Track 2 Planning: Gerar `specs/<componente>/tasks.md` completo. |
| **`GATILHO_3: IMPLEMENTAR`** | "Implemente a spec X", "Crie o componente X" (se spec já aprovada) | Executar código (TSX, CSS, index, testes, demo). Atualizar `tasks.md`. |
| **`GATILHO_4: VALIDAR_ENTREGA`** | "Finalize a entrega X", "Valide a entrega" | Rodar `bun run test` + `bun run build`. Gerar `specs/<componente>/delivery.md`. |
| **`GATILHO_5: CONSULTAR_ROADMAP`** | "Qual o próximo componente?", "Como está o roadmap?" | Consultar Seção 7 de `docs/structure.md` e propor o próximo componente prioritário. |

---

## 3. Protocolo Dual Track Passo a Passo

### 3.1 Etapa 1: Discovery (Track 1)
1. Criar diretório `specs/<nome-componente>/`.
2. Preencher `requirements.md` usando o **Template A**.
3. Preencher `design.md` usando o **Template B**.
4. Apresentar ao humano:
   - Resumo da API pública.
   - Decisões de `Themes` e `Sizes`.
   - Perguntas bloqueantes / questões em aberto.
5. **GATE OBRIGATÓRIO**: Aguardar aprovação explícita do humano antes de prosseguir para tarefas.

### 3.2 Etapa 2: Planejamento de Execução (Track 2)
1. Preencher `tasks.md` usando o **Template C**.
2. Garantir que cada tarefa tenha:
   - Critérios de aceite claros.
   - Decisões confirmadas com o humano.
   - Questões em aberto com o humano.
   - Casos de uso para validação.
   - Casos de teste para validação.
   - Validações técnicas e riscos.
3. Obter validação do plano com o humano.

### 3.3 Etapa 3: Implementação Técnica
1. Criar folha de estilo em `src/lib/styles/css/components/<nome>.css` com prefixo `ya-*`.
2. Registrar o `@import` em `src/lib/styles/yasamen.css` na seção `/* components */`.
3. Criar o componente em `src/lib/components/<dominio>/<nome>.tsx`.
4. Criar mapeamento de classes em `<nome>-classes.ts`.
5. Criar exportações em `src/lib/components/<dominio>/index.ts`.
6. Exportar o novo módulo em `src/lib/index.ts`.
7. Criar testes unitários em `src/lib/components/<dominio>/__tests__/<Nome>.spec.tsx`.
8. Criar tela de demonstração em `src/demo/pages/<Nome>Page.tsx` e registrar no menu de `src/demo/App.tsx`.
9. Criar história no Storybook em `src/stories/components/<Nome>.stories.tsx`.

### 3.4 Etapa 4: Auditoria e Entrega
1. Executar testes:
   ```bash
   bun run test
   ```
   (Todos os testes devem passar com 0 falhas).
2. Executar compilação da lib:
   ```bash
   bun run build
   ```
   (Deve gerar `dist/` com bundle ESM, CJS e `.d.ts` sem erros).
3. Gerar `specs/<nome-componente>/delivery.md` usando o **Template D**.
4. Apresentar evidências ao humano e solicitar o aceite explícito.

---

## 4. Templates Oficiais

### Template A: `requirements.md`

```markdown
# Requirements — <Nome do Componente>

## Metadados
| Campo | Valor |
|---|---|
| Status | Rascunho / Aprovado |
| Prioridade | P1 / P2 / P3 |
| UI Pattern | UIP-... (consultar dotnet/Razor/.codex/skills/ui-map-gen2/references/patterns/) |
| Roadmap | Roadmap 1 > ... (consultar docs/structure.md) |
| Diretório Alvo | src/lib/components/<dominio>/ |
| Demo Page | src/demo/pages/<Nome>Page.tsx |

## Objetivo
Descrever o problema que o componente resolve, público-alvo e contexto no design system.

## Escopo
- Componentes públicos e subcomponentes a entregar.
- Estados visuais obrigatórios (hover, active, disabled, focus, loading, etc.).
- Suporte a temas (Themes) e tamanhos (Sizes).
- Suporte a compound slots (se aplicável).
- Suporte a navegação (navigateTo).

## Fora de Escopo
- O que NÃO será entregue nesta iteração.

## Casos de Uso
1. **Caso Principal**: Uso padrão em contexto comum.
2. **Caso de Variação**: Variação com tema/tamanho específico.
3. **Caso de Borda**: Estado desabilitado, vazio ou com erro.

## Requisitos Funcionais
- Assinatura e props obrigatórias/opcionais.
- Comportamento de eventos (onClick, onChange, etc.).
- Comportamento de acessibilidade (ARIA, teclado, contraste).

## Critérios de Aceite
- [ ] O componente atende a todos os casos de uso previstos.
- [ ] Estilização usa exclusivamente classes com prefixo ya-*.
- [ ] Não há estilos inline ou valores hexadecimais brutos no CSS.
- [ ] O componente está exportado em src/lib/index.ts.
- [ ] Testes unitários com cobertura mínima de fluxo feliz e estados de borda.
- [ ] Página na demo SPA criada e navegável.
```

---

### Template B: `design.md`

```markdown
# Design — <Nome do Componente>

## Arquitetura de Componentes
- **Componente Raiz**: `<Nome>`
- **Slots / Subcomponentes**: `<Nome.Slot1>`, `<Nome.Slot2>` (via createSlot / attachSlots)
- **Contexto**: `<Nome>Context` (se compartilhado)

## Contrato da API Pública (TypeScript)
```typescript
export interface <Nome>Props extends React.HTMLAttributes<HTMLElement> {
    theme?: Themes;
    size?: Sizes;
    className?: string;
    navigateTo?: string;
    // Props específicas...
}
```

## Variações de Tema e Tamanho
- **Themes suportados**: Primary, Secondary, Tertiary, etc. (ou justificar ausência).
- **Fallback de tema**: Themes.Primary (ou equivalente).
- **Sizes suportados**: Smallest (2xs) até Largest (2xl) (ou justificar ausência).

## Contrato Visual e Classes CSS (`ya-*`)
- Arquivo CSS: `src/lib/styles/css/components/<nome>.css`
- Mapeamento em TypeScript: `src/lib/components/<dominio>/<nome>-classes.ts`
- Classes públicas:
  - Base: `ya-<nome>`
  - Modificadores de tema: `ya-<nome>-primary`, etc.
  - Modificadores de tamanho: `ya-<nome>-sm`, `ya-<nome>-md`, etc.
  - Estados: `ya-<nome>-disabled`, `ya-<nome>-active`, etc.

## Tokens Tailwind Utilizados
- Cores: `var(--color-primary-*)`, `var(--color-*-500)`
- Espaçamentos: `--spacing-*`
- Tipografia e Breakpoints do `@theme`

## Riscos e Questões em Aberto
- Riscos técnicos ou dependências não resolvidas.
- Trade-offs assumidos.
```

---

### Template C: `tasks.md`

```markdown
# Tasks — <Nome do Componente>

## 1. Decisões Confirmadas com o Humano
- [x] Confirmação 1: ...
- [x] Confirmação 2: ...

## 2. Questões em Aberto com o Humano
- [ ] Dúvida 1: ...
- [ ] Dúvida 2: ...

## 3. Divisão de Tarefas Implementáveis

### Tarefa 1: Criação dos Estilos CSS
- **Ação**: Criar `src/lib/styles/css/components/<nome>.css` e registrar em `src/lib/styles/yasamen.css`.
- **Critérios de Aceite**:
  - [ ] Prefixo `ya-*` em todas as classes.
  - [ ] Usa tokens do `@theme`.
  - [ ] Suporta temas e tamanhos definidos no design.
- **Validações e Riscos**: Não gerar conflito com outras regras CSS.

### Tarefa 2: Implementação do Componente React e Classes
- **Ação**: Criar `<nome>.tsx`, `<nome>-classes.ts` e exportar no `index.ts` do domínio e no `src/lib/index.ts`.
- **Critérios de Aceite**:
  - [ ] Tipagem TypeScript estrita sem `any`.
  - [ ] Suporte a compound slots e `navigateTo` se previstos.
  - [ ] Build `bun run build` continua gerando d.ts sem erros.
- **Validações e Riscos**: Garantir case-sensitivity estrito nos imports.

### Tarefa 3: Testes Unitários
- **Ação**: Criar `src/lib/components/<dominio>/__tests__/<Nome>.spec.tsx`.
- **Critérios de Aceite**:
  - [ ] Cobre renderização base e classes CSS aplicadas.
  - [ ] Cobre cliques, navegação e interações de estado.
  - [ ] `bun run test` passa com 100% de sucesso.
- **Casos de Teste para Validação**:
  - TC01: Renderiza com tema padrão.
  - TC02: Renderiza com variantes de tamanho.
  - TC03: Dispara eventos de clique ou navegação.

### Tarefa 4: Showcase e Demonstração
- **Ação**: Criar `src/demo/pages/<Nome>Page.tsx` e registrar rota em `src/demo/App.tsx`.
- **Critérios de Aceite**:
  - [ ] Exibe todos os temas, tamanhos e estados.
  - [ ] Navegável pelo menu lateral da demo.
- **Casos de Uso para Validação**:
  - UC01: Validação visual em desktop e mobile.

### Tarefa 5: História no Storybook
- **Ação**: Criar história em `src/stories/components/<Nome>.stories.tsx`.
- **Critérios de Aceite**:
  - [ ] Args e controles funcionais.

## 4. Validações Finais
- [ ] `bun run test` aprovado.
- [ ] `bun run build` aprovado.
- [ ] `delivery.md` preenchido.
- [ ] Validação humana realizada.
```

---

### Template D: `delivery.md`

```markdown
# Delivery — <Nome do Componente>

## Metadados
| Campo | Valor |
|---|---|
| Status Final | Concluído / Aguardando Validação Humana |
| Data | YYYY-MM-DD |
| Autor | IA / Nome |
| Spec | specs/<nome-componente>/ |

## Resumo da Entrega
- Resumo conciso do que foi implementado e entregue.
- Desvios ou simplificações em relação ao plano original.

## Changelog
### Added
- `<Componente>` em `src/lib/components/<dominio>/`
- Folha de estilo `src/lib/styles/css/components/<nome>.css`
- Rota e tela na aplicação demo `/demo/<nome>`
- Histórias no Storybook

## Rastreabilidade
| Origem | Item | Evidência no Código | Status |
|---|---|---|---|
| Requirement | Caso de uso principal | `<arquivo>:<linha>` | OK |
| Design | Classes ya-* | `<arquivo>:<linha>` | OK |
| Tasks | Testes unitários | `<arquivo>:<linha>` | OK |

## Validação Executada
| Tipo | Comando / Rota | Resultado |
|---|---|---|
| **Testes** | `bun run test` | OK (X testes passando) |
| **Build da Lib** | `bun run build` | OK (dist/ gerado com sucesso) |
| **Demo SPA** | `bun run build:demo` | OK |
| **Aceite Humano** | Revisão visual na demo | Aprovado em YYYY-MM-DD |

## Fechamento de Tasks
- [x] Todas as tarefas de `tasks.md` concluídas ou justificadas.
- [x] Código com zero avisos ou erros de tipagem.
- [x] Aceite humano registrado.
```

---

## 5. Regras Rígidas de Qualidade para a IA

1. **Nunca use hexadecimais brutos em CSS**: utilize sempre as variáveis `var(--color-*)`.
2. **Nunca use estilos inline para layouts**: utilize utilitários de Tailwind ou classes `ya-*`.
3. **Nunca crie arquivos com imports de case inconsistente**: valide maiúsculas/minúsculas.
4. **Sempre adicione ao `src/lib/index.ts`**: componente não exportado na raiz é considerado incompleto.
5. **Não altere scripts de build no `package.json`** sem justificativa técnica explícita.
6. **Escreva sempre em Português com acentuação correta**.
