# Tokens (`@theme`)

Fonte dos valores: `src/lib/styles/yasamen.css`. Ler o arquivo antes de usar um token. Não copiar valores para outros arquivos.

## Cores

Temas: `primary`, `secondary`, `tertiary`, `info`, `highlight`, `success`, `warning`, `alert`, `danger`, `light`, `dark`.

Regras que a IA deve seguir estritamente:
- Cada tema tem `--color-<tema>` e `--color-<tema>-100` a `--color-<tema>-900`.
- Usar `var(--color-<tema>)` ou classe Tailwind (`bg-primary-500`, `text-primary-500`).
- Não escrever hexadecimal em CSS de componente.
- Não alterar valor de token existente sem decisão confirmada.
- Criar tema novo com a cor base e as nove variações.

## Breakpoints

| Token | Valor |
|---|---|
| `--breakpoint-xs` | `30rem` |
| `--breakpoint-sm` | `40rem` |
| `--breakpoint-md` | `48rem` |
| `--breakpoint-lg` | `64rem` |
| `--breakpoint-xl` | `80rem` |
| `--breakpoint-2xl` | `96rem` |

## Tipografia

- Fontes: `--font-sans`, `--font-serif`, `--font-mono`.
- Tamanhos extras: `--text-4xs` (`0.5rem`), `--text-3xs` (`0.5625rem`), `--text-2xs` (`0.625rem`).
- Altura de linha: `--leading-none`, `--leading-xs`, `--leading-sm`, `--leading-base`, `--leading-lg`, `--leading-xl`.

## Espaçamento

Regras que a IA deve seguir estritamente:
- Usar `--spacing-*` de `yasamen.css` (escala granular com meio-valores).
- Mapear espaçamento numérico por `commons/spacing.ts`, `margins.ts`, `paddings.ts`, `heights.ts`, `widths.ts`.
- Não criar espaçamento fora da escala.

## Z-index (`utilities.css`)

| Utilitário | Valor |
|---|---|
| `z-app-header` | `1010` |
| `z-offcanvas-backdrop` | `1020` |
| `z-offcanvas` | `1030` |
| `z-backdrop` | `1040` |
| `z-modal` | `1050` |
| `z-notification` | `1060` (criar ao implementar notificação) |

Regras que a IA deve seguir estritamente:
- Incrementar de 10 em 10.
- Posicionar o backdrop abaixo do componente.
- Posicionar notificação acima de todos.

## Transição e fit

Regras que a IA deve seguir estritamente:
- Usar `transition-default` (`all 0.25s cubic-bezier(.16,1,.3,1)`) em transição.
- Usar `fit-top-*`, `fit-left-*`, `fit-right-*`, `fit-bottom-*` para posicionamento de offcanvas e overlays (`--ya-fit-*`).
