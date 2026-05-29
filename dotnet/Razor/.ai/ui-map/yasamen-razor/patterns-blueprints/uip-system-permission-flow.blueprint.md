# UIP-SYSTEM-PERMISSION_FLOW - Blueprint resumido

## Pattern

UIP-SYSTEM-PERMISSION_FLOW — Permission Flow — ver `uip-system-permission-flow.ui-map.md`

## Gap coberto

A lib não tem componente de permission flow. O gap é orientar: `Modal` como pré-contexto antes do pedido nativo do browser, `Feedback(Warning)` para estado de permissão recusada, e JS interop para o pedido efetivo.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `Modal` com `Feedback(Info)` explicando a necessidade + `Button(Permitir)` que dispara JS interop; `Feedback(Warning)` no estado de permissão recusada com instrução textual.

## Componentes usados

- `Modal` — papel: principal (pré-contexto de permissão) — ver `modal.sample.md`
- `Feedback` — papel: composição (estado recusado) — ver `feedback.sample.md`
- `Button` — papel: composição (CTAs) — ver `button.sample.md`
- `Stack` — papel: composição (layout interno do modal) — ver `bar.sample.md`

## Recursos visuais

- `Feedback(Themes.Info/Warning)` — contexto informativo e estado de permissão recusada
- `ModalService.OpenAsync("id")` — abrir pré-contexto antes do pedido nativo

## Receita

`Modal` com pré-contexto → JS interop para pedido nativo → `Feedback(Warning)` se recusado.

```razor
@inject ModalService ModalService
@inject IJSRuntime JS

@code {
    private bool permissaoRecusada;

    private async Task SolicitarLocalizacao()
        => await ModalService.OpenAsync("permissao-localizacao");

    private async Task ConfirmarPermissao()
    {
        await ModalService.CloseAsync("permissao-localizacao");
        try
        {
            await JS.InvokeVoidAsync("navigator.geolocation.getCurrentPosition",
                DotNetObjectReference.Create(this), DotNetObjectReference.Create(this));
        }
        catch
        {
            permissaoRecusada = true;
        }
    }
}

@* Trigger *@
<Button Style="Themes.Secondary" Outline=true
        Label="Usar minha localização"
        Icon="WellKnownIcons.Location"
        OnClick="SolicitarLocalizacao" />

@* Estado de permissão recusada *@
@if (permissaoRecusada)
{
    <Feedback Style="Themes.Warning" AdditionalClasses="mt-2">
        <ChildContent>
            <p class="text-sm font-medium">Localização não disponível</p>
            <p class="text-xs mt-1">
                Para habilitar, acesse as configurações do navegador e permita acesso
                à localização para este site.
            </p>
        </ChildContent>
    </Feedback>
}

@* Modal de pré-contexto *@
<Modal Id="permissao-localizacao" Title="Usar sua localização">
    <ChildContent>
        <Stack Gap="Gaps.Medium">
            <Feedback Style="Themes.Info"
                      Text="Para mostrar opções próximas a você, precisamos de acesso à sua localização. Seus dados não serão compartilhados com terceiros." />
            <Bar>
                <StartContent>
                    <Button Style="Themes.Secondary" Outline=true Label="Não agora"
                            OnClick="() => ModalService.CloseAsync("permissao-localizacao")" />
                </StartContent>
                <EndContent>
                    <Button Style="Themes.Primary" Label="Permitir localização"
                            OnClick="ConfirmarPermissao" />
                </EndContent>
            </Bar>
        </Stack>
    </ChildContent>
</Modal>
```

## Limites

- Não é possível abrir as configurações do navegador programaticamente via web — apenas instrução textual;
- `Themes.Info` pode não existir como tema — verificar tokens disponíveis e usar `Themes.Primary` ou `Themes.Light` como fallback;
- Permissão "blocked permanentemente" vs "negada na sessão" não são distinguíveis com esta abordagem — JS interop com `navigator.permissions.query()` oferece mais granularidade.
