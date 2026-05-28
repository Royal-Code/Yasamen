# UIP-INPUT-VALIDATION_SUMMARY - Validation Summary

## Componentes

**Principais**:

1. Feedback (Themes.Danger)
- `cobertura`: bloco de resumo de erros de validação com título + lista de mensagens; posicionado no topo do formulário ou antes do botão de submissão; integra com erros gerados por `EditContext` do Blazor;
- `limitações`: sem lista de links/âncoras para campos específicos nativa; sem `aria-live` automático;
- `nota`: 7;
- `justificativa`: container visual adequado para resumo de erros — tema Danger sinaliza corretamente a necessidade de correção.

**Composição**:

1. `<ValidationSummary>` (Blazor nativo)
- `cobertura`: componente Blazor nativo que lista todos os erros do `EditForm` atual; sem estilização visual — requer CSS override com `AdditionalClasses`;
- `nota`: 6;
- `justificativa`: fonte de dados de erros nativos do Blazor — pode ser wrappado em `Feedback`.

2. Badge (Themes.Danger)
- `cobertura`: contador de erros pendentes exibido no título da seção ou no botão de submissão;
- `nota`: 6;
- `justificativa`: indicador visual de quantidade de erros pendentes.

**Descartados**: nenhum.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `links/âncoras para campos inválidos`: sem nativo — usar JS interop `element.scrollIntoView()` ou `@ref` + foco;
  - `resumo por seção`: filtrar erros por seção do EditContext manualmente;
  - `aria-live para leitores de tela`: adicionar `role="alert"` via HTML wrapper.

- `tipo de adaptação`: composição direta
- `o que precisa ser feito`:
  - Usar `Feedback Danger` como wrapper do `<ValidationSummary>` nativo;
  - Exibir condicionalmente apenas quando `EditContext.GetValidationMessages().Any()`;
  - Badge com contagem no header do formulário para formulários longos.

## Como usar

### ValidationSummary nativo wrappado em Feedback

```razor
<EditForm Model="@model" OnValidSubmit="Salvar">
    <DataAnnotationsValidator />

    @if (editContext?.GetValidationMessages().Any() == true && tentouSubmeter)
    {
        <Feedback Style="Themes.Danger" AdditionalClasses="mb-4">
            <ChildContent>
                <p class="font-semibold mb-1">Corrija os seguintes erros antes de continuar:</p>
                <ValidationSummary class="list-disc list-inside text-sm" />
            </ChildContent>
        </Feedback>
    }

    @* ... campos do formulário *@
    
    <Bar AdditionalClasses="mt-6">
        <EndContent>
            <Button Style="Themes.Primary" Label="Salvar"
                    OnClick="() => tentouSubmeter = true" />
        </EndContent>
    </Bar>
</EditForm>

@code {
    private EditContext? editContext;
    private bool tentouSubmeter = false;

    protected override void OnInitialized()
        => editContext = new EditContext(model);
}
```

### Badge de contagem de erros no botão

```razor
<Button Style="Themes.Primary" Loading="@salvando">
    <ChildContent>
        Salvar
        @if (erros > 0)
        {
            <Badge Style="Themes.Warning" Text="@erros.ToString()" AdditionalClasses="ml-2" />
        }
    </ChildContent>
</Button>
```

### Resumo de erros por seção (wizard)

```razor
@if (errosEtapaAtual.Any())
{
    <Feedback Style="Themes.Warning" AdditionalClasses="mb-4">
        <ChildContent>
            <p class="font-semibold mb-1">Esta etapa tem @errosEtapaAtual.Count pendência(s):</p>
            <ul class="list-disc list-inside text-sm">
                @foreach (var e in errosEtapaAtual)
                {
                    <li>@e</li>
                }
            </ul>
        </ChildContent>
    </Feedback>
}
```

## Decisão de uso

- `nota geral`: 7;
- `limitações`: sem links para campos específicos; `<ValidationSummary>` requer CSS override para integrar visualmente com Feedback; aria-live requer atributo HTML manual;
- `recomendação`: `usar por composição`
- `justificativa geral`:
  - `Feedback Danger` wrappando `<ValidationSummary>` cobre o resumo de erros de submissão;
  - Integração nativa com `EditForm` + `DataAnnotationsValidator` do Blazor;
  - Nota 7 reflete boa cobertura com limitação apenas em âncoras para campos específicos.
