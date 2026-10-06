# Perfis de componentes

Catálogo de perfis e características-base para levantamento e caracterização de componentes em `js/react/yasamen/`.

## Perfis

| Perfil | Exemplos | Propósito |
|---|---|---|
| Ação | Button, IconButton, Ripple | Disparar comando, navegação ou ação imediata |
| Overlay | Modal, Offcanvas, Dialog, Toast | Conteúdo temporário sobreposto à tela |
| Layout | Bar, Stack, Container, Cols, AppLayout | Estrutura espacial, alinhamento e fluxo visual |
| Entrada | TextField, CheckBox, Select, Switch | Captura e edição de dados pelo usuário |
| Exibição | Badge, Icon, Avatar, Tag | Exibição estática de estado, indicador ou dado |
| Navegação | Breadcrumb, Pagination, Menu, Tabs | Condução do usuário entre rotas ou visões |
| Feedback | Alert, Spinner, ProgressBar, Status | Comunicação de resposta do sistema ou espera |
| Coleção | ListGroup, Table, CardGroup | Agrupamento estruturado de itens repetidos |

## Características-base por perfil

### 1. Ação
- **Estados:** default, hover, active, focus-visible, disabled, loading.
- **Variações:** `theme` (`Themes`), `size` (`Sizes`), fullWidth, variant (solid, outline, ghost).
- **Interação:** clique, tecla Enter, tecla Espaço, suporte a `Ripple`.
- **Navegação:** prop `navigateTo` integrada ao `getNavigator()`.
- **Acessibilidade:** elemento nativo `<button>` ou `<a>`, `aria-disabled`, `aria-busy`.

### 2. Overlay
- **Estados:** closed, opening, opened, closing.
- **Variações:** placement (left, right, top, bottom, center), backdrop (dim, transparent, none), tamanho.
- **Interação:** abrir via prop ou gatilho, fechar via backdrop, fechar via tecla Esc, botão fechar.
- **Foco e rolagem:** focus trap enquanto aberto, restauração de foco ao fechar, bloqueio de scroll do body.
- **Acessibilidade:** `role="dialog"` ou `role="alertdialog"`, `aria-modal="true"`, `aria-labelledby`, `aria-describedby`.

### 3. Layout
- **Estados:** responsivo por breakpoint (`sm`, `md`, `lg`, `xl`, `2xl`).
- **Variações:** orientação (horizontal, vertical), gap, alinhamento, wrap, preenchimento.
- **Slots:** composição flexível de `children` ou slots nomeados (`header`, `body`, `footer`).
- **Acessibilidade:** landmarks semânticos (`<header>`, `<nav>`, `<aside>`, `<main>`, `role="toolbar"`).

### 4. Entrada
- **Estados:** default, focus, valid, invalid, disabled, readonly, placeholder.
- **Variações:** `size`, com ícone inicial/final, prefixo/sufixo, texto de ajuda, mensagem de erro.
- **Interação:** digitação, foco por teclado (Tab), seleção, atalhos de formulário.
- **Acessibilidade:** associação explícita com `<label>` por `id`/`htmlFor`, `aria-invalid`, `aria-describedby`, `aria-required`.

### 5. Exibição
- **Estados:** default, oculto, ativo/selecionado.
- **Variações:** `theme`, `size`, formato (pílula, circular, quadrado), com ícone/texto.
- **Acessibilidade:** texto alternativo quando portar informação, `aria-hidden="true"` quando puramente decorativo.

### 6. Navegação
- **Estados:** item atual (`active`/`current`), hover, foco, desabilitado.
- **Variações:** `size`, orientação, densidade.
- **Interação:** navegação por teclado (setas, Tab, Home, End), cliques integrados ao `navigateTo`.
- **Acessibilidade:** `role="navigation"`, `aria-current="page"` ou `"step"`, rótulo semântico `aria-label`.

### 7. Feedback
- **Estados:** aparecendo, visível, fechando, permanente vs temporário (auto-dismiss).
- **Variações:** severidade (`theme`: success, danger, warning, info), com ícone, com ação fechar.
- **Acessibilidade:** `role="alert"` ou `role="status"`, `aria-live="polite"` ou `"assertive"`.

### 8. Coleção
- **Estados:** vazia, carregando, com itens, item selecionado.
- **Variações:** densidade, separador, zebra/listrado, selecionável.
- **Acessibilidade:** semântica de lista (`<ul>`/`<li>`) ou tabela (`<table>`), navegação entre itens por teclado.

## Adaptações ao projeto Yasamen

Regras que a IA deve seguir estritamente:
- Mapear variações visuais sempre para os tipos centrais `Themes` e `Sizes` da biblioteca.
- Utilizar `navigateTo` para qualquer componente que suporte ação com rota.
- Incluir suporte a `Ripple` para qualquer componente interativo do perfil Ação.
- Seguir o padrão de slots declarativos (`children` ou interfaces de layout) em vez de clonagem de elementos.
- Respeitar a paridade de nomes e capacidades com o equivalente em `dotnet/Razor`.
