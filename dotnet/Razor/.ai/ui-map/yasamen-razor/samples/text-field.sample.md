# TextField - Sample

## Contrato de uso

**Entrada pública**: `<TextField>` — namespace `RoyalCode.Razor.Forms`
**Grupo**: UI-INPUT
**Propósito**: Campo de texto completo com label, placeholder, erro, informação, prepend/append, integração com `EditForm` e DataAnnotations. É o único componente de input de texto da biblioteca.
**Patterns**:
- `implementa`: UIP-INPUT-INPUT_FIELD
- `compõe`: UIP-INPUT-SEARCH_BAR, UIP-INPUT-FILTER_PANEL, UIP-INPUT-INLINE_EDITOR, UIP-ACTION-COMMAND_PALETTE
**Setup necessário**: `builder.Services.AddYasamenCommons()` + `<YasamenStyles />` no `<head>`

## Regras rápidas

- **Use para**: captura de texto e senha em formulários, busca inline, filtros de texto, editores de campo simples
- **Evite quando**: precisa de select/checkbox/radio/número — não existem na lib; use `<InputSelect>`, `<InputCheckbox>`, `<InputNumber>` do Blazor com label manual
- **Cuidado**: `InputType` suporta apenas `Text` (default) e `Password` — não há `Email`, `Date`, `Tel`, `Number`; para email, use `required` + `type="email"` via `AdditionalAttributes`, para número use `<InputNumber>`

## Exemplos

### `UIP-INPUT-INPUT_FIELD` — Campo de formulário com EditForm

Use dentro de `EditForm` para binding, label automático via DataAnnotations e validação integrada. Adornos (prefixo/sufixo) via Prepend/Append.

```razor
@code {
    private FormModel model = new();

    public class FormModel
    {
        [Required, MaxLength(100)]
        public string Nome { get; set; } = "";

        [Required]
        public string Senha { get; set; } = "";

        public string? Site { get; set; }
        public string? Valor { get; set; }
    }
}

<EditForm Model="model" OnValidSubmit="Salvar">
    <DataAnnotationsValidator />

    @* Label e placeholder básicos *@
    <TextField @bind-Value="model.Nome"
               Label="Nome completo"
               Placeholder="Ex: Maria Silva"
               required />

    @* Senha — único tipo alternativo ao Text *@
    <TextField @bind-Value="model.Senha"
               Label="Senha"
               Type="InputType.Password"
               required />

    @* Prefixo textual com FieldText no Prepend *@
    <TextField @bind-Value="model.Site"
               Label="Site"
               Placeholder="meusite.com">
        <Prepend>
            <FieldText>https://</FieldText>
        </Prepend>
    </TextField>

    @* Prefixo de moeda com FieldBadge + informação de ajuda *@
    <TextField @bind-Value="model.Valor"
               Label="Valor"
               Information="Informe o valor em reais">
        <Prepend>
            <FieldBadge Style="Themes.Secondary" Text="R$" />
        </Prepend>
    </TextField>

    <Bar AdditionalClasses="mt-4">
        <EndContent>
            <Button Style="Themes.Primary" Label="Salvar" Type="ButtonTypes.Submit" />
        </EndContent>
    </Bar>
</EditForm>
```

**API usada**: `@bind-Value`, `Label`, `Placeholder`, `Type`, `Information`, `Prepend`
**Nota**: `required` é atributo HTML passado via `AdditionalAttributes`; não é parâmetro declarado.

### `UIP-INPUT-SEARCH_BAR, UIP-INPUT-FILTER_PANEL` — Busca com debounce e filtro de texto

Para busca em tempo real, implemente debounce com `@oninput` em vez de `@bind-Value`.

```razor
@code {
    private string busca = "";
    private CancellationTokenSource? _debounce;

    private async Task OnBusca(ChangeEventArgs e)
    {
        busca = e.Value?.ToString() ?? "";
        _debounce?.Cancel();
        _debounce = new CancellationTokenSource();
        try
        {
            await Task.Delay(350, _debounce.Token);
            await Buscar();
        }
        catch (TaskCanceledException) { }
    }
}

@* Search bar com debounce *@
<TextField @bind-Value="busca"
           @oninput="OnBusca"
           Placeholder="Buscar..."
           AdditionalClasses="w-64">
    <Prepend>
        <FieldAction Icon="WellKnownIcons.Search"
                     Style="Themes.Default"
                     OnClick="Buscar" />
    </Prepend>
</TextField>

@* Filter panel: campo de texto de filtro *@
<div class="flex flex-col gap-3">
    <p class="text-xs font-semibold text-dark-500 uppercase">Busca por nome</p>
    <TextField @bind-Value="filtroNome"
               Placeholder="Filtrar por nome..."
               Size="Sizes.Small" />
</div>
```

**API usada**: `@oninput` via AdditionalAttributes, `Prepend`, `FieldAction`, `Size`
**Nota**: `@oninput` é capturado via `AdditionalAttributes (CaptureUnmatchedValues)`.

### `UIP-INPUT-INLINE_EDITOR, UIP-ACTION-COMMAND_PALETTE` — Edição inline e busca em modal

Para edição inline, renderize o TextField condicionalmente; para command palette, foque automaticamente com `autofocus`.

```razor
@code {
    private bool editando;
    private string valorEdicao = "Título do projeto";
}

@* Inline editor — toggle entre texto e input *@
@if (editando)
{
    <TextField @bind-Value="valorEdicao"
               autofocus
               Size="Sizes.Small">
        <Append>
            <FieldAction Icon="WellKnownIcons.Check"
                         Style="Themes.Success"
                         OnClick="() => editando = false" />
            <FieldAction Icon="WellKnownIcons.Close"
                         Style="Themes.Default"
                         OnClick="() => { editando = false; }" />
        </Append>
    </TextField>
}
else
{
    <span class="cursor-pointer hover:underline text-dark-700"
          @onclick="() => editando = true">@valorEdicao</span>
}

@* Command palette: input de busca com autofocus no modal *@
<Modal Id="modal-comando">
    <ChildContent>
        <TextField @bind-Value="buscaComando"
                   Placeholder="Digite um comando..."
                   autofocus />
        @* Lista de resultados abaixo *@
    </ChildContent>
</Modal>
```

**API usada**: `autofocus` (via AdditionalAttributes), `Append`, `FieldAction`
**Nota**: `autofocus` é atributo HTML padrão capturado via `AdditionalAttributes`.

## API relevante

| Parâmetro | Tipo | Default | Uso |
|---|---|---|---|
| `@bind-Value` | `string` | — | Two-way binding do valor de texto |
| `Type` | `InputType` | Text | Text ou Password — únicos valores suportados |
| `Label` | `string?` | null | Label; auto-detectado via DataAnnotations em EditForm |
| `Placeholder` | `string?` | null | Placeholder do input |
| `Information` | `string?` | null | Texto de ajuda abaixo do campo |
| `Error` | `string?` | null | Mensagem de erro manual (complementa DataAnnotations) |
| `Disabled` | `bool` | false | Desabilita o campo |
| `ReadOnly` | `bool` | false | Somente leitura |
| `Size` | `Sizes` | Medium | Densidade visual |
| `Prepend` | `RenderFragment` | — | Conteúdo antes do input (FieldText, FieldBadge, FieldAction) |
| `Append` | `RenderFragment` | — | Conteúdo após o input |
| `DescriptionComplement` | `RenderFragment` | — | Conteúdo adicional na linha do label (FieldBadge) |
| `FooterAction` | `RenderFragment` | — | Ação no rodapé do campo (FieldAction) |

- **Atributos HTML via AdditionalAttributes**: `required`, `autofocus`, `type` (para override de type HTML), `@oninput`, `@onkeydown`, etc.

## Limites e combinações frágeis

- `InputType` só suporta `Text` e `Password`; para `email`, passar `type="email"` via `AdditionalAttributes` — o input HTML aceita mas sem validação automática da lib
- `FieldText` em `Prepend`/`Append` é decorativo (texto estático) — não confundir com `TextField` (o input)
- Dentro de `EditForm`, `Label` é inferido automaticamente via `DisplayAttribute` do modelo — declarar `Label` explicitamente sobrescreve o inferido

## Defaults importantes

- `Type` default `InputType.Text`: para senha, sempre declarar `Type="InputType.Password"` explicitamente
