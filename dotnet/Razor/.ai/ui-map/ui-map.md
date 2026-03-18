# UI Map — RoyalCode Razor Library

> Mapeamento entre os UI Patterns do Catálogo Global (catalogo-ui.md) e os componentes Blazor da biblioteca RoyalCode.Razor.
>
> Para cada padrão: componente(s) mapeado(s), nota de adaptação (0–10) com justificativa, e exemplo de código Blazor.

---

## Legenda da Nota de Adaptação

| Nota | Significado |
|------|-------------|
| 9–10 | Cobertura total — o componente implementa o padrão diretamente com comportamento, estados e variantes declarados |
| 7–8  | Cobertura alta — estrutura e comportamento cobertos; alguma composição ou CSS extra necessário |
| 5–6  | Cobertura parcial — o padrão é atingível por composição mas sem semântica específica |
| 3–4  | Cobertura baixa — existe um componente relacionado mas incompleto para o padrão |
| 1–2  | Vestigial — apenas primitivos genéricos aplicáveis com muito trabalho personalizado |
| 0    | Ausente — nenhum componente cobre o padrão; implementação inteiramente manual necessária |

---

# Grupo 1 — Estruturais

---

## UIP-STRUCT-LAYOUT_ZONE — Layout Zone

**Componentes RoyalCode:** `Box`, `Container` + `Slot`, `Stack`

**Nota de Adaptação: 7 / 10**

**Justificativa:** O padrão Layout Zone delimita uma área funcional da página com responsabilidade distinta. A biblioteca oferece `Box` (área com borda e padding configuráveis), `Container`+`Slot` (grid responsivo com spans) e `Stack` (coluna vertical). Cobrem as formas de organização espacial. Faltam suporte nativo a estados de "colapsada" e "oculta por permissão" — esses precisam ser geridos com lógica de visibilidade Blazor (`@if`).

**Exemplo:**

```razor
@* Layout Zone com Box (área destacada) *@
<Box Border="@BorderBuilder.Box" Padding="@PaddingBuilder.Medium">
    <h2>Zona Funcional</h2>
    @ChildContent
</Box>

@* Layout Zone com Container/Slot (grid responsivo) *@
<Container Type="LayoutTypes.Grid" Size="LayoutSizes.Desktop">
    <Slot Span="8">
        @* conteúdo principal *@
    </Slot>
    <Slot Span="4">
        @* painel lateral *@
    </Slot>
</Container>

@* Estado colapsado — gerido pelo consumidor *@
@if (!isCollapsed)
{
    <Box>@ChildContent</Box>
}
```

---

## UIP-STRUCT-SPLIT_PANEL — Split Panel

**Componentes RoyalCode:** `Container` + dois `Slot`s

**Nota de Adaptação: 4 / 10**

**Justificativa:** O padrão Split Panel exige dois painéis simultâneos com larguras ajustáveis e comportamento de alternância em Mobile. O `Container`+`Slot` cobre a disposição lado a lado em Desktop (sem resize por arrastar). A lógica de alternância Mobile (um painel de cada vez) precisa ser implementada manualmente. Não há suporte a estado "painel secundário vazio" nem a divisor ajustável.

**Exemplo:**

```razor
@* Desktop: lado a lado. Mobile: apenas o painel active *@

<Container Type="LayoutTypes.Grid" Size="LayoutSizes.Laptop">
    <Slot Span="4" LaptopSpan="5">
        @* Painel primário — lista *@
        <Box Border="@BorderBuilder.Box">
            <ListPanel />
        </Box>
    </Slot>

    @if (selectedItem is not null)
    {
        <Slot Span="4" LaptopSpan="7">
            @* Painel secundário — detalhe *@
            <Box Border="@BorderBuilder.Box">
                <DetailPanel Item="selectedItem" />
            </Box>
        </Slot>
    }
    else
    {
        <Slot Span="4" LaptopSpan="7">
            @* Empty state do painel secundário *@
            <Box>
                <p>Selecione um item para ver o detalhe.</p>
            </Box>
        </Slot>
    }
</Container>
```

---

## UIP-STRUCT-SCROLLABLE_REGION — Scrollable Region

**Componentes RoyalCode:** *(nenhum dedicado)* — aplica-se via `AdditionalClasses` em qualquer container

**Nota de Adaptação: 2 / 10**

**Justificativa:** Não existe um componente `ScrollableRegion` dedicado. A biblioteca usa classes utilitárias (Tailwind/custom) e o desenvolvedor pode injetar `overflow-y-auto` com `AdditionalClasses` em qualquer `Box` ou `Slot`. Não há encapsulamento de scroll independente, lazy loading nativo nem estados de "fim do conteúdo".

**Exemplo:**

```razor
@* Região com scroll independente usando AdditionalClasses *@
<Box AdditionalClasses="overflow-y-auto" style="max-height: 400px;">
    @foreach (var item in items)
    {
        <div>@item.Title</div>
    }
</Box>

@* Ou via Slot com altura fixa *@
<Slot Height="SpacingSize.Large" AdditionalClasses="overflow-y-auto">
    @FeedContent
</Slot>
```

---

## UIP-STRUCT-STACK_CONTAINER — Stack Container

**Componentes RoyalCode:** `Stack`

**Nota de Adaptação: 8 / 10**

**Justificativa:** `Stack` renderiza um `flex flex-col w-100` — exatamente um Stack Container vertical de largura total. Espaçamento entre filhos é controlado pelo CSS do design system. Falta um parâmetro nativo de `gap` variável declarativo, mas o padrão estrutural é coberto com fidelidade.

**Exemplo:**

```razor
@* Stack simples com campos de formulário *@
<Stack>
    <FieldText>Nome</FieldText>
    <FieldText>E-mail</FieldText>
    <FieldText>Mensagem</FieldText>
    <Button Label="Enviar" Style="Themes.Primary" Type="ButtonTypes.Submit" />
</Stack>

@* Stack dentro de uma zona de configurações *@
<Stack AdditionalClasses="gap-4">
    <Box Border="@BorderBuilder.Box" Padding="@PaddingBuilder.Medium">
        <h3>Perfil</h3>
        @ProfileFields
    </Box>
    <Box Border="@BorderBuilder.Box" Padding="@PaddingBuilder.Medium">
        <h3>Segurança</h3>
        @SecurityFields
    </Box>
</Stack>
```

---

## UIP-STRUCT-GRID_CONTAINER — Grid Container

**Componentes RoyalCode:** `Container` + `Slot`

**Nota de Adaptação: 8 / 10**

**Justificativa:** `Container` com `Type="LayoutTypes.Grid"` e `Slot` com spans responsivos (`Span`, `TabletSpan`, `LaptopSpan`, `DesktopSpan`) implementam diretamente um Grid Container com colapso progressivo de colunas. A ordem dos itens é preservada pelo CSS grid. Falta um skeleton nativo de loading — precisa ser composto.

**Exemplo:**

```razor
@* Grid de cards — 3 colunas Desktop, 2 Tablet, 1 Mobile *@
<Container Type="LayoutTypes.Grid" Size="LayoutSizes.Desktop">
    @foreach (var item in catalogItems)
    {
        <Slot Span="4" TabletSpan="6" DesktopSpan="4">
            <Box Border="@BorderBuilder.Box" Padding="@PaddingBuilder.Medium">
                <h4>@item.Name</h4>
                <p>@item.Description</p>
                <Button Label="Ver detalhe" OnClick="@(() => Select(item))" />
            </Box>
        </Slot>
    }
</Container>
```

---

# Grupo 2 — Navegação

---

## UIP-NAV-NAVIGATION_MENU — Navigation Menu

**Componentes RoyalCode:** `AppMenu`, `AppMenuList`, `AppMenuItem`, `AppSideBar`, `AppSideMenuButton`, `AppLayout`

**Nota de Adaptação: 8 / 10**

**Justificativa:** A biblioteca tem um sistema de menu robusto: `AppLayout` com sidebar, `AppSideMenuButton` que abre o `AppMenu` via `OffCanvas`, `AppMenuList` renderizando os itens do nível atual, e `AppMenuItem` com suporte a links, módulos (drill-down) e divisores. Suporta favoritos e navegação hierárquica. O ponto fraco atual não é o carregamento do menu, mas a experiência complementar: o `AppMenu` ainda contém um placeholder interno de busca (`search component`) e não há bottom navigation nativa para Mobile.

**Exemplo:**

```razor
@* AppLayout já inclui a estrutura completa de navegação *@
<AppLayout>
    <TopStart>
        <AppSideMenuButton />  @* hamburger que abre o AppMenu *@
    </TopStart>
    <TopCenter>
        <span>Minha Aplicação</span>
    </TopCenter>
    <LeftMenu>
        @* Ícones de acesso rápido na sidebar *@
        <AppSideItem>
            <IconButton Icon="WellKnownIcons.Home" OnClick="@GoHome" />
        </AppSideItem>
    </LeftMenu>
    <Main>
        @Body
    </Main>
    <Footer>
        <span>(c) 2026</span>
    </Footer>
</AppLayout>
```

Para alimentar o `AppMenu` com itens de menu:

```csharp
builder.Services
    .AddYasamenMenu()
    .ConfigureMenuItems(
        new MenuItem
        {
            Id = "home",
            Text = "Início",
            Url = "/",
            Type = MenuItemType.Link
        },
        new MenuItem
        {
            Id = "cadastros",
            Text = "Cadastros",
            Type = MenuItemType.Module,
            Children =
            [
                new MenuItem
                {
                    Id = "clientes",
                    Text = "Clientes",
                    Url = "/clientes",
                    Type = MenuItemType.Link
                }
            ]
        });
```

Também é possível fornecer um `IMenuLoader` customizado quando o menu vier de HTTP ou outra fonte externa.

---

## UIP-NAV-BREADCRUMB — Breadcrumb

**Componentes RoyalCode:** `Breadcrumb`, `BreadcrumbItem`, `DescribesBreadcrumbs`

**Nota de Adaptação: 9 / 10**

**Justificativa:** Cobertura quase total. `Breadcrumb` renderiza `<nav aria-label="breadcrumb"><ol>`. `BreadcrumbItem` com `Active` marca o item atual como não navegável. O overflow automático para dropdown (via `MenuItems` + `DropButton`) cobre a truncagem em Mobile. `DescribesBreadcrumbs` é uma versão data-driven que atualiza automaticamente via `NavigationManager`. Apenas falta o esqueleto de loading declarativo.

**Exemplo:**

```razor
@* Uso manual com BreadcrumbItem *@
<Breadcrumb>
    <Items>
        <BreadcrumbItem Href="/">Início</BreadcrumbItem>
        <BreadcrumbItem Href="/clientes">Clientes</BreadcrumbItem>
        <BreadcrumbItem Active="true">João Silva</BreadcrumbItem>
    </Items>
</Breadcrumb>

@* Uso data-driven (recomendado) *@
<DescribesBreadcrumbs Items="@breadcrumbItems" />

@code {
    private IReadOnlyList<BreadcrumbDescription> breadcrumbItems =
    [
        new BreadcrumbDescription { Label = "Início", Href = "/" },
        new BreadcrumbDescription { Label = "Clientes", Href = "/clientes" },
        new BreadcrumbDescription { Label = "João Silva", IsActive = true },
    ];
}
```

---

## UIP-NAV-TABS — Tabs

**Componentes RoyalCode:** *(nenhum)*

**Nota de Adaptação: 0 / 10**

**Justificativa:** Não existe componente `Tabs` na biblioteca. O padrão exige uma barra de tabs com estado "tab ativa", conteúdo condicionado e suporte a badges. Precisa ser implementado inteiramente com HTML/CSS e lógica Blazor nativa.

**Exemplo (implementação manual usando primitivos RoyalCode):**

```razor
@* Aproximação manual sem componente dedicado *@
<div class="ya-tabs">
    <Bar>
        <Start>
            <Button Label="Geral"
                    Style="@(activeTab == "geral" ? Themes.Primary : Themes.Default)"
                    OnClick="@(() => activeTab = "geral")" />
            <Button Label="Histórico"
                    Style="@(activeTab == "hist" ? Themes.Primary : Themes.Default)"
                    OnClick="@(() => activeTab = "hist")" />
        </Start>
    </Bar>
</div>

@if (activeTab == "geral")
{
    <GeralContent />
}
else if (activeTab == "hist")
{
    <HistoricoContent />
}

@code {
    private string activeTab = "geral";
}
```

---

## UIP-NAV-PAGINATION — Pagination

**Componentes RoyalCode:** `Pagination`

**Nota de Adaptação: 9 / 10**

**Justificativa:** `Pagination` cobre diretamente o padrão com API pública controlada por estado externo, navegação para primeira/anterior/próxima/última, janela numérica no Desktop, resumo compacto no Mobile e bloqueio durante loading. O componente também expõe `aria-current="page"`, usa `<nav aria-label="Paginação">` e centraliza o contrato visual em classes `ya-pagination*`. O único gap residual do primeiro release é não incluir seletor de tamanho de página nem sincronização automática com URL.

**Exemplo:**

```razor
<Pagination CurrentPage="@currentPage"
            TotalPages="@totalPages"
            Loading="@loading"
            OnPageChanged="@ChangePageAsync" />

@code {
    private int currentPage = 3;
    private int totalPages = 12;
    private bool loading;

    private Task ChangePageAsync(int page)
    {
        currentPage = page;
        return Task.CompletedTask;
    }
}
```

---

## UIP-NAV-STEPPER_INDICATOR — Stepper Indicator

**Componentes RoyalCode:** *(nenhum)*

**Nota de Adaptação: 0 / 10**

**Justificativa:** Não existe componente de Stepper. O padrão exige indicador de progresso multi-etapas com etapas numeradas/nomeadas, estados "concluída", "atual", "futura" e "com erro". A biblioteca não tem primitivos específicos para este padrão.

**Exemplo (implementação manual):**

```razor
@* Approx. manual com Bar e Badge *@
<Bar>
    <Start>
        @for (int i = 1; i <= steps.Count; i++)
        {
            var step = i;
            var isDone = step < currentStep;
            var isActive = step == currentStep;
            <Badge Text="@step.ToString()"
                   Style="@(isDone ? Themes.Success : isActive ? Themes.Primary : Themes.Light)"
                   AdditionalClasses="@(isActive ? "ring-2" : string.Empty)" />
            @if (step < steps.Count)
            {
                <span class="ya-stepper-separator">—</span>
            }
        }
    </Start>
</Bar>

@code {
    private int currentStep = 2;
    private List<string> steps = ["Dados", "Endereço", "Pagamento", "Confirmar"];
}
```

---

# Grupo 3 — Dados & Listagem

---

## UIP-DATA-DATA_TABLE — Data Table

**Componentes RoyalCode:** *(nenhum)*

**Nota de Adaptação: 0 / 10**

**Justificativa:** Não existe componente de tabela de dados. O padrão exige cabeçalho com colunas ordenáveis, linhas com checkbox de seleção, coluna de ações, paginação integrada, Action Bar para seleção múltipla e estados de loading (skeleton), empty e error. Nenhum desses comportamentos está encapsulado. A implementação requer HTML nativo `<table>` com lógica completa.

**Exemplo (estrutura manual com primitivos RoyalCode):**

```razor
@* Action Bar sobre a tabela *@
<Bar>
    <Start>
        @if (selectedIds.Count > 0)
        {
            <Button Label="Excluir selecionados"
                    Style="Themes.Danger"
                    OnClick="@DeleteSelected" />
        }
    </Start>
    <End>
        <Button Label="Novo" Style="Themes.Primary" Icon="WellKnownIcons.Add" />
    </End>
</Bar>

@* Tabela manual *@
<table class="w-full">
    <thead>
        <tr>
            <th><input type="checkbox" @onchange="ToggleAll" /></th>
            <th>Nome</th>
            <th>Status</th>
            <th>Ações</th>
        </tr>
    </thead>
    <tbody>
        @foreach (var item in items)
        {
            <tr>
                <td><input type="checkbox" @bind="item.Selected" /></td>
                <td>@item.Name</td>
                <td><Badge Text="@item.Status" Style="Themes.Info" /></td>
                <td>
                    <DropIconButton Icon="WellKnownIcons.Dots">
                        <DropItem OnClick="@(() => Edit(item))">Editar</DropItem>
                        <DropItem OnClick="@(() => Delete(item))">Excluir</DropItem>
                    </DropIconButton>
                </td>
            </tr>
        }
    </tbody>
</table>
```

---

## UIP-DATA-LIST_ITEM — List Item

**Componentes RoyalCode:** *(nenhum dedicado)* — `AppMenuItem` apenas para contexto de navegação

**Nota de Adaptação: 2 / 10**

**Justificativa:** Não existe um componente `ListItem` genérico. `AppMenuItem` implementa o padrão para navegação (link, módulo, divisor) mas é específico do `AppMenu`. Para listas de dados arbitrárias, o desenvolvedor precisa compor com `Box` e layout manual. Falta área de toque mínima declarativa e estados de seleção/disabled nativos.

**Exemplo:**

```razor
@* Lista simples composta com Box *@
@foreach (var contact in contacts)
{
    <Box AdditionalClasses="cursor-pointer hover:bg-gray-50 flex items-center gap-3 p-3"
         @onclick="@(() => SelectContact(contact))">
        <Icon Kind="WellKnownIcons.User" />
        <div>
            <div class="font-medium">@contact.Name</div>
            <div class="text-sm text-gray-500">@contact.Email</div>
        </div>
        <DropIconButton Icon="WellKnownIcons.Dots" AdditionalClasses="ml-auto">
            <DropItem OnClick="@(() => EditContact(contact))">Editar</DropItem>
        </DropIconButton>
    </Box>
}
```

---

## UIP-DATA-CARD_GRID — Card Grid

**Componentes RoyalCode:** `Box` + `Container` + `Slot`

**Nota de Adaptação: 5 / 10**

**Justificativa:** A combinação `Container`+`Slot` fornece o grid responsivo e `Box` fornece o card com borda/padding. Cobrem a estrutura visual. Faltam estados de hover declarativos sobre o card, estado de seleção, skeleton de loading e acção primária embutida. O `Button` cobre a ação primária dentro do card.

**Exemplo:**

```razor
<Container Type="LayoutTypes.Grid" Size="LayoutSizes.Desktop">
    @foreach (var product in products)
    {
        <Slot Span="4" TabletSpan="6" LaptopSpan="4">
            <Box Border="@BorderBuilder.Box" Padding="@PaddingBuilder.Medium"
                 AdditionalClasses="hover:shadow-md transition-shadow">
                <img src="@product.ImageUrl" alt="@product.Name" class="w-full rounded" />
                <h4 class="mt-2 font-semibold">@product.Name</h4>
                <p class="text-sm text-gray-600">@product.Category</p>
                <p class="text-lg font-bold mt-1">@product.Price.ToString("C")</p>
                <Button Label="Ver produto"
                        Style="Themes.Primary"
                        Block="true"
                        AdditionalClasses="mt-3"
                        OnClick="@(() => Navigate(product))" />
            </Box>
        </Slot>
    }
</Container>
```

---

## UIP-DATA-TIMELINE_ITEM — Timeline Item

**Componentes RoyalCode:** *(nenhum)*

**Nota de Adaptação: 0 / 10**

**Justificativa:** Não existe componente de Timeline. O padrão exige indicador temporal, avatar/ícone, conteúdo principal e acções inline com a semântica de feed cronológico. Nenhum primitivo da biblioteca cobre esse padrão.

**Exemplo (implementação manual):**

```razor
@foreach (var entry in activityFeed)
{
    <div class="flex gap-3 py-3 border-b">
        <Icon Kind="@entry.Icon" AdditionalClasses="text-gray-400 mt-1 shrink-0" />
        <div class="flex-1">
            <div class="text-sm text-gray-500">@entry.OccurredAt.ToString("dd/MM HH:mm")</div>
            <div>@entry.Description</div>
            @if (entry.IsNew)
            {
                <Badge Text="Novo" Style="Themes.Info" />
            }
        </div>
        <DropIconButton Icon="WellKnownIcons.Dots" AdditionalClasses="shrink-0">
            <DropItem OnClick="@(() => MarkRead(entry))">Marcar como lido</DropItem>
        </DropIconButton>
    </div>
}
```

---

## UIP-DATA-KANBAN_COLUMN — Kanban Column

**Componentes RoyalCode:** *(nenhum)*

**Nota de Adaptação: 0 / 10**

**Justificativa:** Não existe suporte a Kanban. O padrão exige colunas com scroll interno, drag-and-drop entre colunas, cabeçalho com contagem e comportamento mobile de "uma coluna de cada vez". A biblioteca não tem primitivos para este padrão.

---

# Grupo 4 — Entrada

---

## UIP-INPUT-FORM_FIELD_GROUP — Form Field Group

**Componentes RoyalCode:** `FieldGroup`, `ControlGroup`, `InputFieldBase<TValue>`, `TextField`, `FieldText`, `FieldBadge`, `FieldAction`

**Nota de Adaptação: 6 / 10**

**Justificativa:** A biblioteca já tem uma boa infraestrutura de campo: `FieldGroup` concentra label, descrição complementar, informação, erro e footer; `ControlGroup` trata prepend/append; `InputFieldBase<TValue>` integra essa estrutura com `EditContext`; e `TextField` já entrega um campo concreto pronto para uso. O gap não está no agrupamento de campo em si, mas na falta de mais inputs concretos e de componentes de entrada mais complexos. Por isso a cobertura é média, não baixa.

**Exemplo:**

```razor
<EditForm Model="@model" OnValidSubmit="@HandleSubmit">
    <DataAnnotationsValidator />

    <Stack>
        <div class="font-semibold text-lg">Dados Pessoais</div>

        <TextField @bind-Value="model.Name"
                   Label="Nome"
                   Information="Informe o nome completo.">
            <DescriptionComplement>
                <FieldBadge Text="Obrigatório" Style="Themes.Danger" />
            </DescriptionComplement>
        </TextField>

        <TextField @bind-Value="model.Code"
                   Label="Código"
                   Placeholder="Código interno">
            <Append>
                <FieldAction Label="Gerar" OnClick="@GenerateCode" />
            </Append>
            <FooterAction>
                <FieldText>Use um código curto e único.</FieldText>
            </FooterAction>
        </TextField>

        <Button Label="Salvar" Type="ButtonTypes.Submit" Style="Themes.Primary" />
    </Stack>
</EditForm>
```

---

## UIP-INPUT-SEARCH_BAR — Search Bar

**Componentes RoyalCode:** *(nenhum dedicado)*

**Nota de Adaptação: 1 / 10**

**Justificativa:** Não existe componente `SearchBar`. O `AppMenu` contém internamente um placeholder de busca não exposto como componente público. Para implementação de busca em páginas de listagem precisa de composição manual com `input` nativo e `FieldAction` ou `IconButton`.

**Exemplo:**

```razor
@* Search Bar composta manualmente *@
<div class="flex items-center gap-2 border rounded px-3 py-2">
    <Icon Kind="WellKnownIcons.Search" AdditionalClasses="text-gray-400" />
    <input type="search"
           class="flex-1 outline-none bg-transparent"
           placeholder="Buscar..."
           @bind-value="searchTerm"
           @bind-value:event="oninput"
           @onkeyup="@OnSearchKeyUp" />
    @if (!string.IsNullOrEmpty(searchTerm))
    {
        <IconButton Icon="WellKnownIcons.Close"
                    Size="Sizes.Small"
                    OnClick="@ClearSearch" />
    }
</div>

@code {
    private string searchTerm = string.Empty;

    private async Task OnSearchKeyUp(KeyboardEventArgs e)
    {
        if (e.Key == "Enter") await Search(searchTerm);
    }

    private void ClearSearch() => searchTerm = string.Empty;
}
```

---

## UIP-INPUT-FILTER_PANEL — Filter Panel

**Componentes RoyalCode:** `OffCanvas` (mobile drawer), `Box` + `Stack` (painel lateral Desktop)

**Nota de Adaptação: 4 / 10**

**Justificativa:** Para Mobile, o `OffCanvas` cobre exatamente o padrão "gaveta de filtros" com abertura por botão, fundo backdrop e fechamento. Para Desktop, uma composição de `Box`+`Stack` cobre o painel lateral. Faltam os comportamentos de "indicador de filtros ativos" e "limpar todos" como funcionalidades nativas. A transição Desktop→Mobile precisa ser gerida pelo consumidor.

**Exemplo:**

```razor
@* Mobile: gaveta via OffCanvas *@
<Button Label="Filtros"
        Icon="WellKnownIcons.Filter"
        OnClick="@filterHandler.Show"
        AdditionalClasses="md:hidden" />

<OffCanvas Handler="@filterHandler" Position="Positions.End" Modal="true" Title="Filtros">
    <Stack>
        <FilterControls @bind-Values="filters" />
        <Button Label="Aplicar" Style="Themes.Primary" Block="true" OnClick="@ApplyFilters" />
        <Button Label="Limpar tudo" Style="Themes.Default" Block="true" OnClick="@ClearFilters" />
    </Stack>
</OffCanvas>

@* Desktop: painel fixo via Stack *@
<div class="hidden md:block">
    <Box Border="@BorderBuilder.Box" Padding="@PaddingBuilder.Medium">
        <Stack>
            <div class="font-semibold">Filtros</div>
            <FilterControls @bind-Values="filters" />
            <Button Label="Limpar todos" Style="Themes.Default" OnClick="@ClearFilters" />
        </Stack>
    </Box>
</div>

@code {
    private OffCanvasHandler filterHandler = new();
}
```

---

## UIP-INPUT-DATE_PICKER — Date Picker

**Componentes RoyalCode:** *(nenhum)*

**Nota de Adaptação: 0 / 10**

**Justificativa:** Não existe componente de seleção de data. O padrão exige calendário dropdown com navegação por mês/ano e seleção de intervalo. O desenvolvedor precisa de uma biblioteca de terceiros (ex: Radzen DatePicker, MudBlazor DatePicker) ou implementação própria.

---

## UIP-INPUT-INLINE_EDITOR — Inline Editor

**Componentes RoyalCode:** *(nenhum)*

**Nota de Adaptação: 0 / 10**

**Justificativa:** Não existe componente de edição inline. O padrão exige ativação por clique no valor, campo de edição no lugar, confirmação implícita (blur/Enter) e cancelamento (Esc). A biblioteca não tem primitivos específicos para este padrão.

**Exemplo (implementação manual):**

```razor
@if (isEditing)
{
    <div class="flex gap-2">
        <input @bind="editValue" @bind:event="oninput"
               @onkeydown="@HandleKeyDown"
               @onblur="@CommitEdit"
               class="ya-input"
               autofocus />
        <IconButton Icon="WellKnownIcons.Close" Size="Sizes.Small" OnClick="@CancelEdit" />
    </div>
}
else
{
    <span @onclick="@StartEdit" class="cursor-pointer hover:underline">@displayValue</span>
}

@code {
    private bool isEditing;
    private string editValue = string.Empty;
    private string displayValue = "Valor atual";

    private void StartEdit() { editValue = displayValue; isEditing = true; }
    private void CommitEdit() { displayValue = editValue; isEditing = false; }
    private void CancelEdit() => isEditing = false;

    private void HandleKeyDown(KeyboardEventArgs e)
    {
        if (e.Key == "Enter") CommitEdit();
        if (e.Key == "Escape") CancelEdit();
    }
}
```

---

# Grupo 5 — Feedback & Estado

---

## UIP-FEEDBACK-EMPTY_STATE — Empty State

**Componentes RoyalCode:** `Feedback` (adaptação parcial)

**Nota de Adaptação: 4 / 10**

**Justificativa:** `Feedback` renderiza uma caixa tematizada com ícone, título e texto — cobre a estrutura visual do Empty State. Porém, não tem uma variante semântica "vazio" (sem dados) vs "sem resultados de filtro", nem CTA primário embutido como elemento de primeiro nível. O `Feedback` é orientado a alertas, não a empty states. Pode ser adaptado com `ChildContent` para inserir um `Button`.

**Exemplo:**

```razor
@if (!items.Any())
{
    <div class="flex flex-col items-center py-12 gap-4">
        <Icon Kind="WellKnownIcons.Empty" AdditionalClasses="w-12 h-12 text-gray-300" />
        <div class="text-center">
            <h3 class="font-semibold text-gray-700">Nenhum resultado encontrado</h3>
            <p class="text-sm text-gray-500 mt-1">Tente ajustar os filtros ou criar um novo item.</p>
        </div>
        <Button Label="Criar novo" Style="Themes.Primary" Icon="WellKnownIcons.Add"
                OnClick="@OpenCreate" />
    </div>
}

@* Alternativa usando Feedback *@
@if (!items.Any())
{
    <Feedback Title="Nenhum item encontrado"
              Text="Crie o primeiro item para começar."
              Style="Themes.Info"
              Block="true">
        <Button Label="Criar" Style="Themes.Primary" Icon="WellKnownIcons.Add"
                OnClick="@OpenCreate" />
    </Feedback>
}
```

---

## UIP-FEEDBACK-LOADING_STATE — Loading State

**Componentes RoyalCode:** `RotationMotion` (spinner), sem skeleton nativo

**Nota de Adaptação: 3 / 10**

**Justificativa:** A biblioteca oferece `RotationMotion` que envolve qualquer conteúdo em animação de rotação contínua — cobre spinners centralizados. Não existem componentes de skeleton loader. O catálogo prefere skeleton sobre spinner para loading states de conteúdo — a biblioteca está abaixo do ideal nesse aspecto. `RotationMotion` com um ícone de engrenagem (`WellKnownIcons.Settings`) é o padrão interno usado no `AppMenuList`.

**Exemplo:**

```razor
@* Spinner com RotationMotion *@
@if (isLoading)
{
    <div class="flex justify-center py-8">
        <RotationMotion>
            <Icon Kind="WellKnownIcons.Settings" AdditionalClasses="w-8 h-8 text-gray-400" />
        </RotationMotion>
    </div>
}

@* Spinner inline em botão de submissão *@
<Button Type="ButtonTypes.Submit" Style="Themes.Primary" Disabled="@isSubmitting">
    @if (isSubmitting)
    {
        <RotationMotion CounterClockwise="true">
            <Icon Kind="WellKnownIcons.Settings" />
        </RotationMotion>
        <span>Aguarde...</span>
    }
    else
    {
        <span>Salvar</span>
    }
</Button>

@* Skeleton manual com classes CSS *@
@if (isLoading)
{
    <div class="animate-pulse space-y-3">
        <div class="h-4 bg-gray-200 rounded w-3/4"></div>
        <div class="h-4 bg-gray-200 rounded w-1/2"></div>
        <div class="h-4 bg-gray-200 rounded w-2/3"></div>
    </div>
}
```

---

## UIP-FEEDBACK-ERROR_STATE — Error State

**Componentes RoyalCode:** `Feedback` com `Style="Themes.Danger"`

**Nota de Adaptação: 6 / 10**

**Justificativa:** `Feedback` com tema `Danger` cobre a estrutura visual (ícone, título, texto) do Error State. Suporta `Closeable` e `ChildContent` para inserir botão de retry. Falta uma variante semântica formal para os subtipos de erro do catálogo (carregamento, submissão, permissão) e a ação de retry não é um parâmetro de primeiro nível. O `OnClose` callback pode ser usado como "retry" com adaptação.

**Exemplo:**

```razor
@* Erro de carregamento com retry *@
@if (hasError)
{
    <Feedback Title="Falha ao carregar os dados"
              Text="Ocorreu um erro ao buscar os dados do servidor. Tente novamente."
              Style="Themes.Danger"
              Block="true">
        <Button Label="Tentar novamente"
                Style="Themes.Danger"
                Outline="true"
                Icon="WellKnownIcons.Refresh"
                OnClick="@Reload" />
    </Feedback>
}

@* Erro inline de submissão *@
<Feedback Title="@errorMessage"
          Style="Themes.Danger"
          Size="Sizes.Small"
          Closeable="true"
          OnClose="@ClearError"
          Block="true" />

@code {
    private bool hasError;
    private string? errorMessage;

    private async Task Reload()
    {
        hasError = false;
        await LoadData();
    }
}
```

---

## UIP-FEEDBACK-TOAST_ALERT — Toast / Alert

**Componentes RoyalCode:** `Notification`, `NotificationContent`, `Notify` (serviço DI)

**Nota de Adaptação: 9 / 10**

**Justificativa:** Cobertura quase total. `Notification` tem auto-dismiss com `Timer`, barra de progresso animada, pausa no hover, `CloseOnClick`, temas completos, ícone ou barra colorida, e callbacks `OnClose` / `OnOpen`. O serviço `Notify` permite uso programático com métodos de conveniência por tema (`Success`, `Danger`, `Warning`, etc.) e callback `configure`. O posicionamento já é configurável por `NotificationItem.Placement`, e o `NotificationOutlet` agrupa os itens por `Placements`.

**Exemplo:**

```razor
@* Uso programático via serviço *@
@inject Notify Notify

<Button Label="Salvar" OnClick="@HandleSave" Style="Themes.Primary" />

@code {
    private async Task HandleSave()
    {
        await SaveData();
        await Notify.Success(
            "Dados salvos com sucesso!",
            configure: item => item.Placement = Placements.BottomEnd);
    }

    private async Task HandleError()
    {
        await Notify.Danger(
            "Erro ao salvar os dados.",
            "Verifique a conexão e tente novamente.",
            item => item.Placement = Placements.TopEnd);
    }
}

@* Uso declarativo com timer *@
<Notification Theme="Themes.Warning"
              Timer="@TimeSpan.FromSeconds(5)"
              Closeable="true"
              Icon="true">
    <NotificationContent Text="Atenção" Details="Sua sessão irá expirar em breve." />
</Notification>
```

---

## UIP-FEEDBACK-CONFIRMATION_DIALOG — Confirmation Dialog

**Componentes RoyalCode:** `Modal`, `ModalHandler`

**Nota de Adaptação: 7 / 10**

**Justificativa:** `Modal` com `ModalHandler` cobre o container overlaid com transições CSS, bloqueio de interação com a página, backdrop, fechamento por teclado (quando `Closeable=true`) e callbacks `OnOpenClose`. O conteúdo interno (título + descrição de impacto + botões) precisa ser composto pelo consumidor com `Stack`, `Button`. Falta um template pré-construído de "confirmação destrutiva" como primeiro cidadão. A integração com `ModalService` gestiona múltiplos modais abertos simultaneamente.

**Exemplo:**

```razor
@* Modal de confirmação de exclusão *@
<ModalHandler @ref="deleteModal" />

<Button Label="Excluir" Style="Themes.Danger" OnClick="@OpenDelete" />

<Modal Id="confirm-delete" Handler="@deleteModal">
    <Stack>
        <div>
            <h4 class="font-semibold text-lg">Confirmar exclusão</h4>
            <p class="text-gray-600 mt-1">
                Esta ação não pode ser desfeita. O item <strong>@itemToDelete?.Name</strong>
                será permanentemente removido.
            </p>
        </div>
        <div class="flex gap-3 justify-end mt-4">
            <Button Label="Cancelar"
                    Style="Themes.Default"
                    OnClick="@deleteModal.CloseAsync" />
            <Button Label="Excluir permanentemente"
                    Style="Themes.Danger"
                    OnClick="@ConfirmDelete" />
        </div>
    </Stack>
</Modal>

@code {
    private ModalHandler deleteModal = new();
    private MyItem? itemToDelete;

    private async Task OpenDelete(MyItem item)
    {
        itemToDelete = item;
        await deleteModal.OpenAsync();
    }

    private async Task ConfirmDelete()
    {
        await DeleteItem(itemToDelete!);
        await deleteModal.CloseAsync();
        await Notify.Success($"{itemToDelete!.Name} excluído com sucesso.");
    }
}
```

---

# Grupo 6 — Ação

---

## UIP-ACTION-ACTION_BAR — Action Bar

**Componentes RoyalCode:** `Bar`, `Button`, `IconButton`

**Nota de Adaptação: 6 / 10**

**Justificativa:** `Bar` é exatamente uma barra horizontal com slots Start/Middle/End para organizar ações com `justify-between`. `Button` e `IconButton` cobrem ações primárias, secundárias e destrutivas. Faltam: comportamento automático de overflow (acções secundárias em menu quando a largura é insuficiente), estado contextual de "seleção múltipla ativa" como primeiro nível e desativação automática baseada em permissão. A composição cobre o padrão mas sem automação.

**Exemplo:**

```razor
@* Action Bar com seleção múltipla *@
<Bar AdditionalClasses="mb-4">
    <Start>
        @if (selectedIds.Count > 0)
        {
            <Badge Text="@($"{selectedIds.Count} selecionados")" Style="Themes.Info" />
            <Button Label="Excluir"
                    Style="Themes.Danger"
                    Icon="WellKnownIcons.Delete"
                    OnClick="@DeleteSelected" />
            <Button Label="Exportar"
                    Style="Themes.Secondary"
                    Icon="WellKnownIcons.Export"
                    OnClick="@Export" />
        }
    </Start>
    <End>
        <Button Label="Novo item"
                Style="Themes.Primary"
                Icon="WellKnownIcons.Add"
                OnClick="@OpenCreate" />
    </End>
</Bar>
```

---

## UIP-ACTION-CONTEXTUAL_MENU — Contextual Menu

**Componentes RoyalCode:** `DropButton`, `DropIconButton`, `DropItem`

**Nota de Adaptação: 9 / 10**

**Justificativa:** Cobertura quase total. `DropIconButton` com ícone de três pontos é o padrão exato do catálogo. `DropItem` com `OnClick` cobre itens de ação. `DropButton`/`DropIconButton` tem `CloseBehavior` configurável (fecha ao clicar no item, fora do menu, ou manualmente). `Direction` e `Align` controlam o posicionamento. Faltam apenas: separadores semânticos nativos entre grupos de itens e estilização automática de itens destrutivos (seria via `AdditionalClasses`).

**Exemplo:**

```razor
@* Menu contextual por linha — três pontos *@
<DropIconButton Icon="WellKnownIcons.Dots"
                ContentType="DropContentType.List"
                CloseBehavior="DropCloseBehavior.CloseOnClick">
    <DropItem OnClick="@(() => View(item))">Ver detalhes</DropItem>
    <DropItem OnClick="@(() => Edit(item))">Editar</DropItem>
    <DropItem OnClick="@(() => Duplicate(item))">Duplicar</DropItem>
    @* Separador manual *@
    <li role="separator" class="border-t my-1"></li>
    <DropItem OnClick="@(() => ConfirmDelete(item))"
              AdditionalClasses="text-red-600">
        Excluir
    </DropItem>
</DropIconButton>

@* Menu contextual por botão com label *@
<DropButton Label="Opções"
            Style="Themes.Secondary"
            Outline="true"
            Direction="Directions.Down"
            Align="Positions.End">
    <DropItem OnClick="@Export">Exportar CSV</DropItem>
    <DropItem OnClick="@Print">Imprimir</DropItem>
</DropButton>
```

---

## UIP-ACTION-FLOATING_ACTION — Floating Action

**Componentes RoyalCode:** `IconButton` ou `Button` com CSS de posicionamento

**Nota de Adaptação: 3 / 10**

**Justificativa:** Não existe componente FAB (Floating Action Button) dedicado. O catálogo define posição fixa (`fixed bottom-right`), tamanho mínimo de 56px em Mobile e estado de loading/desativado. `IconButton` ou `Button` cobrem a aparência do botão, mas o posicionamento fixo, o tamanho e o z-index precisam ser aplicados manualmente. Sem componente dedicado, invsibilidade baseada em `No Permission State` também precisa ser gerida pelo consumidor.

**Exemplo:**

```razor
@* FAB manual usando IconButton *@
<div class="fixed bottom-6 right-6 z-50">
    @if (canCreate)
    {
        <IconButton Icon="WellKnownIcons.Add"
                    Style="Themes.Primary"
                    Size="Sizes.Large"
                    AdditionalClasses="shadow-lg rounded-full w-14 h-14"
                    OnClick="@OpenCreate" />
    }
</div>

@* FAB estendido com label *@
<div class="fixed bottom-6 right-6 z-50">
    <Button Label="Novo pedido"
            Style="Themes.Primary"
            Icon="WellKnownIcons.Add"
            AdditionalClasses="shadow-lg rounded-full px-6 py-4"
            OnClick="@OpenCreate" />
</div>

@code {
    [CascadingParameter] private Task<AuthenticationState> AuthState { get; set; } = null!;
    private bool canCreate;

    protected override async Task OnInitializedAsync()
    {
        var auth = await AuthState;
        canCreate = auth.User.IsInRole("Manager");
    }
}
```

---

# Grupo 7 — Conteúdo

---

## UIP-CONTENT-DETAIL_BLOCK — Detail Block

**Componentes RoyalCode:** `Box`, `Stack`, `Bar`

**Nota de Adaptação: 3 / 10**

**Justificativa:** Não existe componente semântico de Detail Block. A composição de `Box`+`Stack` cobre a área delimitada com agrupamento vertical. `Bar` pode ser usado para a linha "rótulo | valor" lado a lado em Desktop. Faltam: layouts de rótulo+valor com alinhamento consistente, separadores entre grupos, skeleton de loading de atributos e link para edição por secção como comportamentos nativos.

**Exemplo:**

```razor
@* Detail Block composto manualmente *@
<Box Border="@BorderBuilder.Box" Padding="@PaddingBuilder.Medium">
    <Stack>
        <Bar>
            <Start><div class="font-semibold text-lg">Dados do Cliente</div></Start>
            <End>
                <Button Label="Editar" Style="Themes.Secondary" Outline="true"
                        Icon="WellKnownIcons.Edit" OnClick="@OpenEdit" />
            </End>
        </Bar>

        <div class="grid grid-cols-2 gap-4 mt-2">
            <div>
                <div class="text-sm text-gray-500">Nome</div>
                <div class="font-medium">@client.Name</div>
            </div>
            <div>
                <div class="text-sm text-gray-500">E-mail</div>
                <div class="font-medium">@client.Email</div>
            </div>
            <div>
                <div class="text-sm text-gray-500">Telefone</div>
                <div class="font-medium">@client.Phone</div>
            </div>
            <div>
                <div class="text-sm text-gray-500">Status</div>
                <Badge Text="@client.Status" Style="Themes.Success" />
            </div>
        </div>
    </Stack>
</Box>
```

---

## UIP-CONTENT-METRIC_CARD — Metric Card

**Componentes RoyalCode:** `Box` (estrutura), sem semântica dedicada

**Nota de Adaptação: 2 / 10**

**Justificativa:** Não existe componente de Metric Card. `Box` fornece o container visual. O conteúdo semântico (valor principal grande, rótulo, variação positiva/negativa, período, sparkline) precisa ser inteiramente construído com HTML e CSS. A `Badge` pode representar a variação, mas isso é um re-uso fora do contexto intencionado.

**Exemplo:**

```razor
@* Metric Card composta com Box *@
<Box Border="@BorderBuilder.Box" Padding="@PaddingBuilder.Medium">
    <div class="flex justify-between items-start">
        <div>
            <div class="text-sm text-gray-500 uppercase tracking-wide">Receita Mensal</div>
            <div class="text-3xl font-bold mt-1">@revenue.ToString("C0")</div>
        </div>
        <Icon Kind="WellKnownIcons.TrendingUp" AdditionalClasses="w-8 h-8 text-green-400" />
    </div>
    <div class="flex items-center gap-2 mt-2">
        <Badge Text="+12,4%" Style="Themes.Success" />
        <span class="text-sm text-gray-400">vs. mês anterior</span>
    </div>
</Box>
```

---

## UIP-CONTENT-RICH_TEXT_BLOCK — Rich Text Block

**Componentes RoyalCode:** *(nenhum)* — `FieldText` apenas para contexto textual básico em formulários

**Nota de Adaptação: 1 / 10**

**Justificativa:** `FieldText` é um wrapper `<div class="ya-field-text">` para textos descritivos dentro de formulários, não um bloco editorial com tipografia rica (headings, parágrafos, listas, imagens inline). O catálogo exige largura máxima de leitura, tipografia editorial e responsividade de imagens. Nenhum componente da biblioteca cobre esse padrão.

**Exemplo:**

```razor
@* Rich Text Block manual aplicando tipografia editorial *@
<div class="prose prose-slate max-w-prose mx-auto px-4">
    @((MarkupString)articleContent.HtmlBody)
</div>

@* Ou com conteúdo Blazor estruturado *@
<Box AdditionalClasses="max-w-3xl mx-auto">
    <article class="prose">
        <h1>@article.Title</h1>
        <p class="lead">@article.Subtitle</p>
        @((MarkupString)article.Body)
    </article>
</Box>
```

---

## UIP-CONTENT-MEDIA_VIEWER — Media Viewer

**Componentes RoyalCode:** *(nenhum)*

**Nota de Adaptação: 0 / 10**

**Justificativa:** Não existe componente de visualização de mídia. O padrão exige controles de vídeo (play/pause/volume/fullscreen), zoom/rotação de imagens, gestão de galeria com thumbnails e estados de loading/erro/formato não suportado. Nenhum primitivo da biblioteca cobre esse padrão.

---

# Resumo — Tabela de Notas

| ID_UI_PATTERN | Nome | Nota | Componente(s) Principal(is) |
|---|---|:---:|---|
| UIP-STRUCT-LAYOUT_ZONE | Layout Zone | 7 | `Box`, `Container`+`Slot`, `Stack` |
| UIP-STRUCT-SPLIT_PANEL | Split Panel | 4 | `Container`+`Slot` |
| UIP-STRUCT-SCROLLABLE_REGION | Scrollable Region | 2 | *(CSS via AdditionalClasses)* |
| UIP-STRUCT-STACK_CONTAINER | Stack Container | 8 | `Stack` |
| UIP-STRUCT-GRID_CONTAINER | Grid Container | 8 | `Container`+`Slot` |
| UIP-NAV-NAVIGATION_MENU | Navigation Menu | 8 | `AppMenu`, `AppMenuItem`, `AppSideBar` |
| UIP-NAV-BREADCRUMB | Breadcrumb | 9 | `Breadcrumb`, `BreadcrumbItem`, `DescribesBreadcrumbs` |
| UIP-NAV-TABS | Tabs | 0 | *(nenhum)* |
| UIP-NAV-PAGINATION | Pagination | 9 | `Pagination` |
| UIP-NAV-STEPPER_INDICATOR | Stepper Indicator | 0 | *(nenhum)* |
| UIP-DATA-DATA_TABLE | Data Table | 0 | *(nenhum)* |
| UIP-DATA-LIST_ITEM | List Item | 2 | `AppMenuItem` (só em nav) |
| UIP-DATA-CARD_GRID | Card Grid | 5 | `Box`+`Container`+`Slot` |
| UIP-DATA-TIMELINE_ITEM | Timeline Item | 0 | *(nenhum)* |
| UIP-DATA-KANBAN_COLUMN | Kanban Column | 0 | *(nenhum)* |
| UIP-INPUT-FORM_FIELD_GROUP | Form Field Group | 6 | `FieldGroup`, `ControlGroup`, `TextField`, `FieldBadge`, `FieldAction` |
| UIP-INPUT-SEARCH_BAR | Search Bar | 1 | *(manual com input nativo + IconButton)* |
| UIP-INPUT-FILTER_PANEL | Filter Panel | 4 | `OffCanvas`, `Box`+`Stack` |
| UIP-INPUT-DATE_PICKER | Date Picker | 0 | *(nenhum)* |
| UIP-INPUT-INLINE_EDITOR | Inline Editor | 0 | *(nenhum)* |
| UIP-FEEDBACK-EMPTY_STATE | Empty State | 4 | `Feedback` (adaptação) |
| UIP-FEEDBACK-LOADING_STATE | Loading State | 3 | `RotationMotion` (spinner apenas) |
| UIP-FEEDBACK-ERROR_STATE | Error State | 6 | `Feedback` com `Themes.Danger` |
| UIP-FEEDBACK-TOAST_ALERT | Toast / Alert | 9 | `Notification`, `Notify` |
| UIP-FEEDBACK-CONFIRMATION_DIALOG | Confirmation Dialog | 7 | `Modal`, `ModalHandler` |
| UIP-ACTION-ACTION_BAR | Action Bar | 6 | `Bar`, `Button`, `IconButton` |
| UIP-ACTION-CONTEXTUAL_MENU | Contextual Menu | 9 | `DropButton`, `DropIconButton`, `DropItem` |
| UIP-ACTION-FLOATING_ACTION | Floating Action | 3 | `IconButton`+`Button` com CSS manual |
| UIP-CONTENT-DETAIL_BLOCK | Detail Block | 3 | `Box`+`Stack`+`Bar` |
| UIP-CONTENT-METRIC_CARD | Metric Card | 2 | `Box`+`Badge` |
| UIP-CONTENT-RICH_TEXT_BLOCK | Rich Text Block | 1 | *(manual + Tailwind prose)* |
| UIP-CONTENT-MEDIA_VIEWER | Media Viewer | 0 | *(nenhum)* |

---

## Análise por Grupo

| Grupo | Média | Observação |
|---|:---:|---|
| Estruturais | 5,8 | Boa cobertura de grids e stacks; sem scroll region dedicada |
| Navegação | 5,2 | Breadcrumb, Menu e Pagination fortes; Tabs e Stepper ainda ausentes |
| Dados & Listagem | 1,4 | Apenas Card Grid parcialmente coberto; Data Table e Timeline ausentes |
| Entrada | 2,2 | Infra de forms boa; poucos inputs concretos e nenhum input complexo (search, date, inline) |
| Feedback & Estado | 5,8 | Toast e Contextual Dialog fortes; Loading e Empty State fracos |
| Ação | 6,0 | Bar e Contextual Menu muito bons; FAB sem componente dedicado |
| Conteúdo | 1,2 | Nenhum componente de conteúdo estruturado (Detail, Metric, Rich Text, Media) |

