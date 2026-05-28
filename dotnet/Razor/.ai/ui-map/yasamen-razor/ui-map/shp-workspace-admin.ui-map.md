# SHP-WORKSPACE_ADMIN - Workspace/Admin

## Componentes por zona funcional

### Zona: Shell (estrutura raiz)

1. AppLayout
- `cobertura`: layout raiz com sidebar e área de conteúdo; slots de header, sidebar e main; responsivo com colapso de sidebar;
- `nota`: 9;
- `justificativa`: shell de admin nativo — `AppLayout` é o componente de mais alta cobertura da lib.

2. AppSideBar
- `cobertura`: navegação lateral persistente com itens, grupos, ícones; colapso para ícones; scroll de nav;
- `nota`: 9;
- `justificativa`: sidebar de admin com grupos de navegação.

### Zona: Navegação Global

1. Breadcrumb (UIP-NAV-BREADCRUMB)
- `cobertura`: localização no módulo atual; retorno por nível;
- `nota`: 9;
- `justificativa`: orientação de navegação interna ao módulo.

2. Bar (header de página)
- `cobertura`: título da seção + ações globais (novo, exportar) + busca global opcional;
- `nota`: 9;
- `justificativa`: header operacional de módulo.

### Zona: Conteúdo (módulos)

1. PP-LIST-DETAIL, PP-FORM, PP-DETAIL, PP-SETTINGS, PP-DASHBOARD (composição)
- `cobertura`: página de módulo dentro da área de conteúdo do AppLayout;
- `nota`: 8;
- `justificativa`: módulos operacionais compostos — cobertura sólida da maioria dos page patterns.

### Zona: Overlays Globais

1. Modal + ModalService
- `cobertura`: modais globais de confirmação, criação, edição;
- `nota`: 9;
- `justificativa`: overlays de operação — excelente cobertura.

2. OffCanvas + OffCanvasService
- `cobertura`: drawers de filtros, detalhe rápido, configurações;
- `nota`: 9;
- `justificativa`: overlays laterais de contexto.

3. Notification + NotificationService
- `cobertura`: toasts de sucesso/erro/info após operações;
- `nota`: 9;
- `justificativa`: feedback de operações do shell.

**Descartados**: nenhum.

## Composição completa do shell

```razor
@* MainLayout.razor — shell de Workspace Admin *@
@inherits LayoutComponentBase

<AppLayout>
    @* Sidebar de navegação *@
    <AppSideBar>
        @* Logo *@
        <div class="px-4 py-3 border-b border-light-200 flex items-center gap-2">
            <div class="w-7 h-7 rounded bg-primary-500 flex items-center justify-center">
                <span class="text-white text-xs font-bold">A</span>
            </div>
            <span class="font-semibold text-dark-700 text-sm">Admin</span>
        </div>

        @* Navegação principal *@
        <nav class="flex-1 overflow-y-auto p-2">
            <Stack Gap="Gaps.None">
                @* Grupo: Principal *@
                <div class="mb-4">
                    <p class="text-xs font-semibold text-dark-400 uppercase tracking-wide
                               px-3 py-1">
                        Principal
                    </p>
                    <NavLink href="/dashboard" class="flex items-center gap-2 px-3 py-2 text-sm
                                                      rounded-md transition-colors text-dark-500
                                                      hover:bg-light-50"
                             ActiveClass="bg-primary-50 text-primary-700 font-medium">
                        Dashboard
                    </NavLink>
                    <NavLink href="/clientes" class="flex items-center gap-2 px-3 py-2 text-sm
                                                     rounded-md transition-colors text-dark-500
                                                     hover:bg-light-50"
                             ActiveClass="bg-primary-50 text-primary-700 font-medium">
                        Clientes
                    </NavLink>
                    <NavLink href="/pedidos" class="flex items-center gap-2 px-3 py-2 text-sm
                                                    rounded-md transition-colors text-dark-500
                                                    hover:bg-light-50"
                             ActiveClass="bg-primary-50 text-primary-700 font-medium">
                        Pedidos
                    </NavLink>
                </div>

                @* Grupo: Gestão *@
                <div class="mb-4">
                    <p class="text-xs font-semibold text-dark-400 uppercase tracking-wide
                               px-3 py-1">
                        Gestão
                    </p>
                    <NavLink href="/usuarios" class="flex items-center gap-2 px-3 py-2 text-sm
                                                     rounded-md transition-colors text-dark-500
                                                     hover:bg-light-50"
                             ActiveClass="bg-primary-50 text-primary-700 font-medium">
                        Usuários
                    </NavLink>
                    <NavLink href="/configuracoes" class="flex items-center gap-2 px-3 py-2 text-sm
                                                          rounded-md transition-colors text-dark-500
                                                          hover:bg-light-50"
                             ActiveClass="bg-primary-50 text-primary-700 font-medium">
                        Configurações
                    </NavLink>
                </div>
            </Stack>
        </nav>

        @* Footer da sidebar *@
        <div class="border-t border-light-200 p-3">
            <AuthorizeView>
                <Authorized>
                    <Bar>
                        <StartContent>
                            <div class="flex items-center gap-2">
                                <div class="w-7 h-7 rounded-full bg-primary-200 flex items-center
                                            justify-center text-xs font-bold text-primary-700">
                                    @context.User.Identity?.Name?.Substring(0, 1).ToUpper()
                                </div>
                                <div>
                                    <p class="text-xs font-medium text-dark-700">
                                        @context.User.Identity?.Name
                                    </p>
                                </div>
                            </div>
                        </StartContent>
                        <EndContent>
                            <DropIconButton Icon="WellKnownIcons.MoreVertical"
                                           Style="Themes.Default" Size="Sizes.Small">
                                <DropItem Label="Perfil"
                                          OnClick='() => Nav.NavigateTo("/perfil")' />
                                <DropItem Label="Sair" Style="Themes.Danger"
                                          OnClick="Logout" />
                            </DropIconButton>
                        </EndContent>
                    </Bar>
                </Authorized>
            </AuthorizeView>
        </div>
    </AppSideBar>

    @* Conteúdo da página *@
    <main class="flex-1 overflow-auto p-6">
        @Body
    </main>
</AppLayout>
```

```razor
@* _Imports.razor — serviços injetados globalmente *@
@inject ModalService ModalService
@inject OffCanvasService OffCanvasService
@inject NotificationService NotificationService
@inject NavigationManager Nav
```

## Decisão de uso

- `nota geral`: 9;
- `limitações`: tabs de navegação horizontal (UIP-NAV-TABS GAP) exige composição manual; sem command palette nativo; busca global requer implementação customizada; `AppSideBar` sem suporte a itens aninhados em N níveis;
- `recomendação`: `usar direto`
- `justificativa geral`:
  - `AppLayout` + `AppSideBar` + `Modal`/`OffCanvas`/`Notification` services cobrem SHP-WORKSPACE_ADMIN com excelente qualidade;
  - É o shell pattern mais bem suportado pela lib — claramente o use case principal de design da biblioteca;
  - Nota 9 reflete cobertura nativa de alta qualidade para o shell dominante.
