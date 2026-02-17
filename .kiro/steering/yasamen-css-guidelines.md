---
inclusion: auto
---

# Yasamen CSS Guidelines - Steering para Desenvolvimento de Estilos

Este documento orienta o desenvolvimento de estilos CSS nos projetos Yasamen (Razor e React), garantindo consistência entre as implementações.

---

## 1. Filosofia de Design

### Princípios Fundamentais

1. **Design Tokens First**: Sempre use variáveis CSS do @theme
2. **Tailwind CSS v4**: Base para todos os utilitários
3. **Convenção ya-***: Todos os componentes usam prefixo `ya-`
4. **Mobile First**: Design responsivo por padrão
5. **Acessibilidade**: ARIA labels, contraste, navegação por teclado

---

## 2. Estrutura de Arquivos CSS

### Organização Padrão

```
styles/
├── yasamen.css              # Arquivo principal
├── css/
│   ├── variables.css        # Variáveis customizadas (React)
│   ├── reboot.css          # Normalização HTML (React)
│   ├── ripple.css          # Efeito ripple
│   ├── utilities.css       # Utilitários customizados
│   ├── components/         # Componentes individuais
│   │   ├── btn.css
│   │   ├── ibtn.css
│   │   ├── modal.css
│   │   ├── offcanvas.css
│   │   ├── badge.css
│   │   ├── notification.css
│   │   └── ...
│   └── forms/              # Componentes de formulário
│       ├── fieldtext.css
│       ├── fielderror.css
│       └── ...
```

### Ordem de Importação (yasamen.css)

#### React (Import Direto)

```css
/* 1. Variáveis e fundação */
@import './css/variables.css';
@import './css/reboot.css';
@import './css/ripple.css';

/* 2. Tailwind CSS */
@import 'tailwindcss';

/* 3. Utilitários customizados */
@import './css/utilities.css';

/* 4. Componentes (ordem alfabética) */
@import './css/components/app-layout.css';
@import './css/components/badge.css';
/* ... */

/* 5. Forms (se houver) */
@import './css/forms/fieldtext.css';
/* ... */

/* 6. Theme tokens */
@theme { /* ... */ }
```

#### Razor (Bundle via Gulp)

O Razor usa dois arquivos que são bundled:

**styles.css** (bundled primeiro):
```css
@import url(css/variables.css);
@import url(css/reboot.css);
@import url(css/ripple.css);
```

**yasamen.css** (bundled depois):
```css
@import 'tailwindcss' source('../../../Razor');
@import './css/utilities.css';

/* Componentes */
@import './css/components/applayout.css';
/* ... */

@theme { /* ... */ }
```

**Build**: `gulpfile.js` combina `styles.css` + `yasamen.css` em um único bundle.

---

## 3. Design Tokens (@theme)

### Cores - OBRIGATÓRIO ✅

Sempre use estas cores exatas:

```css
@theme {
    /* Primary */
    --color-primary: #0d6dfd;
    --color-primary-100: #cfe2ff;
    --color-primary-200: #9ec5fe;
    --color-primary-300: #6ea7fe;
    --color-primary-400: #3d8afd;
    --color-primary-500: #0d6dfd;
    --color-primary-600: #0255d3;
    --color-primary-700: #01409e;
    --color-primary-800: #012b6a;
    --color-primary-900: #001535;
    
    /* Secondary, Tertiary, Info, Highlight, Success, Warning, Alert, Danger, Light, Dark */
    /* ... (ver arquivo completo) */
}
```

**Regras**:
- ✅ Sempre 9 variações (100-900) + cor base
- ✅ Nunca modificar valores existentes
- ✅ Usar `var(--color-primary)` no CSS, nunca hex direto

---

### Espaçamento - ESCOLHA UMA ABORDAGEM ⚠️

#### Opção A: Granular (Razor - 33 valores)

```css
--spacing-0: 0;
--spacing-0\.5: .03125rem;   /* 0.5px */
--spacing-1: .0625rem;        /* 1px */
--spacing-1\.5: .09375rem;    /* 1.5px */
--spacing-2: .125rem;         /* 2px */
--spacing-2\.5: .1875rem;     /* 3px */
/* ... até 16 */
```

**Quando usar**: Projetos que precisam controle fino de espaçamento.

#### Opção B: Simples (React - 17 valores)

```css
--spacing-0: 0;
--spacing-1: .0625rem;   /* 1px */
--spacing-2: .125rem;    /* 2px */
--spacing-3: .25rem;     /* 4px */
--spacing-4: .5rem;      /* 8px */
/* ... até 16 */
```

**Quando usar**: Projetos que preferem simplicidade e menos tokens.

**Recomendação**: Use Opção B (simples) para novos projetos. Adicione meio-valores apenas se necessário.

---

### Tipografia - OBRIGATÓRIO ✅

```css
@theme {
    --font-sans: system-ui, -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, "Helvetica Neue", Arial, sans-serif;
    --font-serif: "Georgia", "Times New Roman", Times, serif;
    --font-mono: SFMono-Regular, Consolas, "Liberation Mono", Menlo, monospace;
    
    --text-4xs: 0.5rem;
    --text-3xs: 0.5625rem;
    --text-2xs: 0.625rem;
    /* Tailwind fornece xs, sm, base, lg, xl, 2xl, etc */
    
    --leading-none: 1;
    --leading-xs: 1.125;
    --leading-sm: 1.25;
    --leading-base: 1.5;
    --leading-lg: 1.75;
    --leading-xl: 2;
}
```

---

### Breakpoints - OBRIGATÓRIO (React) / RECOMENDADO (Razor) ⚠️

```css
@theme {
    --breakpoint-xs: 30rem;   /* 480px */
    --breakpoint-sm: 40rem;   /* 640px */
    --breakpoint-md: 48rem;   /* 768px */
    --breakpoint-lg: 64rem;   /* 1024px */
    --breakpoint-xl: 80rem;   /* 1280px */
    --breakpoint-2xl: 96rem;  /* 1536px */
}
```

**Razor**: Adicione estes breakpoints ao @theme.

---

## 4. Variáveis CSS Customizadas

### variables.css (Obrigatório)

Ambos os projetos possuem arquivo separado para variáveis não-theme:

#### Razor (Correto ✅)

```css
:root {
    /* Animation Durations */
    --duration-slowest: 0.9s;
    --duration-slower: 0.6s;
    --duration-slow: 0.4s;
    --duration-normal: 0.3s;
    --duration-fast: 0.2s;
    --duration-faster: 0.15s;
    --duration-fastest: 0.1s;
    --duration-default: .15s;
    
    /* Component-specific */
    --ya-fit-top: 0px;
    --ya-fit-left: 0px;
    --ya-fit-right: 0px;
    --ya-fit-bottom: 0px;
}
```

#### React (Tem typo ⚠️)

```css
:root {
    /* Animation Durations - TYPO: "durantion" */
    --durantion-slowest: 0.9s;  /* ❌ Corrigir para --duration-* */
    --durantion-slower: 0.6s;
    /* ... */
    
    /* Component-specific */
    --ya-fit-top: 0px;
    --ya-fit-left: 0px;
    --ya-fit-right: 0px;
    --ya-fit-bottom: 0px;
    --ya-stack-gap: 0.5rem;
}
```

**AÇÃO NECESSÁRIA**: Corrigir typo no React: `--durantion-*` → `--duration-*`

**Convenção de nomenclatura**:
- `--duration-*`: Durações de animação (nomenclatura correta)
- `--ya-*`: Variáveis específicas de componentes Yasamen
- `--{component}-*`: Variáveis de componente específico

---

## 5. Utilitários CSS

### Z-Index - PADRONIZAR ⚠️

Use esta hierarquia:

```css
@utility z-app-header {
    z-index: 1010;
}
@utility z-offcanvas-backdrop {
    z-index: 1020;
}
@utility z-offcanvas {
    z-index: 1030;
}
@utility z-backdrop {
    z-index: 1040;
}
@utility z-modal {
    z-index: 1050;
}
@utility z-notification {
    z-index: 1060;  /* Se tiver notificações */
}
```

**Regras**:
- ✅ Incrementos de 10
- ✅ Backdrop sempre abaixo do componente
- ✅ Notificações no topo (1060+)

---

### Transições - ESCOLHA UMA ABORDAGEM ⚠️

#### Opção A: Easing Suave (React)

```css
@utility transition-default {
    transition: all 0.25s cubic-bezier(.16,1,.3,1);
}
```

**Quando usar**: Interfaces modernas, animações suaves.

#### Opção B: Linear com Variável (Razor)

```css
@utility transition-default {
    transition: all var(--duration-normal) linear;
}
```

**Quando usar**: Transições simples, controle via variável.

**Recomendação**: Use Opção A (easing suave) para novos componentes.

---

### Fit Utilities - OBRIGATÓRIO ✅

```css
@utility fit-top-* {
    --ya-fit-top: --value(--spacing-*);
}
@utility fit-left-* {
    --ya-fit-left: --value(--spacing-*);
}
@utility fit-right-* {
    --ya-fit-right: --value(--spacing-*);
}
@utility fit-bottom-* {
    --ya-fit-bottom: --value(--spacing-*);
}
```

Usado para posicionamento de offcanvas e overlays.

---

## 6. Componentes CSS

### Convenções de Nomenclatura

```css
/* Componente base */
.ya-btn { /* ... */ }

/* Variantes de tema */
.ya-btn-primary { /* ... */ }
.ya-btn-secondary { /* ... */ }

/* Variantes de tamanho */
.ya-btn-sm { /* ... */ }
.ya-btn-md { /* ... */ }
.ya-btn-lg { /* ... */ }

/* Estados */
.ya-btn:hover { /* ... */ }
.ya-btn:active { /* ... */ }
.ya-btn:disabled { /* ... */ }

/* Modificadores */
.ya-btn-outline { /* ... */ }
.ya-btn-block { /* ... */ }
```

**Regras**:
- ✅ Prefixo `ya-` sempre
- ✅ Kebab-case para nomes
- ✅ Tema/tamanho como sufixo
- ✅ Estados via pseudo-classes
- ✅ Modificadores como classes separadas

---

### Estrutura de Arquivo de Componente

```css
/* components/btn.css */

/* Base */
.ya-btn {
    @apply inline-flex items-center justify-center;
    @apply rounded-md font-medium;
    @apply transition-default;
    @apply cursor-pointer;
    /* ... */
}

/* Temas */
.ya-btn-primary {
    @apply bg-primary text-white;
    @apply hover:bg-primary-600;
    /* ... */
}

.ya-btn-secondary {
    @apply bg-secondary text-white;
    @apply hover:bg-secondary-600;
    /* ... */
}

/* Tamanhos */
.ya-btn-sm {
    @apply px-3 py-1.5 text-sm;
}

.ya-btn-md {
    @apply px-4 py-2 text-base;
}

.ya-btn-lg {
    @apply px-6 py-3 text-lg;
}

/* Modificadores */
.ya-btn-outline {
    @apply bg-transparent border-2;
}

.ya-btn-block {
    @apply w-full;
}

/* Estados */
.ya-btn:disabled {
    @apply opacity-50 cursor-not-allowed;
}
```

---

## 7. Reboot CSS (Normalização)

### Ambos: OBRIGATÓRIO ✅

Ambos os projetos incluem `reboot.css` completo para normalização HTML.

**Estrutura**:
- Razor: `dotnet/Razor/RoyalCode.Razor.Styles/wwwroot/css/reboot.css`
- React: `js/react/yasamen/src/lib/styles/css/reboot.css`

**Elementos essenciais normalizados**:
- Body (margin, font, color, bg)
- Headings (h1-h6)
- Paragraphs, lists
- Forms (inputs, buttons, selects)
- Tables
- Links, images

### Diferença: Blazor Error Boundary

Apenas o Razor possui:

```css
.blazor-error-boundary {
    background: url(data:image/svg+xml;...) no-repeat 1rem/1.8rem, #b32121;
    padding: 1rem 1rem 1rem 3.7rem;
    color: white;
}

.blazor-error-boundary::after {
    content: "An error has occurred."
}
```

Classe específica para error boundaries do Blazor. React não precisa (usa error boundaries nativos).

---

## 8. Checklist para Novos Componentes

Ao criar um novo componente CSS:

### Planejamento
- [ ] Componente existe em ambos os projetos (Razor e React)?
- [ ] Qual a funcionalidade principal?
- [ ] Quais variantes de tema são necessárias?
- [ ] Quais tamanhos são necessários?
- [ ] Precisa de estados (hover, active, disabled)?

### Implementação
- [ ] Criar arquivo `components/{nome}.css`
- [ ] Usar prefixo `ya-{nome}`
- [ ] Implementar classe base
- [ ] Implementar variantes de tema (primary, secondary, etc)
- [ ] Implementar tamanhos (sm, md, lg)
- [ ] Implementar estados (hover, active, disabled)
- [ ] Usar variáveis CSS do @theme
- [ ] Usar utilitários Tailwind com @apply
- [ ] Adicionar transições suaves

### Testes
- [ ] Testar em todos os temas
- [ ] Testar em todos os tamanhos
- [ ] Testar estados interativos
- [ ] Testar responsividade
- [ ] Testar acessibilidade (contraste, foco)

### Documentação
- [ ] Adicionar ao yasamen.css (import)
- [ ] Documentar variantes disponíveis
- [ ] Criar exemplos de uso
- [ ] Atualizar análise comparativa (se aplicável)

---

## 9. Migração entre Projetos

### Razor → React

1. **Copiar arquivo CSS** de `dotnet/Razor/.../css/components/` para `js/react/.../css/components/`
2. **Ajustar espaçamento**: Remover meio-valores (0.5, 1.5, etc) se usar escala simples
3. **Ajustar z-index**: Verificar hierarquia de camadas
4. **Adicionar ao yasamen.css**: Import na ordem correta
5. **Testar**: Verificar se funciona com reboot.css do React

### React → Razor

1. **Copiar arquivo CSS** de `js/react/.../css/components/` para `dotnet/Razor/.../css/components/`
2. **Ajustar espaçamento**: Pode usar valores intermediários se necessário
3. **Ajustar z-index**: Verificar hierarquia de camadas
4. **Adicionar ao yasamen.css**: Import na ordem correta
5. **Testar**: Verificar se funciona sem reboot.css

---

## 10. Componentes Prioritários para Implementação

### React (Faltando)

1. **Badge** - Alta prioridade
   - Etiquetas/tags
   - Variantes de tema
   - Tamanhos
   - Com/sem ícone

2. **Notification/Toast** - Alta prioridade
   - Notificações temporárias
   - Timer automático
   - Posicionamento (top-right, etc)
   - Ícones temáticos

3. **Breadcrumbs** - Média prioridade
   - Navegação hierárquica
   - Separadores
   - Item ativo

4. **Dropdown/Menu** - Média prioridade
   - Menus suspensos
   - Posicionamento automático
   - Itens de menu

5. **Forms** - Baixa prioridade (se necessário)
   - TextField
   - FieldError
   - FieldGroup
   - InputField

### Razor (Faltando)

1. **Breakpoints** - Alta prioridade
   - Adicionar ao @theme
   - Documentar uso

2. **Corrigir imports** - Baixa prioridade (opcional)
   - Considerar mover variables/reboot/ripple para yasamen.css
   - Simplificar build process (remover gulp bundle se possível)

---

## 11. Boas Práticas

### DO ✅

- Use variáveis CSS do @theme
- Use utilitários Tailwind com @apply
- Prefixe componentes com `ya-`
- Implemente todos os temas (primary, secondary, etc)
- Adicione transições suaves
- Teste acessibilidade
- Documente variantes

### DON'T ❌

- Não use cores hex diretas (use variáveis)
- Não crie espaçamento customizado (use --spacing-*)
- Não ignore estados (hover, active, disabled)
- Não esqueça responsividade
- Não duplique código (use @apply)
- Não ignore z-index hierarchy

---

## 12. Recursos

### Documentação
- [Tailwind CSS v4](https://tailwindcss.com/docs)
- [CSS Variables (MDN)](https://developer.mozilla.org/en-US/docs/Web/CSS/Using_CSS_custom_properties)
- [Análise Comparativa](../analise-estilos-css-razor-react.md)

### Arquivos de Referência
- `dotnet/Razor/RoyalCode.Razor.Styles/wwwroot/yasamen.css`
- `js/react/yasamen/src/lib/styles/yasamen.css`

## 12. Recursos

### Documentação
- [Tailwind CSS v4](https://tailwindcss.com/docs)
- [CSS Variables (MDN)](https://developer.mozilla.org/en-US/docs/Web/CSS/Using_CSS_custom_properties)
- [Análise Comparativa](../analise-estilos-css-razor-react.md)

### Arquivos de Referência

**Razor**:
- `dotnet/Razor/RoyalCode.Razor.Styles/wwwroot/yasamen.css` (componentes)
- `dotnet/Razor/RoyalCode.Razor.Styles/wwwroot/styles.css` (fundação - bundled)
- `dotnet/Razor/RoyalCode.Razor.Styles/wwwroot/css/variables.css`
- `dotnet/Razor/RoyalCode.Razor.Styles/wwwroot/css/reboot.css`
- `dotnet/Razor/RoyalCode.Razor.Styles/wwwroot/css/ripple.css`

**React**:
- `js/react/yasamen/src/lib/styles/yasamen.css` (arquivo principal)
- `js/react/yasamen/src/lib/styles/css/variables.css`
- `js/react/yasamen/src/lib/styles/css/reboot.css`
- `js/react/yasamen/src/lib/styles/css/ripple.css`

### Correções Prioritárias

1. **React**: Corrigir typo `--durantion-*` → `--duration-*` em `variables.css`
2. **React**: Adicionar `--duration-default: .15s` para consistência
3. **Razor**: Adicionar breakpoints ao @theme

---

**Última Atualização**: Fevereiro de 2026
**Versão**: 1.1
