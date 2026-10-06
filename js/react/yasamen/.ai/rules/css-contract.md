# Contrato CSS

## Arquivos

```
src/lib/styles/
├── yasamen.css
└── css/
    ├── variables.css
    ├── ripple.css
    ├── reboot.css
    ├── utilities.css
    ├── components/<nome>.css
    └── forms/<nome>.css          # componentes de formulário
```

Regras que a IA deve seguir estritamente:
- Criar o CSS de componente em `src/lib/styles/css/components/<nome>.css`.
- Criar o CSS de formulário em `src/lib/styles/css/forms/<nome>.css`.
- Registrar o `@import` em `yasamen.css`, em ordem alfabética dentro do bloco.
- Preservar a ordem de blocos de `yasamen.css`:

1. `@import './css/variables.css';`
2. `@import './css/ripple.css';`
3. `@import './css/reboot.css';`
4. `@import 'tailwindcss';`
5. `@import './css/utilities.css';`
6. `@import './css/components/<arquivo>.css';` (alfabético)
7. `@import './css/forms/<arquivo>.css';` (alfabético, se houver)
8. `@theme { ... }`

## Nomenclatura

| Elemento | Padrão | Exemplo |
|---|---|---|
| Base | `ya-<bloco>` | `ya-btn` |
| Parte interna | `ya-<bloco>-<parte>` | `ya-modal-content` |
| Tema | `ya-<bloco>-<tema>` | `ya-btn-primary` |
| Tema outline | `ya-<bloco>-<tema>-outline` | `ya-btn-primary-outline` |
| Tema ativo | `ya-<bloco>-<tema>-active` | `ya-btn-primary-active` |
| Tamanho | `ya-<bloco>-<tamanho>` | `ya-btn-2xs`, `-xs`, `-sm`, `-md`, `-lg`, `-xl`, `-2xl` |
| Modificador | `ya-<bloco>-<modificador>` | `ya-btn-block`, `ya-btn-disabled` |
| Fase de transição | `ya-<bloco>-<fase>` | `ya-offcanvas-opening` |

Regras que a IA deve seguir estritamente:
- Usar prefixo `ya-` e kebab-case.
- Usar `-` simples. Não usar `--`.
- Declarar tema e tamanho como sufixo. Declarar modificador como classe separada.
- Declarar estado interativo por pseudo-classe (`:hover`, `:active`, `:focus-within`) e estado persistente por classe (`ya-<bloco>-disabled`).
- Usar variante dos 11 temas quando o componente tiver `theme`.

## Estrutura de arquivo de componente

Ordem: base, temas, tamanhos, modificadores, estados.

Regras que a IA deve seguir estritamente:
- Usar `@apply` com utilitários Tailwind. Não duplicar declaração.
- Usar `transition-default` para transição.
- Usar `var(--color-*)` ou classe de cor do Tailwind. Não usar hexadecimal fora do `@theme`.
- Usar `--spacing-*` para espaçamento. Não criar espaçamento customizado.
- Usar `z-*` de `utilities.css`. Não escrever `z-index` numérico.
- Implementar hover, active, disabled e foco visível.
- Declarar layout mobile first; ajustar por breakpoint do `@theme`.
- Mapear props para classes em `<nome>-classes.ts`. Não escrever classe arbitrária no JSX.

## Variáveis não-theme (`variables.css`)

| Prefixo | Uso |
|---|---|
| `--duration-*` | Duração de animação |
| `--ya-*` | Variável de componente Yasamen (`--ya-fit-*`, `--ya-stack-gap`) |
| `--<componente>-*` | Variável de componente específico |

## Reboot

Regras que a IA deve seguir estritamente:
- Manter `reboot.css` como normalização de body, headings, parágrafos, listas, formulários, tabelas, links e imagens.
- Não estilizar elemento HTML puro em `components/*.css`.

## Verificação

Regras que a IA deve seguir estritamente:
- Conferir que toda classe usada em `<nome>-classes.ts` existe em `components/<nome>.css`.
- Conferir que todo `components/*.css` está importado em `yasamen.css`.
