# UIP-STRUCT-COLLAPSIBLE_SECTION - Collapsible Section

**GAP parcial — sem componente dedicado**

A biblioteca não tem componente de seção colapsável/accordion. Requer composição com estado `bool expandido` + `Bar` como cabeçalho clicável + `@if` para conteúdo + ícone de chevron via `WellKnownIcons`.

## Componentes

**Principais**: nenhum dedicado.

**Composição**:

1. Bar (cabeçalho da seção)
- `cobertura`: linha de cabeçalho clicável com título, badge de status/contagem, ícone de expand/collapse; `cursor-pointer` + `@onclick` no `Bar`;
- `nota`: 7;
- `justificativa`: cabeçalho da seção colapsável com zonas Start/End — exatamente o padrão.

2. Box (container da seção)
- `cobertura`: borda de seção com `Border=BorderBuilder.Box`; padding de conteúdo; separação visual de seções;
- `nota`: 7;
- `justificativa`: container visual da seção com borda.

3. IconButton / WellKnownIcons (indicador de estado)
- `cobertura`: ícone `ChevronDown`/`ChevronRight` ou `ChevronUp`/`ChevronDown` para indicar estado expandido/recolhido;
- `nota`: 8;
- `justificativa`: indicador visual de estado da seção.

4. Badge (estado e contagem no cabeçalho)
- `cobertura`: contagem de itens, status de erro/aviso, badge de "N campos" no cabeçalho;
- `nota`: 8;
- `justificativa`: indicador de estado sem expandir.

5. Feedback (callout de erro no conteúdo interno)
- `cobertura`: erro de validação ou aviso dentro da seção expandida;
- `nota`: 8;
- `justificativa`: estado de erro da seção.

**Descartados**: nenhum.

## Esforço de adaptação

- `requisitos bem cobertos`:
  - cabeçalho clicável com título + ícone de toggle: `Bar @onclick` + `WellKnownIcons`;
  - conteúdo expandido/recolhido: `@if (expandido) { ... }`;
  - múltiplas seções independentes: `HashSet<string>` de IDs expandidos;
  - badge de contagem ou erro no cabeçalho: `Badge` no `EndContent` do `Bar`.

- `requisitos mal cobertos`:
  - `animação de expand/collapse`: sem transição CSS nativa — `@if` é substituição instantânea; animação requer CSS `transition` em `max-height` com JS ou `grid-template-rows`;
  - `accordion exclusivo (um por vez)`: lógica C# manual com `string? expandidoAtual`;
  - `estado persistido entre sessões`: `localStorage` via JS interop.

- `tipo de adaptação`: composição com estado local
- `o que precisa ser feito`:
  - `bool expandido` por seção (ou `HashSet<string>` para múltiplas);
  - `Bar` como cabeçalho com `@onclick` + `ChevronDown/Up` no EndContent;
  - `@if (expandido)` envolve o conteúdo da seção.

## Como usar

### Seção colapsável simples

```razor
@code {
    private bool expandido = true;
}

<Box Border="BorderBuilder.Box" AdditionalClasses="overflow-hidden">
    <Bar AdditionalClasses="px-4 py-3 cursor-pointer bg-light-50 border-b border-light-200
                            hover:bg-light-100 transition-colors select-none"
         @onclick="() => expandido = !expandido">
        <StartContent>
            <div class="flex items-center gap-2">
                @WellKnownIcons.Folder("text-dark-400 text-sm")
                <span class="text-sm font-semibold text-dark-600">Dados pessoais</span>
            </div>
        </StartContent>
        <EndContent>
            <div class="flex items-center gap-2">
                <Badge Style="Themes.Light" Text="4 campos" />
                @WellKnownIcons.RawHtml(expandido ? "&#x25B2;" : "&#x25BC;",
                                       "text-dark-400 text-xs")
            </div>
        </EndContent>
    </Bar>
    @if (expandido)
    {
        <div class="p-4">
            <FormGroup>
                <FieldText @bind-Value="model.Nome" Label="Nome" Required />
                <FieldText @bind-Value="model.Email" Label="E-mail" Type="email" />
                <FieldText @bind-Value="model.Telefone" Label="Telefone" />
                <FieldText @bind-Value="model.Cpf" Label="CPF" />
            </FormGroup>
        </div>
    }
</Box>
```

### Accordion múltiplo (várias seções independentes)

```razor
@code {
    private HashSet<string> expandidas = ["basico"];

    private void Toggle(string id)
    {
        if (expandidas.Contains(id)) expandidas.Remove(id);
        else expandidas.Add(id);
    }

    private bool IsExpandida(string id) => expandidas.Contains(id);
}

<Stack Gap="Gaps.Small">
    @foreach (var secao in secoes)
    {
        <Box Border="BorderBuilder.Box" AdditionalClasses="overflow-hidden">
            <Bar AdditionalClasses="px-4 py-3 cursor-pointer select-none
                                    hover:bg-light-50 transition-colors
                                    @(IsExpandida(secao.Id) ? "border-b border-light-200" : "")"
                 @onclick="() => Toggle(secao.Id)">
                <StartContent>
                    <span class="text-sm font-semibold text-dark-600">@secao.Titulo</span>
                </StartContent>
                <EndContent>
                    <div class="flex items-center gap-2">
                        @if (secao.TemErro)
                        {
                            <Badge Style="Themes.Danger" Text="Erro" />
                        }
                        else if (secao.Count > 0)
                        {
                            <Badge Style="Themes.Light" Text="@secao.Count.ToString()" />
                        }
                        <span class="text-dark-400 text-xs">
                            @(IsExpandida(secao.Id) ? "▲" : "▼")
                        </span>
                    </div>
                </EndContent>
            </Bar>
            @if (IsExpandida(secao.Id))
            {
                <div class="p-4">
                    @secao.ConteudoRender
                </div>
            }
        </Box>
    }
</Stack>
```

### Accordion exclusivo (um por vez)

```razor
@code {
    private string? expandidaAtual = "secao1";

    private void Expandir(string id) =>
        expandidaAtual = expandidaAtual == id ? null : id;
}

<Stack Gap="Gaps.Small">
    @foreach (var secao in secoes)
    {
        var id = secao.Id;
        var expandida = expandidaAtual == id;
        <Box Border="BorderBuilder.Box" AdditionalClasses="overflow-hidden">
            <Bar AdditionalClasses="px-4 py-3 cursor-pointer select-none
                                    @(expandida ? "bg-primary-50 border-b border-primary-200" : "hover:bg-light-50")"
                 @onclick="() => Expandir(id)">
                <StartContent>
                    <span class="@(expandida ? "text-primary-700" : "text-dark-600") text-sm font-semibold">
                        @secao.Titulo
                    </span>
                </StartContent>
                <EndContent>
                    <span class="@(expandida ? "text-primary-500" : "text-dark-400") text-xs">
                        @(expandida ? "▲" : "▼")
                    </span>
                </EndContent>
            </Bar>
            @if (expandida)
            {
                <div class="p-4">
                    @secao.ConteudoRender
                </div>
            }
        </Box>
    }
</Stack>
```

### Seção com erro sinalizado no cabeçalho

```razor
@code {
    private bool expandida = false;
    private bool temErro = true;
}

<Box Border="BorderBuilder.Box"
     AdditionalClasses="@(temErro ? "border-danger-300" : "") overflow-hidden">
    <Bar AdditionalClasses="px-4 py-3 cursor-pointer select-none hover:bg-light-50"
         @onclick="() => expandida = !expandida">
        <StartContent>
            <div class="flex items-center gap-2">
                <span class="text-sm font-semibold text-dark-600">Endereço</span>
                @if (temErro)
                {
                    <Badge Style="Themes.Danger" Text="Incompleto" />
                }
            </div>
        </StartContent>
        <EndContent>
            <span class="text-dark-400 text-xs">@(expandida ? "▲" : "▼")</span>
        </EndContent>
    </Bar>
    @if (expandida)
    {
        <div class="p-4">
            @if (temErro)
            {
                <Feedback Style="Themes.Danger" Text="Preencha todos os campos obrigatórios." />
            }
            <FormGroup AdditionalClasses="mt-3">
                <FieldText @bind-Value="endereco.Cep" Label="CEP" Required />
                <FieldText @bind-Value="endereco.Logradouro" Label="Logradouro" Required />
            </FormGroup>
        </div>
    }
</Box>
```

## Decisão de uso

- `nota geral`: 4;
- `limitações`: sem componente de accordion/collapsible nativo; animação de expand/collapse é substitução instantânea (`@if`); toda estrutura é composição manual; estado de seções persistido entre sessões requer JS;
- `recomendação`: `usar com adaptação`
- `justificativa geral`:
  - `Bar` + `Box` + estado C# cobrem seção colapsável funcional com cabeçalho, ícone e conteúdo;
  - `Badge` no cabeçalho cobre sinalização de erro e contagem sem expandir;
  - Nota 4 reflete boa cobertura funcional sem abstração dedicada e sem animação nativa.
