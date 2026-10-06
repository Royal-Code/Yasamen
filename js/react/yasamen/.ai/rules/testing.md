# Testes e QA

Stack: Vitest, Testing Library, jsdom. `vitest.setup.ts` roda `cleanup()` após cada teste. Comando: `bun run test`.

## Regra central

Regras que a IA deve seguir estritamente:
- Considerar teste verde sem evidência até vê-lo falhar.
- Reintroduzir o defeito que o teste deveria pegar. Confirmar que o teste falha. Restaurar o código.
- Comparar o número de testes que caíram com o número que deveria cair. Quando não bater, corrigir o teste, não o código.
- Injetar a falha em um lado só. Alterar constante usada na ida e na volta não quebra nada.
- Declarar, antes de escrever o `expect`, qual falha ele pega. Descartar o teste que não tem resposta.
- Desconfiar do teste que passa de primeira. Verificar primeiro se o laço ou a consulta retornou vazio.
- Registrar em `test-{slug}.md` a falha que pega e a prova de falha de cada `TC<n>`.

## Armadilhas

| # | Armadilha | Regra |
|---|---|---|
| 1 | Verificar a própria conta | Assertar o DOM renderizado contra literal. Não recalcular o esperado com a função de `*-classes.ts`. |
| 2 | Snapshot de elemento animado | Congelar com `vi.useFakeTimers()` ou assertar atributo/classe específico. Não comparar snapshots de `Ripple` ou de transição. |
| 3 | Andaime fornece o efeito | Renderizar duas versões que diferem somente na prop testada. Assertar a diferença. |
| 4 | Fase escondida por transição | Disparar `fireEvent.transitionEnd` e assertar cada fase. jsdom não dispara `transitionend`. |
| 5 | Coleção sem tamanho | Assertar `length` em toda asserção sobre coleção. `every` sobre lista vazia passa. |
| 6 | Atalho sobre o caminho real | Interagir por `userEvent` ou `fireEvent` no elemento. Não chamar handler nem setter direto. |
| 7 | Sintoma que o modelo não produz | Aplicar a regra central: declarar a falha que o teste pega. |
| 8 | Ler estado em vez da volta completa | Em componente controlado e não controlado, montar, interagir, desmontar, montar e ler. |
| 9 | Amostrar na fronteira | Testar primeiro e último `Sizes`, lista vazia, lista com um item, ID duplicado. |
| 10 | Medir uma superfície só | Assertar classe aplicada e estilo computado quando a spec exigir efeito visual (camada L2). |
| 11 | Compilar não é usar | Renderizar o componente. `bun run build` verde não prova funcionamento nem export. |
| 12 | Escrever e ler no mesmo passo | Aguardar com `await waitFor` ou `act` antes de ler o resultado. |
| 13 | Classe presente não prova CSS | Conferir que cada classe de `*-classes.ts` existe no `.css` do componente. |
| 14 | Cor não prova forma | Medir forma (dimensão, posição) quando o requisito nomear forma. Cor serve de diagnóstico. |

## Escrita do teste

Regras que a IA deve seguir estritamente:
- Criar um arquivo `__tests__/<Nome>.spec.tsx` por componente.
- Isolar em arquivo próprio o cenário que altera estado global (navigator, registry de ícones, timers).
- Consultar por papel e rótulo (`getByRole`, `getByLabelText`). Usar `data-testid` somente sem alternativa.
- Escrever nome do teste como comportamento observável.
- Fazer a mensagem de falha trazer valor obtido e valor esperado.
- Cobrir por componente: renderização base, cada prop pública, cada tema e tamanho usados, estados `disabled`/vazio/erro, evento, `navigateTo` quando houver, teclado quando houver.
- Assertar ARIA e foco quando a spec declarar acessibilidade.
- Usar fake timers quando houver timer, e restaurar em `afterEach`.

## Falha por console

Regras que a IA deve seguir estritamente:
- Falhar o teste quando `console.error` ou `console.warn` for chamado (warning do React, `act`, `key`).
- Configurar o gancho em `vitest.setup.ts` quando a spec incluir a tarefa de QA correspondente.
- Verificar a ausência de erro de console ao final de cada teste de interação.

## Camadas

| Camada | Ferramenta | Prova |
|---|---|---|
| L1 | Vitest + jsdom | Lógica, DOM, eventos, ARIA |
| L2 | Vitest browser + Playwright | CSS real, estilo computado, layout, foco |
| L3 | Storybook e demo | Verificação visual, `play` functions |

Limites de L1 (jsdom):
- Não processa Tailwind nem o CSS de `yasamen.css`.
- Não calcula layout.
- Não dispara `transitionend`.
- Não renderiza foco visual.

Regras que a IA deve seguir estritamente:
- Declarar a camada de cada `TC<n>`.
- Não aceitar teste L1 como prova de efeito visual, de posição ou de CSS.
- Marcar `V<n>` de efeito visual como verificação humana na demo ou no Storybook quando L2 não estiver configurado.
- Tratar screenshot como diagnóstico. Não usar como critério de aceite.
- Reportar falha de captura sem derrubar a suíte.

## Detalhe e relatório

Regras que a IA deve seguir estritamente:
- Registrar em `Resultado das tarefas` o comando, a quantidade de testes e as falhas.
- Reportar suíte interrompida como falha, não como ausência de falhas.
- Encerrar processo de Vite, Storybook ou Playwright pendurado pelo processo, não pelo terminal.

## Critério de pronto de um teste

- [ ] A falha que o teste pega está declarada.
- [ ] O defeito reintroduzido derrubou o teste.
- [ ] O número de testes que caíram bateu com o esperado.
- [ ] Toda asserção sobre coleção assere o tamanho.
- [ ] A interação usa o caminho real do usuário.
- [ ] A mensagem de falha traz valores.
- [ ] Nenhum `console.error` ou `console.warn` no teste.
