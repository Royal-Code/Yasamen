# UIP-ACTION-FLOATING_ACTION - Floating Action

**GAP parcial — sem componente dedicado**

A biblioteca não tem componente de FAB (Floating Action Button). Implementação requer CSS de posicionamento `fixed` + Button nativo.

## Componentes

**Principais**: nenhum dedicado.

**Composição**:

1. Button
- `cobertura`: ação com ícone + label ou apenas ícone; `Themes.Primary` para ação primária dominante; `Loading=true` para feedback de progresso; `Disabled=true` para estado inativo; falta posicionamento flutuante nativo;
- `limitações`: sem `fixed` nativo — requer `AdditionalClasses="fixed bottom-6 right-6 z-floating shadow-lg rounded-full"`;
- `nota`: 5;
- `justificativa`: o componente Button cobre a ação mas não a posição flutuante — requer CSS manual.

2. IconButton
- `cobertura`: variante circular compacta mais próxima do FAB tradicional com ícone circular;
- `limitações`: mesma limitação de posicionamento — requer CSS fixed;
- `nota`: 5;
- `justificativa`: variante mais próxima visualmente de FAB circular.

**Descartados**: nenhum.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `posicionamento fixo flutuante`: sem nativo — usar `AdditionalClasses="fixed bottom-6 right-6 z-10 shadow-md"` + classes de tamanho;
  - `variante circular`: Button não é circular por padrão — `AdditionalClasses="rounded-full w-14 h-14 p-0"` para forma;
  - `FAB estendido (ícone + label)`: Button com `rounded-full` + padding horizontal;
  - `ocultar em scroll`: sem comportamento nativo — JS interop necessário para scroll listener.

- `tipo de adaptação`: composição + estilos CSS
- `o que precisa ser feito`:
  - Usar `Button` ou `IconButton` com `AdditionalClasses` de posicionamento fixo;
  - Forma circular para FAB tradicional mobile; botão pill para FAB estendido;
  - Cuidado com z-index: usar `z-10` ou z customizado para não sobrepor Modal/Drawer.

## Como usar

### FAB circular (ícone)

```razor
<Button Style="Themes.Primary"
        AdditionalClasses="fixed bottom-6 right-6 z-10 shadow-lg rounded-full w-14 h-14 p-0 flex items-center justify-center"
        OnClick="NovoItem">
    @WellKnownIcons.Add("text-xl text-white")
</Button>
```

### FAB estendido (ícone + label)

```razor
<Button Style="Themes.Primary" Label="Nova tarefa"
        Icon="WellKnownIcons.Add"
        AdditionalClasses="fixed bottom-6 right-6 z-10 shadow-lg rounded-full px-6"
        OnClick="NovaTarefa" />
```

### FAB condicional (oculto em estado de loading)

```razor
@if (!carregando)
{
    <Button Style="Themes.Primary"
            AdditionalClasses="fixed bottom-6 right-6 z-10 shadow-lg rounded-full w-14 h-14 p-0"
            OnClick="NovoItem">
        @WellKnownIcons.Add("text-xl")
    </Button>
}
```

## Decisão de uso

- `nota geral`: 2;
- `limitações`: sem componente de FAB nativo; toda implementação é Button com CSS manual de posicionamento; sem variante circular nativa; sem ocultar-em-scroll automático; z-index manual para não colidir com overlays;
- `recomendação`: `usar com adaptação`
- `justificativa geral`:
  - `Button` com `AdditionalClasses="fixed bottom-X right-X rounded-full"` cobre FAB funcional;
  - Nota 2 reflete que apenas primitivos genéricos estão disponíveis — nenhum componente específico de FAB existe na lib;
  - Para web/desktop, `ACTION_BAR` ou botão inline geralmente é preferível ao FAB.
