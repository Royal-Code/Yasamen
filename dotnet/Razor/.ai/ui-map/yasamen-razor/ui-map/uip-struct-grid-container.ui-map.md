# UIP-STRUCT-GRID_CONTAINER - Grid Container

## Componentes

**Principais**:

1. Container + Slot
- `cobertura`: grade responsiva de 12 colunas via `LayoutTypes.Grid`; cada Slot ocupa N colunas (`Span`) com breakpoints independentes (`TabletSpan`, `LaptopSpan`, `DesktopSpan`); ordem dos itens é preservada; gaps controlados via `LayoutSizes`; `Slot` pode ter altura configurável via `SpacingSize`; Container propaga `ContainerContext` para filhos;
- `limitações`: grade de 12 colunas fixa (não há grade de colunagem customizada); sem grid de áreas nomeadas; `Slot` com `Span` define largura mas não posição explícita; sem grid denso (auto-placement apenas linear); gap é uniforme para toda a grade;
- `nota`: 9;
- `justificativa`: cobertura nativa e completa de grade responsiva de múltiplas colunas; `Span`/`TabletSpan`/`LaptopSpan`/`DesktopSpan` entregam controle de breakpoint exatamente como o pattern define.

**Composição**:

1. Box
- `cobertura`: envolve o Container quando a zona de grade precisa de borda ou padding externo;
- `limitações`: adiciona wrapper; não altera o comportamento do grid;
- `nota`: 7;
- `justificativa`: bom complemento para delimitar visualmente o container de grade.

**Descartados**:

1. Stack
- `motivo`: sequência vertical, não grade; inadequado para distribuição por colunas.

## Esforço de adaptação

- `requisitos mal cobertos`:
  - `grade com colunagem arbitrária`: Container é fixo em 12 colunas; para grades de 3, 4 ou 5 colunas iguais, usar `Span=4`, `Span=3`, `Span` fracionado — funciona bem dentro das 12 colunas; não há suporte a grid de 5 ou 7 colunas sem ajuste;
  - `gap variável por grupo`: gap é configurado no Container via `LayoutSizes`; não por linha.

- `tipo de adaptação`: componente principal implementa
- `o que precisa ser feito`:
  - Usar `<Container Type="LayoutTypes.Grid">` + `<Slot Span="...">` diretamente;
  - Definir `TabletSpan`/`LaptopSpan`/`DesktopSpan` conforme breakpoints do design;
  - Para grades de N colunas iguais: dividir 12 por N (ex: 3 colunas = `Span=12 TabletSpan=4`).

## Como usar

### Grade de 3 colunas responsiva (card grid)

```razor
<Container Type="LayoutTypes.Grid">
    @foreach (var item in itens)
    {
        <Slot Span="12" TabletSpan="6" LaptopSpan="4">
            <Box Border="BorderBuilder.Box" AdditionalClasses="p-4 h-full">
                <Stack>
                    <span class="text-base font-semibold text-dark-600">@item.Nome</span>
                    <Badge Style="@item.StatusTheme" Text="@item.Status" />
                </Stack>
            </Box>
        </Slot>
    }
</Container>
```

### Grade de formulário responsivo

```razor
<Container Type="LayoutTypes.Grid">
    <Slot Span="12" TabletSpan="6">
        <FieldText Label="Nome" @bind-Value="model.Nome" />
    </Slot>
    <Slot Span="12" TabletSpan="6">
        <FieldText Label="E-mail" @bind-Value="model.Email" />
    </Slot>
    <Slot Span="12" TabletSpan="6">
        <FieldText Label="Telefone" @bind-Value="model.Telefone" />
    </Slot>
    <Slot Span="12" TabletSpan="6">
        <FieldText Label="CPF" @bind-Value="model.Cpf" />
    </Slot>
</Container>
```

### Grade de dashboard (métricas + gráfico)

```razor
<Container Type="LayoutTypes.Grid" AdditionalClasses="mb-6">
    @* 4 cards de KPI em linha *@
    <Slot Span="12" TabletSpan="6" LaptopSpan="3">
        <Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
            <Stack>
                <span class="text-2xs text-dark-700 uppercase">Receita</span>
                <span class="text-2xl font-semibold text-dark-600">R$ 42.500</span>
                <Badge Style="Themes.Success" Text="+12%" />
            </Stack>
        </Box>
    </Slot>
    <Slot Span="12" TabletSpan="6" LaptopSpan="3">
        <Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
            <Stack>
                <span class="text-2xs text-dark-700 uppercase">Pedidos</span>
                <span class="text-2xl font-semibold text-dark-600">138</span>
                <Badge Style="Themes.Warning" Text="-3%" />
            </Stack>
        </Box>
    </Slot>
    @* ... mais cards *@
</Container>
```

### Grade assimétrica (sidebar de filtro + área principal)

```razor
<Container Type="LayoutTypes.Grid" AdditionalClasses="mb-6">
    <Slot Span="12" TabletSpan="4" LaptopSpan="3">
        <Box Border="BorderBuilder.Box" AdditionalClasses="p-4">
            <h3 class="text-sm font-semibold text-dark-600 mb-3">Filtros</h3>
            @* painel de filtros *@
        </Box>
    </Slot>
    <Slot Span="12" TabletSpan="8" LaptopSpan="9">
        <Box Border="BorderBuilder.Box">
            @* área de resultados *@
        </Box>
    </Slot>
</Container>
```

## Decisão de uso

- `nota geral`: 9;
- `limitações`: grade fixa em 12 colunas (sem suporte nativo a grades de colunagem arbitrária diferente de divisores de 12); gap uniforme no Container sem variação por linha; sem grid areas nomeadas; sem grid denso (auto-placement apenas linear por documento);
- `recomendação`: `usar direto`
- `justificativa geral`:
  - `Container` + `Slot` entrega grade de 12 colunas responsiva nativa com controle de breakpoint por `Span`/`TabletSpan`/`LaptopSpan`/`DesktopSpan`;
  - Cobre todos os casos de uso típicos: grade uniforme de cards, formulário responsivo, layout assimétrico de filtro+conteúdo, dashboard de métricas;
  - A única limitação real é a grade fixada em 12 colunas — grades como 5 ou 7 colunas iguais não são naturais, mas a maioria dos designs usa divisores de 12 (2, 3, 4, 6);
  - Nota 9 justificada pela cobertura nativa e pela API de breakpoints que atende a totalidade dos casos de responsividade web.
