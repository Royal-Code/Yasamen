# UIP-INPUT-FILE_UPLOAD - Blueprint resumido

## Pattern

UIP-INPUT-FILE_UPLOAD — File Upload — ver `uip-input-file-upload.ui-map.md`

## Gap coberto

A lib não tem componente de upload. O gap é orientar a composição com `<InputFile>` Blazor oculto + `Button` como label estilizado, validação de tipo/tamanho via `Feedback(Danger)`, e lista de anexos múltiplos com remoção.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `<InputFile class="hidden">` dentro de `<label>` + `Button` como trigger; `IBrowserFile` para acesso a nome/tamanho/tipo; `Feedback(Danger)` para erros; `Box + Bar + IconButton` para lista de arquivos.

## Componentes usados

- `Button` — papel: composição (trigger de seleção) — ver `button.sample.md`
- `Feedback` — papel: composição (erro de validação) — ver `feedback.sample.md`
- `Box` — papel: composição (item de arquivo na lista) — ver `box.sample.md`
- `Bar` — papel: composição (layout do item de arquivo) — ver `bar.sample.md`
- `Badge` — papel: composição (tamanho do arquivo) — ver `badge.sample.md`
- `IconButton` — papel: composição (remover arquivo) — ver `button.sample.md`

## Recursos visuais

- `<InputFile class="hidden">` dentro de `<label>` — estilização via button como trigger
- `accept=".jpg,.png,.pdf"` — filtro de tipos no input nativo
- Validação C#: `arquivo.Size > 5 * 1024 * 1024` para tamanho; `.ContentType` para tipo

## Receita

`<InputFile hidden>` em `<label>` + `Button` como trigger; `Feedback(Danger)` para erros; lista de arquivos com `Box + Bar`.

```razor
@* Upload único com validação *@
@code {
    private IBrowserFile? arquivo;
    private string? erroArquivo;

    private void CarregarArquivo(InputFileChangeEventArgs e)
    {
        arquivo = e.File;
        erroArquivo = null;
        if (arquivo.Size > 5 * 1024 * 1024)
            erroArquivo = "O arquivo excede o limite de 5MB.";
        else if (!new[] { "image/jpeg", "image/png", "application/pdf" }
                      .Contains(arquivo.ContentType))
            erroArquivo = "Formato não suportado. Use JPG, PNG ou PDF.";
    }
}

<div class="flex flex-col gap-2 mb-4">
    <label class="text-sm font-medium text-dark-600">Documento</label>
    <label class="flex items-center gap-2 cursor-pointer w-fit">
        <InputFile class="hidden" accept=".jpg,.png,.pdf" OnChange="CarregarArquivo" />
        <Button Style="Themes.Secondary" Outline=true
                Label="Selecionar arquivo"
                Icon="WellKnownIcons.Upload" type="button" />
        @if (arquivo is not null)
        {
            <span class="text-sm text-dark-600">@arquivo.Name</span>
            <Badge Style="Themes.Light" Text="@($"{arquivo.Size / 1024}KB")" />
        }
    </label>
    @if (erroArquivo is not null)
    {
        <Feedback Style="Themes.Danger" Text="@erroArquivo" />
    }
</div>

@* Múltiplos anexos com lista e remoção *@
@code {
    private List<IBrowserFile> anexos = [];

    private void AdicionarAnexos(InputFileChangeEventArgs e)
        => anexos.AddRange(e.GetMultipleFiles(10));

    private void RemoverAnexo(IBrowserFile f) => anexos.Remove(f);
}

<div class="mb-4">
    <label class="cursor-pointer w-fit block">
        <InputFile class="hidden" multiple accept=".pdf,.docx,.xlsx"
                   OnChange="AdicionarAnexos" />
        <Button Style="Themes.Secondary" Outline=true
                Label="Adicionar anexos"
                Icon="WellKnownIcons.Attach" type="button" />
    </label>

    @if (anexos.Any())
    {
        <Stack Gap="Gaps.Small" AdditionalClasses="mt-2">
            @foreach (var a in anexos)
            {
                <Box Border="BorderBuilder.Box" AdditionalClasses="p-2">
                    <Bar>
                        <StartContent>
                            <Icon Kind="WellKnownIcons.File"
                                  class="text-dark-400 flex-shrink-0" />
                            <span class="text-sm text-dark-600 ml-2">@a.Name</span>
                            <Badge Style="Themes.Light" Text="@($"{a.Size / 1024}KB")"
                                   AdditionalClasses="ml-2" />
                        </StartContent>
                        <EndContent>
                            <IconButton Icon="WellKnownIcons.Close" Style="Themes.Default"
                                        Size="Sizes.Small" OnClick="() => RemoverAnexo(a)" />
                        </EndContent>
                    </Bar>
                </Box>
            }
        </Stack>
    }
</div>
```

## Limites

- `<InputFile>` dentro de `<label>` funciona mas `type="button"` no `Button` deve estar presente para evitar submit do form;
- Preview de imagem antes do upload requer `Convert.ToBase64String()` ou JS interop com `URL.createObjectURL`;
- Barra de progresso de upload requer estado `progresso` + div CSS com `width: @progresso%` manual;
- Drag/drop requer `@ondragover:preventDefault=true` + `@ondrop` no container — não incluído aqui por complexidade.
