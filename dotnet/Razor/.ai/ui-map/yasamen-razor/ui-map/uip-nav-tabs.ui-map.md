# UIP-NAV-TABS - Tabs

**GAP parcial — sem componente dedicado de tabs**

A biblioteca não tem componente de tabs. Requer composição com Bar + Button para simular a barra de tabs e controle de conteúdo ativo via estado C#.

## Componentes

**Principais**: nenhum dedicado.

**Composição**:

1. Bar
- `cobertura`: barra horizontal para os itens de tab; Start/Center/End para alinhamento;
- `limitações`: sem comportamento de tab nativo; sem indicador de tab ativa via linha inferior;
- `nota`: 5;
- `justificativa`: container visual adequado para a barra de tabs.

2. Button
- `cobertura`: item de tab com estado ativo via `Active=true` e `Outline=false`; estilo flat via `Style=Themes.Default`;
- `limitações`: visual de "tab ativa" via background filled — não é linha inferior como tabs tradicionais; sem scroll horizontal de overflow nativo;
- `nota`: 5;
- `justificativa`: item de tab funcional com estado ativo, mas sem estilo de tab típico.

3. Box
- `cobertura`: container do conteúdo ativo da tab;
- `nota`: 7;
- `justificativa`: delimita o painel da tab ativa.

**Descartados**: nenhum.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `indicador visual de tab ativa (linha inferior)`: não nativo — o Active do Button usa background filled; implementar linha inferior via CSS customizado se necessário;
  - `scroll horizontal de overflow de tabs`: não automático — requer `overflow-x-auto` via AdditionalClasses;
  - `badge/contagem por tab`: adicionar `Badge` como ChildContent do Button;
  - `tab desativada`: usar `Disabled=true` no Button.

- `tipo de adaptação`: composição + estilos
- `o que precisa ser feito`:
  - Barra de tabs: `Bar` + `ButtonGroup` com `Button` por tab (cada um com `Active="@(abaAtiva==i)"`);
  - Conteúdo de tab: bloco `@if (abaAtiva == "nome")` com `Box` como container;
  - Para estilo de linha inferior: CSS customizado via `AdditionalClasses` ou estilo inline.

## Como usar

### Tabs básicas (composição)

```razor
@code {
    private string abaAtiva = "geral";
}

<Bar AdditionalClasses="border-b border-light-200 mb-4">
    <StartContent>
        <ButtonGroup>
            <Button Label="Geral" Style="Themes.Default"
                    Active="@(abaAtiva=="geral")"
                    OnClick="() => abaAtiva = "geral"" />
            <Button Label="Histórico" Style="Themes.Default"
                    Active="@(abaAtiva=="historico")"
                    OnClick="() => abaAtiva = "historico"" />
            <Button Label="Arquivos" Style="Themes.Default"
                    Active="@(abaAtiva=="arquivos")"
                    OnClick="() => abaAtiva = "arquivos"" />
        </ButtonGroup>
    </StartContent>
</Bar>

@if (abaAtiva == "geral")
{
    <Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
        @* conteúdo da aba Geral *@
    </Box>
}
else if (abaAtiva == "historico")
{
    <Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
        @* conteúdo da aba Histórico *@
    </Box>
}
else if (abaAtiva == "arquivos")
{
    <Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
        @* conteúdo da aba Arquivos *@
    </Box>
}
```

### Tab com badge de contagem

```razor
<Button Label="Mensagens" Style="Themes.Default" Active="@(abaAtiva=="msgs")"
        OnClick="() => abaAtiva = "msgs"">
    <ChildContent>
        Mensagens <Badge Style="Themes.Danger" Text="@($"{mensagensNaoLidas}")" 
                        AdditionalClasses="ml-2" />
    </ChildContent>
</Button>
```

## Decisão de uso

- `nota geral`: 3;
- `limitações`: sem componente de tabs nativo; visual de ativa usa background filled (não linha inferior); sem scroll de overflow automático; badge por tab requer ChildContent; implementação manual de estado de aba ativa;
- `recomendação`: `usar com adaptação`
- `justificativa geral`:
  - `Bar` + `ButtonGroup` + `Button Active` constroem um tab bar funcional mas com visual de botão ativo, não de tab com linha inferior;
  - O estado da aba ativa é gerenciado pelo app via variável C# — sem abstração de tabs;
  - Nota 3 reflete que a composição é totalmente manual sem suporte visual de tabs da lib.
