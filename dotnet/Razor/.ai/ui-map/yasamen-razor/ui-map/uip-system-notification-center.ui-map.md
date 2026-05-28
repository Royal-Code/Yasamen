# UIP-SYSTEM-NOTIFICATION_CENTER - Notification Center

**GAP parcial — sem componente dedicado**

A biblioteca tem `Notification` para toasts efêmeros, mas não tem componente de centro de notificações persistente. Requer composição com `OffCanvas`/`Modal` + lista manual de notificações.

## Componentes

**Principais**: nenhum dedicado para centro persistente.

**Composição**:

1. OffCanvas
- `cobertura`: painel lateral deslizante para lista de notificações persistentes; `OffCanvasService` para abrir/fechar; `Title` "Notificações"; conteúdo scrollável;
- `nota`: 7;
- `justificativa`: drawer lateral como notification center — padrão correto para notificações persistentes no shell.

2. Badge (no trigger do shell)
- `cobertura`: indicador de não lidas no ícone do sino no header; `Themes.Danger` para badge de contagem;
- `nota`: 7;
- `justificativa`: badge de contagem de não lidas — elemento esperado no trigger do centro.

3. Notification (Themes.*)
- `cobertura`: toast efêmero para anunciar novo evento; `NotificationService.ShowSuccess/Warning/Error`;
- `nota`: 8;
- `justificativa`: anúncio imediato de nova notificação — complementa o centro persistente.

4. Bar + Button
- `cobertura`: header do painel de notificações com "Marcar todas como lidas" e filtro de tipo;
- `nota`: 7;
- `justificativa`: controles do centro de notificações.

5. Box / Stack
- `cobertura`: item de notificação individual — não lido (fundo diferenciado), lida, com ação de clique;
- `nota`: 6;
- `justificativa`: item de notificação como card clicável.

**Descartados**: nenhum.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `persistência de notificações`: estado no serviço singleton ou API — responsabilidade do app;
  - `agrupamento por tipo`: filtro manual via estado C# no painel;
  - `deep link por notificação`: `NavigationManager.NavigateTo(item.Url)` ao clicar;
  - `push notifications do browser`: `Notification API` via JS interop + service worker.

- `tipo de adaptação`: composição + estado de serviço no app
- `o que precisa ser feito`:
  - `OffCanvas` como container do centro; `Badge` no trigger do header com contagem de não lidas;
  - `Notification` toast para evento novo; lista de notificações com `Stack` + `Box` por item;
  - Estado de lido/não lido + ações gerenciados pelo serviço de app.

## Como usar

### Trigger no header com badge

```razor
@inject NotificationCenterService NotifCenter

<div class="relative">
    <IconButton Icon="WellKnownIcons.Bell" Style="Themes.Default"
                OnClick="() => OffCanvasService.OpenAsync("notif-center")" />
    @if (NotifCenter.NaoLidas > 0)
    {
        <Badge Style="Themes.Danger" Text="@NotifCenter.NaoLidas.ToString()"
               AdditionalClasses="absolute -top-1 -right-1 text-xs" />
    }
</div>
```

### Painel de notificações (OffCanvas)

```razor
<OffCanvas Id="notif-center" Title="Notificações" Position="OffCanvasPosition.Right">
    <ChildContent>
        <Bar AdditionalClasses="mb-4">
            <EndContent>
                <Button Style="Themes.Secondary" Outline=true Size="Sizes.Small"
                        Label="Marcar todas como lidas"
                        OnClick="NotifCenter.MarcarTodasComoLidas" />
            </EndContent>
        </Bar>

        @if (!NotifCenter.Notificacoes.Any())
        {
            <Feedback Style="Themes.Light" Text="Nenhuma notificação." />
        }
        else
        {
            <Stack Gap="Gaps.Small">
                @foreach (var n in NotifCenter.Notificacoes)
                {
                    <Box Border="BorderBuilder.Box"
                         AdditionalClasses="@(n.Lida ? "p-3" : "p-3 bg-primary-50") cursor-pointer"
                         @onclick="() => AbrirNotificacao(n)">
                        <Bar>
                            <StartContent>
                                <div class="flex flex-col gap-1">
                                    <span class="text-sm @(n.Lida ? "text-dark-600" : "font-semibold text-dark-600")">
                                        @n.Titulo
                                    </span>
                                    <span class="text-xs text-dark-400">@n.Descricao</span>
                                    <span class="text-xs text-dark-300">@n.DataHora.ToString("dd/MM HH:mm")</span>
                                </div>
                            </StartContent>
                            <EndContent>
                                @if (!n.Lida)
                                {
                                    <div class="w-2 h-2 rounded-full bg-primary-500"></div>
                                }
                            </EndContent>
                        </Bar>
                    </Box>
                }
            </Stack>
        }
    </ChildContent>
</OffCanvas>
```

## Decisão de uso

- `nota geral`: 3;
- `limitações`: sem componente de notification center nativo; `OffCanvas` cobre o container mas toda a lista é composição manual; persistência de notificações é responsabilidade do app; push notifications requerem JS interop + service worker;
- `recomendação`: `usar com adaptação`
- `justificativa geral`:
  - `OffCanvas` + `Badge` + `Stack`/`Box` formam um notification center funcional mas completamente manual;
  - `Notification` toast complementa anunciando eventos novos;
  - Nota 3 reflete que apenas o container e primitivos genéricos estão disponíveis — nenhuma abstração de notification center existe na lib.
