# UIP-SYSTEM-PERMISSION_FLOW - Permission Flow

**GAP parcial — sem componente dedicado**

A biblioteca não tem componente de permission flow. Para web, permissões do browser (câmera, localização, notificações) são gerenciadas via JS interop (`navigator.permissions`, `navigator.mediaDevices`). O pré-contexto e tratamento de recusa são responsabilidade do app.

## Componentes

**Principais**: nenhum dedicado.

**Composição**:

1. Modal
- `cobertura`: tela de pré-contexto de permissão antes de chamar o prompt nativo do browser; explica a necessidade da permissão; botão "Permitir" dispara JS interop; botão "Não agora" retorna ao fluxo degradado;
- `nota`: 7;
- `justificativa`: overlay modal como pré-contexto de permissão — correto para o padrão.

2. Feedback (Themes.Warning / Themes.Danger)
- `cobertura`: estado de permissão recusada com mensagem explicativa e CTA para corrigir; estado de funcionalidade degradada;
- `nota`: 6;
- `justificativa`: feedback visual do estado de permissão negada.

3. Button
- `cobertura`: CTA "Abrir configurações" (link para `chrome://settings/content` não é possível, mas instrução textual + link para `about:preferences` no Firefox), CTA "Tentar novamente";
- `nota`: 7;
- `justificativa`: ações de resolução do estado de permissão negada.

**Descartados**: nenhum.

## Esforço de adaptação

- `tipo de adaptação`: composição + JS interop
- `o que precisa ser feito`:
  - Lógica de permissão via JS: `navigator.permissions.query()` para verificar, `navigator.mediaDevices.getUserMedia()` para câmera/microfone;
  - Para localização: `navigator.geolocation.getCurrentPosition()`;
  - Para notificações: `Notification.requestPermission()`;
  - Pré-contexto em `Modal` antes do pedido; feedback em `Feedback` após recusa;
  - Nenhum componente de permissão nativo na lib.

## Como usar

### Pré-contexto de permissão via Modal

```razor
@inject ModalService ModalService
@inject IJSRuntime JS

@code {
    private async Task SolicitarLocalizacao()
    {
        await ModalService.OpenAsync("permissao-localizacao");
    }

    private async Task ConfirmarPermissao()
    {
        await ModalService.CloseAsync("permissao-localizacao");
        await JS.InvokeVoidAsync("requestGeolocation", DotNetObjectReference.Create(this));
    }

    [JSInvokable]
    public void OnPermissaoRecusada() => permissaoRecusada = true;
    
    private bool permissaoRecusada = false;
}

<Modal Id="permissao-localizacao" Title="Precisamos da sua localização">
    <ChildContent>
        <Stack Gap="Gaps.Medium">
            <Feedback Style="Themes.Info" Text="Para mostrar lojas próximas a você, precisamos de acesso à sua localização. Seus dados não serão compartilhados." />
            <Bar>
                <EndContent>
                    <Button Style="Themes.Secondary" Outline=true Label="Não agora"
                            OnClick="() => ModalService.CloseAsync("permissao-localizacao")" />
                    <Button Style="Themes.Primary" Label="Permitir localização"
                            OnClick="ConfirmarPermissao" />
                </EndContent>
            </Bar>
        </Stack>
    </ChildContent>
</Modal>

@if (permissaoRecusada)
{
    <Feedback Style="Themes.Warning" 
              Text="Localização não disponível. Ative nas configurações do navegador para ver lojas próximas." />
}
```

## Decisão de uso

- `nota geral`: 3;
- `limitações`: sem componente de permission flow nativo; toda lógica de permissão requer JS interop; impossível abrir settings do navegador programaticamente via web; tratamento de estados (recusada, recusada permanente, revogada) é responsabilidade do app;
- `recomendação`: `usar com adaptação`
- `justificativa geral`:
  - `Modal` + `Feedback` + `Button` cobrem o fluxo de pré-contexto e tratamento de recusa;
  - A lib não tem abstração para permissões — JS interop é obrigatório para o pedido nativo;
  - Nota 3 reflete cobertura apenas visual/estrutural, sem lógica de permissão nativa.
