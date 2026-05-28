# UIP-FEEDBACK-LOADING_STATE - Loading State

## Componentes

**Principais**: nenhum dedicado.

**Composição**:

1. RotationMotion (via Animations)
- `cobertura`: animação de rotação contínua aplicada a um ícone — cobre loading de ação inline como spinner visual; usa `ya-rotation` ou `ya-rotation-clockwise` via atributo HTML;
- `limitações`: é apenas animação de ícone, não componente de loading state completo; sem label de "carregando"; sem gestão de fases de loading; requer ícone que faça sentido rotacionando (ex: seta circular, spinner);
- `nota`: 4;
- `justificativa`: cobre o loading inline de botão/ação mas não loading de zona, skeleton ou progresso determinado.

2. Button com IconAnimation
- `cobertura`: botão com ícone rotativo indica processamento de ação — loading inline direto no ponto de interação;
- `limitações`: somente para loading de ação de botão; não serve para loading de zona ou página;
- `nota`: 7;
- `justificativa`: cobertura natural para loading inline de ação — é o padrão esperado quando um botão está processando.

3. Pagination com `Loading=true`
- `cobertura`: estado de loading na paginação — reduz opacidade para 80% indicando carregamento da página;
- `limitações`: somente para contexto de paginação; não é reutilizável;
- `nota`: 6;
- `justificativa`: cobre loading contextual de paginação de forma nativa.

4. Feedback
- `cobertura`: exibe mensagem textual de carregamento (ex: "Carregando...") como loading state textual; sem animação própria;
- `limitações`: sem animação; sem skeleton; apenas texto estático — não comunica progresso visual;
- `nota`: 3;
- `justificativa`: cobertura fraca — serve apenas como fallback textual, não como indicador de loading.

**Descartados**:

1. Badge
- `motivo`: sem papel em loading state.

2. Notification
- `motivo`: para resultado de ação concluída, não para estado de carregamento em curso.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `skeleton de conteúdo`: totalmente ausente — implementar com divs de fundo cinza pulsante via CSS customizado;
  - `progress bar / progresso determinado`: sem componente; implementar com HTML `<progress>` nativo ou CSS customizado;
  - `loading de zona/página`: sem componente — usar RotationMotion + texto "Carregando..." dentro da zona como filhos condicionais;
  - `loading de ação em botão`: coberto nativamente via `Button IconAnimation`;
  - `progresso indeterminado de background`: sem componente — ver UIP-SYSTEM-BACKGROUND_PROGRESS.

- `tipo de adaptação`: nova implementação com composição + estilos
- `o que precisa ser feito`:
  - Loading de botão: usar `<Button Icon="..." IconAnimation="@Spinning">` onde `Spinning = content => @<RotationMotion>@content</RotationMotion>`;
  - Loading de zona: usar `if (isLoading)` + `<div class="flex items-center gap-2 p-4 text-dark-600">` + `@WellKnownIcons.Spinner("animate-spin")` + `<span class="text-sm">Carregando...</span>`;
  - Skeleton de lista: HTML com `<div class="h-4 bg-light-200 rounded animate-pulse mb-2">` por linha simulada;
  - Loading de paginação: `<Pagination Loading="@isLoading" ...>`.

## Como usar

### Loading de ação em botão

```razor
@code {
    private bool isSaving = false;
    private AnimationFragment Spinning => 
        content => @<RotationMotion>@content</RotationMotion>;
}

<Button Style="Themes.Primary" Label="Salvar"
        Icon="WellKnownIcons.LoadIcon"
        IconAnimation="@(isSaving ? Spinning : null)"
        Disabled="isSaving"
        OnClick="Salvar" />
```

### Loading de zona (spinner + texto)

```razor
@if (isLoading)
{
    <Box Border="BorderBuilder.Box" AdditionalClasses="p-8">
        <div class="flex flex-col items-center gap-3 py-6 text-dark-600">
            <RotationMotion>
                @WellKnownIcons.Spinner("text-2xl text-primary-400")
            </RotationMotion>
            <span class="text-sm text-dark-700">Carregando...</span>
        </div>
    </Box>
}
```

### Loading de paginação

```razor
<Pagination CurrentPage="@currentPage" TotalPages="@totalPages"
            OnPageChanged="OnPageChanged" Loading="@isLoading" />
```

### Skeleton simples de lista (composição CSS)

```razor
@if (isLoading)
{
    <Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
        @for (int i = 0; i < 5; i++)
        {
            <div class="flex gap-3 mb-3 animate-pulse">
                <div class="h-4 bg-light-200 rounded flex-1"></div>
                <div class="h-4 bg-light-200 rounded w-16"></div>
                <div class="h-4 bg-light-200 rounded w-20"></div>
            </div>
        }
    </Box>
}
```

## Decisão de uso

- `nota geral`: 3;
- `limitações`: a biblioteca não tem componente dedicado de loading state — sem skeleton, sem progress bar, sem spinner standalone; loading de botão é bem coberto via `IconAnimation`+`RotationMotion`; loading de zona requer composição manual com CSS; loading de paginação tem suporte nativo via `Loading=true`; todo indicador de loading além de botão é implementação manual;
- `recomendação`: `usar com adaptação`
- `justificativa geral`:
  - `RotationMotion` em ícone de botão é o único loading visual nativo da biblioteca;
  - `Pagination Loading=true` cobre loading de paginação;
  - Para qualquer outro cenário (zona, página, skeleton, progresso), o app deve implementar o indicador com HTML e classes Tailwind;
  - Nota 3 reflete que apenas primitivos de animação (RotationMotion) e estado de paginação são fornecidos — o padrão de loading em sua maioria depende de implementação customizada.
