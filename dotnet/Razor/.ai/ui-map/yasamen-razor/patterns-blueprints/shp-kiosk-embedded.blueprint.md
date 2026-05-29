# SHP-KIOSK_EMBEDDED - Blueprint completo

## Pattern

SHP-KIOSK_EMBEDDED — Kiosk/Embedded — ver `shp-kiosk-embedded.ui-map.md`

## Gap coberto

A lib cobre fluxos transacionais mas não tem shell de kiosk. O gap é coordenar: layout full-screen sem `AppLayout`; chrome mínimo (header com logo + relógio + Sair); conteúdo centralizado em `max-w-2xl`; timeout de sessão por inatividade com `Timer?`; botões de toque com padding aumentado via `AdditionalClasses`; integração com hardware periférico via `IJSRuntime` (scanner, impressora) fora do scope da lib.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `KioskLayout.razor` com `div.min-h-screen.flex.flex-col.select-none @onclick="ResetarTimeout"`; header `bg-primary-600` com `Bar`; `main.flex-1.flex.items-center.justify-center` com `div.w-full.max-w-2xl`; footer com instrução de uso; `Timer?` para timeout de 5 min de inatividade; `AppLayout` NÃO deve ser usado.
- `eixos cobertos sem componente novo`:
  - shell → HTML `div.min-h-screen.flex.flex-col` + `Bar(header)`;
  - timeout → `Timer?` C# com `InvokeAsync(() => EncerrarSessao())`;
  - fluxo guiado → `PP-WIZARD` composto com `FormGroup + FieldText/FieldSelect`;
  - CTA grande → `Button(AdditionalClasses="text-lg py-4 px-8")`;
  - confirmação crítica → `Modal`;
  - estados → `Feedback(processando/sucesso/erro)`;
  - alertas de hardware → `Feedback(Danger)`.

## Componentes usados

- `Bar` — papel: principal (header do kiosk) — ver `bar.sample.md`
- `Button` — papel: composição (CTA principal, Sair) — ver `button.sample.md`
- `Container + Slot` — papel: composição (grade de opções na tela inicial) — ver `bar.sample.md`
- `Box` — papel: composição (cards de opção, área de conteúdo) — ver `box.sample.md`
- `Modal` — papel: composição (confirmação crítica antes de finalizar) — ver `modal.sample.md`
- `Feedback` — papel: composição (processando, sucesso, erro, hardware offline) — ver `feedback.sample.md`
- `Stack` — papel: composição (agrupamento de campos no fluxo) — ver `bar.sample.md`

## Recursos visuais

- `min-h-screen flex flex-col select-none` — shell full-screen sem seleção de texto
- `bg-primary-600 text-white px-8 py-4` — header de kiosk em cor de destaque
- `flex-1 flex flex-col items-center justify-center px-8 py-12` — área de conteúdo centralizada verticalmente
- `w-full max-w-2xl` — largura máxima do conteúdo centrado
- `text-lg py-4 px-8` — botão de toque oversized
- `p-8 cursor-pointer hover:shadow-lg transition-shadow hover:border-primary-300` — card de opção para toque
- `text-4xl font-bold text-dark-800` — título principal de boas-vindas

## Receita

### Estrutura base

`KioskLayout.razor` com header, conteúdo centralizado, footer e timeout de sessão.

```razor
@* KioskLayout.razor — shell de Kiosk/Embedded *@
@inherits LayoutComponentBase
@inject NavigationManager Nav
@implements IDisposable

@code {
    private bool sessaoAtiva;
    private Timer? _timeoutTimer;

    protected override void OnInitialized() => ResetarTimeout();

    private void ResetarTimeout()
    {
        _timeoutTimer?.Dispose();
        _timeoutTimer = new Timer(_ =>
        {
            InvokeAsync(() =>
            {
                if (sessaoAtiva) EncerrarSessao();
            });
        }, null, TimeSpan.FromMinutes(5), Timeout.InfiniteTimeSpan);
    }

    private void EncerrarSessao()
    {
        sessaoAtiva = false;
        Nav.NavigateTo("/kiosk");
        StateHasChanged();
    }

    public void Dispose() => _timeoutTimer?.Dispose();
}

<div class="min-h-screen bg-light-50 flex flex-col select-none"
     @onclick="ResetarTimeout">

    @* Header mínimo *@
    <header class="bg-primary-600 text-white px-8 py-4 flex-shrink-0">
        <Bar>
            <StartContent>
                <div class="flex items-center gap-3">
                    <div class="w-10 h-10 rounded-lg bg-white/20 flex items-center
                                justify-center text-white font-bold text-lg">
                        K
                    </div>
                    <span class="font-bold text-xl">Autoatendimento</span>
                </div>
            </StartContent>
            <EndContent>
                <span class="text-sm text-white/70">@DateTime.Now.ToString("HH:mm")</span>
                @if (sessaoAtiva)
                {
                    <Button Style="Themes.Default" Label="Sair"
                            AdditionalClasses="bg-white/20 text-white border-white/30"
                            OnClick="EncerrarSessao" />
                }
            </EndContent>
        </Bar>
    </header>

    @* Área de conteúdo centralizada *@
    <main class="flex-1 flex flex-col items-center justify-center px-8 py-12">
        <div class="w-full max-w-2xl">
            @Body
        </div>
    </main>

    @* Footer com instruções *@
    <footer class="bg-white border-t border-light-200 px-8 py-3 text-center flex-shrink-0">
        <p class="text-sm text-dark-400">
            Toque na tela para começar • Em caso de dúvida, chame um atendente
        </p>
    </footer>
</div>
```

### Cenários de composição

#### Tela inicial com grade de opções

```razor
@* Página inicial do kiosk *@
@page "/kiosk"
@layout KioskLayout

<div class="text-center">
    <h1 class="text-4xl font-bold text-dark-800 mb-4">Bem-vindo!</h1>
    <p class="text-xl text-dark-400 mb-12">Escolha uma opção para começar</p>

    <Container Columns="2" AdditionalClasses="gap-6">
        <Slot>
            <Box Border="BorderBuilder.Box"
                 AdditionalClasses="p-8 cursor-pointer hover:shadow-lg transition-shadow
                                   hover:border-primary-300 text-center"
                 @onclick='() => Nav.NavigateTo("/kiosk/retirada")'>
                <p class="text-5xl mb-4">📦</p>
                <p class="text-xl font-semibold text-dark-700">Retirar pedido</p>
                <p class="text-sm text-dark-400 mt-1">Informe seu código de pedido</p>
            </Box>
        </Slot>
        <Slot>
            <Box Border="BorderBuilder.Box"
                 AdditionalClasses="p-8 cursor-pointer hover:shadow-lg transition-shadow
                                   hover:border-primary-300 text-center"
                 @onclick='() => Nav.NavigateTo("/kiosk/agendamento")'>
                <p class="text-5xl mb-4">📅</p>
                <p class="text-xl font-semibold text-dark-700">Agendar serviço</p>
                <p class="text-sm text-dark-400 mt-1">Escolha data e horário</p>
            </Box>
        </Slot>
    </Container>
</div>
```

#### Etapa de fluxo guiado com CTA oversized

```razor
@* Etapa de identificação — usa PP-WIZARD internamente *@
@page "/kiosk/retirada"
@layout KioskLayout

@code {
    private RetiradaModel model = new();
    private bool processando;
    private bool concluido;
    private string? erro;

    private async Task Confirmar()
    {
        await ModalService.OpenAsync("confirmar-retirada");
    }

    private async Task ExecutarRetirada()
    {
        await ModalService.CloseAsync("confirmar-retirada");
        processando = true;
        try
        {
            await RetiradaService.ProcessarAsync(model.Codigo);
            concluido = true;
            // Retornar à tela inicial após 5s
            await Task.Delay(5000);
            Nav.NavigateTo("/kiosk");
        }
        catch
        {
            erro = "Código não encontrado. Verifique e tente novamente.";
        }
        finally { processando = false; }
    }
}

@if (concluido)
{
    <Feedback Style="Themes.Success" Text="Pedido liberado! Dirija-se ao balcão de retirada." />
}
else if (processando)
{
    <div class="text-center py-12">
        <Feedback Style="Themes.Info" Text="Processando... Aguarde." />
    </div>
}
else
{
    <div class="text-center mb-8">
        <h2 class="text-3xl font-bold text-dark-800 mb-2">Retirar pedido</h2>
        <p class="text-lg text-dark-400">Digite o código que você recebeu por e-mail ou SMS</p>
    </div>

    @if (erro is not null)
    {
        <Feedback Style="Themes.Danger" Text="@erro" AdditionalClasses="mb-6" />
    }

    <EditForm Model="model" OnValidSubmit="Confirmar">
        <DataAnnotationsValidator />
        <Stack Gap="Gaps.Large">
            <FormGroup Label="Código do pedido">
                <FieldText @bind-Value="model.Codigo"
                           Placeholder="Ex: ABC-12345"
                           AdditionalClasses="text-2xl text-center py-4 tracking-widest" />
            </FormGroup>
            <div class="flex gap-4">
                <Button Style="Themes.Default" Label="Voltar"
                        AdditionalClasses="flex-1 text-lg py-4"
                        OnClick='() => Nav.NavigateTo("/kiosk")' />
                <Button Style="Themes.Primary" Label="Continuar"
                        AdditionalClasses="flex-1 text-lg py-4"
                        Type="submit" />
            </div>
        </Stack>
    </EditForm>
}

@* Confirmação crítica *@
<Modal Id="confirmar-retirada" Title="Confirmar retirada">
    <ChildContent>
        <p class="text-base text-dark-600">
            Código <strong>@model.Codigo</strong>. Confirma a retirada do pedido?
        </p>
    </ChildContent>
    <FooterContent>
        <Button Style="Themes.Default" Label="Cancelar"
                AdditionalClasses="text-lg py-3 px-6"
                OnClick='() => ModalService.CloseAsync("confirmar-retirada")' />
        <Button Style="Themes.Primary" Label="Confirmar"
                AdditionalClasses="text-lg py-3 px-6"
                OnClick="ExecutarRetirada" />
    </FooterContent>
</Modal>
```

#### Alerta de hardware indisponível

```razor
@* Verificação de periféricos na inicialização *@
@code {
    private bool impressoraOnline = true;

    protected override async Task OnInitializedAsync()
    {
        impressoraOnline = await JS.InvokeAsync<bool>("kiosk.checkPrinter");
    }
}

@if (!impressoraOnline)
{
    <Feedback Style="Themes.Danger"
              Text="Impressora offline. Recibos não serão emitidos nesta sessão." />
}
```

### Estados de página

- `processando`: `Feedback(Info)` centralizado com texto "Processando... Aguarde." em vez de todo o formulário;
- `concluido`: `Feedback(Success)` com instrução clara ao usuário + redirecionamento automático após 5s;
- `erro de operação`: `Feedback(Danger)` acima do formulário, mantendo campos editáveis para nova tentativa;
- `hardware offline`: `Feedback(Danger)` persistente no topo da área de conteúdo, não bloqueante;
- `timeout de sessão`: redirecionamento automático para `/kiosk` via `Timer?` após 5 min sem interação.

## Limites

- **Shell de kiosk é GAP estrutural** — sem `KioskLayout` nativo; todo o chrome é HTML manual com `Bar`;
- `AppLayout` NÃO deve ser usado — adiciona sidebar e chrome de app operacional incompatíveis com kiosk;
- Timeout de sessão por `Timer?` é lógica C# manual — `IDisposable` obrigatório no layout para evitar leak;
- Botões de toque oversized requerem `AdditionalClasses="text-lg py-4 px-8"` — sem parâmetro de tamanho dedicado para kiosk;
- Integração com hardware (scanner, impressora térmica, leitor de cartão) via `IJSRuntime` — APIs de browser limitadas; requer JS externo específico para cada periférico;
- Relógio no header (`@DateTime.Now`) não atualiza automaticamente — requer `Timer` ou `@onclick` para refresh;
- Stepper de progresso entre etapas (PP-WIZARD) requer CSS manual — sem componente nativo;
- `Container(Columns=2)` na tela inicial: em displays muito estreitos, colapsa para 1 coluna — adequado para kiosks com tela ≥ 800px.

### Responsividade

Kiosk é tipicamente display dedicado landscape (1024×768 ou superior). Em telas menores: `Container(Columns=2)` colapsa para 1 coluna automaticamente. `max-w-2xl` garante conteúdo legível em qualquer escala. Não adaptado para mobile — exibir aviso se `User-Agent` ou viewport detectar device móvel pessoal.
