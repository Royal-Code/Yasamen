# Arquitetura e estrutura

`js/react/yasamen/` é a biblioteca de componentes React 19 + TypeScript do Yasamen. Espelha a arquitetura do Razor (`dotnet/Razor`).

Regras que a IA deve seguir estritamente:
- Derivar cor, tipografia e breakpoint do `@theme` do Tailwind v4.
- Prefixar todo seletor CSS de componente com `ya-`.
- Projetar blocos nomeados por slots (`<Componente.Slot>`).
- Usar `SectionOutlet` e `SectionContent` para portais e injeção no layout.
- Tipar estritamente props, callbacks, contextos e retornos. Não usar `any`.

## Estrutura

```
js/react/yasamen/
├── AGENTS.md
├── .ai/                              # instruções, regras, roadmap, specs
├── .storybook/
├── dist/                             # saída do build (não editar)
├── src/
│   ├── demo/
│   │   ├── layout/                   # DemoMainLayout.tsx
│   │   ├── pages/                    # <Nome>Page.tsx
│   │   ├── App.tsx                   # rotas da demo
│   │   └── main.tsx
│   ├── lib/                          # código distribuído
│   │   ├── components/<dominio>/
│   │   ├── styles/
│   │   │   ├── css/
│   │   │   │   ├── components/       # <nome>.css
│   │   │   │   ├── reboot.css
│   │   │   │   ├── ripple.css
│   │   │   │   ├── utilities.css
│   │   │   │   └── variables.css
│   │   │   └── yasamen.css
│   │   ├── utils/                    # compound.tsx, number-value-map, navigation
│   │   └── index.ts                  # export público
│   └── stories/
│       ├── components/
│       └── layouts/
├── package.json
├── tsconfig.json, tsconfig.app.json, tsconfig.lib.json, tsconfig.node.json
├── vite.config.ts
├── vitest.workspace.ts, vitest.setup.ts
└── eslint.config.js
```

## Domínios em `src/lib/components/`

| Domínio | Conteúdo |
|---|---|
| `bsicons` | Provedor e SVGs de Bootstrap Icons |
| `button` | `Button`, `IconButton` |
| `commons` | Tokens, temas, tamanhos, spacing, `Ripple`, `navigator` |
| `icon` | `Icon`, factory, registry |
| `layouts` | `Bar`, `Stack`, `Container`, `Cols`, `layouts/apps/AppLayout` |
| `modal` | `Modal`, `ModalOutlet`, `ModalProvider`, `ModalBackdrop` |
| `offcanvas` | `Offcanvas`, `OffcanvasOutlet`, `OffcanvasProvider`, `OffcanvasBackdrop` |
| `outlet` | `SectionProvider`, `SectionContent`, `SectionOutlet` |
| `status` | `Status`, `Status404` |

Regras que a IA deve seguir estritamente:
- Criar novo domínio em pasta própria dentro de `src/lib/components/`.
- Manter o nome do arquivo e o caminho dos imports idênticos ao sistema de arquivos, incluindo maiúsculas e minúsculas.
- Não editar `dist/`.
