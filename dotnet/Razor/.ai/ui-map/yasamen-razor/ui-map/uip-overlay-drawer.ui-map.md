# UIP-OVERLAY-DRAWER - Drawer

## Componentes

**Principais**:

1. OffCanvas
- `cobertura`: painel lateral temporário nativo com abertura/fechamento animado; `Position` (Start/End/Top/Bottom); `Size` parametrizado; backdrop configurável; scroll interno; header com título e botão X; fechamento via `OffCanvasService.Close()` ou backdrop;
- `nota`: 9;
- `justificativa`: drawer nativo de alta qualidade — lado, tamanho, backdrop e conteúdo cobertos nativamente.

**Composição**:

1. Bar
- `cobertura`: toolbar no header ou footer do drawer com título, ações e filtros ativos;
- `nota`: 8;
- `justificativa`: header/footer do drawer com controles de ação.

2. FieldText / FieldSelect / FieldCheckbox
- `cobertura`: drawer de filtros com campos; `EditForm` para filtros com estado;
- `nota`: 9;
- `justificativa`: drawer de filtros — composição direta.

3. Stack + Box
- `cobertura`: lista de itens dentro do drawer (drawer de detalhes, itens de navegação);
- `nota`: 8;
- `justificativa`: conteúdo de lista do drawer.

4. Button
- `cobertura`: ações do footer: "Aplicar filtros", "Limpar", "Confirmar", "Fechar";
- `nota`: 9;
- `justificativa`: ações do drawer.

5. Feedback
- `cobertura`: estado vazio ou erro dentro do drawer;
- `nota`: 8;
- `justificativa`: estados de ausência de dados no drawer.

**Descartados**: nenhum.

## Esforço de adaptação

- `requisitos bem cobertos`:
  - drawer lateral (esquerda/direita): `Position=OffCanvasPosition.Start/End` nativo;
  - drawer de baixo: `Position=OffCanvasPosition.Bottom`;
  - tamanho configurável: `Size` parametrizado;
  - fechamento por backdrop: comportamento nativo.

- `requisitos mal cobertos`:
  - `drawer persistente` (sem backdrop, push do conteúdo): OffCanvas é sempre sobreposto — drawer persistente requer `AppSideBar` ou estrutura de layout;
  - `loading no drawer`: skeleton manual com `animate-pulse`;
  - `alterações pendentes no drawer`: lógica `bool temAlteracoes` para bloquear fechamento.

- `tipo de adaptação`: uso direto
- `o que precisa ser feito`:
  - Instanciar via `OffCanvasService.Open<TComponent>()` passando parâmetros;
  - Ou usar `OffCanvas` diretamente com `@bind-IsOpen`;
  - `ChildContent` com conteúdo livre; `FooterContent` com ações.

## Como usar

### Drawer de filtros

```razor
@* FiltrosDrawer.razor *@
@code {
    [Parameter] public FiltrosDto Filtros { get; set; } = new();
    [Parameter] public EventCallback<FiltrosDto> OnAplicar { get; set; }
    [CascadingParameter] public OffCanvasService OffCanvas { get; set; } = default!;

    private FiltrosDto form = new();

    protected override void OnParametersSet() => form = Filtros with { };

    private async Task Aplicar()
    {
        await OnAplicar.InvokeAsync(form);
        OffCanvas.Close();
    }
}

<OffCanvas Title="Filtros" Position="OffCanvasPosition.End" Size="OffCanvasSize.Medium">
    <ChildContent>
        <EditForm Model="form">
            <Stack Gap="Gaps.Medium">
                <FieldSelect @bind-Value="form.Status" Label="Status" Options="statusOptions" />
                <FieldSelect @bind-Value="form.Categoria" Label="Categoria"
                             Options="categoriaOptions" />
                <FieldText @bind-Value="form.Responsavel" Label="Responsável" />
                <div>
                    <label class="text-sm text-dark-400 mb-1 block">Período</label>
                    <div class="flex gap-2">
                        <FieldText @bind-Value="form.DataInicio" Type="date" />
                        <FieldText @bind-Value="form.DataFim" Type="date" />
                    </div>
                </div>
            </Stack>
        </EditForm>
    </ChildContent>
    <FooterContent>
        <Button Style="Themes.Default" Label="Limpar"
                OnClick="() => form = new()" />
        <Button Style="Themes.Primary" Label="Aplicar filtros" OnClick="Aplicar" />
    </FooterContent>
</OffCanvas>
```

```razor
@* Página que abre o drawer *@
@inject OffCanvasService OffCanvasService

<Bar AdditionalClasses="mb-4">
    <EndContent>
        <Button Style="Themes.Default" Label="Filtros"
                OnClick='() => OffCanvasService.Open<FiltrosDrawer>(p =>
                    p.Add(x => x.Filtros, filtrosAtivos)
                     .Add(x => x.OnAplicar, EventCallback.Factory.Create<FiltrosDto>(this, AplicarFiltros)))' />
    </EndContent>
</Bar>
```

### Drawer de detalhe rápido

```razor
@code {
    private bool isOpen;
    private DetalheDto? detalhe;
    private bool carregando;

    private async Task AbrirDetalhe(int id)
    {
        isOpen = true;
        carregando = true;
        detalhe = await Service.ObterAsync(id);
        carregando = false;
    }
}

<OffCanvas Title="@(detalhe?.Nome ?? "Detalhes")"
           @bind-IsOpen="isOpen"
           Position="OffCanvasPosition.End"
           Size="OffCanvasSize.Large">
    <ChildContent>
        @if (carregando)
        {
            <div class="space-y-3 animate-pulse">
                @for (int i = 0; i < 6; i++)
                {
                    <div class="h-4 bg-light-200 rounded @(i % 2 == 0 ? "w-3/4" : "w-1/2")"></div>
                }
            </div>
        }
        else if (detalhe is not null)
        {
            <dl class="space-y-3 text-sm">
                <div>
                    <dt class="text-dark-400 text-xs">Status</dt>
                    <dd><Badge Style="@detalhe.StatusTema" Text="@detalhe.Status" /></dd>
                </div>
                <div>
                    <dt class="text-dark-400 text-xs">Responsável</dt>
                    <dd class="text-dark-600">@detalhe.Responsavel</dd>
                </div>
                <div>
                    <dt class="text-dark-400 text-xs">Descrição</dt>
                    <dd class="text-dark-600">@detalhe.Descricao</dd>
                </div>
            </dl>
        }
    </ChildContent>
    <FooterContent>
        <Button Style="Themes.Default" Label="Fechar"
                OnClick="() => isOpen = false" />
        <Button Style="Themes.Primary" Label="Abrir completo"
                OnClick="() => Nav.NavigateTo($"/itens/{detalhe?.Id}")" />
    </FooterContent>
</OffCanvas>
```

### Drawer de navegação lateral (mobile)

```razor
@code {
    private bool menuOpen;
}

<IconButton Icon="WellKnownIcons.Menu" Style="Themes.Default"
            OnClick="() => menuOpen = true" />

<OffCanvas Title="Menu" @bind-IsOpen="menuOpen"
           Position="OffCanvasPosition.Start"
           Size="OffCanvasSize.Small">
    <ChildContent>
        <nav>
            <Stack Gap="Gaps.None">
                <a href="/dashboard" class="flex items-center gap-3 px-4 py-3 text-sm
                           text-dark-600 hover:bg-light-50 rounded">
                    @WellKnownIcons.Dashboard("text-dark-400 text-sm")
                    Dashboard
                </a>
                <a href="/clientes" class="flex items-center gap-3 px-4 py-3 text-sm
                           text-dark-600 hover:bg-light-50 rounded">
                    @WellKnownIcons.Users("text-dark-400 text-sm")
                    Clientes
                </a>
            </Stack>
        </nav>
    </ChildContent>
</OffCanvas>
```

## Decisão de uso

- `nota geral`: 9;
- `limitações`: sem modo persistente (push de conteúdo) — OffCanvas é sempre sobreposto; drawer persistente requer estrutura de layout com `AppSideBar`; loading no drawer é manual;
- `recomendação`: `usar direto`
- `justificativa geral`:
  - `OffCanvas` nativo cobre drawer lateral, de filtros, de detalhe e de navegação;
  - `OffCanvasService` viabiliza abertura imperativa desacoplada com parâmetros tipados;
  - Nota 9 reflete cobertura excelente — componente dedicado de alta qualidade para drawer temporário.
