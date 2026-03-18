# Requirements — IpAddressField

## Metadados

| Campo | Valor |
|---|---|
| Status | Rascunho |
| Prioridade | `P3` |
| Fase do plano | `F2.x (backlog derivado de Expansão de Inputs Concretos)` |
| UI Pattern | `UIP-INPUT-FORM_FIELD_GROUP` |
| Roadmap | `R2 › IpAddressField` |
| Pacote sugerido | `RoyalCode.Razor.Forms` |
| Showcase inicial | `/demo/forms/ip-address-field` |
| Guides aplicados | `project-structure`, `styles-and-css`, `component-anatomy`, `form-components`, `showcases-and-docs`, `spec-execution-and-delivery`, `form-components-lightweight`, `component-composition-and-dependencies`, `cross-cutting-component-decisions` |

## Objetivo

Entregar um campo especializado para captura de endereços IPv4 com UX melhor que um `TextField` genérico, reduzindo erros de digitação, melhorando navegação por teclado e mantendo integração nativa com `EditForm`, validação e layout padrão de formulários da biblioteca.

## Escopo

- `IpAddressField` como componente público único.
- Captura de IPv4 em quatro segmentos visuais.
- Binding tipado para `System.Net.IPAddress?`.
- Suporte a digitação segmentada, colagem do endereço completo e limpeza total do valor.
- Integração com `FieldGroup`, mensagens de erro, `Information`, addons e `Size`.
- Acessibilidade básica para leitor de tela e navegação por teclado.
- Showcase funcional no host atual de docs.

## Fora de Escopo

- Suporte a IPv6 no primeiro release.
- Máscara textual livre em campo único.
- Resolução DNS, validação de reachability ou lookup de rede.
- Autoformatação CIDR, máscara de sub-rede ou portas.
- Variações visuais por `Style: Themes`.
- Dependência de JavaScript obrigatória para o comportamento principal.

## Casos de Uso

1. Preencher um IPv4 em formulário administrativo ou de configuração de infraestrutura.
2. Editar um endereço já existente em `EditForm`, preservando validação e mensagens inline.
3. Colar um valor completo como `192.168.0.10` sem precisar navegar manualmente entre octetos.

## Requisitos Funcionais

- O componente deve aceitar `@bind-Value` com `IPAddress?` e refletir corretamente mudanças externas no valor.
- O valor só deve ser considerado válido quando os quatro octetos estiverem presentes e dentro do intervalo `0..255`.
- O componente deve permitir estado vazio quando `Value` for `null` ou quando o utilizador limpar todos os segmentos.
- O componente deve distribuir automaticamente um valor colado no formato IPv4 pelos quatro segmentos.
- O componente deve avançar o foco de forma previsível entre segmentos durante a digitação e permitir retorno com teclado quando fizer sentido.
- O componente deve aceitar `AdditionalClasses` e `AdditionalAttributes` no elemento raiz.
- O componente deve reutilizar a infraestrutura de formulários existente (`FieldBase<TValue>` e `FieldGroup`).
- O componente não deve suportar `Style: Themes` no primeiro release, porque campos de formulário da base atual não expõem variantes temáticas públicas e o comportamento esperado é semântico, não decorativo.
- O componente deve suportar `Size: Sizes`, reaproveitando a escala já aplicada por `FieldGroup` e inputs do pacote.
- O componente deve ser classificado como componente especializado sobre a infraestrutura de forms existente, e não como novo primitivo base.
- A spec deve registrar explicitamente que não há componente-base ausente obrigatório antes deste release; uma futura abstração de campo segmentado só deve nascer se outros componentes semelhantes aparecerem.
- O contrato visual deve ser sustentado por tokens já existentes de `yasamen.css`, em especial breakpoints, escala de espaçamento, tipografia base e cores semânticas de foco e erro.

## Acessibilidade e Responsividade

- O conjunto dos quatro segmentos deve ser apresentado como um único campo lógico, com label e mensagem de erro compartilhadas.
- O contêiner do controle deve usar associação semântica com o label e permitir leitura clara por leitor de tela.
- Cada segmento deve expor rótulo acessível derivado da posição do octeto, sem depender apenas do placeholder visual.
- O fluxo por teclado deve ser previsível para `Tab`, `Shift+Tab`, setas quando aplicável e retrocesso entre segmentos vazios.
- Em Mobile, os segmentos devem manter largura legível, evitar quebra visual indevida e favorecer teclado numérico.

## Showcase Obrigatório

- Criar a página `RoyalCode.Razor.Docs.Client/Pages/Demo/Forms/IpAddressFieldPage.razor`.
- Registrar a rota `/demo/forms/ip-address-field`.
- Adicionar item em `ConfigureMenu.cs` dentro do grupo `Forms`.
- Cobrir no showcase:
  - uso básico;
  - valor inicial vindo do modelo;
  - integração com `EditForm` e validação;
  - estado desabilitado e somente leitura;
  - colagem de endereço completo;
  - contêiner estreito para validar responsividade.

## Critérios de Aceite

- [ ] O componente permite capturar IPv4 com quatro segmentos e publicar `IPAddress?` válido ao concluir a edição.
- [ ] O componente mantém integração coerente com `FieldGroup`, mensagens de erro, `Information`, addons e `EditForm`.
- [ ] A colagem de um IPv4 completo funciona sem parsing manual pelo consumidor.
- [ ] O contrato visual usa classes públicas `ya-ip-address-field*` em `RoyalCode.Razor.Styles`.
- [ ] Não é criado `*.razor.css` novo.
- [ ] A decisão de não suportar `Style: Themes` foi documentada.
- [ ] A decisão de suportar `Size: Sizes` foi documentada.
- [ ] A decisão composicional e a ausência de pré-requisito obrigatório foram documentadas.
- [ ] Há showcase funcional em `RoyalCode.Razor.Docs.Client`.
- [ ] Há testes cobrindo parsing, colagem, limpeza, valor externo e navegação básica por teclado.

## Critérios de Conclusão

- [ ] Existe `delivery.md` preenchido ao final da implementação.
- [ ] A implementação foi comparada com requirements, design e guides.
- [ ] O status final da spec foi atualizado com evidência.


