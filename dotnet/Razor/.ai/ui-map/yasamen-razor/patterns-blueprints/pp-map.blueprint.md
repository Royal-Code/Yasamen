# PP-MAP - Blueprint resumido

## Pattern

PP-MAP — Map Page — ver `pp-map.ui-map.md`

## Gap coberto

**GAP crítico (nota 1):** A lib não tem componente de mapa. A superfície cartográfica requer biblioteca externa (Leaflet, Google Maps API, Mapbox, etc.) via JS interop. O gap é orientar: shell da página com toolbar sobreposta via CSS absoluto, `OffCanvas` para painel de detalhe de marcador, `Modal` para formulário de nova localização, e `IconButton` para acionar geolocalização.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `<div id="mapa-container" class="w-full h-full">` como superfície gerenciada por lib externa via `IJSRuntime`; toolbar sobreposta com `div.absolute top-4 left-4 right-4 z-10 + Bar + IconButton`; `OffCanvas("marcador-detalhe")` para painel de detalhe; `Modal("novo-marcador")` para formulário de criação.

## Componentes usados

- `Bar` — papel: composição (toolbar sobreposta e header do painel) — ver `bar.sample.md`
- `OffCanvas` — papel: composição (painel de detalhe do marcador) — ver `modal.sample.md`
- `Modal` — papel: composição (formulário novo marcador) — ver `modal.sample.md`
- `IconButton` — papel: composição (geolocalização, fechar, ações) — ver `button.sample.md`
- `Button` — papel: composição (ações no painel e modal) — ver `button.sample.md`
- `Stack` — papel: composição (lista de campos no painel) — ver `stack.sample.md`
- `Badge` — papel: composição (categoria/status do marcador) — ver `badge.sample.md`
- `TextField` — papel: composição (campos no formulário de novo marcador) — ver `field-text.sample.md`

## Recursos visuais

- `absolute top-4 left-4 right-4 z-10` — toolbar flutuante sobre o mapa
- `rounded-lg shadow-md bg-white/90 backdrop-blur-sm` — toolbar com vidro fosco
- `relative w-full h-full overflow-hidden` — container do mapa ocupando todo o espaço disponível

## Receita

Container de mapa `flex-1`; toolbar absoluta com `Bar`; `OffCanvas` para detalhe; `Modal` para criação; `IJSRuntime` inicializa lib externa no `OnAfterRenderAsync`.

```razor
@page "/mapa"
@inject IJSRuntime JS
@inject MarcadorService MarcadorService
@implements IAsyncDisposable

@code {
    private OffCanvas? marcadorDetalheDrawer;
    private Modal? novoMarcadorModal;
    private MarcadorDto? marcadorSelecionado;
    private bool carregandoLocalizacao;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            // Inicializar lib externa (Leaflet, Google Maps, etc.)
            await JS.InvokeVoidAsync("mapa.inicializar", "mapa-container",
                DotNetObjectReference.Create(this));
        }
    }

    [JSInvokable]
    public async Task OnMarcadorClicado(int marcadorId)
    {
        marcadorSelecionado = await MarcadorService.ObterAsync(marcadorId);
        await marcadorDetalheDrawer!.OpenAsync();
        StateHasChanged();
    }

    private async Task ObterLocalizacaoAtual()
    {
        carregandoLocalizacao = true;
        var coords = await JS.InvokeAsync<double[]>("mapa.obterGeolocalizacao");
        await JS.InvokeVoidAsync("mapa.centralizarEm", coords[0], coords[1]);
        carregandoLocalizacao = false;
    }

    public async ValueTask DisposeAsync()
        => await JS.InvokeVoidAsync("mapa.destruir");
}

@* Shell da página — ocupa toda a viewport *@
<div class="relative w-full h-full overflow-hidden">

    @* Superfície do mapa — gerenciada por biblioteca externa *@
    <div id="mapa-container" class="w-full h-full"></div>

    @* Toolbar sobreposta *@
    <div class="absolute top-4 left-4 right-4 z-10 pointer-events-none">
        <div class="max-w-xl mx-auto pointer-events-auto">
            <Bar AdditionalClasses="rounded-lg shadow-md bg-white/90 backdrop-blur-sm px-3 py-2">
                <StartContent>
                    <span class="text-sm font-semibold text-dark-700">Mapa</span>
                </StartContent>
                <EndContent>
                    <IconButton Icon="WellKnownIcons.MapPin" Style="Themes.Primary"
                                Size="Sizes.Small"
                                OnClick="async () => await novoMarcadorModal!.OpenAsync()"
                                Title="Novo marcador" />
                    <IconButton Icon="WellKnownIcons.Locate" Style="Themes.Default"
                                Size="Sizes.Small"
                                Loading="@carregandoLocalizacao"
                                OnClick="ObterLocalizacaoAtual"
                                Title="Minha localização" />
                </EndContent>
            </Bar>
        </div>
    </div>
</div>

@* Painel de detalhe do marcador *@
<OffCanvas @ref="marcadorDetalheDrawer" Id="marcador-detalhe" Title="@(marcadorSelecionado?.Nome ?? "Marcador")">
    <ChildContent>
        @if (marcadorSelecionado is null)
        {
            <Feedback Style="Themes.Light" Text="Nenhum marcador selecionado." />
        }
        else
        {
            <Stack Gap="Gaps.Small">
                <Bar>
                    <StartContent>
                        <Badge Style="@marcadorSelecionado.CategoriaTema"
                               Text="@marcadorSelecionado.Categoria" />
                    </StartContent>
                </Bar>

                <dl class="space-y-2 text-sm">
                    <div>
                        <dt class="text-xs text-dark-400">Endereço</dt>
                        <dd class="text-dark-600">@marcadorSelecionado.Endereco</dd>
                    </div>
                    @if (marcadorSelecionado.Descricao is not null)
                    {
                        <div>
                            <dt class="text-xs text-dark-400">Descrição</dt>
                            <dd class="text-dark-600">@marcadorSelecionado.Descricao</dd>
                        </div>
                    }
                    <div>
                        <dt class="text-xs text-dark-400">Coordenadas</dt>
                        <dd class="font-mono text-xs text-dark-400">
                            @marcadorSelecionado.Latitude.ToString("F6"),
                            @marcadorSelecionado.Longitude.ToString("F6")
                        </dd>
                    </div>
                </dl>

                <Bar AdditionalClasses="mt-4">
                    <EndContent>
                        <Button Style="Themes.Danger" Outline="true" Size="Sizes.Small"
                                Label="Remover"
                                OnClick="() => RemoverMarcador(marcadorSelecionado.Id)" />
                        <Button Style="Themes.Primary" Size="Sizes.Small"
                                Label="Centralizar no mapa"
                                OnClick="() => CentralizarMarcador(marcadorSelecionado)" />
                    </EndContent>
                </Bar>
            </Stack>
        }
    </ChildContent>
</OffCanvas>

@* Modal de novo marcador *@
<Modal @ref="novoMarcadorModal" Id="novo-marcador" Title="Novo marcador">
    <ChildContent>
        <EditForm Model="novoMarcador" OnValidSubmit="SalvarMarcador">
            <DataAnnotationsValidator />
            <Stack Gap="Gaps.Medium">
                <TextField @bind-Value="novoMarcador.Nome" Label="Nome" required />
                <TextField @bind-Value="novoMarcador.Descricao" Label="Descrição (opcional)" />
                <div class="grid grid-cols-2 gap-3">
                    <TextField @bind-Value="novoMarcador.LatitudeStr" Label="Latitude" />
                    <TextField @bind-Value="novoMarcador.LongitudeStr" Label="Longitude" />
                </div>
            </Stack>
            <Bar AdditionalClasses="mt-4">
                <EndContent>
                    <Button Style="Themes.Default" Label="Cancelar"
                            OnClick="async () => await novoMarcadorModal!.CloseAsync()" />
                    <Button Style="Themes.Primary" Label="Salvar" Type="submit" />
                </EndContent>
            </Bar>
        </EditForm>
    </ChildContent>
</Modal>
```

## Limites

- **Superfície do mapa requer biblioteca JS externa** — Leaflet, Mapbox, Google Maps, etc.; a lib Yasamen não cobre este caso;
- `IJSRuntime` com `[JSInvokable]` é o canal de comunicação entre C# e a lib de mapa — exige arquivo JS de glue code separado;
- Clustering de marcadores, controles de camadas, heatmap e rotas são responsabilidade da lib externa;
- `pointer-events-none / pointer-events-auto` na toolbar é necessário para que cliques passem ao mapa fora dos controles;
- Para mobile: `OffCanvas` pode ser substituído por painel de rodapé com `fixed bottom-0` + `translate-y` para deslizar.
