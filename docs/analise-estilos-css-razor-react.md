# Análise Comparativa: Estilos CSS - Razor vs React (Yasamen)

## Visão Geral

Ambos os projetos (Razor e React) utilizam **Tailwind CSS v4** como base para seus sistemas de design, compartilhando a mesma filosofia de design tokens e utilitários CSS. No entanto, existem diferenças importantes na estrutura, organização e componentes incluídos.

---

## 1. Estrutura de Arquivos

### Razor (`dotnet/Razor/RoyalCode.Razor.Styles/wwwroot/yasamen.css`)

```css
@import 'tailwindcss' source('../../../Razor');
@import './css/utilities.css';

/* Componentes */
@import './css/components/applayout.css';
@import './css/components/badge.css';
@import './css/components/breadcrumbs.css';
@import './css/components/btn.css';
@import './css/components/feedback.css';
@import './css/components/ibtn.css';
@import './css/components/menu.css';
@import './css/components/menuitem.css';
@import './css/components/modal.css';
@import './css/components/notification.css';
@import './css/components/offcanvas.css';
@import './css/components/sidebar.css';
@import './css/components/topbar.css';

/* Forms */
@import './css/forms/fieldbadge.css';
@import './css/forms/fielderror.css';
@import './css/forms/fieldgroup.css';
@import './css/forms/fieldtext.css';
@import './css/forms/inputfield.css';
@import './css/forms/controlgroup.css';

@theme { /* ... */ }
```

**Nota**: O Razor também possui um arquivo `styles.css` separado que é bundled com `yasamen.css`:

```css
/* styles.css - Bundled via gulpfile.js */
@import url(css/variables.css);
@import url(css/reboot.css);
@import url(css/ripple.css);
```

**Características**:
- 13 componentes CSS
- 6 componentes de formulário
- Tailwind com source específico para Razor
- ✅ **TEM reboot/reset CSS** (via `styles.css` bundled)
- ✅ **TEM variáveis CSS separadas** (via `styles.css` bundled)
- ✅ **TEM ripple CSS separado** (via `styles.css` bundled)
- Build process: Gulp bundle de `styles.css` + `yasamen.css`

---

### React (`js/react/yasamen/src/lib/styles/yasamen.css`)

```css
/* Fundação */
@import './css/variables.css';
@import './css/ripple.css';
@import './css/reboot.css';

/* Tailwind */
@import 'tailwindcss';

/* Utilitários */
@import './css/utilities.css';

/* Componentes */
@import './css/components/app-layout.css';
@import './css/components/bar.css';
@import './css/components/btn.css';
@import './css/components/ibtn.css';
@import './css/components/modal.css';
@import './css/components/offcanvas.css';
@import './css/components/stack.css';

@theme { /* ... */ }
```

**Características**:
- 7 componentes CSS
- Reboot CSS completo (normalização HTML)
- Variáveis CSS separadas
- Ripple CSS separado
- Sem componentes de formulário
- Sem componentes de menu/navegação

---

## 2. Componentes CSS Presentes

### Componentes em Ambos ✅

| Componente | Razor | React | Observações |
|------------|-------|-------|-------------|
| **App Layout** | `applayout.css` | `app-layout.css` | Layouts de aplicação |
| **Button** | `btn.css` | `btn.css` | Botões padrão |
| **Icon Button** | `ibtn.css` | `ibtn.css` | Botões de ícone |
| **Modal** | `modal.css` | `modal.css` | Modais/diálogos |
| **OffCanvas** | `offcanvas.css` | `offcanvas.css` | Painéis laterais |

---

### Componentes Exclusivos do Razor ❌

| Componente | Arquivo | Descrição |
|------------|---------|-----------|
| **Badge** | `badge.css` | Badges/etiquetas |
| **Breadcrumbs** | `breadcrumbs.css` | Navegação breadcrumb |
| **Feedback** | `feedback.css` | Componente de feedback |
| **Menu** | `menu.css` | Menus dropdown |
| **MenuItem** | `menuitem.css` | Itens de menu |
| **Notification** | `notification.css` | Notificações toast |
| **Sidebar** | `sidebar.css` | Barra lateral |
| **TopBar** | `topbar.css` | Barra superior |
| **FieldBadge** | `forms/fieldbadge.css` | Badge em campos |
| **FieldError** | `forms/fielderror.css` | Erros de campo |
| **FieldGroup** | `forms/fieldgroup.css` | Grupo de campos |
| **FieldText** | `forms/fieldtext.css` | Campo de texto |
| **InputField** | `forms/inputfield.css` | Input genérico |
| **ControlGroup** | `forms/controlgroup.css` | Grupo de controles |

**Total**: 14 componentes exclusivos

---

### Componentes Exclusivos do React ❌

| Componente | Arquivo | Descrição |
|------------|---------|-----------|
| **Bar** | `bar.css` | Barra horizontal com slots |
| **Stack** | `stack.css` | Layout empilhado |

**Total**: 2 componentes exclusivos

**Nota**: Ripple, Reboot e Variables existem em ambos os projetos, mas com estruturas diferentes.

---

## 3. Design Tokens (@theme)

### Cores - Idênticas ✅

Ambos compartilham exatamente as mesmas cores:

```css
--color-primary: #0d6dfd;
--color-secondary: #6c757d;
--color-tertiary: #7c3aed;
--color-info: #7db8f0;
--color-highlight: #4169E1;
--color-success: #10b981;
--color-warning: #fbbf24;
--color-alert: #f97316;
--color-danger: #DC3545;
--color-light: #F2F1F3;
--color-dark: #38333c;
```

Cada cor tem 9 variações (100-900) idênticas em ambos os projetos.

---

### Tipografia - Idêntica ✅

```css
--font-sans: system-ui, -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, ...
--font-serif: "Georgia", "Times New Roman", Times, serif;
--font-mono: SFMono-Regular, Consolas, "Liberation Mono", Menlo, monospace;

--text-4xs: 0.5rem;
--text-3xs: 0.5625rem;
--text-2xs: 0.625rem;
```

---

### Espaçamento - DIFERENTE ⚠️

#### Razor (mais granular)
```css
--spacing-0: 0;
--spacing-0\.5: .03125rem;    /* 0.5px */
--spacing-1: .0625rem;         /* 1px */
--spacing-1\.5: .09375rem;     /* 1.5px */
--spacing-2: .125rem;          /* 2px */
--spacing-2\.5: .1875rem;      /* 3px */
--spacing-3: .25rem;           /* 4px */
--spacing-3\.5: .375rem;       /* 6px */
--spacing-4: .5rem;            /* 8px */
--spacing-4\.5: 0.625rem;      /* 10px */
--spacing-5: 0.75rem;          /* 12px */
--spacing-5\.5: 0.875rem;      /* 14px */
--spacing-6: 1rem;             /* 16px */
--spacing-6\.5: 1.25rem;       /* 20px */
--spacing-7: 1.5rem;           /* 24px */
--spacing-7\.5: 1.75rem;       /* 28px */
--spacing-8: 2rem;             /* 32px */
--spacing-8\.5: 2.5rem;        /* 40px */
--spacing-9: 3rem;             /* 48px */
--spacing-9\.5: 3.5rem;        /* 56px */
--spacing-10: 4rem;            /* 64px */
--spacing-10\.5: 4.5rem;       /* 72px */
--spacing-11: 5rem;            /* 80px */
--spacing-11\.5: 5.5rem;       /* 88px */
--spacing-12: 6rem;            /* 96px */
--spacing-12\.5: 7rem;         /* 112px */
--spacing-13: 8rem;            /* 128px */
--spacing-13\.5: 10rem;        /* 160px */
--spacing-14: 12rem;           /* 192px */
--spacing-14\.5: 14rem;        /* 224px */
--spacing-15: 16rem;           /* 256px */
--spacing-15\.5: 24rem;        /* 384px */
--spacing-16: 32rem;           /* 512px */
```

**Total**: 33 valores de espaçamento (incluindo meio-valores)

#### React (mais simples)
```css
--spacing-0: 0;
--spacing-1: .0625rem;    /* 1px */
--spacing-2: .125rem;     /* 2px */
--spacing-3: .25rem;      /* 4px */
--spacing-4: .5rem;       /* 8px */
--spacing-5: 0.75rem;     /* 12px */
--spacing-6: 1rem;        /* 16px */
--spacing-7: 1.5rem;      /* 24px */
--spacing-8: 2rem;        /* 32px */
--spacing-9: 3rem;        /* 48px */
--spacing-10: 4rem;       /* 64px */
--spacing-11: 5rem;       /* 80px */
--spacing-12: 6rem;       /* 96px */
--spacing-13: 8rem;       /* 128px */
--spacing-14: 12rem;      /* 192px */
--spacing-15: 16rem;      /* 256px */
--spacing-16: 32rem;      /* 512px */
```

**Total**: 17 valores de espaçamento (sem meio-valores)

**Diferença**: Razor tem **16 valores adicionais** de espaçamento intermediário (0.5, 1.5, 2.5, etc).

---

### Line Height - Idêntico ✅

```css
--leading-none: 1;
--leading-xs: 1.125;
--leading-sm: 1.25;
--leading-base: 1.5;
--leading-lg: 1.75;
--leading-xl: 2;
```

---

### Breakpoints - DIFERENTE ⚠️

#### Razor
❌ **Não define breakpoints** no @theme

#### React
✅ **Define breakpoints** explicitamente:
```css
--breakpoint-xs: 30rem;  /* 480px */
--breakpoint-sm: 40rem;  /* 640px */
--breakpoint-md: 48rem;  /* 768px */
--breakpoint-lg: 64rem;  /* 1024px */
--breakpoint-xl: 80rem;  /* 1280px */
--breakpoint-2xl: 96rem; /* 1536px */
```

---

### Variações de Light - DIFERENTE ⚠️

#### Razor
✅ **Define variações extras** de light:
```css
--color-light-10: #fbfafc;
--color-light-25: #f9f8fa;
--color-light-50: #f6f4f8;
--color-light-100: #f2f1f3;
/* ... 200-900 */
```

#### React
❌ **Não define** light-10, light-25, light-50

---

## 4. Utilitários CSS

### Z-Index - DIFERENTE ⚠️

#### Razor
```css
@utility z-app-bar { z-index: 1010; }
@utility z-offcanvas-backdrop { z-index: 1020; }
@utility z-offcanvas { z-index: 1030; }
@utility z-offcanvas-overlay-backdrop { z-index: 1040; }
@utility z-offcanvas-overlay { z-index: 1050; }
@utility z-backdrop { z-index: 1060; }
@utility z-modal { z-index: 1070; }
@utility z-notification { z-index: 1090; }
```

**Total**: 8 níveis de z-index

#### React
```css
@utility z-app-header { z-index: 1010; }
@utility z-offcanvas-backdrop { z-index: 1020; }
@utility z-offcanvas { z-index: 1030; }
@utility z-backdrop { z-index: 1040; }
@utility z-modal { z-index: 1050; }
```

**Total**: 5 níveis de z-index

**Diferenças**:
- Razor: `z-app-bar` vs React: `z-app-header`
- Razor tem: `z-offcanvas-overlay-backdrop`, `z-offcanvas-overlay`, `z-notification`
- React não tem notificações (z-index 1090)

---

### Transições - DIFERENTE ⚠️

#### Razor
```css
@utility transition-default {
    transition: all var(--duration-default) linear;
}
```
Usa variável CSS `--duration-default` (não definida no @theme, provavelmente em outro arquivo)

#### React
```css
@utility transition-default {
    transition: all 0.25s cubic-bezier(.16,1,.3,1);
    /* transition: all 0.75s linear; */ /* comentado */
}
```
Usa valor fixo com easing `cubic-bezier(.16,1,.3,1)` (easing suave)

**Diferença**: React usa easing mais sofisticado, Razor usa linear.

---

### Fit Utilities - Idêntico ✅

Ambos definem utilitários de "fit" para posicionamento:

```css
@utility fit-top-* { --ya-fit-top: --value(--spacing-*); }
@utility fit-left-* { --ya-fit-left: --value(--spacing-*); }
@utility fit-right-* { --ya-fit-right: --value(--spacing-*); }
@utility fit-bottom-* { --ya-fit-bottom: --value(--spacing-*); }
```

---

## 5. Variáveis CSS Customizadas

Ambos os projetos definem variáveis customizadas em arquivos `variables.css` separados.

### Razor (`css/variables.css`)

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
    --duration-default: .15s;  /* ⚠️ Extra no Razor */
    
    /* Fit for aside offcanvas */
    --ya-fit-top: 0px;
    --ya-fit-left: 0px;
    --ya-fit-right: 0px;
    --ya-fit-bottom: 0px;
}
```

### React (`css/variables.css`)

```css
:root {
    /* Animation Durations */
    --durantion-slowest: 0.9s;  /* ⚠️ Typo: "durantion" */
    --durantion-slower: 0.6s;
    --durantion-slow: 0.4s;
    --durantion-normal: 0.3s;
    --durantion-fast: 0.2s;
    --durantion-faster: 0.15s;
    --durantion-fastest: 0.1s;
    
    /* Fit for aside offcanvas */
    --ya-fit-top: 0px;
    --ya-fit-left: 0px;
    --ya-fit-right: 0px;
    --ya-fit-bottom: 0px;
    
    /* Gap for stack component */
    --ya-stack-gap: 0.5rem;  /* ⚠️ Extra no React */
}
```

### Diferenças

| Variável | Razor | React | Observação |
|----------|-------|-------|------------|
| **Nomenclatura** | `--duration-*` | `--durantion-*` | ⚠️ React tem typo |
| **duration-default** | ✅ `.15s` | ❌ Não tem | Razor tem extra |
| **ya-stack-gap** | ❌ Não tem | ✅ `0.5rem` | React tem extra |

**Recomendação**: Corrigir typo no React (`durantion` → `duration`) e padronizar variáveis.

---

## 6. Reboot CSS (Normalização HTML)

Ambos os projetos incluem um **reboot.css completo** para normalização HTML.

### Estrutura Idêntica ✅

Tanto Razor quanto React possuem `css/reboot.css` com estilos para:

- Body, HTML, root
- Headings (h1-h6)
- Paragraphs, lists, blockquotes
- Forms (inputs, buttons, selects, textareas)
- Tables
- Code, pre, kbd
- Links, images, SVG
- E muito mais...

### Diferenças Mínimas ⚠️

#### Razor - Adicional

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

Classe específica para error boundaries do Blazor.

#### React

Não possui classe de error boundary (usa error boundaries do React nativamente).

### Conclusão

Os arquivos `reboot.css` são **praticamente idênticos** entre Razor e React, com apenas a adição da classe `.blazor-error-boundary` no Razor.

---

## 7. Resumo das Diferenças

### Estrutura

| Aspecto | Razor | React |
|---------|-------|-------|
| **Componentes CSS** | 19 arquivos | 7 arquivos |
| **Reboot/Reset** | ✅ Completo (via bundle) | ✅ Completo |
| **Variáveis separadas** | ✅ Sim (via bundle) | ✅ Sim |
| **Ripple separado** | ✅ Sim (via bundle) | ✅ Sim |
| **Build Process** | Gulp bundle | Import direto |

---

### Design Tokens

| Token | Razor | React | Status |
|-------|-------|-------|--------|
| **Cores** | 11 temas × 9 variações | 11 temas × 9 variações | ✅ Idêntico |
| **Espaçamento** | 33 valores | 17 valores | ⚠️ Razor mais granular |
| **Tipografia** | 3 famílias + tamanhos | 3 famílias + tamanhos | ✅ Idêntico |
| **Line Height** | 6 valores | 6 valores | ✅ Idêntico |
| **Breakpoints** | ❌ Não definido | ✅ 6 breakpoints | ⚠️ React tem |
| **Light extras** | ✅ 10, 25, 50 | ❌ Não tem | ⚠️ Razor tem |

---

### Utilitários

| Utilitário | Razor | React | Diferença |
|------------|-------|-------|-----------|
| **Z-index** | 8 níveis | 5 níveis | Razor: +3 (overlay, notification) |
| **Transições** | Linear + variável | Cubic-bezier fixo | React: easing suave |
| **Fit** | ✅ | ✅ | Idêntico |

---

### Componentes

| Categoria | Razor | React | Diferença |
|-----------|-------|-------|-----------|
| **Básicos** | 5 | 5 | Equivalente |
| **Navegação** | 4 (menu, breadcrumb, sidebar, topbar) | 2 (bar, stack) | Razor: +2 |
| **Alertas** | 3 (badge, feedback, notification) | 0 | Razor: +3 |
| **Forms** | 6 | 0 | Razor: +6 |

---

## 8. Recomendações

### Para o Projeto Razor

1. ~~**Adicionar reboot.css**~~: ✅ Já existe (via `styles.css` bundle)
2. ~~**Separar variáveis**~~: ✅ Já existe (via `styles.css` bundle)
3. **Definir breakpoints**: Adicionar breakpoints no @theme
4. **Documentar espaçamento**: Justificar os 33 valores vs 17
5. **Corrigir nomenclatura**: Padronizar `--duration-*` (já correto no Razor)

### Para o Projeto React

1. **Corrigir typo**: `--durantion-*` → `--duration-*` em `variables.css`

2. **Adicionar componentes faltantes**:
   - Badge CSS
   - Notification/Toast CSS
   - Breadcrumbs CSS
   - Menu/Dropdown CSS
   - Sidebar/TopBar CSS (se necessário)
   - Forms CSS (TextField, ErrorMessage, etc)

3. **Considerar espaçamento intermediário**: Avaliar se meio-valores (0.5, 1.5, etc) são necessários

4. **Adicionar z-index para notificações**: Se implementar sistema de toast

5. **Adicionar variações light extras**: Se necessário (10, 25, 50)

6. **Adicionar `--duration-default`**: Para consistência com Razor

---

## 9. Compatibilidade

### Migração Razor → React

Para migrar estilos do Razor para React:

1. ✅ **Cores**: Compatível 100%
2. ⚠️ **Espaçamento**: Ajustar valores intermediários (0.5, 1.5, etc)
3. ⚠️ **Z-index**: Ajustar camadas de overlay e notification
4. ❌ **Componentes**: Criar CSS para badge, notification, breadcrumbs, forms

### Migração React → Razor

Para migrar estilos do React para Razor:

1. ✅ **Cores**: Compatível 100%
2. ✅ **Espaçamento**: Razor tem todos os valores do React + extras
3. ⚠️ **Breakpoints**: Adicionar ao @theme do Razor
4. ⚠️ **Reboot**: Adicionar normalização HTML
5. ⚠️ **Variáveis**: Adicionar durações de animação

---

## 10. Conclusão

### Pontos Fortes do Razor

1. **Mais completo**: 19 componentes CSS vs 7
2. **Espaçamento granular**: 33 valores para controle fino
3. **Componentes de formulário**: Sistema completo de forms
4. **Navegação**: Menu, breadcrumbs, sidebar, topbar
5. **Alertas**: Badge, feedback, notification
6. **Build otimizado**: Gulp bundle para produção
7. **Nomenclatura correta**: `--duration-*` sem typos

### Pontos Fortes do React

1. **Import direto**: Sem necessidade de build process
2. **Breakpoints definidos**: Responsividade explícita
3. **Easing suave**: Transições com cubic-bezier
4. **Mais leve**: Menos CSS para carregar (7 vs 19 componentes)
5. **Variável extra**: `--ya-stack-gap` para componente Stack

### Filosofia Compartilhada

Ambos os projetos:
- ✅ Usam Tailwind CSS v4
- ✅ Compartilham design tokens (cores, tipografia)
- ✅ Seguem convenção de nomenclatura `ya-*`
- ✅ Usam variáveis CSS customizadas (`variables.css`)
- ✅ Implementam reboot CSS completo (`reboot.css`)
- ✅ Implementam ripple effect separado (`ripple.css`)
- ✅ Implementam utilitários consistentes
- ✅ Estrutura de arquivos similar (apesar do bundle no Razor)

---

## 11. Issues Encontrados

### React: Typo em variables.css ⚠️

**Problema**: Nomenclatura incorreta de variáveis de duração.

```css
/* ❌ Incorreto (React atual) */
--durantion-slowest: 0.9s;
--durantion-slower: 0.6s;
--durantion-slow: 0.4s;
--durantion-normal: 0.3s;
--durantion-fast: 0.2s;
--durantion-faster: 0.15s;
--durantion-fastest: 0.1s;

/* ✅ Correto (Razor) */
--duration-slowest: 0.9s;
--duration-slower: 0.6s;
--duration-slow: 0.4s;
--duration-normal: 0.3s;
--duration-fast: 0.2s;
--duration-faster: 0.15s;
--duration-fastest: 0.1s;
--duration-default: .15s;
```

**Impacto**: 
- Inconsistência entre projetos
- Possível confusão ao migrar código
- Nomenclatura não semântica

**Ação Recomendada**:
1. Corrigir `--durantion-*` → `--duration-*` em `js/react/yasamen/src/lib/styles/css/variables.css`
2. Adicionar `--duration-default: .15s` para consistência com Razor
3. Verificar se algum CSS usa essas variáveis e atualizar referências

### React: Falta duration-default

**Problema**: Razor tem `--duration-default: .15s`, React não tem.

**Ação Recomendada**: Adicionar ao React para consistência.

### Razor: Faltam Breakpoints

**Problema**: React define breakpoints no @theme, Razor não.

**Ação Recomendada**: Adicionar breakpoints ao @theme do Razor:

```css
@theme {
    --breakpoint-xs: 30rem;
    --breakpoint-sm: 40rem;
    --breakpoint-md: 48rem;
    --breakpoint-lg: 64rem;
    --breakpoint-xl: 80rem;
    --breakpoint-2xl: 96rem;
    /* ... resto do theme */
}
```

---

**Data da Análise**: Fevereiro de 2026
**Versões**: Tailwind CSS v4 (ambos)
