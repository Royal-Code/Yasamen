# Kernel — regras globais

Precedência: `kernel.rules.md` > protocolo > template. Protocolo e template não repetem estas regras; referenciam por nome de seção.

## Decisão humana

Regras que a IA deve seguir estritamente:
- Não decidir sem referência verificável ou confirmação humana.
- Não inventar requisito para evitar pergunta.
- Exigir confirmação humana em decisão material: API pública, props, acessibilidade, temas, tamanhos, nomes `ya-*`, tokens `@theme`, paridade com o Razor, quebra de compatibilidade, escopo, custo de manutenção.
- Tratar resposta parcial como premissa pendente. Limitar o artefato ao que foi confirmado.
- Fazer pergunta aberta ao humano na conversa. Registrar no arquivo não basta.
- Nunca tratar ausência de resposta como aprovação.
- Agrupar perguntas por tema. Fazer de três a cinco por rodada.
- Nunca apresentar opção padrão como assumida.

## Ações só com pedido explícito

Regras que a IA deve seguir estritamente:
- Executar `git commit`, `git push`, tag, publicação de pacote e release somente quando o humano pedir.
- Executar o modo revisionado somente quando o humano pedir `revisionado`.
- Alterar `package.json` (scripts, exports, dependências) somente com justificativa técnica aprovada.
- Alterar valores existentes de `@theme` somente com decisão confirmada.

## Idioma e escrita de artefato

Regras que a IA deve seguir estritamente:
- Escrever em português com acentuação correta.
- Salvar arquivos em UTF-8.
- Escrever artefato sem prosa, sem justificativa e sem registro de raciocínio.
- Usar ordem direta, campo, tabela de até quatro colunas ou bullet com rótulo em negrito.
- Escrever no máximo dois fatos por linha de lista.
- Preservar comentários e documentação existentes não relacionados à mudança.

## Identificadores

Prefixos, únicos entre todos os arquivos de uma spec:

| Prefixo | Elemento |
|---|---|
| `DC` | Decisão confirmada |
| `Q` | Questão |
| `CA` | Critério de aceite |
| `T` | Tarefa |
| `R` | Risco |
| `V` | Validação |
| `TC` | Caso de teste |

Regras que a IA deve seguir estritamente:
- Numerar em sequência a partir de `1`. Nunca reutilizar nem renumerar ID existente.
- Ler o campo `Próximos IDs` de `dec-{slug}.md` antes de criar ID. Atualizar o campo ao criar.
- Relacionar itens por ID. Não copiar o texto.
- Manter questão respondida como `[x]`. Registrar a decisão resultante como novo `DC<n>` com a `Q<n>` de origem.

## Status

| Artefato | Valores |
|---|---|
| Spec | `Draft`, `Approved`, `InProgress`, `Completed`, `Superseded` |
| Tarefa | `[ ]` não iniciada, `[-]` parcial ou bloqueada, `[x]` concluída e validada |
| Revisão | `Aberta`, `Avaliada` |

Regras que a IA deve seguir estritamente:
- Marcar `[x]` somente depois de concluir e validar a tarefa.
- Sincronizar todo status de spec com `.ai/specs/specs.index.md` na mesma operação.
- Marcar `Superseded` em vez de sobrescrever o histórico quando a direção mudar.

## Gate

Regras que a IA deve seguir estritamente:
- Verificar cada item do gate por leitura do arquivo ou da conversa. Estado interno não vale.
- Item que depende do humano só é satisfeito com `humano respondeu <o quê>`.
- Parar no primeiro item não satisfeito. Informar ao humano qual item falhou.
- Não iniciar a seção seguinte antes de o gate ser satisfeito.
- Em seção de loop, encerrar a iteração somente com o gate dela satisfeito.

## Validação de código

Comandos, na raiz de `js/react/yasamen/`:

| Ação | Comando |
|---|---|
| Testes | `bun run test` |
| Build da lib | `bun run build` |
| Lint | `bun run lint` |
| Build da demo | `bun run build:demo` |

Regras que a IA deve seguir estritamente:
- Rodar `test`, `build` e `lint` antes de declarar tarefa de código concluída.
- Rodar `build:demo` quando a spec tocar a demo.
- Não declarar `[x]` com comando falhando.
- Registrar comando e resultado em `Resultado das tarefas` de `tasks-{slug}.md`.

## Referências

Regras que a IA deve seguir estritamente:
- Ler `.ai/rules/` antes de escrever código. Seguir `.ai/rules/testing.md` ao escrever teste.
- Referenciar arquivo do repositório pelo caminho a partir de `js/react/yasamen/`.
- Verificar que o caminho existe antes de citá-lo.
- Marcar item como `N/A` e perguntar ao humano quando uma referência obrigatória não existir.
