# UIP-SYSTEM-BACKGROUND_PROGRESS - Blueprint resumido

## Pattern

UIP-SYSTEM-BACKGROUND_PROGRESS — Background Progress — ver `uip-system-background-progress.ui-map.md`

## Gap coberto

A lib não tem barra de progresso. O gap é orientar: banner de progresso com barra CSS determinada (`width: @progresso%`) no `AppLayout` via serviço singleton, e `Notification` para comunicar conclusão ou erro ao navegar.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: serviço C# `ProgressService` com evento `OnChanged`; `AppLayout` subscreve e renderiza `Bar + barra CSS` condicionalmente; `Notification` para toast de conclusão/erro.

## Componentes usados

- `Bar` — papel: composição (container do banner de progresso) — ver `bar.sample.md`
- `Button` — papel: composição (cancelar operação) — ver `button.sample.md`

## Recursos visuais

- `bg-primary-500 h-1 transition-all duration-300` — barra de progresso determinada
- `style="width:@(progresso)%"` — progresso percentual
- `fixed top-0 left-0 right-0 z-50` — posicionamento acima de todo conteúdo

## Receita

Serviço singleton `ProgressService` + banner fixo no `AppLayout` + `Notification` para estado final.

```razor
@* AppLayout ou componente raiz *@
@inject ProgressService ProgressService
@inject NotificationService NotificationService
@implements IDisposable

@code {
    protected override void OnInitialized()
        => ProgressService.OnChanged += OnProgressChanged;

    private async void OnProgressChanged()
    {
        await InvokeAsync(StateHasChanged);

        if (ProgressService.Concluido)
        {
            await NotificationService.ShowAsync(new NotificationOptions
            {
                Style = Themes.Success,
                Title = ProgressService.DescricaoConclusao ?? "Operação concluída"
            });
        }
        else if (ProgressService.Erro is not null)
        {
            await NotificationService.ShowAsync(new NotificationOptions
            {
                Style = Themes.Danger,
                Title = "Operação falhou",
                Text = ProgressService.Erro
            });
        }
    }

    public void Dispose() => ProgressService.OnChanged -= OnProgressChanged;
}

@* Banner de progresso *@
@if (ProgressService.HaOperacaoAtiva)
{
    <div class="fixed top-0 left-0 right-0 z-50">
        @* Barra de progresso CSS determinada *@
        <div class="bg-primary-500 h-1 transition-all duration-300"
             style="width:@(ProgressService.Progresso)%"></div>
        @* Banner informativo *@
        <Bar AdditionalClasses="bg-primary-50 border-b border-primary-200 px-4 py-1">
            <StartContent>
                <span class="text-xs text-primary-700">
                    @ProgressService.Descricao
                    @if (ProgressService.Progresso > 0)
                    {
                        <span class="ml-1 text-primary-500">@ProgressService.Progresso%</span>
                    }
                </span>
            </StartContent>
            <EndContent>
                @if (ProgressService.PodeCancelar)
                {
                    <Button Style="Themes.Secondary" Outline=true Size="Sizes.Small"
                            Label="Cancelar" OnClick="ProgressService.Cancelar" />
                }
            </EndContent>
        </Bar>
    </div>
    @* Compensação no conteúdo principal *@
    <div class="pt-8"></div>
}
```

## Limites

- `ProgressService` (serviço singleton) deve ser registrado em `Program.cs` — responsabilidade do app;
- Para progresso indeterminado (sem percentual): usar `animate-pulse` ou spinner em vez da barra determinada;
- Cancelamento de chamada HTTP requer `CancellationToken` passado ao serviço — não coberto aqui.
