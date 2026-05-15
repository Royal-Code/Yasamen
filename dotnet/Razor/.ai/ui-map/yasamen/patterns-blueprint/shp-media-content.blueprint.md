# SHP-MEDIA_CONTENT - Blueprint

## Identificação
- **Pattern**: SHP-MEDIA_CONTENT - Media/Content.
- **Nível final**: completo.
- **Cobertura atual**: 2.
- **Meta de cobertura proposta**: 8.
- **Evidências usadas**: `ui-map.md`, `shell.pattern.md`, samples de `AppLayout`, `Container`, `Slot`, `Box`, `TextField`, `Button`, `Badge`, `Pagination`, `DropIconButton`, `DropItem`, `Feedback`, `visual.language.md` e `styles.map.md`.

## Resumo executivo
Yasamen consegue estruturar descoberta de conteúdo com busca, filtros, cards e paginação, mas não possui shell de mídia, coleção, preview ou viewer rico. O blueprint propõe um shell de descoberta com busca proeminente, coleções, grid de cards e painel de detalhe opcional, mantendo mídia especializada como responsabilidade do app.

## Requisitos ainda não atendidos
- Navegação leve por coleções e categorias.
- Busca proeminente e filtros compactos.
- Cards de conteúdo com imagem/preview, metadados e ações.
- Continuidade entre descoberta, detalhe e consumo.
- Estados de conteúdo vazio, carregando e indisponível.

## Diagnóstico estruturado do gap
`Container`, `Slot` e `Box` fornecem grade; `TextField` permite busca; `Pagination` cobre paginação; `Badge` e `DropIconButton` cobrem status e ações. Faltam contrato de card de mídia, preview e viewer. Como player/preview especializado não é nativo, a proposta limita o blueprint ao shell e à composição de descoberta.

## Justificativa detalhada da meta
A meta 8 é plausível para shell de mídia/conteúdo, não para player. O blueprint entrega estrutura, estados, filtros e continuidade usando Yasamen; consumo especializado de vídeo, áudio ou imagem avançada continua externo.

## Estratégia de composição
- `AppLayout` com navegação superior ou lateral leve.
- `TextField` para busca com `FieldAction`.
- `ButtonGroup` e `Badge` para categorias/filtros rápidos.
- `Container` e `Slot` para grid responsivo.
- `Box` para cards de conteúdo.
- `Pagination` ou scroll controlado para coleção.
- `Feedback` para vazio/erro.

## Proposta de peças, contratos e responsabilidades
- `[API proposta] ContentShell`: orquestra busca, categorias, coleção e detalhe.
- `[API proposta] ContentCard`: imagem/preview, título, metadados, status e ações.
- `[API proposta] ContentSection`: seção de destaque ou coleção.
- `[API proposta] MediaPreview`: slot para player/thumbnail externo, marcado como integração.

## Aplicação objetiva da linguagem visual
Cards devem usar `bg-white`, `border-light-300`, `rounded-md` e texto `dark`. Badges de status usam `Themes.Info`, `Themes.Success` ou `Themes.Highlight`. A ação principal de consumo usa `Themes.Primary`; ações de overflow usam `DropIconButton`.

## Aplicação de estilos e tokens
Usar grid 4/8/12/16; cards com `p-4`, `space-y-3`; imagens com `bg-light-200` e `rounded-sm`. Evitar gradientes e hero visual pesado; Yasamen favorece clareza operacional.

## Estrutura sugerida por tecnologia

```razor
@* [API proposta] ContentShell *@
<AppLayout AdditionalMainClasses="p-8 bg-light-100">
    <TopStart><strong>Biblioteca</strong></TopStart>
    <TopEnd>
        <TextField Placeholder="Buscar conteúdo" @bind-Value="Search">
            <FooterAction>
                <FieldAction Label="Buscar" Style="Themes.Primary" OnClick="ApplySearch" />
            </FooterAction>
        </TextField>
    </TopEnd>
    <Main>
        <Stack AdditionalClasses="space-y-6">
            @Toolbar
            @ContentGrid
            @Pager
        </Stack>
    </Main>
</AppLayout>
```

## Blocos principais de código

```razor
@* [API proposta] ContentCard *@
<Box AdditionalClasses="p-4 bg-white border border-light-300 rounded-md space-y-4">
    <div class="aspect-video bg-light-200 rounded-sm overflow-hidden">
        @Preview
    </div>
    <div class="space-y-2">
        <div class="flex items-start justify-between gap-3">
            <h3 class="font-medium text-dark-900">@Title</h3>
            <DropIconButton Icon="BsIconNames.ThreeDots" MinWidth="12rem">
                <DropItem OnClick="Open">Abrir</DropItem>
                <DropItem OnClick="Save">Salvar</DropItem>
            </DropIconButton>
        </div>
        <p class="text-sm text-dark-500">@Summary</p>
        <Badge Text="@Kind" Style="Themes.Info" Size="Sizes.Small" />
    </div>
</Box>
```

## Estados e comportamento responsivo
- Desktop: filtros e coleções podem coexistir; grid usa 3 ou 4 cards por linha conforme `Slot`.
- Mobile: busca no topo, filtros em `OffCanvas` se crescerem e cards em coluna única.
- Empty: `Feedback Style="Themes.Info"` com CTA para limpar filtros.
- Loading: placeholders locais propostos ou `Feedback Style="Themes.Info"`; não há skeleton nativo.
- Erro de mídia: `Feedback Style="Themes.Danger"` dentro do card ou viewer.

## Exemplo principal de uso

```razor
@* [API proposta] *@
<ContentShell Items="items"
              Search="@search"
              OnSearch="LoadContent"
              OnOpen="OpenContent" />
```

## Comparação entre cobertura atual e proposta
| Critério | Atual | Proposta |
|---|---|---|
| Layout de coleção | possível com `Container` | contrato de shell |
| Card de mídia | manual | `ContentCard` proposto |
| Busca/filtro | parcial | toolbar dedicada |
| Viewer/player | ausente | slot externo documentado |

## Limitações remanescentes
- Player, zoom, preview real e DRM ficam fora.
- Recomendações e ranking dependem do domínio.
- Infinite scroll precisa implementação própria.

## Pontos de adaptação
- Ligar `Preview` a thumbnail real, player ou componente externo.
- Definir taxonomia de categorias.
- Ajustar política de paginação conforme API do repositório destino.
