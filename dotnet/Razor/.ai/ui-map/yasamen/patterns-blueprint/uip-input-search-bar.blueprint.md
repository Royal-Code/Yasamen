# UIP-INPUT-SEARCH_BAR - Blueprint

## Identificação
- **Pattern**: UIP-INPUT-SEARCH_BAR - Search Bar.
- **Nível final**: resumido.
- **Cobertura atual**: 5.
- **Meta de cobertura proposta**: 8.
- **Evidências usadas**: `ui-map.md`, `ui_input.pattern.md`, samples de `TextField`, `FieldText`, `FieldAction`, `Button`, `IconButton`, `visual.language.md` e `styles.map.md`.

## Gap resumido
`TextField` cobre entrada e ação, mas faltam contrato de submit, clear, loading e sugestões.

## Decisão arquitetural principal
Criar `[API proposta] SearchBar` sobre `TextField`, com `Value`, `OnSearch`, `OnClear`, `Loading`, `Suggestions`.

## Componentes reaproveitados
`TextField`, `FieldText`, `FieldAction`, `Button` e `IconButton`.

## Bloco principal de código

```razor
@* [API proposta] SearchBar *@
<TextField Placeholder="@Placeholder" @bind-Value="Value">
    <Prepend>
        <FieldText><Icon Kind="BsIconNames.Search" /></FieldText>
    </Prepend>
    <FooterAction>
        <FieldAction Label="Buscar" Style="Themes.Primary" OnClick="Search" Disabled="@Loading" />
    </FooterAction>
</TextField>
```

## Exemplo principal de uso
Use em catálogo, list-detail, data table e resultados. Para filtros estruturados, combinar com `UIP-INPUT-FILTER_PANEL`.

## Justificativa breve da cobertura proposta
O blueprint fixa o contrato que falta sem inventar busca pronta no `AppMenu`, que foi identificado como placeholder.

## Limitações remanescentes
- Sugestões/autocomplete não são nativos.
- Debounce depende do app.

## Pontos de adaptação
- Definir se busca ocorre por enter, botão ou debounce.
- Exibir botão limpar quando houver valor.
