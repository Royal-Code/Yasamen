# Styles Map - yasamen

## Resumo executivo

Este documento traduz a linguagem visual da Yasamen em recursos concretos de implementação: componentes, classes `ya-*`, tokens Tailwind/Yasamen, enum `Themes`, enum `Sizes`, breakpoints, spacing, z-index e receitas operacionais. Use este mapa para implementar telas que parecam nativas da biblioteca sem copiar integralmente o guia de estilos nem inventar tokens.

## Como ler este documento

1. Escolha primeiro o eixo visual: ação, feedback, formulário, navegação, layout, overlay ou conteúdo.
2. Use componentes Yasamen quando existirem; use classes `ya-*` diretamente apenas quando o componente não expor a composição necessária.
3. Escolha `Themes` por significado semântico e `Sizes` por densidade.
4. Use tokens oficiais de cor, spacing e breakpoint; quando um token estiver em lacuna, prefira utilitários Tailwind confirmados.
5. Força `forte` significa token/API/CSS de componente; `fraca` significa padrão recorrente em demos; `inconclusiva` significa zona de cuidado.

## Tabela principal de mapeamento

| Eixo visual | Regra visual | Token/Classe/Variável | Receita de uso | Força |
|---|---|---|---|---|
| Identidade | UI operacional, clara e semântica | `bg-white`, `bg-light-100`, `text-dark-*`, `Themes` | Fundo geral claro, superfícies brancas, cor só para semântica | forte |
| Ação principal | CTA preenchido e azul | `Button Style=Themes.Primary`, `ya-btn-primary` | Use para salvar, confirmar, adicionar ou executar ação principal | forte |
| Ação secundária | Baixo peso sem competir com CTA | `Themes.Secondary`, `Themes.Light`, `Outline=true` | Use Secondary para ação comum; Light ou outline para cancelar/voltar | forte |
| Ação destrutiva | Vermelho semântico | `Themes.Danger`, `ya-btn-danger`, `text-danger-*` | Use somente para remover/excluir/erro destrutivo | forte |
| Aviso | Separar warning de alert | `Themes.Warning` amarelo, `Themes.Alert` laranja | Warning para cautela; Alert para atenção operacional forte | forte |
| Iconografia | Ações compactas circulares | `IconButton`, `ya-i-btn-*`, `rounded-full` | Use em toolbar, sidebar, menu e ações de linha quando o contexto já explica | forte |
| Grupos de ação | Continuidade visual | `ButtonGroup`, `Orientation`, `Style`, `Size` | Agrupe ações relacionadas; verticalize em espaco estreito | forte |
| Badge/status | Pill leve | `Badge`, `FieldBadge`, `ya-badge-*`, `rounded-full` | Use `bg-*-100`, `text-*-800`, `border-*-200` via componente | forte |
| Feedback inline | Fundo claro com borda semântica | `Feedback`, `ya-feedback-*` | Use para mensagens persistentes em página ou formulário | forte |
| Toast | Cartao branco com faixa/ícone semântico | `Notification`, `Notify`, `ya-notification-*` | Use para eventos temporários; posicione via grupo/serviço quando necessário | forte |
| Forms | Campo branco com focus azul | `TextField`, `ya-input-field`, `ya-field-*` | Use label, information, prepend/append, error; não estilize input cru | forte |
| Erro de campo | Vermelho com ícone e mensagem | `ya-input-field-invalid`, `FieldError`, `text-danger-600` | Use `Error`/validação para ativar estado invalid | forte |
| Navegação estrutural | Sidebar branca com ativo sutil | `AppSideBar`, `AppSideItem`, `border-l-2 primary/50` | Use barra lateral em desktop e offcanvas/menu em mobile | forte |
| Breadcrumb | Texto neutro e separador discreto | `Breadcrumb`, `text-dark-400`, separador `»` | Use para caminho hierárquico; item ativo `dark-900` e semibold | forte |
| Pagination | Desktop numérico, mobile compacto | `Pagination`, `md:block`, `md:hidden` | Use componente para listas/grids; não criar paginação manual | forte |
| Layout grid | 4/8/12/16 colunas | `Container Type=Grid`, `LayoutSizes` | Use phone 4, tablet 8, laptop 12, desktop 16 | forte |
| App shell | Topbar fixa, conteúdo grid, footer | `AppLayout`, `z-app-bar`, spacing `LargerX2` | Use como shell de app/docs; mantenha superfícies brancas | forte |
| Modal | Backdrop leve e deslocamento vertical | `Modal`, `ya-modal-*`, `bg-black/20`, `z-modal` | Use para interrupção focada; evitar sombras/backdrops custom pesados | forte |
| Offcanvas | Painel lateral branco com slide | `OffCanvas`, `ya-offcanvas-*`, `z-offcanvas` | Use para menu, filtros, detalhes laterais | forte |
| Movimento | Transição curta | `transition-default`, `duration-150`, `--duration-default` | Use movimentos rapidos, funcionais e previsiveis | forte |
| Ornamentação | Baixa decoração | `border-light-*`, `rounded-md`, `shadow-lg` só em toasts/overlays | Prefira borda/radius; sombra apenas quando precisa separar camada | forte |
| Demos de página | Respiro generoso | `p-8`, `space-y-10`, `space-y-4`, `border-light-300` | Bom ponto de partida para documentação ou telas administrativas | fraca |
| Reboot tipográfico | Base HTML com lacunas | `body`, `h1..h6`, `p`, variáveis `--font-*` não confirmadas | Prefira classes/componentes confirmados se criar base nova | inconclusiva |

## Receitas operacionais

### Ação principal em formulário

- Intenção visual: uma decisão dominante, clara e clicavel.
- Implementação: `Button Label="Salvar" Style="Themes.Primary" Size="Sizes.Medium"`.
- Variações: use `Sizes.Small` em barras compactas; use `Block=true` quando a ação precisa ocupar largura total em mobile; use `Icon` apenas quando reforcar a ação.

### Ações de formulário com cancelar

- Intenção visual: destacar confirmação e rebaixar cancelamento.
- Implementação: `ButtonGroup` com `Button Style=Themes.Primary` para salvar, `Button Style=Themes.Light` ou `Outline=true` para cancelar.
- Variações: em painel estreito, `Orientation="ButtonGroupOrientation.Vertical"`.

### Toolbar compacta

- Intenção visual: varias ações curtas sem texto grande.
- Implementação: `ButtonGroup Size=Sizes.Small` contendo `IconButton` e, se uma ação precisar de clareza extra, um `Button Label`.
- Variações: use `Themes.Info` ou `Themes.Secondary`; use `Danger` apenas no item destrutivo.

### Campo de texto padrão

- Intenção visual: entrada clara, legível, com foco azul.
- Implementação: `TextField Label="Nome" Placeholder="Digite..." Size=Sizes.Medium`.
- Variações: `Information` para ajuda; `Error`/validação para invalid; `Prepend`/`Append` com `FieldText` para prefixo/sufixo; `DescriptionComplement` com `FieldBadge`.

### Campo invalidado

- Intenção visual: erro visível sem destruir o layout.
- Implementação: `TextField Error="Mensagem"` ativa `ya-input-field-invalid`, borda/texto `danger`, focus `danger` e ícone SVG no fundo.
- Variações: combine com `FieldError` e texto curto; não use `Alert` para erro de campo.

### Feedback inline

- Intenção visual: mensagem contextual dentro da página.
- Implementação: `Feedback Style=Themes.Info|Success|Warning|Danger Size=Sizes.Medium`.
- Variações: `Block=true` para largura total; `Title` para separar cabeçalho; icon opcional por tema.

### Toast/notificação

- Intenção visual: evento temporário, empilhavel e semanticamente colorido.
- Implementação: `Notify.ShowAsync(Themes.Success, text, details)` ou `Notification Theme=... Icon=true Closeable=true`.
- Variações: `NotificationContent` para texto/detalhes; `NotificationGroup Placement=TopEnd` quando controlar posição; timer usa barra semântica.

### App shell

- Intenção visual: aplicação com barra superior, menu lateral, conteúdo e footer.
- Implementação: `AppLayout` com `TopStart`, `TopCenter`, `TopEnd`, `LeftMenu`, `Main`, `Footer`; sidebars usam `AppSideBar`, menu usa `AppSideMenuButton`.
- Variações: tamanho padrão do shell vem de `SpacingSize.LargerX2`; em mobile a sidebar some e o menu deve abrir via offcanvas.

### Offcanvas de menu/filtros

- Intenção visual: camada lateral temporária.
- Implementação: `OffCanvas Position=Positions.Start|End Handler=...`; conteúdo branco; backdrop `bg-black/20`.
- Variações: use `fit-*` quando precisar respeitar topbar ou margens; evite sombra custom pesada.

### Modal focado

- Intenção visual: interrupção central ou overlay de decisão.
- Implementação: `Modal` com outlet configurado pela biblioteca; backdrop leve e transição vertical curta.
- Variações: mantenha conteúdo interno em superfície branca; usar ações com `ButtonGroup`.

### Pagination para lista

- Intenção visual: navegação de página clara em desktop e compacta em mobile.
- Implementação: `Pagination CurrentPage TotalPages OnPageChanged Size=Sizes.Medium`.
- Variações: `Loading=true` para reduzir cliques; `SinglePageMode.Message` para coleção de uma página.

### Status em linha

- Intenção visual: rótulo curto sem roubar foco do conteúdo.
- Implementação: `Badge Text="Ativo" Style=Themes.Success Size=Sizes.Small`.
- Variações: use `FieldBadge` em complemento de label de campo; use `AdditionalClasses="text-xs"` apenas para ajuste local.

### Bloco de conteúdo administrativo

- Intenção visual: área limpa para formulário, lista ou demo.
- Implementação: `Box AdditionalClasses="p-8 bg-white border-none"` com seções `space-y-4`/`space-y-10`.
- Variações: para bloco destacado use `border border-light-300 p-4`; essa receita vem de demos, portanto e força fraca.

## Design tokens disponíveis

### Breakpoints

| Token | Valor | Uso |
|---|---:|---|
| `--breakpoint-xs` | `30rem` / 480px | telas muito pequenas |
| `--breakpoint-sm` | `40rem` / 640px | phone/primeiro layout multi-coluna |
| `--breakpoint-md` | `48rem` / 768px | tablet; alternancia de pagination |
| `--breakpoint-lg` | `64rem` / 1024px | laptop |
| `--breakpoint-xl` | `80rem` / 1280px | desktop comum |
| `--breakpoint-2xl` | `96rem` / 1536px | desktop amplo; grid 16 colunas |

### Cores e temas

| Tema | Base | Escala confirmada |
|---|---|---|
| `primary` | `#0d6dfd` | 100 `#cfe2ff`, 200 `#9ec5fe`, 300 `#6ea7fe`, 400 `#3d8afd`, 500 `#0d6dfd`, 600 `#0255d3`, 700 `#01409e`, 800 `#012b6a`, 900 `#001535` |
| `secondary` | `#6c757d` | 100 `#e1e3e5`, 200 `#c4c8cc`, 300 `#a6acb2`, 400 `#889198`, 500 `#6c757d`, 600 `#565e64`, 700 `#41464b`, 800 `#2b2f32`, 900 `#161719` |
| `tertiary` | `#7c3aed` | 100 `#e5d8fb`, 200 `#cbb0f8`, 300 `#b089f4`, 400 `#9661f1`, 500 `#7c3aed`, 600 `#5c14d8`, 700 `#450fa2`, 800 `#2e0a6c`, 900 `#170536` |
| `info` | `#7db8f0` | 100 `#e5f1fc`, 200 `#cbe3f9`, 300 `#b1d4f6`, 400 `#97c6f3`, 500 `#7db8f0`, 600 `#3c94e8`, 700 `#1770c4`, 800 `#0f4b83`, 900 `#082541` |
| `highlight` | `#4169e1` | 100 `#d9e1f9`, 200 `#b3c3f3`, 300 `#8da5ed`, 400 `#6787e7`, 500 `#4169e1`, 600 `#204ac8`, 700 `#183796`, 800 `#102564`, 900 `#081232` |
| `success` | `#10b981` | 100 `#c6fae9`, 200 `#8df5d3`, 300 `#54f0bd`, 400 `#1beba6`, 500 `#10b981`, 600 `#0d9467`, 700 `#0a6f4d`, 800 `#064a34`, 900 `#03251a` |
| `warning` | `#fbbf24` | 100 `#fef2d3`, 200 `#fde5a7`, 300 `#fdd97c`, 400 `#fccc50`, 500 `#fbbf24`, 600 `#e1a404`, 700 `#a97b03`, 800 `#715202`, 900 `#382901` |
| `alert` | `#f97316` | 100 `#fee3d0`, 200 `#fdc7a2`, 300 `#fbab73`, 400 `#fa8f45`, 500 `#f97316`, 600 `#d35a05`, 700 `#9f4304`, 800 `#6a2d03`, 900 `#351601` |
| `danger` | `#dc3545` | 100 `#f8d7da`, 200 `#f1aeb5`, 300 `#ea868f`, 400 `#e35d6a`, 500 `#dc3545`, 600 `#ba202f`, 700 `#8c1823`, 800 `#5d1017`, 900 `#2f080c` |
| `light` | `#f2f1f3` | 10 `#fbfafc`, 25 `#f9f8fa`, 50 `#f6f4f8`, 100 `#f2f1f3`, 200 `#e6e4e8`, 300 `#dad7dd`, 400 `#cecad1`, 500 `#c2bdc6`, 600 `#b5b0bb`, 700 `#a9a3b0`, 800 `#9d96a5`, 900 `#91899a` |
| `dark` | `#38333c` | 100 `#a39aa9`, 200 `#887e91`, 300 `#6e6476`, 400 `#534b59`, 500 `#38333c`, 600 `#312c34`, 700 `#29252c`, 800 `#221f24`, 900 `#1a181c` |

### Semântica recomendada de cores

| Tema | Uso recomendado |
|---|---|
| `Primary` | CTA principal, foco, link/ativo primario |
| `Secondary` | Ação comum/default, suporte neutro |
| `Tertiary` | Destaque alternativo quando Primary já estiver ocupado |
| `Info` | Informação, ajuda, consulta |
| `Highlight` | Favorito, destaque selecionado, item especial |
| `Success` | Confirmação, conclusao positiva |
| `Warning` | Risco/cautela |
| `Alert` | Atenção laranja, alerta operacional |
| `Danger` | Erro, invalidacao, exclusao |
| `Light` | Cancelar, superfície secundária, baixo peso |
| `Dark` | Ação ou texto de alto contraste |

### Tipografia

| Token/Classe | Valor ou uso |
|---|---|
| `--font-sans` | `system-ui`, Apple/BlinkMac, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif |
| `--font-serif` | Georgia/Times |
| `--font-mono` | SFMono-Regular, Consolas, Liberation Mono, Menlo, monospace |
| `--text-4xs` | `0.5rem`, line-height `0.75/0.5` |
| `--text-3xs` | `0.5625rem`, line-height `0.8125/0.5625` |
| `--text-2xs` | `0.625rem`, line-height `0.875/0.625` |
| Tailwind text scale | `text-xs` a `text-9xl` disponíveis no bundle |
| Font weights | usar classes confirmadas `font-normal`, `font-medium`, `font-semibold`, `font-bold` |
| Leading | tokens `--leading-none`, `--leading-xs`, `--leading-sm`, `--leading-base`, `--leading-lg`, `--leading-xl` |

### Espacamento

| Token | Valor |
|---|---:|
| `--spacing-0` | `0` |
| `--spacing-0.5` | `.03125rem` |
| `--spacing-1` | `.0625rem` |
| `--spacing-1.5` | `.09375rem` |
| `--spacing-2` | `.125rem` |
| `--spacing-2.5` | `.1875rem` |
| `--spacing-3` | `.25rem` |
| `--spacing-3.5` | `.375rem` |
| `--spacing-4` | `.5rem` |
| `--spacing-4.5` | `.625rem` |
| `--spacing-5` | `.75rem` |
| `--spacing-5.5` | `.875rem` |
| `--spacing-6` | `1rem` |
| `--spacing-6.5` | `1.25rem` |
| `--spacing-7` | `1.5rem` |
| `--spacing-7.5` | `1.75rem` |
| `--spacing-8` | `2rem` |
| `--spacing-8.5` | `2.5rem` |
| `--spacing-9` | `3rem` |
| `--spacing-9.5` | `3.5rem` |
| `--spacing-10` | `4rem` |
| `--spacing-10.5` | `4.5rem` |
| `--spacing-11` | `5rem` |
| `--spacing-11.5` | `5.5rem` |
| `--spacing-12` | `6rem` |
| `--spacing-12.5` | `7rem` |
| `--spacing-13` | `8rem` |
| `--spacing-13.5` | `10rem` |
| `--spacing-14` | `12rem` |
| `--spacing-14.5` | `14rem` |
| `--spacing-15` | `16rem` |
| `--spacing-15.5` | `24rem` |
| `--spacing-16` | `32rem` |

### Sizes de componentes

| Enum | Classe tipica | Uso visual |
|---|---|---|
| `Sizes.Smallest` | `2xs` | controles muito densos |
| `Sizes.Smaller` | `xs` | controles compactos |
| `Sizes.Small` | `sm` | toolbar, listas, área estreita |
| `Sizes.Medium` | `md` | default de formulário e botão |
| `Sizes.Large` | `lg` | controles mais destacados |
| `Sizes.Larger` | `xl` | destaque local, pouca densidade |
| `Sizes.Largest` | `2xl` | casos raros de leitura ampliada |

### Superfície, borda, radius e sombra

| Recurso | Classes/tokens | Uso |
|---|---|---|
| Superfície de app | `bg-light-100`, `bg-white` | body e áreas de trabalho |
| Borda padrão | `border`, `border-1`, `border-light-300`, `border-light-400` | separacao discreta |
| Borda semântica | `border-*-200`, `border-*-400`, `border-*-500/50` | feedback, badges, inputs invalidos |
| Radius de controles | `rounded-sm`, `rounded-md`, `rounded-lg` | tamanho pequeno/médio/grande |
| Pills/circular | `rounded-full` | badges e icon buttons |
| Sombra de overlay | `shadow-lg`, sombras laterais `#00000020` | notifications/offcanvas |
| Backdrop | `bg-black/20` | modal/offcanvas |

### Motion e z-index

| Token/classe | Valor ou camada | Uso |
|---|---|---|
| `--duration-default` | `.15s` | transição default |
| `--duration-fastest` | `.1s` | microinteracao |
| `--duration-faster` | `.15s` | estado rápido |
| `--duration-fast` | `.2s` | interação comum |
| `--duration-normal` | `.3s` | movimento perceptivel |
| `--duration-slow` | `.4s` | movimento mais longo |
| `transition-default` | `all var(--duration-default) linear` | transição geral |
| `z-app-bar` | `1010` | topbar |
| `z-offcanvas-backdrop` | `1020` | backdrop offcanvas |
| `z-offcanvas` | `1030` | offcanvas |
| `z-offcanvas-overlay-backdrop` | `1040` | backdrop overlaying |
| `z-offcanvas-overlay` | `1050` | offcanvas overlaying |
| `z-backdrop` | `1060` | backdrop modal |
| `z-modal` | `1070` | modal |
| `z-notification` | `1090` | notifications |

## Lacunas e zonas de cuidado

| Regra visual | Por que não tem correspondencia segura | Alternativa | Risco |
|---|---|---|---|
| Tipografia HTML global completa | Reboot referência variáveis `--font-base`, `--font-normal`, `--font-medium`, `--font-bold`, `--font-light`, `--font-extra-bold`, `--radius-2`, `--size-3`, `--leading-1` sem definições observadas | Usar classes confirmadas (`text-base`, `font-medium`, `leading-base`, `rounded-sm/md`) e componentes | Elementos HTML crus podem renderizar diferente do esperado |
| Busca de menu | `AppMenu` contém placeholder textual | Implementar busca real com campo/controlador antes de mapear pattern de search | Tela com menu pode aparentar incompleta |
| Data display rico | Não há data grid/table/chart dedicado | Usar layout, pagination, feedback e blueprints futuros | Patterns de dados terao baixa cobertura |
| Cards complexos | `Box` existe, mas estilo de card é principalmente demos/fraca | Usar `Box` com `bg-white`, borda clara e padding ou criar blueprint | Risco de cards inconsistentes |
| Modo dark global | Existe tema `Dark` como cor, não modo dark | Não gerar dark mode automático | Contraste e superfícies podem ficar incoerentes |
| Hero/marketing | Biblioteca não demonstra linguagem editorial | Criar hero apenas com classes Tailwind e tokens, com cautela | Resultado pode fugir da identidade operacional |

## Critérios de uso por IA

1. Para telas de app, combine `AppLayout`, `Box`, `Container`, `Slot`, `Button`, `TextField`, `Feedback`, `Pagination`, `Modal`, `OffCanvas` e `Notify` antes de criar estruturas novas.
2. Para classes visuais manuais, prefira `bg-white`, `bg-light-100`, `border-light-300/400`, `text-dark-*`, `rounded-md`, `p-4/p-6/p-8`, `space-y-*`, `gap-*`.
3. Para semântica, use `Themes`; para densidade, use `Sizes`; para responsividade estrutural, use `LayoutSizes`.
4. Quando precisar desenhar pattern não coberto, preserve a gramatica: superfície branca, borda leve, cor semântica, movimento curto, sombras discretas.
5. Não inventar token de marca, gradiente, dark mode, data grid ou search component sem blueprint.
6. Em conflito entre demo e CSS de componente, o CSS de componente vence. Em conflito entre CSS e token oficial, o token oficial vence.
