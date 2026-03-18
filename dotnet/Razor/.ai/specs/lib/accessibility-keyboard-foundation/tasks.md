# Tasks — Accessibility Keyboard Foundation

## Preparação

- [ ] Validar a spec com `ui-plan.md`, `ui-map.md` e os guides aplicados.
- [ ] Levantar os componentes âncora da primeira onda.
- [ ] Definir a matriz mínima por família de componente.
- [ ] Confirmar quais projetos de teste já podem ser aproveitados e onde faltará cobertura nova.

## Implementação

- [ ] Ajustar `Pagination` para servir como referência de navegação semântica e teclado no domínio de navigation.
- [ ] Ajustar `Modal` e `OffCanvas` para foco e escape coerentes no domínio de overlays.
- [ ] Revisar `Drop` como caso de comportamento local com interop e teclado mínimo viável.
- [ ] Revisar `TextField` e infraestrutura base para label, erro, foco visível e estado inválido coerentes.
- [ ] Ajustar botões ou gatilhos que hoje dependam de semântica frágil nos casos cobertos.

## Estilos

- [ ] Definir ou ajustar estados públicos de foco visível em `RoyalCode.Razor.Styles`.
- [ ] Registrar os imports necessários em `wwwroot/yasamen.css`, se houver novos arquivos.
- [ ] Garantir que foco visível e estados acessíveis façam parte do contrato visual público dos componentes cobertos.

## Testes

- [ ] Expandir testes de `Pagination` para cobrir a matriz definida.
- [ ] Criar ou atualizar testes para `Modal` e `OffCanvas` nos comportamentos críticos de teclado e semântica.
- [ ] Cobrir pelo menos um caso de formulário e um caso de trigger interativo com teste automatizado, quando viável.
- [ ] Registrar limitações de teste que ficarem fora do primeiro ciclo.

## Documentação

- [ ] Atualizar os showcases existentes dos componentes tocados.
- [ ] Garantir que as páginas afetadas cubram cenários mínimos de acessibilidade e teclado.
- [ ] Registrar a matriz aplicada e os componentes cobertos em `delivery.md`.
- [ ] Definir, ao final, se já existe massa crítica para abrir um guide futuro de `accessibility-keyboard`.

## Encerramento

- [ ] Comparar a implementação com `requirements.md`, `design.md` e os guides aplicados.
- [ ] Executar build, testes e validações manuais previstos.
- [ ] Fazer revisão crítica do próprio diff.
- [ ] Preencher `delivery.md`.
- [ ] Atualizar o status final da spec.
- [ ] Fechar ou justificar tasks remanescentes.

