# PP-DETAIL - Detail

## Componentes por zona funcional

### Zona: Cabeçalho (UIP-CONTENT-CONTENT_HEADER)

1. Bar + Breadcrumb + Badge
- `cobertura`: título, breadcrumb de retorno, badge de status; ações principais inline;
- `nota`: 9;
- `justificativa`: cabeçalho completo de página de detalhe.

2. Breadcrumb (UIP-NAV-BREADCRUMB)
- `cobertura`: localização na hierarquia + link de retorno à coleção;
- `nota`: 9;
- `justificativa`: orientação de navegação.

### Zona: Detalhe

1. Box + Bar + dl/dd (UIP-CONTENT-DETAIL_BLOCK)
- `cobertura`: atributos em grid com rótulo/valor; agrupados por seção com `Box`;
- `nota`: 8;
- `justificativa`: apresentação estruturada de atributos da entidade.

2. uip-struct-collapsible-section (seções colapsáveis)
- `cobertura`: seções opcionais ou secundárias colapsáveis (histórico, metadados, etc.);
- `nota`: 5;
- `justificativa`: seções de detalhe progressivas.

3. Box + `@((MarkupString)html)` (UIP-CONTENT-RICH_TEXT_BLOCK)
- `cobertura`: campo de texto rico, notas, descrição longa;
- `nota`: 6;
- `justificativa`: conteúdo textual longo na entidade.

4. Stack + Box/Bar (UIP-CONTENT-COMMENT_THREAD)
- `cobertura`: comentários ou histórico de atividade relacionado à entidade;
- `nota`: 5;
- `justificativa`: seção de comentários na entidade.

### Zona: Ações

1. Bar + Button + DropIconButton (UIP-ACTION-ACTION_BAR)
- `cobertura`: ação primária (Editar) + ações secundárias (Excluir, Exportar, Duplicar);
- `nota`: 9;
- `justificativa`: ações sobre a entidade visualizada.

2. Modal (UIP-FEEDBACK-CONFIRMATION_DIALOG)
- `cobertura`: confirmação de exclusão;
- `nota`: 9;
- `justificativa`: confirmação de ação destrutiva.

### Zona: Estados

1. Feedback + animate-pulse (UIP-FEEDBACK-LOADING_STATE)
- `cobertura`: skeleton de atributos durante carregamento;
- `nota`: 7;
- `justificativa`: estado de loading da entidade.

2. Feedback Style=Danger (UIP-FEEDBACK-ERROR_STATE)
- `cobertura`: "Entidade não encontrada" ou "Erro ao carregar";
- `nota`: 8;
- `justificativa`: erro de carregamento.

**Descartados**: nenhum.

## Composição completa da página

```razor
@page "/clientes/{Id:int}"
@code {
    [Parameter] public int Id { get; set; }

    private ClienteDto? cliente;
    private bool carregando = true;
    private string? erro;
    private bool confirmandoExclusao;
    private bool abaAtividade;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            cliente = await Service.ObterAsync(Id);
        }
        catch (NotFoundException)
        {
            erro = "Cliente não encontrado.";
        }
        catch (Exception ex)
        {
            erro = $"Erro ao carregar: {ex.Message}";
        }
        finally { carregando = false; }
    }

    private async Task Excluir()
    {
        await Service.ExcluirAsync(Id);
        Nav.NavigateTo("/clientes");
    }
}

@* Cabeçalho *@
<Bar AdditionalClasses="mb-6">
    <StartContent>
        <div>
            <Breadcrumb Items='new[] { ("Clientes", "/clientes"), ("Detalhe", null) }' />
            @if (cliente is not null)
            {
                <div class="flex items-center gap-2 mt-1">
                    <h1 class="text-xl font-semibold text-dark-700">@cliente.Nome</h1>
                    <Badge Style="@(cliente.Ativo ? Themes.Success : Themes.Light)"
                           Text="@(cliente.Ativo ? "Ativo" : "Inativo")" />
                </div>
            }
            else if (carregando)
            {
                <div class="animate-pulse h-6 w-48 bg-light-200 rounded mt-1"></div>
            }
        </div>
    </StartContent>
    @if (cliente is not null)
    {
        <EndContent>
            <Button Style="Themes.Primary" Label="Editar"
                    OnClick='() => Nav.NavigateTo($"/clientes/{Id}/editar")' />
            <DropIconButton Icon="WellKnownIcons.MoreVertical" Style="Themes.Default">
                <DropItem Label="Duplicar" OnClick="Duplicar" />
                <DropItem Label="Exportar" OnClick="Exportar" />
                <hr class="my-1 border-light-200" />
                <DropItem Label="Excluir" Style="Themes.Danger"
                          OnClick="() => confirmandoExclusao = true" />
            </DropIconButton>
        </EndContent>
    }
</Bar>

@* Conteúdo *@
@if (carregando)
{
    <Stack Gap="Gaps.Medium">
        @for (int i = 0; i < 3; i++)
        {
            <Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
                <div class="space-y-3 animate-pulse">
                    <div class="h-4 bg-light-200 rounded w-1/4"></div>
                    <div class="grid grid-cols-2 gap-3">
                        @for (int j = 0; j < 4; j++)
                        {
                            <div class="h-10 bg-light-100 rounded"></div>
                        }
                    </div>
                </div>
            </Box>
        }
    </Stack>
}
else if (erro is not null)
{
    <Feedback Style="Themes.Danger" Text="@erro">
        <ChildContent>
            <Button Style="Themes.Default" Size="Sizes.Small" Label="Voltar"
                    OnClick='() => Nav.NavigateTo("/clientes")' />
        </ChildContent>
    </Feedback>
}
else if (cliente is not null)
{
    <Stack Gap="Gaps.Medium">
        @* Dados principais *@
        <Box Border="BorderBuilder.Box" AdditionalClasses="p-5">
            <h2 class="text-sm font-semibold text-dark-500 uppercase tracking-wide mb-4">
                Dados do cliente
            </h2>
            <dl class="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-x-6 gap-y-4 text-sm">
                <div>
                    <dt class="text-dark-400 text-xs mb-0.5">E-mail</dt>
                    <dd class="text-dark-600 font-medium">@cliente.Email</dd>
                </div>
                <div>
                    <dt class="text-dark-400 text-xs mb-0.5">Telefone</dt>
                    <dd class="text-dark-600">@cliente.Telefone</dd>
                </div>
                <div>
                    <dt class="text-dark-400 text-xs mb-0.5">Tipo</dt>
                    <dd><Badge Style="Themes.Light" Text="@cliente.Tipo" /></dd>
                </div>
                <div>
                    <dt class="text-dark-400 text-xs mb-0.5">Cadastrado em</dt>
                    <dd class="text-dark-600">@cliente.CriadoEm.ToString("dd/MM/yyyy")</dd>
                </div>
                <div>
                    <dt class="text-dark-400 text-xs mb-0.5">Última atualização</dt>
                    <dd class="text-dark-600">@cliente.AtualizadoEm.ToString("dd/MM/yyyy HH:mm")</dd>
                </div>
            </dl>
        </Box>

        @* Notas / texto rico *@
        @if (!string.IsNullOrEmpty(cliente.Observacoes))
        {
            <Box Border="BorderBuilder.Box" AdditionalClasses="p-5">
                <h2 class="text-sm font-semibold text-dark-500 uppercase tracking-wide mb-3">
                    Observações
                </h2>
                <div class="text-sm text-dark-600 prose prose-sm max-w-none">
                    @((MarkupString)cliente.Observacoes)
                </div>
            </Box>
        }

        @* Relacionamentos *@
        @if (cliente.Pedidos?.Any() == true)
        {
            <Box Border="BorderBuilder.Box" AdditionalClasses="overflow-hidden">
                <Bar AdditionalClasses="px-4 py-3 border-b border-light-200">
                    <StartContent>
                        <span class="text-sm font-semibold text-dark-600">Pedidos</span>
                    </StartContent>
                    <EndContent>
                        <Badge Style="Themes.Light" Text="@cliente.Pedidos.Count.ToString()" />
                        <a href="/pedidos?clienteId=@Id"
                           class="text-xs text-primary-600 hover:underline">
                            Ver todos
                        </a>
                    </EndContent>
                </Bar>
                <Stack Gap="Gaps.None">
                    @foreach (var pedido in cliente.Pedidos.Take(5))
                    {
                        <div class="border-b border-light-100 last:border-0">
                            <Bar AdditionalClasses="px-4 py-2 hover:bg-light-50 cursor-pointer"
                                 @onclick='() => Nav.NavigateTo($"/pedidos/{pedido.Id}")'>
                                <StartContent>
                                    <div>
                                        <p class="text-xs font-medium text-dark-600">#@pedido.Numero</p>
                                        <p class="text-xs text-dark-400">@pedido.Data.ToString("dd/MM/yyyy")</p>
                                    </div>
                                </StartContent>
                                <EndContent>
                                    <Badge Style="@pedido.StatusTema" Text="@pedido.Status" />
                                    <span class="text-xs font-medium text-dark-600">
                                        @pedido.Total.ToString("C")
                                    </span>
                                </EndContent>
                            </Bar>
                        </div>
                    }
                </Stack>
            </Box>
        }
    </Stack>
}

@* Confirmação de exclusão *@
<Modal Title="Excluir cliente"
       @bind-IsOpen="confirmandoExclusao"
       Size="ModalSize.Small">
    <ChildContent>
        <p class="text-sm text-dark-600">
            Tem certeza que deseja excluir <strong>@cliente?.Nome</strong>?
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

- `nota geral`: 8;
- `limitações`: seções colapsáveis são CSS/C# manual; abas de seção de detalhe requerem composição manual (UIP-NAV-TABS GAP);
- `recomendação`: `usar por composição`
- `justificativa geral`:
  - `Bar` + `Breadcrumb` + `Badge` + `Box` + `dl/dd` cobrem PP-DETAIL com qualidade alta;
  - `Modal` de confirmação + `NotificationService` completam o ciclo de ações;
  - Nota 8 reflete excelente cobertura — PP-DETAIL é muito bem suportado pela lib.
