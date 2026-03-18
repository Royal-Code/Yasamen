# Tasks — IpAddressField

## Preparação

- [ ] Validar a spec com `ui-plan.md`, `ui-map.md` e `components-plan-list.md`.
- [ ] Confirmar `RoyalCode.Razor.Forms` como projeto alvo.
- [ ] Confirmar que o componente seguirá sobre `FieldBase<TValue>` e `FieldGroup`, sem depender de `InputFieldBase<TValue>`.
- [ ] Confirmar a decisão de não suportar `Style: Themes` no primeiro release.
- [ ] Confirmar a decisão de suportar `Size: Sizes` via escala de `ya-field-*`.
- [ ] Verificar se algum helper interno de segmentação precisa ser extraído para `Internal/Forms`.
- [ ] Confirmar os tokens de `yasamen.css` que sustentam foco, erro, contraste e espaçamento.

## Implementação

- [ ] Criar `IpAddressField` com quatro segmentos visuais e valor tipado `IPAddress?`.
- [ ] Implementar sincronização entre valor externo e segmentos internos.
- [ ] Implementar parsing de IPv4 válido com intervalo `0..255` por octeto.
- [ ] Implementar limpeza total para `null`.
- [ ] Implementar colagem de endereço completo no formato `a.b.c.d`.
- [ ] Implementar navegação básica entre segmentos sem JavaScript obrigatório.
- [ ] Garantir `AdditionalClasses` e `AdditionalAttributes` no elemento raiz.
- [ ] Preservar integração com `Information`, erro, addons e `FooterAction` via `FieldGroup`.

## Estilos

- [ ] Criar `RoyalCode.Razor.Styles/wwwroot/css/forms/ipaddressfield.css`.
- [ ] Registrar o `@import` em `RoyalCode.Razor.Styles/wwwroot/yasamen.css`.
- [ ] Cobrir estados visuais de foco, inválido, desabilitado, somente leitura, completo e incompleto.
- [ ] Cobrir variações de tamanho suportadas.
- [ ] Usar tokens existentes de `yasamen.css` para cor, espaçamento, tipografia e breakpoints.

## Testes

- [ ] Criar ou ajustar projeto de testes para Forms.
- [ ] Cobrir valor inicial externo e sincronização reversa.
- [ ] Cobrir parsing válido e rejeição de valores inválidos.
- [ ] Cobrir colagem de IPv4 completo.
- [ ] Cobrir limpeza do campo para `null`.
- [ ] Cobrir integração com `EditForm` e erro de validação.

## Documentação

- [ ] Criar a página de showcase em `RoyalCode.Razor.Docs.Client/Pages/Demo/Forms/IpAddressFieldPage.razor`.
- [ ] Registrar a rota e o item correspondente em `ConfigureMenu.cs`.
- [ ] Cobrir cenário básico, valor inicial, validação, estados e responsividade.
- [ ] Documentar exemplos de uso público com `@bind-Value`.
- [ ] Atualizar `ui-map.md` e `ui-plan.md` se a implementação concluída alterar a cobertura documentada.

## Encerramento

- [ ] Comparar a implementação com `requirements.md`, `design.md` e os guides aplicados.
- [ ] Executar build, testes e validações manuais previstos.
- [ ] Fazer revisão crítica do próprio diff.
- [ ] Preencher `delivery.md`.
- [ ] Atualizar o status final da spec.
- [ ] Fechar ou justificar tasks remanescentes.
