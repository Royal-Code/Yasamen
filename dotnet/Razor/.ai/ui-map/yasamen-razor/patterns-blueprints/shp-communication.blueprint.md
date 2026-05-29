# SHP-COMMUNICATION - Blueprint completo

## Pattern

SHP-COMMUNICATION — Communication — ver `shp-communication.ui-map.md`

## Gap coberto

A lib tem `AppLayout` mas não tem shell de comunicação dedicado. O gap é coordenar: sidebar de workspaces/canais (strip estreita `w-16`) + painel de inbox (`w-72`) + área de thread (`flex-1`) em layout `flex h-screen`; responsividade mobile com toggle entre inbox e thread; badge de não lidas no item de nav; e integração com `PP-CONVERSATION` para a thread ativa.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `CommunicationLayout.razor` com `div.flex.h-screen.overflow-hidden`; strip de workspaces `w-16 bg-dark-800`; painel inbox `w-72 flex-col border-r bg-white`; thread `flex-1 flex-col overflow-hidden`; mobile: `mostrarThreadMobile` toggle com `hidden md:flex`; sem `AppLayout` (sidebar de admin não adequada).
- `eixos cobertos sem componente novo`:
  - inbox → `Bar + FieldText(busca) + Stack(itens) + Badge(naoLidas)`;
  - thread → composição de `PP-CONVERSATION` (balões + composição);
  - notificação de nova mensagem → `NotificationService(toast)`;
  - painel contextual → `OffCanvas` com perfil/arquivos;
  - tempo real → SignalR externo ao scope da lib.

## Componentes usados

- `Bar` — papel: principal (header do inbox, header da thread) — ver `bar.sample.md`
- `Badge` — papel: composição (não lidas por thread e global) — ver `badge.sample.md`
- `OffCanvas` — papel: composição (contexto da conversa ativa) — ver `modal.sample.md`
- `FieldText` — papel: composição (busca de conversas) — ver `field-text.sample.md`
- `Stack` — papel: composição (lista de conversas no inbox) — ver `bar.sample.md`
- `IconButton` — papel: composição (nova mensagem, info, voltar mobile) — ver `button.sample.md`
- `Feedback` — papel: composição (empty state inbox e thread) — ver `feedback.sample.md`

## Recursos visuais

- `flex h-screen overflow-hidden` — shell full-height sem scroll na raiz
- `w-16 bg-dark-800 flex-shrink-0` — strip estreita de workspaces
- `w-72 flex-shrink-0 border-r border-light-200 bg-white` — painel de inbox
- `hidden md:flex` / `flex md:hidden` — toggle mobile/desktop dos painéis
- `bg-primary-50` — item de conversa ativa no inbox

## Receita

### Estrutura base

`CommunicationLayout.razor` com strip de workspaces, inbox e thread.

```razor
@* CommunicationLayout.razor — shell de comunicação *@
@inherits LayoutComponentBase
@inject OffCanvasService OffCanvasService

@code {
    private bool mostrarThreadMobile;
    private string buscaInbox = "";

    // Chamado pelas páginas filhas ao selecionar conversa
    [CascadingParameter] public Action<bool>? SetMostrarThread { get; set; }
}

<CascadingValue Value="(Action<bool>)(mostrar => { mostrarThreadMobile = mostrar; InvokeAsync(StateHasChanged); })">
    <div class="flex h-screen overflow-hidden">

        @* Strip de workspaces (opcional — remover para app simples) *@
        <div class="w-16 bg-dark-800 flex-shrink-0 flex flex-col items-center py-4 gap-3">
            <div class="w-9 h-9 rounded-xl bg-primary-500 flex items-center justify-center
                        text-white font-bold text-sm cursor-pointer">
                G
            </div>
        </div>

        @* Painel de inbox *@
        <div class="@(mostrarThreadMobile ? "hidden md:flex" : "flex") flex-col
                    w-full md:w-72 flex-shrink-0 border-r border-light-200 bg-white">
            <Bar AdditionalClasses="px-4 py-3 border-b border-light-200">
                <StartContent>
                    <h2 class="text-sm font-semibold text-dark-700">Mensagens</h2>
                </StartContent>
                <EndContent>
                    <IconButton Icon="WellKnownIcons.Edit" Style="Themes.Default"
                                Size="Sizes.Small" Title="Nova mensagem" />
                </EndContent>
            </Bar>

            <div class="px-3 py-2 border-b border-light-100">
                <FieldText Placeholder="Buscar conversas..."
                           @bind-Value="buscaInbox" />
            </div>

            @* Lista de conversas — renderizada pela página *@
            <div class="flex-1 overflow-y-auto">
                @Body
            </div>
        </div>

        @* Thread ativa *@
        <div class="@(mostrarThreadMobile ? "flex" : "hidden md:flex") flex-col flex-1 overflow-hidden">
            @* Conteúdo da thread renderizado pela página de conversa *@
        </div>
    </div>
</CascadingValue>
```

### Cenários de composição

#### Página de inbox com lista de conversas

```razor
@page "/mensagens"
@layout CommunicationLayout

@code {
    private List<ConversaDto> conversas = [];
    private ConversaDto? ativa;

    protected override async Task OnInitializedAsync()
        => conversas = await Service.ListarAsync();

    private void AbrirConversa(ConversaDto c)
    {
        ativa = c;
        // Sinaliza ao layout para mostrar thread no mobile
        SetMostrarThread?.Invoke(true);
        Nav.NavigateTo($"/mensagens/{c.Id}");
    }
}

@foreach (var conversa in conversas)
{
    <button class="w-full text-left border-b border-light-100 last:border-0"
            @onclick="() => AbrirConversa(conversa)">
        <Bar AdditionalClasses="px-3 py-3 transition-colors
                               @(ativa?.Id == conversa.Id ? "bg-primary-50" : "hover:bg-light-50")">
            <StartContent>
                <div class="flex gap-2">
                    <div class="w-9 h-9 rounded-full bg-primary-100 flex-shrink-0
                                flex items-center justify-center
                                text-sm font-bold text-primary-600">
                        @conversa.NomeParticipante[0]
                    </div>
                    <div class="min-w-0">
                        <p class="text-sm font-medium text-dark-600 truncate">
                            @conversa.NomeParticipante
                        </p>
                        <p class="text-xs text-dark-400 truncate">@conversa.UltimaMensagem</p>
                    </div>
                </div>
            </StartContent>
            <EndContent>
                <div class="flex flex-col items-end gap-1 flex-shrink-0">
                    <span class="text-xs text-dark-300">
                        @conversa.UltimaAtividade.ToString("HH:mm")
                    </span>
                    @if (conversa.NaoLidas > 0)
                    {
                        <Badge Style="Themes.Primary"
                               Text="@conversa.NaoLidas.ToString()" />
                    }
                </div>
            </EndContent>
        </Bar>
    </button>
}
```

#### Badge de alertas global no item de nav

```razor
@* Dentro do strip de workspaces — badge sobreposto ao ícone *@
<div class="relative">
    <div class="w-9 h-9 rounded-xl bg-dark-700 flex items-center justify-center
                text-dark-300 cursor-pointer hover:bg-dark-600">
        <Icon Kind="WellKnownIcons.Bell" />
    </div>
    @if (totalNaoLidas > 0)
    {
        <span class="absolute -top-1 -right-1">
            <Badge Style="Themes.Danger"
                   Text="@(totalNaoLidas > 99 ? "99+" : totalNaoLidas.ToString())" />
        </span>
    }
</div>
```

### Estados de página

- `loading` (inbox): 5 itens `animate-pulse h-14 bg-light-100 rounded` no painel lateral;
- `empty` (inbox): `Feedback(Light) "Nenhuma conversa."` centralizado no painel;
- `sem thread` selecionada: `Feedback(Light) "Selecione uma conversa."` na área de thread.

## Limites

- Sem suporte a tempo real nativo — SignalR é responsabilidade do app consumidor;
- `CascadingValue` para `SetMostrarThread` é solução de coordenação — alternativa mais robusta: serviço singleton `InboxStateService`;
- Balões de mensagem são CSS manual (`rounded-2xl bg-primary-500`) — ver `PP-CONVERSATION` para código completo;
- Sem indicadores de "digitando..." ou presença — requerem SignalR + estado C# no app;
- Para múltiplos canais (estilo Slack): a strip `w-16` escala bem, mas a lista de canais dentro do inbox requer seções colapsáveis.

### Responsividade

Mobile: mostrar apenas inbox OU thread por vez (`hidden md:flex`). Ao selecionar conversa: inbox desaparece, thread aparece. Botão "voltar" (ChevronLeft) no header da thread reseta `mostrarThreadMobile = false`.
