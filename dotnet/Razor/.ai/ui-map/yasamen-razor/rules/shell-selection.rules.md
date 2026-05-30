# Seleção de Shell — yasamen-razor

## Quando aplicar

Ao definir o layout raiz de uma aplicação ou de uma área da aplicação.

## Regras

### Use AppLayout quando

O shell é um painel operacional estilo admin/workspace com:
- sidebar de navegação permanente (`AppSideBar` com `NavLink` e `AppMenu`);
- topbar com branding, busca global e ações de usuário (`AppTopBar`);
- conteúdo principal paginado ou em abas.

Exemplos: painel administrativo, dashboard operacional, backoffice, gerenciador de conteúdo.

```razor
@* Layout de admin — usa AppLayout *@
@inherits LayoutComponentBase

<AppLayout>
    <AppSideBar>
        @* NavLink, AppMenu *@
    </AppSideBar>
    <AppTopBar>
        @* Branding, busca, usuário *@
    </AppTopBar>
    @Body
</AppLayout>
```

### Nunca use AppLayout quando

O shell NÃO é painel operacional. Nestes casos, usar HTML semântico (`<header>`, `<main>`, `<footer>`) com `Bar` e componentes da lib:

| Tipo de shell | Por que não usar AppLayout |
|---|---|
| **Portal público** | Header leve + nav desktop; AppLayout adiciona sidebar de admin incompatível |
| **Media / Catálogo** | Header com categorias; sem sidebar; catálogo em grade central |
| **Kiosk / Embedded** | Full-screen sem chrome; AppLayout adiciona estrutura de app operacional |
| **Studio / Workbench** | Multi-painel CSS customizado; tema escuro; sem sidebar de admin |
| **Communication** (chat) | Split inbox+thread; `w-16` workspace strip; AppLayout não cobre esse layout |
| **Commerce** | Header de loja + carrinho em OffCanvas; sem sidebar de navegação de admin |

```razor
@* Layout de portal — NÃO usa AppLayout *@
@inherits LayoutComponentBase

<header class="sticky top-0 z-10 bg-white border-b border-light-200">
    <Bar AdditionalClasses="max-w-6xl mx-auto px-4 py-3">
        @* Logo + nav desktop + menu mobile *@
    </Bar>
</header>

<main>
    @Body
</main>

<footer>
    @* Footer editorial *@
</footer>

@* Outlets manuais — ver bootstrap.rules.md *@
<ModalOutlet />
<OffCanvasOutlet />
<NotificationOutlet />
```

### Shells sem AppLayout — outlets obrigatórios

Qualquer shell que não usa `AppLayout` **deve** incluir os outlets manualmente. Ver `bootstrap.rules.md` seção "Outlets — Sem AppLayout".

## Anti-padrões

- Adicionar `AppLayout` a uma landing page pública: resulta em sidebar de admin visível no portal.
- Remover `AppSideBar` do `AppLayout` esperando que o layout funcione sem sidebar: `AppLayout` foi projetado para o par completo — sem `AppSideBar`, o layout fica incompleto.
- Usar `AppLayout` como wrapper genérico para "qualquer coisa que precise de header": criar um shell customizado simples com `<header>` + `Bar` é mais correto e mais leve.
