# UI Map - yasamen

## Premissas de uso

- Plataforma-alvo: web Blazor.
- Catálogos ativados: Shell, Page, UI Struct, UI Navigation, UI Data, UI Input, UI Action, UI Feedback e UI Content.
- Catálogos condicionais não ativados: mobile e desktop nativos.
- Os exemplos assumem que os namespaces da Yasamen estão importados no projeto consumidor e que os ícones Bootstrap foram registrados quando `BsIconNames.*` for usado.
- A linguagem visual recomendada usa superfícies `bg-white`/`bg-light-100`, bordas `border-light-*`, cores por `Themes`, densidade por `Sizes`, grid por `Container`/`Slot` e movimento curto.

## Shell

### SHP-WORKSPACE_ADMIN - Workspace/Admin

**Componentes**: `AppLayout` compõe topbar, conteúdo, footer, sidebars, outlets de modal/offcanvas/notificação; `AppMainLayout` entrega um layout pronto; `AppSideMenuButton`, `AppSideBar`, `AppSideItem`, `AppMenu` e `OffCanvas` sustentam navegação global; `IconButton` e `Button` entram como ações de shell.

**Nota**: 8

**Justificativa**: A cobertura é alta porque a biblioteca possui um shell operacional real, com topbar fixa, menu lateral, conteúdo principal, footer e integração de overlays globais. A nota não é 9 ou 10 porque o `AppMenu` ainda tem placeholder textual de busca e porque o menu depende de serviço/modelo próprio, não de uma API declarativa simples no markup da tela.

**Tipo de cobertura**: Nativo com composição.

**Esforço de adaptação**: Configurar menu, serviços e conteúdo dos slots; implementar busca real caso a tela precise pesquisar destinos no menu.

**Como usar**:

```razor
<AppLayout AdditionalMainClasses="p-8 bg-light-100">
    <TopStart>
        <strong>Operação</strong>
    </TopStart>
    <TopEnd>
        <Button Label="Novo pedido" Style="Themes.Primary" Size="Sizes.Small" />
    </TopEnd>
    <LeftMenu>
        <AppSideMenuButton />
    </LeftMenu>
    <Main>
        <Box AdditionalClasses="p-6 bg-white border border-light-300 rounded-md">
            <h1 class="text-xl font-medium mb-4">Pedidos</h1>
            @Body
        </Box>
    </Main>
    <Footer>
        <span class="text-sm text-dark-400">Yasamen admin</span>
    </Footer>
</AppLayout>
```

**Limitações**: Não tratar o placeholder de busca do `AppMenu` como feature pronta.

### SHP-PORTAL - Portal

**Componentes**: `AppLayout` pode montar header/topbar, conteúdo e footer; `Button`, `IconButton`, `Box`, `Container`, `Slot`, `Breadcrumb` e `Feedback` ajudam seções informativas.

**Nota**: 5

**Justificativa**: O portal é atingível por composição, mas a biblioteca não demonstra componentes dedicados de header público, hero, nav horizontal rica, rodapé institucional ou blocos editoriais. A linguagem visual é operacional e contida, então o resultado tende a um portal simples, não uma experiência editorial forte.

**Tipo de cobertura**: Composição parcial.

**Esforço de adaptação**: Criar nav pública e seções editoriais com HTML/Tailwind, preservando tokens claros e botões semânticos.

**Como usar**:

```razor
<AppLayout LeftMenuSize="SpacingSize.None" AdditionalMainClasses="bg-white">
    <TopStart>
        <span class="font-medium text-dark-900">Yasamen Portal</span>
    </TopStart>
    <TopEnd>
        <Button Label="Entrar" Style="Themes.Primary" Size="Sizes.Small" />
    </TopEnd>
    <Main>
        <section class="mx-auto max-w-5xl px-6 py-10 space-y-6">
            <h1 class="text-3xl font-medium text-dark-900">Componentes Blazor para aplicações claras</h1>
            <p class="text-dark-600">Construa telas operacionais com temas, feedback, navegação e overlays.</p>
            <Button Label="Ver documentação" Style="Themes.Primary" />
        </section>
    </Main>
    <Footer>
        <div class="px-6 py-4 text-sm text-dark-500">© Yasamen</div>
    </Footer>
</AppLayout>
```

**Limitações**: Não há componente de hero, media block ou footer institucional.

### SHP-COMMUNICATION - Communication

**Componentes**: `AppLayout`, `Container`, `Slot`, `Stack`, `Box`, `Button`, `TextField`, `Badge` e `Feedback` podem estruturar inbox e thread manualmente.

**Nota**: 2

**Justificativa**: A biblioteca não possui inbox, thread, mensagem, compositor, presença ou atualização em tempo real. Há apenas layout e ações genéricas para desenhar a estrutura. A nota é vestigial porque a maior parte do comportamento conversacional precisa ser implementada fora da biblioteca.

**Tipo de cobertura**: Vestigial por primitivos.

**Esforço de adaptação**: Construir componentes de thread, mensagens, estado de leitura, composer, anexos, scroll local e atualização.

**Como usar**:

```razor
<Container AdditionalClasses="h-full">
    <Slot Span="4" LaptopSpan="4">
        <Stack AdditionalClasses="gap-2">
            <TextField Label="Buscar conversa" @bind-Value="search" Placeholder="Nome ou assunto" />
            @foreach (var thread in threads)
            {
                <Box AdditionalClasses="p-4 bg-white border border-light-300 rounded-md">
                    <div class="font-medium">@thread.Title</div>
                    <div class="text-sm text-dark-500">@thread.LastMessage</div>
                </Box>
            }
        </Stack>
    </Slot>
    <Slot Span="4" LaptopSpan="8">
        <Box AdditionalClasses="p-6 bg-white border border-light-300 rounded-md h-full">
            <h2 class="text-lg font-medium mb-4">Thread ativa</h2>
            <div class="space-y-3 overflow-y-auto max-h-96">...</div>
            <TextField Label="Responder" @bind-Value="reply" Placeholder="Digite a resposta" />
        </Box>
    </Slot>
</Container>

@code {
    private string search = string.Empty;
    private string reply = string.Empty;
    private readonly (string Title, string LastMessage)[] threads = [("Suporte", "Aguardando retorno")];
}
```

**Limitações**: Não cobre semântica, estados nem acessibilidade específica de conversa.

### SHP-MEDIA_CONTENT - Media/Content

**Componentes**: `AppLayout`, `Container`, `Slot`, `Box`, `Button`, `Badge`, `Pagination` e `TextField` podem montar descoberta simples.

**Nota**: 2

**Justificativa**: A biblioteca não tem viewer de mídia, card editorial, galeria, busca com sugestões ou componentes de catálogo visual. O grid e os botões ajudam a montar a casca, mas a experiência de conteúdo precisa ser desenhada manualmente.

**Tipo de cobertura**: Vestigial por layout e controles.

**Esforço de adaptação**: Criar cards de conteúdo, viewer, miniaturas, metadados e busca real.

**Como usar**:

```razor
<Box AdditionalClasses="p-6 bg-white border border-light-300 rounded-md">
    <TextField Label="Buscar conteúdo" @bind-Value="query" Placeholder="Título, tag ou autor" />
    <Container AdditionalClasses="mt-6">
        @foreach (var item in items)
        {
            <Slot Span="4" LaptopSpan="4">
                <Box AdditionalClasses="p-4 bg-white border border-light-300 rounded-md space-y-3">
                    <div class="aspect-video bg-light-200 rounded-md"></div>
                    <Badge Text="@item.Kind" Style="Themes.Info" Size="Sizes.Small" />
                    <h3 class="font-medium">@item.Title</h3>
                    <Button Label="Abrir" Style="Themes.Primary" Size="Sizes.Small" />
                </Box>
            </Slot>
        }
    </Container>
</Box>

@code {
    private string query = string.Empty;
    private readonly (string Title, string Kind)[] items = [("Guia de uso", "Artigo")];
}
```

**Limitações**: Mídia real, favoritos, recomendações e filtros facetados não existem como componentes.

### SHP-DASHBOARD_ANALYTICS - Dashboard/Analytics

**Componentes**: `AppLayout`, `Container`, `Slot`, `Box`, `Badge`, `Feedback`, `ButtonGroup` e `TextField` sustentam estrutura; não há chart ou KPI dedicado.

**Nota**: 3

**Justificativa**: O shell de app e o grid são bons para organizar blocos analíticos, mas a biblioteca não oferece metric card, gráficos, tabelas analíticas, filtros temporais ricos ou drill-down. A cobertura é baixa porque só a estrutura e alguns badges/feedbacks são fornecidos.

**Tipo de cobertura**: Baixa por composição.

**Esforço de adaptação**: Implementar cards de métrica, charts, filtros temporais e estados analíticos, usando Yasamen para shell e ações.

**Como usar**:

```razor
<AppLayout AdditionalMainClasses="p-8 bg-light-100">
    <TopStart><strong>Indicadores</strong></TopStart>
    <TopEnd>
        <ButtonGroup Size="Sizes.Small" AriaLabel="Período">
            <Button Label="Hoje" Active="true" />
            <Button Label="Semana" />
            <Button Label="Mês" />
        </ButtonGroup>
    </TopEnd>
    <Main>
        <Container>
            <Slot Span="4">
                <Box AdditionalClasses="p-5 bg-white border border-light-300 rounded-md">
                    <span class="text-sm text-dark-500">Receita</span>
                    <div class="text-2xl font-medium">R$ 42.000</div>
                    <Badge Text="+8%" Style="Themes.Success" Size="Sizes.Small" />
                </Box>
            </Slot>
        </Container>
    </Main>
</AppLayout>
```

**Limitações**: Visualização analítica depende de componentes externos ou blueprints.

### SHP-STUDIO_WORKBENCH - Studio/Workbench

**Componentes**: `AppLayout`, `AppSideBar`, `Bar`, `ButtonGroup`, `IconButton`, `OffCanvas`, `Container` e `Slot` montam painéis e toolbars.

**Nota**: 3

**Justificativa**: A biblioteca consegue criar a armação de workbench, com toolbar e painéis laterais, mas não possui canvas, inspector, layers, drag, seleção de objetos ou controles especializados. A nota é baixa porque o núcleo da experiência precisa ser construído manualmente.

**Tipo de cobertura**: Baixa por composição.

**Esforço de adaptação**: Criar canvas/editor, modelo de seleção, inspector, toolbar de ferramentas e persistência.

**Como usar**:

```razor
<AppLayout AdditionalMainClasses="p-4 bg-light-100">
    <TopStart>
        <ButtonGroup Size="Sizes.Small" AriaLabel="Ferramentas">
            <IconButton Icon="BsIconNames.Cursor" Active="true" />
            <IconButton Icon="BsIconNames.BoundingBox" />
            <IconButton Icon="BsIconNames.Type" />
        </ButtonGroup>
    </TopStart>
    <RightMenu>
        <Box AdditionalClasses="p-4 bg-white border-l border-light-300 h-full">
            <h2 class="font-medium mb-3">Propriedades</h2>
            <TextField Label="Nome" @bind-Value="selectedName" />
        </Box>
    </RightMenu>
    <Main>
        <div class="h-full rounded-md border border-light-300 bg-white"></div>
    </Main>
</AppLayout>

@code {
    private string selectedName = "Objeto 1";
}
```

**Limitações**: A superfície de edição é totalmente customizada.

### SHP-TRANSACTIONAL_COMMERCE - Transactional/Commerce

**Componentes**: `Button`, `ButtonGroup`, `TextField`, `Feedback`, `Modal`, `Pagination`, `Container`, `Slot` e `Badge` cobrem partes de compra/cadastro/checkout.

**Nota**: 3

**Justificativa**: Há bons componentes de formulário, ações e confirmação, mas não há catálogo transacional, carrinho, checkout, produto, preço, pagamento ou stepper. A cobertura é baixa e funciona melhor para telas administrativas de pedido do que para comércio completo.

**Tipo de cobertura**: Baixa por composição.

**Esforço de adaptação**: Criar componentes de produto/carrinho/checkout e regras transacionais; usar Yasamen para formulários e ações.

**Como usar**:

```razor
<Box AdditionalClasses="p-6 bg-white border border-light-300 rounded-md space-y-6">
    <Container>
        <Slot Span="4" LaptopSpan="8">
            <h1 class="text-xl font-medium">Checkout</h1>
            <EditForm Model="this">
                <TextField Label="Nome" @bind-Value="name" />
                <TextField Label="E-mail" @bind-Value="email" />
            </EditForm>
        </Slot>
        <Slot Span="4" LaptopSpan="4">
            <Box AdditionalClasses="p-4 border border-light-300 rounded-md">
                <Badge Text="Total" Style="Themes.Info" />
                <div class="text-2xl font-medium mt-2">R$ 199,00</div>
                <Button Label="Confirmar pedido" Style="Themes.Primary" Block="true" AdditionalClasses="mt-4" />
            </Box>
        </Slot>
    </Container>
</Box>

@code {
    private string name = string.Empty;
    private string email = string.Empty;
}
```

**Limitações**: Não cobre pagamento, carrinho nem fluxo multi-etapa.

### SHP-KIOSK_EMBEDDED - Kiosk/Embedded

**Componentes**: `Button`, `IconButton`, `Feedback`, `Container`, `Slot`, `Box` e `Modal` podem montar fluxos de foco único.

**Nota**: 2

**Justificativa**: A biblioteca não tem componentes próprios para toque ampliado, fullscreen, sessão efêmera ou hardware. Botões em tamanhos grandes e feedbacks ajudam, mas o padrão exige muita customização de layout e interação.

**Tipo de cobertura**: Vestigial por primitivos.

**Esforço de adaptação**: Definir dimensões touch, timeout, fluxo restrito, acessibilidade e integração de dispositivo.

**Como usar**:

```razor
<main class="min-h-screen bg-light-100 p-8 flex items-center justify-center">
    <Box AdditionalClasses="max-w-3xl w-full p-8 bg-white border border-light-300 rounded-md text-center space-y-8">
        <h1 class="text-3xl font-medium">Autoatendimento</h1>
        <Feedback Style="Themes.Info" Text="Escolha uma opção para iniciar." />
        <ButtonGroup Orientation="ButtonGroupOrientation.Vertical" Size="Sizes.Largest" AriaLabel="Ações principais">
            <Button Label="Iniciar atendimento" Style="Themes.Primary" Block="true" />
            <Button Label="Consultar senha" Style="Themes.Secondary" Block="true" />
        </ButtonGroup>
    </Box>
</main>
```

**Limitações**: A biblioteca não impõe regras kiosk de foco, sessão ou toque.

## Page

### PP-LIST-DETAIL

**Componentes**: `Container`, `Slot`, `Box`, `Stack`, `ButtonGroup`, `Button`, `IconButton`, `Badge`, `Pagination` e `Feedback`.

**Nota**: 6

**Justificativa**: A estrutura master-detail é viável com grid, slots, lista manual e painel de detalhe. A nota é parcial porque não há `List`, `DataTable`, seleção, painel dividido ou estado de detalhe vazio como componentes semânticos.

**Tipo de cobertura**: Composição parcial.

**Esforço de adaptação**: Criar lista/seleção, sincronizar estado selecionado, tratar vazio/loading/erro e adaptar mobile para navegação sequencial.

**Como usar**:

```razor
<Container>
    <Slot Span="4" LaptopSpan="4">
        <Stack AdditionalClasses="gap-3">
            @foreach (var order in orders)
            {
                <Box AdditionalClasses="p-4 bg-white border border-light-300 rounded-md">
                    <div class="flex items-center justify-between">
                        <button class="text-left font-medium" @onclick="() => selected = order">@order.Number</button>
                        <Badge Text="@order.Status" Style="Themes.Info" Size="Sizes.Small" />
                    </div>
                </Box>
            }
            <Pagination CurrentPage="1" TotalPages="8" OnPageChanged="@(_ => Task.CompletedTask)" />
        </Stack>
    </Slot>
    <Slot Span="4" LaptopSpan="8">
        <Box AdditionalClasses="p-6 bg-white border border-light-300 rounded-md">
            @if (selected is null)
            {
                <Feedback Style="Themes.Info" Text="Selecione um pedido para ver o detalhe." />
            }
            else
            {
                <h2 class="text-lg font-medium">@selected.Number</h2>
                <ButtonGroup Size="Sizes.Small" AriaLabel="Ações do pedido">
                    <Button Label="Editar" Style="Themes.Primary" />
                    <Button Label="Cancelar" Style="Themes.Light" />
                </ButtonGroup>
            }
        </Box>
    </Slot>
</Container>

@code {
    private Order? selected;
    private readonly Order[] orders = [new("PED-001", "Novo")];
    private sealed record Order(string Number, string Status);
}
```

**Limitações**: Não há seleção em lote, ordenação, tabela ou split responsivo pronto.

### PP-CATALOG

**Componentes**: `TextField`, `OffCanvas`, `Button`, `ButtonGroup`, `Container`, `Slot`, `Box`, `Badge`, `DropIconButton`, `DropItem` e `Pagination`.

**Nota**: 4

**Justificativa**: Busca textual, painel de filtros e grid de cards são possíveis por composição. A cobertura é baixa porque não há card semântico, filtro facetado, select/checkbox Yasamen, sugestões ou componente de resultado.

**Tipo de cobertura**: Baixa por composição.

**Esforço de adaptação**: Implementar card de catálogo, filtros estruturados e lógica de busca; usar offcanvas para filtros mobile.

**Como usar**:

```razor
<Box AdditionalClasses="p-6 bg-white border border-light-300 rounded-md space-y-6">
    <Bar>
        <Start>
            <TextField Label="Buscar" @bind-Value="query" Placeholder="Produto ou código" />
        </Start>
        <End>
            <Button Label="Filtros" Style="Themes.Secondary" OnClick="@(async _ => await filters.OpenAsync())" />
        </End>
    </Bar>
    <Container>
        @foreach (var product in products)
        {
            <Slot Span="4" LaptopSpan="4">
                <Box AdditionalClasses="p-4 bg-white border border-light-300 rounded-md space-y-3">
                    <Badge Text="@product.Tag" Style="Themes.Highlight" Size="Sizes.Small" />
                    <h3 class="font-medium">@product.Name</h3>
                    <Button Label="Ver detalhes" Style="Themes.Primary" Size="Sizes.Small" />
                </Box>
            </Slot>
        }
    </Container>
    <Pagination CurrentPage="1" TotalPages="12" OnPageChanged="@(_ => Task.CompletedTask)" />
</Box>

<OffCanvas Handler="filters" Position="Positions.End" Title="Filtros">
    <Stack AdditionalClasses="gap-4 p-4">
        <TextField Label="Categoria" @bind-Value="category" />
        <Button Label="Aplicar filtros" Style="Themes.Primary" />
    </Stack>
</OffCanvas>

@code {
    private readonly OffCanvasHandler filters = new();
    private string query = string.Empty;
    private string category = string.Empty;
    private readonly (string Name, string Tag)[] products = [("Plano Básico", "Novo")];
}
```

**Limitações**: Cards e filtros ainda são estrutura manual.

### PP-FORM

**Componentes**: `TextField`, `Container`, `Slot`, `FieldText`, `FieldBadge`, `FieldAction`, `ButtonGroup`, `Button`, `Feedback`, `Notification` e `Modal`.

**Nota**: 7

**Justificativa**: Formulários de texto têm boa cobertura, com label, informação, erro, slots, tamanhos e integração com `EditForm`. A nota não é maior porque só há `TextField` com tipos `Text` e `Password`; controles como select, checkbox, radio, date e textarea não aparecem como componentes Yasamen.

**Tipo de cobertura**: Alta para texto; parcial para formulário amplo.

**Esforço de adaptação**: Complementar controles ausentes ou usar HTML/Blazor padrão para tipos não cobertos.

**Como usar**:

```razor
<EditForm Model="model" OnValidSubmit="SaveAsync">
    <Box AdditionalClasses="p-6 bg-white border border-light-300 rounded-md space-y-6">
        <Container>
            <Slot Span="4" LaptopSpan="6">
                <TextField Label="Nome" @bind-Value="model.Name" Information="Nome exibido no cadastro." />
            </Slot>
            <Slot Span="4" LaptopSpan="6">
                <TextField Label="E-mail" @bind-Value="model.Email" Error="@emailError" />
            </Slot>
        </Container>
        <ButtonGroup AriaLabel="Ações do formulário">
            <Button Label="Salvar" Type="ButtonTypes.Submit" Style="Themes.Primary" />
            <Button Label="Cancelar" Style="Themes.Light" />
        </ButtonGroup>
    </Box>
</EditForm>

@code {
    private FormModel model = new();
    private string? emailError;
    private Task SaveAsync() => Task.CompletedTask;
    private sealed class FormModel { public string Name { get; set; } = string.Empty; public string Email { get; set; } = string.Empty; }
}
```

**Limitações**: Formulários ricos exigem componentes adicionais.

### PP-WIZARD

**Componentes**: `Box`, `Badge`, `ButtonGroup`, `Button`, `TextField`, `Feedback` e `Container`.

**Nota**: 4

**Justificativa**: O corpo de etapa e as ações de progressão são fáceis de compor, mas não existe stepper indicator nativo, validação por fase ou componente de wizard. A nota é baixa porque a progressão e o estado precisam ser implementados manualmente.

**Tipo de cobertura**: Baixa por composição.

**Esforço de adaptação**: Criar stepper, regras de avanço, validação por etapa, persistência parcial e resumo final.

**Como usar**:

```razor
<Box AdditionalClasses="p-6 bg-white border border-light-300 rounded-md space-y-6">
    <div class="flex gap-2">
        <Badge Text="1 Dados" Style="@(step == 1 ? Themes.Primary : Themes.Light)" />
        <Badge Text="2 Revisão" Style="@(step == 2 ? Themes.Primary : Themes.Light)" />
        <Badge Text="3 Confirmação" Style="@(step == 3 ? Themes.Primary : Themes.Light)" />
    </div>

    @if (step == 1)
    {
        <TextField Label="Nome" @bind-Value="name" />
    }
    else
    {
        <Feedback Style="Themes.Info" Text="Revise as informações antes de continuar." />
    }

    <ButtonGroup AriaLabel="Navegação do fluxo">
        <Button Label="Voltar" Style="Themes.Light" Disabled="@(step == 1)" OnClick="@(_ => step--)" />
        <Button Label="Avançar" Style="Themes.Primary" OnClick="@(_ => step++)" />
    </ButtonGroup>
</Box>

@code {
    private int step = 1;
    private string name = string.Empty;
}
```

**Limitações**: Stepper visual e comportamento de fluxo são customizados.

### PP-DASHBOARD

**Componentes**: `Container`, `Slot`, `Box`, `Badge`, `ButtonGroup`, `Feedback` e `Pagination`.

**Nota**: 3

**Justificativa**: A estrutura de grid existe, mas métrica, chart, tabela e filtros analíticos precisam ser manuais. A biblioteca ajuda a organizar e estilizar, não a representar dados analíticos.

**Tipo de cobertura**: Baixa por composição.

**Esforço de adaptação**: Criar metric cards, gráficos, filtros e drill-downs.

**Como usar**:

```razor
<Container>
    <Slot Span="4">
        <Box AdditionalClasses="p-5 bg-white border border-light-300 rounded-md">
            <div class="text-sm text-dark-500">Chamados abertos</div>
            <div class="text-3xl font-medium text-dark-900">128</div>
            <Badge Text="+12 hoje" Style="Themes.Warning" Size="Sizes.Small" />
        </Box>
    </Slot>
    <Slot Span="4" LaptopSpan="8">
        <Box AdditionalClasses="p-5 bg-white border border-light-300 rounded-md">
            <Feedback Style="Themes.Info" Text="Área de gráfico a implementar com componente externo." />
        </Box>
    </Slot>
</Container>
```

**Limitações**: Sem chart, data visualization e KPI component.

### PP-DETAIL

**Componentes**: `Breadcrumb`, `BreadcrumbItem`, `Box`, `Stack`, `Badge`, `ButtonGroup`, `Button`, `IconButton` e `Feedback`.

**Nota**: 6

**Justificativa**: Páginas de detalhe são bem montáveis com breadcrumb, bloco branco, badges e ações. A nota é parcial porque não há `DetailBlock` semântico, definição de campos/valores ou layout de metadados pronto.

**Tipo de cobertura**: Composição parcial.

**Esforço de adaptação**: Criar componente de atributo/valor ou padronizar seções de detalhe.

**Como usar**:

```razor
<Stack AdditionalClasses="gap-4">
    <Breadcrumb>
        <Items>
            <BreadcrumbItem Href="/clientes">Clientes</BreadcrumbItem>
            <BreadcrumbItem Active="true">Cliente 001</BreadcrumbItem>
        </Items>
    </Breadcrumb>

    <Box AdditionalClasses="p-6 bg-white border border-light-300 rounded-md space-y-4">
        <div class="flex items-center justify-between">
            <h1 class="text-xl font-medium">Cliente 001</h1>
            <Badge Text="Ativo" Style="Themes.Success" />
        </div>
        <dl class="grid gap-4 md:grid-cols-2">
            <div><dt class="text-sm text-dark-500">Nome</dt><dd class="font-medium">Royal Code</dd></div>
            <div><dt class="text-sm text-dark-500">Plano</dt><dd class="font-medium">Enterprise</dd></div>
        </dl>
        <ButtonGroup AriaLabel="Ações do cliente">
            <Button Label="Editar" Style="Themes.Primary" />
            <Button Label="Desativar" Style="Themes.Danger" Outline="true" />
        </ButtonGroup>
    </Box>
</Stack>
```

**Limitações**: Estrutura de detalhe não é componente próprio.

### PP-LANDING

**Componentes**: `Box`, `Container`, `Slot`, `Button`, `Badge` e `Feedback`.

**Nota**: 2

**Justificativa**: É possível compor uma página linear simples, mas a biblioteca não possui hero, media, seções de marketing, prova social ou linguagem editorial. A identidade observada é mais administrativa que promocional.

**Tipo de cobertura**: Vestigial por primitivos.

**Esforço de adaptação**: Criar design editorial, assets e seções específicas sem perder a paleta e os controles Yasamen.

**Como usar**:

```razor
<main class="bg-white">
    <section class="mx-auto max-w-5xl px-6 py-12 space-y-6">
        <Badge Text="Blazor UI" Style="Themes.Highlight" />
        <h1 class="text-4xl font-medium text-dark-900">Yasamen</h1>
        <p class="max-w-2xl text-dark-600">Componentes para telas operacionais, formulários, feedback e navegação.</p>
        <Button Label="Começar" Style="Themes.Primary" />
    </section>
</main>
```

**Limitações**: Não usar como landing rica sem blueprint visual próprio.

### PP-CONVERSATION

**Componentes**: `Stack`, `Box`, `TextField`, `Button`, `Badge` e `Feedback`.

**Nota**: 1

**Justificativa**: Não há componentes de conversa. A biblioteca só oferece controles genéricos para desenhar uma thread manual. A nota é 1 porque até mensagens, compositor e scroll precisam ser definidos fora.

**Tipo de cobertura**: Vestigial.

**Esforço de adaptação**: Implementar mensagem, composer, agrupamento temporal, estados de leitura, anexos e acessibilidade.

**Como usar**:

```razor
<Box AdditionalClasses="p-4 bg-white border border-light-300 rounded-md">
    <Stack AdditionalClasses="gap-3 max-h-96 overflow-y-auto">
        <div class="rounded-md border border-light-300 p-3">
            <Badge Text="Novo" Style="Themes.Info" Size="Sizes.Small" />
            <p class="mt-2">Mensagem recebida.</p>
        </div>
    </Stack>
    <div class="mt-4 flex gap-3">
        <TextField Label="Mensagem" @bind-Value="message" Placeholder="Digite..." />
        <Button Label="Enviar" Style="Themes.Primary" />
    </div>
</Box>

@code {
    private string message = string.Empty;
}
```

**Limitações**: Exemplo apenas estrutura; não implementa pattern conversacional completo.

### PP-FEED

**Componentes**: `Stack`, `Box`, `Badge`, `DropIconButton`, `DropItem`, `Button` e `Feedback`.

**Nota**: 2

**Justificativa**: A biblioteca permite montar uma lista cronológica, mas não tem feed, timeline item, atualização incremental ou composer. A cobertura é vestigial por layout e ações.

**Tipo de cobertura**: Vestigial por composição.

**Esforço de adaptação**: Criar item cronológico, carregamento incremental, marcador de novo e menu por item.

**Como usar**:

```razor
<Stack AdditionalClasses="gap-4">
    @foreach (var item in feed)
    {
        <Box AdditionalClasses="p-4 bg-white border border-light-300 rounded-md">
            <div class="flex justify-between">
                <Badge Text="@item.When" Style="Themes.Light" Size="Sizes.Small" />
                <DropIconButton Icon="BsIconNames.ThreeDots" MinWidth="Sizes.Smaller">
                    <DropItem>Ocultar</DropItem>
                    <DropItem>Copiar link</DropItem>
                </DropIconButton>
            </div>
            <p class="mt-3">@item.Text</p>
        </Box>
    }
</Stack>

@code {
    private readonly (string When, string Text)[] feed = [("Agora", "Item publicado")];
}
```

**Limitações**: Sem componente de timeline/feed nem scroll progressivo pronto.

### PP-SETTINGS

**Componentes**: `Stack`, `Box`, `TextField`, `ButtonGroup`, `Button`, `Breadcrumb`, `Feedback` e `Badge`.

**Nota**: 5

**Justificativa**: Configurações textuais e seções empilhadas são viáveis, mas faltam tabs, toggle, checkbox, select e componentes de preferência. A biblioteca cobre melhor a parte de formulário textual e ações do que a navegação local de settings.

**Tipo de cobertura**: Parcial por composição.

**Esforço de adaptação**: Criar tabs ou navegação local, controles de preferência e estados de salvamento.

**Como usar**:

```razor
<Stack AdditionalClasses="gap-4">
    <Breadcrumb>
        <Items>
            <BreadcrumbItem Href="/admin">Admin</BreadcrumbItem>
            <BreadcrumbItem Active="true">Configurações</BreadcrumbItem>
        </Items>
    </Breadcrumb>
    <Box AdditionalClasses="p-6 bg-white border border-light-300 rounded-md space-y-4">
        <h1 class="text-xl font-medium">Configurações gerais</h1>
        <TextField Label="Nome da empresa" @bind-Value="companyName" />
        <TextField Label="E-mail de suporte" @bind-Value="supportEmail" />
        <ButtonGroup AriaLabel="Ações de configuração">
            <Button Label="Salvar" Style="Themes.Primary" />
            <Button Label="Restaurar" Style="Themes.Light" />
        </ButtonGroup>
    </Box>
</Stack>

@code {
    private string companyName = string.Empty;
    private string supportEmail = string.Empty;
}
```

**Limitações**: Não há controle booleano Yasamen dedicado nem tabs nativas.

### PP-BOARD

**Componentes**: `Container`, `Slot`, `Box`, `Stack`, `Badge`, `DropIconButton`, `DropItem` e `Button`.

**Nota**: 1

**Justificativa**: Colunas de board podem ser desenhadas manualmente com layout, mas não há Kanban column, drag-and-drop, limites de coluna, item movível ou navegação por lanes. A nota é vestigial.

**Tipo de cobertura**: Vestigial.

**Esforço de adaptação**: Implementar drag, modelo de coluna, cards, estados vazios e alternativa mobile.

**Como usar**:

```razor
<Container AdditionalClasses="overflow-x-auto">
    @foreach (var column in columns)
    {
        <Slot Span="4">
            <Box AdditionalClasses="p-4 bg-light-100 border border-light-300 rounded-md">
                <div class="flex justify-between mb-3">
                    <h2 class="font-medium">@column.Name</h2>
                    <Badge Text="@column.Count.ToString()" Style="Themes.Secondary" Size="Sizes.Small" />
                </div>
                <Stack AdditionalClasses="gap-3">
                    <Box AdditionalClasses="p-3 bg-white border border-light-300 rounded-md">Item manual</Box>
                </Stack>
            </Box>
        </Slot>
    }
</Container>

@code {
    private readonly (string Name, int Count)[] columns = [("Novo", 1), ("Em andamento", 0)];
}
```

**Limitações**: Não implementa movimento entre colunas.

### PP-CALENDAR

**Componentes**: `Box`, `ButtonGroup`, `Button`, `Badge`, `Feedback` e `TextField` apenas para contorno.

**Nota**: 0

**Justificativa**: Não há calendário, date picker, agenda, grade temporal ou visualização por mês/semana/dia. Como o pattern depende do eixo temporal como estrutura principal, a biblioteca não cobre o padrão.

**Tipo de cobertura**: Ausente.

**Esforço de adaptação**: Criar ou integrar componente de calendário e usar Yasamen apenas para filtros, ações e feedback.

**Como usar**:

```razor
<Box AdditionalClasses="p-6 bg-white border border-light-300 rounded-md space-y-4">
    <Bar>
        <Start>
            <ButtonGroup Size="Sizes.Small" AriaLabel="Visão">
                <Button Label="Dia" Active="true" />
                <Button Label="Semana" />
                <Button Label="Mês" />
            </ButtonGroup>
        </Start>
        <End>
            <Button Label="Novo evento" Style="Themes.Primary" Size="Sizes.Small" />
        </End>
    </Bar>
    <Feedback Style="Themes.Warning" Text="Calendário ausente: implemente a grade temporal aqui." />
</Box>
```

**Limitações**: Exemplo mostra apenas entorno visual, não o calendário.

### PP-MAP

**Componentes**: `Box`, `TextField`, `Button`, `OffCanvas`, `Feedback` e `Badge` apenas para contorno.

**Nota**: 0

**Justificativa**: Não há mapa, camadas, marcador, geocodificação, viewport ou controle espacial. O pattern depende de superfície cartográfica, portanto a biblioteca não cobre.

**Tipo de cobertura**: Ausente.

**Esforço de adaptação**: Integrar biblioteca de mapas e usar Yasamen para filtros, painéis e ações.

**Como usar**:

```razor
<Box AdditionalClasses="relative h-[32rem] bg-white border border-light-300 rounded-md overflow-hidden">
    <div class="absolute left-4 top-4 z-modal w-80">
        <TextField Label="Buscar local" @bind-Value="place" Placeholder="Endereço ou ponto" />
    </div>
    <div class="h-full bg-light-200 grid place-items-center">
        <Feedback Style="Themes.Info" Text="Superfície de mapa deve ser implementada com biblioteca externa." />
    </div>
</Box>

@code {
    private string place = string.Empty;
}
```

**Limitações**: Sem mapa real.

### PP-CANVAS

**Componentes**: `AppLayout`, `ButtonGroup`, `IconButton`, `OffCanvas`, `Box` e `TextField` ajudam ferramenta e painéis.

**Nota**: 1

**Justificativa**: A biblioteca monta o shell de ferramenta, mas não oferece canvas, seleção, zoom, pan, layers, inspector semântico ou manipulação direta. O núcleo do pattern está ausente.

**Tipo de cobertura**: Vestigial.

**Esforço de adaptação**: Implementar canvas/editor e usar Yasamen para toolbar, inspector e dialogs.

**Como usar**:

```razor
<AppLayout AdditionalMainClasses="p-4 bg-light-100">
    <TopStart>
        <ButtonGroup Size="Sizes.Small" AriaLabel="Ferramentas do canvas">
            <IconButton Icon="BsIconNames.Cursor" Active="true" />
            <IconButton Icon="BsIconNames.ZoomIn" />
            <IconButton Icon="BsIconNames.ZoomOut" />
        </ButtonGroup>
    </TopStart>
    <Main>
        <div class="h-full min-h-[32rem] rounded-md border border-light-300 bg-white"></div>
    </Main>
</AppLayout>
```

**Limitações**: Canvas precisa de implementação própria.

## UI Struct

### UIP-STRUCT-LAYOUT_ZONE - Layout Zone

**Componentes**: `Box`, `Bar`, `Container`, `Slot`, `Stack`, `AppLayout`.

**Nota**: 7

**Justificativa**: Yasamen oferece bons containers para zonas visuais e slots de shell. A nota não é maior porque não há componente semântico de zona com estados próprios; `Box` e `Container` são estruturais, não nomeiam responsabilidade funcional.

**Tipo de cobertura**: Alta por composição.

**Esforço de adaptação**: Nomear zonas no markup, aplicar headings, estados e classes responsivas manualmente.

**Como usar**:

```razor
<Box AdditionalClasses="p-6 bg-white border border-light-300 rounded-md">
    <Bar>
        <Start><h2 class="text-lg font-medium">Filtros</h2></Start>
        <End><Button Label="Limpar" Style="Themes.Light" Size="Sizes.Small" /></End>
    </Bar>
    <div class="mt-4">
        <TextField Label="Termo" @bind-Value="term" />
    </div>
</Box>

@code {
    private string term = string.Empty;
}
```

**Limitações**: Estados de zona são responsabilidade da tela.

### UIP-STRUCT-SPLIT_PANEL - Split Panel

**Componentes**: `Container`, `Slot`, `Box`, `OffCanvas`, `Button` e `Feedback`.

**Nota**: 5

**Justificativa**: Dois painéis lado a lado são viáveis com grid e slots. A nota é parcial porque não há divisor, resize, colapso coordenado ou alternância mobile nativa.

**Tipo de cobertura**: Composição parcial.

**Esforço de adaptação**: Criar regras de largura, seleção, colapso e mobile; usar offcanvas para painel secundário em telas estreitas.

**Como usar**:

```razor
<Container>
    <Slot Span="4" LaptopSpan="4">
        <Box AdditionalClasses="p-4 bg-white border border-light-300 rounded-md">Lista</Box>
    </Slot>
    <Slot Span="4" LaptopSpan="8">
        <Box AdditionalClasses="p-4 bg-white border border-light-300 rounded-md">
            <Feedback Style="Themes.Info" Text="Detalhe do item selecionado." />
        </Box>
    </Slot>
</Container>
```

**Limitações**: Split interativo precisa ser implementado.

### UIP-STRUCT-SCROLLABLE_REGION - Scrollable Region

**Componentes**: `Box`, `Stack`, `Feedback` e classes utilitárias confirmadas.

**Nota**: 4

**Justificativa**: A região rolável é feita com HTML/CSS e containers Yasamen. Não há componente específico que controle altura, fim da lista, carregamento incremental ou acessibilidade de scroll.

**Tipo de cobertura**: Baixa por composição.

**Esforço de adaptação**: Definir altura, overflow, loading incremental e foco/teclado.

**Como usar**:

```razor
<Box AdditionalClasses="p-4 bg-white border border-light-300 rounded-md">
    <Stack AdditionalClasses="gap-3 max-h-80 overflow-y-auto">
        @foreach (var item in items)
        {
            <div class="rounded-md border border-light-300 p-3">@item</div>
        }
    </Stack>
</Box>

@code {
    private readonly string[] items = ["Item 1", "Item 2", "Item 3"];
}
```

**Limitações**: Sem comportamento próprio de infinite scroll.

### UIP-STRUCT-STACK_CONTAINER - Stack Container

**Componentes**: `Stack`, `Box`, `Feedback`.

**Nota**: 8

**Justificativa**: `Stack` cobre diretamente o empilhamento vertical simples. A nota não chega a 10 porque espaçamento e estados precisam vir de classes adicionais e composição.

**Tipo de cobertura**: Nativo simples.

**Esforço de adaptação**: Aplicar `gap-*`/`space-y-*` conforme densidade da tela e tratar estados no conteúdo.

**Como usar**:

```razor
<Stack AdditionalClasses="gap-4">
    <Feedback Style="Themes.Info" Text="Revise os dados antes de salvar." />
    <TextField Label="Nome" @bind-Value="name" />
    <Button Label="Salvar" Style="Themes.Primary" />
</Stack>

@code {
    private string name = string.Empty;
}
```

**Limitações**: Não há prop explícita de espaçamento.

### UIP-STRUCT-GRID_CONTAINER - Grid Container

**Componentes**: `Container`, `Slot`, `LayoutSizes`, `LayoutTypes`.

**Nota**: 9

**Justificativa**: A biblioteca possui grid responsivo próprio com 4/8/12/16 colunas e spans por breakpoint. A nota é alta porque esse é um componente estrutural direto; não é 10 apenas porque estados de grid e skeleton não são próprios.

**Tipo de cobertura**: Nativo.

**Esforço de adaptação**: Escolher spans por breakpoint e preencher estados de loading/empty quando necessário.

**Como usar**:

```razor
<Container Type="LayoutTypes.Grid" Size="LayoutSizes.Default">
    <Slot Span="4" TabletSpan="4" LaptopSpan="6">
        <Box AdditionalClasses="p-4 bg-white border border-light-300 rounded-md">Resumo</Box>
    </Slot>
    <Slot Span="4" TabletSpan="4" LaptopSpan="6">
        <Box AdditionalClasses="p-4 bg-white border border-light-300 rounded-md">Detalhes</Box>
    </Slot>
</Container>
```

**Limitações**: Não cobre semântica de coleção por si só.

## UI Navigation

### UIP-NAV-NAVIGATION_MENU - Navigation Menu

**Componentes**: `AppSideMenuButton`, `AppMenu`, `AppMenuList`, `AppMenuItem`, `AppSideBar`, `AppSideItem`, `OffCanvas`.

**Nota**: 8

**Justificativa**: O menu global é um dos pontos fortes: há item de sidebar, botão de menu, menu em offcanvas, breadcrumbs internos e modelo de item. A nota não é maior porque a busca do `AppMenu` é placeholder e o menu depende de serviço/modelo.

**Tipo de cobertura**: Nativo com composição.

**Esforço de adaptação**: Configurar `MenuService`, destinos e permissões; implementar busca se necessária.

**Como usar**:

```razor
<AppLayout>
    <LeftMenu>
        <AppSideMenuButton />
    </LeftMenu>
    <Main>
        @Body
    </Main>
</AppLayout>
```

**Limitações**: Busca e permissões precisam ser resolvidas no app.

### UIP-NAV-BREADCRUMB - Breadcrumb

**Componentes**: `Breadcrumb`, `BreadcrumbItem`, `DescribesBreadcrumbs`, `DropButton`, `DropItem`.

**Nota**: 9

**Justificativa**: Breadcrumb é componente direto, com item ativo, href/click e overflow por dropdown. A nota é alta porque cobre a semântica central do pattern.

**Tipo de cobertura**: Nativo.

**Esforço de adaptação**: Fornecer hierarquia real e escolher truncamento via `DescribesBreadcrumbs` quando aplicável.

**Como usar**:

```razor
<Breadcrumb>
    <MenuItems>
        <DropItem>Admin</DropItem>
    </MenuItems>
    <Items>
        <BreadcrumbItem Href="/clientes">Clientes</BreadcrumbItem>
        <BreadcrumbItem Href="/clientes/42">Cliente 42</BreadcrumbItem>
        <BreadcrumbItem Active="true">Contratos</BreadcrumbItem>
    </Items>
</Breadcrumb>
```

**Limitações**: Skeleton de breadcrumb não é nativo.

### UIP-NAV-TABS - Tabs

**Componentes**: `ButtonGroup`, `Button`, `Badge`.

**Nota**: 2

**Justificativa**: Tabs podem ser simuladas com `ButtonGroup` e estado ativo, mas não há componente com semântica de tabs, roles ARIA, painel associado ou scroll horizontal. A cobertura é vestigial.

**Tipo de cobertura**: Vestigial por botões.

**Esforço de adaptação**: Implementar componente de tabs ou garantir roles, teclado, painel e responsividade.

**Como usar**:

```razor
<ButtonGroup AriaLabel="Seções do detalhe">
    <Button Label="Resumo" Active="@(tab == "summary")" OnClick="@(_ => tab = "summary")" />
    <Button Label="Histórico" Active="@(tab == "history")" OnClick="@(_ => tab = "history")" />
    <Button Label="Anexos" Active="@(tab == "files")" OnClick="@(_ => tab = "files")" />
</ButtonGroup>

<Box AdditionalClasses="mt-4 p-4 bg-white border border-light-300 rounded-md">
    Conteúdo da aba: @tab
</Box>

@code {
    private string tab = "summary";
}
```

**Limitações**: Não tratar como tabs acessíveis completas sem implementação adicional.

### UIP-NAV-PAGINATION - Pagination

**Componentes**: `Pagination`, `PaginationSinglePageMode`, `Sizes`.

**Nota**: 9

**Justificativa**: Paginação é componente direto, com página atual, total, loading, tamanho, janela desktop e modo mobile compacto. A nota é alta porque cobre o pattern praticamente inteiro.

**Tipo de cobertura**: Nativo.

**Esforço de adaptação**: Conectar estado externo, total de páginas e busca de dados.

**Como usar**:

```razor
<Pagination CurrentPage="@page"
            TotalPages="@totalPages"
            Loading="@loading"
            Size="Sizes.Medium"
            OnPageChanged="@SetPage" />

@code {
    private int page = 1;
    private int totalPages = 12;
    private bool loading;

    private Task SetPage(int value)
    {
        page = value;
        return Task.CompletedTask;
    }
}
```

**Limitações**: Não substitui infinite scroll.

### UIP-NAV-STEPPER_INDICATOR - Stepper Indicator

**Componentes**: `Badge`, `ButtonGroup`, `Button`, `Feedback`.

**Nota**: 2

**Justificativa**: Não há stepper nativo. Badges e botões conseguem representar progresso manual, mas não entregam semântica, validação por etapa ou responsividade própria.

**Tipo de cobertura**: Vestigial por composição.

**Esforço de adaptação**: Criar stepper acessível com estados atual/concluído/futuro/erro.

**Como usar**:

```razor
<div class="flex flex-wrap gap-2">
    @foreach (var stepInfo in steps)
    {
        <Badge Text="@stepInfo.Label"
               Style="@(stepInfo.Number == currentStep ? Themes.Primary : Themes.Light)"
               Size="Sizes.Small" />
    }
</div>

@code {
    private int currentStep = 2;
    private readonly (int Number, string Label)[] steps = [(1, "Conta"), (2, "Dados"), (3, "Confirmar")];
}
```

**Limitações**: Apenas indicador visual simples.

## UI Data

### UIP-DATA-DATA_TABLE - Data Table

**Componentes**: `Box`, `ButtonGroup`, `IconButton`, `DropIconButton`, `DropItem`, `Badge`, `Pagination`.

**Nota**: 1

**Justificativa**: Não há tabela ou data grid. HTML `<table>` pode ser estilizado com classes e ações Yasamen, mas seleção, ordenação, densidade, expansão, coluna de ação e responsividade precisam ser manuais.

**Tipo de cobertura**: Vestigial.

**Esforço de adaptação**: Construir componente de tabela ou integrar grid externo; padronizar estados e ações.

**Como usar**:

```razor
<Box AdditionalClasses="p-4 bg-white border border-light-300 rounded-md">
    <table class="w-full text-sm">
        <thead>
            <tr class="border-b border-light-300 text-left">
                <th class="p-3">Cliente</th>
                <th class="p-3">Status</th>
                <th class="p-3 text-right">Ações</th>
            </tr>
        </thead>
        <tbody>
            <tr class="border-b border-light-200">
                <td class="p-3">Royal Code</td>
                <td class="p-3"><Badge Text="Ativo" Style="Themes.Success" Size="Sizes.Small" /></td>
                <td class="p-3 text-right">
                    <DropIconButton Icon="BsIconNames.ThreeDots" MinWidth="Sizes.Smaller">
                        <DropItem>Editar</DropItem>
                        <DropItem>Excluir</DropItem>
                    </DropIconButton>
                </td>
            </tr>
        </tbody>
    </table>
    <Pagination CurrentPage="1" TotalPages="5" OnPageChanged="@(_ => Task.CompletedTask)" />
</Box>
```

**Limitações**: Tabela é HTML customizado, não componente Yasamen.

### UIP-DATA-LIST_ITEM - List Item

**Componentes**: `Box`, `Badge`, `IconButton`, `DropIconButton`, `DropItem`, `Button`.

**Nota**: 5

**Justificativa**: Não há `ListItem` genérico, mas uma linha/bloco de lista é simples de compor com `Box`, badge e ações. A nota é parcial porque estados de seleção, hover, disabled e densidade ficam manuais.

**Tipo de cobertura**: Composição parcial.

**Esforço de adaptação**: Padronizar item, área de toque, seleção e metadados.

**Como usar**:

```razor
<Stack AdditionalClasses="gap-2">
    @foreach (var item in items)
    {
        <Box AdditionalClasses="p-4 bg-white border border-light-300 rounded-md">
            <div class="flex items-center justify-between gap-4">
                <div>
                    <div class="font-medium">@item.Title</div>
                    <div class="text-sm text-dark-500">@item.Description</div>
                </div>
                <Badge Text="@item.Status" Style="Themes.Info" Size="Sizes.Small" />
            </div>
        </Box>
    }
</Stack>

@code {
    private readonly (string Title, string Description, string Status)[] items = [("Pedido 001", "Criado hoje", "Novo")];
}
```

**Limitações**: Não substitui tabela em coleções densas.

### UIP-DATA-CARD_GRID - Card Grid

**Componentes**: `Container`, `Slot`, `Box`, `Badge`, `Button`, `DropIconButton`, `DropItem`.

**Nota**: 4

**Justificativa**: O grid responsivo é forte, mas card é composição manual. Não há componente de card com imagem, título, metadados e ação primária padronizados.

**Tipo de cobertura**: Baixa por composição.

**Esforço de adaptação**: Definir card padrão, imagem/thumbnail, estados de loading/empty e ação de item.

**Como usar**:

```razor
<Container>
    @foreach (var card in cards)
    {
        <Slot Span="4" LaptopSpan="4">
            <Box AdditionalClasses="p-4 bg-white border border-light-300 rounded-md space-y-3">
                <div class="aspect-video rounded-md bg-light-200"></div>
                <Badge Text="@card.Tag" Style="Themes.Highlight" Size="Sizes.Small" />
                <h3 class="font-medium">@card.Title</h3>
                <Button Label="Abrir" Style="Themes.Primary" Size="Sizes.Small" />
            </Box>
        </Slot>
    }
</Container>

@code {
    private readonly (string Title, string Tag)[] cards = [("Componente", "UI")];
}
```

**Limitações**: Visual de card não é contrato de biblioteca.

### UIP-DATA-TIMELINE_ITEM - Timeline Item

**Componentes**: `Box`, `Stack`, `Badge`, `Icon`, `DropIconButton`, `DropItem`.

**Nota**: 2

**Justificativa**: Timeline precisa ser desenhada manualmente; a biblioteca só oferece badges, ícones e containers. Não há eixo temporal, conector, agrupamento ou estados de item novo/expandido.

**Tipo de cobertura**: Vestigial.

**Esforço de adaptação**: Criar estrutura de linha temporal, marcadores, conectores e ações.

**Como usar**:

```razor
<Stack AdditionalClasses="gap-4">
    <div class="flex gap-4">
        <div class="mt-1 h-3 w-3 rounded-full bg-primary-500"></div>
        <Box AdditionalClasses="flex-1 p-4 bg-white border border-light-300 rounded-md">
            <Badge Text="10:30" Style="Themes.Light" Size="Sizes.Small" />
            <p class="mt-2">Status alterado para aprovado.</p>
        </Box>
    </div>
</Stack>
```

**Limitações**: Sem componente de timeline.

### UIP-DATA-KANBAN_COLUMN - Kanban Column

**Componentes**: `Box`, `Stack`, `Badge`, `DropIconButton`, `DropItem`.

**Nota**: 1

**Justificativa**: Coluna e card podem ser desenhados, mas kanban real exige drag-and-drop, estados de drop, limites, navegação mobile por coluna e mudança de estado. Nada disso é nativo.

**Tipo de cobertura**: Vestigial.

**Esforço de adaptação**: Implementar coluna, item movível, regras de drop e alternativa mobile.

**Como usar**:

```razor
<Box AdditionalClasses="p-4 bg-light-100 border border-light-300 rounded-md min-w-72">
    <div class="flex justify-between mb-3">
        <h3 class="font-medium">Em andamento</h3>
        <Badge Text="3" Style="Themes.Secondary" Size="Sizes.Small" />
    </div>
    <Stack AdditionalClasses="gap-3">
        <Box AdditionalClasses="p-3 bg-white border border-light-300 rounded-md">
            <div class="font-medium">Tarefa 42</div>
            <Badge Text="Alta" Style="Themes.Warning" Size="Sizes.Small" />
        </Box>
    </Stack>
</Box>
```

**Limitações**: Não há drag-and-drop nem semântica de board.

## UI Input

### UIP-INPUT-FORM_FIELD_GROUP - Form Field Group

**Componentes**: `TextField`, `FieldText`, `FieldBadge`, `FieldAction`, `Container`, `Slot`, `Feedback`.

**Nota**: 7

**Justificativa**: `TextField` encapsula label, informação, erro e slots de campo; `Container` organiza grupos responsivos. A nota é alta para campos textuais, mas parcial para grupos com controles variados.

**Tipo de cobertura**: Alta parcial.

**Esforço de adaptação**: Criar componentes equivalentes para tipos de campo ausentes ou padronizar HTML padrão.

**Como usar**:

```razor
<EditForm Model="profile">
    <Container>
        <Slot Span="4" LaptopSpan="6">
            <TextField Label="Usuário" @bind-Value="profile.UserName" Information="Use letras e números.">
                <Prepend><FieldText>#</FieldText></Prepend>
                <DescriptionComplement><FieldBadge Text="Obrigatório" Style="Themes.Warning" /></DescriptionComplement>
            </TextField>
        </Slot>
        <Slot Span="4" LaptopSpan="6">
            <TextField Label="Senha" Type="InputType.Password" @bind-Value="profile.Password" />
        </Slot>
    </Container>
</EditForm>

@code {
    private Profile profile = new();
    private sealed class Profile { public string UserName { get; set; } = string.Empty; public string Password { get; set; } = string.Empty; }
}
```

**Limitações**: Select, radio, checkbox, textarea e date não são componentes Yasamen mapeados.

### UIP-INPUT-SEARCH_BAR - Search Bar

**Componentes**: `TextField`, `FieldText`, `FieldAction`, `Button`, `IconButton`.

**Nota**: 5

**Justificativa**: Busca textual pode ser implementada com `TextField`, prepend/append e botão de ação. Falta semântica específica de search, botão limpar, loading no campo, sugestões e dropdown.

**Tipo de cobertura**: Composição parcial.

**Esforço de adaptação**: Implementar limpeza, debounce, sugestões, estado buscando e acessibilidade.

**Como usar**:

```razor
<TextField Label="Buscar" @bind-Value="query" Placeholder="Nome, código ou termo">
    <Prepend>
        <FieldText>#</FieldText>
    </Prepend>
    <FooterAction>
        <FieldAction Label="Pesquisar" Style="Themes.Primary" OnClick="@(_ => SearchAsync())" />
    </FooterAction>
</TextField>

@code {
    private string query = string.Empty;
    private Task SearchAsync() => Task.CompletedTask;
}
```

**Limitações**: Não usar `AppMenu` como busca pronta.

### UIP-INPUT-FILTER_PANEL - Filter Panel

**Componentes**: `OffCanvas`, `TextField`, `ButtonGroup`, `Button`, `Badge`, `Feedback`.

**Nota**: 4

**Justificativa**: Um painel de filtros pode ser composto, inclusive como offcanvas. A cobertura é baixa porque não há controles de filtro variados, chips de filtros ativos ou aplicação/limpeza padronizadas.

**Tipo de cobertura**: Baixa por composição.

**Esforço de adaptação**: Criar controles por faceta, estado de filtros ativos, limpar todos e variante desktop/mobile.

**Como usar**:

```razor
<Button Label="Filtros" Style="Themes.Secondary" OnClick="@(async _ => await filters.OpenAsync())" />

<OffCanvas Handler="filters" Position="Positions.End" Title="Filtros">
    <Stack AdditionalClasses="gap-4 p-4">
        <TextField Label="Status" @bind-Value="status" />
        <TextField Label="Responsável" @bind-Value="owner" />
        <ButtonGroup AriaLabel="Ações de filtro">
            <Button Label="Aplicar" Style="Themes.Primary" />
            <Button Label="Limpar" Style="Themes.Light" />
        </ButtonGroup>
    </Stack>
</OffCanvas>

@code {
    private readonly OffCanvasHandler filters = new();
    private string status = string.Empty;
    private string owner = string.Empty;
}
```

**Limitações**: Filtros estruturados dependem de controles ausentes.

### UIP-INPUT-DATE_PICKER - Date Picker

**Componentes**: `TextField`, `FieldText`, `Feedback`.

**Nota**: 1

**Justificativa**: `InputType` cobre apenas `Text` e `Password`; não há date picker nem calendário dropdown. Um campo textual pode capturar data, mas não atende seleção estruturada.

**Tipo de cobertura**: Vestigial.

**Esforço de adaptação**: Implementar date picker próprio ou integrar biblioteca externa; usar `TextField` só como fallback textual.

**Como usar**:

```razor
<TextField Label="Data inicial"
           @bind-Value="dateText"
           Placeholder="AAAA-MM-DD"
           Error="@dateError">
    <Prepend><FieldText>Data</FieldText></Prepend>
</TextField>

@code {
    private string dateText = string.Empty;
    private string? dateError;
}
```

**Limitações**: Sem validação visual de calendário, seleção de intervalo ou datas desabilitadas.

### UIP-INPUT-INLINE_EDITOR - Inline Editor

**Componentes**: `TextField`, `ButtonGroup`, `Button`, `IconButton`, `Feedback`.

**Nota**: 3

**Justificativa**: É possível alternar manualmente leitura/edição com `TextField` e botões, mas não há componente de inline editor, confirmação por Enter/blur, cancelamento por Escape ou estado de salvamento.

**Tipo de cobertura**: Baixa por composição.

**Esforço de adaptação**: Controlar modo de edição, foco, teclado, validação local e rollback.

**Como usar**:

```razor
@if (editing)
{
    <div class="flex gap-2">
        <TextField Label="Nome" @bind-Value="nameDraft" />
        <ButtonGroup Size="Sizes.Small" AriaLabel="Salvar edição">
            <Button Label="Salvar" Style="Themes.Primary" OnClick="@(_ => Save())" />
            <Button Label="Cancelar" Style="Themes.Light" OnClick="@(_ => editing = false)" />
        </ButtonGroup>
    </div>
}
else
{
    <div class="flex items-center gap-2">
        <span class="font-medium">@name</span>
        <IconButton Icon="BsIconNames.Pencil" Size="Sizes.Small" OnClick="@(_ => editing = true)" />
    </div>
}

@code {
    private bool editing;
    private string name = "Royal Code";
    private string nameDraft = "Royal Code";
    private void Save() { name = nameDraft; editing = false; }
}
```

**Limitações**: Sem acessibilidade/teclado de inline edit prontos.

## UI Action

### UIP-ACTION-ACTION_BAR - Action Bar

**Componentes**: `Bar`, `ButtonGroup`, `Button`, `IconButton`, `DropIconButton`, `DropItem`.

**Nota**: 8

**Justificativa**: `Bar` e `ButtonGroup` cobrem bem barras de ação com áreas start/middle/end e agrupamento visual. A nota não é 10 porque overflow mobile e regras de disponibilidade por seleção não são automáticas.

**Tipo de cobertura**: Alta por composição.

**Esforço de adaptação**: Definir quais ações ficam visíveis, quais vão para overflow e quando desabilitar por estado/permissão.

**Como usar**:

```razor
<Bar AdditionalClasses="p-4 bg-white border border-light-300 rounded-md">
    <Start>
        <h2 class="font-medium">Pedidos</h2>
    </Start>
    <End>
        <ButtonGroup Size="Sizes.Small" AriaLabel="Ações">
            <Button Label="Novo" Style="Themes.Primary" />
            <Button Label="Exportar" Style="Themes.Secondary" />
            <DropIconButton Icon="BsIconNames.ThreeDots" MinWidth="Sizes.Smaller">
                <DropItem>Arquivar seleção</DropItem>
                <DropItem>Excluir</DropItem>
            </DropIconButton>
        </ButtonGroup>
    </End>
</Bar>
```

**Limitações**: Overflow responsivo é manual.

### UIP-ACTION-CONTEXTUAL_MENU - Contextual Menu

**Componentes**: `DropButton`, `DropIconButton`, `DropItem`, `Button`, `IconButton`.

**Nota**: 8

**Justificativa**: Menus contextuais são muito bem cobertos por drops, alinhamento, direção, largura mínima e itens clicáveis. A nota não é maior porque não há agrupamento/separador semântico nem variante mobile sheet.

**Tipo de cobertura**: Alta por componente direto.

**Esforço de adaptação**: Definir agrupamentos, estados disabled/destrutivo e alternativa touch quando necessário.

**Como usar**:

```razor
<DropIconButton Icon="BsIconNames.ThreeDots"
                Direction="Directions.Down"
                Align="Positions.End"
                MinWidth="Sizes.Smaller">
    <DropItem OnClick="@(_ => Edit())">Editar</DropItem>
    <DropItem OnClick="@(_ => Duplicate())">Duplicar</DropItem>
    <DropItem OnClick="@(_ => Delete())">Excluir</DropItem>
</DropIconButton>

@code {
    private void Edit() { }
    private void Duplicate() { }
    private void Delete() { }
}
```

**Limitações**: Não há item disabled formal mapeado.

### UIP-ACTION-FLOATING_ACTION - Floating Action

**Componentes**: `IconButton`, `Button`, `Modal`, `OffCanvas`.

**Nota**: 5

**Justificativa**: Um FAB pode ser composto com `IconButton` e classes fixas, mas não existe componente que garanta posição, tamanho mínimo, safe area mobile ou colisão com navegação.

**Tipo de cobertura**: Composição parcial.

**Esforço de adaptação**: Definir posicionamento, z-index, responsividade, label acessível e comportamento de foco.

**Como usar**:

```razor
<IconButton Icon="BsIconNames.Plus"
            Style="Themes.Primary"
            Size="Sizes.Largest"
            title="Criar item"
            AdditionalClasses="fixed right-6 bottom-6 z-notification shadow-lg"
            OnClick="@(_ => Create())" />

@code {
    private void Create() { }
}
```

**Limitações**: Precisa validar sobreposição com footer, toasts e mobile.

## UI Feedback

### UIP-FEEDBACK-EMPTY_STATE - Empty State

**Componentes**: `Feedback`, `Button`, `Icon`, `Box`.

**Nota**: 5

**Justificativa**: Um empty state pode ser composto com `Feedback` e CTA, mas não há componente dedicado com layout centrado, ilustração, título/subtítulo e variantes para sem dados/sem resultados.

**Tipo de cobertura**: Composição parcial.

**Esforço de adaptação**: Padronizar estrutura, ícone, CTA e mensagens por contexto.

**Como usar**:

```razor
<Box AdditionalClasses="p-8 bg-white border border-light-300 rounded-md text-center">
    <Feedback Style="Themes.Info"
              Title="Nenhum resultado encontrado"
              Text="Ajuste os filtros ou crie um novo registro."
              Block="true" />
    <Button Label="Criar registro" Style="Themes.Primary" AdditionalClasses="mt-4" />
</Box>
```

**Limitações**: Não há skeleton/ilustração de empty state.

### UIP-FEEDBACK-LOADING_STATE - Loading State

**Componentes**: `Pagination` com `Loading`, `Button` disabled, `RotationMotion`, `Icon`, `Feedback`.

**Nota**: 3

**Justificativa**: Existem sinais pontuais de loading em paginação e motion de rotação, mas não há skeleton, spinner semântico ou estado de carregamento global. A cobertura é baixa.

**Tipo de cobertura**: Baixa por composição.

**Esforço de adaptação**: Criar skeletons e indicadores padronizados para listas, cards e botões.

**Como usar**:

```razor
<Box AdditionalClasses="p-6 bg-white border border-light-300 rounded-md">
    <div class="flex items-center gap-3 text-dark-600">
        <RotationMotion>
            <Icon Kind="BsIconNames.ArrowClockwise" />
        </RotationMotion>
        <span>Carregando dados...</span>
    </div>
    <Pagination CurrentPage="1" TotalPages="10" Loading="true" OnPageChanged="@(_ => Task.CompletedTask)" />
</Box>
```

**Limitações**: `RotationMotion` é suporte visual, não loading state completo.

### UIP-FEEDBACK-ERROR_STATE - Error State

**Componentes**: `Feedback`, `Button`, `ButtonGroup`, `Box`.

**Nota**: 6

**Justificativa**: `Feedback` cobre bem mensagem de erro inline com tema `Danger`, título, texto, ícone e fechamento. Falta um componente de error state de página/zona com retry e layout próprio.

**Tipo de cobertura**: Parcial alta.

**Esforço de adaptação**: Criar wrapper de zona, retry e diferenciação entre erro técnico, permissão e não encontrado.

**Como usar**:

```razor
<Box AdditionalClasses="p-6 bg-white border border-light-300 rounded-md">
    <Feedback Style="Themes.Danger"
              Title="Não foi possível carregar"
              Text="Tente novamente. Se o problema persistir, contate o suporte." />
    <Button Label="Tentar novamente" Style="Themes.Primary" AdditionalClasses="mt-4" OnClick="@(_ => RetryAsync())" />
</Box>

@code {
    private Task RetryAsync() => Task.CompletedTask;
}
```

**Limitações**: Não há componente para erro estrutural de página.

### UIP-FEEDBACK-TOAST_ALERT - Toast / Alert

**Componentes**: `Feedback`, `Notification`, `NotificationContent`, `NotificationGroup`, `Notify`, `NotificationOutlet`.

**Nota**: 9

**Justificativa**: A biblioteca cobre tanto alert inline persistente (`Feedback`) quanto toast (`Notification`/`Notify`), com tema, ícone, close, timer, grupo e outlet no shell. A nota é alta porque o pattern é diretamente suportado.

**Tipo de cobertura**: Nativo.

**Esforço de adaptação**: Escolher entre feedback local e toast global; registrar serviço de notificação quando usar `Notify`.

**Como usar**:

```razor
@inject Notify Notify

<Feedback Style="Themes.Success"
          Title="Alterações salvas"
          Text="Os dados foram atualizados com sucesso." />

<Button Label="Disparar toast"
        Style="Themes.Primary"
        OnClick="@(_ => Notify.ShowAsync(Themes.Success, "Salvo", "Operação concluída"))" />
```

**Limitações**: `NotificationGroup` e `NotificationAnimation` aparecem como suporte avançado; preferir `Notify` ou `Notification` para uso comum.

### UIP-FEEDBACK-CONFIRMATION_DIALOG - Confirmation Dialog

**Componentes**: `Modal`, `ModalHandler`, `ButtonGroup`, `Button`, `Feedback`.

**Nota**: 7

**Justificativa**: `Modal` permite construir confirmação bloqueante com backdrop e handler. A nota não é maior porque não há componente específico de confirmação, serviço de confirm dialog ou convenção nativa para ações destrutivas/processando.

**Tipo de cobertura**: Alta por composição.

**Esforço de adaptação**: Criar conteúdo padronizado, bloquear botão durante processamento e integrar resultado da decisão.

**Como usar**:

```razor
<Button Label="Excluir" Style="Themes.Danger" OnClick="@(async _ => await confirm.OpenAsync())" />

<Modal Id="delete-confirmation" Handler="confirm">
    <Box AdditionalClasses="p-6 bg-white rounded-md space-y-4">
        <Feedback Style="Themes.Warning"
                  Title="Confirmar exclusão"
                  Text="Esta ação não pode ser desfeita." />
        <ButtonGroup AriaLabel="Confirmar exclusão">
            <Button Label="Cancelar" Style="Themes.Light" OnClick="@(async _ => await confirm.CloseAsync())" />
            <Button Label="Excluir" Style="Themes.Danger" OnClick="@(_ => DeleteAsync())" />
        </ButtonGroup>
    </Box>
</Modal>

@code {
    private readonly ModalHandler confirm = new();
    private Task DeleteAsync() => Task.CompletedTask;
}
```

**Limitações**: Não há API de resultado modal confirmada.

## UI Content

### UIP-CONTENT-DETAIL_BLOCK - Detail Block

**Componentes**: `Box`, `Stack`, `Badge`, `ButtonGroup`, `Button`, `Breadcrumb`.

**Nota**: 5

**Justificativa**: Blocos de detalhe são simples por composição, mas não há componente de atributo/valor, seção de detalhe ou metadado. A cobertura é parcial.

**Tipo de cobertura**: Composição parcial.

**Esforço de adaptação**: Padronizar `dl`, seções, labels, valores vazios e edição por seção.

**Como usar**:

```razor
<Box AdditionalClasses="p-6 bg-white border border-light-300 rounded-md space-y-4">
    <div class="flex items-center justify-between">
        <h2 class="text-lg font-medium">Dados do contrato</h2>
        <Badge Text="Vigente" Style="Themes.Success" />
    </div>
    <dl class="grid gap-4 md:grid-cols-2">
        <div><dt class="text-sm text-dark-500">Número</dt><dd class="font-medium">CTR-2026-001</dd></div>
        <div><dt class="text-sm text-dark-500">Cliente</dt><dd class="font-medium">Royal Code</dd></div>
    </dl>
</Box>
```

**Limitações**: Layout de atributos é manual.

### UIP-CONTENT-METRIC_CARD - Metric Card

**Componentes**: `Box`, `Badge`, `Icon`, `Feedback`.

**Nota**: 4

**Justificativa**: É possível compor um metric card visualmente consistente, mas não há componente de KPI, variação, período ou sparkline. A nota é baixa por ausência semântica.

**Tipo de cobertura**: Baixa por composição.

**Esforço de adaptação**: Criar componente de KPI e padronizar variação positiva/negativa/neutra.

**Como usar**:

```razor
<Box AdditionalClasses="p-5 bg-white border border-light-300 rounded-md">
    <div class="text-sm text-dark-500">Conversão</div>
    <div class="mt-2 text-3xl font-medium text-dark-900">18,4%</div>
    <Badge Text="+2,1%" Style="Themes.Success" Size="Sizes.Small" AdditionalClasses="mt-3" />
</Box>
```

**Limitações**: Sem chart/sparkline.

### UIP-CONTENT-RICH_TEXT_BLOCK - Rich Text Block

**Componentes**: `Box`, HTML semântico, `Button`, `Badge`, `Feedback`.

**Nota**: 4

**Justificativa**: Blocos de texto rico podem usar HTML e base de estilos, mas não há componente de rich text, prose, markdown ou viewer documental. A nota é baixa porque a tipografia global tem lacunas de tokens no reboot.

**Tipo de cobertura**: Baixa por HTML + composição.

**Esforço de adaptação**: Definir classes de leitura, largura, headings, listas, links e imagens.

**Como usar**:

```razor
<Box AdditionalClasses="p-6 bg-white border border-light-300 rounded-md">
    <article class="max-w-3xl space-y-4 text-dark-700">
        <Badge Text="Guia" Style="Themes.Info" />
        <h1 class="text-2xl font-medium text-dark-900">Política de uso</h1>
        <p>Use os componentes Yasamen priorizando clareza, feedback contextual e ações semânticas.</p>
        <ul class="list-disc pl-6">
            <li>Use `Themes.Primary` para a ação principal.</li>
            <li>Use `Feedback` para mensagens persistentes.</li>
        </ul>
    </article>
</Box>
```

**Limitações**: Não há normalização editorial completa.

### UIP-CONTENT-MEDIA_VIEWER - Media Viewer

**Componentes**: `Box`, `ButtonGroup`, `IconButton`, `Feedback`.

**Nota**: 1

**Justificativa**: Não há viewer de imagem, vídeo, documento ou arquivo. A biblioteca só fornece containers e ações para envolver um viewer externo.

**Tipo de cobertura**: Vestigial.

**Esforço de adaptação**: Criar viewer ou integrar componente externo; usar Yasamen para controles e estados.

**Como usar**:

```razor
<Box AdditionalClasses="p-4 bg-white border border-light-300 rounded-md">
    <div class="aspect-video bg-light-200 rounded-md grid place-items-center">
        <Feedback Style="Themes.Info" Text="Renderize a mídia aqui com componente próprio." />
    </div>
    <ButtonGroup Size="Sizes.Small" AriaLabel="Controles de mídia" AdditionalClasses="mt-4">
        <IconButton Icon="BsIconNames.ZoomIn" />
        <IconButton Icon="BsIconNames.ZoomOut" />
        <IconButton Icon="BsIconNames.Download" />
    </ButtonGroup>
</Box>
```

**Limitações**: Mídia real é externa ao Yasamen.

## Componentes sem pattern mapeado

| Componente | Justificativa |
|---|---|
| `YasamenStyles` | Componente de setup/carregamento de CSS; necessário para aplicação, mas não representa pattern visual. |
| `Ripple` | Utilitário interno de interação usado por botões; não deve ser escolhido diretamente como pattern. |
| `DropBase` | Base interna de `DropButton`/`DropIconButton`; já contemplada em contextual menu. |
| `ModalOutlet`, `ModalBackdrop` | Infraestrutura interna de modal; contemplada indiretamente em shell e confirmation dialog. |
| `OffCanvasOutlet` | Infraestrutura interna de offcanvas; contemplada indiretamente em shell, filter panel e navigation menu. |
| `NotificationOutlet`, `NotificationSection` | Infraestrutura interna de toast global; contemplada em toast/alert. |
| `InputFieldBase`, `FieldGroup`, `ControlGroup`, `FieldError` | Bases internas do `TextField`; contempladas em form field group e form. |
| `NotificationAnimation`, `NotificationGroup` | Suporte avançado de notificação; usar com cautela, pois aparecem como internos apesar de serem demonstrados. |
| `RotateEffect`, `RotationMotion` | Recursos de motion auxiliares; entram como suporte para loading/ícones, não como pattern próprio. |
| `Icon` | Elemento transversal usado em botões, badges, feedbacks, menus e conteúdo; não forma pattern isolado no catálogo. |

## Análise por Grupo

| Grupo | Nota média | Patterns fortes (>=7) | Patterns fracos (<=4) | Observações de adaptação |
|---|---:|---|---|---|
| Shell | 3.5 | SHP-WORKSPACE_ADMIN | Communication, Media/Content, Dashboard/Analytics, Studio/Workbench, Transactional/Commerce, Kiosk/Embedded | Forte para app shell administrativo; fraco para shells especializados. |
| Page | 3.0 | PP-FORM | Catalog, Wizard, Dashboard, Landing, Conversation, Feed, Board, Calendar, Map, Canvas | Formulários e detalhes são viáveis; páginas de dados ricos, mapa, calendário e canvas exigem blueprint. |
| UI Struct | 6.6 | Layout Zone, Stack Container, Grid Container | Scrollable Region | Grid e stack são bons; split/scroll precisam de comportamento manual. |
| UI Navigation | 6.0 | Navigation Menu, Breadcrumb, Pagination | Tabs, Stepper Indicator | Navegação global, breadcrumb e paginação estão fortes; tabs e stepper são lacunas. |
| UI Data | 2.6 | nenhum | Data Table, Card Grid, Timeline Item, Kanban Column | Dados/listagens são o maior gap funcional visível. |
| UI Input | 4.0 | Form Field Group | Filter Panel, Date Picker, Inline Editor | `TextField` é bom, mas a família de inputs está curta. |
| UI Action | 7.0 | Action Bar, Contextual Menu | nenhum | Ações são uma área forte; FAB precisa só de padronização. |
| UI Feedback | 6.0 | Toast / Alert, Confirmation Dialog | Loading State | Feedback e toast são fortes; loading/skeleton precisa blueprint. |
| UI Content | 3.5 | nenhum | Metric Card, Rich Text Block, Media Viewer | Conteúdo estruturado é possível, mas sem componentes dedicados. |

### Recomendações por grupo

- **Shell**: priorizar correção/implementação da busca no `AppMenu` antes de prometer navegação global pesquisável.
- **Page**: gerar blueprints para Calendar, Map, Canvas, Board, Dashboard e Catalog quando esses patterns forem usados.
- **UI Struct**: padronizar split panel e scrollable region para reduzir repetição em telas list-detail e conversation.
- **UI Navigation**: criar blueprint de Tabs e Stepper Indicator; a base de botões já permite uma primeira versão.
- **UI Data**: priorizar Data Table, List Item, Card Grid e Kanban Column, pois vários page patterns dependem desses blocos.
- **UI Input**: priorizar Select, Checkbox/Toggle, Date Picker e Filter Panel antes de fluxos de settings/catalog avançados.
- **UI Action**: formalizar Floating Action com regras de posição e mobile.
- **UI Feedback**: criar loading/skeleton e empty state dedicados; manter `Feedback`/`Notification` como base semântica.
- **UI Content**: criar Detail Block e Metric Card antes de dashboards ou páginas de detalhe densas.
