# Tasks — ButtonGroup

## Preparação

- [x] Validar a spec com `ui-plan.md`, `ui-map.md` e `components-plan-list.md`.
- [x] Confirmar `RoyalCode.Razor.Buttons` como projeto alvo, sem pacote novo.
- [x] Confirmar `ButtonGroup` como primitivo base do domínio de ações.
- [x] Confirmar que o contrato visual só garante filhos diretos `Button` e `IconButton`.
- [x] Confirmar a decisão de suportar `Style: Themes` como default herdado.
- [x] Confirmar o fallback de `Themes.Default` como “não impor tema”.
- [x] Confirmar a decisão de suportar `Size: Sizes` como default herdado.
- [x] Confirmar o fallback de `Sizes.Default` como “não impor tamanho”.
- [x] Confirmar a decisão de não suportar `Outline` no nível do grupo no primeiro release.
- [x] Confirmar os tokens de `yasamen.css` que sustentam bordas, raios, foco e transição.

## Implementação

- [x] Criar `ButtonGroup` e `ButtonGroupOrientation`.
- [x] Criar `ButtonGroupContext` em `Internal/Buttons`.
- [x] Renderizar o contêiner raiz com `role="group"`.
- [x] Implementar `AriaLabel`, `AdditionalClasses` e `AdditionalAttributes` no elemento raiz.
- [x] Atualizar `Button` para consumir defaults herdados de `Style`, `Size` e `Disabled`.
- [x] Atualizar `IconButton` para consumir defaults herdados de `Style`, `Size` e `Disabled`.
- [x] Garantir que `Style` e `Size` explícitos do filho sobrescrevam o grupo.
- [x] Garantir que `Disabled` do grupo desabilite todos os filhos suportados.
- [x] Cobrir orientação horizontal e vertical.
- [x] Registrar em comentários e docs a limitação de wrappers intermediários.

## Estilos

- [x] Criar `RoyalCode.Razor.Styles/wwwroot/css/components/btn-group.css`.
- [x] Registrar o `@import` em `RoyalCode.Razor.Styles/wwwroot/yasamen.css`.
- [x] Cobrir junção horizontal entre `Button` e `IconButton`.
- [x] Cobrir junção vertical entre `Button` e `IconButton`.
- [x] Garantir foco visível sem recorte por bordas sobrepostas.
- [x] Cobrir o estado `ya-btn-group-disabled`.
- [x] Usar tokens existentes de `yasamen.css` para raio, transição e contraste.

## Testes

- [x] Criar `ButtonGroupTests.cs` em `RoyalCode.Razor.Buttons.Tests`.
- [x] Cobrir renderização mínima com `role="group"` e classes raiz.
- [x] Cobrir herança de `Style` para `Button`.
- [x] Cobrir herança de `Size` para `IconButton`.
- [x] Cobrir `Disabled` em cascata.
- [x] Cobrir sobrescrita por filho com `Style` e `Size` explícitos.
- [x] Cobrir orientação vertical.
- [x] Cobrir mistura de `Button` com `IconButton`.

## Validação Humana

- [x] Executar os testes humanos previstos no showcase e nos ajustes finais do `ButtonGroup`.
- [x] Registrar em `delivery.md` o aceite explícito do humano; a spec só fecha após esse ok.

## Documentação

- [x] Criar a página de showcase em `RoyalCode.Razor.Docs.Client/Pages/Demo/Buttons/ButtonGroupPage.razor`.
- [x] Registrar a rota e o item correspondente em `ConfigureMenu.cs`.
- [x] Cobrir cenário básico, defaults herdados, mistura com `IconButton`, orientação vertical, estados e contêiner estreito.
- [x] Documentar explicitamente o uso recomendado de `AriaLabel`, especialmente para grupos com ícones.
- [x] Evitar ampliar a dívida das rotas legadas de botões fora de `/demo/...`.
- [x] Atualizar `.ai/roadmap/components-plan-list.md` quando a implementação for concluída.
- [x] Avaliar `ui-map.md` e `ui-plan.md`; nenhum update foi necessário porque `ButtonGroup` permanece um primitivo transversal e não altera a cobertura dos `UIP-*` ativos.

## Encerramento

- [x] Comparar a implementação com `requirements.md`, `design.md` e os guides aplicados.
- [x] Executar build, testes e validações manuais previstos.
- [x] Fazer revisão crítica do próprio diff.
- [x] Preencher `delivery.md`.
- [x] Atualizar o status final da spec.
- [x] Fechar ou justificar tasks remanescentes.
