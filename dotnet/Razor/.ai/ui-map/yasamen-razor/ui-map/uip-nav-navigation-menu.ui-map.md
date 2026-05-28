# UIP-NAV-NAVIGATION_MENU - Navigation Menu

## Componentes

**Principais**:

1. AppMenu
- `cobertura`: menu de navegação principal via OffCanvas lateral — abre com `AppSideMenuButton`; carrega itens de `MenuService` na primeira abertura; suporta `AppMenuList` + `AppMenuItem`; propagação de `AppMenuContext` via CascadingValue; título configurável; menu persistente durante a sessão via OffCanvas;
- `limitações`: aberto via OffCanvas — não é sidebar persistente visível; requer DI completo (`AddYasamenMenu`, `AddYasamenOffCanvas`); sem suporte nativo a submenu multinível; sem badge/contador por item de menu; itens definidos via MenuService (não em markup direto por padrão);
- `nota`: 8;
- `justificativa`: cobertura alta para menu de navegação global — padrão da biblioteca é OffCanvas + sidebar de ícones; falta sidebar persistente expandida e submenu multinível.

2. AppSideBar
- `cobertura`: sidebar estreita de ícones com `AppSideItem`; fixa e persistente; `Active` via estado da rota; ícone + label (label acessível); cada item é link de navegação (`Href`);
- `limitações`: apenas ícones — sem label visível (tooltip ou label pode ser configurado); sem hierarquia de itens; sem badge por item; largura estreita apenas;
- `nota`: 7;
- `justificativa`: cobertura boa para navigation rail (sidebar de ícones) — variante compacta de navegação persistente.

**Composição**:

1. AppSideMenuButton
- `cobertura`: botão hamburguer que abre o AppMenu (OffCanvas);
- `nota`: 9;
- `justificativa`: peça essencial para acionar o menu principal.

2. AppSideItem
- `cobertura`: item da sidebar com ícone, href e estado ativo;
- `nota`: 8;
- `justificativa`: item de destino de navegação com estado.

3. DropButton
- `cobertura`: pode fornecer submenus inline para itens de menu com filhos;
- `nota`: 5;
- `justificativa`: workaround para submenu — não é design natural do AppMenu.

**Descartados**: nenhum.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `sidebar expandida e persistente com labels visíveis`: AppSideBar é estreita e de ícones; sem variante expandida nativa;
  - `submenu multinível`: não suportado no AppMenu — requer DropButton como workaround;
  - `badge/contagem por item`: não nativo — inserir Badge como filho do AppMenuItem manualmente;
  - `ocultação de item por permissão`: responsabilidade do MenuService — filtrar itens ao carregar.

- `tipo de adaptação`: componente principal implementa
- `o que precisa ser feito`:
  - Para menu principal: registrar `AddYasamenMenu()` + `AddYasamenOffCanvas()` + definir itens via `MenuService`;
  - Para sidebar de ícones: usar `AppSideBar` + `AppSideItem` por destino;
  - Para sidebar expandida: sem componente nativo — implementar customizado ou usar OffCanvas como drawer de menu;
  - Filtrar itens de menu por permissão no `MenuService` ao carregar.

## Como usar

### Menu principal com AppMenu + AppSideBar (padrão da biblioteca)

```razor
@* Program.cs / startup *@
builder.Services.AddYasamenMenu();
builder.Services.AddYasamenOffCanvas();

@* AppLayout com AppSideBar + AppMenu *@
<AppLayout>
    <TopBar>
        <AppTopBar>
            <StartContent>
                <AppSideMenuButton />
            </StartContent>
        </AppTopBar>
    </TopBar>
    <SideBar>
        <AppSideBar>
            <AppSideItem Icon="WellKnownIcons.Home" Href="/" Label="Início" />
            <AppSideItem Icon="WellKnownIcons.Users" Href="/usuarios" Label="Usuários" />
            <AppSideItem Icon="WellKnownIcons.Settings" Href="/configuracoes" Label="Config." />
        </AppSideBar>
    </SideBar>
    <AppContent>@Body</AppContent>
</AppLayout>

@* AppMenu abre em OffCanvas ao clicar no AppSideMenuButton *@
<AppMenu Title="Menu Principal" />
```

### Menu simples sem shell completo (OffCanvas manual)

```razor
<Button Style="Themes.Default" Icon="WellKnownIcons.Menu"
        Label="Menu" OnClick="() => menuOffCanvas.Open()" />

<OffCanvas @ref="menuOffCanvas" Position="Positions.Start">
    <AsideBox Title="Navegação">
        <Stack AdditionalClasses="gap-1">
            <Button Style="Themes.Default" Label="Início"
                    NavigateTo="/" Block=true />
            <Button Style="Themes.Default" Label="Usuários"
                    NavigateTo="/usuarios" Block=true />
        </Stack>
    </AsideBox>
</OffCanvas>
```

## Decisão de uso

- `nota geral`: 8;
- `limitações`: sem sidebar expandida com labels persistente (apenas estreita de ícones); sem submenu multinível nativo; badge por item não é prop; menu principal via OffCanvas — não há navegação sidebar fixa expandida;
- `recomendação`: `usar direto`
- `justificativa geral`:
  - `AppMenu` + `AppSideBar` + `AppSideMenuButton` é o padrão nativo da biblioteca para navegação global;
  - Cobre menu principal em OffCanvas com hierarquia de módulos e sidebar de ícones como atalhos rápidos;
  - Para a maioria dos apps B2B (workspace/admin), este padrão cobre diretamente;
  - Nota 8 porque a sidebar expandida persistente não existe — o padrão exige drawer via OffCanvas.
