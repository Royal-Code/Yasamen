# PP-CONVERSATION - Blueprint

## Identificação
- **Pattern**: PP-CONVERSATION.
- **Nível final**: completo.
- **Cobertura atual**: 1.
- **Meta de cobertura proposta**: 8.
- **Evidências usadas**: `ui-map.md`, `page.pattern.md`, samples de `Stack`, `Box`, `TextField`, `Button`, `Badge`, `Feedback`, `DropIconButton`, `visual.language.md` e `styles.map.md`.

## Resumo executivo
Yasamen não tem componentes conversacionais, mas fornece blocos suficientes para propor thread, mensagem e composer. Este blueprint é a versão de página do shell de comunicação.

## Requisitos ainda não atendidos
- Lista/thread de mensagens.
- Mensagem com autoria, hora e status.
- Composer com envio.
- Scroll independente.
- Empty/error/loading conversacionais.

## Diagnóstico estruturado do gap
`Stack` e `Box` montam timeline; `TextField` e `Button` montam composer; `Badge` e `Feedback` cobrem status. A semântica de conversa é totalmente proposta.

## Justificativa detalhada da meta
Com `ConversationPage`, `MessageBubble` e `MessageComposer`, a cobertura atinge 8 para conversa simples. Realtime, anexos e virtualização ficam externos.

## Estratégia de composição
- `Box` para header da conversa.
- Região scrollável com `Stack`.
- `MessageBubble` proposto usando `Box`.
- Composer fixo no rodapé da página ou painel.
- `Feedback` para vazio/erro.

## Proposta de peças, contratos e responsabilidades
- `[API proposta] ConversationPage`: Conversation, Messages, Draft, OnSend.
- `[API proposta] MessageBubble`: Mine, Author, Body, SentAt, Status.
- `[API proposta] MessageComposer`: Draft, OnSend, IsSending.

## Aplicação objetiva da linguagem visual
Mensagens próprias usam `primary-100` sem fundo forte. Mensagens recebidas usam branco com borda. Composer usa `TextField` em superfície branca com borda superior.

## Aplicação de estilos e tokens
Usar `overflow-y-auto`, `space-y-3`, `p-4`, `border-light-300`. Evitar bolhas com cores saturadas.

## Estrutura sugerida por tecnologia

```razor
@* [API proposta] ConversationPage *@
<Box AdditionalClasses="h-full bg-light-100 border border-light-300 rounded-md flex flex-col">
    <Bar AdditionalClasses="p-4 bg-white border-b border-light-300">
        <Start><strong>@ConversationTitle</strong></Start>
        <End><Badge Text="@Status" Style="Themes.Info" Size="Sizes.Small" /></End>
    </Bar>

    <div class="flex-1 overflow-y-auto p-4">
        <Stack AdditionalClasses="space-y-3">
            @Messages
        </Stack>
    </div>

    @Composer
</Box>
```

## Blocos principais de código

```razor
@* [API proposta] MessageBubble *@
<div class="flex @(Mine ? "justify-end" : "justify-start")">
    <Box AdditionalClasses="@BubbleClasses">
        <div class="text-sm font-medium text-dark-800">@Author</div>
        <div class="text-dark-900">@Body</div>
        <div class="text-xs text-dark-400">@SentAt</div>
    </Box>
</div>

@* [API proposta] composer *@
<Box AdditionalClasses="p-4 bg-white border-t border-light-300 rounded-none">
    <TextField Placeholder="Escrever resposta" @bind-Value="Draft">
        <FooterAction>
            <FieldAction Label="Enviar" Style="Themes.Primary" OnClick="Send" Disabled="@IsSending" />
        </FooterAction>
    </TextField>
</Box>
```

## Estados e comportamento responsivo
- Desktop: thread pode coexistir com contexto lateral.
- Mobile: foco único na thread.
- Empty: `Feedback Info` com orientação de primeira mensagem.
- Sending: composer disabled e botão com estado do app.
- Error: `Feedback Danger` próximo ao composer.

## Exemplo principal de uso

```razor
@* [API proposta] *@
<ConversationPage Conversation="conversation"
                  Messages="messages"
                  Draft="@draft"
                  OnSend="SendAsync" />
```

## Comparação entre cobertura atual e proposta
| Critério | Atual | Proposta |
|---|---|---|
| Thread | ausente | proposta |
| Mensagem | ausente | bubble proposta |
| Composer | parcial | contrato proposto |
| Estados | `Feedback` | específicos |

## Limitações remanescentes
- Realtime, anexos e markdown dependem do app.
- Sem virtualização nativa.
- Multi-linha pode exigir componente novo.

## Pontos de adaptação
- Definir ordenação e paginação de mensagens.
- Tratar envio otimista ou pessimista.
- Definir política de retry e moderação.
