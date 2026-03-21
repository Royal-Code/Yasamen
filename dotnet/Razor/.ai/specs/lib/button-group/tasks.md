# Tasks — ButtonGroup

## Preparação

- [ ] Validar a spec com `ui-plan.md`, `ui-map.md` e `components-plan-list.md`.
- [ ] Confirmar `RoyalCode.Razor.Buttons` como projeto alvo, sem pacote novo.
- [ ] Confirmar `ButtonGroup` como primitivo base do domínio de ações.
- [ ] Confirmar que o contrato visual só garante filhos diretos `Button` e `IconButton`.
- [ ] Confirmar a decisão de suportar `Style: Themes` como default herdado.
- [ ] Confirmar o fallback de `Themes.Default` como “não impor tema”.
- [ ] Confirmar a decisão de suportar `Size: Sizes` como default herdado.
- [ ] Confirmar o fallback de `Sizes.Default` como “não impor tamanho”.
- [ ] Confirmar a decisão de não suportar `Outline` no nível do grupo no primeiro release.
- [ ] Confirmar os tokens de `yasamen.css` que sustentam bordas, raios, foco e transição.

## Implementação

- [ ] Criar `ButtonGroup` e `ButtonGroupOrientation`.
- [ ] Criar `ButtonGroupContext` em `Internal/Buttons`.
- [ ] Renderizar o contêiner raiz com `role="group"`.
- [ ] Implementar `AriaLabel`, `AdditionalClasses` e `AdditionalAttributes` no elemento raiz.
- [ ] Atualizar `Button` para consumir defaults herdados de `Style`, `Size` e `Disabled`.
- [ ] Atualizar `IconButton` para consumir defaults herdados de `Style`, `Size` e `Disabled`.
- [ ] Garantir que `Style` e `Size` explícitos do filho sobrescrevam o grupo.
- [ ] Garantir que `Disabled` do grupo desabilite todos os filhos suportados.
- [ ] Cobrir orientação horizontal e vertical.
- [ ] Registrar em comentários e docs a limitação de wrappers intermediários.

## Estilos

- [ ] Criar `RoyalCode.Razor.Styles/wwwroot/css/components/btn-group.css`.
- [ ] Registrar o `@import` em `RoyalCode.Razor.Styles/wwwroot/yasamen.css`.
- [ ] Cobrir junção horizontal entre `Button` e `IconButton`.
- [ ] Cobrir junção vertical entre `Button` e `IconButton`.
- [ ] Garantir foco visível sem recorte por bordas sobrepostas.
- [ ] Cobrir o estado `ya-btn-group-disabled`.
- [ ] Usar tokens existentes de `yasamen.css` para raio, transição e contraste.

## Testes

- [ ] Criar `ButtonGroupTests.cs` em `RoyalCode.Razor.Buttons.Tests`.
- [ ] Cobrir renderização mínima com `role="group"` e classes raiz.
- [ ] Cobrir herança de `Style` para `Button`.
- [ ] Cobrir herança de `Size` para `IconButton`.
- [ ] Cobrir `Disabled` em cascata.
- [ ] Cobrir sobrescrita por filho com `Style` e `Size` explícitos.
- [ ] Cobrir orientação vertical.
- [ ] Cobrir mistura de `Button` com `IconButton`.

## Documentação

- [ ] Criar a página de showcase em `RoyalCode.Razor.Docs.Client/Pages/Demo/Buttons/ButtonGroupPage.razor`.
- [ ] Registrar a rota e o item correspondente em `ConfigureMenu.cs`.
- [ ] Cobrir cenário básico, defaults herdados, mistura com `IconButton`, orientação vertical, estados e contêiner estreito.
- [ ] Documentar explicitamente o uso recomendado de `AriaLabel`, especialmente para grupos com ícones.
- [ ] Evitar ampliar a dívida das rotas legadas de botões fora de `/demo/...`.
- [ ] Atualizar `.ai/roadmap/components-plan-list.md` quando a implementação for concluída.
- [ ] Atualizar `ui-map.md` e `ui-plan.md` apenas se a implementação realmente mudar a leitura de cobertura do backlog.

## Encerramento

- [ ] Comparar a implementação com `requirements.md`, `design.md` e os guides aplicados.
- [ ] Executar build, testes e validações manuais previstos.
- [ ] Fazer revisão crítica do próprio diff.
- [ ] Preencher `delivery.md`.
- [ ] Atualizar o status final da spec.
- [ ] Fechar ou justificar tasks remanescentes.
