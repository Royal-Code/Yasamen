# Visual Language — yasamen-razor

---

## Resumo executivo

yasamen-razor é uma biblioteca Blazor/Razor Components com identidade flat, semântica e app-centric. A paleta é inteiramente própria — sem herança de Bootstrap, Material ou Tailwind UI — baseada em onze temas semânticos (primary, secondary, tertiary, success, warning, danger, alert, info, highlight, light, dark) cada um com escala de 100 a 900. Ações primárias usam shade-400 (tom médio), indicadores de status usam shade-100/200/800 (tons suaves), texto principal usa dark-600/700. Motion é rápido e sutil (150ms linear). A estética é contida: sem gradientes, sem sombras pesadas, com ripple como único elemento de ornamentação interativa. Lacunas relevantes: sem tabela/data grid, sem inputs avançados (select, checkbox, radio), sem tabs, sem dark mode, sem tooltip standalone.

---

## Identidade visual dominante — OBRIGATÓRIO

**Regra**: A biblioteca tem identidade flat, semântica e app-centric — sem decoração desnecessária, sem herança de outro design system.
- **Força**: forte
- **Aplicação**: usar a paleta semântica nativa, componentes públicos como estão, sem sobreposição de estilo externo. A identidade vem dos tokens `yasamen.css`, não de classes Bootstrap ou Material.
- **Evitar**: misturar classes Bootstrap/Material com classes `ya-*`, inventar gradientes, sombras pesadas ou efeitos que a biblioteca não define.

**Regra**: Feedback tátil via ripple nos botões é a única ornamentação interativa prevista.
- **Força**: forte
- **Aplicação**: aceitar o ripple nos botões como comportamento nativo; não suprimir nem duplicar com outro efeito visual.
- **Evitar**: adicionar hover effects adicionais, animações de escala ou glow — a biblioteca não os prevê.

**Regra**: Motion rápido e sutil — 150ms linear como padrão.
- **Força**: forte
- **Aplicação**: confiar nos transitions dos componentes (`transition-default` = 150ms); não sobrepor duração de transição via `AdditionalClasses` sem motivo funcional.
- **Evitar**: animações lentas (>300ms) para interações simples; animações de entrada/saída exceto nas fases de Modal e Notification que já as têm nativas.

---

## Princípios visuais observados — OBRIGATÓRIO

**P1 — Contenção**: Nenhum componente usa gradiente, sombra pesada ou decoração ornamental.
- **Força**: forte
- **Aplicação**: superfícies brancas puras (bg-white), sombras apenas em notificações (shadow-lg) e offcanvas (sombra lateral 3px sutil).
- **Evitar**: box-shadow nos componentes de conteúdo (Box, Card via Box, modais de conteúdo).

**P2 — Semântica de cor sem sintaxe decorativa**: cada cor carrega significado funcional, não estético.
- **Força**: forte
- **Aplicação**: `Themes.Success` para confirmação, `Themes.Danger` para destruição, `Themes.Warning` para atenção — escolha o tema pelo significado, não pela cor.
- **Evitar**: usar `Themes.Highlight` ou `Themes.Alert` apenas por preferência visual, sem contexto semântico.

**P3 — Hierarquia por saturação, não por tamanho**: ação principal via filled (bg-400), secundária via outline, terciária via light.
- **Força**: forte
- **Aplicação**: em todo agrupamento de ações, usar variantes diferentes para indicar importância relativa. Nunca usar dois botões filled no mesmo contexto imediato.
- **Evitar**: dois `Themes.Primary` filled no mesmo grupo de ações; filled sem ser a ação mais importante do contexto.

**P4 — Disabled por opacidade**: componentes desabilitados reduzem opacidade a 50% sem alterar cor.
- **Força**: forte
- **Aplicação**: confiar no comportamento nativo; não personalizar cor de disabled — a opacidade uniform já cobre todos os temas.
- **Evitar**: sobrescrever opacity de componentes disabled.

**P5 — Superfícies brancas**: todas as superfícies de overlay e container usam bg-white.
- **Força**: forte
- **Aplicação**: Modal, OffCanvas, Notification, footer, AsideBox — sempre branco puro como fundo.
- **Evitar**: fundos coloridos em superfícies de overlay.

**P6 — Ícones externos e extensíveis**: a biblioteca não embutem ícones fixos; usa sistema extensível via `WellKnownIcons`.
- **Força**: forte
- **Aplicação**: registrar o pacote `RoyalCode.Razor.Icons.Bootstrap` (ou equivalente) na DI; sem ele, ícones de sistema mostram fallback "ban".
- **Evitar**: passar SVG inline em parâmetros de ícone — usar `Enum Kind` via `IIconContentFactory`.

---

## Hierarquia perceptiva — OBRIGATÓRIO

### Hierarquia de ações

| Nível | Variante | Parâmetros | Quando usar |
|---|---|---|---|
| Primária | Filled / `Themes.Primary` | `Style=Primary` (default `Outline=false`) | Ação principal do contexto — max 1 por grupo |
| Secundária | Outline | `Style=Primary, Outline=true` ou `Style=Secondary` | Ação alternativa, cancelar, voltar |
| Terciária | Light | `Style=Light` | Ação opcional, contexto expandido |
| Destrutiva | Filled Danger | `Style=Danger` | Exclusão permanente, ação irreversível |
| Ícone-só | `IconButton` | `Style=*, Icon=*` | Ações contextuais compactas (editar, fechar, menu) |
| Dropdown | `DropButton` / `DropIconButton` | `Style=*, Text/Icon` | Ações secundárias agrupadas, contexto de linha |
| Desabilitada | Qualquer | `Disabled=true` | Ação indisponível — mesma variante, opacity 50% |

### Hierarquia tipográfica

| Nível | Token CSS | Size | Weight | Uso |
|---|---|---|---|---|
| Título de seção | Tailwind `text-xl` / `text-2xl` | 1.25–1.5rem | semibold (`font-semibold`) | Título de página, modal, feedback |
| Texto de label | Herda body | ~0.875rem | normal (herda) | Labels de form, rótulos |
| Texto de conteúdo | `text-base` / `text-sm` | 1rem / 0.875rem | normal | Corpo de conteúdo |
| Detalhe compacto | `text-2xs` (`0.625rem`) | 0.625rem | normal | Detalhe de notificação, legenda micro |
| Badge / label compacto | `text-xs` / `text-2xs` | 0.75rem / 0.625rem | normal | Badges, indicadores |

### Status por cor vs importância por tamanho

- **Cor** = semântica (success, danger, warning, info): indica tipo de informação, não hierarquia.
- **Tamanho** (`Sizes.*`) = importância perceptiva: use size maior para ação em destaque, menor para contexto compacto.
- Badges usam cor para status (verde=sucesso, vermelho=erro) mas size pequeno — não competem com ações.

---

## Spacing, ritmo e densidade — OBRIGATÓRIO

### Escala de espaçamento

| Token Tailwind | Valor rem | Valor px | Uso típico |
|---|---|---|---|
| `spacing-3` / `p-3` | 0.25rem | 4px | micro padding (badges, labels compactos) |
| `spacing-4` / `p-4` | 0.5rem | 8px | gap entre elementos inline |
| `spacing-5` / `p-5` | 0.75rem | 12px | padding interno de toasts, label-input gap |
| `spacing-6` / `p-6` | 1rem | 16px | padding padrão de conteúdo |
| `spacing-7` / `p-7` | 1.5rem | 24px | separação entre seções |
| `spacing-8` / `p-8` | 2rem | 32px | padding de página / margens amplas |

### Padding de botões por tamanho

| Sizes | Classe CSS | Padding X / Y | Size texto |
|---|---|---|---|
| `Smallest` | `ya-btn-2xs` | px-3 / py-1 | text-2xs |
| `Smaller` | `ya-btn-xs` | px-4 / py-2 | text-xs |
| `Small` | `ya-btn-sm` | px-4 / py-2 | text-sm |
| `Medium` | `ya-btn-md` | px-5 / py-3 | text-base |
| `Large` | `ya-btn-lg` | px-6 / py-4 | text-lg |
| `Larger` | `ya-btn-xl` | px-6 / py-4 | text-xl |
| `Largest` | `ya-btn-2xl` | px-7 / py-4 | text-2xl |

### Regras de densidade

- **Componentes internos**: `p-3` (0.75rem) como padding base para toasts e campos compactos.
- **Separação label→input**: `mb-3` (~0.75rem) no `FieldGroup`, descendo para `mb-2.5` no tamanho 2xs.
- **Separação entre componentes**: usar `mt-*` / `mb-*` via `AdditionalClasses` ou `MarginBuilder` — a biblioteca não impõe margem externa automática entre componentes.
- **Padding de página**: usar `Container` com padding, ou `Box` com `PaddingBuilder` — evitar padding manual em `AppContent`.

---

## Peso e proporção entre zonas — OBRIGATÓRIO

### Shell visual

```
┌─────────────────────────────────────────────────────┐
│  AppTopBar (fixo, z=1010, height=LargerX2)          │
├────────┬────────────────────────────────────────────┤
│ Side   │                                            │
│ Bar    │  AppContent (scroll, max-sm:mx-0)          │
│ (fixo) │                                            │
│        │                                            │
│        ├────────────────────────────────────────────┤
│        │  Footer (self-end, bg-white)               │
└────────┴────────────────────────────────────────────┘
         [OffCanvas z=1030 sobrepõe sidebar+content]
         [Modal z=1070 sobrepõe tudo exceto notif]
         [Notification z=1090 no topo absoluto]
```

### Regras de zonas

**Regra**: Header fixo sempre acima de conteúdo, abaixo de overlays.
- **Força**: forte
- **Aplicação**: `AppTopBar` com `z-app-bar (1010)` — não adicionar z-index manual no header.
- **Evitar**: conteúdo com z-index maior que 1010 fora de overlay.

**Regra**: Shell ocupa 100% do viewport (grid w-full min-h-screen).
- **Força**: forte
- **Aplicação**: usar `AppLayout` como wrapper raiz; não criar wrappers de viewport adicionais.
- **Evitar**: height/width customizados no elemento raiz do `AppLayout`.

**Regra**: Camadas de overlay bem definidas — não inverter a ordem.
- **Força**: forte
- **Aplicação**: respeitar a stack app-bar(1010) < offcanvas(1030) < modal(1070) < notification(1090).
- **Evitar**: z-index manual em componentes de conteúdo que ultrapasse 1010.

**Regra**: Footer adesivo ao final do conteúdo, fundo branco.
- **Força**: forte
- **Aplicação**: colocar footer dentro do `AppLayout` no slot de footer — `self-end bg-white` é aplicado automaticamente.
- **Evitar**: footer com fundo colorido ou sombra superior.

---

## Ação principal e ações secundárias — OBRIGATÓRIO

### Hierarquia de botões por contexto

| Contexto | Posição | Componente | Variante | Style |
|---|---|---|---|---|
| Formulário — salvar | direita, último | `Button` | filled | `Primary` |
| Formulário — cancelar | esquerda do salvar | `Button` | outline | `Secondary` |
| Formulário — deletar | esquerda, separado | `Button` | filled | `Danger` |
| Listagem — criar | cabeçalho, direita | `Button` | filled | `Primary` |
| Listagem — ações de linha | coluna de ações | `IconButton` ou `DropIconButton` | outline ou icon | `Secondary` ou `Default` |
| Toolbar — ações secundárias múltiplas | grupo | `ButtonGroup` | variado | contextual |
| Modal — confirmar | direita | `Button` | filled | `Primary` ou `Danger` |
| Modal — cancelar | esquerda do confirmar | `Button` | outline | `Secondary` |

### Ação destrutiva segura

- **Regra**: toda ação destrutiva irreversível deve usar `Themes.Danger` e idealmente estar dentro de um Modal de confirmação.
- **Força**: fraca (recomendação de composição)
- **Aplicação**: `<Button Style="Themes.Danger" Label="Excluir" />` dentro de um `Modal` com ação de cancelamento clara.
- **Evitar**: botão Danger sem confirmação para deleções permanentes.

### Feedback pós-ação

- Sucesso: `NotificationService.Show(...)` com `Themes.Success` — toast auto-fechável.
- Erro: `Feedback` inline com `Themes.Danger` ou `NotificationService` com `Themes.Danger`.
- Progresso: `Button` com `IconAnimation` usando `RotationMotion` no ícone.

---

## Tipografia, cor e superfície — OBRIGATÓRIO

### Tipografia

- **Família**: `system-ui` (sans-serif nativo do sistema operacional) — sem fonte customizada.
- **Peso padrão**: normal (herdado do body); `font-semibold` explícito em títulos de componentes.
- **Escala Tailwind padrão**: `text-xs` (0.75rem) a `text-2xl` (1.5rem) para conteúdo geral.
- **Escala micro** (abaixo de xs): `text-2xs` (0.625rem), `text-3xs` (0.5625rem), `text-4xs` (0.5rem) — para badges e labels compactos.
- **Line-heights semânticos**: leading-none (1), xs (1.125), sm (1.25), base (1.5), lg (1.75), xl (2).

| Uso | Size | Weight | Line-height |
|---|---|---|---|
| Título de feedback/modal | text-base a text-lg | font-semibold | leading-sm |
| Corpo de conteúdo | text-base (1rem) | normal | leading-base (1.5) |
| Labels de formulário | text-sm (0.875rem) | normal | leading-sm |
| Texto de botão (md) | text-base | font-medium | leading-none |
| Detalhe de notificação | text-2xs (0.625rem) | normal | leading-xs |
| Badge / pill | text-xs a text-2xs | normal | leading-none |

### Paleta de cores

| Shade | Semântica | Uso típico |
|---|---|---|
| `{tema}-100` | fundo suave | Badge bg, Feedback bg, hover neutro |
| `{tema}-200` | borda suave | Badge border, Feedback border |
| `{tema}-400` | ação / identidade | Button bg (filled), Notification borda, ícone de notificação |
| `{tema}-600` | hover | Button hover state |
| `{tema}-700` | pressed | Button active/pressed state |
| `{tema}-800` | texto sobre pastel | Badge text, Feedback text |
| `{tema}-900` | texto enfático | Texto de botões success/warning/danger (contraste sobre 400) |
| `dark-600` | texto base | Conteúdo principal |
| `dark-700` | detalhe | Subtexto, legendas |
| `light-50` / `light-100` | hover neutro | Hover em elementos sem tema |

**Regra**: ações em shade-400, indicadores de status em pastel (100/200/800).
- **Força**: forte
- **Aplicação**: botões preenchidos com `bg-{tema}-400`; badges e feedback com `bg-{tema}-100 border-{tema}-200 text-{tema}-800`.
- **Evitar**: inverter (botão pastel, badge vibrante).

**Regra**: texto principal com `dark-600`/`dark-700`, não com `black` ou `gray-*`.
- **Força**: forte
- **Aplicação**: para texto em layouts, usar `text-dark-600` ou `text-dark-700`.
- **Evitar**: `text-black`, `text-gray-500` (não são tokens da paleta).

### Superfícies e profundidade

| Superfície | Background | Shadow | Radius | Uso |
|---|---|---|---|---|
| Modal | bg-white | nenhuma | rounded-md | Diálogos, confirmações |
| OffCanvas | bg-white | `3px 0 3px 0 #00000020` (lateral sutil) | nenhum | Painéis laterais, menus |
| Notification | bg-white | shadow-lg | rounded-md | Toasts |
| AsideBox | bg-white | nenhuma | nenhum | Conteúdo interno de OffCanvas |
| Box | bg-white (default) | via `BorderBuilder.BoxWithShadow` | rounded via BorderBuilder | Containers de conteúdo |
| Footer | bg-white | nenhuma | nenhum | Rodapé da aplicação |

### Bordas e raios

| Componente / Contexto | Radius | Borda |
|---|---|---|
| Button (geral) | rounded-md | nenhuma (filled) / 1px colored (outline) |
| Badge | rounded-full | 1px colored-200 |
| Input (FieldGroup) | rounded-md | 1px border-default |
| Notification | rounded-md | 2px left-border colored-400 |
| Modal | rounded-md | nenhuma |
| Box (default) | via BorderBuilder | via BorderBuilder |

**Regra**: radius proporcional ao tamanho — sm para compactos, md para médios, lg para grandes, full para pills/badges.
- **Força**: forte
- **Aplicação**: usar os modificadores de radius nativos dos componentes; não adicionar radius externo.
- **Evitar**: border-radius manual em componentes que já têm radius definido.

---

## Contenção ou ornamentação — OBRIGATÓRIO

**Regra**: sem gradientes em nenhum componente.
- **Força**: forte
- **Aplicação**: backgrounds são sempre cores planas.
- **Evitar**: `background: linear-gradient(...)` em qualquer elemento da interface.

**Regra**: elevação mínima e funcional — sombras apenas onde há sobreposição real.
- **Força**: forte
- **Aplicação**: shadow-lg apenas em `Notification` (toast flutuante); sombra lateral leve em `OffCanvas` (3px lateral); zero sombra em box, modal, botão.
- **Evitar**: box-shadow decorativo em cards, headers, listas.

**Regra**: ícones externos registrados em `WellKnownIcons`, não embutidos no markup.
- **Força**: forte
- **Aplicação**: usar `<Icon Kind="..." />` ou `@WellKnownIcons.{Nome}("classes")` — não inserir SVG inline nos templates.
- **Evitar**: SVG inline, base64, emoji como substituto de ícone funcional.

**Regra**: ripple como único elemento de ornamentação interativa.
- **Força**: forte
- **Aplicação**: ripple é automático nos botões via `Ripple.razor` — não suprimir.
- **Evitar**: adicionar hover scale, box-glow ou qualquer outro efeito interativo sobre os botões.

**Regra**: separação visual por borda (border-b) ou espaçamento, não por linha decorativa separada.
- **Força**: forte
- **Aplicação**: `border-b` no título do `Feedback`; espaçamento entre seções de formulário via `mb-*`.
- **Evitar**: `<hr>` decorativo sem valor estrutural, separadores coloridos.

---

## Estados e interação — OBRIGATÓRIO

### Tabela de estados

| Estado | Padrão visual | Implementação |
|---|---|---|
| Normal | cor plana base | classe raiz + tema |
| Hover | `bg-{tema}-600` (2 shades acima do normal 400) | CSS automático — não requer prop |
| Pressed / Active | `bg-{tema}-700` (3 shades acima) | CSS automático |
| Focus | ring semitransparente `ring-{tema}-300/50` | CSS automático via `focus-within:` |
| Disabled | `opacity-50 cursor-not-allowed` | `Disabled=true` no componente |
| Loading (pagination) | `opacity-80` | `Loading=true` no componente |
| Active (sideitem) | `ya-side-bar-item active` | controlado pelo router/código da aplicação |

### Regras de motion

| Componente | Animação | Duração |
|---|---|---|
| Modal | slide-down (translateY -50px→0) + fade | 150ms (padrão) |
| Notification | slide direcional + fade por posição | 150ms (padrão) |
| OffCanvas | translate-x ±100% → 0 | 150ms (padrão) |
| Botão | ripple on click | ~300ms (inerente ao ripple) |
| Ícone rotativo | RotationMotion continuous | configurable via `--duration-*` |
| Transition padrão | `transition-colors 150ms linear` | `--duration-default: 0.15s` |

**Regra**: modal com slide-down + fade em duas fases (opening-start → opening → open).
- **Força**: forte
- **Aplicação**: as classes de fase são controladas internamente — não interferir com classes de transformação no conteúdo interno do modal.
- **Evitar**: CSS que contra-animate com o modal (ex: transform no filho direto do `ya-modal`).

### Feedback ao usuário

| Tipo | Componente | Persistência | Quando usar |
|---|---|---|---|
| Sucesso de operação | `Notification` (Success) | Auto-fechável (timer) | Após save, submit, ação concluída |
| Erro de validação | `Feedback` inline (Danger) | Permanente até fechar | Erro em formulário, validação de campo |
| Erro de sistema | `Notification` (Danger) | Auto-fechável ou manual | Exceção, falha de API |
| Alerta informativo | `Feedback` (Warning/Info) | Permanente | Aviso contextual, instrução importante |
| Status em item | `Badge` | Permanente | Status de registro em listagem ou detalhe |

---

## Responsividade e adaptação — OBRIGATÓRIO

### Breakpoints

| Token | Valor | Dispositivo típico |
|---|---|---|
| `xs` | 480px | Mobile pequeno |
| `sm` | 640px | Mobile |
| `md` | 768px | Tablet |
| `lg` | 1024px | Laptop |
| `xl` | 1280px | Desktop |
| `2xl` | 1536px | Wide desktop |

### Regras de adaptação

**Regra**: grid responsivo via `Container` + `Slot` com spans por breakpoint.
- **Força**: fraca (recomendação)
- **Aplicação**: `<Slot Span="12" TabletSpan="6" LaptopSpan="4">` — grid de 12 colunas, colapsa para full-width no mobile.
- **Evitar**: media queries manuais para layouts que o `Container`+`Slot` já cobre.

**Regra**: `Pagination` adapta automaticamente — componente único renderiza versões mobile e desktop via CSS.
- **Força**: forte
- **Aplicação**: usar `<Pagination />` sem wrapper condicional — o CSS controla visibilidade por breakpoint.
- **Evitar**: esconder/mostrar a paginação manualmente via código C#.

**Regra**: conteúdo sem margem lateral em mobile (`max-sm:mx-0`).
- **Força**: forte
- **Aplicação**: `AppContent` já aplica `mx-0` em mobile — não adicionar margens laterais no conteúdo de página para mobile.
- **Evitar**: `px-*` fixo no container de página que force margem lateral em mobile.

**Regra**: sidebar e header adaptam via `SpacingSize` — não via media query manual.
- **Força**: forte
- **Aplicação**: configurar `AppLayout` com `TopBarSize`, `SideBarSize` etc. via `SpacingSize.*`.
- **Evitar**: dimensões fixas (px, rem hardcoded) para header/sidebar.

---

## Padrões visuais recorrentes — OBRIGATÓRIO

### Shell e navegação

A biblioteca oferece shell completo: `AppLayout` (wrapper), `AppTopBar` (header fixo), `AppSideBar` (sidebar fixa de ícones), `AppMenu` (nav via OffCanvas), `AppSideMenuButton` (hamburguer). O padrão esperado é sidebar estreita de ícones + menu completo em OffCanvas ativado pelo `AppSideMenuButton`. Para aplicações simples sem sidebar, apenas `AppLayout` + `AppTopBar` já formam shell funcional.

**Quando usar sidebar**: app com muitas seções de navegação; sidebar estreita de ícones + OffCanvas para menu expandido.
**Quando não usar**: telas de autenticação, landing pages, telas de erro — usar layout simples sem `AppLayout`.

### Listagem e dados

A biblioteca **não tem** componente de tabela ou data grid. Para listagens:
- Usar `Box` com conteúdo HTML estruturado (table nativa ou listas) + `Badge` para status.
- Usar `Container` + `Slot` para grid de cards.
- `Pagination` para navegação de páginas.
- `DropIconButton` para ações de linha (editar, excluir, mais opções).

### Formulários

Padrão: `FieldGroup` (label acima do input) é o único layout de campo da biblioteca. Inputs disponíveis: `FieldText` (texto/número/email), `FieldAction` (com botão integrado), `FieldBadge` (com badge integrado). Para select, checkbox, radio, datepicker: usar HTML nativo dentro de `FieldGroup` ou implementar customizado.

Layout de formulário responsivo:
```razor
<Container Type="LayoutTypes.Grid">
    <Slot Span="12" TabletSpan="6"><FieldText Label="Nome" ... /></Slot>
    <Slot Span="12" TabletSpan="6"><FieldText Label="Email" ... /></Slot>
    <Slot Span="12">
        <Bar>
            <StartContent><Button Style="Themes.Secondary" Outline=true Label="Cancelar" /></StartContent>
            <EndContent><Button Style="Themes.Primary" Label="Salvar" /></EndContent>
        </Bar>
    </Slot>
</Container>
```

### Feedback ao usuário

| Cenário | Componente | Motivo |
|---|---|---|
| Mensagem temporária de sucesso | `Notification` (Success, auto-close) | Não bloqueia fluxo |
| Erro de formulário persistente | `Feedback` (Danger) inline | Fica visível enquanto há erro |
| Confirmação de ação destrutiva | `Modal` (Danger) com botão Danger | Bloqueia até decisão |
| Status de item em lista | `Badge` (tema semântico) | Não invasivo, escanável |
| Alerta contextual permanente | `Feedback` (Warning/Info) | Leitura obrigatória |

**Toast vs Alert vs Modal**: use Toast (Notification) para feedback não-bloqueante pós-ação; Alert (Feedback) inline quando o erro/aviso está vinculado a um elemento específico; Modal apenas para decisões que exigem confirmação explícita do usuário.

### Overlays

| Overlay | Componente | Quando usar |
|---|---|---|
| Diálogo de confirmação | `Modal` | Ações destrutivas, confirmações críticas |
| Painel lateral | `OffCanvas` | Formulários secundários, detalhes de item, filtros avançados |
| Menu de navegação | `AppMenu` (OffCanvas interno) | Navegação principal expandida |
| Notificação flutuante | `Notification` | Feedback não-bloqueante |

**Modal vs OffCanvas**: Modal para decisões que bloqueiam o fluxo (confirmação, erro crítico); OffCanvas para conteúdo complementar não-bloqueante (detalhe, filtro lateral, formulário de edição rápida).

### CRUD recorrente

- **Listagem**: Bar(cabeçalho com título + Button Primary "Criar") + Container+Slot(grid de itens) + Pagination
- **Detalhe**: Box com conteúdo + Bar(ações: editar, voltar) + Badge(status) + Feedback(erros)
- **Formulário criar/editar**: Container+Slot(grid campos) + Bar(Cancelar outline + Salvar filled) + Feedback(erros)
- **Confirmação de exclusão**: Modal com texto explicativo + Button Danger "Excluir" + Button Secondary "Cancelar"

---

## Critérios de uso por IA — OBRIGATÓRIO

1. **Início**: verificar se o cenário exige shell (`AppLayout`) ou apenas componentes isolados.
2. **Ação principal**: identificar a ação mais importante → `Button Filled Primary`. Max 1 por contexto imediato.
3. **Hierarquia de ações**: demais ações → outline, light ou dropdown conforme importância relativa.
4. **Feedback**: toda operação com resultado visível precisa de feedback → escolher Toast vs Feedback vs Modal conforme urgência e bloqueio.
5. **Status de dados**: usar `Badge` com tema semântico — não usar cor direta via `AdditionalClasses`.
6. **Formulários**: sempre `FieldGroup` via `FieldText`/`FieldAction`/`FieldBadge`; para inputs não cobertos, HTML nativo dentro de `FieldGroup` com slot `Control`.
7. **Layout responsivo**: usar `Container`+`Slot` com spans por breakpoint — não usar CSS grid manual.
8. **Sobreposições**: preferir `OffCanvas` para conteúdo complementar; `Modal` apenas para bloqueio de fluxo.
9. **Ícones**: sempre via `WellKnownIcons.*` ou `<Icon Kind="..." />` — nunca SVG inline.
10. **Lacunas**: para table, tabs, select, checkbox, radio, tooltip, datepicker → usar HTML nativo ou implementação customizada; documentar como fora da biblioteca.
11. **AdditionalClasses**: usar apenas para spacing externo (`mt-*`, `mb-*`) e customizações pontuais — nunca para sobrescrever cor, radius ou animação dos componentes.
12. **Dark mode**: não implementado — aplicações que precisem devem implementar por conta própria fora da biblioteca.

**Ordem de consulta**: `visual.language.md` (intenção) → `visual.map.md` (recurso concreto) → `components.summary.md` (props do componente) → `ui-guide.md` (tokens e helpers CSS).

---

## Resolução de conflitos — OBRIGATÓRIO

Para **valor concreto** (cor, size, spacing, radius):
- Token em `yasamen.css` @theme prevalece sobre qualquer outro.
- CSS de componente (`btn.css`, `badge.css`, etc.) prevalece sobre documentação.
- Padrão com 3+ ocorrências prevalece sobre caso isolado.

Para **intenção de uso** (quando usar, onde posicionar, qual componente):
- `ui-guide.md` e `structure.md` prevalecem sobre padrão recorrente.
- Padrão recorrente (3+ exemplos no código) prevalece sobre token isolado.
- Anti-padrão explícito neste documento prevalece sobre qualquer exemplo observado.

**Conflito específico documentado**: shade-400 vs shade-500 para primary.
- Token `--color-primary` é shade-500 (`#0d6dfd`) — identidade da marca.
- Botões preenchidos usam shade-400 — ações em tom médio para não saturar.
- Regra: `primary-500` para cor de identidade (logo, link de marca); `primary-400` para botões e ações (comportamento já no CSS).

---

## Limites, lacunas e anti-padrões — OBRIGATÓRIO

### Limites

| Capacidade | Status | Impacto |
|---|---|---|
| Tabela / data grid | ausente | Listagens tabulares precisam de HTML nativo ou lib externa |
| Select, checkbox, radio, datepicker | ausente | Formulários complexos requerem HTML nativo |
| Tabs / navegação por abas | ausente | Implementar customizado |
| Dark mode | ausente | App define por conta própria |
| Tooltip standalone | ausente | Implementar via HTML `title` ou lib externa |
| Card component | sem componente dedicado — usar `Box` | Composição manual necessária |
| Heading tokens (h1/h2/h3) | sem tokens definidos | App define hierarquia tipográfica de conteúdo livremente |
| Spinner standalone | sem componente dedicado — usar `RotationMotion` em ícone | Compor manualmente |
| Progress bar | sem componente | Implementar com HTML/CSS externo |

### Anti-padrões

| Anti-padrão | Por que é ruim | Alternativa segura |
|---|---|---|
| Dois botões `Filled Primary` no mesmo grupo | Destrói hierarquia de ação | Um Filled Primary + um Outline Secondary |
| `Themes.Danger` em ação não-destrutiva | Falso alarme visual, treina usuário a ignorar danger | `Themes.Secondary` ou `Themes.Warning` conforme contexto |
| z-index manual acima de 1010 em conteúdo | Conflito com overlays de Modal/OffCanvas/Notification | Nunca definir z-index em conteúdo — usar overlays da biblioteca |
| `*.razor.css` novo em componente customizado | Viola convenção da biblioteca (CSS público apenas em `Styles/wwwroot/`) | Adicionar CSS em `RoyalCode.Razor.Styles/wwwroot/css/` ou usar classes Tailwind via `AdditionalClasses` |
| Sobrescrever `opacity` de elemento `Disabled` | Rompe contrato visual de estado desabilitado | Deixar o comportamento nativo (`Disabled=true`) |
| Gradient em superfície | Viola princípio de contenção | Cor plana via token semântico |
| SVG inline como ícone | Fora do sistema de ícones — não escala nem aceita WellKnownIcons | `<Icon Kind="..." />` ou `@WellKnownIcons.{Nome}(classes)` |
| Usar `Notification` para erros de validação de campo | Notification some — erro de campo precisa persistir | `Feedback` inline com `Themes.Danger` |
| Usar `Modal` para conteúdo não-bloqueante | Bloqueia a UI desnecessariamente | `OffCanvas` para conteúdo complementar |

### Alternativas seguras

- **Não sei qual tema usar**: `Themes.Default` — cada componente define seu fallback adequado.
- **Não sei qual tamanho usar**: `Sizes.Default` — equivalente a `Medium` na maioria dos componentes.
- **Não sei se usar Toast ou Alert**: prefira `Feedback` inline se o erro está associado a um elemento; `Notification` se é resposta de operação.
- **Não sei se usar Modal ou OffCanvas**: se o usuário precisa tomar uma decisão, use `Modal`; se é conteúdo complementar opcional, use `OffCanvas`.
- **Preciso de heading hierarchy**: definir com classes Tailwind diretamente (`text-2xl font-semibold`, `text-xl font-semibold`, `text-lg font-medium`) — a biblioteca não define tokens de heading.
