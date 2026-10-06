# Anatomia de componente

## Arquivos por componente

```
src/lib/components/<dominio>/
├── <Nome>.tsx                  # componente
├── <nome>-classes.ts           # mapeamento de classes ya-* (quando houver)
├── <nome>-context.ts           # contexto React (quando houver)
├── index.ts                    # export do domínio
└── __tests__/<Nome>.spec.tsx
```

Regras que a IA deve seguir estritamente:
- Nomear arquivo de componente em PascalCase. Nomear `*-classes.ts` e `*-context.ts` em kebab-case.
- Exportar o componente em `<dominio>/index.ts` e `src/lib/index.ts`. Componente fora de `src/lib/index.ts` está incompleto.
- Criar página em `src/demo/pages/<Nome>Page.tsx`. Registrar a rota em `src/demo/App.tsx` e o item de menu em `src/demo/layout/DemoMainLayout.tsx`.
- Criar história em `src/stories/components/<Nome>.stories.tsx` ou `src/stories/layouts/`. Cobrir temas, tamanhos e estados.

## Props

Regras que a IA deve seguir estritamente:
- Estender `React.HTMLAttributes<HTMLElement>` do elemento correspondente (`ButtonHTMLAttributes<HTMLButtonElement>`, `HTMLAttributes<HTMLDivElement>`).
- Exportar a interface: `export interface <Nome>Props`.
- Aceitar `className?: string`. Combinar com classes internas por `[className, ...classes].filter(Boolean).join(' ')`.
- Aceitar `theme?: Themes` e `size?: Sizes` quando o componente tiver variação. Padrão: `Themes.Primary` e `Sizes.Medium`.
- Repassar `...rest` ao elemento raiz.
- Lançar erro explícito para combinação inválida de props, como `Button` com `iconPosition` central.

## Temas e tamanhos

Enums em `src/lib/components/commons/`:

| Enum | Valores |
|---|---|
| `Themes` | `Primary`, `Secondary`, `Tertiary`, `Info`, `Highlight`, `Success`, `Warning`, `Alert`, `Danger`, `Light`, `Dark` |
| `Sizes` | `Smallest`, `Smaller`, `Small`, `Medium`, `Large`, `Larger`, `Largest` |

Regras que a IA deve seguir estritamente:
- Usar os enums. Não usar string literal de tema ou tamanho em componente.
- Declarar na spec os temas e tamanhos suportados. Justificar ausência.

## Compound slots

Funções de `src/lib/utils/compound.tsx`:
- `createSlot('<Nome>')` cria o marcador.
- `attachSlots(Root, { Slot1, Slot2 })` anexa os slots ao componente raiz.
- `pickSlots(children, { Slot1, Slot2 })` extrai o conteúdo de cada slot no render.
- `hasContent(slot)` indica se o slot tem conteúdo.

Regras que a IA deve seguir estritamente:
- Renderizar o container do slot somente quando `hasContent(slot)` for verdadeiro.

## Navegação (`navigateTo`)

Regras que a IA deve seguir estritamente:
- Aceitar `navigateTo?: string` em componente acionável (botão, link, item de menu).
- No `onClick`, quando `navigateTo` estiver preenchido, chamar `e.preventDefault()` e `getNavigator().navigate(navigateTo)`.
- Não navegar quando o componente estiver `disabled`.

## Ripple

Regras que a IA deve seguir estritamente:
- Renderizar `<Ripple dark={isDark} />` ao final do conteúdo clicável.
- Declarar `position: relative` e `overflow: hidden` na classe base do elemento.

## Transições por fase

Aplicar a overlays (`Modal`, `Offcanvas`).

Regras que a IA deve seguir estritamente:
- Usar máquina de fases: `closed`, `opening_start`, `opening`, `open`, `closing_start`, `closing`.
- Avançar a fase em `onTransitionEnd`.
- Mapear cada fase a uma classe `ya-<nome>-*`.

## Seções (outlet)

Regras que a IA deve seguir estritamente:
- Envolver conteúdo projetado em `<SectionContent id=...>`.
- Renderizar o destino com `<SectionOutlet id=...>`.
- Usar `id` único por conteúdo projetado.
