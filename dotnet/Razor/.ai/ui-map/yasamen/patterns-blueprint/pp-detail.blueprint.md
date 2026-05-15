# PP-DETAIL - Blueprint

## Identificação
- **Pattern**: PP-DETAIL.
- **Nível final**: resumido.
- **Cobertura atual**: 6.
- **Meta de cobertura proposta**: 8.
- **Evidências usadas**: `ui-map.md`, `page.pattern.md`, samples de `Breadcrumb`, `Box`, `Stack`, `Badge`, `ButtonGroup`, `Button`, `IconButton`, `Feedback`, `visual.language.md` e `styles.map.md`.

## Gap resumido
Yasamen cobre breadcrumb, blocos, badges e ações, mas falta uma composição padronizada para cabeçalho contextual, seções de detalhe, metadados e ações de entidade.

## Decisão arquitetural principal
Criar `[API proposta] DetailPageLayout` e `[API proposta] DetailBlock` como composição de aplicação, usando `Breadcrumb`, `Box`, `Stack`, `Badge` e `ButtonGroup`.

## Componentes reaproveitados
- `Breadcrumb`/`BreadcrumbItem`: hierarquia.
- `Box` e `Stack`: seções.
- `Badge`: status.
- `ButtonGroup`, `Button`, `IconButton`: ações.
- `Feedback`: loading, erro ou item indisponível.

## Peça proposta
`DetailPageLayout` expõe `Breadcrumb`, `Header`, `Actions`, `Summary`, `Sections`, `Aside` e `State`.

## Bloco principal de código

```razor
@* [API proposta] DetailPageLayout *@
<Stack AdditionalClasses="space-y-6">
    <Breadcrumb>
        <Items>
            <BreadcrumbItem Href="/clientes">Clientes</BreadcrumbItem>
            <BreadcrumbItem Active="true">@Customer.Name</BreadcrumbItem>
        </Items>
    </Breadcrumb>

    <Box AdditionalClasses="p-6 bg-white border border-light-300 rounded-md">
        <Bar>
            <Start>
                <div>
                    <h1 class="text-2xl font-medium text-dark-900">@Customer.Name</h1>
                    <Badge Text="@Customer.Status" Style="Themes.Success" Size="Sizes.Small" />
                </div>
            </Start>
            <End>
                <ButtonGroup AriaLabel="Ações do detalhe" Size="Sizes.Small">
                    <Button Label="Editar" Style="Themes.Primary" />
                    <IconButton Icon="BsIconNames.ThreeDots" Style="Themes.Secondary" />
                </ButtonGroup>
            </End>
        </Bar>
    </Box>

    @Sections
</Stack>
```

## Exemplo principal de uso
Use para entidade única, perfil, registro, pedido ou artefato. Para detalhe dentro de master-detail, usar como conteúdo do painel de detalhe.

## Justificativa breve da cobertura proposta
O layout proposto cobre cabeçalho, hierarquia, ações e seções, que são os gaps centrais. A mídia rica continua dependendo do padrão de conteúdo ou integração externa.

## Limitações remanescentes
- Sem componente oficial de `DetailBlock`.
- Loading skeleton e mídia avançada não são nativos.
- Permissões de ação dependem do app destino.

## Pontos de adaptação
- Definir blocos por domínio.
- Escolher breadcrumbs ou rota simples conforme profundidade.
- Colocar ações destrutivas em modal de confirmação.
