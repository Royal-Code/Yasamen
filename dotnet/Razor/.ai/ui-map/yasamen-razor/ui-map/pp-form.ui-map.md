# PP-FORM - Form

## Componentes por zona funcional

### Zona: Cabeçalho

1. Bar + Badge + Breadcrumb (UIP-CONTENT-CONTENT_HEADER)
- `cobertura`: título da página, breadcrumb de localização, badge de status ("Novo" / "Edição");
- `nota`: 8;
- `justificativa`: cabeçalho de formulário com contexto de navegação.

### Zona: Conteúdo

1. FormGroup + FieldText/FieldSelect/FieldCheckbox/FieldNumber (UIP-INPUT-FORM_FIELD_GROUP + UIP-INPUT-INPUT_FIELD)
- `cobertura`: grupos de campos com `Legend` + `HelpText`; grid responsivo; validação Blazor nativa;
- `nota`: 9;
- `justificativa`: ponto forte da lib — formulário com grupos e campos é cobertura excelente.

2. uip-struct-collapsible-section (seções colapsáveis)
- `cobertura`: formulários longos com seções opcionais ou avançadas colapsáveis;
- `nota`: 5;
- `justificativa`: progressividade no formulário via seções colapsáveis manuais.

3. Feedback Style=Danger + ValidationSummary (UIP-INPUT-VALIDATION_SUMMARY)
- `cobertura`: resumo de erros de validação acima do formulário; erros inline por campo;
- `nota`: 8;
- `justificativa`: feedback de erros de validação.

### Zona: Ações

1. Bar + Button + Button (UIP-ACTION-ACTION_BAR)
- `cobertura`: "Salvar" (Primary) + "Cancelar" (Default) + "Excluir" (Danger, se edição); sticky no footer ou no topo;
- `nota`: 9;
- `justificativa`: ações do formulário — direto e de alta qualidade.

2. Modal (UIP-FEEDBACK-CONFIRMATION_DIALOG)
- `cobertura`: confirmação de saída com alterações não salvas; confirmação de exclusão;
- `nota`: 9;
- `justificativa`: diálogos de confirmação.

3. NotificationService / Notification (UIP-FEEDBACK-TOAST_ALERT)
- `cobertura`: "Salvo com sucesso" / "Erro ao salvar" após submissão;
- `nota`: 9;
- `justificativa`: feedback de resultado de operação.

**Descartados**: nenhum.

## Composição completa da página

```razor
@page "/clientes/{Id:int?}"
@code {
    [Parameter] public int? Id { get; set; }

    private ClienteDto model = new();
    private EditContext editContext = default!;
    private bool salvando;
    private bool confirmandoCancelamento;
    private bool isNovo => Id is null;

    protected override async Task OnInitializedAsync()
    {
        editContext = new EditContext(model);
        if (Id is not null)
            model = await Service.ObterAsync(Id.Value);
    }

    private async Task Salvar()
    {
        if (!editContext.Validate()) return;
        salvando = true;
        try
        {
            if (isNovo) await Service.CriarAsync(model);
            else await Service.AtualizarAsync(model);
            NotificationService.Show("Salvo com sucesso.", Themes.Success);
            Nav.NavigateTo("/clientes");
        }
        catch (Exception ex)
        {
            NotificationService.Show($"Erro ao salvar: {ex.Message}", Themes.Danger);
        }
        finally { salvando = false; }
    }

    private void Cancelar()
    {
        if (editContext.IsModified()) confirmandoCancelamento = true;
        else Nav.NavigateTo("/clientes");
    }
}

@* Cabeçalho *@
<Bar AdditionalClasses="mb-6">
    <StartContent>
        <div>
            <Breadcrumb Items="breadcrumbItems" />
            <div class="flex items-center gap-2 mt-1">
                <h1 class="text-lg font-semibold text-dark-700">
                    @(isNovo ? "Novo cliente" : "Editar cliente")
                </h1>
                <Badge Style="@(isNovo ? Themes.Success : Themes.Light)"
                       Text="@(isNovo ? "Novo" : "Edição")" />
            </div>
        </div>
    </StartContent>
    <EndContent>
        @if (!isNovo)
        {
            <Button Style="Themes.Danger" Size="Sizes.Small" Label="Excluir"
                    OnClick="ConfirmarExclusao" />
        }
    </EndContent>
</Bar>

@* Formulário *@
<EditForm EditContext="editContext" OnValidSubmit="Salvar">
    <DataAnnotationsValidator />

    @* Resumo de erros *@
    @if (editContext.GetValidationMessages().Any())
    {
        <Feedback Style="Themes.Danger" AdditionalClasses="mb-4">
            <ChildContent>
                <ValidationSummary />
            </ChildContent>
        </Feedback>
    }

    @* Seção principal *@
    <Box Border="BorderBuilder.Box" AdditionalClasses="p-6 mb-4">
        <FormGroup Legend="Dados do cliente">
            <div class="grid grid-cols-1 sm:grid-cols-2 gap-4">
                <FieldText @bind-Value="model.Nome" Label="Nome" Required />
                <FieldText @bind-Value="model.Email" Label="E-mail" Type="email" Required />
                <FieldText @bind-Value="model.Telefone" Label="Telefone" />
                <FieldSelect @bind-Value="model.Tipo" Label="Tipo" Options="tipoOptions" />
            </div>
        </FormGroup>
    </Box>

    @* Seção de endereço (colapsável) *@
    <Box Border="BorderBuilder.Box" AdditionalClasses="overflow-hidden mb-4">
        <Bar AdditionalClasses="px-4 py-3 cursor-pointer bg-light-50 border-b border-light-200"
             @onclick="() => enderecoExpandido = !enderecoExpandido">
            <StartContent>
                <span class="text-sm font-semibold text-dark-600">Endereço</span>
            </StartContent>
            <EndContent>
                <span class="text-dark-400 text-xs">@(enderecoExpandido ? "▲" : "▼")</span>
            </EndContent>
        </Bar>
        @if (enderecoExpandido)
        {
            <div class="p-4">
                <FormGroup>
                    <div class="grid grid-cols-1 sm:grid-cols-3 gap-4">
                        <FieldText @bind-Value="model.Cep" Label="CEP"
                                   AdditionalClasses="sm:col-span-1" />
                        <FieldText @bind-Value="model.Logradouro" Label="Logradouro"
                                   AdditionalClasses="sm:col-span-2" />
                        <FieldText @bind-Value="model.Cidade" Label="Cidade" />
                        <FieldText @bind-Value="model.Estado" Label="Estado" />
                    </div>
                </FormGroup>
            </div>
        }
    </Box>

    @* Ações *@
    <Bar>
        <EndContent>
            <Button Style="Themes.Default" Label="Cancelar"
                    OnClick="Cancelar" Disabled="@salvando" />
            <Button Style="Themes.Primary" Label="@(salvando ? "Salvando..." : "Salvar")"
                    Type="submit" Disabled="@salvando" />
        </EndContent>
    </Bar>
</EditForm>

@* Confirmação de saída *@
<Modal Title="Alterações não salvas"
       @bind-IsOpen="confirmandoCancelamento"
       Size="ModalSize.Small">
    <ChildContent>
        <p class="text-sm text-dark-600">
            Existem alterações não salvas. Deseja sair sem salvar?
        </p>
    </ChildContent>
    <FooterContent>
        <Button Style="Themes.Default" Label="Continuar editando"
                OnClick="() => confirmandoCancelamento = false" />
        <Button Style="Themes.Danger" Label="Sair sem salvar"
                OnClick="() => Nav.NavigateTo(\"/clientes\")" />
    </FooterContent>
</Modal>
```

## Decisão de uso

- `nota geral`: 9;
- `limitações`: seções colapsáveis são manuais (sem animação); formulários muito longos com dependências entre campos requerem lógica C# do app; upload de arquivo requer `InputFile` separado;
- `recomendação`: `usar direto`
- `justificativa geral`:
  - `EditForm` + `FormGroup` + `FieldText/Select/Checkbox` + `DataAnnotationsValidator` cobrem PP-FORM com excelente qualidade nativa;
  - `Modal` + `NotificationService` + `Bar` com ações completam o padrão com confirmação e feedback;
  - Nota 9 reflete PP-FORM como o page pattern mais bem suportado pela lib.
