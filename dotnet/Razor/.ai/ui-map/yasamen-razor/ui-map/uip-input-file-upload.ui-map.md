# UIP-INPUT-FILE_UPLOAD - File Upload

**GAP parcial — sem componente dedicado de upload**

A biblioteca não tem componente de file upload. Blazor provê `<InputFile>` nativo para seleção de arquivo. Área de drop, progresso e preview requerem composição manual.

## Componentes

**Principais**: nenhum dedicado.

**Composição**:

1. `<InputFile>` (Blazor nativo)
- `cobertura`: seleção de arquivo via `<InputFile OnChange="CarregarArquivo" accept="..." multiple>`; recebe `IBrowserFile` ou `IReadOnlyList<IBrowserFile>`; acesso a nome, tamanho, tipo e stream;
- `limitações`: sem estilização nativa — usar `<label>` HTML sobre `<InputFile class="hidden">` para estilizar;
- `nota`: 7;
- `justificativa`: componente Blazor nativo para seleção de arquivo — sem custo de lib externa.

2. Button (como trigger)
- `cobertura`: botão "Selecionar arquivo" como label sobre `<InputFile hidden>`;
- `nota`: 7;
- `justificativa`: trigger estilizado para o file input nativo.

3. Feedback (Themes.Danger)
- `cobertura`: erro de validação de tipo ou tamanho do arquivo;
- `nota`: 7;
- `justificativa`: feedback de validação de arquivo rejeitado.

4. Box (como drop zone)
- `cobertura`: área de drop via eventos `@ondragover`/`@ondrop` com estilo pontilhado; sem comportamento nativo de drop;
- `nota`: 4;
- `justificativa`: container visual de drag/drop — requer JS interop ou event handling Blazor.

**Descartados**: nenhum.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `barra de progresso de upload`: sem nativo — `<div>` CSS com `width: @progresso%` ou componente manual;
  - `preview de imagem antes do upload`: `Convert.ToBase64String()` do stream ou `URL.createObjectURL` via JS;
  - `drag/drop`: Blazor suporta eventos `@ondrop` mas requer `@ondragover:preventDefault=true`;
  - `upload em background`: `HttpClient.PostAsync` com `CancellationToken` + `UIP-SYSTEM-BACKGROUND_PROGRESS`.

- `tipo de adaptação`: composição + HTML nativo + lógica C#
- `o que precisa ser feito`:
  - `<InputFile>` hidden + `<label>` estilizado com Button como trigger;
  - Validação em C# (tipo, tamanho) com `Feedback Danger` para erros;
  - Lista de arquivos selecionados com botão de remover por item.

## Como usar

### Upload único

```razor
@code {
    private IBrowserFile? arquivo;
    private string? erroArquivo;

    private async Task CarregarArquivo(InputFileChangeEventArgs e)
    {
        arquivo = e.File;
        erroArquivo = null;
        if (arquivo.Size > 5 * 1024 * 1024)
            erroArquivo = "O arquivo excede o limite de 5MB.";
        else if (!new[] { "image/jpeg", "image/png", "application/pdf" }.Contains(arquivo.ContentType))
            erroArquivo = "Formato não suportado. Use JPG, PNG ou PDF.";
    }
}

<div class="flex flex-col gap-2 mb-4">
    <label class="text-sm font-medium text-dark-600">Documento</label>
    <label class="flex items-center gap-2 cursor-pointer">
        <InputFile class="hidden" accept=".jpg,.png,.pdf" OnChange="CarregarArquivo" />
        <Button Style="Themes.Secondary" Outline=true Label="Selecionar arquivo"
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
```

### Múltiplos anexos com lista

```razor
@code {
    private List<IBrowserFile> anexos = [];

    private void AdicionarAnexos(InputFileChangeEventArgs e)
        => anexos.AddRange(e.GetMultipleFiles(10));

    private void RemoverAnexo(IBrowserFile f) => anexos.Remove(f);
}

<label class="cursor-pointer">
    <InputFile class="hidden" multiple accept=".pdf,.docx,.xlsx"
               OnChange="AdicionarAnexos" />
    <Button Style="Themes.Secondary" Outline=true Label="Adicionar anexos"
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
                        <span class="text-sm">@a.Name</span>
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
```

## Decisão de uso

- `nota geral`: 2;
- `limitações`: sem componente de upload nativo; `<InputFile>` Blazor provê seleção mas sem estilização, preview ou progresso; drag/drop requer event handling manual; progresso de upload requer composição com CSS;
- `recomendação`: `usar com adaptação`
- `justificativa geral`:
  - `<InputFile>` Blazor + `Button` como label + `Feedback` para erros cobrem upload funcional;
  - A lib contribui apenas com elementos de apoio visual — sem abstração de upload;
  - Nota 2 reflete cobertura parcial via primitivos sem componente de upload dedicado.
