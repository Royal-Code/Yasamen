# Yasamen React — Estrutura, Padrões Técnicos e Diretrizes

> Documento técnico normativo para desenvolvimento da biblioteca Yasamen React (`js/react/yasamen`). Escrito de forma diretiva e imperativa para consumo por IA e desenvolvedores.

---

## 1. Visão Geral e Arquitetura

O projeto `yasamen` é o design system e biblioteca de componentes React 19 + TypeScript da RoyalCode.
Ele replica e compatibiliza a arquitetura do projeto Blazor/Razor correspondente (`RoyalCode.Razor`), adaptando os conceitos para o paradigma funcional do React.

### Princípios Inegociáveis
1. **Design Tokens First**: Valores de cor, tipografia e breakpoints derivam do `@theme` do Tailwind CSS v4.
2. **Prefixo CSS Obrigatório `ya-*`**: Todo seletor CSS de componente deve usar o prefixo `ya-`.
3. **Padrão Compound Components / Slots**: Projeção de blocos nomeados baseada em slots (`<Component.Slot>`), espelhando `RenderFragment` do Razor.
4. **Desacoplamento Global por Seções**: Portais e injeções no layout utilizam o sistema `SectionOutlet` / `SectionContent`.
5. **Zero Regressão e TypeScript Estrito**: Todas as props, callbacks, contextos e retornos são estritamente tipados.

---

## 2. Estrutura de Diretórios

```
js/react/yasamen/
├── .storybook/              # Configuração do Storybook 10
├── docs/
│   └── structure.md         # Este documento técnico normativo
├── specs/                   # Especificações Dual Track dos componentes
├── dist/                    # Saída compilada da biblioteca (ESM, CJS, dts, css)
├── src/
│   ├── demo/                # SPA de demonstração e testes manuais
│   │   ├── layout/          # Layout da demo (DemoMainLayout.tsx)
│   │   ├── pages/           # Telas de teste por componente
│   │   ├── App.tsx          # Roteamento da demo
│   │   └── main.tsx         # Ponto de entrada da demo
│   ├── lib/                 # NÚCLEO DA BIBLIOTECA (código distribuído)
│   │   ├── components/      # Componentes organizados por domínio
│   │   │   ├── bsicons/     # Provedor e SVGs dos Bootstrap Icons
│   │   │   ├── button/      # Button, IconButton e testes
│   │   │   ├── commons/     # Tokens, temas, sizes, ripple, navigator
│   │   │   ├── icon/        # Icon abstrato, factory e registry
│   │   │   ├── layouts/     # Bar, Stack, Container, Cols, AppLayout
│   │   │   ├── modal/       # Modal, ModalOutlet, ModalProvider, Backdrop
│   │   │   ├── offcanvas/   # Offcanvas, OffcanvasOutlet, classes
│   │   │   ├── outlet/      # SectionProvider, SectionContent, SectionOutlet
│   │   │   └── status/      # Status, Status404
│   │   ├── styles/          # Estilização global e componentes
│   │   │   ├── css/         # Arquivos CSS modulares
│   │   │   │   ├── components/  # btn.css, modal.css, bar.css, etc.
│   │   │   │   ├── reboot.css   # Reset/normalização
│   │   │   │   ├── ripple.css   # Efeito ripple
│   │   │   │   ├── utilities.css# Utilitários adicionais
│   │   │   │   └── variables.css# Variáveis não-theme (animações, etc.)
│   │   │   └── yasamen.css  # CSS principal (@theme + imports)
│   │   ├── utils/           # compound.tsx, number-value-map, navigation
│   │   └── index.ts         # Exportação pública raiz da biblioteca
│   └── stories/             # Histórias do Storybook (Button, Icon, Bar, etc.)
├── AGENTS.md                # Protocolo de orquestração para IA
├── bun.lock                 # Lockfile de dependências (Bun)
├── package.json             # Manifesto com scripts, exports e dependências
├── tsconfig.json            # Configuração TypeScript de solução
├── tsconfig.app.json        # TSConfig da aplicação demo
├── tsconfig.lib.json        # TSConfig exclusivo da lib e emissão de d.ts
├── vite.config.ts           # Configuração de build Vite (Lib e Demo)
└── vitest.workspace.ts      # Configuração de testes Vitest
```

---

## 3. Como Criar Componentes

Cada componente reside em seu próprio subdiretório em `src/lib/components/<nome-dominio>/`.

### 3.1 Estrutura de Arquivos Obrigatória por Componente

```
src/lib/components/<dominio>/
├── <nome-componente>.tsx          # Componente principal React
├── <nome-componente>-classes.ts    # Mapeamento de classes CSS ya-* (se aplicável)
├── <nome-componente>-context.ts    # Contexto React (se aplicável)
├── index.ts                       # Exportação local de componentes e tipos
└── __tests__/
    └── <NomeComponente>.spec.tsx   # Testes unitários com Vitest + Testing Library
```

### 3.2 Convenções de Código do Componente

1. **Assinatura de Props**:
   - Estenda `React.HTMLAttributes<HTMLElement>` correspondente (`HTMLButtonElement`, `HTMLDivElement`, etc.).
   - Exporte a interface de props explicitamente (`export interface <Componente>Props`).
   - Forneça `className?: string` e combine com as classes internas via `[className, ...classes].filter(Boolean).join(' ')`.

2. **Padrão Compound Slots**:
   - Utilize as funções de `src/lib/utils/compound.tsx`:
     - `createSlot('<NomeSlot>')` para criar marcadores de slot.
     - `attachSlots(RootComponent, { Slot1, Slot2 })` para anexar à função principal.
     - `pickSlots(children, { Slot1, Slot2 })` dentro do render para extrair o conteúdo de cada slot.
     - `hasContent(slotNode)` para renderizar o container do slot apenas se houver conteúdo.

3. **Navegação Integrada (`navigateTo`)**:
   - Componentes acionáveis (botões, links, itens de menu) devem aceitar a prop opcional `navigateTo?: string`.
   - No `onClick`, se `navigateTo` estiver preenchido:
     ```ts
     if (navigateTo) {
       e.preventDefault();
       getNavigator().navigate(navigateTo);
     }
     ```

4. **Efeito Ripple**:
   - Adicione `<Ripple dark={isDark} />` ao final do conteúdo clicável, respeitando `position: relative` e `overflow: hidden` na classe base do elemento.

5. **Exportação Central**:
   - Reexporte o componente em `src/lib/components/<dominio>/index.ts`.
   - Adicione a exportação em `src/lib/index.ts`.

---

## 4. Convenção de Classes CSS e Estilização

Siga rigorosamente as diretrizes em `.kiro/steering/yasamen-css-guidelines.md`.

### 4.1 Nomenclatura das Classes
- Todo componente usa prefixo `ya-`.
- Padrão: `ya-<bloco>[-<elemento>][--<modificador>]` ou `ya-<bloco>-<variante>`.
- Exemplos:
  - `ya-btn`: base do botão.
  - `ya-btn-primary`: botão com tema primário sólido.
  - `ya-btn-primary-outline`: botão primário outline.
  - `ya-btn-sm`: tamanho pequeno.
  - `ya-modal`: container base do modal.
  - `ya-modal-content`: corpo do modal.

### 4.2 Arquivos e Importação no CSS
- Estilos de novos componentes devem ser criados em `src/lib/styles/css/components/<nome>.css`.
- O arquivo deve ser registrado em `src/lib/styles/yasamen.css` na seção `/* components */` em ordem alfabética.
- **Ordem estrita de `yasamen.css`**:
  1. `@import './css/variables.css';`
  2. `@import './css/ripple.css';`
  3. `@import './css/reboot.css';`
  4. `@import 'tailwindcss';`
  5. `@import './css/utilities.css';`
  6. `@import './css/components/<arquivo>.css';`
  7. Bloco `@theme { ... }`

### 4.3 Separação de Responsabilidade TS/CSS
- Não hardcode classes arbitrárias diretamente no JSX.
- Crie um arquivo `<componente>-classes.ts` ou utilize `commons/themes.ts` mapeando os enums/props para as classes CSS.

---

## 5. Como Funciona o Tailwind CSS v4 no Projeto

O projeto utiliza **Tailwind CSS v4** integrado via `@tailwindcss/vite` e configurado no bloco `@theme` de `src/lib/styles/yasamen.css`.

### 5.1 Tokens de Cor Obrigatórios
Existem 11 temas oficiais. Cada tema possui uma cor base e variações numeradas de `100` a `900`:
- `primary`: `#0d6dfd`
- `secondary`: `#6c757d`
- `tertiary`: `#7c3aed`
- `info`: `#7db8f0`
- `highlight`: `#4169E1`
- `success`: `#10b981`
- `warning`: `#fbbf24`
- `alert`: `#f97316`
- `danger`: `#dc3545`
- `light`: `#f8f9fa`
- `dark`: `#212529`

Regras:
- Use `var(--color-primary)` ou classes geradas pelo Tailwind (ex: `bg-primary-500`, `text-primary-500`).
- Nunca insira valores hexadecimais brutos no CSS dos componentes.

### 5.2 Breakpoints do Projeto
Configurados no `@theme`:
- `--breakpoint-xs: 30rem;` (480px)
- `--breakpoint-sm: 40rem;` (640px)
- `--breakpoint-md: 48rem;` (768px)
- `--breakpoint-lg: 64rem;` (1024px)
- `--breakpoint-xl: 80rem;` (1280px)
- `--breakpoint-2xl: 96rem;` (1536px)

### 5.3 Tipografia e Espaçamento
- Fontes: `--font-sans`, `--font-serif`, `--font-mono`.
- Tamanhos de texto estendidos: `--text-4xs` (0.5rem), `--text-3xs` (0.5625rem), `--text-2xs` (0.625rem).
- Espaçamentos numéricos: Mapeados em `src/lib/components/commons/` (`spacing.ts`, `margins.ts`, `paddings.ts`, `heights.ts`, `widths.ts`).

---

## 6. Regras de Desenvolvimento e Garantia de Qualidade

1. **Case-Sensitivity Estrito**:
   - Nomes de arquivos e seus respectivos caminhos nos imports devem bater exatamente com o sistema de arquivos (ex: `./button` para `button.tsx`).
2. **Ciclo de Verificação Obrigatório**:
   - Após qualquer alteração:
     1. Rodar testes: `bun run test` (todos os testes devem passar).
     2. Rodar build da lib: `bun run build` (deve gerar `dist/` sem erros de TypeScript ou Rollup).
3. **Registro na Aplicação Demo**:
   - Todo componente funcional deve ter uma página de demonstração em `src/demo/pages/<Nome>Page.tsx` e ser adicionado às rotas em `src/demo/App.tsx` e `DemoMainLayout.tsx`.
4. **Registro no Storybook**:
   - Histórias com variantes de temas, tamanhos e estados devem ser criadas em `src/stories/components/` ou `src/stories/layouts/`.

---

## 7. Roadmap de Componentes (React vs Razor)

Mapeamento de paridade baseado em `dotnet/Razor/.ai/roadmap/components-plan-list.md`:

### 7.1 Componentes Básicos Iniciais
- [x] **Ripple**: `src/lib/components/commons/Ripple.tsx`
- [x] **Button**: `src/lib/components/button/button.tsx`
- [x] **IconButton**: `src/lib/components/button/iconbutton.tsx`
- [x] **Icon / BootstrapIcons**: `src/lib/components/icon/` e `bsicons/`
- [x] **Bar (Navbar/Toolbar)**: `src/lib/components/layouts/Bar.tsx`
- [x] **Stack**: `src/lib/components/layouts/Stack.tsx`
- [x] **Container & Cols**: `src/lib/components/layouts/Container.tsx`, `Cols.tsx`
- [x] **AppLayout**: `src/lib/components/layouts/apps/AppLayout.tsx`
- [x] **SectionOutlet / SectionContent**: `src/lib/components/outlet/`
- [x] **Modal / Dialog**: `src/lib/components/modal/`
- [x] **Status / Status404**: `src/lib/components/status/`
- [x] **Offcanvas (Drawer/Painel lateral)**: `src/lib/components/offcanvas/`
- [ ] **ButtonGroup**: Agrupamento de botões com estilo conectado
- [ ] **Badge**: Indicador visual e contadores
- [ ] **Alert / Feedback**: Mensagens e alertas de status
- [ ] **Notification / Toast**: Sistema de notificações com auto-dismiss
- [ ] **Dropdown**: DropButton, DropIconButton, DropItem

### 7.2 Componentes de Formulário Essenciais
- [ ] **FormControl / FieldGroup**: Base estrutural com label, erro, dica e addons
- [ ] **TextField**: Input de texto, senha e email com suporte a temas e tamanhos
- [ ] **TextArea**: Campo multilinhas
- [ ] **Select**: Dropdown de seleção simples e nativa
- [ ] **CheckBox**: Caixa de seleção com suporte a indeterminate
- [ ] **RadioBox / RadioGroup**: Seleção única com opções agrupadas
- [ ] **Switch (Toggle)**: Interruptor liga/desliga
- [ ] **DatePicker**: Seleção de datas e horas
- [ ] **NumberField**: Input numérico com controles de incremento

### 7.3 Componentes Diversos e de Navegação
- [ ] **Breadcrumb**: Trilha de navegação hierárquica
- [ ] **Card / Box**: Contêiner com header, body e footer
- [ ] **Pagination**: Controle de paginação de dados
- [ ] **Tabs**: Navegação em abas com painéis sincronizados
- [ ] **Accordion / Collapse**: Seções colapsáveis com animação
- [ ] **Popover**: Container flutuante contextual
- [ ] **Tooltip**: Dica flutuante acionada por hover/foco
- [ ] **ProgressBar**: Barra de progresso linear com variantes
- [ ] **Spinner / Loader**: Indicador de carregamento giratório
- [ ] **Skeleton / Placeholder**: Mock visual animado de conteúdo carregando

### 7.4 Componentes Complexos
- [ ] **DataGrid / Table**: Tabela de dados com ordenação, filtros e paginação
- [ ] **Tree / TreeView**: Visualização hierárquica em árvore
- [ ] **Calendar / Agenda**: Visão de eventos por mês/semana
- [ ] **Kanban**: Quadro de cartões por colunas
- [ ] **AutoComplete**: Busca preditiva com lista flutuante

---

## 8. Mecanismo de Spec Dual Track

O desenvolvimento de componentes obedece à metodologia **Dual Track**, dividida em duas faixas complementares:

```
[TRACK 1: DISCOVERY / DEFINIÇÃO]
  requirements.md ───► design.md ───► Gate de Aprovação Humana
                                             │
                                             ▼
[TRACK 2: EXECUTION / ENTREGA]
  tasks.md ─────────► Implementação ──► Testes & Showcase ──► delivery.md
```

### 8.1 Track 1: Discovery (Requisitos e Design)
- **`requirements.md`**: Define o problema, casos de uso, acessibilidade, critérios de aceite e escopo.
- **`design.md`**: Define arquitetura técnica, API pública (props, slots, eventos), suporte a `Style: Themes` e `Size: Sizes`, tokens e classes `ya-*`, riscos e decisões técnicas.

### 8.2 Track 2: Execution (Tarefas e Entrega)
- **`tasks.md`**: Decomposição em tarefas granulares contendo obrigatoriamente:
  - Tarefa a executar.
  - Critérios de aceite verificáveis.
  - Decisões confirmadas com o humano.
  - Questões em aberto com o humano.
  - Casos de uso para validação.
  - Casos de teste para validação.
  - Validações técnicas e riscos.
- **`delivery.md`**: Registro formal de conclusão, changelog, rastreabilidade, evidências de testes e aceite humano explícito.

### 8.3 Localização das Specs
Todas as specs devem ser salvas no diretório `specs/<nome-componente>/`:
```
specs/<nome-componente>/
├── requirements.md
├── design.md
├── tasks.md
└── delivery.md
```
