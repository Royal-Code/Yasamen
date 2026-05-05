# Protocolo: Corporate Guides

## Objetivo

Descobrir, selecionar e gerar guides corporativos que documentem decisões técnicas recorrentes do projeto/empresa. Estes guides serão usados pela skill screen-designer para respeitar regras corporativas ao gerar telas.

Esta etapa é opcional: só executa quando acionada pelo humano ou quando a skill detecta valor claro.

---

## INSTRUÇÕES DE EXECUÇÃO

[INSTRUÇÃO] Reler o kernel, workflow e este protocolo antes de iniciar.

[INSTRUÇÃO] Executar os passos na ordem.

### Passo 1: Decisão de entrada

[INSTRUÇÃO] A etapa executa quando:
- O humano solicita explicitamente.
- A skill detecta padrões recorrentes nos fontes que mereceriam guide e pede confirmação.
- Há políticas corporativas relevantes identificadas durante etapas anteriores.

Se nenhuma condição se aplicar:
- Registrar `stages.corporate_guides: skipped` no state.
- Avançar direto para `finalize`.

### Passo 2: Busca activa nos fontes

[INSTRUÇÃO] Explorar os seguintes eixos para identificar guides candidatos. São orientação de busca, não catálogo fixo.

**Eixos universais (sempre procurar evidência):**
- Arquitetura e organização de código (camadas, módulos, imports, public API).
- Integração com APIs/backend (cliente HTTP, hooks, services, mappers, cache).
- Autenticação e autorização (auth provider, tokens, proteção de rotas, permissões).
- Feedback e tratamento de erro (toast, alert, error boundaries, estados de erro).

**Eixos condicionais por tecnologia:**
- Web/SPA: roteamento, state management, SSR/SSG, PWA, formulários complexos.
- React: hooks patterns, providers, suspense, composition, bootstrap.
- Angular: modules/standalone, signals, DI, guards, interceptors.
- Vue: composables, stores (Pinia), router guards, provide/inject.
- Mobile: navegação nativa, deep linking, offline first, permissions.
- Design system: tokens/temas, acessibilidade, responsividade, iconografia.

**Eixos condicionais por contexto do projeto:**
- Telas operacionais (CRUD, busca, data-grid, master-detail).
- Shell/Bootstrap (setup, providers, configuração base).
- Testes (mock, test patterns, cenários, fixtures).
- i18n e localização.
- Permissões granulares e visibilidade condicional.
- Branding e exceções visuais.
- Navegação estrutural.

**Variações abertas:** Além dos eixos, buscar ativamente nos fontes por templates recorrentes, convenções de naming, padrões de composição implícitos, dependências externas com regras próprias, qualquer decisão técnica repetida.

[INSTRUÇÃO] Vasculhar código, docs, configs e exemplos. Para cada candidato registrar:
- Nome sugerido para o guide.
- Eixo de origem.
- Evidência encontrada (o que nos fontes sugere).
- Valor estimado (por que ajudaria).

### Passo 3: Entrevista com o humano

[INSTRUÇÃO] Fazer as perguntas mínimas:
1. Quais decisões corporativas a IA deve respeitar sempre?
2. O que já existe no repositório e deve ser tratado como fonte oficial?
3. É permitido usar documentação externa oficial?
4. O objetivo é orientar só IA ou também humanos?
5. Quer pacote mínimo ou conjunto mais completo?
6. Prefere receber um por vez (validação individual) ou em lote?

[INSTRUÇÃO] Após busca e entrevista, apresentar lista completa de guides candidatos ao humano com: nome, eixo, evidência, valor estimado. Perguntar: quais quer?

### Passo 4: Respeitar seleção do humano

O humano escolhe quais guides quer, modo de entrega (um a um ou lote), e prioridade. Não insistir em guides recusados.

### Passo 5: Gerar `corporative.guide.md` (índice despachador)

[INSTRUÇÃO] Produzir como primeiro artefato, independente de quantos guides individuais forem selecionados:

```md
# Corporate Guide — {nome da biblioteca / projeto}

## Roteamento
- Quando carregar: {condição para a IA carregar este guide}
- Objetivo: {para que serve este índice}

## Catálogo de guides

| Guide | Quando usar | O que resolve | Status |
|---|---|---|---|
| {guide}.guide.md | {condição} | {resumo} | {gerado|pendente|recusado} |

## Regras corporativas gerais
- {regra 1 — decisão que vale para todo o projeto}
- {regra 2}
```

### Passo 6: Gerar guides específicos

[INSTRUÇÃO] Para cada guide aprovado:
1. Ler fontes relevantes (repo, docs, configs).
2. Redigir guide com conteúdo executável — instruções que uma IA consegue seguir sem ambiguidade.
3. Se modo "um por vez": apresentar ao humano para validação.
4. Se modo "lote": gerar todos e apresentar resumo consolidado.

[INSTRUÇÃO] Formato de cada guide:

```md
# {Nome do Guide}

## Objetivo
{O que este guide resolve — em termos concretos de decisão}

## Quando usar
{Em quais situações a IA deve carregar e aplicar este guide}

## Decisão corporativa
{A decisão técnica documentada — clara e sem ambiguidade}

## Regras
- {regra 1 — instrução direta e executável}
- {regra 2}
- ...

## Exemplos / Passo-a-passo

### {Cenário 1}
{Código ou instrução demonstrando a aplicação correcta}

### {Cenário 2}
{Outro exemplo com variação relevante}

## Anti-padrões
- {O que NÃO fazer e por quê}

## Fontes
- {De onde a informação veio — path, URI, ou declaração do humano}
```

[INSTRUÇÃO] O conteúdo dos guides deve ser:
- **Executável** — instruções que a IA aplica directamente.
- **Concreto** — exemplos de código reais, não descrições abstratas.
- **Rastreável** — cada regra aponta para a evidência ou decisão que a sustenta.
- **Útil** — resolve problema real que a IA encontraria ao gerar telas.

---

## GATE CORPORATE-GUIDES

- Busca activa nos fontes realizada.
- Entrevista com humano feita (perguntas mínimas respondidas).
- Lista de candidatos apresentada e seleção feita pelo humano.
- `corporative.guide.md` (índice) gerado.
- Cada guide aprovado foi gerado com conteúdo executável.
- Guides contêm exemplos de código concretos.
- Humano validou os guides (modo individual ou lote).
- Resumo apresentado ao humano.
- Aprovação explícita para seguir.

### Checklist
- Cada guide tem decisão clara e regras executáveis.
- Cada guide tem ao menos um exemplo de código.
- Nenhum guide inventa regra sem evidência ou declaração do humano.
- O índice (`corporative.guide.md`) lista todos os guides com condição de carregamento.
- Guides recusados pelo humano não foram gerados.
