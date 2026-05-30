# UIP-CONTENT-COMMENT_THREAD - Blueprint resumido

## Pattern

UIP-CONTENT-COMMENT_THREAD — Comment Thread — ver `uip-content-comment-thread.ui-map.md`

## Gap coberto

A lib não tem componente de comment thread. O gap é orientar a composição com `Stack + Box + Bar` para a lista de comentários, avatar inicial como div, e `<InputTextArea>` como composer com `Button(enviar/cancelar)`.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `Stack + Box + Bar` para lista cronológica de comentários; avatar inicial via `div.rounded-full`; `DropIconButton` para ações do autor; `<InputTextArea>` Blazor para composer (sem FieldTextArea na lib).

## Componentes usados

- `Stack` — papel: principal (lista de comentários) — ver `stack.sample.md`
- `Box` — papel: composição (card por comentário) — ver `box.sample.md`
- `Bar` — papel: composição (header da seção e por comentário) — ver `bar.sample.md`
- `Badge` — papel: composição (contador de comentários) — ver `badge.sample.md`
- `DropIconButton` — papel: composição (ações do autor) — ver `button.sample.md`
- `Button` — papel: composição (enviar/cancelar) — ver `button.sample.md`
- `Feedback` — papel: composição (empty state) — ver `feedback.sample.md`

## Recursos visuais

- `bg-primary-50` — destaque no comentário do usuário atual
- `w-7 h-7 rounded-full bg-primary-100` — avatar com inicial do nome
- `resize-none` — textarea sem redimensionamento

## Receita

`Stack + Box + Bar` para thread; avatar div + inicial; `<InputTextArea>` para composer.

```razor
@code {
    private string novoComentario = "";
    private bool enviando;

    private async Task Enviar()
    {
        if (string.IsNullOrWhiteSpace(novoComentario)) return;
        enviando = true;
        await ComentarioService.AdicionarAsync(entidadeId, novoComentario);
        novoComentario = "";
        enviando = false;
    }
}

<Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
    <Bar AdditionalClasses="mb-4">
        <StartContent>
            <h3 class="text-sm font-semibold text-dark-600">Comentários</h3>
            <Badge Style="Themes.Light" Text="@comentarios.Count.ToString()"
                   AdditionalClasses="ml-2" />
        </StartContent>
    </Bar>

    @if (!comentarios.Any())
    {
        <Feedback Style="Themes.Light" Text="Nenhum comentário ainda." AdditionalClasses="mb-4" />
    }
    else
    {
        <Stack Gap="Gaps.Medium" AdditionalClasses="mb-4">
            @foreach (var c in comentarios.OrderBy(x => x.CriadoEm))
            {
                <Box Border="BorderBuilder.Box"
                     AdditionalClasses="@($"p-3 {(c.AutorId == usuarioAtualId ? "bg-primary-50" : "")}")">
                    <Bar AdditionalClasses="mb-2">
                        <StartContent>
                            <div class="flex items-center gap-2">
                                <div class="w-7 h-7 rounded-full bg-primary-100 flex items-center
                                            justify-center flex-shrink-0">
                                    <span class="text-xs font-bold text-primary-600">
                                        @c.AutorNome[0].ToString().ToUpper()
                                    </span>
                                </div>
                                <div>
                                    <span class="text-sm font-semibold text-dark-600">
                                        @c.AutorNome
                                    </span>
                                    <span class="text-xs text-dark-400 ml-2">
                                        @c.CriadoEm.ToString("dd/MM HH:mm")
                                    </span>
                                </div>
                            </div>
                        </StartContent>
                        <EndContent>
                            @if (c.AutorId == usuarioAtualId)
                            {
                                <DropIconButton Icon="WellKnownIcons.MoreVertical"
                                               Style="Themes.Default" Size="Sizes.Small">
                                    <DropItem Label="Editar" OnClick="() => EditarComentario(c)" />
                                    <DropItem Label="Excluir" Style="Themes.Danger"
                                              OnClick="() => ExcluirComentario(c.Id)" />
                                </DropIconButton>
                            }
                        </EndContent>
                    </Bar>
                    <p class="text-sm text-dark-600">@c.Texto</p>
                </Box>
            }
        </Stack>
    }

    @* Composer — <InputTextArea> Blazor (sem FieldTextArea na lib) *@
    <InputTextArea @bind-Value="novoComentario" rows="3"
                   placeholder="Escreva um comentário..."
                   class="w-full border border-light-300 rounded-md px-3 py-2 text-sm resize-none
                          focus:outline-none focus:ring-2 focus:ring-primary-400" />
    <Bar AdditionalClasses="mt-2">
        <EndContent>
            <Button Style="Themes.Secondary" Outline=true Label="Cancelar"
                    OnClick="() => novoComentario = """
                    Disabled="@enviando" />
            <Button Style="Themes.Primary" Label="Comentar"
                    Loading="@enviando"
                    Disabled="@string.IsNullOrWhiteSpace(novoComentario)"
                    OnClick="Enviar" />
        </EndContent>
    </Bar>
</Box>
```

## Limites

- Sem `FieldTextArea` na lib — `<InputTextArea>` Blazor sem estilo visual da lib;
- Respostas aninhadas requerem `ml-6` manual no `Box` + estado `respondendoA` no componente;
- Sem menções (`@usuario`) ou reações — requerem lógica adicional no app;
- `comentarios.OrderBy(x => x.CriadoEm)` deve ser executado antes do `@foreach` para evitar re-sorting em cada render.
