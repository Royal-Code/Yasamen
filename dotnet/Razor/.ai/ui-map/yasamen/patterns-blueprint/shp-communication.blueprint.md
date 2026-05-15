# SHP-COMMUNICATION - Blueprint

## Identificação
- **Pattern**: SHP-COMMUNICATION - Communication.
- **Nível final**: completo.
- **Cobertura atual**: 2.
- **Meta de cobertura proposta**: 8.
- **Evidências usadas**: `ui-map.md`, `shell.pattern.md`, samples de `AppLayout`, `Container`, `Slot`, `Box`, `Stack`, `Button`, `IconButton`, `TextField`, `Badge`, `Feedback`, `OffCanvas`, `visual.language.md` e `styles.map.md`.

## Resumo executivo
Yasamen fornece shell, blocos, campos, badges e ações compactas, mas não possui inbox, thread, mensagem, composer ou atualização conversacional. O blueprint propõe um shell de comunicação com lista de conversas, thread ativa e contexto lateral usando componentes existentes no contorno e peças novas marcadas como propostas para semântica de conversa.

## Requisitos ainda não atendidos
- Inbox com seleção de conversa e estado não lido.
- Thread com mensagens agrupadas, autoria, horário e separadores.
- Composer persistente com envio, anexos e disabled/loading.
- Contexto lateral para participantes ou detalhes.
- Transição desktop para mobile: lista e thread alternáveis.

## Diagnóstico estruturado do gap
`AppLayout`, `Container`, `Slot` e `Box` resolvem a estrutura, mas a semântica de comunicação fica manual. `TextField` cobre entrada textual, porém não cobre composer multi-linha, anexos ou estado de envio. `Badge` e `Feedback` ajudam em status e empty state, mas não substituem mensagens ou threads.

## Justificativa detalhada da meta
Com `CommunicationShell`, `ConversationList`, `MessageThread` e `MessageComposer` como `[API proposta]`, a experiência chega a cobertura 8 porque preserva a interação dominante do pattern e reutiliza a base visual da Yasamen. A meta não deve passar de 8 enquanto não houver WebSocket, presença, virtualização ou componente oficial de mensagem.

## Estratégia de composição
- Usar `AppLayout` para topbar, menu lateral e outlets globais.
- Usar `Container`/`Slot` para layout desktop com inbox e thread simultâneos.
- Usar `OffCanvas` para contexto lateral em mobile.
- Usar `Box` para cards de conversa e mensagens.
- Usar `Badge` para unread/status.
- Usar `TextField` e `Button` para composer simples.

## Proposta de peças, contratos e responsabilidades
- `[API proposta] ConversationSummary`: id, title, preview, timestamp, unreadCount, active.
- `[API proposta] MessageBubble`: author, sentAt, body, mine, status.
- `[API proposta] MessageComposer`: value, ValueChanged, OnSend, Disabled, Placeholder.
- `[API proposta] CommunicationShell`: selectedConversationId, items, messages, OnSelect, OnSend.

## Aplicação objetiva da linguagem visual
Superfícies devem ser brancas sobre `bg-light-100`; mensagens próprias podem usar fundo `primary-100` e texto `dark-900`; mensagens externas ficam brancas com borda `light-300`. Ação de envio usa `Themes.Primary`; ações de contexto usam `IconButton` com tema neutro.

## Aplicação de estilos e camadas
Usar `border-light-300`, `rounded-md`, `p-4/p-6`, `space-y-4`, `z-offcanvas` para contexto lateral e `z-notification` somente para eventos temporários. Evitar cores fortes em toda a thread.

## Estrutura sugerida por tecnologia

```razor
@* [API proposta] CommunicationShell.razor *@
<AppLayout AdditionalMainClasses="p-0 bg-light-100">
    <TopStart><strong>Mensagens</strong></TopStart>
    <TopEnd>
        <ButtonGroup Size="Sizes.Small" AriaLabel="Ações de comunicação">
            <IconButton Icon="BsIconNames.Search" Style="Themes.Secondary" />
            <IconButton Icon="BsIconNames.Gear" Style="Themes.Secondary" />
        </ButtonGroup>
    </TopEnd>
    <Main>
        <Container Type="LayoutTypes.Grid" Size="LayoutSizes.Default" AdditionalClasses="min-h-[calc(100vh-4rem)] gap-0">
            <Slot Span="4" LaptopSpan="4">
                <Box AdditionalClasses="h-full bg-white border-r border-light-300 rounded-none">
                    @Inbox
                </Box>
            </Slot>
            <Slot Span="4" LaptopSpan="8">
                <Box AdditionalClasses="h-full bg-light-100 rounded-none flex flex-col">
                    @Thread
                    @Composer
                </Box>
            </Slot>
        </Container>
    </Main>
</AppLayout>
```

## Blocos principais de código

```razor
@* [API proposta] item de inbox *@
<button class="w-full text-left p-4 border-b border-light-300 bg-white hover:bg-light-100">
    <div class="flex items-start justify-between gap-4">
        <div class="min-w-0">
            <div class="font-medium text-dark-900">@Title</div>
            <div class="text-sm text-dark-500 truncate">@Preview</div>
        </div>
        @if (UnreadCount > 0)
        {
            <Badge Text="@UnreadCount.ToString()" Style="Themes.Primary" Size="Sizes.Small" />
        }
    </div>
</button>

@* [API proposta] composer simples reaproveitando TextField *@
<Box AdditionalClasses="p-4 bg-white border-t border-light-300 rounded-none">
    <TextField Placeholder="Escrever mensagem" @bind-Value="Draft">
        <FooterAction>
            <FieldAction Label="Enviar" Style="Themes.Primary" OnClick="OnSend" Disabled="@IsSending" />
        </FooterAction>
    </TextField>
</Box>
```

## Estados e comportamento responsivo
- Desktop: inbox e thread coexistem; contexto pode ficar em `RightMenu`.
- Mobile: mostrar inbox ou thread, não ambos; contexto abre via `OffCanvas`.
- Empty: `Feedback Style="Themes.Info"` quando não há conversa selecionada.
- Loading: `Feedback` ou skeleton local proposto, sem bloquear todo shell.
- Erro de envio: `Feedback Style="Themes.Danger"` próximo ao composer e toast por `Notify` se o serviço existir.

## Exemplo principal de uso

```razor
@* [API proposta] *@
<CommunicationShell Items="conversations"
                    Messages="messages"
                    SelectedConversationId="@selectedId"
                    OnSelect="SelectConversation"
                    OnSend="SendMessage" />
```

## Comparação entre cobertura atual e proposta
| Critério | Atual | Proposta |
|---|---|---|
| Shell | `AppLayout` forte | Mantido |
| Inbox | manual | contrato proposto |
| Thread | ausente | `MessageThread` proposto |
| Composer | `TextField` parcial | `MessageComposer` proposto |
| Mobile | composição manual | lista/thread alternáveis |

## Limitações remanescentes
- Presença, typing indicator, anexos e realtime dependem do app destino.
- Virtualização de mensagens não é fornecida.
- Multi-linha real pode exigir componente adicional além de `TextField`.

## Pontos de adaptação
- Definir modelo de mensagem do domínio.
- Integrar com serviço de realtime ou polling.
- Ajustar política de retenção, anexos e moderação fora da camada visual.
