# React + TypeScript + Vite

This template provides a minimal setup to get React working in Vite with HMR and some ESLint rules.

Currently, two official plugins are available:

- [@vitejs/plugin-react](https://github.com/vitejs/vite-plugin-react/blob/main/packages/plugin-react) uses [Babel](https://babeljs.io/) for Fast Refresh
- [@vitejs/plugin-react-swc](https://github.com/vitejs/vite-plugin-react/blob/main/packages/plugin-react-swc) uses [SWC](https://swc.rs/) for Fast Refresh

## Expanding the ESLint configuration

If you are developing a production application, we recommend updating the configuration to enable type-aware lint rules:

```js
export default tseslint.config({
  extends: [
    // Remove ...tseslint.configs.recommended and replace with this
    ...tseslint.configs.recommendedTypeChecked,
    // Alternatively, use this for stricter rules
    ...tseslint.configs.strictTypeChecked,
    // Optionally, add this for stylistic rules
    ...tseslint.configs.stylisticTypeChecked,
  ],
  languageOptions: {
    // other options...
    parserOptions: {
      project: ['./tsconfig.node.json', './tsconfig.app.json'],
      tsconfigRootDir: import.meta.dirname,
    },
  },
})
```

You can also install [eslint-plugin-react-x](https://github.com/Rel1cx/eslint-react/tree/main/packages/plugins/eslint-plugin-react-x) and [eslint-plugin-react-dom](https://github.com/Rel1cx/eslint-react/tree/main/packages/plugins/eslint-plugin-react-dom) for React-specific lint rules:

```js
// eslint.config.js
import reactX from 'eslint-plugin-react-x'
import reactDom from 'eslint-plugin-react-dom'

export default tseslint.config({
  plugins: {
    // Add the react-x and react-dom plugins
    'react-x': reactX,
    'react-dom': reactDom,
  },
  rules: {
    // other rules...
    // Enable its recommended typescript rules
    ...reactX.configs['recommended-typescript'].rules,
    ...reactDom.configs.recommended.rules,
  },
})
```

## Section Outlet / Content

O padrão de seções permite declarar conteúdo em qualquer lugar da árvore e renderizá-lo em outro ponto específico. Baseado no conceito de `SectionOutlet` / `SectionContent` do Blazor.

### Uso Básico

Envólva sua aplicação com o `SectionProvider`:

```tsx
import { SectionProvider } from './src/lib/components/outlet';

<SectionProvider>
  <App />
</SectionProvider>
```

Declare conteúdo em um ponto da árvore:

```tsx
import { SectionContent } from './src/lib/components/outlet';

<SectionContent id="header">
  <h1>Título da Página</h1>
</SectionContent>
```

E consuma em outro ponto com o `SectionOutlet`:

```tsx
import { SectionOutlet } from './src/lib/components/outlet';

<header>
  <SectionOutlet id="header" />
</header>
```

Se múltiplos `SectionContent` usarem o mesmo `id`, o último montado vence. Ao desmontar um conteúdo, o anterior volta automaticamente.

### Comportamento
- Registro em pilha por `id` (stack).
- Atualização do nó ao mudar `children`.
- Limpeza automática no unmount.
- Sem markup extra no `SectionOutlet` (usa fragment).

### Quando usar
Útil para títulos dinâmicos, barras de ação, breadcrumbs ou áreas de layout global definidas por páginas internas.

### Fallback
Não há fallback interno; se nenhum conteúdo registrado, nada é renderizado. Você pode embrulhar `<SectionOutlet />` com markup adicional para fornecer um placeholder.
