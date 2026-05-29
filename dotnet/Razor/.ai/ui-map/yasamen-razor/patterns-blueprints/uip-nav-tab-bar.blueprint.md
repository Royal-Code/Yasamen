# UIP-NAV-TAB_BAR - Blueprint resumido

## Pattern

UIP-NAV-TAB_BAR — Tab Bar — ver `uip-nav-tab-bar.ui-map.md`

## Gap coberto

A lib usa `AppSideBar` como navigation rail para desktop/web, mas não tem barra de navegação inferior (bottom tab bar) nativa. O gap é orientar o uso do `AppSideBar` como rail compacto de ícones para desktop e a alternativa de barra inferior CSS para mobile web.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `AppSideBar` com `AppSideItem` cobre navigation rail para desktop; barra inferior mobile é CSS manual com `fixed bottom-0` sem componente dedicado.

## Componentes usados

- `AppSideBar` — papel: principal (rail de desktop) — ver `app-layout.sample.md`
- `AppSideItem` — papel: composição (item do rail) — ver `app-layout.sample.md`
- `Badge` — papel: composição (contador de notificações) — ver `badge.sample.md`

## Recursos visuais

- `fixed bottom-0 left-0 right-0` — posicionamento da barra inferior
- `z-50` — acima do conteúdo
- `safe-area-inset-bottom` — padding para notch em mobile (via CSS env())

## Receita

Para desktop/web: `AppSideBar` em modo rail (sem labels); para mobile web: barra `fixed bottom-0` com `NavLink` + ícones.

```razor
@* Navigation rail via AppSideBar — desktop *@
<AppLayout>
    <AppSideBar>
        <AppSideItem Icon="WellKnownIcons.Home" Label="Início"
                     Href="/" Match="NavLinkMatch.All" />
        <AppSideItem Icon="WellKnownIcons.Search" Label="Buscar"
                     Href="/busca" />
        <AppSideItem Icon="WellKnownIcons.Bell" Label="Notificações"
                     Href="/notificacoes" BadgeCount="3" />
        <AppSideItem Icon="WellKnownIcons.User" Label="Perfil"
                     Href="/perfil" />
    </AppSideBar>
    @Body
</AppLayout>

@* Bottom tab bar — mobile web *@
@* Adicionar padding-bottom no conteúdo principal para compensar a barra *@
<div class="pb-16 lg:pb-0">
    @Body
</div>

<nav class="fixed bottom-0 left-0 right-0 z-50 bg-white border-t border-light-200
            flex lg:hidden"
     style="padding-bottom: env(safe-area-inset-bottom)">
    @foreach (var tab in new[] {
        (WellKnownIcons.Home, "Início", "/"),
        (WellKnownIcons.Search, "Buscar", "/busca"),
        (WellKnownIcons.Bell, "Avisos", "/notificacoes"),
        (WellKnownIcons.User, "Perfil", "/perfil"),
    })
    {
        <NavLink href="@tab.Item3"
                 class="flex-1 flex flex-col items-center justify-center py-2 text-dark-400
                        hover:text-primary-600 transition-colors gap-0.5"
                 ActiveClass="text-primary-600"
                 Match="@(tab.Item3 == "/" ? NavLinkMatch.All : NavLinkMatch.Prefix)">
            <Icon Kind="@tab.Item1" />
            <span class="text-xs">@tab.Item2</span>
        </NavLink>
    }
</nav>
```

## Limites

- Badge de contagem sobre ícone na barra inferior requer posicionamento `relative/absolute` manual — `AppSideItem.BadgeCount` pode não existir no contexto de bottom bar;
- `AppSideBar` como rail de ícones sem labels pode requerer configuração específica de largura no componente.
