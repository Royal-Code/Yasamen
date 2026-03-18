# Design — IpAddressField

## Decisões de Estrutura

- Implementar `IpAddressField` em `RoyalCode.Razor.Forms`.
- Usar `namespace RoyalCode.Razor.Components` para o componente público.
- Usar `namespace RoyalCode.Razor.Internal.Forms` para helpers internos de parsing e sincronização de segmentos, se necessários.
- Não criar pacote novo: o componente pertence claramente à família de inputs concretos sobre a infraestrutura já existente.
- Reutilizar `FieldBase<TValue>` e `FieldGroup`; não derivar de `InputFieldBase<TValue>`, porque o controle é segmentado e não mapeia para um único `<input>`.

## Composição, Dependências e Ordem de Implementação

- Classificação: componente composto especializado sobre a infraestrutura de forms já existente.
- Componentes e bases reutilizados:
  - `FieldBase<TValue>` para binding, `EditContext`, erros e ciclo de vida;
  - `FieldGroup` para label, descrição, informação, erro e addons;
  - `ControlGroup`, apenas se a implementação precisar preservar addons externos com o mesmo comportamento visual dos demais campos.
- Componente-base ausente avaliado: não há pré-requisito obrigatório para o primeiro release.
- Justificativa: embora exista espaço futuro para um primitivo interno de campo segmentado, `IpAddressField` não deve esperar por essa abstração porque ainda não há massa crítica de outros controles equivalentes no roadmap.
- Relação com `NumberField`: não depende dele; cada octeto será tratado como segmento textual numérico de alcance restrito, com parsing próprio e UX específica.

## API Pública Proposta

### Componente público

- `IpAddressField`

### Parâmetros

- Herdados de `FieldBase`:
  - `Id`
  - `Name`
  - `Label`
  - `LabelId`
  - `Placeholder`
  - `Information`
  - `Error`
  - `Disabled`
  - `ReadOnly`
  - `Size`
  - `Prepend`
  - `Append`
  - `DescriptionComplement`
  - `FooterAction`
  - `AdditionalClasses`
  - `AdditionalAttributes`
- Binding:
  - `IPAddress? Value`
  - `EventCallback<IPAddress?> ValueChanged`
  - `Expression<Func<IPAddress?>>? ValueExpression`
  - `EventCallback<IPAddress?> OnChange`

### Variações visuais e dimensionais

- `Style: Themes`: não suportado no primeiro release.
- Justificativa: o componente deve herdar a semântica visual do sistema de campos e estados de validação já existentes; introduzir tema público aqui criaria uma exceção sem par nos demais inputs concretos do pacote.
- `Size: Sizes`: suportado.
- Escopo inicial de `Size`: `Sizes.Small`, `Sizes.Default`, `Sizes.Large`, com herança compatível para outros valores do enum pela mesma convenção CSS de `ya-field-*`.
- Impacto de `Size`: largura de cada octeto, padding interno, altura do controle, densidade do separador e ritmo vertical do conjunto.

### Slots e eventos

- Slots herdados da infraestrutura de forms:
  - `Prepend`
  - `Append`
  - `DescriptionComplement`
  - `FooterAction`
- Eventos públicos:
  - `ValueChanged`
  - `OnChange`
- Não adicionar eventos extras de foco por octeto no primeiro release.

## Estrutura Interna

Arquivos previstos:

- `RoyalCode.Razor.Forms/Components/IpAddressField.razor`
- `RoyalCode.Razor.Forms/Components/IpAddressField.razor.cs`
- `RoyalCode.Razor.Forms/Internal/Forms/IpAddressSegments.cs` ou helper equivalente, se o parsing ficar extenso demais

Estratégia interna:

- Manter estado interno dos quatro segmentos como strings curtas.
- Sincronizar `Value` externo para os segmentos em `SetParametersAsync` ou `OnParametersSet`.
- Converter segmentos completos e válidos para `IPAddress` apenas quando os quatro octetos estiverem prontos.
- Tratar estado vazio completo como `null`.
- Considerar entrada parcial como estado intermediário local, sem publicar valor inválido como `IPAddress`.
- Distribuir colagem de `a.b.c.d` diretamente entre os segmentos.
- Usar markup com um contêiner raiz do controle e quatro `<input>` internos separados por pontos visuais.

## CSS e Contrato Visual

- Criar `RoyalCode.Razor.Styles/wwwroot/css/forms/ipaddressfield.css`.
- Registrar o `@import` em `RoyalCode.Razor.Styles/wwwroot/yasamen.css`.
- Classes públicas previstas:
  - `ya-ip-address-field`
  - `ya-ip-address-field-control`
  - `ya-ip-address-field-segment`
  - `ya-ip-address-field-separator`
  - `ya-ip-address-field-invalid`
  - `ya-ip-address-field-disabled`
  - `ya-ip-address-field-readonly`
  - `ya-ip-address-field-focused`
  - `ya-ip-address-field-complete`
  - `ya-ip-address-field-incomplete`
- Não criar `IpAddressField.razor.css`.
- Tokens de `yasamen.css` a reutilizar:
  - cores: `--color-light-10`, `--color-light-100`, `--color-dark-500`, `--color-dark-700`, `--color-primary-500`, `--color-primary-600`, `--color-danger-500`, `--color-danger-600`;
  - tipografia: `--font-sans`, escala de texto base já herdada pelo sistema de campos;
  - espaçamento: `--spacing-4`, `--spacing-5`, `--spacing-6`;
  - breakpoints: `--breakpoint-sm` e `--breakpoint-md` para ajustes de largura em docs e comportamento mais estreito.

## Testes e Documentação

- Casos mínimos de teste:
  - renderização com valor inicial externo;
  - digitação de um IPv4 válido e emissão de `ValueChanged`;
  - rejeição de octeto fora do intervalo `0..255`;
  - distribuição por colagem de valor completo;
  - limpeza total voltando para `null`;
  - integração com erro de validação em `EditForm`.
- Se ainda não houver projeto de testes para Forms, criar `RoyalCode.Razor.Forms.Tests` como parte da implementação.
- Adicionar showcase no `RoyalCode.Razor.Docs.Client` com exemplos reais de formulário.

## Showcase no Docs

- Rota inicial: `/demo/forms/ip-address-field`.
- Página alvo: `RoyalCode.Razor.Docs.Client/Pages/Demo/Forms/IpAddressFieldPage.razor`.
- Menu: grupo `Forms` em `RoyalCode.Razor.Docs.Client/ConfigureMenu.cs`.
- Estrutura mínima da página:
  - introdução curta;
  - seção `Básico`;
  - seção `Valor Inicial`;
  - seção `Validação em Formulário`;
  - seção `Estados`;
  - seção `Colagem e Responsividade`.

## Riscos e Questões em Aberto

- Ponto em aberto controlado: decidir se a publicação do valor ocorre por segmento (`oninput`) ou apenas quando o endereço fica completo; a spec recomenda publicar apenas quando houver IPv4 completo ou limpeza total.
- Ponto em aberto controlado: definir se retrocesso entre segmentos vazios acontece por `Backspace` e seta para a esquerda já no primeiro release; a recomendação é cobrir ao menos `Backspace` previsível.
- Trade-off assumido: focar apenas em IPv4 mantém a API pequena e evita um desenho frágil para IPv6.
- Trade-off assumido: não expor eventos por octeto nem opções extensas de máscara no primeiro release.

## Validação Esperada

- `dotnet build` do pacote `RoyalCode.Razor.Forms`.
- `dotnet build` do host `RoyalCode.Razor.Docs.Client`.
- Testes automatizados do pacote de Forms, se existente, ou do novo projeto de testes criado na implementação.
- Validação manual do showcase em `/demo/forms/ip-address-field`.
- Não há impacto obrigatório imediato em `ui-map.md` e `ui-plan.md` durante a criação da spec; eventual atualização fica para a implementação concluída.
