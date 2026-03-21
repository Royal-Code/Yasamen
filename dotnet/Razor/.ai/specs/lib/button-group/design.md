# Design — ButtonGroup

## Decisões de Estrutura

- Implementar `ButtonGroup` em `RoyalCode.Razor.Buttons`.
- Usar `namespace RoyalCode.Razor.Components` para `ButtonGroup` e `ButtonGroupOrientation`.
- Usar `namespace RoyalCode.Razor.Internal.Buttons` para o contexto interno de herança do grupo.
- Não criar pacote novo: o componente pertence claramente à mesma família de `Button` e `IconButton`.
- Preservar o grafo atual do projeto `RoyalCode.Razor.Buttons`, sem novas `ProjectReference`. As dependências já existentes (`Animations`, `Commons`, `Icons`) continuam suficientes para o primeiro release.

## Composição, Dependências e Ordem de Implementação

- Classificação: primitivo base.
- Relação com os componentes existentes:
  - `ButtonGroup` não substitui `Button` nem `IconButton`; ele organiza e coordena defaults desses componentes.
  - `Button` e `IconButton` continuam sendo os leaf components da ação.
- Reuso previsto:
  - classes e semântica visuais já existentes de `Button` e `IconButton`;
  - helpers de classes e enums de `RoyalCode.Razor.Styles`.
- Componente-base ausente avaliado: não há outro pré-requisito estrutural antes dele.
- Justificativa: o próprio backlog histórico e o guide de composição tratam `ButtonGroup` como o primitivo que estava faltando para ações agrupadas.

## API Pública Proposta

### Componentes públicos

- `ButtonGroup`
- `ButtonGroupOrientation`

### Parâmetros

- `[EditorRequired] RenderFragment ChildContent`
- `ButtonGroupOrientation Orientation = ButtonGroupOrientation.Horizontal`
- `Themes Style = Themes.Default`
- `Sizes Size = Sizes.Default`
- `bool Disabled`
- `string? AriaLabel`
- `string? AdditionalClasses`
- `Dictionary<string, object>? AdditionalAttributes`

### Variações visuais e dimensionais

- `Style: Themes`: suportado como default herdado.
- Escopo inicial: o grupo aceita o mesmo conjunto de temas já usado por `Button` e `IconButton` (`Primary`, `Secondary`, `Tertiary`, `Info`, `Highlight`, `Success`, `Warning`, `Alert`, `Danger`, `Light`, `Dark`).
- Fallback de `Themes.Default`: não pinta o contêiner; apenas significa “não impor tema”. Nesse caso, cada `Button` e `IconButton` segue com o fallback que já existe hoje.
- `Size: Sizes`: suportado como default herdado.
- Escopo inicial: o grupo aceita toda a escala já existente em `Button` e `IconButton`.
- Fallback de `Sizes.Default`: não impõe escala; cada filho segue com o baseline já existente.
- `Outline`: não suportado no nível do grupo no primeiro release.
- Justificativa: `Button` e `IconButton` expõem `Outline` como `bool`, e a API atual não permite distinguir com segurança “valor default” de “valor explicitamente false” para uma herança limpa.

### Slots e eventos

- Slot único: `ChildContent`.
- Não haverá eventos próprios do grupo no primeiro release.
- O grupo não tentará sintetizar `OnClick`, `OnChanged` ou estado ativo centralizado.

## Estrutura Interna

Arquivos previstos:

- `RoyalCode.Razor.Buttons/Components/ButtonGroup.razor`
- `RoyalCode.Razor.Buttons/Components/ButtonGroup.razor.cs`
- `RoyalCode.Razor.Buttons/Components/ButtonGroupOrientation.cs`
- `RoyalCode.Razor.Buttons/Internal/Buttons/ButtonGroupContext.cs`
- ajustes em:
  - `RoyalCode.Razor.Buttons/Components/Button.razor.cs`
  - `RoyalCode.Razor.Buttons/Components/IconButton.razor.cs`

Estratégia interna:

- `ButtonGroup` renderiza um contêiner raiz simples (`div`) com `role="group"`.
- O componente fornece um `CascadingValue` com um `ButtonGroupContext` interno.
- `Button` e `IconButton` passam a calcular `EffectiveStyle`, `EffectiveSize` e `EffectiveDisabled` a partir do contexto:
  - `Style` herdado só entra quando o filho estiver em `Themes.Default`;
  - `Size` herdado só entra quando o filho estiver em `Sizes.Default`;
  - `Disabled` herdado entra como `OR` lógico com o valor local.
- O agrupamento visual não depende de registro de filhos nem de wrappers por item.
- A junção visual será feita por CSS do grupo sobre filhos diretos `.ya-btn` e `.ya-i-btn`.
- Filhos arbitrários ou wrappers intermediários continuam permitidos no markup, mas ficam fora do contrato visual do primeiro release.

### Contrato do `ButtonGroupContext`

```csharp
internal sealed class ButtonGroupContext
{
    public Themes Style { get; init; }
    public Sizes Size { get; init; }
    public bool Disabled { get; init; }
}
```

### Contrato do `ButtonGroupOrientation`

```csharp
public enum ButtonGroupOrientation
{
    Horizontal,
    Vertical
}
```

## CSS e Contrato Visual

- Criar `RoyalCode.Razor.Styles/wwwroot/css/components/btn-group.css`.
- Registrar o `@import` em `RoyalCode.Razor.Styles/wwwroot/yasamen.css`.
- Classes públicas previstas:
  - `ya-btn-group`
  - `ya-btn-group-horizontal`
  - `ya-btn-group-vertical`
  - `ya-btn-group-disabled`
- Regras visuais principais:
  - o contêiner expõe a estrutura do grupo;
  - os filhos diretos `Button` e `IconButton` perdem raio intermediário;
  - as bordas adjacentes colapsam com sobreposição controlada;
  - o item focado ou ativo sobe na pilha (`z-index`) para não ter o foco recortado;
  - a orientação vertical troca a lógica de borda lateral por borda superior/inferior.
- Não criar `ButtonGroup.razor.css`.

### Tokens de `yasamen.css` a reutilizar

- raios e arredondamento já usados por `btn.css` e `ibtn.css` (`--radius-sm`, `--radius-md`, `--radius-lg`);
- escala base de espaçamento (`--spacing`);
- duração e easing padrão (`--default-transition-duration`, `--default-transition-timing-function`);
- cores semânticas e contrastes já aplicados pelos próprios `Button` e `IconButton`.

O grupo não deve introduzir uma paleta nova; ele reaproveita a semântica de cor dos componentes filhos.

## Testes e Documentação

- Reaproveitar o projeto `RoyalCode.Razor.Buttons.Tests`.
- Casos mínimos de teste:
  - renderização raiz com `role="group"` e classes esperadas;
  - classe de orientação vertical;
  - herança de `Style` para `Button` com valor default;
  - herança de `Size` para `IconButton` com valor default;
  - desabilitação em cascata;
  - sobrescrita por filho com `Style` ou `Size` explícito;
  - mistura de `Button` com `IconButton`.
- Adicionar showcase no `RoyalCode.Razor.Docs.Client`.

## Showcase no Docs

- Rota inicial: `/demo/buttons/button-group`.
- Página alvo: `RoyalCode.Razor.Docs.Client/Pages/Demo/Buttons/ButtonGroupPage.razor`.
- Menu: registrar `Button Group` em `RoyalCode.Razor.Docs.Client/ConfigureMenu.cs`, preferencialmente abrindo o domínio `Buttons` como grupo alinhado à convenção nova.
- Estrutura mínima da página:
  - introdução curta;
  - seção `Básico`;
  - seção `Herança de Tema e Tamanho`;
  - seção `Composição com IconButton`;
  - seção `Orientação Vertical`;
  - seção `Estados`;
  - seção `Contêiner Estreito`.

## Riscos e Questões em Aberto

- Misturar botões filled, outline e temas muito diferentes dentro do mesmo grupo pode gerar junções visuais pouco elegantes; a spec não proíbe isso, mas o showcase deve priorizar composições coerentes.
- Wrappers intermediários quebram o seletor de filhos diretos do CSS; isso deve ficar explícito na documentação pública.
- Se surgir demanda por comportamento de seleção, roving tabindex ou toolbar semântica, o mais provável é abrir uma spec separada (`SegmentedButtonGroup`, `ToolbarGroup` ou equivalente), em vez de esticar demais `ButtonGroup`.
- A área de docs ainda tem páginas legadas de botões fora da taxonomia `/demo/...`; a implementação deve evitar ampliar essa dívida.

## Validação Esperada

- `dotnet build` de `RoyalCode.Razor.Buttons`.
- `dotnet build` de `RoyalCode.Razor.Docs.Client`.
- `dotnet test` de `RoyalCode.Razor.Buttons.Tests`.
- Validação manual do showcase em `/demo/buttons/button-group`.
- Na implementação concluída:
  - marcar `ButtonGroup` como entregue em `.ai/roadmap/components-plan-list.md`;
  - avaliar se `ui-map.md` merece menção mais forte a agrupamentos de ação, embora não exista um `UIP-*` próprio para `ButtonGroup`;
  - não há obrigação de alterar `ui-plan.md` se a entrega não mover prioridade do backlog ativo.
