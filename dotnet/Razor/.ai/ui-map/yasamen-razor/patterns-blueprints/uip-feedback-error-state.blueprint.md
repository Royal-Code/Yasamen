# UIP-FEEDBACK-ERROR_STATE - Blueprint resumido

## Pattern

UIP-FEEDBACK-ERROR_STATE — Error State — ver `uip-feedback-error-state.ui-map.md`

## Gap coberto

`Feedback(Danger)` cobre o erro básico, mas não há orientação sobre os cenários distintos: erro de campo de formulário, erro de zona/lista, e erro crítico de página inteira. O gap é mapear cada cenário ao componente correto.

## Estratégia

- `tipo de artefato`: composição apenas
- `decisão`: `Feedback(Danger)` + ação de retry cobre os cenários inline e de zona; erros de validação de formulário usam `ValidationSummary` + `Feedback`.

## Componentes usados

- `Feedback` — papel: principal — ver `feedback.sample.md`
- `Button` — papel: composição (retry) — ver `button.sample.md`
- `Stack` — papel: composição — ver `stack.sample.md`

## Recursos visuais

- `Themes.Danger` — tom semântico de erro
- `Themes.Warning` — para avisos (não erros críticos)
- `flex-1 flex items-center justify-center` — centralização de erro de página inteira

## Receita

Mapear erro ao contexto: inline para campo/validação, `Feedback` para zona, centralizado para página inteira.

```razor
@code {
    private string? erroCarregamento;
    private string? erroSubmit;

    private async Task Carregar()
    {
        erroCarregamento = null;
        try { dados = await Service.ObterAsync(); }
        catch (Exception ex) { erroCarregamento = "Erro ao carregar dados. Tente novamente."; }
    }

    private async Task Salvar()
    {
        erroSubmit = null;
        try { await Service.SalvarAsync(model); }
        catch (Exception ex) { erroSubmit = ex.Message; }
    }
}

@* Erro de zona (substitui o conteúdo da zona) *@
@if (erroCarregamento is not null)
{
    <Feedback Style="Themes.Danger" Text="@erroCarregamento">
        <ChildContent>
            <Button Style="Themes.Danger" Outline=true Size="Sizes.Small"
                    Label="Tentar novamente" OnClick="Carregar" />
        </ChildContent>
    </Feedback>
}

@* Erro de submit de formulário (acima das ações) *@
@if (erroSubmit is not null)
{
    <Feedback Style="Themes.Danger" Text="@erroSubmit" AdditionalClasses="mb-4" />
}

@* Erro de página inteira *@
@if (erroCarregamento is not null && !dados.Any())
{
    <div class="flex-1 flex items-center justify-center p-8">
        <div class="text-center max-w-xs">
            <div class="w-16 h-16 rounded-full bg-danger-50 flex items-center justify-center
                        mx-auto mb-4">
                <Icon Kind="WellKnownIcons.Alert" AdditionalClasses="text-danger-500" />
            </div>
            <h3 class="text-base font-semibold text-dark-700 mb-1">Erro ao carregar</h3>
            <p class="text-sm text-dark-400 mb-4">@erroCarregamento</p>
            <Button Style="Themes.Primary" Label="Tentar novamente" OnClick="Carregar" />
        </div>
    </div>
}

@* Erro de validação em formulário *@
<EditForm Model="model" OnValidSubmit="Salvar">
    <DataAnnotationsValidator />
    <ValidationSummary />  @* Blazor nativo — erros de campo *@
    @* ... campos ... *@
    @if (erroSubmit is not null)
    {
        <Feedback Style="Themes.Danger" Text="@erroSubmit" AdditionalClasses="mt-2" />
    }
</EditForm>
```

## Limites

- Cores de `Themes.Danger` dependem do token CSS configurado pelo `YasamenStyles` — verificar tokens em `visual.map.md`;
- `WellKnownIcons.Alert` — verificar se o ícone existe no enum; usar alternativa disponível se necessário.
