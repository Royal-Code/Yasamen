# UIP-NAV-STEPPER_INDICATOR - Stepper Indicator

**GAP parcial — sem componente dedicado**

A biblioteca não tem componente de stepper. Requer composição manual com Bar + Badge para indicar progresso.

## Componentes

**Principais**: nenhum.

**Composição**:

1. Bar
- `cobertura`: barra horizontal para os indicadores de etapa;
- `nota`: 5;
- `justificativa`: container visual da barra de etapas.

2. Badge
- `cobertura`: número da etapa com tema (Success para concluída, Primary para atual, light para futura);
- `nota`: 6;
- `justificativa`: indicador visual de estado de etapa — tom pastel para concluída, vibrante para ativa.

3. Button
- `cobertura`: navegação entre etapas (Próximo, Anterior, Cancelar);
- `nota`: 9;
- `justificativa`: ações de progressão do stepper.

**Descartados**: nenhum.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `linha de progresso entre etapas`: implementar com `<div class="flex-1 h-0.5 bg-light-200">` entre badges;
  - `etapa com erro visual`: usar `Badge` com `Themes.Danger`;
  - `validação por etapa antes de avançar`: lógica no app C# com `Disabled` no botão Próximo.

- `tipo de adaptação`: composição + estilos
- `o que precisa ser feito`:
  - Bar com badges numerados e linha entre eles;
  - Estado de etapa por index: `Themes.Success` (concluída), `Themes.Primary` (ativa), `Themes.Light` (futura);
  - Botões Anterior/Próximo/Finalizar com controle de estado via código C#.

## Como usar

### Stepper horizontal (composição manual)

```razor
@code {
    private int etapaAtual = 0;
    private List<string> etapas = ["Dados", "Endereço", "Revisão", "Confirmação"];
    
    private Themes GetEtapaTema(int index)
    {
        if (index < etapaAtual) return Themes.Success;
        if (index == etapaAtual) return Themes.Primary;
        return Themes.Light;
    }
}

<Bar AdditionalClasses="mb-6">
    <StartContent>
        <div class="flex items-center gap-2">
            @for (int i = 0; i < etapas.Count; i++)
            {
                var idx = i;
                <div class="flex items-center gap-2">
                    <Badge Style="@GetEtapaTema(idx)" Text="@((idx+1).ToString())" />
                    <span class="text-sm @(idx == etapaAtual ? "font-semibold text-dark-600" : "text-dark-700")">
                        @etapas[idx]
                    </span>
                    @if (idx < etapas.Count - 1)
                    {
                        <div class="w-8 h-0.5 @(idx < etapaAtual ? "bg-success-400" : "bg-light-200")"></div>
                    }
                </div>
            }
        </div>
    </StartContent>
</Bar>

@* Conteúdo da etapa atual *@
<Box Border="BorderBuilder.Box" AdditionalClasses="p-4 mb-4">
    @* ... conteúdo da etapa etapaAtual *@
</Box>

<Bar>
    <StartContent>
        @if (etapaAtual > 0)
        {
            <Button Style="Themes.Secondary" Outline=true Label="Anterior"
                    OnClick="() => etapaAtual--" />
        }
    </StartContent>
    <EndContent>
        @if (etapaAtual < etapas.Count - 1)
        {
            <Button Style="Themes.Primary" Label="Próximo"
                    OnClick="() => etapaAtual++" />
        }
        else
        {
            <Button Style="Themes.Success" Label="Finalizar" OnClick="Finalizar" />
        }
    </EndContent>
</Bar>
```

## Decisão de uso

- `nota geral`: 3;
- `limitações`: sem componente de stepper — toda estrutura é composição manual; linha de progresso requer HTML div com classes CSS; sem validação de etapa nativa; sem animação de transição entre etapas;
- `recomendação`: `usar com adaptação`
- `justificativa geral`:
  - `Badge` + `Bar` + `Button` formam um stepper funcional mas totalmente manual;
  - Nota 3 reflete que apenas componentes genéricos são usados — nenhum específico de stepper.
