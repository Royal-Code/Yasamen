# UIP-DATA-DATA_TABLE - Blueprint

## Identificação
- **Pattern**: UIP-DATA-DATA_TABLE - Data Table.
- **Nível final**: completo.
- **Cobertura atual**: 1.
- **Meta de cobertura proposta**: 8.
- **Evidências usadas**: `ui-map.md`, `ui_data.pattern.md`, samples de `Box`, `ButtonGroup`, `IconButton`, `DropIconButton`, `DropItem`, `Badge`, `Pagination`, `Feedback`, `visual.language.md` e `styles.map.md`.

## Resumo executivo
Yasamen não possui tabela de dados. O blueprint propõe uma tabela HTML semântica estilizada com classes Yasamen, reaproveitando `Pagination`, `DropIconButton`, `Badge`, `ButtonGroup` e `Feedback`.

## Requisitos ainda não atendidos
- Definição de colunas.
- Sorting por coluna.
- Seleção simples/múltipla.
- Ações por linha.
- Loading/empty/error.
- Responsividade compacta.

## Diagnóstico estruturado do gap
A biblioteca cobre controles periféricos, mas o core tabular é ausente. A proposta precisa usar `<table>` HTML com classes confirmadas e componentes Yasamen nas células.

## Justificativa detalhada da meta
Com `DataTable` proposta, a cobertura chega a 8 para tabela operacional comum. Não cobre virtualização, edição massiva ou grid avançado.

## Estratégia de composição
- HTML `<table>` para semântica.
- `Box` como contêiner.
- `ButtonGroup` para toolbar.
- `Badge` para status.
- `DropIconButton` para ações por linha.
- `Pagination` no rodapé.
- `Feedback` para estados.

## Proposta de peças, contratos e responsabilidades
- `[API proposta] DataTable<TItem>`: Items, Columns, Sort, SelectedItems, RowActions.
- `[API proposta] DataColumn<TItem>`: Header, CellTemplate, SortKey, HideOnMobile.
- `[API proposta] RowAction`: Label, Theme, OnClick.

## Aplicação objetiva da linguagem visual
Tabela deve usar fundo branco, linhas com borda `light-300`, cabeçalho `light-100`, texto `dark`, ação destrutiva em `Danger`. Não usar zebra colorida forte.

## Aplicação de estilos e tokens
Usar `text-sm`, `p-3`, `border-light-300`, `overflow-x-auto`. Em mobile, ocultar colunas secundárias e manter título/status/ações.

## Estrutura sugerida por tecnologia

```razor
@* [API proposta] DataTable *@
<Box AdditionalClasses="bg-white border border-light-300 rounded-md overflow-hidden">
    <div class="p-4 border-b border-light-300">
        @Toolbar
    </div>
    <div class="overflow-x-auto">
        <table class="w-full text-sm text-dark-800">
            <thead class="bg-light-100 text-dark-600">
                @Header
            </thead>
            <tbody>
                @Rows
            </tbody>
        </table>
    </div>
    <div class="p-4 border-t border-light-300">
        <Pagination CurrentPage="@Page" TotalPages="@TotalPages" Loading="@Loading" OnPageChanged="ChangePage" />
    </div>
</Box>
```

## Blocos principais de código

```razor
@* [API proposta] linha manual com Yasamen *@
<tr class="border-t border-light-300 hover:bg-light-100">
    <td class="p-3 font-medium text-dark-900">@customer.Name</td>
    <td class="p-3 hidden md:table-cell">@customer.Email</td>
    <td class="p-3"><Badge Text="@customer.Status" Style="Themes.Success" Size="Sizes.Small" /></td>
    <td class="p-3 text-right">
        <DropIconButton Icon="BsIconNames.ThreeDots" MinWidth="Sizes.Smaller">
            <DropItem OnClick="@(() => View(customer))">Ver</DropItem>
            <DropItem OnClick="@(() => Edit(customer))">Editar</DropItem>
        </DropIconButton>
    </td>
</tr>
```

## Estados e comportamento responsivo
- Desktop: tabela completa.
- Mobile: colunas secundárias ocultas ou detalhe expandido.
- Empty: `Feedback Info` dentro do contêiner.
- Loading: linhas skeleton propostas ou `Feedback Info`.
- Error: `Feedback Danger`.

## Exemplo principal de uso

```razor
@* [API proposta] *@
<DataTable Items="customers"
           Columns="columns"
           Page="@page"
           TotalPages="@totalPages"
           OnPageChanged="LoadPage" />
```

## Comparação entre cobertura atual e proposta
| Critério | Atual | Proposta |
|---|---|---|
| Tabela | ausente | proposta HTML |
| Paginação | forte | integrada |
| Ações | drop existe | aplicado por linha |
| Seleção/sort | ausente | contrato proposto |

## Limitações remanescentes
- Virtualização e edição massiva ficam fora.
- Acessibilidade de sorting precisa implementação.
- Colunas dinâmicas dependem do app.

## Pontos de adaptação
- Definir colunas e comportamento mobile.
- Escolher seleção múltipla só quando necessária.
- Separar ações globais de ações por linha.
