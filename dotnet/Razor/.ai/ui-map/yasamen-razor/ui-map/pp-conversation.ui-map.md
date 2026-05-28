# PP-CONVERSATION - Conversation

## Componentes por zona funcional

### Zona: Coleção (lista de conversas)

1. Stack + Bar (UIP-DATA-LIST_ITEM)
- `cobertura`: lista de conversas com avatar, nome, última mensagem, timestamp e badge de não lidas;
- `nota`: 7;
- `justificativa`: lista de threads — composição direta com Bar.

2. FieldText (busca de conversa)
- `cobertura`: busca inline nas conversas;
- `nota`: 8;
- `justificativa`: filtro de conversas.

### Zona: Thread (conteúdo da conversa)

1. CSS vertical line + Box + Bar (UIP-DATA-TIMELINE_ITEM)
- `cobertura`: thread de mensagens com alinhamento próprio (esquerda/direita); timestamp; avatar;
- `nota`: 4;
- `justificativa`: estrutura de mensagens como timeline — sem alinhamento automático para chat (esq/dir).

2. Box (balão de mensagem)
- `cobertura`: container de mensagem com padding, borda e fundo; alinhamento por `justify-end` / `justify-start`;
- `nota`: 6;
- `justificativa`: balão de mensagem — cobre o padrão com CSS.

3. Badge (status de mensagem)
- `cobertura`: "Enviando", "Enviado", "Lido";
- `nota`: 7;
- `justificativa`: status de entrega da mensagem.

### Zona: Composição (input de mensagem)

1. FieldTextArea + Button (composição)
- `cobertura`: área de texto para nova mensagem; botão "Enviar"; Enter para enviar (`@onkeydown`);
- `nota`: 7;
- `justificativa`: composição básica de mensagem.

2. Bar (toolbar de composição)
- `cobertura`: linha com FieldTextArea + ações de enviar + anexar;
- `nota`: 8;
- `justificativa`: toolbar de composição.

### Zona: Painel Auxiliar

1. OffCanvas (contexto da conversa)
- `cobertura`: painel lateral com perfil do participante, arquivos compartilhados, links;
- `nota`: 8;
- `justificativa`: informações contextuais da conversa.

**Descartados**: nenhum.

## Composição completa da página

```razor
@page "/mensagens/{ConversaId:int?}"
@code {
    [Parameter] public int? ConversaId { get; set; }
    private List<ConversaDto> conversas = [];
    private ConversaDto? conversaAtiva;
    private List<MensagemDto> mensagens = [];
    private string novaMensagem = "";
    private bool enviando;
    private ElementReference threadRef;

    protected override async Task OnInitializedAsync()
    {
        conversas = await Service.ListarConversasAsync();
        if (ConversaId is not null)
            await AbrirConversa(ConversaId.Value);
    }

    private async Task AbrirConversa(int id)
    {
        conversaAtiva = conversas.FirstOrDefault(c => c.Id == id);
        mensagens = await Service.ObterMensagensAsync(id);
        await JS.InvokeVoidAsync("scrollToBottom", threadRef);
    }

    private async Task Enviar()
    {
        if (string.IsNullOrWhiteSpace(novaMensagem)) return;
        enviando = true;
        try
        {
            var msg = await Service.EnviarAsync(conversaAtiva!.Id, novaMensagem);
            mensagens.Add(msg);
            novaMensagem = "";
            await JS.InvokeVoidAsync("scrollToBottom", threadRef);
        }
        finally { enviando = false; }
    }

    private async Task OnKeyDown(KeyboardEventArgs e)
    {
        if (e.Key == "Enter" && !e.ShiftKey)
            await Enviar();
    }
}

<div class="flex h-full border border-light-200 rounded-md overflow-hidden">
    @* Painel de conversas *@
    <div class="w-72 flex-shrink-0 border-r border-light-200 flex flex-col">
        <div class="p-3 border-b border-light-200">
            <FieldText Placeholder="Buscar conversas..." @bind-Value="buscaConversa" />
        </div>
        <div class="flex-1 overflow-y-auto">
            @foreach (var conversa in ConversasFiltradas)
            {
                <button class="w-full text-left border-b border-light-100 last:border-0"
                        @onclick="() => AbrirConversa(conversa.Id)">
                    <Bar AdditionalClasses="px-3 py-3 hover:bg-light-50 transition-colors
                                           @(conversaAtiva?.Id == conversa.Id ? "bg-primary-50" : "")">
                        <StartContent>
                            <div class="flex gap-2">
                                <div class="w-8 h-8 rounded-full bg-primary-100 flex-shrink-0
                                            flex items-center justify-center text-xs font-bold text-primary-600">
                                    @conversa.NomeParticipante.Substring(0, 1)
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
                            <div class="flex flex-col items-end gap-1">
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
            @* Header da conversa *@
            <Bar AdditionalClasses="px-4 py-3 border-b border-light-200 bg-light-50 flex-shrink-0">
                <StartContent>
                    <div class="flex items-center gap-2">
                        <div class="w-8 h-8 rounded-full bg-primary-100 flex items-center
                                    justify-center text-xs font-bold text-primary-600">
                            @conversaAtiva.NomeParticipante.Substring(0, 1)
                        </div>
                        <div>
                            <p class="text-sm font-semibold text-dark-700">
                                @conversaAtiva.NomeParticipante
                            </p>
                            <p class="text-xs text-dark-400">Online</p>
                        </div>
                    </div>
                </StartContent>
                <EndContent>
                    <IconButton Icon="WellKnownIcons.Info" Style="Themes.Default"
                               OnClick='() => OffCanvasService.Open<ConversaInfoDrawer>(
                                   p => p.Add(x => x.Conversa, conversaAtiva))' />
                </EndContent>
            </Bar>

            @* Mensagens *@
            <div class="flex-1 overflow-y-auto p-4 space-y-3" @ref="threadRef">
                @foreach (var msg in mensagens)
                {
                    var ehMinha = msg.RemetenteId == UsuarioAtualId;
                    <div class="flex @(ehMinha ? "justify-end" : "justify-start")">
                        <div class="max-w-xs lg:max-w-md">
                            @if (!ehMinha)
                            {
                                <p class="text-xs text-dark-400 mb-0.5 pl-1">@msg.RemetenteNome</p>
                            }
                            <div class="px-3 py-2 rounded-2xl text-sm
                                        @(ehMinha
                                          ? "bg-primary-500 text-white rounded-br-sm"
                                          : "bg-light-100 text-dark-700 rounded-bl-sm")">
                                @msg.Conteudo
                            </div>
                            <p class="text-xs text-dark-300 mt-0.5 @(ehMinha ? "text-right" : "")">
                                @msg.EnviadoEm.ToString("HH:mm")
                                @if (ehMinha)
                                {
                                    @(" · ")
                                    <span>@(msg.Lida ? "Lido" : "Enviado")</span>
                                }
                            </p>
                        </div>
                    </div>
                }
            </div>

            @* Área de composição *@
            <div class="flex-shrink-0 border-t border-light-200 p-3">
                <Bar>
                    <StartContent>
                        @* [inferido] FieldTextArea não existe — usar <InputTextArea> Blazor *@
                        <InputTextArea @bind-Value="novaMensagem"
                                       placeholder="Digite uma mensagem..."
                                       rows="1"
                                       @onkeydown="OnKeyDown"
                                       class="flex-1 border border-light-300 rounded-md px-3 py-2 text-sm resize-none" />
                    </StartContent>
                    <EndContent>
                        <IconButton Icon="WellKnownIcons.Send" Style="Themes.Primary"
                                   OnClick="Enviar"
                                   Disabled="@(enviando || string.IsNullOrWhiteSpace(novaMensagem))" />
                    </EndContent>
                </Bar>
            </div>
        }
    </div>
</div>
```

## Decisão de uso

- `nota geral`: 5;
- `limitações`: sem componente de chat/mensagem nativo; alinhamento de balões de mensagem (esq/dir) é CSS manual; scroll automático para última mensagem requer JS; sem suporte a tempo real nativo (SignalR requer integração manual); sem upload de arquivo integrado;
- `recomendação`: `usar com adaptação`
- `justificativa geral`:
  - `Bar` + `Box` + `FieldTextArea` + `Stack` cobrem PP-CONVERSATION funcional com composição manual;
  - O painel split (lista + thread) usa a mesma abordagem de `UIP-STRUCT-SPLIT_PANEL`;
  - Nota 5 reflete cobertura funcional mas com adaptação substancial no layout de mensagens e ausência de tempo real nativo.
