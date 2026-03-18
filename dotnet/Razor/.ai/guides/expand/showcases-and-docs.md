# Showcases e Documentação em Docs

> Como documentar componentes com exemplos de uso enquanto `RoyalCode.Razor.Show` ainda não existe como plataforma de showcase.

---

## Visão Geral

Hoje a solução **ainda não tem** uma plataforma dedicada de showcase no estilo Storybook, mas pensada para Blazor. Esse papel futuro pertence a `RoyalCode.Razor.Show`, porém o projeto ainda não saiu do papel.

Enquanto isso, o host oficial de exemplos e documentação executável é:

- `RoyalCode.Razor.Docs.Client`

Portanto:

- todo componente novo que precise de showcase deve ser documentado em `RoyalCode.Razor.Docs.Client`;
- `RoyalCode.Razor.Show` pode aparecer nas specs como direção futura, mas **não** deve ser tratado como host atual.

---

## Papel do Showcase

Um showcase não é só uma vitrine visual. Ele deve cumprir quatro funções ao mesmo tempo:

1. validar a API pública do componente em uso real;
2. demonstrar estados e variações importantes;
3. servir como documentação viva para consumidores da biblioteca;
4. reduzir regressões visuais e de integração ao longo do tempo.

Se a página apenas “mostra que renderizou”, ela não é um showcase bom o bastante.

---

## Avaliação do Estado Atual

O `Docs.Client` já tem uma base útil:

- há páginas reais de demonstração;
- o projeto já carrega `YasamenStyles`;
- o menu de demos já pode ser montado via `ConfigureMenu.cs`;
- alguns exemplos já cobrem variações e estados relevantes, como `TextField`, `Feedback` e `Notification`.

Mas a qualidade ainda é irregular. Os principais problemas observados hoje são:

### 1. Estrutura de páginas inconsistente

Há páginas boas em cobertura de estados, como `Forms/TextFieldPage.razor`, e páginas muito rasas, como `AppLayoutPage.razor`.

### 2. Rotas e taxonomia inconsistentes

Hoje coexistem rotas como:

- `/buttons`
- `/badges`
- `/modals`
- `/demo/forms/text-field`
- `/demo/commons/elementjs`

Isso dificulta navegação, previsibilidade e agrupamento por domínio.

### 3. Exemplos orientados demais a matriz visual e de menos a cenário real

Páginas como `ButtonsPage.razor`, `BadgesPage.razor` e `IconButtonPage.razor` mostram grade de tamanho/tema, o que é útil, mas isso aparece sem uma camada equivalente de uso real, composição e estados de negócio.

### 4. Vazamento de detalhes internos

`NotificationsPage.razor` usa `RoyalCode.Razor.Internal.Notifications`, o que não é aceitável como padrão de showcase de API pública.

### 5. HTML cru e estilos inline em excesso

Há uso de:

- `<button class="ya-btn ...">` no lugar de `Button`;
- `<style>` inline em página;
- `style=""` local para estrutura de exemplo.

Isso é aceitável como exceção pontual em demos muito técnicas, mas não como padrão da documentação dos componentes.

### 6. Linguagem e apresentação irregulares

Há mistura de português e inglês, títulos incompletos e páginas sem introdução mínima do que está sendo demonstrado.

---

## Host Canônico Atual

Até existir uma plataforma própria de showcase:

- o showcase deve ser criado em `RoyalCode.Razor.Docs.Client/Pages/Demo/...`;
- a navegação deve ser registrada em `RoyalCode.Razor.Docs.Client/ConfigureMenu.cs`;
- a página deve usar o layout padrão atual do Docs (`AppMainLayout`);
- estilos auxiliares do Docs devem ficar no projeto de Docs, não no pacote do componente.

---

## Convenção de Pastas e Rotas

### Pasta

```text
RoyalCode.Razor.Docs.Client/
└── Pages/
    └── Demo/
        ├── Actions/
        ├── Commons/
        ├── Feedback/
        ├── Forms/
        ├── Layouts/
        ├── Navigation/
        └── Overlays/
```

### Regra de rota

Todos os showcases novos devem usar:

```text
/demo/{grupo}/{componente-kebab-case}
```

Exemplos:

- `/demo/navigation/tabs`
- `/demo/navigation/pagination`
- `/demo/feedback/empty-state`
- `/demo/forms/text-field`

### Regra para páginas antigas

Rotas antigas em raiz, como `/buttons` ou `/modals`, passam a ser consideradas legado. Não usar esse padrão em novas páginas.

---

## Anatomia Obrigatória de uma Página de Showcase

Toda página nova deve seguir esta estrutura mínima:

1. `@page`
2. `@layout AppMainLayout`
3. container principal com espaçamento consistente
4. `h1` com nome do componente
5. parágrafo curto explicando o papel do componente
6. seções com `h2` para cenários relevantes

Estrutura recomendada:

```razor
@page "/demo/navigation/pagination"
@layout AppMainLayout

<Box AdditionalClasses="p-8 bg-white border-none">
    <h1>Pagination</h1>

    <p class="mb-6">
        Navegação paginada para listas, tabelas e grids.
    </p>

    <section>
        <h2>Básico</h2>
        ...
    </section>

    <section>
        <h2>Variações</h2>
        ...
    </section>

    <section>
        <h2>Estados</h2>
        ...
    </section>

    <section>
        <h2>Composição</h2>
        ...
    </section>
</Box>
```

---

## O Que Todo Showcase Deve Cobrir

Como regra geral, cada showcase deve ter:

### 1. Exemplo básico

O menor uso público que já faça sentido para o consumidor.

### 2. Variações relevantes

Somente as variações que realmente mudam comportamento ou leitura visual:

- tamanho;
- tema;
- orientação;
- composição;
- ícone;
- variante semântica.

### 3. Estados

Cobrir os estados que mais geram regressão ou dúvida:

- ativo;
- desabilitado;
- loading;
- vazio;
- inválido;
- closeable;
- readonly;
- selected.

Cada componente deve cobrir apenas os estados que fazem sentido para ele.

### 4. Composição ou integração

Mostrar o componente no contexto onde ele realmente será usado:

- `Pagination` com lista;
- `Tabs` com conteúdo;
- `EmptyState` com CTA;
- `TextField` com addons;
- `Modal` com handler.

### 5. Responsividade ou restrição de largura

Quando o componente muda entre Desktop e Mobile, o showcase deve explicitar isso com um bloco de largura reduzida ou outro cenário equivalente.

---

## Regras de Qualidade

### Usar API pública

- Não usar `RoyalCode.Razor.Internal.*` em showcases de consumidor.
- Se um cenário só existe com API interna, isso é indício de problema de design ou de showcase mal posicionado.

### Preferir componentes públicos da biblioteca

- Para demonstrar o próprio design system, prefira `Button`, `IconButton`, `TextField`, `Box`, `Stack` etc.
- HTML cru pode existir em controles auxiliares de playground, mas não deve substituir o uso normal do componente documentado.

### Evitar `<style>` inline e CSS local improvisado

- Não usar blocos `<style>` por página como padrão.
- Se o Docs precisar de helpers visuais, eles devem ser centralizados em CSS do projeto de Docs.

### Evitar páginas só com tabela-matriz

Grades de tema/tamanho são úteis, mas devem ser complemento, não a única forma de showcase.

### Linguagem consistente

- Usar português em títulos, descrições e textos auxiliares;
- manter nomes de componentes e símbolos de API em inglês apenas quando fizer parte da API pública.

---

## Menu e Descoberta

Toda página nova precisa de entrada correspondente em:

- `RoyalCode.Razor.Docs.Client/ConfigureMenu.cs`

Regra:

- o agrupamento do menu deve seguir o mesmo agrupamento da pasta e da rota;
- não criar atalhos soltos em raiz para páginas novas.

---

## Estilos do Próprio Docs

Os estilos usados para estruturar showcase **não** fazem parte do contrato público da biblioteca.

Logo:

- CSS de componente continua em `RoyalCode.Razor.Styles`;
- CSS do shell de documentação e de helpers de showcase deve ficar no projeto de Docs.

Exemplos de classes aceitáveis para o Docs:

- `ya-doc-page`
- `ya-doc-section`
- `ya-doc-example`
- `ya-doc-playground`
- `ya-doc-notes`

Essas classes são internas ao ambiente de documentação.

---

## Relação Futura com `RoyalCode.Razor.Show`

Quando `RoyalCode.Razor.Show` existir de fato, a direção recomendada é:

- mover a infraestrutura de showcase reutilizável para `RoyalCode.Razor.Show`;
- manter `RoyalCode.Razor.Docs` como host de navegação, conteúdo e documentação institucional;
- consumir o motor de showcase a partir do Docs.

Até lá:

- `Docs.Client` é a fonte canônica de showcases;
- specs e tarefas devem refletir esse estado real.

---

## Checklist

- [ ] O showcase está em `RoyalCode.Razor.Docs.Client/Pages/Demo/...`?
- [ ] A rota segue `/demo/{grupo}/{componente}`?
- [ ] O menu foi atualizado em `ConfigureMenu.cs`?
- [ ] A página tem `h1`, introdução e seções claras?
- [ ] Há exemplo básico, variações, estados e composição?
- [ ] O showcase usa apenas API pública?
- [ ] Não há `RoyalCode.Razor.Internal.*`?
- [ ] Não foi criado `*.razor.css` nem `<style>` inline no Docs?
- [ ] O conteúdo está consistente em português?



