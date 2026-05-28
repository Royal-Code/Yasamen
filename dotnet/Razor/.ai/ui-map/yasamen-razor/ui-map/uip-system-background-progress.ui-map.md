# UIP-SYSTEM-BACKGROUND_PROGRESS - Background Progress

**GAP parcial — sem componente dedicado**

A biblioteca não tem componente de progresso em background. Requer composição com `Notification`/`Feedback` + `ProgressBar` (quando disponível) ou barra de progresso HTML + controles de estado em serviço C# compartilhado.

## Componentes

**Principais**: nenhum dedicado.

**Composição**:

1. Notification
- `cobertura`: notificação de progresso inicial ("Upload iniciado"), conclusão ("Export concluído") e erro ("Falha ao exportar — Tentar novamente"); `NotificationService` para disparar sem bloquear a tela;
- `nota`: 7;
- `justificativa`: comunicação não bloqueante de mudança de estado da operação longa.

2. Feedback (no header/shell)
- `cobertura`: banner persistente de operação em andamento com porcentagem ou spinner; botão "Cancelar";
- `nota`: 5;
- `justificativa`: indicador persistente no shell — sem barra de progresso determinada nativa.

3. Bar + Button
- `cobertura`: mini-painel de progresso no header ou rodapé do shell; "X de N itens processados"; botão Cancelar/Pausar;
- `nota`: 6;
- `justificativa`: estrutura de status bar de operação de background.

**Descartados**: nenhum.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `barra de progresso determinada (0-100%)`: sem componente nativo — usar `<div class="bg-primary-500 h-1 rounded transition-all" style="width:@(progresso)%">`;
  - `fila de operações`: state management no app (serviço C# singleton com lista de jobs);
  - `persistência entre navegações`: serviço singleton ou state no `AppLayout`;
  - `cancelamento via AbortController`: JS interop para uploads/downloads.

- `tipo de adaptação`: composição + estado de serviço no app
- `o que precisa ser feito`:
  - Serviço C# (singleton `ProgressService`) com eventos `OnProgressChanged`;
  - `AppLayout` subscreve ao serviço e renderiza banner/mini-painel;
  - `Notification` para notificar conclusão ou erro após sair da tela.

## Como usar

### Banner de progresso no AppLayout

```razor
@* No AppLayout ou componente raiz: *@
@inject ProgressService ProgressService
@implements IDisposable

@code {
    protected override void OnInitialized()
        => ProgressService.OnChanged += StateHasChanged;
    public void Dispose()
        => ProgressService.OnChanged -= StateHasChanged;
}

@if (ProgressService.HaOperacaoAtiva)
{
    <div class="fixed top-0 left-0 right-0 z-notify">
        <div class="bg-primary-500 h-1 transition-all duration-300"
             style="width:@(ProgressService.Progresso)%"></div>
        <Bar AdditionalClasses="bg-primary-50 border-b border-primary-200 px-4 py-1">
            <StartContent>
                <span class="text-xs text-primary-700">@ProgressService.Descricao</span>
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
}
```

### Toast de conclusão

```razor
@* Após conclusão ou erro no serviço: *@
@inject NotificationService NotificationService

// Sucesso:
NotificationService.ShowSuccess("Export concluído", "relatorio-2024.xlsx está pronto.");

// Erro com retry:
NotificationService.ShowError("Falha no upload", "Clique para tentar novamente.");
```

## Decisão de uso

- `nota geral`: 3;
- `limitações`: sem barra de progresso nativa determinada; sem fila de operações nativa; persistência entre navegações requer serviço C# singleton; cancelamento de requisições HTTP requer CancellationToken + AbortController;
- `recomendação`: `usar com adaptação`
- `justificativa geral`:
  - `Notification` + `Bar` + CSS de barra de progresso cobrem o padrão visual;
  - A lógica de background é responsabilidade do serviço de app — a lib contribui com primitivos visuais;
  - Nota 3 reflete cobertura visual básica sem abstração de operação longa nativa.
