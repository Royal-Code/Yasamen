# UIP-OVERLAY-TOOLTIP - Tooltip

**GAP parcial — sem componente dedicado**

A biblioteca não tem componente de tooltip. A alternativa nativa é o atributo HTML `title` (tooltip nativo do browser, sem controle visual). Para tooltips com estilo consistente requer CSS puro com `:hover` via Tailwind ou JavaScript.

## Componentes

**Principais**: nenhum dedicado.

**Composição**:

1. (atributo HTML `title`)
- `cobertura`: tooltip nativo do browser acionado por hover/foco; sem controle de posicionamento, estilo ou delay;
- `nota`: 3;
- `justificativa`: funcional mas sem consistência visual com o design system.

2. IconButton (trigger com help icon)
- `cobertura`: ícone de interrogação como trigger de ajuda; redireciona para popover manual ao invés de tooltip;
- `nota`: 5;
- `justificativa`: alternativa prática — substituir tooltip por popover simples em `IconButton` de ajuda.

**Descartados**: nenhum.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `tooltip com estilo do design system`: CSS puro com `:hover` via Tailwind + grupo de classes;
  - `posicionamento automático`: estático por CSS (`top-full`, `bottom-full`, etc.);
  - `delay de aparição`: `transition-opacity` + `opacity-0 hover:opacity-100` com `delay-500`;
  - `tooltip em mobile`: substituir por popover, texto inline ou label explícito.

- `tipo de adaptação`: CSS puro via Tailwind ou substituição por help icon + popover
- `o que precisa ser feito`:
  - Wrapper com `group relative` + `span` filho oculto com `group-hover:block`;
  - Ou usar atributo `title` como fallback sem estilo;
  - Para ajuda em formulários: texto de ajuda inline abaixo do campo é preferível.

## Como usar

### Tooltip CSS puro (via Tailwind group)

```razor
<div class="group relative inline-block">
    <IconButton Icon="WellKnownIcons.Info" Style="Themes.Default" Size="Sizes.Small" />

    @* Tooltip *@
    <div class="absolute bottom-full left-1/2 -translate-x-1/2 mb-1 px-2 py-1
                bg-dark-700 text-white text-xs rounded whitespace-nowrap
                opacity-0 group-hover:opacity-100 transition-opacity delay-300
                pointer-events-none z-50">
        Clique para mais informações
        <div class="absolute top-full left-1/2 -translate-x-1/2 border-4
                    border-transparent border-t-dark-700"></div>
    </div>
</div>
```

### Tooltip nativo (title HTML — fallback simples)

```razor
<span title="Formato: DD/MM/AAAA">
    <FieldText @bind-Value="data" Label="Data" Type="date" />
</span>
```

### Help hint em formulário (alternativa preferida)

```razor
@* Alternativa: texto de ajuda inline abaixo do campo *@
<FormGroup>
    <FieldText @bind-Value="cpf" Label="CPF" Placeholder="000.000.000-00" />
    <p class="text-xs text-dark-400 mt-0.5">Somente números, sem pontos ou traços.</p>
</FormGroup>
```

### Substituição por popover para conteúdo longo

```razor
@* Para conteúdo mais longo, preferir help icon + popover (ver UIP-OVERLAY-POPOVER) *@
@code {
    private bool helpAberto;
}

<div class="flex items-center gap-1">
    <label class="text-sm text-dark-600">Coeficiente de ajuste</label>
    <div class="relative">
        <button class="text-dark-300 hover:text-dark-500 text-xs"
                @onclick="() => helpAberto = !helpAberto"
                @onclick:stopPropagation>
            ?
        </button>
        @if (helpAberto)
        {
            <div class="fixed inset-0 z-20" @onclick="() => helpAberto = false"></div>
            <div class="absolute left-0 top-full mt-1 z-30 w-48">
                <Box Border="BorderBuilder.Box" AdditionalClasses="p-2 shadow-lg bg-white text-xs text-dark-500">
                    Valor entre 0,8 e 1,2. Padrão: 1,0. Valores acima de 1,0 aumentam o resultado.
                </Box>
            </div>
        }
    </div>
</div>
```

## Decisão de uso

- `nota geral`: 1;
- `limitações`: sem componente de tooltip nativo; tooltip CSS puro via Tailwind funciona mas requer repetição de classes em cada uso; sem gerenciamento de posicionamento; sem acessibilidade automática (`aria-describedby`); tooltip nativo HTML (`title`) sem estilo do design system;
- `recomendação`: `usar com adaptação`
- `justificativa geral`:
  - Para ajuda em formulários: preferir texto de ajuda inline (não requer tooltip);
  - Para ícones sem rótulo: `title` HTML como fallback ou tooltip CSS grupo;
  - Para ajuda mais rica: substituir por help icon + popover manual (ver `UIP-OVERLAY-POPOVER`);
  - Nota 1 reflete ausência de componente dedicado — tooltip é o pattern de menor cobertura na lib.
