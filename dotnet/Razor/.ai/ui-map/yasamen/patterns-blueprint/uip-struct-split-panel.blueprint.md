# UIP-STRUCT-SPLIT_PANEL - Blueprint

## Identificação
- **Pattern**: UIP-STRUCT-SPLIT_PANEL - Split Panel.
- **Nível final**: completo.
- **Cobertura atual**: 5.
- **Meta de cobertura proposta**: 8.
- **Evidências usadas**: `ui-map.md`, `ui_struct.pattern.md`, samples de `Container`, `Slot`, `Box`, `OffCanvas`, `Button`, `Feedback`, `visual.language.md` e `styles.map.md`.

## Resumo executivo
Yasamen monta dois painéis com `Container` e `Slot`, e usa `OffCanvas` para alternativa mobile, mas não possui split panel com estado, colapso ou resize. O blueprint propõe `SplitPanel` como composição responsiva.

## Requisitos ainda não atendidos
- Painel primário e secundário com responsabilidades explícitas.
- Estado de foco/seleção.
- Colapso ou alternância mobile.
- Empty state do painel secundário.
- Resize opcional marcado como externo.

## Diagnóstico estruturado do gap
`Container`/`Slot` entrega estrutura; `Box` entrega painel; `OffCanvas` entrega secundário em mobile. Falta contrato de sincronização, foco e estado do painel.

## Justificativa detalhada da meta
Sem resize nativo, a meta 8 cobre split panel responsivo e não redimensionável. Resize por mouse/touch deve ser `[API proposta]` ou integração externa.

## Estratégia de composição
- Desktop: dois `Slot` lado a lado.
- Mobile: painel secundário vira `OffCanvas` ou tela sequencial.
- `Feedback Info` quando não há seleção.
- `Button` para voltar/abrir detalhe em telas pequenas.

## Proposta de peças, contratos e responsabilidades
- `[API proposta] SplitPanel`: Primary, Secondary, Selected, IsSecondaryOpen, OnCloseSecondary.
- `[API proposta] SplitPanelState`: PrimaryFocused, SecondaryFocused, SecondaryEmpty.

## Aplicação objetiva da linguagem visual
Painéis são brancos com borda `light-300`; divisor pode ser borda simples. O painel ativo pode receber borda `primary-500/50` se a seleção precisar aparecer.

## Aplicação de estilos e tokens
Usar grid 4/8/12/16; lista 4 colunas e detalhe 8 colunas em laptop. Mobile não deve exibir dois painéis comprimidos.

## Estrutura sugerida por tecnologia

```razor
@* [API proposta] SplitPanel *@
<Container Type="LayoutTypes.Grid" Size="LayoutSizes.Default" AdditionalClasses="gap-0 min-h-full">
    <Slot Span="4" LaptopSpan="4">
        <Box AdditionalClasses="h-full bg-white border-r border-light-300 rounded-none">
            @Primary
        </Box>
    </Slot>
    <Slot Span="4" LaptopSpan="8">
        <Box AdditionalClasses="h-full bg-white rounded-none">
            @Secondary
        </Box>
    </Slot>
</Container>
```

## Blocos principais de código

```razor
@* [API proposta] fallback mobile para secundário *@
<OffCanvas Handler="detailHandler" Position="Positions.End" Title="Detalhe" UseBox="true">
    @Secondary
</OffCanvas>

@if (SelectedItem is null)
{
    <Feedback Style="Themes.Info" Title="Nenhum item selecionado" Text="Escolha um item para ver o detalhe." Block="true" />
}
```

## Estados e comportamento responsivo
- Desktop: painéis coexistem.
- Mobile: secundário abre por ação ou rota.
- Empty: detalhe mostra `Feedback Info`.
- Loading: cada painel mostra loading próprio.
- Error: erro fica no painel afetado.

## Exemplo principal de uso

```razor
@* [API proposta] *@
<SplitPanel Selected="selected">
    <Primary><CustomerList OnSelect="Select" /></Primary>
    <Secondary><CustomerDetail Customer="selected" /></Secondary>
</SplitPanel>
```

## Comparação entre cobertura atual e proposta
| Critério | Atual | Proposta |
|---|---|---|
| Dois painéis | possível | contrato claro |
| Mobile | manual | offcanvas/sequência |
| Empty | manual | previsto |
| Resize | ausente | opcional externo |

## Limitações remanescentes
- Resize e drag divisor não são nativos.
- Sincronização por rota depende do app.

## Pontos de adaptação
- Definir qual painel é primário.
- Escolher offcanvas ou navegação para mobile.
- Não usar split panel para formulário simples.
