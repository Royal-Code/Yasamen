# UIP-INPUT-VALIDATION_SUMMARY - Blueprint resumido

## Pattern

UIP-INPUT-VALIDATION_SUMMARY — Validation Summary — ver `uip-input-validation-summary.ui-map.md`

## Gap coberto

`Feedback(Danger)` cobre o resumo visual de erros mas não renderiza as mensagens do `EditContext` automaticamente. O gap é orientar o wrapping de `<ValidationSummary>` Blazor dentro do `Feedback` e o controle de exibição pós-submissão.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `Feedback(Danger, ChildContent)` wrappando `<ValidationSummary>` nativo; exibição condicional via `tentouSubmeter && editContext?.GetValidationMessages().Any()`; `Badge(Danger)` para contador de erros no header.

## Componentes usados

- `Feedback` — papel: principal (container de erros) — ver `feedback.sample.md`
- `Badge` — papel: composição (contador de erros) — ver `badge.sample.md`

## Recursos visuais

- `Feedback(Themes.Danger)` — container vermelho de erros
- `ValidationSummary class="list-disc list-inside text-sm"` — lista de erros nativos do Blazor
- `Feedback(Themes.Warning)` — avisos não-bloqueantes (ex.: campos opcionais ausentes)

## Receita

`Feedback(Danger) + ValidationSummary` condicional ao `tentouSubmeter`; `Badge` com contagem para formulários longos.

```razor
@code {
    private EditContext? editContext;
    private bool tentouSubmeter;

    protected override void OnInitialized()
        => editContext = new EditContext(model);
}

<EditForm EditContext="editContext" OnValidSubmit="Salvar">
    <DataAnnotationsValidator />

    @* Resumo de erros — exibido apenas após tentativa de submissão *@
    @if (tentouSubmeter && editContext!.GetValidationMessages().Any())
    {
        <Feedback Style="Themes.Danger" AdditionalClasses="mb-4" role="alert">
            <ChildContent>
                <p class="font-semibold mb-1">
                    Corrija os erros abaixo antes de continuar:
                </p>
                <ValidationSummary class="list-disc list-inside text-sm mt-1" />
            </ChildContent>
        </Feedback>
    }

    @* ... campos do formulário ... *@

    <Bar AdditionalClasses="mt-6">
        <EndContent>
            <Button Style="Themes.Secondary" Outline=true Label="Cancelar" />
            <Button Style="Themes.Primary" Label="Salvar" Loading="@salvando"
                    OnClick="() => tentouSubmeter = true" />
        </EndContent>
    </Bar>
</EditForm>

@* Badge de contagem de erros no título do formulário *@
<Bar AdditionalClasses="mb-4">
    <StartContent>
        <h2 class="text-base font-semibold text-dark-700">Dados do cadastro</h2>
        @{var erros = editContext?.GetValidationMessages().Count() ?? 0;}
        @if (erros > 0)
        {
            <Badge Style="Themes.Danger" Text="@erros.ToString()" AdditionalClasses="ml-2" />
        }
    </StartContent>
</Bar>

@* Resumo por seção (wizard) — erros manuais *@
@if (errosEtapa.Any())
{
    <Feedback Style="Themes.Warning" AdditionalClasses="mb-4">
        <ChildContent>
            <p class="font-semibold mb-1">
                Esta etapa tem @errosEtapa.Count pendência(s):
            </p>
            <ul class="list-disc list-inside text-sm">
                @foreach (var e in errosEtapa)
                {
                    <li>@e</li>
                }
            </ul>
        </ChildContent>
    </Feedback>
}
```

## Limites

- `<ValidationSummary>` não renderiza links para campos específicos — scroll até o campo requer JS interop;
- `editContext?.GetValidationMessages()` força re-render manual — acionar via `editContext.OnValidationStateChanged` para reatividade automática;
- `role="alert"` no container melhora acessibilidade para leitores de tela mas não é automático na lib.
