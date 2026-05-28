# SHP-COMMUNICATION - Communication

**GAP parcial — lib cobre primitivos mas sem shell de comunicação dedicado**

A biblioteca não tem layout específico para shell de comunicação. A estrutura de inbox + thread requer composição com split panel CSS + `PP-CONVERSATION`. SignalR para tempo real é externo ao scope da lib.

## Componentes por zona funcional

### Zona: Shell (estrutura)

1. AppLayout (estrutura raiz)
- `cobertura`: layout base com sidebar (inbox/canais) + área de conteúdo (thread);
- `nota`: 7;
- `justificativa`: AppLayout como base do shell de comunicação — adaptado para inbox+thread.

2. Split panel CSS (lista + thread)
- `cobertura`: lista de conversas à esquerda + thread à direita via `flex h-full`;
- `nota`: 5;
- `justificativa`: split de comunicação — CSS manual.

### Zona: Inbox

1. Stack + Bar (lista de conversas)
- `cobertura`: inbox com itens de conversa, badge de não lidas, preview de última mensagem;
- `nota`: 7;
- `justificativa`: lista de threads do inbox.

2. Badge (contagem de não lidas)
- `cobertura`: contador de mensagens não lidas por thread e no ícone global;
- `nota`: 9;
- `justificativa`: indicador de notificações.

### Zona: Thread

1. PP-CONVERSATION (thread ativa)
- `cobertura`: thread de mensagens com composição, balões, timestamp e status;
- `nota`: 5;
- `justificativa`: thread de mensagens — composição manual (ver UIP-DATA-TIMELINE_ITEM).

2. FieldTextArea + Button (composição)
- `cobertura`: área de composição de mensagem com envio por botão ou Enter;
- `nota`: 7;
- `justificativa`: entrada de mensagem.

### Zona: Notificações

1. NotificationService + Notification
- `cobertura`: toasts de nova mensagem recebida; badge no ícone de mensagens;
- `nota`: 8;
- `justificativa`: notificação de mensagem recebida.

2. OffCanvas (contexto da conversa)
- `cobertura`: painel com perfil do contato, arquivos, detalhes;
- `nota`: 9;
- `justificativa`: painel de contexto da conversa ativa.

**Descartados**: AppSideBar (sidebar de módulos de app, não de canais/threads de comunicação).

## Estrutura de shell

```razor
@* CommunicationLayout.razor — shell de comunicação *@
@inherits LayoutComponentBase

@code {
    private int? threadAtiva;
    private bool mostrarThreadMobile;
}

<div class="flex h-screen overflow-hidden">
    @* Sidebar: canais/DMs (opcional para apps de mensagens) *@
    <div class="w-16 bg-dark-800 flex-shrink-0 flex flex-col items-center py-3 gap-3">
        @* Ícones de workspace/categorias *@
        <div class="w-8 h-8 rounded-lg bg-primary-500 flex items-center justify-center
                    text-white font-bold text-xs">
            G
        </div>
        <div class="w-8 h-8 rounded-lg bg-light-600 flex items-center justify-center
                    text-white text-xs">
            2
        </div>
    </div>

    @* Lista de conversas *@
    <div class="@(mostrarThreadMobile ? "hidden md:flex" : "flex") flex-col
                w-full md:w-72 flex-shrink-0 border-r border-light-200 bg-white">
        <Bar AdditionalClasses="px-4 py-3 border-b border-light-200">
            <StartContent>
                <h2 class="text-sm font-semibold text-dark-700">Mensagens</h2>
            </StartContent>
            <EndContent>
                <IconButton Icon="WellKnownIcons.Edit" Style="Themes.Default" Size="Sizes.Small"
                           title="Nova mensagem" />
            </EndContent>
        </Bar>
        <div class="px-3 py-2 border-b border-light-100">
            <FieldText Placeholder="Buscar conversas..." @bind-Value="buscaInbox" />
        </div>
        <div class="flex-1 overflow-y-auto">
            @Body
            @* Lista de conversas renderizada pela página *@
        </div>
    </div>

    @* Thread ativa *@
    <div class="@(mostrarThreadMobile ? "flex" : "hidden md:flex") flex-col flex-1 overflow-hidden">
        @Body
        @* Thread renderizada pela página de conversa *@
    </div>
</div>
```

```razor
@* Uso: /mensagens/{id} renderiza dentro do shell *@
@page "/mensagens/{Id:int?}"

@* Componente de thread (ver PP-CONVERSATION para código completo) *@
```

## Decisão de uso

- `nota geral`: 4;
- `limitações`: sem shell de comunicação nativo; sem suporte a tempo real (SignalR externo); balões de mensagem são CSS manual; threads e inbox são composição completa; notificações push requerem JS interop; sem presença de usuário ou indicadores de "digitando";
- `recomendação`: `usar com adaptação`
- `justificativa geral`:
  - `AppLayout` + split CSS + `Bar`/`FieldTextArea`/`Badge`/`NotificationService` cobrem o shell de comunicação funcional;
  - Para mensageria em tempo real: SignalR é o stack natural em .NET — a lib não interfere mas também não auxilia;
  - Nota 4 reflete shell funcional com adaptação substancial requerida para comunicação real.
