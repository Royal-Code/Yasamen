# UIP-OVERLAY-MODAL - Modal

## Componentes

**Principais**:

1. Modal
- `cobertura`: superfície bloqueante nativa com backdrop; título, conteúdo e ações; `Size` parametrizado (Small/Medium/Large/FullScreen); fechamento via botão X, backdrop click ou `ModalService.Close()`; `Scrollable` para conteúdo longo; foco gerenciado pela lib;
- `nota`: 9;
- `justificativa`: modal nativo de alta qualidade — bloqueio, foco, escape e ações primárias/secundárias cobertos nativamente.

**Composição**:

1. Button
- `cobertura`: ações primária e secundária no footer do modal; `Style=Themes.Primary` para confirmar; `Style=Themes.Default` para cancelar; `Style=Themes.Danger` para destrutivo;
- `nota`: 9;
- `justificativa`: ações do modal.

2. FormGroup + FieldText/FieldSelect/FieldCheckbox
- `cobertura`: formulário curto dentro do modal com `EditForm` + `DataAnnotationsValidator`;
- `nota`: 9;
- `justificativa`: modal de formulário — composição direta.

3. Feedback
- `cobertura`: estado de erro ou warning dentro do modal; `Style=Themes.Danger` para erro de submit;
- `nota`: 8;
- `justificativa`: erros de operação do modal.

4. Badge
- `cobertura`: status do item sendo editado; estado do modal em processamento;
- `nota`: 7;
- `justificativa`: indicador visual de estado no header.

**Descartados**: nenhum.

## Esforço de adaptação

- `requisitos bem cobertos`:
  - bloqueio de foco, backdrop, fechamento por escape, retorno ao originador: nativos;
  - tamanhos de modal: `Size` parametrizado;
  - modal com formulário: `EditForm` dentro do `ChildContent`;
  - modal informativo: conteúdo livre no `ChildContent`.

- `requisitos mal cobertos`:
  - `loading inline no modal`: `bool processando` + disabled nos botões + spinner HTML/CSS;
  - `modal fullscreen em mobile`: `Size=ModalSize.FullScreen` disponível;
  - `validação de formulário no modal`: `EditContext` + `DataAnnotationsValidator` manual.

- `tipo de adaptação`: uso direto
- `o que precisa ser feito`:
  - Instanciar via `ModalService.Open<TComponent>()` passando parâmetros;
  - Ou usar `Modal` diretamente com `@bind-IsOpen`;
  - `ChildContent` com conteúdo; `FooterContent` com botões ou usar parâmetros nativos.

## Como usar

### Modal de tarefa simples (via ModalService)

```razor
@* Componente de modal: EditarClienteModal.razor *@
@code {
    [Parameter] public ClienteDto Cliente { get; set; } = default!;
    [CascadingParameter] public ModalService Modal { get; set; } = default!;

    private ClienteDto form = new();
    private bool processando;

    protected override void OnParametersSet() => form = Cliente with { };

    private async Task Salvar()
    {
        processando = true;
        await ClienteService.SalvarAsync(form);
        Modal.Close(form);
    }
}

<Modal Title="Editar cliente" Size="ModalSize.Medium">
    <ChildContent>
        <EditForm Model="form" OnValidSubmit="Salvar">
            <DataAnnotationsValidator />
            <Stack Gap="Gaps.Medium">
                <TextField @bind-Value="form.Nome" Label="Nome" required />
                <TextField @bind-Value="form.Email" Label="E-mail" />
                @* [inferido] FieldSelect não existe — usar <InputSelect> Blazor *@
                <div class="flex flex-col gap-1">
                    <label class="text-sm font-medium text-dark-600">Status</label>
                    <InputSelect @bind-Value="form.Status"
                                 class="w-full border border-light-300 rounded-md px-3 py-2 text-sm bg-white">
                        @foreach (var opt in statusOptions)
                        {
                            <option value="@opt.Value">@opt.Label</option>
                        }
                    </InputSelect>
                </div>
            </Stack>
        </EditForm>
    </ChildContent>
    <FooterContent>
        <Button Style="Themes.Default" Label="Cancelar" OnClick="() => Modal.Close()" />
        <Button Style="Themes.Primary" Label="Salvar" OnClick="Salvar"
                Disabled="@processando" />
    </FooterContent>
</Modal>
```

```razor
@* Página que abre o modal *@
@inject ModalService ModalService

<Button Style="Themes.Primary" Label="Editar"
        OnClick="() => ModalService.Open<EditarClienteModal>(p => p.Add(x => x.Cliente, cliente))" />
```

### Modal informativo com estado de erro

```razor
@code {
    private bool isOpen;
    private bool carregando;
    private string? erro;
    private DetalheDto? detalhe;

    private async Task Abrir()
    {
        isOpen = true;
        carregando = true;
        try { detalhe = await Service.ObterAsync(id); }
        catch { erro = "Erro ao carregar dados."; }
        finally { carregando = false; }
    }
}

<IconButton Icon="WellKnownIcons.Info" Style="Themes.Default" OnClick="Abrir" />

<Modal Title="Detalhes" @bind-IsOpen="isOpen" Size="ModalSize.Medium">
    <ChildContent>
        @if (carregando)
        {
            <div class="space-y-3 animate-pulse">
                <div class="h-4 bg-light-200 rounded w-3/4"></div>
                <div class="h-4 bg-light-100 rounded w-1/2"></div>
            </div>
        }
        else if (erro is not null)
        {
            <Feedback Style="Themes.Danger" Text="@erro" />
        }
        else if (detalhe is not null)
        {
            <dl class="grid grid-cols-2 gap-x-4 gap-y-2 text-sm">
                <dt class="text-dark-400">Nome</dt>
                <dd class="text-dark-600 font-medium">@detalhe.Nome</dd>
                <dt class="text-dark-400">Status</dt>
                <dd><Badge Style="@detalhe.StatusTema" Text="@detalhe.Status" /></dd>
            </dl>
        }
    </ChildContent>
    <FooterContent>
        <Button Style="Themes.Default" Label="Fechar" OnClick="() => isOpen = false" />
    </FooterContent>
</Modal>
```

### Modal de confirmação destrutiva

```razor
@code {
    private bool confirmandoExclusao;
    private ItemDto? itemParaExcluir;

    private void ConfirmarExclusao(ItemDto item)
    {
        itemParaExcluir = item;
        confirmandoExclusao = true;
    }

    private async Task Excluir()
    {
        await Service.ExcluirAsync(itemParaExcluir!.Id);
        confirmandoExclusao = false;
        itemParaExcluir = null;
    }
}

<Modal Title="Excluir item" @bind-IsOpen="confirmandoExclusao" Size="ModalSize.Small">
    <ChildContent>
        <p class="text-sm text-dark-600">
            Tem certeza que deseja excluir <strong>@itemParaExcluir?.Nome</strong>?
            Esta ação não pode ser desfeita.
        </p>
    </ChildContent>
    <FooterContent>
        <Button Style="Themes.Default" Label="Cancelar"
                OnClick="() => confirmandoExclusao = false" />
        <Button Style="Themes.Danger" Label="Excluir" OnClick="Excluir" />
    </FooterContent>
</Modal>
```

## Decisão de uso

- `nota geral`: 9;
- `limitações`: nested modal via ModalService requer atenção ao z-index; loading inline dentro do modal é manual; sem step indicator nativo para wizard em modal;
- `recomendação`: `usar direto`
- `justificativa geral`:
  - `Modal` nativo cobre bloqueio, foco, escape, tamanhos e ações primárias/secundárias;
  - `ModalService` viabiliza abertura imperativa desacoplada com parâmetros tipados;
  - Nota 9 reflete cobertura excelente — componente dedicado de alta qualidade.
