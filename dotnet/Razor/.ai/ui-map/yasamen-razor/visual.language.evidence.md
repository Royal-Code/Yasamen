# Visual Language Evidence — yasamen-razor

Artefato de auditoria interna. Não é para consumo externo.

---

## Fontes analisadas

| Fonte | Tipo | Eixos cobertos | Confiabilidade |
|---|---|---|---|
| `yasamen.css` (@theme) | token | cor, tipografia, spacing, breakpoints, line-height | alta |
| `variables.css` | token | animação (durations), fit vars | alta |
| `utilities.css` | token | z-index, transition-default | alta |
| `btn.css` | código | ações, estados, bordas, tamanhos | alta |
| `badge.css` | código | cor semântica (suave), tamanhos, forma | alta |
| `feedback.css` | código | cor semântica, estados, tipografia interna | alta |
| `notification.css` | código | cor, superfície, elevação, motion, grupos | alta |
| `modal.css` | código | overlay, z-index, motion, fases | alta |
| `offcanvas.css` | código | overlay lateral, z-index, motion, sombra | alta |
| `pagination.css` | código | navegação, estados, responsividade | alta |
| `applayout.css` | código | zonas de shell, posição header, grid | alta |
| `fieldgroup.css` | código | formulário, label, validação, tamanhos | alta |
| componentes `.razor/.razor.cs` | código | API, params, semântica de uso | alta |
| `.ai/guides/` (expand, css-visual-contract) | docs | intenção de uso, regras de design | média |
| `RoyalCode.Razor.Docs` (demo pages) | demo | exemplos aplicados | média |

---

## Evidências por eixo visual

### Identidade

| Leitura | Observação | Fonte | Força | Decisão no contrato |
|---|---|---|---|---|
| primitiva | Paleta semântica própria, sem herança de Bootstrap/Material/Tailwind UI | `yasamen.css` | forte | regra: identidade flat e semântica |
| primitiva | `primary` = `#0d6dfd` (azul moderno), `secondary` = `#6c757d` (cinza), `danger` = `#DC3545` (vermelho saturado) | `yasamen.css` | forte | regra: paleta semântica, não decorativa |
| primitiva | Ripple nos botões (herança Material Design) | `btn.css`, `Ripple.razor` | forte | regra: feedback tátil via ripple |
| primitiva | Transição padrão 150ms linear (`transition-default`) | `variables.css`, `utilities.css` | forte | regra: motion rápido e sutil |
| aplicada | Shell com topbar fixo + sidebar estreita de ícones + conteúdo principal | `AppLayout`, demo pages | fraca | recomendação: shell app-centric com nav lateral |
| aplicada | Sem ornamentação desnecessária: sem gradientes, sem sombras pesadas, sem decorações | múltiplos CSS | fraca | recomendação: estética flat e contida |

### Hierarquia

| Leitura | Observação | Fonte | Força | Decisão no contrato |
|---|---|---|---|---|
| primitiva | Botão filled (400) = ação principal; outline = secundária; light = terciária | `btn.css` | forte | regra: hierarquia por saturação |
| primitiva | Success/Warning/Danger têm texto `text-dark-900` (não white) por questão de contraste | `btn.css` | forte | regra: contraste automático por tema |
| aplicada | `Themes.Primary` para ação principal, `Themes.Secondary` para ação neutra, `Themes.Danger` para destrutiva | componentes, docs | fraca | recomendação: semântica de ação por tema |
| aplicada | Badge usa tom suave (bg-100, text-800) para não competir com ações | `badge.css` | forte | regra: indicadores de status em tons suaves |
| primitiva | Feedback title tem `font-semibold` + `border-b` + `pb-4` — hierarquia interna clara | `feedback.css` | forte | regra: título de feedback como landmark semibold |

### Spacing

| Leitura | Observação | Fonte | Força | Decisão no contrato |
|---|---|---|---|---|
| primitiva | Escala customizada: spacing-3=0.25rem, spacing-4=0.5rem, spacing-5=0.75rem, spacing-6=1rem, spacing-7=1.5rem... | `yasamen.css` | forte | regra: escala de espaçamento própria |
| primitiva | Botões: 2xs=px-3/py-1; xs=px-4/py-2; sm=px-4/py-2; md=px-5/py-3; lg=px-6/py-4; xl=px-6/py-4; 2xl=px-7/py-4 | `btn.css` | forte | regra: padding proporcional por tamanho |
| primitiva | FieldGroup label: `mb-3` base (descendo até `mb-2.5` no 2xs) | `fieldgroup.css` | forte | regra: spacing entre label e input ~0.75rem |
| aplicada | Formulários usam FieldGroup com label-above-input (não inline) | componentes, docs | fraca | recomendação: layout label-above por padrão |
| primitiva | Notification: conteúdo `p-3` (0.75rem) | `notification.css` | forte | regra: toasts compactos |

### Zonas

| Leitura | Observação | Fonte | Força | Decisão no contrato |
|---|---|---|---|---|
| primitiva | Header fixo: `fixed top-0 right-0 left-0 z-app-bar (1010)` | `applayout.css` | forte | regra: header acima de tudo exceto overlays |
| primitiva | AppLayout: `grid w-full min-h-screen` — ocupa viewport completa | `applayout.css` | forte | regra: shell ocupa 100% do viewport |
| aplicada | Sidebar esquerda com AppSideMenuButton → AppMenu via OffCanvas | `AppLayout`, demo | fraca | recomendação: nav principal no OffCanvas |
| primitiva | z-index stack: app-bar(1010) < offcanvas(1030) < modal(1070) < notification(1090) | `utilities.css` | forte | regra: camadas bem definidas |
| primitiva | Footer: `self-end` + `bg-white` — footer ao final do conteúdo | `applayout.css` | forte | regra: footer com bg branco, grudado ao fim |

### Ações

| Leitura | Observação | Fonte | Força | Decisão no contrato |
|---|---|---|---|---|
| primitiva | Filled = primária, Outline = secundária/alternativa | `btn.css` | forte | regra: hierarquia visual de ações |
| primitiva | Disabled: `opacity-50 + cursor-not-allowed` | `btn.css`, componentes | forte | regra: desabilitado por opacidade |
| primitiva | Close button: posição absoluta `top-4 right-4`, circular, hover dark | `btn.css` | forte | regra: fechar sempre canto superior direito |
| aplicada | Ações destrutivas: `Themes.Danger` — vermelho saturado | componentes, docs | fraca | recomendação: danger para destrutiva |
| primitiva | Ripple dark para outline e light buttons | `Button.razor` | forte | regra: ripple adapta ao contraste |
| aplicada | DropButton/DropIconButton para menus contextuais | docs | fraca | recomendação: dropdown para ações secundárias contextuais |

### Tipografia

| Leitura | Observação | Fonte | Força | Decisão no contrato |
|---|---|---|---|---|
| primitiva | Sans-serif system-ui como fonte base (sem custom font) | `yasamen.css` | forte | regra: sistema tipográfico nativo |
| primitiva | Escala adicional abaixo de xs: 4xs(0.5), 3xs(0.5625), 2xs(0.625rem) | `yasamen.css` | forte | regra: escala micro para badges/labels compactos |
| primitiva | Tailwind text scale usada diretamente: xs, sm, base, lg, xl, 2xl | múltiplos CSS | forte | regra: escala Tailwind padrão para conteúdo |
| primitiva | Line-heights custom: leading-none(1), xs(1.125), sm(1.25), base(1.5), lg(1.75), xl(2) | `yasamen.css` | forte | regra: line-height semântico |
| primitiva | Feedback title: `font-semibold` | `feedback.css` | forte | regra: semibold para ênfase em títulos de componente |
| primitiva | Field label: não há font-weight explícito em fieldgroup.css (herda do body) | `fieldgroup.css` | fraca | lacuna: peso de label de formulário não definido |
| primitiva | Notification content-details: `text-2xs text-dark-700` — subtexto de detalhes | `notification.css` | forte | regra: detalhe em micro + cinza escuro |

### Cor e superfície

| Leitura | Observação | Fonte | Força | Decisão no contrato |
|---|---|---|---|---|
| primitiva | Superfície base: `bg-white` (modal, offcanvas, notification, footer) | múltiplos CSS | forte | regra: superfícies em branco puro |
| primitiva | Superfície neutra clara: `light-50`/`light-100` para estados de hover e vazios | `pagination.css`, `btn.css` | forte | regra: hover e estados neutros em light-50/100 |
| primitiva | `dark-*` family: texto principal em dark-600/700/900 | `fieldgroup.css`, `pagination.css` | forte | regra: texto base em dark-600/700 |
| primitiva | Badge/Feedback: bg-100, text-800, border-200 — tons pastel para indicadores | `badge.css`, `feedback.css` | forte | regra: indicadores de status em pastel (não vibrante) |
| primitiva | Botões preenchidos: bg-400 (tom médio, não 500 ou 600) | `btn.css` | forte | regra: ações em shade-400 (mediano) |
| primitiva | Notification borda: shade-400 (mesma escala de botão) | `notification.css` | forte | regra: borda de notificação sinaliza com shade-400 |
| primitiva | Ícone de notificação: bg-400 text-white — coluna colorida sólida | `notification.css` | forte | regra: ícone em bloco colorido lateral |
| primitiva | OffCanvas: `bg-white` + sombra lateral `3px 0 3px 0 #00000020` | `offcanvas.css` | forte | regra: offcanvas branco com sombra sutil |
| primitiva | Sem dark mode definido nos tokens | `yasamen.css` | forte | lacuna: sem suporte a dark mode |

### Contenção

| Leitura | Observação | Fonte | Força | Decisão no contrato |
|---|---|---|---|---|
| primitiva | Sem gradientes em nenhum componente | todos os CSS | forte | regra: sem gradientes |
| primitiva | Sombras apenas em notificações (shadow-lg) e offcanvas (sombra lateral leve) | múltiplos CSS | forte | regra: elevação mínima e funcional |
| primitiva | Ícones via sistema extensível (WellKnownIcons + pacote de ícones externo) | componentes | forte | regra: ícones externos, sem embutidos fixos |
| primitiva | Ripple como único elemento de ornamentação interativa | `Ripple.razor`, `btn.css` | forte | regra: contenção com ripple como único "efeito" |
| primitiva | Arredondamento: sm para compactos, md para médios, lg para grandes, full para badges | múltiplos CSS | forte | regra: radius proporcional ao tamanho |

### Estados

| Leitura | Observação | Fonte | Força | Decisão no contrato |
|---|---|---|---|---|
| primitiva | Hover: `hover:not-disabled:bg-{tema}-600` — mais escuro que o estado normal | `btn.css` | forte | regra: hover escurece 2 shades |
| primitiva | Active: `active:not-disabled:bg-{tema}-700` — ainda mais escuro | `btn.css` | forte | regra: pressed escurece 3 shades |
| primitiva | Focus: `focus-within:ring-{N} focus-within:ring-{tema}-300/50` — ring semitransparente | `btn.css`, `pagination.css` | forte | regra: focus com ring semitransparente |
| primitiva | Disabled: `opacity-50 cursor-not-allowed` | `btn.css`, componentes | forte | regra: disabled por opacidade |
| primitiva | Loading (pagination): `opacity-80` | `pagination.css` | forte | regra: loading por redução de opacidade |
| primitiva | Modal fases: opening-start(translate-50/opacity-0) → opening(0/100%) → open → closing → closed | `modal.css` | forte | regra: modal com slide-down + fade |
| primitiva | Notification estados: opening/open/closing/closed com translate + opacity | `notification.css` | forte | regra: notificação com slide + fade direcional |

### Responsividade

| Leitura | Observação | Fonte | Força | Decisão no contrato |
|---|---|---|---|---|
| primitiva | Breakpoints: xs(480px), sm(640px), md(768px), lg(1024px), xl(1280px), 2xl(1536px) | `yasamen.css` | forte | regra: breakpoints definidos |
| primitiva | Pagination: desktop oculto em mobile (md:block), mobile oculto em desktop (md:hidden) | `pagination.css` | forte | regra: pagination tem variante mobile automática |
| primitiva | AppContent: `max-sm:mx-0` — sem margem lateral em mobile | `applayout.css` | forte | regra: layout sem margem lateral em mobile |
| aplicada | Container + Slot com Span/TabletSpan/LaptopSpan/DesktopSpan | componentes | fraca | recomendação: grid responsivo via Container+Slot |

---

## Contradições

| Tema | Fontes em conflito | Impacto | Decisão |
|---|---|---|---|
| Escala de tamanho de botão | `btn.css` tem `ya-btn-2xs` e `ya-btn-xs` mas enum `Sizes` começa em `Smallest` | Mapeamento pode variar | Sem impacto no contrato externo — CSS confirma ambas existem |
| `primary` default shade | Components usam shade-400 nos botões (bg-400), mas `--color-primary: #0d6dfd` é o shade-500 | Levemente inconsistente | Token principal é o 500, botões usam 400 — regra: ações em 400, identidade em 500 |

---

## Lacunas

| Eixo | O que falta | Evidência encontrada | Impacto | Tratamento |
|---|---|---|---|---|
| Tipografia | Sem hierarquia de heading (h1/h2/h3 com tokens definidos) | Apenas escala de tamanho Tailwind | App consumidor define headings livremente | Documentar como limite |
| Dados | Sem componente de tabela/data grid | Nenhum | Listagens precisam de HTML nativo ou lib externa | Lacuna de cobertura |
| Formulário | Sem select, checkbox, radio, datepicker | Apenas FieldText + FieldAction + FieldBadge | Inputs especializados precisam de HTML nativo | Lacuna de cobertura |
| Feedback | Sem progress bar standalone, sem spinner standalone | Apenas RotationMotion via IconAnimation | Indicadores de carregamento limitados | Lacuna — usar RotationMotion manualmente |
| Tabs | Sem componente de tabs/navigation tabs | Nenhum | Navegação entre abas precisa de implementação customizada | Lacuna de cobertura |
| Dark mode | Sem variantes dark nos tokens | Tokens apenas light | App que precisa de dark mode deve implementar por conta | Limite da biblioteca |
| Tooltip | Sem componente de tooltip | Nenhum | Dicas contextuais precisam de implementação externa | Lacuna de cobertura |
| Card | Sem componente de card específico | Apenas Box genérico | Cards precisam de Box + estilização manual | Box como alternativa |

---

## Fontes descartadas ou inacessíveis

| Fonte | Motivo | Impacto |
|---|---|---|
| `RoyalCode.Razor.Drops/*.razor.css` (legado) | CSS isolation legado, não parte do contrato público | Baixo — apenas detalhes internos do drop |
| Screenshots/previews | Não disponíveis | Baixo — CSS é suficiente |

---

## Veredito de qualidade

- Cobertura visual: **suficiente** — tokens, CSS de componentes e documentação cobrem todos os eixos principais;
- Riscos para consumo externo: tipografia de heading não definida (app define livremente), ausência de tabela/inputs avançados pode surpreender;
- Eixos com evidência forte: cor/paleta, spacing, bordas/radius, motion, estados, z-index, ações, superfícies, responsividade básica;
- Eixos com evidência fraca ou inconclusiva: peso de label de formulário, hierarquia tipográfica de conteúdo;
- Pontos que exigem decisão humana: nenhum bloqueante — lacunas registradas como limites da biblioteca.
