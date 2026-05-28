# UIP-NAV-TAB_BAR - Tab Bar

**GAP parcial — sem componente dedicado de Tab Bar**

Tab Bar é primariamente um padrão mobile nativo. Para Web, `AppSideBar` cobre uma variante de navegação de destinos raiz como sidebar de ícones, mas não como barra inferior fixa.

## Componentes

**Principais**:

1. AppSideBar (variante sidebar de ícones)
- `cobertura`: sidebar fixa com ícones de destinos principais (`AppSideItem`); estado ativo via `Active`; `Href` para navegação por rota; equivalente a "navigation rail" em desktop/web; posicionada lateralmente, não na base;
- `limitações`: sidebar vertical, não barra inferior; sem posição "bottom" nativa; sem badge por item; sem estado de scroll-to-hide; layout fixo na esquerda;
- `nota`: 5;
- `justificativa`: cobre o papel de destinos raiz com ícones mas em sidebar vertical, não em barra inferior.

**Composição**:

1. AppSideItem
- `cobertura`: item de destino com ícone, href e estado ativo;
- `nota`: 7;
- `justificativa`: item de navegação raiz com semântica correta.

**Descartados**: nenhum.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `barra fixa na base (mobile)`: não existe — implementar com CSS `fixed bottom-0` + ícones HTML nativo;
  - `badge por destino`: não nativo no AppSideItem — adicionar Badge como filho via HTML;
  - `3-5 destinos raiz em barra inferior (mobile web)`: implementar customizado com classes Tailwind.

- `tipo de adaptação`: composição + estilos (para web), nova implementação (para mobile web com barra inferior)
- `o que precisa ser feito`:
  - Para desktop/web: usar `AppSideBar` + `AppSideItem` — cobre o papel de destinos raiz como navigation rail;
  - Para mobile web com barra inferior: implementar com `<nav class="fixed bottom-0 left-0 right-0 bg-white border-t ...">` + ícones HTML.

## Como usar

### Navigation rail com AppSideBar (web/desktop)

```razor
<AppSideBar>
    <AppSideItem Icon="WellKnownIcons.Home" Href="/" Label="Início" />
    <AppSideItem Icon="WellKnownIcons.Users" Href="/usuarios" Label="Usuários" />
    <AppSideItem Icon="WellKnownIcons.Chart" Href="/relatorios" Label="Relatórios" />
    <AppSideItem Icon="WellKnownIcons.Settings" Href="/config" Label="Config." />
</AppSideBar>
```

### Barra inferior mobile (implementação manual)

```razor
@* CSS fixed bottom — não usa componentes da biblioteca *@
<nav class="fixed bottom-0 left-0 right-0 bg-white border-t border-light-200 
            flex justify-around items-center py-2 md:hidden z-app-bar">
    <a href="/" class="flex flex-col items-center gap-1 text-xs text-dark-600">
        @WellKnownIcons.Home("text-xl")
        <span>Início</span>
    </a>
    <a href="/usuarios" class="flex flex-col items-center gap-1 text-xs text-dark-600">
        @WellKnownIcons.Users("text-xl")
        <span>Usuários</span>
    </a>
</nav>
```

## Decisão de uso

- `nota geral`: 5;
- `limitações`: sem componente de barra inferior nativa; AppSideBar cobre navigation rail (sidebar de ícones) — adequado para web/desktop mas não para mobile com barra inferior; badge por item não é nativo;
- `recomendação`: `usar com adaptação`
- `justificativa geral`:
  - `AppSideBar` + `AppSideItem` cobrem bem o papel de destinos raiz em web/desktop como navigation rail;
  - Para mobile web com barra inferior fixa, implementação manual com HTML + Tailwind é necessária;
  - Nota 5 reflete cobertura parcial — sidebar de ícones funciona como alternativa web, mas barra inferior mobile requer implementação customizada.
