# Visual Map — yasamen-razor

---

## Sistema de estilos — OBRIGATÓRIO

- **Stack**: Tailwind CSS v4 via `@theme` tokens em `yasamen.css` + classes `ya-*` por componente;
- **Entrada pública**: componente `<YasamenStyles />` no `<head>` da aplicação — único import necessário;
- **Base comum**: `builder.Services.AddYasamenCommons()` + registros por pacote conforme necessidade;
- **Regra geral de estilização**: componentes são self-contained (classes `ya-*`); customização externa via `AdditionalClasses` (string de classes Tailwind) e `AdditionalAttributes`; CSS de layout via tokens Tailwind diretamente nos elementos HTML do app.

---

## Tabela principal de mapeamento — OBRIGATÓRIO

| Eixo visual | Regra visual | Recurso concreto | Receita de uso | Origem | Força |
|---|---|---|---|---|---|
| Cor de marca | primary-500 para identidade, primary-400 para ações | `Themes.Primary` em botões; `primary-500` como token de cor | `<Button Style="Themes.Primary" />` | `btn.css` + `yasamen.css` @theme | forte |
| Ação principal | Filled Primary — max 1 por contexto | `Themes.Primary` com `Outline=false` (default) | `<Button Style="Themes.Primary" Label="Salvar" />` | `btn.css` | forte |
| Ação secundária | Outline Primary ou Secondary | `Outline=true` + `Themes.Primary` ou `Themes.Secondary` | `<Button Style="Themes.Secondary" Outline=true Label="Cancelar" />` | `btn.css` | forte |
| Ação destrutiva | Filled Danger — sempre com confirmação | `Themes.Danger` | `<Button Style="Themes.Danger" Label="Excluir" />` dentro de Modal | `btn.css` | forte |
| Status de item | Pastel semântico (bg-100/text-800/border-200) | `Badge` com `Style=Themes.*` | `<Badge Style="Themes.Success" Text="Ativo" />` | `badge.css` | forte |
| Alerta inline | Feedback com borda semântica | `Feedback` com `Style=Themes.*` | `<Feedback Style="Themes.Danger" Title="Erro" Text="..." />` | `feedback.css` | forte |
| Toast notificação | Branco + borda colorida-400 + ícone colorido | `NotificationService.Show(...)` | `await notifService.ShowSuccess("Salvo!")` | `notification.css` + DI | forte |
| Texto principal | dark-600/dark-700 | classe Tailwind `text-dark-600` | `<p class="text-dark-600">...</p>` | `yasamen.css` @theme | forte |
| Texto de detalhe compacto | text-2xs + dark-700 | classes Tailwind | `<span class="text-2xs text-dark-700">...</span>` | `notification.css` | forte |
| Título de componente | font-semibold | prop `Title` em Feedback/AsideBox | `<Feedback Title="Atenção" ... />` | `feedback.css` | forte |
| Tipografia de conteúdo | system-ui, escala Tailwind | classes Tailwind text-* | `<p class="text-base leading-base">...</p>` | `yasamen.css` @theme | forte |
| Formulário — campo | label acima do input | `FieldText`, `FieldAction`, `FieldBadge` | `<FieldText Label="Nome" @bind-Value="model.Nome" />` | `fieldgroup.css` | forte |
| Loading / progresso de botão | RotationMotion no ícone | `IconAnimation` param + `RotationMotion` | `<Button Icon="..." IconAnimation="@Spinning" />` | `Animations` | forte |
| Loading de listagem | opacity-80 na paginação | `Loading=true` em `Pagination` | `<Pagination Loading="isLoading" ... />` | `pagination.css` | forte |
| Spacing interno compacto | p-3 (0.75rem) | classe Tailwind `p-3` | `<div class="p-3">` ou `PaddingBuilder` em Box | `yasamen.css` spacing | forte |
| Spacing padrão de conteúdo | p-6 (1rem) | classe Tailwind `p-6` | `<div class="p-6">` | `yasamen.css` spacing | forte |
| Separação entre seções | mb-7 (1.5rem) | classe Tailwind `mb-7` | `<section class="mb-7">` | `yasamen.css` spacing | forte |
| Superfície de overlay | bg-white + z-layer definido | Modal, OffCanvas componentes | `<Modal>` / `<OffCanvas>` | `modal.css`, `offcanvas.css` | forte |
| Superfície de container | bg-white via Box | `Box` com `BorderBuilder` | `<Box Border="BorderBuilder.Box">` | `Box.razor` | forte |
| Borda de componente | rounded-md para médios, rounded-full para pills | nativo nos componentes `ya-*` | implícito em `ya-btn`, `ya-badge`, etc. | CSS de componente | forte |
| Elevação / sombra | shadow-lg apenas em toast; lateral em OffCanvas | nativo em `Notification`, `OffCanvas` | implícito — não adicionar shadow externo | `notification.css`, `offcanvas.css` | forte |
| Z-index — app-bar | 1010 | `ya-top-bar` / `AppTopBar` | implícito — nunca sobrescrever | `utilities.css` | forte |
| Z-index — offcanvas | 1030 | `ya-offcanvas` / `OffCanvas` | implícito | `utilities.css` | forte |
| Z-index — modal | 1070 | `ya-modal` / `Modal` | implícito | `utilities.css` | forte |
| Z-index — notification | 1090 | `ya-notification` / `Notification` via service | implícito | `utilities.css` | forte |
| Navegação global | Shell com topbar + sidebar + AppMenu OffCanvas | `AppLayout`, `AppTopBar`, `AppSideBar`, `AppMenu` | ver gramática de layout | `applayout.css` | fraca |
| Navegação local (breadcrumb) | `Breadcrumb` / `DescribesBreadcrumbs` | `<Breadcrumb>` + `<BreadcrumbItem>` | `<DescribesBreadcrumbs MaxVisibleItems="4" />` | `Breadcrumbs` | fraca |
| Paginação | Dual-version mobile+desktop automática | `Pagination` com `CurrentPage`/`TotalPages`/`OnPageChanged` | `<Pagination CurrentPage="p" TotalPages="t" OnPageChanged="OnPage" />` | `pagination.css` | forte |
| Dados tabulares | sem componente — HTML nativo | `<table class="...">` dentro de `Box` | HTML nativo | ausente | inconclusiva |
| Iconografia | WellKnownIcons ou IIconContentFactory | `@WellKnownIcons.Close("text-sm")` / `<Icon Kind="..." />` | registrar `AddYasamenBootstrapIcons()` | `Icons` | forte |
| Responsividade de layout | Container+Slot com spans por breakpoint | `<Container>` + `<Slot Span TabletSpan LaptopSpan>` | ver gramática de layout | `Layouts` | fraca |
| Responsividade de shell | max-sm:mx-0 automático em AppContent | nativo em `AppLayout` | implícito | `applayout.css` | forte |
| Disabled | opacity-50 + cursor-not-allowed | `Disabled=true` | `<Button Disabled="!canSave" ... />` | `btn.css` | forte |
| Hover / pressed | shade+2 / shade+3 automático | nativo em CSS `ya-btn-*` | implícito — não sobrescrever | `btn.css` | forte |
| Focus ring | ring semitransparente tema-300/50 | nativo via `focus-within:` em CSS | implícito | `btn.css`, `pagination.css` | forte |
| Motion padrão | 150ms linear | `transition-default` implícito nos componentes | não sobrescrever com AdditionalClasses | `utilities.css` | forte |
| Motion de modal | slide-down + fade — fases automáticas | nativo em `ya-modal-*` classes | controlado internamente — não interferir | `modal.css` | forte |
| Motion de notificação | slide direcional + fade | nativo em `ya-notification-*` | controlado via `NotificationService` | `notification.css` | forte |

---

## Gramática de layout para telas — OBRIGATÓRIO

### Regras de composição

- **Zona de trabalho**: conteúdo principal dentro de `AppContent` (já injeta `max-sm:mx-0`); usar `Box` ou `Container` para delimitar áreas de conteúdo.
- **Cabeçalho de página**: `Bar` com slot `StartContent` (título) e `EndContent` (ação primária) + margem inferior `mb-7`.
- **Blocos relacionados**: `Box` com `BorderBuilder.Box` para delimitar grupos; `mb-7` entre seções distintas.
- **Filtros e dados**: `Box` com filtros acima, `Box` ou HTML nativo com dados abaixo; `Pagination` abaixo dos dados.
- **Formulários**: `Container Type="Grid"` + `Slot` com spans; `Bar` na última linha para ações (cancelar à esquerda, salvar à direita).
- **Dashboards**: `Container` grid + `Slot` com `Box` interno para cada card de métrica; `Stack` para conteúdo vertical em cada card.
- **List-detail mobile**: `OffCanvas` para o detalhe (posição End); no desktop, `Container`+`Slot` com grid 1/3+2/3.

### Exemplos estruturais

```razor
@* Cabeçalho de página com ação primária *@
<Bar AdditionalClasses="mb-7">
    <StartContent>
        <h1 class="text-xl font-semibold text-dark-600">Usuários</h1>
    </StartContent>
    <EndContent>
        <Button Style="Themes.Primary" Label="Novo Usuário" OnClick="OpenCreate" />
    </EndContent>
</Bar>
```

```razor
@* Formulário responsivo com ações *@
<Container Type="LayoutTypes.Grid">
    <Slot Span="12" TabletSpan="6">
        <FieldText Label="Nome" @bind-Value="model.Nome" />
    </Slot>
    <Slot Span="12" TabletSpan="6">
        <FieldText Label="E-mail" @bind-Value="model.Email" />
    </Slot>
    <Slot Span="12">
        @if (errorMessage is not null)
        {
            <Feedback Style="Themes.Danger" Title="Erro" Text="@errorMessage" AdditionalClasses="mb-4" />
        }
    </Slot>
    <Slot Span="12">
        <Bar>
            <StartContent>
                <Button Style="Themes.Secondary" Outline=true Label="Cancelar" OnClick="Cancel" />
            </StartContent>
            <EndContent>
                <Button Style="Themes.Primary" Label="Salvar" OnClick="Save" />
            </EndContent>
        </Bar>
    </Slot>
</Container>
```

```razor
@* Filtro + dados + paginação *@
<Box Border="BorderBuilder.Box" AdditionalClasses="mb-4 p-4">
    @* filtros aqui *@
    <Bar>
        <StartContent>
            <FieldText Label="Buscar" @bind-Value="filtro" />
        </StartContent>
        <EndContent>
            <Button Style="Themes.Primary" Outline=true Label="Filtrar" OnClick="Buscar" />
        </EndContent>
    </Bar>
</Box>
<Box Border="BorderBuilder.Box" AdditionalClasses="mb-4">
    @* tabela nativa ou lista *@
    <table class="w-full text-sm text-dark-600">
        @* ... *@
    </table>
</Box>
<Pagination CurrentPage="@currentPage" TotalPages="@totalPages"
            OnPageChanged="OnPageChanged" Loading="@isLoading" />
```

---

## Receitas operacionais — OBRIGATÓRIO

### Ação principal em listagem

- **Intenção**: destacar criação de novo item como ação prioritária da tela;
- **Componentes**: `Bar` + `Button` Primary;
- **Recursos**: `Themes.Primary`, `Sizes.Default`;
- **Limites**: máximo 1 botão Filled Primary no cabeçalho;

```razor
<Bar AdditionalClasses="mb-6">
    <StartContent>
        <h1 class="text-xl font-semibold">Produtos</h1>
    </StartContent>
    <EndContent>
        <Button Style="Themes.Primary" Label="Novo Produto" OnClick="IrParaCriacao" />
    </EndContent>
</Bar>
```

- **Variações**: em mobile, o `Bar` empilha Start+End; ação permanece acessível.

---

### Ação destrutiva segura

- **Intenção**: impedir exclusão acidental com confirmação explícita;
- **Componentes**: `Modal` + `Button` Danger + `Button` Secondary outline;
- **Recursos**: `Themes.Danger`, `ModalService` ou handler `ModalHandler`;
- **Limites**: sempre confirmar; nunca excluir ao primeiro clique sem modal;

```razor
@* Botão de exclusão na listagem *@
<IconButton Style="Themes.Danger" Icon="WellKnownIcons.TrashIcon"
            OnClick="@(() => AbrirConfirmacaoExclusao(item.Id))" />

@* Modal de confirmação *@
<Modal @ref="modalExclusao">
    <ChildContent>
        <p class="text-dark-600">Tem certeza que deseja excluir <strong>@nomeItem</strong>? Esta ação não pode ser desfeita.</p>
    </ChildContent>
    <FooterContent>
        <Button Style="Themes.Secondary" Outline=true Label="Cancelar"
                OnClick="() => modalExclusao.Close()" />
        <Button Style="Themes.Danger" Label="Excluir" OnClick="ConfirmarExclusao" />
    </FooterContent>
</Modal>
```

- **Variações**: para exclusão em lote, mostrar contagem no texto do modal.

---

### Formulário com feedback de erro

- **Intenção**: guiar o usuário a corrigir erros sem perder o contexto;
- **Componentes**: `FieldText`, `Feedback` Danger, `Button` Primary;
- **Recursos**: `Themes.Danger`, `Themes.Primary`, `FieldGroup` implícito;
- **Limites**: `Feedback` inline — não usar `Notification` para erro de formulário;

```razor
@if (!string.IsNullOrEmpty(erroGeral))
{
    <Feedback Style="Themes.Danger" Title="Não foi possível salvar"
              Text="@erroGeral" AdditionalClasses="mb-4" />
}
<FieldText Label="Nome" @bind-Value="model.Nome" />
<FieldText Label="E-mail" @bind-Value="model.Email" />
<Bar AdditionalClasses="mt-6">
    <StartContent>
        <Button Style="Themes.Secondary" Outline=true Label="Cancelar" OnClick="Voltar" />
    </StartContent>
    <EndContent>
        <Button Style="Themes.Primary" Label="Salvar" OnClick="Salvar" />
    </EndContent>
</Bar>
```

- **Variações**: `Feedback` pode ser `Closeable=true` para o usuário dispensar o aviso.

---

### Busca e filtros acima de dados

- **Intenção**: manter filtros visíveis e separados da área de resultados;
- **Componentes**: `Box`, `FieldText`, `Button`, tabela nativa, `Pagination`;
- **Recursos**: `BorderBuilder.Box`, `Themes.Primary` outline para filtrar;
- **Limites**: sem componente nativo de tabela — HTML `<table>` dentro de `Box`;

```razor
<Box Border="BorderBuilder.Box" AdditionalClasses="p-4 mb-4">
    <Container Type="LayoutTypes.Grid">
        <Slot Span="12" TabletSpan="6" LaptopSpan="4">
            <FieldText Label="Buscar por nome" @bind-Value="filtroNome" />
        </Slot>
        <Slot Span="12" TabletSpan="6" LaptopSpan="4">
            <Bar AdditionalClasses="items-end pt-1">
                <EndContent>
                    <Button Style="Themes.Primary" Outline=true Label="Aplicar Filtros"
                            OnClick="AplicarFiltros" />
                </EndContent>
            </Bar>
        </Slot>
    </Container>
</Box>

<Box Border="BorderBuilder.Box">
    <table class="w-full">
        <thead class="border-b border-light-200">
            <tr class="text-sm font-semibold text-dark-600">
                <th class="p-3 text-left">Nome</th>
                <th class="p-3 text-left">Status</th>
                <th class="p-3"></th>
            </tr>
        </thead>
        <tbody>
            @foreach (var item in itens)
            {
                <tr class="border-b border-light-100 hover:bg-light-50">
                    <td class="p-3 text-dark-600">@item.Nome</td>
                    <td class="p-3">
                        <Badge Style="@item.Status.ToTheme()" Text="@item.Status.ToString()" />
                    </td>
                    <td class="p-3">
                        <DropIconButton Icon="WellKnownIcons.More" Style="Themes.Default">
                            <DropItem Text="Editar" OnClick="@(() => Editar(item.Id))" />
                            <DropItem Text="Excluir" OnClick="@(() => AbrirExclusao(item.Id))" />
                        </DropIconButton>
                    </td>
                </tr>
            }
        </tbody>
    </table>
</Box>
<Pagination CurrentPage="@currentPage" TotalPages="@totalPages"
            OnPageChanged="OnPageChanged" Loading="@loading" AdditionalClasses="mt-4" />
```

---

### Dashboard com métricas

- **Intenção**: apresentar KPIs de forma escaneável e responsiva;
- **Componentes**: `Container`, `Slot`, `Box`, `Stack`, `Badge`;
- **Recursos**: `LayoutTypes.Grid`, `SpacingSize.*`, `BorderBuilder.*`;
- **Limites**: sem componente de card dedicado — compor com `Box`+`Stack`;

```razor
<Container Type="LayoutTypes.Grid" AdditionalClasses="mb-7">
    @foreach (var metrica in metricas)
    {
        <Slot Span="12" TabletSpan="6" LaptopSpan="3">
            <Box Border="BorderBuilder.Box" AdditionalClasses="p-4 h-full">
                <Stack>
                    <span class="text-2xs text-dark-700 font-medium uppercase">@metrica.Rotulo</span>
                    <span class="text-2xl font-semibold text-dark-600 mt-1">@metrica.Valor</span>
                    @if (metrica.Variacao is not null)
                    {
                        <Badge Style="@metrica.VariacaoTheme" Text="@metrica.Variacao"
                               AdditionalClasses="mt-2" />
                    }
                </Stack>
            </Box>
        </Slot>
    }
</Container>
```

---

### Feedback proporcional à ação

- **Intenção**: confirmar resultado sem bloquear fluxo;
- **Componentes**: `NotificationService` para sucesso; `Feedback` para erro contextual;
- **Recursos**: `Themes.Success`, `Themes.Danger`;
- **Limites**: notification some automaticamente — não usar para erros persistentes;

```razor
@code {
    [Inject] INotificationService NotificationService { get; set; } = default!;

    private async Task Salvar()
    {
        try
        {
            await service.SalvarAsync(model);
            await NotificationService.ShowAsync("Registro salvo com sucesso.", Themes.Success);
            Navegar();
        }
        catch (ValidationException ex)
        {
            erroGeral = ex.Message;  // exibido via <Feedback> inline
        }
        catch (Exception)
        {
            await NotificationService.ShowAsync("Erro inesperado. Tente novamente.", Themes.Danger);
        }
    }
}
```

- **Variações**: erros de validação de campo → `Feedback` inline; erros de sistema → `Notification` Danger.

---

### Shell e navegação completa

- **Intenção**: montar shell app-centric com header, sidebar e menu;
- **Componentes**: `AppLayout`, `AppTopBar`, `AppSideBar`, `AppSideMenuButton`, `AppMenu`;
- **Recursos**: DI completo (`AddYasamenModal`, `AddYasamenOffCanvas`, `AddYasamenNotification`, `AddYasamenMenu`);
- **Limites**: `AppLayout` injeta outlets de Modal, OffCanvas e Notification automaticamente;

```razor
@* MainLayout.razor *@
<AppLayout>
    <TopBar>
        <AppTopBar>
            <StartContent>
                <AppSideMenuButton />
                <span class="text-lg font-semibold text-dark-600 ml-3">MinhaApp</span>
            </StartContent>
            <EndContent>
                <IconButton Icon="WellKnownIcons.User" Style="Themes.Default" />
            </EndContent>
        </AppTopBar>
    </TopBar>
    <SideBar>
        <AppSideBar>
            <AppSideItem Icon="WellKnownIcons.Home" Href="/" Label="Início" />
            <AppSideItem Icon="WellKnownIcons.Users" Href="/usuarios" Label="Usuários" />
        </AppSideBar>
    </SideBar>
    <AppContent>
        @Body
    </AppContent>
</AppLayout>

@* Menu completo no OffCanvas (via AppMenu + MenuService) *@
<AppMenu Title="Menu Principal" />
```

- **Variações**: sem sidebar → omitir bloco `<SideBar>`; sem menu expandido → omitir `AppMenu` e `AppSideMenuButton`.

---

### Painel lateral (list-detail)

- **Intenção**: mostrar detalhe de item sem navegar de página;
- **Componentes**: `OffCanvas`, `AsideBox`, `Button` / `IconButton`;
- **Recursos**: `Position=Positions.End`, `Fitting=OffCanvasFitting.Float` ou `Modal`;
- **Limites**: `OffCanvas` requer `AddYasamenOffCanvas()` + outlet no `AppLayout`;

```razor
<OffCanvas @ref="detalhePainel" Position="Positions.End">
    <AsideBox Title="Detalhe do Produto" Size="Sizes.Large">
        <ChildContent>
            @* conteúdo do detalhe *@
            <Stack>
                <span class="text-sm text-dark-700">@produto?.Nome</span>
                <Badge Style="@produto?.StatusTheme" Text="@produto?.Status" />
            </Stack>
        </ChildContent>
        <FooterContent>
            <Button Style="Themes.Primary" Outline=true Label="Editar"
                    NavigateTo="@($"/produtos/{produto?.Id}/editar")" />
        </FooterContent>
    </AsideBox>
</OffCanvas>
```

---

## Recursos visuais disponíveis — OBRIGATÓRIO

### Cores

| Recurso | Tipo | Valor | Uso |
|---|---|---|---|
| `primary-100` | token CSS (@theme) | ~#e8f0fe | Badge/Feedback bg primary |
| `primary-400` | token CSS | ~#3d8bfd | Button filled primary |
| `primary-500` | token CSS | #0d6dfd | Cor de identidade primary |
| `primary-600` | token CSS | ~#0a58ca | Button hover primary |
| `primary-700` | token CSS | ~#084298 | Button active/pressed |
| `primary-800` | token CSS | ~#052c65 | Badge text primary |
| `secondary-*` | token CSS | escala cinza | Ações secundárias neutras |
| `success-400` | token CSS | verde médio | Button success, notif borda |
| `danger-400` | token CSS | #DC3545 médio | Button danger, erros |
| `warning-400` | token CSS | amarelo médio | Button warning |
| `info-400` | token CSS | azul info | Informações neutras |
| `dark-600` | token CSS | cinza escuro | Texto principal |
| `dark-700` | token CSS | cinza mais escuro | Subtexto, detalhe |
| `dark-900` | token CSS | quase preto | Texto de botão success/warning/danger |
| `light-50` | token CSS | quase branco | Hover neutro, superfície levíssima |
| `light-100` | token CSS | branco levemente cinza | Hover em itens de lista |

### Tipografia

| Recurso | Composição | Uso |
|---|---|---|
| `text-4xs` | system-ui normal 0.5rem | Micro-label extremamente compacto |
| `text-3xs` | system-ui normal 0.5625rem | Micro-label compacto |
| `text-2xs` | system-ui normal 0.625rem | Detalhe de toast, legenda compacta |
| `text-xs` | system-ui normal 0.75rem | Badge, label pequeno |
| `text-sm` | system-ui normal 0.875rem | Texto de apoio, label de campo |
| `text-base` | system-ui normal 1rem | Corpo de conteúdo, botão medium |
| `text-lg` | system-ui normal 1.125rem | Texto levemente maior |
| `text-xl` | system-ui normal 1.25rem | Título de seção |
| `text-2xl` | system-ui normal 1.5rem | Título de página |
| `font-medium` | peso 500 | Botão padrão |
| `font-semibold` | peso 600 | Título de componente, heading de tabela |
| `leading-none` | 1 | Botões, badges |
| `leading-xs` | 1.125 | Texto compacto |
| `leading-sm` | 1.25 | Labels |
| `leading-base` | 1.5 | Corpo de texto |

### Espaçamento

| Recurso | Tipo | Valor | Uso |
|---|---|---|---|
| `p-3` / `py-3 px-3` | inner | 0.25rem (4px) | Micro padding |
| `p-4` | inner | 0.5rem (8px) | Gap inline, padding pequeno |
| `p-5` | inner | 0.75rem (12px) | Toast, label-input gap |
| `p-6` | inner | 1rem (16px) | Padding padrão de card/box |
| `p-7` | inner | 1.5rem (24px) | Padding generoso |
| `mb-3` | outer | 0.25rem | Label → input |
| `mb-4` | outer | 0.5rem | Entre campos |
| `mb-6` | outer | 1rem | Entre grupos de campos |
| `mb-7` | outer | 1.5rem | Entre seções de página |
| `gap-2` | grid/flex | 0.5rem | Gap entre elementos inline |
| `gap-4` | grid/flex | 1rem | Gap padrão em grid |
| `gap-6` | grid/flex | 1.5rem | Gap entre cards |

### Bordas, raios e elevação

| Recurso | Tipo | Valor | Uso |
|---|---|---|---|
| `rounded-md` | radius | 0.375rem (6px) | Botão, modal, campo, notificação |
| `rounded-full` | radius | 9999px | Badge (pill), avatar |
| `rounded-sm` | radius | 0.125rem (2px) | Elementos muito compactos |
| `rounded-lg` | radius | 0.5rem (8px) | Elementos maiores |
| `border` | border | 1px solid | Outline de campos e botões outline |
| `border-2` | border | 2px solid | Borda de notificação (lateral) |
| `shadow-lg` | shadow | `0 10px 15px -3px rgba(0,0,0,0.1)` | Toast (Notification) |
| `shadow-sm` | shadow | sutil | OffCanvas lateral |
| `BorderBuilder.Box` | C# builder | borda + rounded-md | Container de conteúdo padrão |
| `BorderBuilder.BoxWithShadow` | C# builder | borda + rounded + shadow | Card com destaque |

### Breakpoints

| Nome | Valor | Dispositivo/contexto |
|---|---|---|
| `xs` | 480px | Mobile pequeno |
| `sm` | 640px | Mobile |
| `md` | 768px | Tablet — Pagination desktop visível aqui |
| `lg` | 1024px | Laptop — LaptopSpan em Slot |
| `xl` | 1280px | Desktop — DesktopSpan em Slot |
| `2xl` | 1536px | Wide desktop |

### Outros recursos

**Z-index (utilitários)**

| Classe | Valor | Uso |
|---|---|---|
| `z-app-bar` | 1010 | `AppTopBar` |
| `z-offcanvas` | 1030 | `OffCanvas` |
| `z-modal` | 1070 | `Modal` |
| `z-notification` | 1090 | `Notification` toast |

**Motion**

| Variável | Valor | Uso |
|---|---|---|
| `--duration-default` | 0.15s | Transitions padrão (botões, estados) |
| `--duration-fastest` | 0.1s | Animações ultrarrápidas |
| `--duration-slowest` | 0.9s | RotationMotion (loading spinner) |
| `transition-default` | `transition-colors 0.15s linear` | Classe utilitária nos componentes |

**Positions de Notification (9 posições)**

| Posição | Classe |
|---|---|
| Topo esquerda | `ya-notification-group-top-start` |
| Topo centro | `ya-notification-group-top-center` |
| Topo direita | `ya-notification-group-top-end` |
| Centro esquerda | `ya-notification-group-center-start` |
| Centro | `ya-notification-group-center` |
| Centro direita | `ya-notification-group-center-end` |
| Baixo esquerda | `ya-notification-group-bottom-start` |
| Baixo centro | `ya-notification-group-bottom-center` |
| Baixo direita | `ya-notification-group-bottom-end` |

---

## Lacunas e alternativas — OBRIGATÓRIO

| Lacuna | Impacto | Alternativa |
|---|---|---|
| Tabela / data grid | Listagens tabulares precisam de HTML nativo (`<table>`) dentro de `Box` | HTML nativo com classes Tailwind; `Box` para delimitação |
| Select, combobox | Formulários com seleção precisam de `<select>` nativo | `<select>` nativo dentro de `FieldGroup` via slot `Control` |
| Checkbox, radio | Opções de múltipla escolha requerem HTML nativo | `<input type="checkbox">` / `<input type="radio">` com label HTML |
| Datepicker | Seleção de data sem componente da lib | `<input type="date">` nativo dentro de `FieldGroup` |
| Tabs / navigation tabs | Navegação por abas não coberta | Implementar customizado com `Bar` + estados de aba ativos via `active` class |
| Tooltip | Dicas contextuais sem componente | Atributo HTML `title`, ou lib externa (Popper.js, Floating UI) |
| Card component | Sem componente dedicado | `Box` com `BorderBuilder.Box` + `Stack` + `PaddingBuilder` |
| Progress bar | Indicador de progresso não disponível | HTML nativo `<progress>` ou implementação CSS customizada |
| Spinner standalone | Loading de ícone, não de botão | `<RotationMotion>@WellKnownIcons.Spinner("")</RotationMotion>` |
| Dark mode | Sem tokens dark | Implementar variantes CSS customizadas fora da biblioteca |
| Heading tokens | Sem tokens h1/h2/h3 definidos | Usar `text-2xl font-semibold`, `text-xl font-semibold`, `text-lg font-medium` diretamente |
