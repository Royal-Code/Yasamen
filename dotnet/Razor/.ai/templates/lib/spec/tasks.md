# Tasks - <Nome do Componente>

## Preparação

- [ ] Validar a spec com `ui-plan.md`, `ui-map.md` e `components-plan-list.md` do roadmap.
- [ ] Confirmar pacote, namespaces e referências diretas.
- [ ] Confirmar se o pacote alvo já existe ou se precisará ser criado.
- [ ] Confirmar CSS público e nomes de classes `ya-*`.
- [ ] Decidir se o componente suporta `Style: Themes` ou justificar a ausência.
- [ ] Decidir se o componente suporta `Size: Sizes` ou justificar a ausência.
- [ ] Confirmar fallback de tema e estratégia de escala, quando aplicável.
- [ ] Verificar se existe componente-base ou dependência composicional que precise vir antes.
- [ ] Confirmar quais tokens de `yasamen.css` sustentam o componente.

## Implementação

- [ ] Criar ou ajustar o projeto alvo; se for pacote novo, seguir `.ai/instructions/expand/create-library-project.md`.
- [ ] Implementar os componentes públicos.
- [ ] Implementar helpers e tipos internos necessários.
- [ ] Garantir `AdditionalClasses` e `AdditionalAttributes`.
- [ ] Garantir estados, eventos e slots da spec.
- [ ] Reutilizar componentes existentes quando isso fizer parte do desenho aprovado.

## Estilos

- [ ] Criar o arquivo CSS em `RoyalCode.Razor.Styles/wwwroot/css/...`.
- [ ] Registrar o `@import` em `wwwroot/yasamen.css`.
- [ ] Cobrir estados visuais, responsividade e acessibilidade.
- [ ] Cobrir variações de tema, quando fizerem parte da spec.
- [ ] Cobrir variações de tamanho, quando fizerem parte da spec.
- [ ] Usar tokens de `yasamen.css` de forma coerente para cor, espaçamento, tipografia e breakpoints.

## Testes

- [ ] Criar ou atualizar testes unitários e/ou bUnit.
- [ ] Cobrir fluxo feliz, estados de borda e regressões prováveis.
- [ ] Cobrir a decisão estrutural mais arriscada da composição, quando aplicável.

## Validação Humana

- [ ] Executar os testes humanos previstos no componente ou showcase com o responsável pela validação.
- [ ] Registrar em `delivery.md` a data, o escopo e o aceite explícito do humano; sem isso, a spec fica em `Aguardando validação humana`.

## Documentação

- [ ] Criar a página de showcase em `RoyalCode.Razor.Docs.Client/Pages/Demo/...`.
- [ ] Registrar a rota e o item correspondente em `ConfigureMenu.cs`.
- [ ] Cobrir cenário básico, variações, estados e composição.
- [ ] Documentar API pública e exemplos de uso.
- [ ] Atualizar `ui-map.md` e `ui-plan.md` se a entrega mudar a cobertura.

## Encerramento

- [ ] Comparar a implementação com `requirements.md`, `design.md` e os guides aplicados.
- [ ] Executar build, testes e validações manuais previstos.
- [ ] Fazer revisão crítica do próprio diff.
- [ ] Preencher `delivery.md`.
- [ ] Atualizar o status final da spec.
- [ ] Fechar ou justificar tasks remanescentes.

