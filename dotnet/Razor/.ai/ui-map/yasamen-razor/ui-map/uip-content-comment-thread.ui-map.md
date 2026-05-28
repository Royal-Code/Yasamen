# UIP-CONTENT-COMMENT_THREAD - Comment Thread

**GAP parcial — sem componente dedicado**

A biblioteca não tem componente de comment thread. Requer composição com `Stack` + `Box` (por comentário) + `FieldTextArea` (composer) + `Button` (enviar).

## Componentes

**Principais**: nenhum dedicado.

**Composição**:

1. Stack
- `cobertura`: lista vertical de comentários com espaçamento coerente;
- `nota`: 8;
- `justificativa`: sequência cronológica de comentários.

2. Box
- `cobertura`: container de cada comentário com borda; destaque para comentário próprio (`bg-primary-50`); timestamp + autor no header;
- `nota`: 7;
- `justificativa`: card de comentário individual.

3. FieldTextArea
- `cobertura`: área de composição de novo comentário; `Rows="3"` para altura inicial; `@bind-Value` para conteúdo;
- `nota`: 8;
- `justificativa`: composer de comentário.

4. Button
- `cobertura`: botão "Comentar" (Themes.Primary) para enviar; "Cancelar" para limpar o composer; estado `Loading=true` durante envio;
- `nota`: 8;
- `justificativa`: ação de envio do comentário.

5. Bar
- `cobertura`: header de cada comentário com autor + timestamp; header da seção de comentários com título e contagem;
- `nota`: 8;
- `justificativa`: layout de metadados de autoria por comentário.

6. DropIconButton
- `cobertura`: menu de ações por comentário (editar, excluir, responder) para o autor;
- `nota`: 7;
- `justificativa`: ações contextuais de comentário.

**Descartados**: nenhum.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `respostas aninhadas`: estado `comentarId` para indicar resposta; indentação via `ml-6` no `Box`;
  - `comentário resolvível`: estado `Resolvido` + `Badge Success` + botão "Marcar como resolvido";
  - `menções (@usuario)`: lógica de autocomplete no composer — sem nativo;
  - `edição inline de comentário`: `UIP-INPUT-INLINE_EDITOR` por comentário.

- `tipo de adaptação`: composição + estado de lista de comentários
- `o que precisa ser feito`:
  - Lista de comentários em `Stack`; composer no fundo (FieldTextArea + Bar de ações);
  - Header por comentário: avatar (div inicial) + nome + timestamp + `DropIconButton` de ações.

## Como usar

### Thread de comentários básica

```razor
@code {
    private string novoComentario = "";
    private bool enviando = false;

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
        <Feedback Style="Themes.Light" Text="Nenhum comentário ainda. Seja o primeiro!" />
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
                                <div class="w-7 h-7 rounded-full bg-primary-100 flex items-center justify-center">
                                    <span class="text-xs font-bold text-primary-600">
                                        @c.AutorNome.Substring(0, 1).ToUpper()
                                    </span>
                                </div>
                                <div>
                                    <span class="text-sm font-semibold text-dark-600">@c.AutorNome</span>
                                    <span class="text-xs text-dark-400 ml-2">@c.CriadoEm.ToString("dd/MM HH:mm")</span>
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

    @* Composer *@
    <FieldTextArea @bind-Value="novoComentario" Rows="3"
                   Placeholder="Escreva um comentário..." />
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

## Decisão de uso

- `nota geral`: 4;
- `limitações`: sem componente de comment thread nativo; toda estrutura é composição manual; sem respostas aninhadas nativas; sem menções; sem reações; sem resolução nativa de thread;
- `recomendação`: `usar com adaptação`
- `justificativa geral`:
  - `Stack` + `Box` + `FieldTextArea` + `Button` + `Bar` formam uma thread de comentários funcional;
  - A lib contribui com os primitivos visuais — lógica de thread, replies e permissões é do app;
  - Nota 4 reflete composição manual completa sem abstração de thread dedicada.
