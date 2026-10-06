# Protocolo: Compatibilidade de API

## Regras

Regras que a IA deve seguir estritamente:
- Aplicar a toda mudança em: export de `src/lib/index.ts` ou de `<dominio>/index.ts`, nome ou tipo de prop, valor de enum (`Themes`, `Sizes`, `Positions`), nome de classe `ya-*`, token de `@theme`, utilitário de `utilities.css`, `exports` do `package.json`.
- Aplicar na dúvida.
- Tratar como quebra: remoção, renomeação, mudança de tipo, mudança de padrão e mudança de comportamento observável.
- Exigir decisão humana para toda quebra (`kernel.rules.md`, seção `Decisão humana`).
- Não renomear nem remover item público para facilitar a implementação.
- Verificar o uso no código antes de declarar um item sem consumidor.

## Arquivos a ler

- `src/lib/index.ts` e `<dominio>/index.ts`: obter a superfície pública.
- `src/lib/styles/css/components/*.css` e `<nome>-classes.ts`: obter as classes públicas.
- `package.json`: obter `exports` e `version`.
- `src/demo/` e `src/stories/`: obter consumidores internos.
- `dotnet/Razor` equivalente: conferir paridade.

## 1. Mapear

1. Listar cada item público alterado.
2. Buscar os consumidores do item no repositório (`src/`, `src/demo/`, `src/stories/`).
3. Classificar cada alteração: aditiva, quebra.

### GATE AC.1

Use as regras de GATE de `kernel.rules.md` para validar os itens:
- todo item alterado listado;
- consumidores buscados e listados;
- classificação definida.

## 2. Decidir

Somente após gate `AC.1` satisfeito.

1. Escolher a forma da mudança para cada quebra, nesta ordem de preferência:
   - prop ou classe nova, mantendo a antiga;
   - alias com aviso de depreciação em JSDoc (`@deprecated`);
   - remoção com versão `major`.
2. Registrar `Q<n>` com as opções e a recomendação. Perguntar ao humano.
3. Registrar `DC<n>` com a resposta.

### GATE AC.2

Use as regras de GATE de `kernel.rules.md` para validar os itens:
- humano respondeu a forma de cada quebra;
- `DC<n>` registrada.

## 3. Executar

Somente após gate `AC.2` satisfeito.

1. Atualizar consumidores internos (demo, stories, outros componentes).
2. Escrever teste que cobre o item alterado e o item antigo mantido ou depreciado.
3. Registrar a alteração em `Compatibilidade` de `ds-{slug}.md`.
4. Registrar a mudança em `Changelog` de `hist-{slug}.md`.
5. Executar `bun run test`, `bun run build` e `bun run lint`.
