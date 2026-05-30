# UIP-SYSTEM-NOTIFICATION_CENTER - Blueprint resumido

## Pattern

UIP-SYSTEM-NOTIFICATION_CENTER — Notification Center — ver `uip-system-notification-center.ui-map.md`

## Gap coberto

A lib tem `Notification` para toasts mas não tem centro de notificações persistente. O gap é orientar: `OffCanvas` como drawer de notificações, `Badge` no trigger do header, e `Stack + Box` para a lista de itens com estado lido/não lido.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `IconButton(Bell) + Badge` no `AppTopBar` como trigger; `OffCanvas("notif-center")` com `Stack + Box` por notificação; `bg-primary-50` para não lidas; `Notification` toast para evento novo em tempo real.

## Componentes usados

- `OffCanvas` — papel: principal (painel de notificações) — ver `modal.sample.md`
- `Badge` — papel: composição (contador de não lidas no trigger) — ver `badge.sample.md`
- `IconButton` — papel: composição (trigger sino) — ver `button.sample.md`
- `Stack` — papel: composição (lista de notificações) — ver `stack.sample.md`
- `Box` — papel: composição (item de notificação) — ver `box.sample.md`
- `Bar` — papel: composição (header do painel) — ver `bar.sample.md`
- `Feedback` — papel: composição (empty state) — ver `feedback.sample.md`

## Recursos visuais

- `absolute -top-1 -right-1` — badge de contagem sobreposto ao ícone
- `bg-primary-50` — fundo diferenciado para notificação não lida
- `w-2 h-2 rounded-full bg-primary-500` — indicador visual de não lida

## Receita

`IconButton + Badge` no header → `OffCanvas` com `Stack + Box` para lista → `Bar` com "Marcar todas como lidas".

```razor
@inject NotificationCenterService NotifCenter

@code {
    private OffCanvas? notifCenter;
}

@* Trigger no header (ex.: dentro do AppTopBar) *@
<div class="relative">
    <IconButton Icon="WellKnownIcons.Bell" Style="Themes.Default"
                OnClick="async () => await notifCenter!.OpenAsync()" />
    @if (NotifCenter.NaoLidas > 0)
    {
        <Badge Style="Themes.Danger"
               Text="@(NotifCenter.NaoLidas > 99 ? "99+" : NotifCenter.NaoLidas.ToString())"
               AdditionalClasses="absolute -top-1 -right-1 text-xs" />
    }
</div>

@* Painel de notificações *@
<OffCanvas @ref="notifCenter" Id="notif-center" Title="Notificações">
    <ChildContent>
        <Bar AdditionalClasses="mb-4">
            <EndContent>
                <Button Style="Themes.Secondary" Outline=true Size="Sizes.Small"
                        Label="Marcar todas como lidas"
                        Disabled="@(NotifCenter.NaoLidas == 0)"
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
                @foreach (var n in NotifCenter.Notificacoes.OrderByDescending(x => x.DataHora))
                {
                    <Box Border="BorderBuilder.Box"
                         AdditionalClasses="@($"p-3 cursor-pointer hover:shadow-sm {(!n.Lida ? "bg-primary-50" : "")}")"
                         @onclick="() => AbrirNotificacao(n)">
                        <Bar>
                            <StartContent>
                                <div class="flex flex-col gap-0.5 flex-1">
                                    <span class="text-sm @(!n.Lida ? "font-semibold text-dark-700" : "text-dark-600")">
                                        @n.Titulo
                                    </span>
                                    @if (n.Descricao is not null)
                                    {
                                        <span class="text-xs text-dark-400">@n.Descricao</span>
                                    }
                                    <span class="text-xs text-dark-300">
                                        @n.DataHora.ToString("dd/MM HH:mm")
                                    </span>
                                </div>
                            </StartContent>
                            <EndContent>
                                @if (!n.Lida)
                                {
                                    <div class="w-2 h-2 rounded-full bg-primary-500 flex-shrink-0"></div>
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

## Limites

- `NotificationCenterService` é responsabilidade do app — persistência de notificações via API ou estado local;
- Push notifications do browser requerem `Notification API` via JS interop + service worker;
- `OffCanvas` não tem scroll interno automático para lista longa — adicionar `overflow-y-auto max-h-[calc(100vh-8rem)]` no `ChildContent` se necessário.
