# Visual Language - yasamen

## Resumo executivo

Yasamen tem linguagem visual operacional, semântica e contida: a interface parte de superfícies claras, texto escuro arroxeado, bordas finas, radios pequenos/medios, sombras discretas e uma paleta temática ampla aplicada por intenção funcional (`Primary`, `Secondary`, `Success`, `Warning`, `Alert`, `Danger`, `Info`, `Highlight`, `Light`, `Dark`, `Tertiary`). A força principal da biblioteca está em controles, feedback, formulários, navegação, app shell e overlays, com variações sistemáticas de tamanho e tema. A identidade não e editorial nem ornamental; ela favorece telas de aplicação, fluxos administrativos, formulários, menus e estados de feedback. As limitações mais relevantes são a ausência de princípios visuais declarados, ausência de componentes ricos de dados e algumas lacunas de CSS base herdado.

## Identidade visual dominante

Yasamen deve ser usada como uma biblioteca de UI para aplicações Blazor com aparência limpa, funcional e levemente inspirada em Bootstrap, mas implementada com Tailwind e tokens próprios. O tom dominante e neutro-profissional: branco e tons `light` estruturam superfícies, `dark` estrutura texto, e a cor entra como marcador semântico de ação ou estado, não como decoração de fundo.

Evidências: [forte] tokens oficiais definem famílias semânticas completas de cores, breakpoints, fontes system UI, spacing e leading; [forte] componentes de botão, badge, feedback, notification, field e pagination aplicam essas famílias por classe `ya-*`; [fraca] demos usam containers brancos com padding amplo e bordas leves para apresentar fluxos de formulário, navegação e ações.

## Princípios visuais observados

1. [forte] Cor deve carregar semântica, não estilo arbitrário. A paleta é exposta como temas nomeados e cada componente mapeia o tema para classes `ya-btn-*`, `ya-badge-*`, `ya-feedback-*`, `ya-notification-*`, `ya-field-*` e similares.
2. [forte] O estado principal deve ser mais preenchido que o secundário. Botões filled usam fundo `*-400`, texto contrastante e hover/active mais escuros; outline usa fundo branco, borda/label coloridos e hover suave em `*-100`.
3. [forte] A densidade deve escalar por enum de tamanho. A escala `Sizes` mapeia `Smallest`, `Smaller`, `Small`, `Medium`, `Large`, `Larger`, `Largest` para classes de texto, padding, ring e radius dos componentes.
4. [forte] Feedback deve combinar fundo claro, borda semântica e texto escuro da mesma família. Badges e feedbacks usam tons `100` para fundo, `200/500` para borda e `800` para texto.
5. [forte] Overlays devem usar movimento curto, backdrop preto translúcido e z-index escalonado. Modal e offcanvas usam `duration-150`, `transition-default`, `bg-black/20` e utilitários `z-*`.
6. [fraca] Telas de demo preferem blocos brancos com `p-8`, `space-y-*`, `border-light-300` e largura contida; isto é recorrente nos exemplos, mas não é declarado como regra oficial de design.
7. [inconclusiva] Existe intenção de sistema tipográfico base, mas algumas variáveis do reboot (`--font-base`, `--font-normal`, `--radius-2`, etc.) não aparecem definidas nos tokens observados.

## Regras de hierarquia perceptiva

1. [forte] Use `Primary` para a ação principal de uma área e `Secondary` como fallback operacional. Evidência: `Themes.Default` normalmente mapeia para `Secondary` nos botões; `Primary` tem fundo azul preenchido e aparece nas demos para "Salvar", "Adicionar notificação" e disparos principais.
2. [forte] Use preenchimento para a ação dominante e outline para ação alternativa. Evidência: o CSS separa variantes filled e outline; filled usa fundo colorido e outline usa `bg-white`, borda e texto coloridos.
3. [forte] Use tamanho para prioridade local, não para expressao editorial. Evidência: `Sizes` controla padding, fonte, ring e dimensoes de controles; não há escala hero ou display própria além de headings base e tamanhos Tailwind.
4. [forte] Use `Danger`, `Warning`, `Alert`, `Success`, `Info` e `Highlight` para estados com significado. Evidência: esses temas existem como enum, tokens, classes de botão, badge, feedback e notification.
5. [fraca] Em seções de conteúdo, hierarquia de título e paragrafo vem do HTML (`h1`, `h2`, `h3`, `p`) e de spacing utilitário como `space-y-*`, `mb-*`, `p-*`. Evidência: demos oficiais usam esse padrão em páginas de ButtonGroup, Pagination e TextField.

## Regras de spacing, ritmo e respiro

1. [forte] Use a escala própria de spacing como base numérica: `0`, `.5`, `1`, `1.5`, `2`, `2.5`, `3`, `3.5`, `4`, `4.5`, `5`, `5.5`, `6`, `6.5`, `7`, `7.5`, `8`, `8.5`, `9`, `9.5`, `10`, `10.5`, `11`, `11.5`, `12`, `12.5`, `13`, `13.5`, `14`, `14.5`, `15`, `15.5`, `16`. Evidência: tokens `--spacing-*` oficiais.
2. [forte] O ritmo de controles pequenos e médio deve vir dos componentes, não de padding manual. Evidência: `Button`, `IconButton`, `InputField`, `Pagination`, `Feedback`, `Badge` e `Field*` já derivam padding e fonte de `Sizes`.
3. [forte] Grids usam 4 colunas em phone, 8 em tablet, 12 em laptop e 16 em desktop amplo. Evidência: `LayoutSizes` define `grid-cols-4`, `md:grid-cols-8`, `lg:grid-cols-12`, `2xl:grid-cols-16`.
4. [fraca] Em páginas de documentação, seções usam respiro generoso (`p-8`, `space-y-10`, `space-y-4`, `gap-6`) e cards/blocos de exemplo usam borda `light-300` com padding `p-4`. Evidência: demos de ButtonGroup, Pagination e TextField.
5. [forte] Componentes responsivos devem reduzir informação antes de comprimir demais. Evidência: pagination tem versao desktop numérica `md:block` e versao mobile compacta `md:hidden`.

## Regras de peso e proporção entre zonas

1. [forte] App shell usa topo fixo, sidebars fixas em telas não pequenas, conteúdo principal flex/grid e footer simples. Evidência: app layout usa `fixed top-0 right-0 left-0 z-app-bar`, sidebars `sm:fixed` e ocultas em `max-sm`, conteúdo `grid w-full`.
2. [forte] Zonas estruturais devem ser brancas e pouco ornamentadas. Evidência: topbar, sidebar, app menu, offcanvas e footer usam `bg-white`; o body usa `light-100`.
3. [forte] Destaque de navegação lateral deve ser uma barra/borda lateral sutil, não um bloco pesado. Evidência: item ativo da sidebar usa `border-l-2 border-primary-500/50` e `bg-primary-500/10`.
4. [forte] Overlays devem ficar acima da aplicação com z-index explicito: app bar 1010, offcanvas 1030, backdrop/modal 1060/1070 e notification 1090. Evidência: utilitários `z-app-bar`, `z-offcanvas`, `z-backdrop`, `z-modal`, `z-notification`.
5. [fraca] Conteúdo de demo e exemplos fica em caixas de largura total com áreas internas brancas, não em hero visual. Evidência: demos usam `Box AdditionalClasses="p-8 bg-white border-none"`.

## Regras para ação principal e ações secundarias

1. [forte] CTA principal: usar `Button` filled com `Themes.Primary`, tamanho `Medium` ou `Small` conforme densidade do contexto. Receita visual: fundo azul `primary-400`, texto branco, hover `primary-600`, active `primary-700`, ring `primary-300/50`.
2. [forte] Ação secundária: usar `Button` filled `Secondary`, `Light` para cancelar/voltar, ou `Outline` quando a ação deve competir menos com a principal. O default visual de botão cai para `Secondary`.
3. [forte] Ação destrutiva: usar `Danger` e evitar `Alert` como destrutivo final; `Alert` e laranja e deve funcionar como aviso/atenção. Evidência: `Danger` tem vermelho `#DC3545`; `Alert` tem laranja `#f97316`.
4. [forte] Icon-only action: usar `IconButton`, que e circular, transparente por default e mostra peso visual no hover/active. Ele e ideal para toolbar, sidebar e ações compactas.
5. [forte] Ações relacionadas devem ser agrupadas com `ButtonGroup` para continuidade visual; filhos podem herdar tema, tamanho e disabled. Evidência: docs de demo descrevem continuidade visual e defaults herdados.
6. [fraca] Em áreas estreitas, trocar grupo horizontal para vertical antes de forcar quebra visual. Evidência: demo de ButtonGroup declara orientação vertical quando o espaco horizontal e insuficiente.

## Regras de tipografia, cor e superfície

1. [forte] Fonte principal: usar system UI (`system-ui`, Apple/BlinkMac, Segoe UI, Roboto, Helvetica Neue, Arial). Evidência: token `--font-sans`.
2. [forte] Texto base deve ser escuro (`dark`) sobre superfície clara (`light-100` ou branco). Evidência: body usa cor `dark` e fundo `light-100`; componentes usam `text-dark-*` em superfícies claras.
3. [forte] Tons semânticos tem escala de 100 a 900, com 400/500 como ponto de cor de interface e 100/200 como fundo/borda leve. Evidência: tokens e CSS de botões/feedback/badges.
4. [forte] Superfícies primarias de trabalho são brancas com borda clara; feedback usa superfície colorida clara. Evidência: inputs, notifications, pagination e app menu usam `bg-white`; badges/feedbacks usam `bg-*-100`.
5. [forte] Bordas devem ser finas (`border`, `border-1`) e geralmente `light-*` ou cor semântica translúcida. Evidência: inputs `border-light-400`, feedback `border-*-500/50`, badges `border-*-200`.
6. [forte] Radius usual: `rounded-sm`, `rounded-md`, `rounded-lg` e `rounded-full` para pills/icon buttons. Evidência: botões variam radius por tamanho, badges e icon buttons usam `rounded-full`, inputs usam `rounded-md`.
7. [inconclusiva] O reboot tenta definir tipografia HTML global, mas usa algumas variáveis não encontradas; portanto, para telas geradas por IA, prefira classes/componentes Yasamen e tokens Tailwind em vez de depender de todos os defaults de elementos HTML crus.

## Regras de contenção ou ornamentação

1. [forte] Ornamentação deve ser baixa: borda, cor semântica, radius e sombra leve bastam. Evidência: topbar usa sombra inset muito sutil; offcanvas tem sombra lateral `#00000020`; notifications em grupo usam `shadow-lg`.
2. [forte] Backdrops devem ser translucidos e não dramaticos: modal/offcanvas usam `bg-black/20`.
3. [forte] Movimento deve ser curto e funcional: `duration-150`, `transition-default`, fade/translate em modal, slide em offcanvas, pequena translacao ou scale em notifications.
4. [forte] Badges e field badges devem ser pills leves, com fundo 100 e texto 800. Não devem virar botões nem chamar mais atenção que CTAs.
5. [fraca] Demos usam `rounded-xl` em containers de exemplo, mas os componentes centrais usam radius menor; para telas finais, trate `rounded-xl` como recurso de container demonstrativo, não assinatura dominante.

## Regras responsivas

1. [forte] Breakpoints oficiais: `xs` 30rem/480px, `sm` 40rem/640px, `md` 48rem/768px, `lg` 64rem/1024px, `xl` 80rem/1280px, `2xl` 96rem/1536px.
2. [forte] Layout grid deve crescer por capacidade: 1 coluna em xs, 4 em sm/phone, 8 em md/tablet, 12 em lg/laptop, 16 em 2xl/desktop.
3. [forte] Sidebar de app desaparece em telas pequenas (`max-sm:hidden`), enquanto offcanvas e menu lateral devem assumir navegação.
4. [forte] Pagination troca janela numérica por resumo compacto em mobile (`md:hidden` para mobile, `md:block` para desktop).
5. [fraca] Demos recomendam orientação vertical para `ButtonGroup` quando o espaco horizontal não comporta as ações.
6. [inconclusiva] Nem todos os componentes tem regra responsiva própria além do que herdam de Tailwind e containers.

## Limites e restrições da biblioteca

1. Não há evidência de componente de tabela, data grid, chart, kanban, calendário ou visualização rica de dados.
2. Não há design principles oficiais encontrados; personalidade visual foi inferida de tokens, componentes e exemplos.
3. `AppMenu` contém área de busca ainda como placeholder textual; não tratar busca como componente pronto.
4. Alguns tokens referenciados no reboot parecem não definidos (`--font-base`, `--font-normal`, `--font-medium`, `--font-bold`, `--font-light`, `--font-extra-bold`, `--radius-2`, `--size-3`, `--leading-1`). Evite depender desses nomes em novos componentes até validação.
5. O sistema tem temas claros/escuros como cores (`Light`, `Dark`), mas não há evidência de modo dark global.
6. `NotificationGroup` e `NotificationAnimation` aparecem em demo, mas são suporte interno/avançado; prefira `Notify` e `Notification` para consumo comum.

## Anti-padrões

1. Não criar telas com paletas arbitrarias fora de `Themes`; alternativa: escolher o tema semântico correto e variar intensidade (`100` a `900`) quando a classe existir.
2. Não usar cor forte em todo o painel; alternativa: branco/light para superfícies e cor forte apenas em CTA, estado ativo, borda ou faixa.
3. Não usar sombras pesadas como estrutura principal; alternativa: borda clara, radius pequeno/médio e sombras discretas apenas em overlays/toasts.
4. Não transformar `IconButton` em CTA principal isolado sem rótulo visível quando a ação precisa ser entendida; alternativa: `Button` com label e ícone.
5. Não misturar muitos temas no mesmo grupo de ações; alternativa: um CTA `Primary`, secundarios `Secondary`/`Light`, e `Danger` apenas para destruicao.
6. Não forcar `ButtonGroup` horizontal em container estreito; alternativa: orientação vertical ou menos ações visiveis.
7. Não tratar `AppMenu` como busca pronta; alternativa: implementar um campo de busca real com `TextField`/input antes de depender do placeholder.
8. Não depender de variáveis CSS não confirmadas do reboot para tipografia nova; alternativa: usar tokens Tailwind/Yasamen confirmados como `text-base`, `font-medium`, `leading-base`, `font-sans`.

## Critérios de uso por IA

1. Comece pelo componente Yasamen mais semântico antes de recorrer a HTML cru: `Button`, `IconButton`, `ButtonGroup`, `TextField`, `Feedback`, `Badge`, `Notification`, `Pagination`, `AppLayout`, `OffCanvas`, `Modal`.
2. Escolha tema por significado: `Primary` para ação principal, `Secondary` para ação comum, `Light` para cancelar/baixo peso, `Danger` para destrutivo, `Warning`/`Alert` para atenção, `Success` para confirmação, `Info` para informação, `Highlight` para destaque/favorito.
3. Defina densidade por `Sizes`, não por padding manual, quando o componente expuser tamanho.
4. Use superfícies claras e contidas: branco para áreas de trabalho, `light-100` para fundo geral, borda `light-300/400` para separacao.
5. Em conflitos, prioridade de decisão: token oficial > CSS de componente > API/comentario de componente > demo recorrente > hipótese visual.
6. Marque como lacuna qualquer regra que dependa de componente ausente ou token não confirmado.
7. Para telas responsivas, use grid 4/8/12/16, esconda navegação lateral em telas pequenas e prefira resumo/ação compacta antes de comprimir texto.

## Evidências principais

| ID | Evidência | Força | Uso |
|---|---|---|---|
| E1 | Tokens oficiais expõem breakpoints, famílias de cor, fonte system UI, textos extras 4xs/3xs/2xs, spacing e leading. | forte | Identidade, responsividade, cor, spacing, tipografia |
| E2 | Reboot define body `dark` sobre `light-100`, fonte system UI, headings com peso médio e margens base. | forte com lacuna | Base visual e tipografia HTML |
| E3 | Botões usam filled/outline, temas semânticos, hover/active, focus ring e tamanhos sistemáticos. | forte | CTA, hierarquia, estados |
| E4 | Icon buttons são circulares, transparentes por default e usam cor no ícone/hover. | forte | Toolbars, sidebars, ações compactas |
| E5 | Badges, field badges e feedbacks usam fundo 100, texto 800 e borda leve da família semântica. | forte | Feedback inline, chips, status |
| E6 | Inputs usam fundo branco, borda `light-400`, focus `primary`, invalid `danger`, disabled/read-only `light-100`. | forte | Forms |
| E7 | App shell usa topbar fixa, sidebar branca oculta em telas pequenas, conteúdo grid e footer branco. | forte | Estrutura de aplicação |
| E8 | Modal/offcanvas usam backdrop `black/20`, z-index escalonado e transições curtas. | forte | Overlays |
| E9 | Pagination tem desktop numérico e mobile compacto com break em `md`. | forte | Navegação responsiva |
| E10 | Demos usam `Box` com `p-8`, `bg-white`, `border-none`, seções `space-y-*` e containers com `border-light-300`. | fraca | Ritmo de página e exemplos |

## Lacunas abertas

| Eixo | O que falta | Evidência encontrada | Impacto |
|---|---|---|---|
| Princípios oficiais | Documento explicito de filosofia visual | Nenhum princípio oficial encontrado; inferência veio de tokens/componentes/demos | médio: pode haver intenção de marca não capturada |
| Reboot CSS | Variáveis `--font-base`, `--font-normal`, `--font-medium`, `--font-bold`, `--font-light`, `--font-extra-bold`, `--radius-2`, `--size-3`, `--leading-1` não aparecem definidas | Usos observados no CSS base; definições não encontradas | médio: pode afetar tipografia/base se usada fora dos componentes |
| Busca no AppMenu | Busca visual/funcional não implementada | Área contém texto placeholder `search component` | baixo: não bloquear patterns, mas não mapear como search pronto |
| Visual real renderizado | Sem screenshots oficiais avaliadas nesta etapa | Evidência principal veio de tokens, CSS e demos em código | baixo: suficiente para linguagem, mas não confirma render final |
| Componentes de dados ricos | Data grid/tabela/chart não encontrados | Inventario não mostrou componentes dedicados | médio: afetara cobertura de patterns de dados |

## Avaliação de qualidade

O documento é suficiente para outra IA desenhar telas coerentes com a Yasamen em fluxos de aplicação, formulários, navegação, feedback e overlays. A confiança e alta para cor, spacing, ações, feedback, forms, app shell e responsividade básica porque esses eixos tem tokens e CSS fortes. A confiança e média para filosofia visual ampla, cards de produto, dashboards ricos e data display porque não há princípios oficiais nem componentes de dados complexos.
