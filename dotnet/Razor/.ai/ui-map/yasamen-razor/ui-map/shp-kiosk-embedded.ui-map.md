# SHP-KIOSK_EMBEDDED - Kiosk/Embedded

## Componentes por zona funcional

### Zona: Shell (estrutura full-screen)

1. HTML layout full-screen (estrutura raiz)
- `cobertura`: layout `min-h-screen flex flex-col`; sem sidebar de navegação; chrome mínimo; foco na tarefa;
- `nota`: 7;
- `justificativa`: shell simples de kiosk — sem AppLayout (muito complexo para kiosk).

2. Bar mínima (header de sessão)
- `cobertura`: logo, status de sessão ("Bem-vindo"), botão de "Sair / Encerrar sessão";
- `nota`: 8;
- `justificativa`: header mínimo de kiosk.

### Zona: Fluxo guiado (PP-WIZARD)

1. FormGroup + FieldText/FieldSelect/FieldCheckbox
- `cobertura`: etapas do fluxo do kiosk (identificação, seleção, confirmação);
- `nota`: 9;
- `justificativa`: captura de dados do fluxo guiado — excelente cobertura.

2. Indicador de progresso CSS (stepper)
- `cobertura`: progresso entre etapas do fluxo;
- `nota`: 3;
- `justificativa`: stepper manual — sem componente nativo.

3. Button Style=Primary (CTA grande)
- `cobertura`: botão de ação principal com tamanho aumentado (`Size.Large` ou padding manual);
- `nota`: 7;
- `justificativa`: CTA para toque em tela grande — `AdditionalClasses="text-lg py-4 px-8"`.

### Zona: Feedback e Estados

1. Modal (UIP-FEEDBACK-CONFIRMATION_DIALOG)
- `cobertura`: confirmação antes de finalizar transação;
- `nota`: 9;
- `justificativa`: confirmação crítica no kiosk.

2. Feedback (estados de espera e sucesso)
- `cobertura`: "Processando...", "Operação concluída!", "Erro — tente novamente";
- `nota`: 8;
- `justificativa`: estados do kiosk após ação.

3. Feedback Style=Danger (erros de hardware)
- `cobertura`: "Impressora offline", "Leitor de cartão indisponível";
- `nota`: 8;
- `justificativa`: alertas de periférico.

### Zona: Integração hardware

1. IJSRuntime (periféricos)
- `cobertura`: scanner (câmera via JS), impressora (JS Print API), leitor de cartão (serial via browser API);
- `nota`: 3;
- `justificativa`: integração com hardware via JS interop — fora do scope da lib.

**Descartados**: AppLayout, AppSideBar, Breadcrumb (navegação de admin).

## Estrutura de shell

```razor
@* KioskLayout.razor — shell de Kiosk/Embedded *@
@inherits LayoutComponentBase

@code {
    private bool sessaoAtiva;
    private Timer? _timeoutTimer;

    protected override void OnInitialized()
    {
        ResetarTimeout();
    }

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
}

<div class="min-h-screen bg-light-50 flex flex-col select-none"
     @onclick="ResetarTimeout">
    @* Header mínimo *@
    <header class="bg-primary-600 text-white px-8 py-4">
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
                <span class="text-sm text-white/70">
                    @DateTime.Now.ToString("HH:mm")
                </span>
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
    <footer class="bg-white border-t border-light-200 px-8 py-3 text-center">
        <p class="text-sm text-dark-400">
            Toque na tela para começar • Em caso de dúvida, chame um atendente
        </p>
    </footer>
</div>
```

```razor
@* Página inicial do kiosk *@
@page "/kiosk"
@layout KioskLayout

<div class="text-center">
    <h1 class="text-4xl font-bold text-dark-800 mb-4">Bem-vindo!</h1>
    <p class="text-xl text-dark-400 mb-12">
        Escolha uma opção para começar
    </p>

    <Container Columns="2" AdditionalClasses="gap-6">
        <Slot>
            <Box Border="BorderBuilder.Box"
                 AdditionalClasses="p-8 cursor-pointer hover:shadow-lg transition-shadow
                                   hover:border-primary-300 text-center"
                 @onclick='() => Nav.NavigateTo("/kiosk/retirada")'>
                <div class="text-5xl mb-4">📦</div>
                <p class="text-xl font-semibold text-dark-700">Retirar pedido</p>
                <p class="text-sm text-dark-400 mt-1">Informe seu código de pedido</p>
            </Box>
        </Slot>
        <Slot>
            <Box Border="BorderBuilder.Box"
                 AdditionalClasses="p-8 cursor-pointer hover:shadow-lg transition-shadow
                                   hover:border-primary-300 text-center"
                 @onclick='() => Nav.NavigateTo("/kiosk/agendamento")'>
                <div class="text-5xl mb-4">📅</div>
                <p class="text-xl font-semibold text-dark-700">Agendar serviço</p>
                <p class="text-sm text-dark-400 mt-1">Escolha data e horário</p>
            </Box>
        </Slot>
    </Container>
</div>
```

## Decisão de uso

- `nota geral`: 6;
- `limitações`: sem shell de kiosk nativo; botões grandes para toque requerem `AdditionalClasses` de padding manual; timeout de sessão é lógica C# manual; integração com hardware (scanner, impressora) via JS interop externo;
- `recomendação`: `usar por composição`
- `justificativa geral`:
  - `FormGroup` + `Button` (CTA grande) + `Modal` (confirmação) + `Feedback` cobrem os fluxos de kiosk com boa qualidade;
  - O shell minimalista (sem AppLayout) composto com `Bar` + HTML é adequado para displays dedicados;
  - Nota 6 reflete boa cobertura para fluxos transacionais simples — adequado para PP-FORM e PP-WIZARD em kiosk.
