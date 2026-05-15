# UIP-STRUCT-LAYOUT_ZONE - Blueprint

## Identificação
- **Pattern**: UIP-STRUCT-LAYOUT_ZONE - Layout Zone.
- **Nível final**: resumido.
- **Cobertura atual**: 7.
- **Meta de cobertura proposta**: 8.
- **Evidências usadas**: `ui-map.md`, `ui_struct.pattern.md`, samples de `Box`, `Bar`, `Container`, `Slot`, `Stack`, `AppLayout`, `visual.language.md` e `styles.map.md`.

## Gap resumido
Yasamen tem ótimos blocos estruturais, mas não nomeia zonas funcionais nem define contrato de cabeçalho, conteúdo, ação e estado local. Isso deixa outra IA livre demais para misturar responsabilidades.

## Decisão arquitetural principal
Criar `[API proposta] LayoutZone` como composição leve sobre `Box`/`Bar`, com `Title`, `Actions`, `State`, `ChildContent` e classes adicionais.

## Componentes reaproveitados
`Box` delimita a zona, `Bar` separa título e ações, `Stack` organiza corpo e `Feedback` pode representar vazio/erro local.

## Bloco principal de código

```razor
@* [API proposta] LayoutZone *@
<Box AdditionalClasses="p-6 bg-white border border-light-300 rounded-md">
    <Stack AdditionalClasses="space-y-4">
        <Bar>
            <Start><h2 class="font-medium text-dark-900">@Title</h2></Start>
            <End>@Actions</End>
        </Bar>
        @if (StateContent is not null)
        {
            @StateContent
        }
        else
        {
            @ChildContent
        }
    </Stack>
</Box>
```

## Exemplo principal de uso

```razor
@* [API proposta] *@
<LayoutZone Title="Filtros">
    <Actions><Button Label="Limpar" Style="Themes.Light" Size="Sizes.Small" /></Actions>
    <TextField Label="Buscar" @bind-Value="search" />
</LayoutZone>
```

## Justificativa breve da cobertura proposta
A proposta aumenta a precisão sem substituir componentes existentes. A zona continua composicional e deve ser usada apenas quando houver responsabilidade funcional nomeável.

## Limitações remanescentes
- Estados são slots do app, não comportamento nativo.
- Não substitui `SplitPanel` quando há simultaneidade forte.

## Pontos de adaptação
- Nomear zonas por função: Header, Filter, List, Detail, Actions.
- Evitar usar `LayoutZone` apenas para padding visual.
