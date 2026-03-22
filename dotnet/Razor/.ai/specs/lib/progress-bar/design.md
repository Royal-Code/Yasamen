# Design — ProgressBar

## Decisões de Estrutura

- Implementar `ProgressBar` em `RoyalCode.Razor.Alerts`.
- Manter `namespace RoyalCode.Razor.Components` para o componente público e para o enum público `ProgressBarAnimation`.
- Não criar pacote novo nem acionar `create-library-project`; o projeto atual já abriga feedbacks visuais (`Feedback`, `Notification`, `Badge`) e é o encaixe mais coerente para a barra de progresso.
- Preservar dependências diretas enxutas:
  - `RoyalCode.Razor.Styles` para `Themes`, `Sizes`, `CssClasses` e tokens visuais;
  - dependências já existentes do pacote `Alerts`, sem introduzir referência obrigatória a `RoyalCode.Razor.Animations` no primeiro release.
- Reaproveitar o precedente visual já existente da barra temporal da `Notification`, mas sem acoplar a API pública do novo componente à semântica de toast.

## Composição, Dependências e Ordem de Implementação

- Classificação: `ProgressBar` é um primitivo base de feedback linear.
- Reuso previsto:
  - helpers de classes e enums semânticos de `RoyalCode.Razor.Styles`;
  - convenções de tema já usadas em `Feedback` e `Notification`.
- Dependência-base ausente avaliada: não é necessário criar um `ProgressIndicatorBase` antes do primeiro release.
- Decisão: `ProgressCircle` permanece como componente futuro independente. Se a implementação futura revelar duplicação real, a abstração compartilhada poderá nascer depois, e não antes.

## API Pública Proposta

### Componentes públicos

- `ProgressBar`
- `ProgressBarAnimation`

### Parâmetros

- `double Value`
- `double Min = 0`
- `double Max = 100`
- `bool Indeterminate`
- `Themes Style = Themes.Default`
- `Sizes Size = Sizes.Default`
- `string? Label`
- `bool ShowValue`
- `string? ValueText`
- `string? AriaLabel`
- `ProgressBarAnimation Animation = ProgressBarAnimation.None`
- `string? AdditionalClasses`
- `Dictionary<string, object>? AdditionalAttributes`

### Variações visuais e dimensionais

- `Style: Themes`
  - suportado no primeiro release;
  - temas previstos: `Primary`, `Secondary`, `Tertiary`, `Info`, `Highlight`, `Success`, `Warning`, `Alert`, `Danger`, `Light`, `Dark`;
  - fallback explícito: `Themes.Default -> Themes.Primary`;
  - o tema afeta a cor principal do preenchimento e os overlays de animação, mantendo a trilha neutra e legível.
- `Size: Sizes`
  - suportado no primeiro release;
  - `Sizes.Default` funciona como baseline equivalente ao ritmo visual médio;
  - os tamanhos afetam altura da trilha, raio, espaçamento do cabeçalho e tipografia de `Label`/`ValueText`;
  - a implementação deve aceitar toda a enumeração atual (`Smallest` até `Largest`) por meio de classes públicas previsíveis.

### Slots e eventos

- Não haverá slots nomeados no primeiro release.
- Não haverá `EventCallback`; o componente é puramente declarativo e informativo.
- `Label` e `ValueText` ficam textuais para manter a API enxuta no v1.
- `ChildContent` não fará parte da API pública no primeiro release.
- Se futuramente houver necessidade de cabeçalho rico, isso deve entrar como refinamento de spec e não como detalhe implícito da implementação.

## Estrutura Interna

Arquivos previstos:

- `Components/ProgressBar.razor`
- `Components/ProgressBar.razor.cs`
- `Components/ProgressBarAnimation.cs`

Estratégia:

- O componente renderiza um contêiner raiz com cabeçalho opcional e uma trilha linear.
- A largura efetiva do preenchimento em modo determinado deve ser derivada de percentagem normalizada.
- Quando `Max <= Min`, a normalização deve usar internamente o intervalo `0..100`.
- Quando `Animation != None` e `Indeterminate = false`, o efeito visual deve ocorrer sobre a área já preenchida.
- Quando `Animation != None` e `Indeterminate = true`, a renderização deve usar movimento contínuo dentro da trilha inteira.
- A percentagem efetiva deve ser calculada com clamp do valor dentro do intervalo válido.
- O markup deve permanecer simples, sem wrappers desnecessários e sem dependência de JS.

### Enum público `ProgressBarAnimation`

Valores previstos:

- `None`
- `BarberPole`
- `PingPong`

Semântica:

- `BarberPole` aplica faixas diagonais contínuas em uma direção.
- `PingPong` aplica uma faixa suave/degradê que percorre ida e volta.

## CSS e Contrato Visual

- Criar `RoyalCode.Razor.Styles/wwwroot/css/components/progress-bar.css`.
- Registrar o `@import` em `RoyalCode.Razor.Styles/wwwroot/yasamen.css`.
- Não criar `ProgressBar.razor.css`.

Classes públicas previstas:

| Classe | Uso |
|---|---|
| `ya-progress-bar` | Container raiz do componente |
| `ya-progress-bar-header` | Linha opcional com rótulo e valor |
| `ya-progress-bar-label` | Texto de rótulo |
| `ya-progress-bar-value` | Texto do valor renderizado |
| `ya-progress-bar-track` | Trilho neutro da barra |
| `ya-progress-bar-fill` | Área preenchida no modo determinado |
| `ya-progress-bar-indeterminate` | Estado de modo indeterminado |
| `ya-progress-bar-animated` | Estado com animação habilitada |
| `ya-progress-bar-motion-barber-pole` | Modificador da animação zebrada |
| `ya-progress-bar-motion-ping-pong` | Modificador da animação de ida e volta |
| `ya-progress-bar-complete` | Estado opcional quando a percentagem efetiva chega a 100% |

Variações de tema e tamanho:

- tema via classes `ya-progress-bar-{theme}` geradas de forma previsível;
- tamanho via `Size.ToCssClassName("ya-progress-bar")`.

Tokens de `yasamen.css` a priorizar:

- cores semânticas `--color-primary-*`, `--color-secondary-*`, `--color-success-*`, `--color-warning-*`, `--color-danger-*`, `--color-light-*`, `--color-dark-*`;
- espaçamentos `--spacing-2`, `--spacing-3`, `--spacing-4`;
- tipografia `--text-xs`, `--text-sm`, `--text-base`;
- raios `--radius-sm`, `--radius-md`, `--radius-lg`;
- transição `--default-transition-duration` e `--ease-in-out`.

Diretrizes visuais:

- a trilha deve permanecer neutra e discreta;
- o preenchimento deve carregar a semântica do tema;
- a animação não deve exigir cores hardcoded fora dos tokens;
- `prefers-reduced-motion` deve reduzir ou remover keyframes, preservando leitura do estado.

## Testes e Documentação

- Cobrir com testes automatizados:
  - renderização determinada básica;
  - clamp de `Value` abaixo/acima do intervalo;
  - fallback quando `Max <= Min`;
  - ausência de `aria-valuenow` no modo indeterminado;
  - renderização de `Label`, `ShowValue` e `ValueText`;
  - classes de tema, tamanho e animação;
  - marcação de estado completo quando atingir 100%.
- Preferir bUnit para a marcação e para as classes.
- Se não existir projeto de testes adequado para `Alerts`, a implementação deve decidir entre criar `RoyalCode.Razor.Alerts.Tests` ou posicionar os testes em estrutura compatível da solução.

## Showcase no Docs

- Rota inicial: `/demo/feedback/progress-bar`.
- Página alvo: `RoyalCode.Razor.Docs.Client/Pages/Demo/Feedback/ProgressBarPage.razor`.
- Menu: grupo `Feedback` em `RoyalCode.Razor.Docs.Client/ConfigureMenu.cs`.
- Estrutura mínima da página:
  - introdução curta;
  - seção `Básico`;
  - seção `Temas e Tamanhos`;
  - seção `Determinado com Valor`;
  - seção `Indeterminado`;
  - seção `Animações Contínuas`;
  - seção `Largura Reduzida`.
- O showcase deve demonstrar o componente com API pública apenas, sem usar `RoyalCode.Razor.Internal.*`.

## Riscos e Questões em Aberto

- Confirmar durante a implementação se `Label` e `ValueText` textuais bastam, ou se surgirá necessidade real de slot de cabeçalho.
- Confirmar se `BarberPole` e `PingPong` devem ser liberados para qualquer tamanho sem ajuste específico de contraste nas extremidades menores.
- Confirmar se o estado `complete` merece visual dedicado ou apenas o preenchimento total no primeiro release.

## Validação Esperada

- `dotnet build` dos projetos afetados:
  - `RoyalCode.Razor.Alerts`
  - `RoyalCode.Razor.Styles`
  - `RoyalCode.Razor.Docs.Client`
- Testes automatizados cobrindo markup, classes e estados de borda.
- Validação manual do showcase em `/demo/feedback/progress-bar`.
- Validação humana explícita do comportamento visual das animações `BarberPole` e `PingPong`.
- Reavaliação do `ui-map.md` para verificar se a cobertura de `UIP-FEEDBACK-LOADING_STATE` deve ser ajustada após a implementação.
