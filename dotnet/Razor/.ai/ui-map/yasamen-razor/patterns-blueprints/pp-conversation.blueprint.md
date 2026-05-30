# PP-CONVERSATION - Blueprint completo

## Pattern

PP-CONVERSATION — Conversation — ver `pp-conversation.ui-map.md`

## Gap coberto

A lib não tem componente de chat. O gap é coordenar: layout split lista de conversas + thread, balões de mensagem com alinhamento próprio/alheio via `justify-end/start`, scroll automático para a última mensagem via `IJSRuntime`, área de composição fixada no rodapé com `InputTextArea` + `IconButton Send`, e envio por `Enter` (`@onkeydown`).

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `div.flex.h-full.border.rounded-md.overflow-hidden` como container split; painel de conversas `w-72 flex-shrink-0 border-r` com lista de conversas; thread `flex-1 flex-col overflow-hidden` com mensagens + composição; balões: `div.px-3.py-2.rounded-2xl` com `bg-primary-500 text-white` (própria) ou `bg-light-100 text-dark-700` (alheia); `[ref]` + JS `scrollToBottom` para auto-scroll.
- `eixos cobertos sem componente novo`:
  - lista de conversas → `Bar(hover + active) + Badge(NaoLidas)`;
  - balão de mensagem → `div.px-3.py-2.rounded-2xl` CSS puro;
  - composição → `InputTextArea + IconButton(Send)` dentro de `Bar`;
  - Enter para enviar → `@onkeydown OnKeyDown(KeyboardEventArgs)`;
  - scroll automático → `IJSRuntime.InvokeVoidAsync("scrollToBottom", threadRef)`;
  - painel auxiliar → `OffCanvas` com perfil/arquivos da conversa.

## Componentes usados

- `Bar` — papel: principal (header da conversa, linha de conversa, composição) — ver `bar.sample.md`
- `Badge` — papel: composição (não lidas, status de mensagem) — ver `badge.sample.md`
- `IconButton` — papel: composição (enviar, informações, voltar mobile) — ver `button.sample.md`
- `OffCanvas` — papel: composição (painel de informações da conversa) — ver `modal.sample.md`
- `Feedback` — papel: composição (sem conversa selecionada, sem mensagens) — ver `feedback.sample.md`
- `TextField / FieldText` — papel: composição (busca de conversa) — ver `field-text.sample.md`

## Recursos visuais

- `w-72 flex-shrink-0 border-r border-light-200` — painel lateral de conversas
- `justify-end` / `justify-start` — alinhamento de balão (próprio/alheio)
- `bg-primary-500 text-white rounded-br-sm` — balão de mensagem própria
- `bg-light-100 text-dark-700 rounded-bl-sm` — balão de mensagem alheia
- `max-w-xs lg:max-w-md` — largura máxima do balão
- `flex-shrink-0 border-t border-light-200 p-3` — área de composição fixada no rodapé

## Receita

### Estrutura base

Split conversa com lista + thread + composição e auto-scroll.

```razor
@page "/mensagens/{ConversaId:int?}"
@inject IJSRuntime JS

@code {
    private OffCanvas? conversaInfoDrawer;
    [Parameter] public int? ConversaId { get; set; }
    private List<ConversaDto> conversas = [];
    private ConversaDto? conversaAtiva;
    private List<MensagemDto> mensagens = [];
    private string novaMensagem = "";
    private bool enviando;
    private string buscaConversa = "";
    private ElementReference threadRef;

    protected override async Task OnInitializedAsync()
    {
        conversas = await Service.ListarConversasAsync();
        if (ConversaId.HasValue)
            await AbrirConversa(ConversaId.Value);
    }

    private async Task AbrirConversa(int id)
    {
        conversaAtiva = conversas.FirstOrDefault(c => c.Id == id);
        if (conversaAtiva is null) return;
        mensagens = await Service.ObterMensagensAsync(id);
        await InvokeAsync(StateHasChanged);
        await JS.InvokeVoidAsync("scrollToBottom", threadRef);
    }

    private IEnumerable<ConversaDto> ConversasFiltradas =>
        string.IsNullOrEmpty(buscaConversa) ? conversas
        : conversas.Where(c => c.NomeParticipante.Contains(buscaConversa,
            StringComparison.OrdinalIgnoreCase));

    private async Task Enviar()
    {
        if (string.IsNullOrWhiteSpace(novaMensagem) || conversaAtiva is null) return;
        enviando = true;
        try
        {
            var msg = await Service.EnviarAsync(conversaAtiva.Id, novaMensagem.Trim());
            mensagens.Add(msg);
            novaMensagem = "";
            await InvokeAsync(StateHasChanged);
            await JS.InvokeVoidAsync("scrollToBottom", threadRef);
        }
        finally { enviando = false; }
    }

    private async Task OnKeyDown(KeyboardEventArgs e)
    {
        if (e.Key == "Enter" && !e.ShiftKey)
        {
            e.PreventDefault();  // necessário em alguns casos
            await Enviar();
        }
    }
}

<div class="flex h-full border border-light-200 rounded-md overflow-hidden">

    @* Painel de conversas *@
    <div class="w-72 flex-shrink-0 border-r border-light-200 flex flex-col">
        <div class="p-3 border-b border-light-200 flex-shrink-0">
            <FieldText Placeholder="Buscar conversas..."
                       @bind-Value="buscaConversa" />
        </div>
        <div class="flex-1 overflow-y-auto">
            @foreach (var conversa in ConversasFiltradas)
            {
                <button class="w-full text-left border-b border-light-100 last:border-0"
                        @onclick="() => AbrirConversa(conversa.Id)">
                    <Bar AdditionalClasses="px-3 py-3 transition-colors
                                           @(conversaAtiva?.Id == conversa.Id
                                             ? "bg-primary-50"
                                             : "hover:bg-light-50")">
                        <StartContent>
                            <div class="flex gap-2">
                                <div class="w-8 h-8 rounded-full bg-primary-100 flex-shrink-0
                                            flex items-center justify-center
                                            text-xs font-bold text-primary-600">
                                    @conversa.NomeParticipante[0]
                                </div>
                                <div class="min-w-0">
                                    <p class="text-sm font-medium text-dark-600 truncate">
                                        @conversa.NomeParticipante
                                    </p>
                                    <p class="text-xs text-dark-400 truncate">
                                        @conversa.UltimaMensagem
                                    </p>
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
        </div>
    </div>

    @* Thread da conversa *@
    <div class="flex-1 flex flex-col overflow-hidden">
        @if (conversaAtiva is null)
        {
            <div class="flex-1 flex items-center justify-center">
                <Feedback Style="Themes.Light" Text="Selecione uma conversa." />
            </div>
        }
        else
        {
            @* Header *@
            <Bar AdditionalClasses="px-4 py-3 border-b border-light-200 bg-light-50 flex-shrink-0">
                <StartContent>
                    <div class="flex items-center gap-2">
                        <div class="w-8 h-8 rounded-full bg-primary-100 flex-shrink-0
                                    flex items-center justify-center
                                    text-xs font-bold text-primary-600">
                            @conversaAtiva.NomeParticipante[0]
                        </div>
                        <div>
                            <p class="text-sm font-semibold text-dark-700">
                                @conversaAtiva.NomeParticipante
                            </p>
                        </div>
                    </div>
                </StartContent>
                <EndContent>
                    <IconButton Icon="WellKnownIcons.Info" Style="Themes.Default"
                                OnClick='async () => await conversaInfoDrawer!.OpenAsync()' />
                </EndContent>
            </Bar>

            @* Mensagens *@
            <div class="flex-1 overflow-y-auto p-4 space-y-3" @ref="threadRef">
                @if (!mensagens.Any())
                {
                    <div class="flex items-center justify-center h-full">
                        <Feedback Style="Themes.Light"
                                  Text="Ainda não há mensagens. Diga olá!" />
                    </div>
                }
                @foreach (var msg in mensagens)
                {
                    var ehMinha = msg.RemetenteId == UsuarioAtualId;
                    <div class="flex @(ehMinha ? "justify-end" : "justify-start")">
                        <div class="max-w-xs lg:max-w-md">
                            @if (!ehMinha)
                            {
                                <p class="text-xs text-dark-400 mb-0.5 pl-1">
                                    @msg.RemetenteNome
                                </p>
                            }
                            <div class="px-3 py-2 rounded-2xl text-sm leading-relaxed
                                        @(ehMinha
                                          ? "bg-primary-500 text-white rounded-br-sm"
                                          : "bg-light-100 text-dark-700 rounded-bl-sm")">
                                @msg.Conteudo
                            </div>
                            <p class="text-xs text-dark-300 mt-0.5
                                      @(ehMinha ? "text-right" : "")">
                                @msg.EnviadoEm.ToString("HH:mm")
                                @if (ehMinha)
                                {
                                    <span class="ml-1">@(msg.Lida ? "· Lido" : "· Enviado")</span>
                                }
                            </p>
                        </div>
                    </div>
                }
            </div>

            @* Composição *@
            <div class="flex-shrink-0 border-t border-light-200 p-3">
                <Bar>
                    <StartContent>
                        <InputTextArea @bind-Value="novaMensagem"
                                       placeholder="Digite uma mensagem..."
                                       rows="1"
                                       @onkeydown="OnKeyDown"
                                       class="flex-1 w-full border border-light-300 rounded-md
                                              px-3 py-2 text-sm resize-none focus:outline-none
                                              focus:ring-1 focus:ring-primary-400" />
                    </StartContent>
                    <EndContent>
                        <IconButton Icon="WellKnownIcons.Send" Style="Themes.Primary"
                                    Loading="@enviando"
                                    Disabled="@(enviando || string.IsNullOrWhiteSpace(novaMensagem))"
                                    OnClick="Enviar" />
                    </EndContent>
                </Bar>
            </div>
        }
    </div>
</div>

@* Painel de informações da conversa *@
<OffCanvas @ref="conversaInfoDrawer" Id="conversa-info" Title="Informações">
    <ChildContent>
        @if (conversaAtiva is not null)
        {
            <Stack Gap="Gaps.Medium">
                <div class="flex flex-col items-center py-4">
                    <div class="w-16 h-16 rounded-full bg-primary-100 flex items-center
                                justify-center text-xl font-bold text-primary-600 mb-2">
                        @conversaAtiva.NomeParticipante[0]
                    </div>
                    <p class="text-base font-semibold text-dark-700">
                        @conversaAtiva.NomeParticipante
                    </p>
                </div>
            </Stack>
        }
    </ChildContent>
</OffCanvas>
```

### Cenários de composição

#### Thread com agrupamento por data

```razor
@* Agrupamento de mensagens por dia *@
@{
    var porDia = mensagens.GroupBy(m => m.EnviadoEm.Date).OrderBy(g => g.Key);
}
@foreach (var grupo in porDia)
{
    <div class="flex items-center gap-2 my-3">
        <div class="flex-1 h-px bg-light-200"></div>
        <span class="text-xs text-dark-400 flex-shrink-0">
            @(grupo.Key == DateTime.Today.Date ? "Hoje"
              : grupo.Key == DateTime.Today.Date.AddDays(-1) ? "Ontem"
              : grupo.Key.ToString("dd/MM/yyyy"))
        </span>
        <div class="flex-1 h-px bg-light-200"></div>
    </div>
    @foreach (var msg in grupo) { @* balões de mensagem *@ }
}
```

### Estados de página

- `loading` (conversas): 5 linhas `animate-pulse h-14 bg-light-100 rounded` no painel lateral;
- `loading` (mensagens): 3 balões skeleton alternando esquerda/direita;
- `empty` (sem conversa selecionada): `Feedback(Light) "Selecione uma conversa."`;
- `empty` (sem mensagens): `Feedback(Light) "Ainda não há mensagens. Diga olá!"`;
- `enviando`: `IconButton(Loading=true Disabled=true)` no botão de enviar.

## Limites

- Scroll automático para última mensagem requer JS interop — `scrollToBottom` precisa ser implementado em `wwwroot/js/chat.js`;
- Tempo real (SignalR) requer integração separada — sem suporte nativo na lib;
- `InputTextArea` não expande automaticamente conforme texto — auto-resize requer JS interop;
- Mobile: coluna de conversas ocupa tela toda; considerar navegar para `/mensagens/{id}` para abrir thread em mobile;
- `[JSInvokable]` pode ser necessário para receber novas mensagens via SignalR e chamar `StateHasChanged`;
- Upload de arquivo na composição requer `InputFile` com tratamento separado.

### Responsividade

Mobile (< md): exibir painel de conversas ou thread em tela cheia, nunca ambos simultaneamente. Implementar via `mostrarThread = bool` com toggle ao selecionar conversa e botão voltar no header da thread.
